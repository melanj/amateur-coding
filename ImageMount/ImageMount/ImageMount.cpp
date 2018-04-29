// ImageMount.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "ImageMount.h"
#include "ImageMountDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CImageMount

BEGIN_MESSAGE_MAP(CImageMount, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()


// CImageMount construction

CImageMount::CImageMount()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CImageMount object

CImageMount theApp;

// CImageMount initialization

BOOL CImageMount::InitInstance()
{
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinApp::InitInstance();
	OSVERSIONINFO vi;

    ZeroMemory(&vi, sizeof(OSVERSIONINFO));
    vi.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);
     ::GetVersionEx(&vi);

	CImageMountDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with Cancel
	}

	return FALSE;
}
