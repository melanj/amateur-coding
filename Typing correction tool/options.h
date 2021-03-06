#pragma once
/**
options.h 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Monday, July 28, 2008
@version	2.2.1	
@majorvesions
	n/a	
**/

#define CSIDL_DESKTOP                   0x0000
#define CSIDL_INTERNET                  0x0001
#define CSIDL_PROGRAMS                  0x0002
#define CSIDL_CONTROLS                  0x0003
#define CSIDL_PRINTERS                  0x0004
#define CSIDL_PERSONAL                  0x0005
#define CSIDL_FAVORITES                 0x0006
#define CSIDL_STARTUP                   0x0007
#define CSIDL_RECENT                    0x0008
#define CSIDL_SENDTO                    0x0009
#define CSIDL_BITBUCKET                 0x000a
#define CSIDL_STARTMENU                 0x000b
#define CSIDL_DESKTOPDIRECTORY          0x0010
#define CSIDL_DRIVES                    0x0011
#define CSIDL_NETWORK                   0x0012
#define CSIDL_NETHOOD                   0x0013
#define CSIDL_FONTS                     0x0014
#define CSIDL_TEMPLATES                 0x0015
#define CSIDL_COMMON_STARTMENU          0x0016
#define CSIDL_COMMON_PROGRAMS           0X0017
#define CSIDL_COMMON_STARTUP            0x0018
#define CSIDL_COMMON_DESKTOPDIRECTORY   0x0019
#define CSIDL_APPDATA                   0x001a
#define CSIDL_PRINTHOOD                 0x001b
#define CSIDL_ALTSTARTUP                0x001d         // DBCS
#define CSIDL_COMMON_ALTSTARTUP         0x001e         // DBCS
#define CSIDL_COMMON_FAVORITES          0x001f
#define CSIDL_INTERNET_CACHE            0x0020
#define CSIDL_COOKIES                   0x0021
#define CSIDL_HISTORY                   0x0022

class options : public CDialog
{
	DECLARE_DYNAMIC(options)

public:
	options(CWnd* pParent = NULL);   
	virtual ~options();

	enum { IDD = IDD_OPTIONS };

	void CreateLink(int nFolder,CString m_strItem,CString m_strFile );
	CString GetSpecialFolder(int nFolder );

protected:
	virtual void DoDataExchange(CDataExchange* pDX);   

	DECLARE_MESSAGE_MAP()
public:
	BOOL m_sp;
	BOOL m_ld;
	afx_msg void OnBnClickedOk();
};
