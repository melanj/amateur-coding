// jstestDlg.cpp : implementation file
//

#include "stdafx.h"
#include "jstest.h"
#include "jstestDlg.h"
#include "DlgProxy.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CjstestDlg dialog

BEGIN_DHTML_EVENT_MAP(CjstestDlg)
	DHTML_EVENT_ONCLICK(_T("ButtonOK"), OnButtonOK)
	DHTML_EVENT_ONCLICK(_T("ButtonCancel"), OnButtonCancel)
END_DHTML_EVENT_MAP()



IMPLEMENT_DYNAMIC(CjstestDlg, CDHtmlDialog);

CjstestDlg::CjstestDlg(CWnd* pParent /*=NULL*/)
	: CDHtmlDialog(CjstestDlg::IDD, CjstestDlg::IDH, pParent)
{
	EnableAutomation();
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_pAutoProxy = NULL;
}

CjstestDlg::~CjstestDlg()
{
	// If there is an automation proxy for this dialog, set
	//  its back pointer to this dialog to NULL, so it knows
	//  the dialog has been deleted.
	if (m_pAutoProxy != NULL)
		m_pAutoProxy->m_pDialog = NULL;
}

void CjstestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDHtmlDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CjstestDlg, CDHtmlDialog)
	ON_WM_CLOSE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

BEGIN_DISPATCH_MAP(CjstestDlg, CDHtmlDialog)
DISP_FUNCTION(CjstestDlg, "fun1", fun1, VT_EMPTY, VTS_BSTR) // Each methods need here to add mapping
END_DISPATCH_MAP()

// CjstestDlg message handlers

BOOL CjstestDlg::OnInitDialog()
{
	SetExternalDispatch(GetIDispatch(TRUE)); 
	CDHtmlDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CjstestDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDHtmlDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CjstestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

// Automation servers should not exit when a user closes the UI
//  if a controller still holds on to one of its objects.  These
//  message handlers make sure that if the proxy is still in use,
//  then the UI is hidden but the dialog remains around if it
//  is dismissed.

void CjstestDlg::OnClose()
{
	if (CanExit())
		CDHtmlDialog::OnClose();
}

void CjstestDlg::OnOK()
{
	if (CanExit())
		CDHtmlDialog::OnOK();
}

void CjstestDlg::OnCancel()
{
	if (CanExit())
		CDHtmlDialog::OnCancel();
}

BOOL CjstestDlg::CanExit()
{
	// If the proxy object is still around, then the automation
	//  controller is still holding on to this application.  Leave
	//  the dialog around, but hide its UI.
	if (m_pAutoProxy != NULL)
	{
		ShowWindow(SW_HIDE);
		return FALSE;
	}

	return TRUE;
}

HRESULT CjstestDlg::OnButtonOK(IHTMLElement* /*pElement*/)
{
	OnOK();
	return S_OK;
}

HRESULT CjstestDlg::OnButtonCancel(IHTMLElement* /*pElement*/)
{
	OnCancel();
	return S_OK;
}

void CjstestDlg::fun1(LPCTSTR lpszFile)
{
MessageBox(lpszFile);
}