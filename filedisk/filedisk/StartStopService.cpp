/* A console program that starts/stops our skeleton service */
/* Author :- Nishant S */
/* EMail :- nish@inapp.com */

#include <iostream.h>
#include <windows.h>
#include <winsvc.h>

void ShowErr();

int main(int argc, char* argv[])
{
	if(argc<2)
	{
		cout << "Usage:- StartStopService start|stop\r\n";
		return 1;
	}
	SC_HANDLE NishService,scm;
	scm=OpenSCManager(0,0,SC_MANAGER_CREATE_SERVICE);
	if(!scm)
	{
		ShowErr();
		return 1;
	}
	NishService=OpenService(scm,"NishService",SERVICE_ALL_ACCESS);
	if(!NishService)
	{
		CloseServiceHandle(scm);
		ShowErr();
		return 1;
	}
	if(strcmp(argv[1],"start")==0)
	{
		cout << "starting...\r\n";
		StartService(NishService,0,NULL);
	}
	if(strcmp(argv[1],"stop")==0)
	{
		cout << "stopping...\r\n";
		SERVICE_STATUS m_SERVICE_STATUS;
		ControlService(NishService,SERVICE_CONTROL_STOP,&m_SERVICE_STATUS);
	}
	
	CloseServiceHandle(NishService);
	CloseServiceHandle(scm);
	return 0;
}

void ShowErr()
{
	cout << "Error" << "\r\n";
}