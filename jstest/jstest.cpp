// jstest.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "jstest.h"
#include "jstestDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CjstestApp

BEGIN_MESSAGE_MAP(CjstestApp, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()


// CjstestApp construction

CjstestApp::CjstestApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CjstestApp object

CjstestApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x5251279F, 0x2D27, 0x4F37, { 0x8A, 0xAA, 0xC1, 0x18, 0x15, 0x36, 0x76, 0x42 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;


// CjstestApp initialization

BOOL CjstestApp::InitInstance()
{
	// InitCommonControlsEx() is required on Windows XP if an application
	// manifest specifies use of ComCtl32.dll version 6 or later to enable
	// visual styles.  Otherwise, any window creation will fail.
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	// Set this to include all the common control classes you want to use
	// in your application.
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinApp::InitInstance();

	// Initialize OLE libraries
	if (!AfxOleInit())
	{
		AfxMessageBox(IDP_OLE_INIT_FAILED);
		return FALSE;
	}

	AfxEnableControlContainer();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	// of your final executable, you should remove from the following
	// the specific initialization routines you do not need
	// Change the registry key under which our settings are stored
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization
	SetRegistryKey(_T("Local AppWizard-Generated Applications"));
	// Parse command line for automation or reg/unreg switches.
	CCommandLineInfo cmdInfo;
	ParseCommandLine(cmdInfo);

	// App was launched with /Embedding or /Automation switch.
	// Run app as automation server.
	if (cmdInfo.m_bRunEmbedded || cmdInfo.m_bRunAutomated)
	{
		// Register class factories via CoRegisterClassObject().
		COleTemplateServer::RegisterAll();
	}
	// App was launched with /Unregserver or /Unregister switch.  Remove
	// entries from the registry.
	else if (cmdInfo.m_nShellCommand == CCommandLineInfo::AppUnregister)
	{
		COleObjectFactory::UpdateRegistryAll(FALSE);
		AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor);
		return FALSE;
	}
	// App was launched standalone or with other switches (e.g. /Register
	// or /Regserver).  Update registry entries, including typelibrary.
	else
	{
		COleObjectFactory::UpdateRegistryAll();
		AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid);
		if (cmdInfo.m_nShellCommand == CCommandLineInfo::AppRegister)
			return FALSE;
	}

	CjstestDlg dlg;
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

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
