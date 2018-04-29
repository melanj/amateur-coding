/**
options.cpp 
 
@author		Melan Nimesh
@created	Friday, November 24, 2006 (n/a ) 
@modified	Monday, July 28, 2008
@version	2.2.1	
@majorvesions
	n/a	
**/

#include "stdafx.h"
#include "ESToolkit.h"
#include "options.h"




IMPLEMENT_DYNAMIC(options, CDialog)
options::options(CWnd* pParent)
	: CDialog(options::IDD, pParent)
	, m_sp(FALSE)
	, m_ld(FALSE)
{
	CoInitialize(NULL);
	AfxGetApp()->WriteProfileInt("Config","options opened",1);
	m_sp = AfxGetApp()->GetProfileInt("Config","Show Splash",1);
	m_ld = AfxGetApp()->GetProfileInt("Config","Automatically run",0);
}

options::~options()
{
}

void options::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Check(pDX, IDC_CH_SP, m_sp);
	DDX_Check(pDX, IDC_CH_LD, m_ld);
}


BEGIN_MESSAGE_MAP(options, CDialog)
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
END_MESSAGE_MAP()



void options::OnBnClickedOk()
{
	CString zExe,stpath,lnk;
	CFile stsc;
	UpdateData(1);
	AfxGetApp()->WriteProfileInt("Config","Show Splash",m_sp);
    AfxGetApp()->WriteProfileInt("Config","Automatically run",m_ld);
    
	stpath=GetSpecialFolder(CSIDL_STARTUP);
    zExe = AfxGetApp()->m_pszHelpFilePath;
	zExe.Replace(".HLP",".exe");
	lnk.Format("%s\\Easy Sinhala Toolkit.lnk",stpath);
    if(m_ld)
	{   
		if(!stsc.Open(lnk,CFile::modeRead))
		{
			CreateLink(CSIDL_STARTUP,"Easy Sinhala Toolkit",zExe);

		}
		else
		{
			stsc.Close();
		}
	}
	else
	{
		if(!stsc.Open(lnk,CFile::modeRead))
		{

		}
		else
		{
        stsc.Close();
		remove(lnk);
		}
	}

    AfxGetApp()->WriteProfileInt("Config","options opened",0);
	OnOK();
}

void options::CreateLink(int nFolder,CString m_strItem,CString m_strFile )
{

	   LPITEMIDLIST pidl;	   
	   HRESULT hr = SHGetSpecialFolderLocation(NULL, nFolder, &pidl);	   
	   char szPath[_MAX_PATH];
	   BOOL f = SHGetPathFromIDList(pidl, szPath);   
	   LPMALLOC pMalloc;
	   hr = SHGetMalloc(&pMalloc);
	   pMalloc->Free(pidl);
	   
	   pMalloc->Release();

		CString	szLinkName = m_strItem ;
		szLinkName+= _T(".lnk") ;
        
		CString m_szCurrentDirectory = szPath ;

		CString szTemp = szLinkName;
        szLinkName.Format( "%s\\%s", m_szCurrentDirectory, szTemp );
			
		
        HRESULT hres = NULL;  
        IShellLink* psl = NULL; 
 
        hres = CoCreateInstance(CLSID_ShellLink, NULL, 
            CLSCTX_INPROC_SERVER, IID_IShellLink, 
            reinterpret_cast<void**>(&psl)); 
        if (SUCCEEDED(hres)) 
        { 
            IPersistFile* ppf = NULL; 
 
            psl->SetPath(m_strFile); 
			
            hres = psl->QueryInterface(IID_IPersistFile, 
                reinterpret_cast<void**>(&ppf)); 
 
            if (SUCCEEDED(hres)) 
            { 
                WCHAR wsz[MAX_PATH]; 
 
                MultiByteToWideChar(CP_ACP, 0, szLinkName, -1, 
                    wsz, MAX_PATH); 
  
                hres = ppf->Save(wsz, TRUE); 
                ppf->Release(); 
            } 
            psl->Release(); 
        } 	


}


CString options::GetSpecialFolder(int nFolder )
{

LPITEMIDLIST pidl;	   
HRESULT hr = SHGetSpecialFolderLocation(NULL, nFolder, &pidl);	   
char szPath[_MAX_PATH];
BOOL f = SHGetPathFromIDList(pidl, szPath);   
LPMALLOC pMalloc;
hr = SHGetMalloc(&pMalloc);
pMalloc->Free(pidl);
pMalloc->Release();
 
return szPath ;

}
