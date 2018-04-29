#pragma once

class cmount
{
public:
	cmount(void);
	virtual ~cmount(void);
	int  mount(int DeviceNumber,char* FileName,char DriveLetter);
	int  mount(int DeviceNumber,char* FileName,char DriveLetter, char* Option);
	int  mount(int DeviceNumber,char* FileName,char DriveLetter, char* Option,bool newfile);
    int  Umount(char DriveLetter);
    int  Status(char DriveLetter);
};
