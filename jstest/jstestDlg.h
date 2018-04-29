// jstestDlg.h : header file
//

#pragma once

class CjstestDlgAutoProxy;


// CjstestDlg dialog
class CjstestDlg : public CDHtmlDialog
{
	DECLARE_DYNAMIC(CjstestDlg);
	friend class CjstestDlgAutoProxy;


// Construction
public:
	CjstestDlg(CWnd* pParent = NULL);	// standard constructor
	virtual ~CjstestDlg();
	afx_msg void fun1(LPCTSTR lpszFile);
// Dialog Data
	enum { IDD = IDD_JSTEST_DIALOG, IDH = IDR_HTML_JSTEST_DIALOG };


	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

	HRESULT OnButtonOK(IHTMLElement *pElement);
	HRESULT OnButtonCancel(IHTMLElement *pElement);
	
// Implementation
protected:
	CjstestDlgAutoProxy* m_pAutoProxy;
	HICON m_hIcon;

	BOOL CanExit();

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClose();
	virtual void OnOK();
	virtual void OnCancel();
	
	DECLARE_MESSAGE_MAP()
	DECLARE_DHTML_EVENT_MAP()
	DECLARE_DISPATCH_MAP()
};
