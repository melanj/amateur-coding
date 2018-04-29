// autorun.h : header file
//

#pragma once


// Cautorun dialog
class Cautorun : public CDialog
{
// Construction
public:
	Cautorun(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_AUTORUN2_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedMount();
	afx_msg void OnBnClickedUmount();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedMount2();
};
