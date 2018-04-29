
#pragma once
/**
ESToolkit.h 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Monday, July 28, 2008
@version	2.2.1	
@majorvesions
	n/a	
**/
#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		



class CESToolkitApp : public CWinApp
{
public:
	CESToolkitApp();

	public:
	virtual BOOL InitInstance();


	DECLARE_MESSAGE_MAP()
};

extern CESToolkitApp theApp;