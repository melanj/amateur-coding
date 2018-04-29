#pragma once
/**
about.cpp 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Monday, July 28, 2008
@version	2.2.1	
@majorvesions
	n/a	
**/
class about : public CDialog
{
	DECLARE_DYNAMIC(about)

public:
	about(CWnd* pParent = NULL);  
	virtual ~about();

	enum { IDD = IDD_ABOUT };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
public:
	afx_msg void OnStnClickedWebSite();
};
