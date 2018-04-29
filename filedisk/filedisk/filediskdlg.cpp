// filediskDlg.cpp : implementation file
//

#include "stdafx.h"
#include "filedisk.h"
#include "filediskDlg.h"
#include <direct.h>
#include "filediskct.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif

filediskct Svc;
CString CuSelDrive;
int nDevice=0;
CRect formRect; 
int advshow=0;


class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()







CfilediskDlg::CfilediskDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CfilediskDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CfilediskDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_PATH, m_Path);
	DDX_Control(pDX, IDC_DRIVE, m_Drive);
	DDX_Control(pDX, IDC_BROWSE, m_Browse);
	DDX_Control(pDX, IDC_MOUNT, m_Mount);
	DDX_Control(pDX, IDC_LIST_MOUNT, m_Mounted);
	DDX_Control(pDX, IDC_SVC_START, m_SvcStart);
	DDX_Control(pDX, IDC_SVC_STOP, m_SvcStop);
	DDX_Control(pDX, IDC_SVC_INSTALL, m_SvcInstall);
}

BEGIN_MESSAGE_MAP(CfilediskDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BROWSE, &CfilediskDlg::OnBnClickedBrowse)
ON_BN_CLICKED(IDC_MOUNT, &CfilediskDlg::OnBnClickedMount)
ON_BN_CLICKED(IDC_SVC_INSTALL, &CfilediskDlg::OnBnClickedSvcInstall)
ON_BN_CLICKED(IDC_SVC_START, &CfilediskDlg::OnBnClickedSvcStart)
ON_BN_CLICKED(IDC_SVC_STOP, &CfilediskDlg::OnBnClickedSvcStop)
ON_NOTIFY(LVN_ITEMCHANGED, IDC_LIST_MOUNT, &CfilediskDlg::OnLvnItemchangedListMount)
ON_BN_CLICKED(IDC_UMOUNT, &CfilediskDlg::OnBnClickedUmount)
ON_BN_CLICKED(IDC_UMOUNT_ALL, &CfilediskDlg::OnBnClickedUmountAll)
ON_BN_CLICKED(IDC_OPEN, &CfilediskDlg::OnBnClickedOpen)
ON_BN_CLICKED(IDC_BUTTON1, &CfilediskDlg::OnBnClickedButton1)
END_MESSAGE_MAP()




BOOL CfilediskDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	SetIcon(m_hIcon, TRUE);			
	SetIcon(m_hIcon, FALSE);	
	m_Browse.SetIcon(m_hIcon);
	m_Browse.RedrawWindow();
	CfilediskDlg::FillDriveList();

	m_Mounted.InsertColumn(0, "Drive", LVCFMT_RIGHT, 40);
	m_Mounted.InsertColumn(1, "Image file path", LVCFMT_LEFT, 250);
	m_Mounted.InsertColumn(2, "Size", LVCFMT_LEFT, 150);
	FillMountedList();
	GetWindowRect(&formRect);
	int sy = GetSystemMetrics(SM_CYSCREEN);
	int sx = GetSystemMetrics(SM_CXSCREEN);
	int fx = formRect.Width();
	int fy = formRect.Height();
	MoveWindow((sx-fx)/2,(sy-fy)/2,fx,fy,true);
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CfilediskDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}



void CfilediskDlg::OnPaint()
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
HCURSOR CfilediskDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CfilediskDlg::OnBnClickedBrowse()
{
	CFileDialog m_ldFile(TRUE, NULL, NULL, OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, _T("All Files (*.*)|*.*||"));
	if (m_ldFile.DoModal() == IDOK)
	{
		m_Path = m_ldFile.GetPathName();
		UpdateData(FALSE);
	}
}


//void CfilediskDlg::OnCbnSelchangeDrive()
//{
//	 int nIndex = m_Drive.GetCurSel();
//    CString strCBText;
//
//    m_Drive.GetLBText(nIndex, strCBText);
//	MessageBox(strCBText);
//}

void CfilediskDlg::OnBnClickedMount()
{
	CString strDrive;
	int mount;
	CString nn;

	
	if ((m_Path.GetLength()>0) && (m_Drive.GetCount()>0) )
	{

	m_Drive.GetLBText(m_Drive.GetCurSel(), strDrive);

	mount = Svc.Mount(nDevice++,const_cast <char*>((LPCTSTR)m_Path),"",(char)strDrive.GetAt(0));
	CString mStatus = Svc.GetStatus((char)strDrive.GetAt(0));
	if((mStatus.GetLength()>0) && (mount==0))
	{

	CString rPath =  mStatus.SpanExcluding("|");
	mStatus.Replace(rPath,"");
	mStatus.Replace("|","");
	int size = atoi(mStatus.GetBuffer(0));
	CString rSize;
	rSize.Format("%i MB (%i  bytes)",size/(1024*1024),size);
	m_Mounted.InsertItem(0,strDrive);	
	m_Mounted.SetItemText(0, 1, rPath);
	m_Mounted.SetItemText(0, 2, rSize);
	m_Mounted.SetItemState(0, LVIS_SELECTED, LVIS_SELECTED | LVIS_FOCUSED);

	m_Drive.DeleteString(m_Drive.GetCurSel());
	m_Drive.SetCurSel(0);

	m_Path.Empty();
	UpdateData(FALSE);
	}
	else
	{
	//MessageBox(_T("Please enter file name"),_T("Error"),MB_ICONWARNING);
	}
	}
	else{
	MessageBox(_T("There was no image to mount!"),_T("Mount Image"),MB_ICONINFORMATION);
	}
	CfilediskDlg::FillDriveList();
}



void CfilediskDlg::OnBnClickedSvcInstall()
{
	MessageBox("Not implements Yet!","Filedisk GUI",MB_ICONINFORMATION);
}

void CfilediskDlg::OnBnClickedSvcStart()
{
	m_SvcStop.EnableWindow(1);
	m_SvcStart.EnableWindow(0);
	Svc.StartSvc();
}

void CfilediskDlg::OnBnClickedSvcStop()
{
	m_SvcStart.EnableWindow(1);
	m_SvcStop.EnableWindow(0);
	Svc.StopSvc();
}


void CfilediskDlg::OnLvnItemchangedListMount(NMHDR *pNMHDR, LRESULT *pResult)
{
	int i=0;
	LPNMLISTVIEW pNMLV = reinterpret_cast<LPNMLISTVIEW>(pNMHDR);
	//	m_Mounted.SetItemState(1,LVIS_SELECTED, LVIS_SELECTED | LVIS_FOCUSED);
	POSITION p = m_Mounted.GetFirstSelectedItemPosition();
	while (p)
	{
	int nSelected = m_Mounted.GetNextSelectedItem(p);
	i++;
	int j =m_Mounted.GetItemCount();
	CuSelDrive = m_Mounted.GetItemText(nSelected,0);
	}
	

	*pResult = 0;
}

void CfilediskDlg::OnBnClickedUmount()
{
	int umount;
	POSITION p = m_Mounted.GetFirstSelectedItemPosition();
	int nSelected = m_Mounted.GetNextSelectedItem(p);
	if(nSelected!=-1){
	umount = Svc.Umount((char)CuSelDrive.GetAt(0));
	if(umount==0)
	{
	m_Mounted.DeleteItem(nSelected);
	nDevice--;
	}
	else{}
	}
	else
	{
		if (m_Mounted.GetItemCount()==0)
		MessageBox("No Mounted images to unmount!","Umount disk Image",MB_ICONINFORMATION);
		else
		MessageBox("Please select drive letter of images to unmount!","Umount disk Image",MB_ICONINFORMATION);
	}
	CfilediskDlg::FillDriveList();
}

void CfilediskDlg::FillDriveList(){
	CString dd;
	int i,j;
	char dr;
    j=_getdrive();
	m_Drive.ResetContent();
	for(i=3;i<27;i++){
		dr = (char)(i+64);
		dd.Format(_T("%c:\\"),dr); 
		if(_chdrive(i) == -1 && GetDriveType(dd) ==1)
		{
			_chdrive(j);
			m_Drive.AddString(dd);
		
		}
		}
	m_Drive.SetCurSel(0);
}

void CfilediskDlg::FillMountedList(){
	CString dd,mounted,rPath,rSize;
	int i,j,size;
	char dr;
    j=_getdrive();

	for(i=3;i<27;i++){
		dr = (char)(i+64);
		dd.Format(_T("%c:\\"),dr); 
		if(_chdrive(i) == 0 && GetDriveType(dd) ==3)
		{
			_chdrive(j);
			mounted = Svc.GetStatus((char)dd.GetAt(0));
			if(mounted.GetLength()>0){
			rPath =  mounted.SpanExcluding("|");
			mounted.Replace(rPath,"");
			mounted.Replace("|","");
			size = atoi(mounted.GetBuffer(0));
			rSize.Format("%i MB (%i  bytes)",size/(1024*1024),size);
			m_Mounted.InsertItem(0,dd);	
			m_Mounted.SetItemText(0, 1, rPath);
			m_Mounted.SetItemText(0, 2, rSize);
			m_Mounted.SetItemState(0, LVIS_SELECTED, LVIS_SELECTED | LVIS_FOCUSED);
			nDevice++;
			}
		}
		}
}

void CfilediskDlg::OnBnClickedUmountAll()
{
	MessageBox("Not implements Yet!","Filedisk GUI",MB_ICONINFORMATION);
}

void CfilediskDlg::OnBnClickedOpen()
{
	int sy = GetSystemMetrics(SM_CYSCREEN);
	int sx = GetSystemMetrics(SM_CXSCREEN);
	int fx = formRect.Width();
	int fy = formRect.Height();
	MoveWindow((sx-fx)/2,(sy-fy)/2,fx,fy,true);
	}

void CfilediskDlg::OnBnClickedButton1()
{
	GetWindowRect(&formRect);
	long m_lWidth;
	long m_lHeight; 
	float fWidth = (float)formRect.Width();
	//CWnd* desk = ::GetDesktopWindow();
	int y = GetSystemMetrics(SM_CYSCREEN);
	int x = GetSystemMetrics(SM_CXSCREEN);
	// calculate difference between form height and edit box height
	float fHeight = (float)formRect.Height();
	CString msg;
	msg.Format("w=%f h=%f",fWidth,fHeight);
	MessageBox(msg);
	
	if(++advshow%2==1)
	{
	MoveWindow(0,0,488,340,true);
	}
	else
	{
	MoveWindow(0,0,488,465,true);

	}
}
