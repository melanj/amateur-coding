// DlgProxy.cpp : implementation file
//

#include "stdafx.h"
#include "jstest.h"
#include "DlgProxy.h"
#include "jstestDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CjstestDlgAutoProxy

IMPLEMENT_DYNCREATE(CjstestDlgAutoProxy, CCmdTarget)

CjstestDlgAutoProxy::CjstestDlgAutoProxy()
{
	EnableAutomation();
	
	// To keep the application running as long as an automation 
	//	object is active, the constructor calls AfxOleLockApp.
	AfxOleLockApp();

	// Get access to the dialog through the application's
	//  main window pointer.  Set the proxy's internal pointer
	//  to point to the dialog, and set the dialog's back pointer to
	//  this proxy.
	ASSERT_VALID(AfxGetApp()->m_pMainWnd);
	if (AfxGetApp()->m_pMainWnd)
	{
		ASSERT_KINDOF(CjstestDlg, AfxGetApp()->m_pMainWnd);
		if (AfxGetApp()->m_pMainWnd->IsKindOf(RUNTIME_CLASS(CjstestDlg)))
		{
			m_pDialog = reinterpret_cast<CjstestDlg*>(AfxGetApp()->m_pMainWnd);
			m_pDialog->m_pAutoProxy = this;
		}
	}
}

CjstestDlgAutoProxy::~CjstestDlgAutoProxy()
{
	// To terminate the application when all objects created with
	// 	with automation, the destructor calls AfxOleUnlockApp.
	//  Among other things, this will destroy the main dialog
	if (m_pDialog != NULL)
		m_pDialog->m_pAutoProxy = NULL;
	AfxOleUnlockApp();
}

void CjstestDlgAutoProxy::OnFinalRelease()
{
	// When the last reference for an automation object is released
	// OnFinalRelease is called.  The base class will automatically
	// deletes the object.  Add additional cleanup required for your
	// object before calling the base class.

	CCmdTarget::OnFinalRelease();
}

BEGIN_MESSAGE_MAP(CjstestDlgAutoProxy, CCmdTarget)
END_MESSAGE_MAP()

BEGIN_DISPATCH_MAP(CjstestDlgAutoProxy, CCmdTarget)
END_DISPATCH_MAP()

// Note: we add support for IID_Ijstest to support typesafe binding
//  from VBA.  This IID must match the GUID that is attached to the 
//  dispinterface in the .IDL file.

// {C1C4D84F-CAB6-4387-985E-713880CB5786}
static const IID IID_Ijstest =
{ 0xC1C4D84F, 0xCAB6, 0x4387, { 0x98, 0x5E, 0x71, 0x38, 0x80, 0xCB, 0x57, 0x86 } };

BEGIN_INTERFACE_MAP(CjstestDlgAutoProxy, CCmdTarget)
	INTERFACE_PART(CjstestDlgAutoProxy, IID_Ijstest, Dispatch)
END_INTERFACE_MAP()

// The IMPLEMENT_OLECREATE2 macro is defined in StdAfx.h of this project
// {68E2F675-62FF-46D4-A39A-3F72BD6DCF1B}
IMPLEMENT_OLECREATE2(CjstestDlgAutoProxy, "jstest.Application", 0x68e2f675, 0x62ff, 0x46d4, 0xa3, 0x9a, 0x3f, 0x72, 0xbd, 0x6d, 0xcf, 0x1b)


// CjstestDlgAutoProxy message handlers
