// ImageMountDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "afxcmn.h"


// CImageMountDlg dialog
class CImageMountDlg : public CDialog
{
// Construction
public:
	CImageMountDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_IMAGEMOUNT_DIALOG };

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
	afx_msg void OnBnClickedAdv();
	CString m_Path;
	CComboBox m_Drive;
	CButton m_Browse;
//	CButton m_Mount;
	afx_msg void OnBnClickedBrowse();
	afx_msg void OnBnClickedMount();
	afx_msg void OnBnClickedNewImage();
	CListCtrl m_Mounted;
	afx_msg void OnBnClickedUmountAll();
	afx_msg void OnBnClickedUmount();
	afx_msg void OnBnClickedOpen();
	void FillDriveList(void);
	void FillMountedList(void);
	BOOL isNewFile;
	afx_msg void OnLvnItemchangedListMount(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedCd();
	afx_msg void OnBnClickedReadonly();
	BOOL isCdImage;
	BOOL isReadOnly;
public:
	CString NewFileSize;
public:
	CString m_ReqFileSize;
public:
	void MountSelImage(void);
};
