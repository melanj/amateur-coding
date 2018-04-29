// filediskDlg.h : header file
//

#pragma once


// CfilediskDlg dialog
class CfilediskDlg : public CDialog
{
// Construction
public:
	CfilediskDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_FILEDISK_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedBrowse();
	CString m_Path;
	CComboBox m_Drive;
	CButton m_Browse;
	CButton m_Mount;
	afx_msg void OnBnClickedMount();
	CListCtrl m_Mounted;
	CButton m_SvcStart;
	CButton m_SvcStop;
	CButton m_SvcInstall;
public:
	afx_msg void OnBnClickedSvcInstall();
public:
	afx_msg void OnBnClickedSvcStart();
public:
	afx_msg void OnBnClickedSvcStop();
public:
//	afx_msg void OnHdnItemchangedListMount(NMHDR *pNMHDR, LRESULT *pResult);
public:
	afx_msg void OnLvnItemchangedListMount(NMHDR *pNMHDR, LRESULT *pResult);
public:
	afx_msg void OnBnClickedUmount();
	void FillDriveList();
	void FillMountedList();
public:
	afx_msg void OnBnClickedUmountAll();
public:
	afx_msg void OnBnClickedOpen();
public:
	afx_msg void OnBnClickedButton1();
};
