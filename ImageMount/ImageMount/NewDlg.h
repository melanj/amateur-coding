#pragma once
#include "afxwin.h"


// NewDlg dialog

class NewDlg : public CDialog
{
	DECLARE_DYNAMIC(NewDlg)

public:
	NewDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~NewDlg();

// Dialog Data
	enum { IDD = IDD_NEW_IMAGE };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedCancel();
public:
	double m_FileSize;
public:
	CComboBox m_Unit;
public:
	virtual BOOL OnInitDialog();
public:
	afx_msg void OnEnChangeFilesize();
public:
	CString GetNewFileSize(void);
public:
	afx_msg void OnCbnSelchangeUnit();
public:
	int CurSel;
public:
	CString FUnit;
};
