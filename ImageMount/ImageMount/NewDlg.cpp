// NewDlg.cpp : implementation file
//

#include "stdafx.h"
#include "ImageMount.h"
#include "NewDlg.h"


// NewDlg dialog

IMPLEMENT_DYNAMIC(NewDlg, CDialog)

NewDlg::NewDlg(CWnd* pParent /*=NULL*/)
	: CDialog(NewDlg::IDD, pParent)
	, m_FileSize(0)
	, CurSel(0)
	, FUnit(_T(""))
{

}

NewDlg::~NewDlg()
{
}

void NewDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_FILESIZE, m_FileSize);
	DDX_Control(pDX, IDC_UNIT, m_Unit);
}


BEGIN_MESSAGE_MAP(NewDlg, CDialog)
	ON_BN_CLICKED(IDOK, &NewDlg::OnBnClickedOk)
	ON_BN_CLICKED(IDCANCEL, &NewDlg::OnBnClickedCancel)
	ON_EN_CHANGE(IDC_FILESIZE, &NewDlg::OnEnChangeFilesize)
	ON_CBN_SELCHANGE(IDC_UNIT, &NewDlg::OnCbnSelchangeUnit)
END_MESSAGE_MAP()


// NewDlg message handlers

void NewDlg::OnBnClickedOk()
{
	UpdateData(TRUE);
	CurSel = m_Unit.GetCurSel();
	m_Unit.GetLBText(CurSel,FUnit);
	FUnit.Replace("B","");
	OnOK();
}

void NewDlg::OnBnClickedCancel()
{

	OnCancel();
}

BOOL NewDlg::OnInitDialog()
{
	CDialog::OnInitDialog();
	m_Unit.SetCurSel(0);
	

	return TRUE;
}

void NewDlg::OnEnChangeFilesize()
{
UpdateData(1);
	
}

CString NewDlg::GetNewFileSize(void)
{
	CString FileSize;
	FileSize.Format("%6.2f%s",m_FileSize,FUnit);
	return FileSize;
}

void NewDlg::OnCbnSelchangeUnit()
{
	CurSel = m_Unit.GetCurSel();
}
