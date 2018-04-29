/*
@aurhor Melan Nimesh
Tuesday, August 29, 2006
modified :  Monday, December 29, 2008, v2.0
*/

#pragma once

#ifndef _DIMAGE_
#define _DIMAGE_

#ifndef __T
#ifdef _NTDDK_
#define __T(x)  L ## x
#else
#define __T(x)  x
#endif
#endif

#ifndef _T
#define _T(x)   __T(x)
#endif

#define DEVICE_BASE_NAME    _T("\\dimage")
#define DEVICE_DIR_NAME     _T("\\Device")      DEVICE_BASE_NAME
#define DEVICE_NAME_PREFIX  DEVICE_DIR_NAME     DEVICE_BASE_NAME

#define FILE_DEVICE_FILE_DISK       0x8000

#define IOCTL_FILE_DISK_OPEN_FILE   CTL_CODE(FILE_DEVICE_FILE_DISK, 0x800, METHOD_BUFFERED, FILE_READ_ACCESS | FILE_WRITE_ACCESS)
#define IOCTL_FILE_DISK_CLOSE_FILE  CTL_CODE(FILE_DEVICE_FILE_DISK, 0x801, METHOD_BUFFERED, FILE_READ_ACCESS | FILE_WRITE_ACCESS)
#define IOCTL_FILE_DISK_QUERY_FILE  CTL_CODE(FILE_DEVICE_FILE_DISK, 0x802, METHOD_BUFFERED, FILE_READ_ACCESS)

typedef struct _OPEN_FILE_INFORMATION {
    LARGE_INTEGER   FileSize;
    BOOLEAN         ReadOnly;
    short          FileNameLength;
    char           FileName[1];
} OPEN_FILE_INFORMATION, *POPEN_FILE_INFORMATION;
#endif

class Svctrl
{
public:
	Svctrl(void);
	int Mount(int DeviceNumber,char* FileName,BOOLEAN readonly,char DriveLetter);
	int MountCD(int DeviceNumber,char* FileName,char DriveLetter);
	int MountNew(int DeviceNumber,char* FileName,char* Option,char DriveLetter);
	int Umount(char DriveLetter);
	int Status(char DriveLetter);
	int StartSvc(void);
	int StopSvc(void);
	int InstallSvc(void);
	CString GetStatus(char DriveLetter);
	int SvcStatus(void);
	~Svctrl(void);
private:
	int DiskMount(int DeviceNumber,POPEN_FILE_INFORMATION  OpenFileInformation, char DriveLetter,BOOLEAN CdImage);
	void PrintLastError(char* Prefix);
};
