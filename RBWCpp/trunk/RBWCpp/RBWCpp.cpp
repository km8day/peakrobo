// RBWCpp.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "RBWCpp.h"
#include "RBWCppDlg.h"
#include <tlhelp32.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define  RBW65EXE  _T("RobotWorks65.exe")

// CRBWCppApp

BEGIN_MESSAGE_MAP(CRBWCppApp, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()


// CRBWCppApp construction

CRBWCppApp::CRBWCppApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CRBWCppApp object

CRBWCppApp theApp;


// CRBWCppApp initialization

BOOL CRBWCppApp::InitInstance()
{
	// InitCommonControlsEx() is required on Windows XP if an application
	// manifest specifies use of ComCtl32.dll version 6 or later to enable
	// visual styles.  Otherwise, any window creation will fail.
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	// Set this to include all the common control classes you want to use
	// in your application.
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinApp::InitInstance();

	AfxEnableControlContainer();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	// of your final executable, you should remove from the following
	// the specific initialization routines you do not need
	// Change the registry key under which our settings are stored
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization
	SetRegistryKey(_T("RobotWorks API call application 1"));
	
	//check if RobotWorks65.exe is running
	HANDLE handle=CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS,0);

	PROCESSENTRY32* info=new PROCESSENTRY32;
	info->dwSize=sizeof(PROCESSENTRY32);
	bool bRBW65Runing = false;
	if(Process32First(handle,info))
	{
		if(GetLastError()==ERROR_NO_MORE_FILES )
		{
			bRBW65Runing = false;
		}
		else
		{
			CString strProcessExe = info->szExeFile;
			//strProcessExe.Format("%s",info->szExeFile);
			if(strProcessExe.CompareNoCase(RBW65EXE) == 0 )
				bRBW65Runing = true;

			while(Process32Next(handle,info)!=FALSE && !bRBW65Runing)
			{
				strProcessExe = info->szExeFile;
				//strProcessExe.Format("%s",info->szExeFile);
				if(strProcessExe.CompareNoCase(RBW65EXE) == 0)
				{
					bRBW65Runing = true;
					break;
				}
			}
		}
	}
	CloseHandle(handle);
	delete info;
	info = NULL;
	if(!bRBW65Runing)
	{
		AfxMessageBox(_T("RobotWorks65.exe is not running!"));
		return FALSE;
	}

	CoInitialize(NULL);
	{
		CRBWCppDlg dlg;
		m_pMainWnd = &dlg;
		INT_PTR nResponse = dlg.DoModal();
		if (nResponse == IDOK)
		{
			// TODO: Place code here to handle when the dialog is
			//  dismissed with OK
		}
		else if (nResponse == IDCANCEL)
		{
			// TODO: Place code here to handle when the dialog is
			//  dismissed with Cancel
		}
	}
	CoUninitialize();
	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
