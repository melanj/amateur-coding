
#pragma once

/**
dlg.h 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Thursday, December 04, 2008 (port to x64)
@version	2.2.2	
@majorvesions
	n/a	
**/

class CESToolkitDlg : public CDialog
{

public:
	CESToolkitDlg(CWnd* pParent = NULL);	

	enum { IDD = IDD_EASYSINHALATOOLKIT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	


protected:
	HICON m_hIcon;

	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	LRESULT OnTrayNotification(WPARAM wParam, LPARAM lParam);
	DECLARE_MESSAGE_MAP()
	
public:
	afx_msg void OnPopupExit();
	afx_msg void OnPopupAbout();
	afx_msg void OnPopupOptions();
	afx_msg void OnPopupEnable();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
};
