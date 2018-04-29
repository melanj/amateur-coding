// ImageMountDlg.cpp : implementation file
// wed, May 20, 2009

#include "stdafx.h"
#include "ImageMount.h"
#include "ImageMountDlg.h"
#include <direct.h>
#include "AdvDlg.h"
#include "NewDlg.h"
#include "Svctrl.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif

Svctrl Svc;
CString CuSelDrive;
int nDevice=0;

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
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


// CImageMountDlg dialog




CImageMountDlg::CImageMountDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CImageMountDlg::IDD, pParent)
	, m_Path(_T(""))
	, isNewFile(FALSE)
	, isCdImage(FALSE)
	, isReadOnly(FALSE)
	, NewFileSize(_T(""))
	, m_ReqFileSize(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CImageMountDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
//	DDX_Text(pDX, IDC_PATH, m_Path);
	DDX_Control(pDX, IDC_DRIVE, m_Drive);
	DDX_Control(pDX, IDC_BROWSE, m_Browse);
//	DDX_Control(pDX, IDC_MOUNT, m_Mount);
	DDX_Control(pDX, IDC_LIST_MOUNT, m_Mounted);
	DDX_Check(pDX, IDC_NEW_IMAGE, isNewFile);
	DDX_Check(pDX, IDC_CD, isCdImage);
	DDX_Check(pDX, IDC_READONLY, isReadOnly);
}

BEGIN_MESSAGE_MAP(CImageMountDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_ADV, &CImageMountDlg::OnBnClickedAdv)
	ON_BN_CLICKED(IDC_BROWSE, &CImageMountDlg::OnBnClickedBrowse)
	//ON_BN_CLICKED(IDC_MOUNT, &CImageMountDlg::OnBnClickedMount)
	ON_BN_CLICKED(IDC_NEW_IMAGE, &CImageMountDlg::OnBnClickedNewImage)
	ON_BN_CLICKED(IDC_UMOUNT_ALL, &CImageMountDlg::OnBnClickedUmountAll)
	ON_BN_CLICKED(IDC_UMOUNT, &CImageMountDlg::OnBnClickedUmount)
	ON_BN_CLICKED(IDC_OPEN, &CImageMountDlg::OnBnClickedOpen)
	ON_NOTIFY(LVN_ITEMCHANGED, IDC_LIST_MOUNT, &CImageMountDlg::OnLvnItemchangedListMount)
	ON_BN_CLICKED(IDC_CD, &CImageMountDlg::OnBnClickedCd)
	ON_BN_CLICKED(IDC_READONLY, &CImageMountDlg::OnBnClickedReadonly)
END_MESSAGE_MAP()


// CImageMountDlg message handlers

BOOL CImageMountDlg::OnInitDialog()
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

	FillDriveList();
	m_Mounted.InsertColumn(0, "Drive", LVCFMT_RIGHT, 40);
	m_Mounted.InsertColumn(1, "Image file path", LVCFMT_LEFT, 250);
	m_Mounted.InsertColumn(2, "Size", LVCFMT_LEFT, 150);
	FillMountedList();
	return TRUE;  
}

void CImageMountDlg::OnSysCommand(UINT nID, LPARAM lParam)
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


void CImageMountDlg::OnPaint()
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


HCURSOR CImageMountDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CImageMountDlg::OnBnClickedAdv()
{
	if (m_Mounted.GetItemCount()==0){
	AdvDlg AdvdlgInt;
	AdvdlgInt.DoModal();
	}
	else
		MessageBox("Some Disk images are allready mounted","",MB_ICONINFORMATION);
}

void CImageMountDlg::OnBnClickedBrowse()
{
	UpdateData(1);
	if(isNewFile){
	CFileDialog m_ldFile(FALSE, NULL, NULL, OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, _T("All Files (*.*)|*.*||"));
	if (m_ldFile.DoModal() == IDOK)
	{
		m_Path = m_ldFile.GetPathName();
		UpdateData(FALSE);
		NewDlg NewdlgInt;
		NewdlgInt.DoModal();
		m_ReqFileSize = NewdlgInt.GetNewFileSize();
		MountSelImage();
	}
	}
	else{
	CFileDialog m_ldFile(TRUE, NULL, NULL, OFN_HIDEREADONLY|OFN_FILEMUSTEXIST, _T("All Files (*.*)|*.*||"));
	if (m_ldFile.DoModal() == IDOK)
	{
		m_Path = m_ldFile.GetPathName();
		MountSelImage();
		UpdateData(FALSE);
	}
	}
}



void CImageMountDlg::OnBnClickedNewImage()
{
	UpdateData(TRUE);
	isCdImage=FALSE;
	isReadOnly=FALSE;
	GetDlgItem(IDC_READONLY)->EnableWindow(!isNewFile);
	m_Path="";
	UpdateData(FALSE);
}

void CImageMountDlg::OnBnClickedUmountAll()
{
	// TODO: Add your control notification handler code here
}

void CImageMountDlg::OnBnClickedUmount()
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
	FillDriveList();
}

void CImageMountDlg::OnBnClickedOpen()
{
//#if defined _M_IX86
//MessageBox("x86");
//#elif defined _M_X64
//MessageBox("x64");
//#endif
}

void CImageMountDlg::FillDriveList(void)
{
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

void CImageMountDlg::FillMountedList(void)
{
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

void CImageMountDlg::OnLvnItemchangedListMount(NMHDR *pNMHDR, LRESULT *pResult)
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

void CImageMountDlg::OnBnClickedCd()
{
	UpdateData(TRUE);
	isNewFile=FALSE;
	isReadOnly=isCdImage;
	GetDlgItem(IDC_READONLY)->EnableWindow(!isCdImage);
	UpdateData(FALSE);
}

void CImageMountDlg::OnBnClickedReadonly()
{
	// TODO: Add your control notification handler code here
}

void CImageMountDlg::MountSelImage(void)
{
	CString strDrive;
	int mount;
	CString nn;
	UpdateData(TRUE);
	if(Svc.SvcStatus() ==3)
	{
	if ((m_Path.GetLength()>0) && (m_Drive.GetCount()>0) )
	{

	m_Drive.GetLBText(m_Drive.GetCurSel(), strDrive);
	if(isNewFile)
	{
	mount = Svc.MountNew(nDevice++,const_cast <char*>((LPCTSTR)m_Path),const_cast <char*>((LPCTSTR)m_ReqFileSize),(char)strDrive.GetAt(0));
	}
	else if(isCdImage)
	{
	mount = Svc.MountCD(nDevice++,const_cast <char*>((LPCTSTR)m_Path),(char)strDrive.GetAt(0));
	}
	else{
	mount = Svc.Mount(nDevice++,const_cast <char*>((LPCTSTR)m_Path),isReadOnly,(char)strDrive.GetAt(0));
	}
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
	isNewFile=FALSE;
	isCdImage=FALSE;
	isReadOnly=FALSE;
	GetDlgItem(IDC_READONLY)->EnableWindow(1);
	GetDlgItem(IDC_NEW_IMAGE)->EnableWindow(1);
	GetDlgItem(IDC_CD)->EnableWindow(1);
	UpdateData(FALSE);
	}
	else
	{
	nDevice--;
	//MessageBox(_T("Please enter file name"),_T("Error"),MB_ICONWARNING);
	}
	}
	else{
	MessageBox(_T("There was no image to mount!"),_T("Mount Image"),MB_ICONINFORMATION);
	}
	}
	else{
	MessageBox(_T("Disk image mouting service is current not runing!"),_T("Mount Image"),MB_ICONINFORMATION);
	}
	FillDriveList();
}
