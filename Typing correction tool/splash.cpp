/**
splash.cpp 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Thursday, December 04, 2008 (port to x64)
@version	2.2.2	
@majorvesions
	n/a	
**/
#include "stdafx.h"
#include "ESToolkit.h"
#include "splash.h"

IMPLEMENT_DYNAMIC(splash, CDialog)
splash::splash(CWnd* pParent )
	: CDialog(splash::IDD, pParent)
{
//	SetWindowText("Loading.....");
}

splash::~splash()
{
}

void splash::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(splash, CDialog)
	ON_WM_TIMER()
ON_WM_CREATE()
END_MESSAGE_MAP()



void splash::OnTimer(UINT_PTR nIDEvent)
{
	KillTimer(ID_CLOCK_TIMER);
	CDialog::OnOK();
	CDialog::OnTimer(nIDEvent);
}



int splash::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CDialog::OnCreate(lpCreateStruct) == -1)
		return -1;
	SetTimer(ID_CLOCK_TIMER, 3000, NULL);

	return 0;
}

