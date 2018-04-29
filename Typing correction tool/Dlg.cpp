/**
Dlg.cpp 
 
@author	Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Thursday, December 04, 2008 (port to x64)
@version	2.2.2
@majorvesions
	n/a	
**/
#include "stdafx.h"
#include "ESToolkit.h"
#include "Dlg.h"
#include "SystemTray.h"
#include "options.h"
#include "about.h"

#define WM_ICON_NOTIFY  WM_APP+10
CSystemTray m_TrayIcon;
int ci=0,cj=0;

HINSTANCE LDDLL;
void    (WINAPI *Initializedynlibrary)();
void    (WINAPI *Uninitializedynlibrary)();

CESToolkitDlg::CESToolkitDlg(CWnd* pParent)
	: CDialog(CESToolkitDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDI_EN);
	LDDLL = LoadLibrary(_T("DYNLIB.DLL"));
	CString zExe,zmsg;
	zExe = AfxGetApp()->m_pszHelpFilePath;
    zExe.Replace(".HLP",".exe");
	zmsg.Format("Runtime Error!\n\nProgram: %s\n\nThis application has requested the Runtime to terminate it in an unusual way.\nPlease contact the application's support team for more information.",zExe);
	if (LDDLL == NULL)
	{
		MessageBox(zmsg ,"Sinhala Unicode Typing Correction Tool",MB_ICONSTOP);
		exit(-1);
	}

	m_TrayIcon.Create(NULL, WM_ICON_NOTIFY, "Sinhala Unicode Typing Correction Tool", 
                      m_hIcon, IDR_POPUP_MENU,                  
                      FALSE,
                      _T(""), 
                      _T(""),               
                      NIIF_WARNING,                   
                      20 );

	(FARPROC&)Initializedynlibrary = GetProcAddress(LDDLL, _T("Initializedynlibrary"));
     Initializedynlibrary();

	 m_TrayIcon.SetMenuDefaultItem(3,1);

}

void CESToolkitDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CESToolkitDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_MESSAGE(WM_ICON_NOTIFY, OnTrayNotification)
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_POPUP_EXIT, OnPopupExit)
	ON_COMMAND(ID_POPUP_ABOUT, OnPopupAbout)
	ON_COMMAND(ID_POPUP_OPTIONS, OnPopupOptions)
	ON_COMMAND(ID_POPUP_ENABLE, OnPopupEnable)
	ON_WM_TIMER()
END_MESSAGE_MAP()


BOOL CESToolkitDlg::OnInitDialog()
{
	CDialog::OnInitDialog();
	SetIcon(m_hIcon, TRUE);			
	SetIcon(m_hIcon, FALSE);
	SetTimer(ID_HIDE_TIMER, 10, NULL);
	return TRUE;  
}


LRESULT CESToolkitDlg::OnTrayNotification(WPARAM wParam, LPARAM lParam)
{
    return m_TrayIcon.OnTrayNotification(wParam, lParam);
}

void CESToolkitDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this);

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}


HCURSOR CESToolkitDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CESToolkitDlg::OnPopupExit()
{
	if((ci%2)==1){
	m_TrayIcon.ShowBalloon("Sinhala unicode typing correction tool is now exiting","Sinhala Unicode Typing Correction Tool",NIIF_WARNING,20);
	Sleep(3000);
	   }
	else{
	(FARPROC&)Uninitializedynlibrary = GetProcAddress(LDDLL, _T("Uninitializedynlibrary"));
    Uninitializedynlibrary();
	m_TrayIcon.ShowBalloon("Sinhala unicode typing correction tool is Disabled\nand now exiting","Sinhala Unicode Typing Correction Tool",NIIF_WARNING,20);
	Sleep(3000);	
	}
    FreeLibrary(LDDLL);
	AfxGetApp()->WriteProfileInt("Config","options opened",0);
	AfxGetApp()->WriteProfileInt("Config","about opened",0);
    exit(0);
}

void CESToolkitDlg::OnPopupAbout()
{
	if(!AfxGetApp()->GetProfileInt("Config","about opened",0))
	{
	about thtm;
	thtm.DoModal();
	}
	else Beep(800,1);
}

void CESToolkitDlg::OnPopupOptions()
{
	if(!AfxGetApp()->GetProfileInt("Config","options opened",0))
	{
	options tdlg;
	tdlg.DoModal();
	}
	else Beep(800,1);
}

void CESToolkitDlg::OnPopupEnable()
{
	ci++;
	if((ci%2)==1){
	    (FARPROC&)Uninitializedynlibrary = GetProcAddress(LDDLL, _T("Uninitializedynlibrary"));
	    Uninitializedynlibrary();
		m_TrayIcon.SetIcon(IDI_DIS);
	    m_TrayIcon.ShowBalloon("Sinhala unicode typing correction tool is Disabled","Sinhala Unicode Typing Correction Tool",NIIF_INFO,20);
	   }
	else{
		(FARPROC&)Initializedynlibrary = GetProcAddress(LDDLL, _T("Initializedynlibrary"));
        Initializedynlibrary();
		m_TrayIcon.SetIcon(IDI_EN);
	    m_TrayIcon.ShowBalloon("Sinhala unicode typing correction tool is Enabled","Sinhala Unicode Typing Correction Tool",NIIF_INFO,20);
	}

}


void CESToolkitDlg::OnTimer(UINT_PTR nIDEvent)
{
	
    KillTimer(ID_HIDE_TIMER);
	CESToolkitDlg::ShowWindow(0);
	CDialog::OnTimer(nIDEvent);
}

