
#include "stdafx.h"
#include "filedisk.h"
#include "filediskDlg.h"


BEGIN_MESSAGE_MAP(CfilediskApp, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()



CfilediskApp::CfilediskApp()
{
	
}



CfilediskApp theApp;


BOOL CfilediskApp::InitInstance()
{
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinApp::InitInstance();

	SetRegistryKey(_T("Local AppWizard-Generated Applications"));

	CfilediskDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		
	}
	else if (nResponse == IDCANCEL)
	{
		
	}

	return FALSE;
}
