/**
about.cpp 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006
@modified	Monday, July 28, 2008
@version	2.2.1	
@majorvesions
	n/a	
**/

#include "stdafx.h"
#include "ESToolkit.h"
#include "about.h"


IMPLEMENT_DYNAMIC(about, CDialog)
about::about(CWnd* pParent )
	: CDialog(about::IDD, pParent)
{
	AfxGetApp()->WriteProfileInt("Config","about opened",1);
}

about::~about()
{
}

void about::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(about, CDialog)
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
	ON_STN_CLICKED(IDC_WEB_SITE, &about::OnStnClickedWebSite)
END_MESSAGE_MAP()



void about::OnBnClickedOk()
{
	AfxGetApp()->WriteProfileInt("Config","about opened",0);
	OnOK();
}

void about::OnStnClickedWebSite()
{
	// TODO: Add your control notification handler code here
}
