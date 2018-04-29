// DlgProxy.h: header file
//

#pragma once

class CjstestDlg;


// CjstestDlgAutoProxy command target

class CjstestDlgAutoProxy : public CCmdTarget
{
	DECLARE_DYNCREATE(CjstestDlgAutoProxy)

	CjstestDlgAutoProxy();           // protected constructor used by dynamic creation

// Attributes
public:
	CjstestDlg* m_pDialog;

// Operations
public:

// Overrides
	public:
	virtual void OnFinalRelease();

// Implementation
protected:
	virtual ~CjstestDlgAutoProxy();

	// Generated message map functions

	DECLARE_MESSAGE_MAP()
	DECLARE_OLECREATE(CjstestDlgAutoProxy)

	// Generated OLE dispatch map functions

	DECLARE_DISPATCH_MAP()
	DECLARE_INTERFACE_MAP()
};

