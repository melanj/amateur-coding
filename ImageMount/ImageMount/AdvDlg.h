#pragma once


// AdvDlg dialog

class AdvDlg : public CDialog
{
	DECLARE_DYNAMIC(AdvDlg)

public:
	AdvDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~AdvDlg();

// Dialog Data
	enum { IDD = IDD_ADV };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedStartStop();
public:
	afx_msg void OnBnClickedInstallUnstall();
public:
	virtual BOOL OnInitDialog();
public:
	afx_msg void OnCbnSelchangeNumDrv();
public:
	int m_NumOfDrv;
public:
	afx_msg void OnBnClickedCancel();
public:
	BOOL m_as;
};
