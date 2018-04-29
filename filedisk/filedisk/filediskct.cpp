/*
@aurhor Melan Nimesh
Tuesday, August 29, 2006
modified :  Monday, December 29, 2008, 
Since v2.0
*/

#include "StdAfx.h"
#include <windows.h>
#include <winioctl.h>
#include <stdio.h>
#include <stdlib.h>
#include <winsvc.h>
#include "filediskct.h"
#include "Resource.h"

char path[MAX_PATH];
HINSTANCE hmodule;

filediskct::filediskct(void)
{
}

filediskct::~filediskct(void)
{
}

int filediskct::StartSvc(void) 
{
	SC_HANDLE FileDiskService,scm;
	scm=OpenSCManager(0,0,SC_MANAGER_CREATE_SERVICE);
	if(!scm)
	{
		//ShowErr();
		return 1;
	}
	FileDiskService=OpenService(scm,_T("filedisk"),SERVICE_ALL_ACCESS);
	if(!FileDiskService)
	{
		CloseServiceHandle(scm);
		//ShowErr();
		return 1;
	}
	StartService(FileDiskService,0,NULL);
	CloseServiceHandle(FileDiskService);
	CloseServiceHandle(scm);
	return 0;
}

int filediskct::StopSvc(void)  
{
	SC_HANDLE FileDiskService,scm;
	scm=OpenSCManager(0,0,SC_MANAGER_CREATE_SERVICE);
	if(!scm)
	{
		//ShowErr();
		return 1;
	}
	FileDiskService=OpenService(scm,_T("filedisk"),SERVICE_ALL_ACCESS);
	if(!FileDiskService)
	{
		CloseServiceHandle(scm);
		//ShowErr();
		return 1;
	}
	SERVICE_STATUS m_SERVICE_STATUS;
	ControlService(FileDiskService,SERVICE_CONTROL_STOP,&m_SERVICE_STATUS);
	CloseServiceHandle(FileDiskService);
	CloseServiceHandle(scm);
	return 0;
}
int filediskct::InstallSvc(void)  
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
				strcat_s(path,"\\Drivers\\filedisk.sys");
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
				return 5;  // error access denied
			}
		}	
		else
		{
		   Ser = CreateService (Mgr,                      
                                "filedisk",                        
                                "filedisk",                        
                                SERVICE_ALL_ACCESS,                
                                SERVICE_KERNEL_DRIVER,             
                                SERVICE_SYSTEM_START,               
                                SERVICE_ERROR_NORMAL,               
                                "System32\\Drivers\\filedisk.sys",  
                                NULL,                               
                                NULL,                              
                                NULL,                               
                                NULL,                              
                                NULL                               
                                );

		}

CloseServiceHandle(Ser);
CloseServiceHandle(Mgr);
WinExec("reg add \"HKLM\\SYSTEM\\ControlSet001\\Services\\filedisk\" /f /v Start /t REG_DWORD /d 00000003",0);
return 0;
}

void filediskct::PrintLastError(char* Prefix)
{
    LPVOID lpMsgBuf;
    CString msg;
    FormatMessage( FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, NULL,GetLastError(),0,(LPTSTR) &lpMsgBuf,0,NULL);
	msg.Format(_T("%s %s"), Prefix, (LPTSTR) lpMsgBuf);
    MessageBox(0,msg,_T("error"),MB_ICONINFORMATION);
    LocalFree(lpMsgBuf);
}


int filediskct::FileDiskMount(int DeviceNumber,POPEN_FILE_INFORMATION  OpenFileInformation, char DriveLetter,BOOLEAN CdImage)
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
        PrintLastError("FileDisk:");
        DefineDosDeviceA(DDD_REMOVE_DEFINITION, &VolumeName[4], NULL);
        return -1;
    }
    CloseHandle(Device);  
    return 0;
}

int filediskct::Umount(char DriveLetter)
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
        PrintLastError("FileDisk:");
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

int filediskct::Status(char DriveLetter)
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

int  filediskct::Mount(int DeviceNumber,char* FileName,char* Option,char DriveLetter) 
{
    
    BOOLEAN                 CdImage = FALSE;
    POPEN_FILE_INFORMATION  OpenFileInformation;

        OpenFileInformation =(POPEN_FILE_INFORMATION)malloc(sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        memset(OpenFileInformation,0,sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        if (FileName[0] == '\\')
        {
            if (FileName[1] == '\\')
                // \\server\share\path\filedisk.img
            {
                strcpy(OpenFileInformation->FileName, "\\??\\UNC");
                strcat(OpenFileInformation->FileName, FileName + 1);
            }
            else
                // \Device\Harddisk0\Partition1\path\filedisk.img
            {
                strcpy(OpenFileInformation->FileName, FileName);
            }
        }
        else
            // c:\path\filedisk.img
        {
            strcpy(OpenFileInformation->FileName, "\\??\\");
            strcat(OpenFileInformation->FileName, FileName);
        }

        OpenFileInformation->FileNameLength =(USHORT) strlen(OpenFileInformation->FileName);

            if (!strcmp(Option, "/ro"))
            {
                OpenFileInformation->ReadOnly = TRUE;
            }
            else if (!strcmp(Option, "/cd"))
            {
                CdImage = TRUE;
            }
            else if (strcmp(Option, ""))
            {
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
            }
        
        return FileDiskMount(DeviceNumber, OpenFileInformation, DriveLetter, CdImage);
    

}

CString  filediskct::GetStatus(char DriveLetter)
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

int filediskct::SvcStatus(void)  
{
	SC_HANDLE FileDiskService,scm;
	scm=OpenSCManager(0,0,SC_MANAGER_CREATE_SERVICE);
	if(!scm)
	{
		//ShowErr();
		return -1;
	}
	FileDiskService=OpenService(scm,_T("filedisk"),SERVICE_ALL_ACCESS);
	if(!FileDiskService)
	{
		CloseServiceHandle(scm);
		//ShowErr();
		return -1;
	}
	SERVICE_STATUS m_SERVICE_STATUS;
	if( !QueryServiceStatus(FileDiskService, &m_SERVICE_STATUS))
		{
			return -1;
		}
	switch(m_SERVICE_STATUS.dwCurrentState){
	case SERVICE_STOPPED:
                    MessageBox(0,"Stopped","",MB_ICONINFORMATION);
					break;
	case SERVICE_START_PENDING:
                    MessageBox(0,"Start Pending","",MB_ICONINFORMATION);
					break;
	case SERVICE_STOP_PENDING:
                    MessageBox(0,"Stop Pending","",MB_ICONINFORMATION);
					break;
	case SERVICE_RUNNING:
                    MessageBox(0,"Running","",MB_ICONINFORMATION);
					break;
	case SERVICE_CONTINUE_PENDING:
                    MessageBox(0,"Coninue Pending","",MB_ICONINFORMATION);
					break;
	case SERVICE_PAUSE_PENDING:
                    MessageBox(0,"Pause Pending","",MB_ICONINFORMATION);
					break;
	case SERVICE_PAUSED:
                    MessageBox(0,"Paused","",MB_ICONINFORMATION);
					break;
	default: return 1;
	}
	CloseServiceHandle(FileDiskService);
	CloseServiceHandle(scm);
	return 0;
}