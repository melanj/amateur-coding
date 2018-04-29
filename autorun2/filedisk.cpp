/*
    Control program for a virtual disk driver for Windows NT/2000/XP.
    Copyright (C) 1999, 2000, 2001, 2002 Bo Brantén.
    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/
#include "stdafx.h"
#include <windows.h>
#include <winioctl.h>
#include <stdio.h>
#include <stdlib.h>
#include "filedisk.h"


void PrintLastError(char* Prefix)
{
    LPVOID lpMsgBuf;
    CString msg;
    FormatMessage( 
        FORMAT_MESSAGE_ALLOCATE_BUFFER |
        FORMAT_MESSAGE_FROM_SYSTEM |
        FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL,
        GetLastError(),
        0,
        (LPTSTR) &lpMsgBuf,
        0,
        NULL
        );

	msg.Format("%s %s", Prefix, (LPTSTR) lpMsgBuf);
    //fprintf(stderr, "%s %s", Prefix, (LPTSTR) lpMsgBuf);
    MessageBox(0,msg,"error",MB_ICONSTOP);
    LocalFree(lpMsgBuf);
}

int
FileDiskMount(
    int                     DeviceNumber,
    POPEN_FILE_INFORMATION  OpenFileInformation,
    char                    DriveLetter,
    BOOLEAN                 CdImage
)
{
    char    VolumeName[] = "\\\\.\\ :";
    char    DeviceName[255];
    HANDLE  Device;
    DWORD   BytesReturned;

    VolumeName[4] = DriveLetter;

    Device = CreateFile(
        VolumeName,
        GENERIC_READ | GENERIC_WRITE,
        FILE_SHARE_READ | FILE_SHARE_WRITE,
        NULL,
        OPEN_EXISTING,
        FILE_FLAG_NO_BUFFERING,
        NULL
        );

    if (Device != INVALID_HANDLE_VALUE)
    {
        SetLastError(ERROR_BUSY);
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (CdImage)
    {
        sprintf(DeviceName, DEVICE_NAME_PREFIX "Cd" "%u", DeviceNumber);
    }
    else
    {
        sprintf(DeviceName, DEVICE_NAME_PREFIX "%u", DeviceNumber);
    }

    if (!DefineDosDevice(
        DDD_RAW_TARGET_PATH,
        &VolumeName[4],
        DeviceName
        ))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    Device = CreateFile(
        VolumeName,
        GENERIC_READ | GENERIC_WRITE,
        FILE_SHARE_READ | FILE_SHARE_WRITE,
        NULL,
        OPEN_EXISTING,
        FILE_FLAG_NO_BUFFERING,
        NULL
        );

    if (Device == INVALID_HANDLE_VALUE)
    {
        PrintLastError(&VolumeName[4]);
        DefineDosDevice(DDD_REMOVE_DEFINITION, &VolumeName[4], NULL);
        return -1;
    }

    if (!DeviceIoControl(
        Device,
        IOCTL_FILE_DISK_OPEN_FILE,
        OpenFileInformation,
        sizeof(OPEN_FILE_INFORMATION) + OpenFileInformation->FileNameLength - 1,
        NULL,
        0,
        &BytesReturned,
        NULL
        ))
    {
        PrintLastError("FileDisk:");
        DefineDosDevice(DDD_REMOVE_DEFINITION, &VolumeName[4], NULL);
        return -1;
    }
    CloseHandle(Device);  //add by melan 
    return 0;
}

int FileDiskUmount(char DriveLetter)
{
    char    VolumeName[] = "\\\\.\\ :";
    HANDLE  Device;
    DWORD   BytesReturned;

    VolumeName[4] = DriveLetter;

    Device = CreateFile(
        VolumeName,
        GENERIC_READ | GENERIC_WRITE,
        FILE_SHARE_READ | FILE_SHARE_WRITE,
        NULL,
        OPEN_EXISTING,
        FILE_FLAG_NO_BUFFERING,
        NULL
        );

    if (Device == INVALID_HANDLE_VALUE)
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (!DeviceIoControl(
        Device,
        FSCTL_LOCK_VOLUME,
        NULL,
        0,
        NULL,
        0,
        &BytesReturned,
        NULL
        ))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (!DeviceIoControl(
        Device,
        IOCTL_FILE_DISK_CLOSE_FILE,
        NULL,
        0,
        NULL,
        0,
        &BytesReturned,
        NULL
        ))
    {
        PrintLastError("FileDisk:");
        return -1;
    }

    if (!DeviceIoControl(
        Device,
        FSCTL_DISMOUNT_VOLUME,
        NULL,
        0,
        NULL,
        0,
        &BytesReturned,
        NULL
        ))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    if (!DeviceIoControl(
        Device,
        FSCTL_UNLOCK_VOLUME,
        NULL,
        0,
        NULL,
        0,
        &BytesReturned,
        NULL
        ))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    CloseHandle(Device);

    if (!DefineDosDevice(
        DDD_REMOVE_DEFINITION,
        &VolumeName[4],
        NULL
        ))
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    return 0;
}

int FileDiskStatus(char DriveLetter)
{
	CString st;
    char                    VolumeName[] = "\\\\.\\ :";
    HANDLE                  Device;
    POPEN_FILE_INFORMATION  OpenFileInformation;
    DWORD                   BytesReturned;

    VolumeName[4] = DriveLetter;

    Device = CreateFile(
        VolumeName,
        GENERIC_READ,
        FILE_SHARE_READ | FILE_SHARE_WRITE,
        NULL,
        OPEN_EXISTING,
        FILE_FLAG_NO_BUFFERING,
        NULL
        );

    if (Device == INVALID_HANDLE_VALUE)
    {
        PrintLastError(&VolumeName[4]);
        return -1;
    }

    OpenFileInformation =(POPEN_FILE_INFORMATION) malloc(sizeof(OPEN_FILE_INFORMATION) + MAX_PATH);

    if (!DeviceIoControl(
        Device,
        IOCTL_FILE_DISK_QUERY_FILE,
        NULL,
        0,
        OpenFileInformation,
        sizeof(OPEN_FILE_INFORMATION) + MAX_PATH,
        &BytesReturned,
        NULL
        ))
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

	st.Format("%c: %.*s Size: %I64u bytes%s\n",
        DriveLetter,
        OpenFileInformation->FileNameLength,
        OpenFileInformation->FileName,
        OpenFileInformation->FileSize,
        OpenFileInformation->ReadOnly ? ", ReadOnly" : "");


	MessageBox(NULL,st,"status",MB_ICONINFORMATION);
    return 0;
}

int  mount2(int DeviceNumber,char* FileName,char* Option,char DriveLetter)
{
    
    BOOLEAN                 CdImage = FALSE;
    POPEN_FILE_INFORMATION  OpenFileInformation;


  

        OpenFileInformation =
            (POPEN_FILE_INFORMATION)malloc(sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7);

        memset(
            OpenFileInformation,
            0,
            sizeof(OPEN_FILE_INFORMATION) + strlen(FileName) + 7
            );

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

        OpenFileInformation->FileNameLength =
            (USHORT) strlen(OpenFileInformation->FileName);



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
                    OpenFileInformation->FileSize.QuadPart =
                        _atoi64(Option) * 1024 * 1024 * 1024;
                }
                else if (Option[strlen(Option) - 1] == 'M')
                {
                    OpenFileInformation->FileSize.QuadPart =
                        _atoi64(Option) * 1024 * 1024;
                }
                else if (Option[strlen(Option) - 1] == 'k')
                {
                    OpenFileInformation->FileSize.QuadPart =
                        _atoi64(Option) * 1024;
                }
                else
                {
                    OpenFileInformation->FileSize.QuadPart =
                        _atoi64(Option);
                }
            }
        

        return FileDiskMount(DeviceNumber, OpenFileInformation, DriveLetter, CdImage);
    

}
