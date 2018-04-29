// imgDlg.h : header file
//
#include "PictureCtrl.h"
#pragma once


// CimgDlg dialog
class CimgDlg : public CDialog
{
// Construction
public:
	CimgDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_IMG_DIALOG };

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
	CListCtrl m_ctlListCtrl;
public:
	afx_msg void OnLvnItemchangedList2(NMHDR *pNMHDR, LRESULT *pResult);
public:
	afx_msg void OnBnClickedOk();
public:
	CPictureCtrl m_pic;
};
