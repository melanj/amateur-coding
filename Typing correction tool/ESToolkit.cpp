/**
ESToolkit.cpp 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Monday, July 28, 2008
@version	2.2.1	
@majorvesions
	n/a	
**/
#include "stdafx.h"
#include "ESToolkit.h"
#include "Dlg.h"
#include "splash.h"


BEGIN_MESSAGE_MAP(CESToolkitApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()



CESToolkitApp::CESToolkitApp()
{

}



CESToolkitApp theApp;



BOOL CESToolkitApp::InitInstance()
{
	CFile lock;
	CString ztmp;
	OSVERSIONINFO vi;

    ZeroMemory(&vi, sizeof(OSVERSIONINFO));
    vi.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);
    ::GetVersionEx(&vi);
    
	if (vi.dwPlatformId == VER_PLATFORM_WIN32_NT && vi.dwMajorVersion >= 6)
		{
	InitCommonControls();
	CWinApp::InitInstance();
	AfxEnableControlContainer();
	SetRegistryKey(_T("Melan Nimesh"));
	AfxGetApp()->WriteProfileInt("Config","options opened",0);
	AfxGetApp()->WriteProfileInt("Config","about opened",0);
   	ztmp.Format("%s\\$$textool.tmp$$", getenv("tmp"));
	if(!lock.Open(ztmp,CFile::modeCreate | CFile::modeWrite)){
	MessageBox(NULL,"Sinhala unicode typing correction tool is already Running","Sinhala Unicode Typing Correction Tool",MB_ICONINFORMATION);
	exit(0);
    }
    if(AfxGetApp()->GetProfileInt("Config","Show Splash",1)==1){
	
	splash tsplash;	
	tsplash.DoModal();
	
    }
	CESToolkitDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
	}
	else{
	MessageBox(NULL,"The version of this file is not compatible with the version of Windows you're running. Check your computer's system information to see whether you need an x86 (32-bit) or x64 (64-bit) version of the program, and then contact the software publisher.","Sinhala Unicode Typing Correction Tool",MB_ICONWARNING);
	}
	return FALSE;
}


