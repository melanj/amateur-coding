// imgDlg.cpp : implementation file
//

#include "stdafx.h"
#include "img.h"
#include "imgDlg.h"
#include "PictureCtrl.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CimgDlg dialog




CimgDlg::CimgDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CimgDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CimgDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST2, m_ctlListCtrl);
	DDX_Control(pDX, IDC_STATIC1, m_pic);
}

BEGIN_MESSAGE_MAP(CimgDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_NOTIFY(LVN_ITEMCHANGED, IDC_LIST2, &CimgDlg::OnLvnItemchangedList2)
	ON_BN_CLICKED(IDOK, &CimgDlg::OnBnClickedOk)
END_MESSAGE_MAP()


// CimgDlg message handlers

BOOL CimgDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	// TODO: Add extra initialization here
UpdateData(1);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CimgDlg::OnPaint()
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
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CimgDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CimgDlg::OnLvnItemchangedList2(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMLISTVIEW pNMLV = reinterpret_cast<LPNMLISTVIEW>(pNMHDR);
	// TODO: Add your control notification handler code here
	*pResult = 0;
}

void CimgDlg::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here
//	OnOK();
	CFileDialog m_ldFile(TRUE, NULL, NULL, OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, _T("All Files (*.jpg)|*.jpg||"));
	if (m_ldFile.DoModal() == IDOK)
	{
		MessageBox(m_ldFile.GetPathName());
		HBITMAP hbmp;
			hbmp = ::LoadBitmapA(AfxGetInstanceHandle(),m_ldFile.GetPathName());
			m_pic.LoadFromFile(m_ldFile.GetPathName());
			m_pic.SetRedraw(1);
	}

}
