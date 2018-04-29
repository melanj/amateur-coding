// AdvDlg.cpp : implementation file
//

#include "stdafx.h"
#include "ImageMount.h"
#include "AdvDlg.h"
#include "Svctrl.h"
#include "Registry.h"

Svctrl Svc2;
CRegistry SvcReg (CREG_CREATE );
CComboBox *NumOfD;

// AdvDlg dialog

IMPLEMENT_DYNAMIC(AdvDlg, CDialog)

AdvDlg::AdvDlg(CWnd* pParent /*=NULL*/)
	: CDialog(AdvDlg::IDD, pParent)
	, m_NumOfDrv(0)
	, m_as(FALSE)
{

}

AdvDlg::~AdvDlg()
{
}

void AdvDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_CBIndex(pDX, IDC_NUM_DRV, m_NumOfDrv);
	DDV_MinMaxInt(pDX, m_NumOfDrv, 1, 9);
	DDX_Check(pDX, IDC_AS, m_as);
}


BEGIN_MESSAGE_MAP(AdvDlg, CDialog)
	ON_BN_CLICKED(IDC_START_STOP, &AdvDlg::OnBnClickedStartStop)
	ON_BN_CLICKED(IDC_INSTALL_UNSTALL, &AdvDlg::OnBnClickedInstallUnstall)
	ON_CBN_SELCHANGE(IDC_NUM_DRV, &AdvDlg::OnCbnSelchangeNumDrv)
	ON_BN_CLICKED(IDCANCEL, &AdvDlg::OnBnClickedCancel)
END_MESSAGE_MAP()


// AdvDlg message handlers

void AdvDlg::OnBnClickedStartStop()
{
switch(Svc2.SvcStatus())
	{
	case -2:
	case -1:
	case -0:
	case 7:
		MessageBox("Oops!, unknown Error!","System Error!",MB_ICONSTOP);
		break;
	case 1:
	case 6:	
		if(Svc2.StartSvc()) 
			SetDlgItemText(IDC_START_STOP,"Stop");
		break;
	case 3:
		if(Svc2.StopSvc()) 
		SetDlgItemText(IDC_START_STOP,"Stat");
		break;
	case 2:
	case 4:
	case 5:
		MessageBox("some task still pending.\nplease wait a while....","Please Wait",MB_ICONINFORMATION);
		break;
	default:
		break;
	}	
}

void AdvDlg::OnBnClickedInstallUnstall()
{
//	Svc2.InstallSvc();
	//::GetDlgItem(0,IDC_INSTALL_UNSTALL)
	//SetDlgItemText(IDC_INSTALL_UNSTALL,"");
	
	
	switch(Svc2.SvcStatus())
	{
	case -1:
	if(Svc2.InstallSvc())
	{
	SvcReg.Open( "SYSTEM\\CurrentControlSet\\Services\\dimage\\Parameters", HKEY_LOCAL_MACHINE );
	SvcReg["NumberOfDevices"]=(unsigned long)4;
	SvcReg.Close();
	SetDlgItemText(IDC_INSTALL_UNSTALL,"Uninstall");
	GetDlgItem(IDC_START_STOP)->EnableWindow(0);
    MessageBox("device driver installed sucessfully ","Driver Install",MB_ICONINFORMATION);
	}
	else
	{
	MessageBox("Oops!, unknown Error!","Error",MB_ICONSTOP);
	}
		break;
	default:
		MessageBox("Oops!, unknown Error!","Error",MB_ICONSTOP);
		break;
	}
}

BOOL AdvDlg::OnInitDialog()
{
	CDialog::OnInitDialog();
	SvcReg.Open( "SYSTEM\\CurrentControlSet\\Services\\dimage", HKEY_LOCAL_MACHINE );
	m_as=((int)SvcReg["Start"]==1)?true:false;
	SvcReg.Close();
	UpdateData(false);
	SvcReg.Open( "SYSTEM\\CurrentControlSet\\Services\\dimage\\Parameters", HKEY_LOCAL_MACHINE );
	NumOfD = (CComboBox *)GetDlgItem(IDC_NUM_DRV);
	NumOfD->SetCurSel((unsigned long)((int)SvcReg["NumberOfDevices"]>0)?((int)SvcReg["NumberOfDevices"]-1):3);
	SvcReg.Close();
	switch(Svc2.SvcStatus())
	{
	case -2:
		break;
	case -1:
		SetDlgItemText(IDC_INSTALL_UNSTALL,"Install");
		GetDlgItem(IDC_INSTALL_UNSTALL)->EnableWindow(1);
		break;
	case -0:
		break;
	case 1:
		SetDlgItemText(IDC_START_STOP,"Start");
		SetDlgItemText(IDC_INSTALL_UNSTALL,"Uninstall");
		GetDlgItem(IDC_START_STOP)->EnableWindow(1);
		break;
	case 2:
		break;
	case 3:
		SetDlgItemText(IDC_START_STOP,"Stop");
		SetDlgItemText(IDC_INSTALL_UNSTALL,"Uninstall");
		GetDlgItem(IDC_START_STOP)->EnableWindow(1);
		break;
	case 4:
		break;
	case 5:
		break;
	case 6:
		break;
	case 7:
		break;
	default:
		break;
	}

	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}

void AdvDlg::OnCbnSelchangeNumDrv()
{
	//
}

void AdvDlg::OnBnClickedCancel()
{
	UpdateData(1);
	SvcReg.Open( "SYSTEM\\CurrentControlSet\\Services\\dimage", HKEY_LOCAL_MACHINE );
	SvcReg["Start"]=(unsigned long)((m_as)?1:3);
	SvcReg.Close();
	SvcReg.Open( "SYSTEM\\CurrentControlSet\\Services\\dimage\\Parameters", HKEY_LOCAL_MACHINE );
	SvcReg["NumberOfDevices"]=(unsigned long)(NumOfD->GetCurSel()+1);
	SvcReg.Close();
	OnCancel();
}
