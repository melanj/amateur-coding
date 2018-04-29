/*
@aurhor Melan Nimesh
Tuesday, August 29, 2006
modified :  Monday, December 29, 2008, 
Since v0.2
*/

#include "StdAfx.h"
#include <windows.h>
#include <winioctl.h>
#include <stdio.h>
#include <stdlib.h>
#include <winsvc.h>
#include "Svctrl.h"
#include "Resource.h"

char path[MAX_PATH];
HINSTANCE hmodule;

Svctrl::Svctrl(void)
{
}

Svctrl::~Svctrl(void)
{
}

int Svctrl::StartSvc(void) 
{
	SC_HANDLE Service,scm;
	scm=OpenSCManager(0,0,SC_MANAGER_CREATE_SERVICE);
	if(!scm)
	{
		//ShowErr();
		return 0;
	}
	Service=OpenService(scm,_T("dimage"),SERVICE_ALL_ACCESS);
	if(!Service)
	{
		CloseServiceHandle(scm);
		//ShowErr();
		return 0;
	}
	StartService(Service,0,NULL);
	CloseServiceHandle(Service);
	CloseServiceHandle(scm);
	return 1;
}

int Svctrl::StopSvc(void)  
{
	SC_HANDLE Service,scm;
	scm=OpenSCManager(0,0,SC_MANAGER_CREATE_SERVICE);
	if(!scm)
	{
		//ShowErr();
		return 0;
	}
	Service=OpenService(scm,_T("dimage"),SERVICE_ALL_ACCESS);
	if(!Service)
	{
		CloseServiceHandle(scm);
		//ShowErr();
		return 0;
	}
	SERVICE_STATUS m_SERVICE_STATUS;
	ControlService(Service,SERVICE_CONTROL_STOP,&m_SERVICE_STATUS);
	CloseServiceHandle(Service);
	CloseServiceHandle(scm);
	return 1;
}
int Svctrl::InstallSvc(void)  
{
	SC_HANDLE  Mgr;
    SC_HANDLE  Ser; 
	GetSystemDirectory(path , sizeof(path));
	HRSRC hResource = FindResource(NULL, MAKEINTRESOURCE(IDR_BIN), "bin");
	if(hResource)
	{
		HGLOBAL binGlob = LoadResource(NULL, hResource);
		if(binGlob)
		{
			void *binData = LockResource(binGlob);
		
			if(binData)
			{
				HANDLE file;
				strcat_s(path,"\\Drivers\\dimage.sys");
				file = CreateFile(path,
								  GENERIC_WRITE,
								  0,
								  NULL,
								  CREATE_ALWAYS,
								  0,
								  NULL);

				if(file)
				{
					DWORD size, written;
					size = SizeofResource(NULL, hResource);
					WriteFile(file, binData, size, &written, NULL);
					CloseHandle(file);

				}
			}
		}
	}


		Mgr = OpenSCManager (NULL, NULL,SC_MANAGER_ALL_ACCESS);
	    if (Mgr == NULL)
		{	
			//No permission to create service
			if (GetLastError() == ERROR_ACCESS_DENIED) 
			{
				return 0;  // error access denied
				MessageBox(0,"Error : Access was denied","access denied",MB_ICONSTOP);
			}
		}	
		else
		{
		   Ser = CreateService (Mgr,                      
                                "dimage",                        
                                "Disk Image Mounting Device Driver",                        
                                SERVICE_ALL_ACCESS,                
                                SERVICE_KERNEL_DRIVER,             
                                SERVICE_SYSTEM_START,               
                                SERVICE_ERROR_NORMAL,               
                                "System32\\Drivers\\dimage.sys",  
                                NULL,                               
                                NULL,                              
                                NULL,                               
                                NULL,                              
                                NULL                               
                                );


		}

CloseServiceHandle(Ser);
CloseServiceHandle(Mgr);
return 1;
}

void Svctrl::PrintLastError(char* Prefix)
{
    LPVOID lpMsgBuf;
    CString msg;
    FormatMessage( FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, NULL,GetLastError(),0,(LPTSTR) &lpMsgBuf,0,NULL);
	msg.Format(_T("%s %s"), Prefix, (LPTSTR) lpMsgBuf);
    MessageBox(0,msg,_T("error"),MB_ICONINFORMATION);
    LocalFree(lpMsgBuf);
}


int Svctrl::DiskMount(int DeviceNumber,POPEN_FILE_INFORMATION  OpenFileInformation, char DriveLetter,BOOLEAN CdImage)
{
    char    VolumeName[] = "\\\\.\\ :";
    char    DeviceName[255];
//	CString DeviceName;
    HANDLE  Device;
    DWORD   BytesReturned;

    VolumeName[4] = DriveLetter;

    Device = CreateFile(VolumeName,GENERIC_READ | GENERIC_WRITE,FILE_SHARE_READ | FILE_SHARE_WRITE,NULL,OPEN_EXISTING,FILE_FLAG_NO_BUFFERING,NULL);

    if (Device != INVALID_HANDLE_VALUE)
    {
        SetLastError(ERROR_BUSY);
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (CdImage)
    {
      sprintf_s(DeviceName,DEVICE_NAME_PREFIX "Cd" "%u", DeviceNumber);
	}
    else
    {
       sprintf_s(DeviceName, DEVICE_NAME_PREFIX "%u", DeviceNumber);
	}

    if (!DefineDosDevice(DDD_RAW_TARGET_PATH,&VolumeName[4],DeviceName))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    Device = CreateFile(VolumeName,GENERIC_READ | GENERIC_WRITE,FILE_SHARE_READ | FILE_SHARE_WRITE,NULL,OPEN_EXISTING,FILE_FLAG_NO_BUFFERING,NULL);

    if (Device == INVALID_HANDLE_VALUE)
    {
        PrintLastError(&VolumeName[4]);
        DefineDosDeviceA(DDD_REMOVE_DEFINITION, &VolumeName[4], NULL);
        return -1;
    }

    if (!DeviceIoControl(Device,IOCTL_FILE_DISK_OPEN_FILE,OpenFileInformation,sizeof(OPEN_FILE_INFORMATION) + OpenFileInformation->FileNameLength - 1,NULL,0,&BytesReturned,NULL))
    {
        PrintLastError("dimage:");
        DefineDosDeviceA(DDD_REMOVE_DEFINITION, &VolumeName[4], NULL);
        return -1;
    }
    CloseHandle(Device);  
    return 0;
}

int Svctrl::Umount(char DriveLetter)
{
    char    VolumeName[] = "\\\\.\\ :";
    HANDLE  Device;
    DWORD   BytesReturned;

    VolumeName[4] = DriveLetter;

    Device = CreateFileA(VolumeName,GENERIC_READ | GENERIC_WRITE,FILE_SHARE_READ | FILE_SHARE_WRITE,NULL,OPEN_EXISTING,FILE_FLAG_NO_BUFFERING,NULL);

    if (Device == INVALID_HANDLE_VALUE)
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (!DeviceIoControl(Device,FSCTL_LOCK_VOLUME,NULL,0,NULL,0,&BytesReturned,NULL))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (!DeviceIoControl(Device,IOCTL_FILE_DISK_CLOSE_FILE,NULL,0,NULL,0,&BytesReturned,NULL))
    {
        PrintLastError("dimage:");
        return -1;
    }

    if (!DeviceIoControl(Device,FSCTL_DISMOUNT_VOLUME,NULL,0,NULL,0,&BytesReturned,NULL))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (!DeviceIoControl(Device,FSCTL_UNLOCK_VOLUME,NULL,0,NULL,0,&BytesReturned,NULL))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    CloseHandle(Device);

    if (!DefineDosDevice(DDD_REMOVE_DEFINITION,&VolumeName[4],NULL))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    return 0;
}

int Svctrl::Status(char DriveLetter)
{
	CString st;
    char                    VolumeName[] = "\\\\.\\ :";
    HANDLE                  Device;
    POPEN_FILE_INFORMATION  OpenFileInformation;
    DWORD                   BytesReturned;

    VolumeName[4] = DriveLetter;

    Device = CreateFileA(VolumeName,GENERIC_READ,FILE_SHARE_READ | FILE_SHARE_WRITE,NULL,OPEN_EXISTING,FILE_FLAG_NO_BUFFERING,NULL);

    if (Device == INVALID_HANDLE_VALUE)
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    OpenFileInformation =(POPEN_FILE_INFORMATION) malloc(sizeof(OPEN_FILE_INFORMATION) + MAX_PATH);

    if (!DeviceIoControl(Device,IOCTL_FILE_DISK_QUERY_FILE,NULL,0,OpenFileInformation,sizeof(OPEN_FILE_INFORMATION) + MAX_PATH,&BytesReturned,NULL))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (BytesReturned < sizeof(OPEN_FILE_INFORMATION))
    {
        SetLastError(ERROR_INSUFFICIENT_BUFFER);
        PrintLastError(&VolumeName[4]);
        return -1;
    }

	st.Format(_T("%c: %.*s Size: %I64u bytes%s\n"),DriveLetter,OpenFileInformation->FileNameLength,OpenFileInformation->FileName,OpenFileInformation->FileSize,OpenFileInformation->ReadOnly ? ", ReadOnly" : "");
	MessageBox(NULL,st,_T("status"),MB_ICONINFORMATION);
	CloseHandle(Device);  
    return 0;
}

int  Svctrl::Mount(int DeviceNumber,char* FileName,BOOLEAN readonly,char DriveLetter) 
{
    
    POPEN_FILE_INFORMATION  OpenFileInformation;

        OpenFileInformation =(POPEN_FILE_INFORMATION)malloc(sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        memset(OpenFileInformation,0,sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        if (FileName[0] == '\\')
        {
            if (FileName[1] == '\\')
                // \\server\share\path\dimage.img
            {
                strcpy(OpenFileInformation->FileName, "\\??\\UNC");
                strcat(OpenFileInformation->FileName, FileName + 1);
            }
            else
                // \Device\Harddisk0\Partition1\path\dimage.img
            {
                strcpy(OpenFileInformation->FileName, FileName);
            }
        }
        else
            // c:\path\dimage.img
        {
            strcpy(OpenFileInformation->FileName, "\\??\\");
            strcat(OpenFileInformation->FileName, FileName);
        }

        OpenFileInformation->FileNameLength =(USHORT) strlen(OpenFileInformation->FileName);
        OpenFileInformation->ReadOnly = readonly;

        
        return DiskMount(DeviceNumber, OpenFileInformation, DriveLetter, FALSE);
    

}

CString  Svctrl::GetStatus(char DriveLetter)
{
	CString st;
	CString r;
    char                    VolumeName[] = "\\\\.\\ :";
    HANDLE                  Device;
    POPEN_FILE_INFORMATION  OpenFileInformation;
    DWORD                   BytesReturned;

    VolumeName[4] = DriveLetter;

    Device = CreateFileA(VolumeName,GENERIC_READ,FILE_SHARE_READ | FILE_SHARE_WRITE,NULL,OPEN_EXISTING,FILE_FLAG_NO_BUFFERING,NULL);

    if (Device == INVALID_HANDLE_VALUE)
    {
        return "";
    }

    OpenFileInformation =(POPEN_FILE_INFORMATION) malloc(sizeof(OPEN_FILE_INFORMATION) + MAX_PATH);

    if (!DeviceIoControl(Device,IOCTL_FILE_DISK_QUERY_FILE,NULL,0,OpenFileInformation,sizeof(OPEN_FILE_INFORMATION) + MAX_PATH,&BytesReturned,NULL))
    {
        return "";
    }

    if (BytesReturned < sizeof(OPEN_FILE_INFORMATION))
    {
        SetLastError(ERROR_INSUFFICIENT_BUFFER);
        return "";
    }

	st.Format(_T("%c: %.*s Size: %I64u bytes%s\n"),DriveLetter,OpenFileInformation->FileNameLength,OpenFileInformation->FileName,OpenFileInformation->FileSize,OpenFileInformation->ReadOnly ? ", ReadOnly" : "");
	r.Format(_T("%.*s|%I64u"),OpenFileInformation->FileNameLength,OpenFileInformation->FileName,OpenFileInformation->FileSize);
	r.Replace("\\??\\","");
	CloseHandle(Device); 
	return r;
}

int Svctrl::SvcStatus(void)  
{
	SC_HANDLE Service,scm;
	scm=OpenSCManager(0,0,SC_MANAGER_CREATE_SERVICE);
	if(!scm)
	{
		//ShowErr();
		return -2;
	}
	Service=OpenService(scm,_T("dimage"),SERVICE_ALL_ACCESS);
	if(!Service)
	{
		CloseServiceHandle(scm);
		//ShowErr();
		return -1;
	}
	SERVICE_STATUS m_SERVICE_STATUS;
	if( !QueryServiceStatus(Service, &m_SERVICE_STATUS))
		{
			return 0;
		}
	switch(m_SERVICE_STATUS.dwCurrentState){
	case SERVICE_STOPPED:
                    return 1;
					break;
	case SERVICE_START_PENDING:
                    return 2;
					break;
	case SERVICE_RUNNING:
                    return 3;
					break;
	case SERVICE_CONTINUE_PENDING:
                    return 4;
					break;
	case SERVICE_PAUSE_PENDING:
                    return 5;
					break;
	case SERVICE_PAUSED:
                    return 6;
					break;
	default: return 7;
	}
	CloseServiceHandle(Service);
	CloseServiceHandle(scm);
	return 0;
}

int  Svctrl::MountCD(int DeviceNumber,char* FileName,char DriveLetter) 
{
    
    POPEN_FILE_INFORMATION  OpenFileInformation;

	OpenFileInformation =(POPEN_FILE_INFORMATION)malloc(sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);
	memset(OpenFileInformation,0,sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        if (FileName[0] == '\\')
        {
            if (FileName[1] == '\\')
                // \\server\share\path\dimage.img
            {
                strcpy(OpenFileInformation->FileName, "\\??\\UNC");
                strcat(OpenFileInformation->FileName, FileName + 1);
            }
            else
                // \Device\Harddisk0\Partition1\path\dimage.img
            {
                strcpy(OpenFileInformation->FileName, FileName);
            }
        }
        else
            // c:\path\dimage.img
        {
            strcpy(OpenFileInformation->FileName, "\\??\\");
            strcat(OpenFileInformation->FileName, FileName);
        }

        OpenFileInformation->FileNameLength =(USHORT) strlen(OpenFileInformation->FileName);

        return DiskMount(DeviceNumber, OpenFileInformation, DriveLetter, TRUE);
    

}

int  Svctrl::MountNew(int DeviceNumber,char* FileName,char* Option,char DriveLetter) 
{
    
    BOOLEAN                 CdImage = FALSE;
    POPEN_FILE_INFORMATION  OpenFileInformation;

        OpenFileInformation =(POPEN_FILE_INFORMATION)malloc(sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        memset(OpenFileInformation,0,sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        if (FileName[0] == '\\')
        {
            if (FileName[1] == '\\')
                // \\server\share\path\dimage.img
            {
                strcpy(OpenFileInformation->FileName, "\\??\\UNC");
                strcat(OpenFileInformation->FileName, FileName + 1);
            }
            else
                // \Device\Harddisk0\Partition1\path\dimage.img
            {
                strcpy(OpenFileInformation->FileName, FileName);
            }
        }
        else
            // c:\path\dimage.img
        {
            strcpy(OpenFileInformation->FileName, "\\??\\");
            strcat(OpenFileInformation->FileName, FileName);
        }

        OpenFileInformation->FileNameLength =(USHORT) strlen(OpenFileInformation->FileName);

                if (Option[strlen(Option) - 1] == 'G')
                {
                    OpenFileInformation->FileSize.QuadPart = _atoi64(Option) * 1024 * 1024 * 1024;
                }
                else if (Option[strlen(Option) - 1] == 'M')
                {
                    OpenFileInformation->FileSize.QuadPart = _atoi64(Option) * 1024 * 1024;
                }
                else if (Option[strlen(Option) - 1] == 'k')
                {
                    OpenFileInformation->FileSize.QuadPart = _atoi64(Option) * 1024;
                }
                else
                {
                    OpenFileInformation->FileSize.QuadPart = _atoi64(Option);
                }
  
        
        return DiskMount(DeviceNumber, OpenFileInformation, DriveLetter, CdImage);
    

}