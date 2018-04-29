#pragma once

/**
splash.cpp 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Thursday, December 04, 2008 (port to x64)
@version	2.2.2
@majorvesions
	n/a	
**/

class splash : public CDialog
{
	DECLARE_DYNAMIC(splash)

public:
	splash(CWnd* pParent = NULL);   
	virtual ~splash();

	enum { IDD = IDD_SPLASH };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);   

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
};
