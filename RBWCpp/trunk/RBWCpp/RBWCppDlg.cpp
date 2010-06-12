// RBWCppDlg.cpp : implementation file
//

#include "stdafx.h"
#include "RBWCpp.h"
#include "RBWCppDlg.h"
#include <tlhelp32.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define  STR_COMMA _T(",")
#define  STR_SPACE _T(" ")
#define  TOTALELEMENTS _T("TOTALELEMENTS=")

#define MOTION_TYPE _T("MOTION")
#define SPEED _T("SPEED")
#define BLEND _T("BLEND")
#define BYPASS _T("BYPASS")
#define GOSUB _T("GOSUB")
#define LASER _T("LASER")
#define DELAY _T("DELAY")
#define SLDAX_DIS _T("SLDAX DISTANCE")
#define PROCESS_INDEX _T("PROCESS INDEX")
#define A1 _T("A1")
#define A2 _T("A2")

#define  RBW65EXE  _T("RobotWorks65.exe")

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()



// CRBWCppDlg dialog




CRBWCppDlg::CRBWCppDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CRBWCppDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_bDispCreated = false;
}

void CRBWCppDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//DDX_Control(pDX, IDC_GenerateText, m_button);
	//DDX_Control(pDX, IDC_PROGRESS, m_ProgressCtrl);
}

BEGIN_MESSAGE_MAP(CRBWCppDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_GenerateText, &CRBWCppDlg::OnBnClickedGeneratetext)
	ON_BN_CLICKED(IDC_BUTTON_ABOUT, &CRBWCppDlg::OnBnClickedButtonAbout)
	ON_BN_CLICKED(IDC_BUTTON_JOINT, &CRBWCppDlg::OnBnClickedButtonJoint)
	ON_BN_CLICKED(IDC_BUTTON_TCP, &CRBWCppDlg::OnBnClickedButtonTcp)
END_MESSAGE_MAP()


// CRBWCppDlg message handlers

BOOL CRBWCppDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	if(!m_bDispCreated)
	{
		BOOL b = m_rbwAPI.CreateDispatch(_T("RobotWorks65.API"));
		if(!b) 
		{
			AfxMessageBox(_T("Can't create RobotWorks65.API object!"));
			return FALSE;
		}
		m_bDispCreated = true;
	}

	// TODO: Add extra initialization here
	//CRBWAPI rbwAPI;
	//BOOL b = rbwAPI.CreateDispatch(_T("RobotWorks500.API"));
	//if(b)
	//{


		//OrientationData *pData;// = new OrientationData;
		//CLSID clsid;//= _T("{15c6f1e1-c97f-4c9a-8be9-7e9f3aea588b}");
		//HRESULT hr = CLSIDFromProgID(L"RobotWorks65.API", &clsid);
		//IDispatch *pDis;
		//hr = CoCreateInstance(clsid, NULL, CLSCTX_LOCAL_SERVER, IID_IDispatch, (void**)&pDis);
		//if(hr == S_OK)
		//{
		//	//VARIANT vnt;
		//	IRecordInfo *pRI;
		//	OrientationData* data = (OrientationData*)CoTaskMemAlloc(sizeof(OrientationData));
		//	data->q4 = 0.0;
		//	data->X = 0.0;data->Y = 0.0; data->z = 0.0;
		//	data->Rx = 0.0; data->Ry = 0.0; data->Rz = 0.0;
		//	hr = GetRecordInfoFromGuids(__uuidof(__RobotWorks65), 1, 0, 0x409, __uuidof(OrientationData), &pRI);
		//	VARIANTARG v[2];
		//	VariantInit(&v[0]);
		//	VariantInit(&v[1]);
		//	//////////////////////////////////////////////////////////////////////////
		//	//very import step
		//	v[0].vt = VT_RECORD|VT_BYREF;
		//	//////////////////////////////////////////////////////////////////////////
		//	v[0].pvRecord = data;
		//	v[0].pRecInfo = pRI;
		//	v[1].vt = VT_I4;
		//	v[1].lVal = 3;
		//	DISPPARAMS dispParam = {v, NULL, 2, 0};
		//	VARIANT varResult;
		//	VariantInit(&varResult);
		//	EXCEPINFO excep;
		//	UINT uArgErr;
		//	hr = pDis->Invoke(0x60030003, IID_NULL, LOCALE_SYSTEM_DEFAULT, 
		//						DISPATCH_METHOD, &dispParam, &varResult, &excep, &uArgErr );
		//	if(hr == S_OK)
		//	{
		//		VARIANTARG *pvarg = dispParam.rgvarg;
		//		VARIANT var = pvarg[0];
		//		OrientationData *pD = (OrientationData*)var.pvRecord;
		//		//OrientationData *pDa = *pD;
		//		double dX = pD->X;
		//		//VARIANT vX; VariantInit(&vX); vX.vt = VT_R8;
		//		//hr = pRI->GetField(pdata, _T("X"), &vX);
		//		int a = 1;
		//	}
		//}




	//}

	//CLSID clsid;//= _T("{15c6f1e1-c97f-4c9a-8be9-7e9f3aea588b}");
	//HRESULT hr = CLSIDFromProgID(L"OutCom.Simple.1", &clsid);
	//ISimple *pDis;
	//hr = CoCreateInstance(clsid, NULL, CLSCTX_LOCAL_SERVER, IID_IDispatch, (void**)&pDis);
	//if(hr == S_OK)
	//{
	//	MyStruct *pst = (MyStruct *)CoTaskMemAlloc(sizeof(MyStruct));
	//	IRecordInfo *pRI;
	//	hr = GetRecordInfoFromGuids(__uuidof(__OutComLib), 1, 0, 0x409, __uuidof(MyStruct), &pRI);
	//	VARIANTARG v[2];
	//	VariantInit(&v[0]);
	//	VariantInit(&v[1]);
	//	v[0].vt = VT_RECORD|VT_BYREF;
	//	v[0].pvRecord = pst;
	//	v[0].pRecInfo = pRI;
	//	v[1].vt = VT_I4;
	//	v[1].lVal = 1;
	//	DISPPARAMS dispParam = {v, NULL, 2, 0};
	//	VARIANT varResult;
	//	VariantInit(&varResult);
	//	EXCEPINFO excep;
	//	UINT uArgErr;
	//	hr = pDis->Invoke(0x3, IID_NULL, LOCALE_SYSTEM_DEFAULT, DISPATCH_METHOD, &dispParam, &varResult, &excep, &uArgErr );
	//	if(hr == S_OK)
	//	{
	//		int a = 1;
	//	}
	//}

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CRBWCppDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CRBWCppDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CRBWCppDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CRBWCppDlg::OnBnClickedGeneratetext()
{
	if(!m_bDispCreated)
	{
		BOOL b = m_rbwAPI.CreateDispatch(_T("RobotWorks65.API"));
		if(!b) 
		{
			AfxMessageBox(_T("Can't create RobotWorks65.API object!"));
			return;
		}
		m_bDispCreated = true;
	}
	m_button.ShowWindow(SW_HIDE);
	m_ProgressCtrl.ShowWindow(SW_SHOW);
	m_ProgressCtrl.SetPos(0);

	CFileDialog filedlg(FALSE, _T("txt"), _T("1.txt"), OFN_OVERWRITEPROMPT, 
							_T("Text Files(*.txt)\0*.txt\0All File(*.*)\0*.*"), NULL);
	if(filedlg.DoModal() != IDOK)
		return;
	CString strFullFileName = filedlg.GetPathName();
	
	CTextFileWrite filewrite(strFullFileName, CTextFileWrite::UTF_8);
	// TODO: Add your control notification handler code here
	
	long lPntCnt = m_rbwAPI.Get_PointCount();
	filewrite << _T("FRAME VALUE= ");

	CString strfx, strfy, strfz, strfc, strfb, strfa;
	GetFrameData(strfx, strfy, strfz, strfc, strfb, strfa);
	filewrite << strfx;
	filewrite << STR_COMMA;
	filewrite << strfy;
	filewrite << STR_COMMA;
	filewrite << strfz;
	filewrite << STR_COMMA;
	filewrite << strfc;
	filewrite << STR_COMMA;
	filewrite << strfb;
	filewrite << STR_COMMA;
	filewrite << strfa;
	filewrite.WriteEndl();
	filewrite.WriteEndl();

	CString strtx, strty, strtz, strtc, strtb, strta;
	GetToolData(strtx, strty, strtz, strtc, strtb, strta);
	for (long l = 1; l <= lPntCnt; l++)
	{
		//tool data
		filewrite << strtx;
		filewrite << STR_COMMA;
		filewrite << strty;
		filewrite << STR_COMMA;
		filewrite << strtz;
		filewrite << STR_COMMA;
		filewrite << strtc;
		filewrite <<STR_COMMA;
		filewrite << strtb;
		filewrite << STR_COMMA;
		filewrite << strta;
		filewrite << STR_COMMA;
		filewrite << STR_SPACE;

		//cartesina data
		CString strcx, strcy, strcz, strcc, strcb, strca;
		GetCartesinaData(l, strcx, strcy, strcz, strcc, strcb, strca);
		filewrite << strcx;
		filewrite << STR_COMMA;
		filewrite << strcy;
		filewrite << STR_COMMA;
		filewrite << strcz;
		filewrite << STR_COMMA;
		filewrite << strcc;
		filewrite << STR_COMMA;
		filewrite << strcb;
		filewrite << STR_COMMA;
		filewrite << strca;
		filewrite << STR_COMMA;
		filewrite << STR_SPACE;

		//events data
		CString stre1, stre2, stre3, stre4, stre5, stre6, stre7, stre8, stre9;
		GetEventsData(l, stre1, stre2, stre3, stre4, stre5, stre6, stre7, stre8, stre9);
		filewrite << stre1;
		filewrite << STR_COMMA;
		filewrite << stre2;
		filewrite << STR_COMMA;
		filewrite << stre3;
		filewrite << STR_COMMA;
		filewrite << stre4;
		filewrite << STR_COMMA;
		filewrite << stre5;
		filewrite << STR_COMMA;
		filewrite << stre6;
		filewrite << STR_COMMA;
		filewrite << stre7;
		filewrite << STR_COMMA;
		filewrite << stre8;
		filewrite << STR_COMMA;
		filewrite << stre9;
		filewrite.WriteEndl();

		m_ProgressCtrl.SetPos(l*100/lPntCnt);
	}
	m_button.ShowWindow(SW_SHOW);
	m_ProgressCtrl.ShowWindow(SW_HIDE);
}

CString CRBWCppDlg::GetTableCellString(long lTable, long lRow, long lCol)
{
	USES_CONVERSION;
	CComBSTR bstrVaule;
	short iRet = m_rbwAPI.Get_TableCell(&lTable, &lRow, &lCol, &bstrVaule);
	CString strRet;
	//didn't success
	if(iRet != 0)
		strRet = _T("");
	else
		strRet = bstrVaule;
	return strRet;
}

void CRBWCppDlg::GetToolData(CString &chtx, CString &chty, CString &chtz, 
													CString &chtc, CString &chtb, CString &chta)
{
	chtx = GetTableCellString(4, 1, 1);
	chty = GetTableCellString(4, 1, 2);
	chtz = GetTableCellString(4, 1, 3);
	chtc = GetTableCellString(4, 1, 4);
	chtb = GetTableCellString(4, 1, 5);
	chta = GetTableCellString(4, 1, 6);
}

void CRBWCppDlg::GetFrameData(CString &chx, CString &chy, CString &chz, 
													CString &chc, CString &chb, CString &cha)
{
	chx = GetTableCellString(5, 1, 1);
	chy = GetTableCellString(5, 1, 2);
	chz = GetTableCellString(5, 1, 3);
	chc = GetTableCellString(5, 1, 4);
	chb = GetTableCellString(5, 1, 5);
	cha = GetTableCellString(5, 1, 6);
}

void CRBWCppDlg::GetCartesinaData(long lRow, CString &chtx, CString &chty, 
														CString &chtz, CString &chtc, CString &chtb, CString &chta)
{
	chtx = GetTableCellString(0, lRow, 2);
	chty = GetTableCellString(0, lRow, 3);
	chtz = GetTableCellString(0, lRow, 4);
	chtc = GetTableCellString(0, lRow, 5);
	chtb = GetTableCellString(0, lRow, 6);
	chta = GetTableCellString(0, lRow, 7);
}

void CRBWCppDlg::GetEventsData(long lRow, CString &ch1, CString &ch2, CString &ch3, 
														CString &ch4, CString &ch5, CString &ch6, 
														CString &ch7, CString &ch8, CString &ch9)
{
	ch1 = GetTableCellString(3, lRow, 1);
	ch2 = GetTableCellString(3, lRow, 2);
	ch3 = GetTableCellString(3, lRow, 3);
	ch4 = GetTableCellString(3, lRow, 4);
	ch5 = GetTableCellString(3, lRow, 5);
	ch6 = GetTableCellString(3, lRow, 6);
	ch7 = GetTableCellString(3, lRow, 7);
	ch8 = GetTableCellString(3, lRow, 8);
	ch9 = GetTableCellString(3, lRow, 9);
}

void CRBWCppDlg::GetJointData(long lRow, CString &strA1, CString &strA2, 
				  CString &strA3, CString &strA4, CString &strA5, CString &strA6)
{
	strA1 = GetTableCellString(1, lRow, 1);
	strA2 = GetTableCellString(1, lRow, 2);
	strA3 = GetTableCellString(1, lRow, 3);
	strA4 = GetTableCellString(1, lRow, 4);
	strA5 = GetTableCellString(1, lRow, 5);
	strA6 = GetTableCellString(1, lRow, 6);
}

void CRBWCppDlg::GetPointProcessType(long lRow, CString &strProcessType)
{
	strProcessType = GetTableCellString(2, lRow, 10);
}

void CRBWCppDlg::OnBnClickedButtonAbout()
{
	// TODO: Add your control notification handler code here
	CAboutDlg dlg;
	dlg.DoModal();
}

void CRBWCppDlg::OnBnClickedButtonJoint()
{
	m_iCurrentOutType = 1;
	if(!DoPreCheck()) return;
	
	// TODO: Add your control notification handler code here
	CFileDialog filedlg(FALSE, _T("txt"), _T("JT6.txt"), OFN_OVERWRITEPROMPT, 
		_T("Text Files(*.txt)\0*.txt\0All File(*.*)\0*.*"), NULL);
	if(filedlg.DoModal() != IDOK)
		return;
	CString strFullFileName = filedlg.GetPathName();

	CTextFileWrite filewrite(strFullFileName, CTextFileWrite::UTF_8);
	
	std::vector<RobotPathObject> vPaths;
	if(!GetRobotPaths(vPaths))
		return;

	WriteFirstSection(filewrite, vPaths.size());

	for (size_t i = 1; i <= vPaths.size(); i++)
	{
		CString strElement;
		strElement.Format(_T("%d"), i);
		filewrite << _T("ELEMENT") + strElement + _T("=BEGIN");
		filewrite.WriteEndl();
		
		long lStartIndex = vPaths[i-1].GetStartIndex();
		long lEndIndex = vPaths[i-1].GetEndIndex();

		if(i == 1)//for the first path, output all the points before start point
		{
			for (long j = m_lLandingIndex + 1; j < lStartIndex; j++)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(j, filewrite);
				WritePointStaubliEvents(j, filewrite);
			}
		}
		else
		{
			long lLastEndIndex = vPaths[i-2].GetEndIndex();
			if((lStartIndex - lLastEndIndex) <= 4)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(lStartIndex-1, filewrite);
				WritePointStaubliEvents(lStartIndex-1, filewrite);
			}
			else
			{
				for(long j = lLastEndIndex + 3; j < lStartIndex; j++)
				{
					filewrite << _T("MOVEJ=");
					WriteJointData(j, filewrite);
					WritePointStaubliEvents(j, filewrite);
				}
			}
		}

		for (long j = lStartIndex; j <= lEndIndex; j++)
		{
			filewrite << _T("MOVEJ=");
			WriteJointData(j, filewrite);
			WritePointStaubliEvents(j, filewrite);
		}
		if(i == vPaths.size())
		{
			//for the last path, output all the points before landing point and last end point
			for (long l = lEndIndex + 1; l < m_lTakeoffIndex; l++)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(l, filewrite);
				WritePointStaubliEvents(l, filewrite);
			}
		}
		else
		{
			long lNextStartIndex = vPaths[i].GetStartIndex();
			if((lEndIndex + 2) >= lNextStartIndex)
			{
				AfxMessageBox(_T("There should be at least two In Air points between end point and start point!"));
			}

			//In air points count between two paths may be 2 or more
			//if there are two points between end and start, then output lEndIndex+1 in current path
			//if there are more than two points, then output lEndIndex+1 and lEndIndex+2 in current path
			filewrite << _T("MOVEJ=");
			WriteJointData(lEndIndex + 1, filewrite);
			WritePointStaubliEvents(lEndIndex + 1, filewrite);
			if(((lNextStartIndex - lEndIndex) > 3)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(lEndIndex + 2, filewrite);
				WritePointStaubliEvents(lEndIndex + 2, filewrite);
			}
		}

		filewrite << _T("ELEMENT") + strElement + _T("=END");
		filewrite.WriteEndl();
		filewrite.WriteEndl();
	}

	filewrite << _T("MOVEJ=");
	WriteJointData(m_lTakeoffIndex, filewrite);

	AfxMessageBox(_T("JOINT data output successed"));
}

void CRBWCppDlg::OnBnClickedButtonTcp()
{
	m_iCurrentOutType = 2;
	if(!DoPreCheck()) return;

	// TODO: Add your control notification handler code here
	CFileDialog filedlg(FALSE, _T("txt"), _T("TCP.txt"), OFN_OVERWRITEPROMPT, 
		_T("Text Files(*.txt)\0*.txt\0All File(*.*)\0*.*"), NULL);
	if(filedlg.DoModal() != IDOK)
		return;
	CString strFullFileName = filedlg.GetPathName();

	CTextFileWrite filewrite(strFullFileName, CTextFileWrite::UTF_8);

	std::vector<RobotPathObject> vPaths;
	if(!GetRobotPaths(vPaths))
		return;

	WriteFirstSection(filewrite, vPaths.size());

	for (size_t i = 1; i <= vPaths.size(); i++)
	{
		CString strElement;
		strElement.Format(_T("%d"), i);
		filewrite << _T("ELEMENT") + strElement + _T("=BEGIN");
		filewrite.WriteEndl();

		long lStartIndex = vPaths[i-1].GetStartIndex();
		long lEndIndex = vPaths[i-1].GetEndIndex();

		if(i == 1)
		{
			for (long j = m_lLandingIndex + 1; j <= lStartIndex - 2; j++)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(j, filewrite);
				WritePointStaubliEvents(j, filewrite);
			}
		}
		else
		{
			long lLastEndIndex = vPaths[i-2].GetEndIndex();	
			for(long j = lLastEndIndex + 3; j < lStartIndex - 1; j++)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(j, filewrite);
				WritePointStaubliEvents(j, filewrite);
			}
		}

		for (long j = lStartIndex - 1; j <= lEndIndex + 1; j++)
		{
			if(j >= m_lTakeoffIndex) break;

			CString strMotion;
			GetMotionType(j, strMotion);
			if(strMotion.CompareNoCase(_T("MOVEC")) == 0)
			{
				filewrite << _T("MOVEC=");
				CString strMotion2;
				GetMotionType(j+1, strMotion2);
				if(strMotion2.CompareNoCase(_T("MOVEC")) == 0)
				{
					WriteCartesianData(j, filewrite, false);
					filewrite << _T("/");
					WriteCartesianData(j+1, filewrite);
					j++;
				}
				else
					WriteCartesianData(j, filewrite);
			}
			else
			{
				filewrite << _T("MOVEL=");
				WriteCartesianData(j, filewrite);
			}
			WritePointStaubliEvents(j, filewrite);
		}
		
		if(i == vPaths.size())
		{
			if(lEndIndex + 2 < m_lTakeoffIndex)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(lEndIndex+2, filewrite);
				WritePointStaubliEvents(lEndIndex+2, filewrite);
			}
			for (long l = lEndIndex + 3; l < m_lTakeoffIndex; l++)
			{
				filewrite << _T("MOVEJ=");
				WriteJointData(l, filewrite);
				WritePointStaubliEvents(l, filewrite);
			}
		}
		else
		{
			filewrite << _T("MOVEJ=");
			WriteJointData(lEndIndex+2, filewrite);
			WritePointStaubliEvents(lEndIndex+2, filewrite);
		}
		filewrite << _T("ELEMENT") + strElement + _T("=END");
		filewrite.WriteEndl();
		filewrite.WriteEndl();
	}

	filewrite << _T("MOVEJ=");
	WriteJointData(m_lTakeoffIndex, filewrite);

	AfxMessageBox(_T("TCP data output successed"));
}

bool CRBWCppDlg::GetRobotPaths(std::vector<RobotPathObject> &vPaths)
{
	std::vector<long> vStartIndexes;
	std::vector<long> vEndIndexes;
	long lCount = m_rbwAPI.Get_PointCount();
	for (long l = m_lLandingIndex+1; l <= lCount; l++)
	{
		CString strProcessType;
		GetPointProcessType(l, strProcessType);
		if(strProcessType.CompareNoCase(_T("Start Process")) == 0)
			vStartIndexes.push_back(l);
		if(strProcessType.CompareNoCase(_T("End Process")) == 0)
			vEndIndexes.push_back(l);
	}
	
	if(vStartIndexes.empty())
	{
		AfxMessageBox(_T("Didn't find any Start Process point"));
		return false;
	}
	if(vEndIndexes.empty())
	{
		AfxMessageBox(_T("Didn't find any End Process point"));
		return false;
	}

	if(vStartIndexes.size() != vEndIndexes.size())
	{
		AfxMessageBox(_T("Start Process points count is not equal to End Process points count"));
		return false;
	}

	for (size_t i = 0; i < vStartIndexes.size(); i++)
	{
		vPaths.push_back(RobotPathObject(vStartIndexes[i], vEndIndexes[i]));
	}

	return true;
}

void CRBWCppDlg::WriteToolData(CTextFileWrite& filewrite)
{
	CString strtx, strty, strtz, strtc, strtb, strta;
	GetToolData(strtx, strty, strtz, strtc, strtb, strta);
	//write tool data
	filewrite << _T("TCP=");
	filewrite << strtx;
	filewrite << STR_COMMA;
	filewrite << strty;
	filewrite << STR_COMMA;
	filewrite << strtz;
	filewrite << STR_COMMA;
	filewrite << strtc;
	filewrite <<STR_COMMA;
	filewrite << strtb;
	filewrite << STR_COMMA;
	filewrite << strta;
	filewrite.WriteEndl();
	return;
}

void CRBWCppDlg::WriteFrameData(CTextFileWrite& filewrite)
{
	CString strfx, strfy, strfz, strfc, strfb, strfa;
	GetFrameData(strfx, strfy, strfz, strfc, strfb, strfa);
	filewrite << _T("FRAME=");
	filewrite << strfx;
	filewrite << STR_COMMA;
	filewrite << strfy;
	filewrite << STR_COMMA;
	filewrite << strfz;
	filewrite << STR_COMMA;
	filewrite << strfc;
	filewrite << STR_COMMA;
	filewrite << strfb;
	filewrite << STR_COMMA;
	filewrite << strfa;
	filewrite.WriteEndl();
	return;
}

void CRBWCppDlg::WriteHomeData(CTextFileWrite& filewrite)
{
	//the first point's joint data
	filewrite << _T("HOME=");
	WriteJointData(m_lLandingIndex, filewrite);
}

void CRBWCppDlg::WriteJointData(long lRow, CTextFileWrite& filewrite)
{
	CString strA1, strA2, strA3, strA4, strA5, strA6;
	GetJointData(lRow, strA1, strA2, strA3, strA4, strA5, strA6);
	filewrite << strA1;
	filewrite << STR_COMMA;
	filewrite << strA2;
	filewrite << STR_COMMA;
	filewrite << strA3;
	filewrite << STR_COMMA;
	filewrite << strA4;
	filewrite << STR_COMMA;
	filewrite << strA5;
	filewrite << STR_COMMA;
	filewrite << strA6;
	filewrite.WriteEndl();	
}

void CRBWCppDlg::WriteCartesianData(long lRow, CTextFileWrite& filewrite, bool bWriteEndl)
{
	CString strcx, strcy, strcz, strcc, strcb, strca;
	GetCartesinaData(lRow, strcx, strcy, strcz, strcc, strcb, strca);	
	filewrite << strcx;
	filewrite << STR_COMMA;
	filewrite << strcy;
	filewrite << STR_COMMA;
	filewrite << strcz;
	filewrite << STR_COMMA;
	filewrite << strcc;
	filewrite << STR_COMMA;
	filewrite << strcb;
	filewrite << STR_COMMA;
	filewrite << strca;
	if(bWriteEndl)
		filewrite.WriteEndl();	
}

void CRBWCppDlg::GetEventData(long lRow, long lColumn, CString &strVaule)
{
	strVaule = GetTableCellString(3, lRow, lColumn);
}

void CRBWCppDlg::GetJointDataA1(long lRow, CString &strA1)
{
	strA1 = GetTableCellString(1, lRow, 1);
}

bool CRBWCppDlg::DoPreCheck()
{
	m_lLandingIndex = -1;
	m_lTakeoffIndex = -1;

	CString strVaule = _T("");
	GetJointDataA1(1, strVaule);
	if (strVaule.IsEmpty())
	{
		AfxMessageBox(_T("Please execute Convert to Robot firstly"));
		return false;
	}

	bool bFindLandingPnt = false;
	long lPntCount = m_rbwAPI.Get_PointCount();
	for (long i = 1; i <= lPntCount; i++)
	{
		CString strType = _T("");
		GetPointProcessType(i, strType);
		if(strType.Find(_T("Landing")) != -1) //find it
		{
			bFindLandingPnt = true;
			m_lLandingIndex = i;
			break;
		}
	}
	if(!bFindLandingPnt)
	{
		AfxMessageBox(_T("Did not find the Landing point!"));
		return false;
	}

	bool bFindTakeoffPnt = false;
	for (long i = lPntCount; i >= 1; i--)
	{
		CString strType = _T("");
		GetPointProcessType(i, strType);
		if(strType.Find(_T("Take Off")) != -1) //find it
		{
			bFindTakeoffPnt = true;
			m_lTakeoffIndex = i;
			break;
		}
	}
	if(!bFindTakeoffPnt)
	{
		AfxMessageBox(_T("Did not find the Takeoff point!"));
		return false;
	}

	return true;
}

void CRBWCppDlg::WriteFirstSection(CTextFileWrite& filewrite, long lPathsCnt)
{
	CString strElementCount;
	strElementCount.Format(_T("%d"), lPathsCnt);
	CString strTotalElements = TOTALELEMENTS + strElementCount;
	//write total elements
	filewrite << strTotalElements;
	filewrite.WriteEndl();

	WriteToolData(filewrite);
	WriteFrameData(filewrite);
	WriteHomeData(filewrite);
	filewrite.WriteEndl();
	filewrite.WriteEndl();
	filewrite.WriteEndl();
	return;
}

bool CRBWCppDlg::IsRBWRunning()
{

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
	return bRBW65Runing;
}

void CRBWCppDlg::GetPointStaubliEvents(long lRow, std::map<CString, CString> &eventsvaluemap,
																bool bIncludeMotion)
{
	eventsvaluemap.clear();
	if(bIncludeMotion)
	{
		CString strMotion;
		GetEventData(lRow, 1, strMotion);
		if(strMotion.IsEmpty() == 0)
		{
			eventsvaluemap[MOTION_TYPE] = strMotion;
		}
	}

	CString strSpeed;
	GetEventData(lRow, 2, strSpeed);
	if (strSpeed.IsEmpty() == 0)
	{
		eventsvaluemap[SPEED] = strSpeed;
	}

	CString strBlend;
	GetEventData(lRow, 3, strBlend);
	if (strBlend.IsEmpty() == 0)
	{
		eventsvaluemap[BLEND] = strBlend;
	}

	CString strBypass;
	GetEventData(lRow, 4, strBypass);
	if (strBypass.IsEmpty() == 0)
	{
		eventsvaluemap[BYPASS] = strBypass;
	}

	CString strGoSub;
	GetEventData(lRow, 5, strGoSub);
	if (strGoSub.IsEmpty() == 0)
	{
		eventsvaluemap[GOSUB] = strGoSub;
	}

	CString strLaser;
	GetEventData(lRow, 6, strLaser);
	if (strLaser.IsEmpty() == 0)
	{
		eventsvaluemap[LASER] = strLaser;
	}

	CString strDelay;
	GetEventData(lRow, 7, strDelay);
	if (strDelay.IsEmpty() == 0)
	{
		eventsvaluemap[DELAY] = strDelay;
	}

	CString strSldax;
	GetEventData(lRow, 8, strSldax);
	if (strSldax.IsEmpty() == 0)
	{
		eventsvaluemap[SLDAX_DIS] = strSldax;
	}

	CString strProcess;
	GetEventData(lRow, 9, strProcess);
	if (strProcess.IsEmpty() == 0)
	{
		eventsvaluemap[PROCESS_INDEX] = strProcess;
	}

	CString strA1;
	GetEventData(lRow, 10, strA1);
	if (strA1.IsEmpty() == 0)
	{
		eventsvaluemap[A1] = strA1;
	}

	CString strA2;
	GetEventData(lRow, 11, strA2);
	if (strA2.IsEmpty() == 0)
	{
		eventsvaluemap[A2] = strA2;
	}
}

void CRBWCppDlg::WritePointStaubliEvents(long lRow, CTextFileWrite& filewrite)
{
	std::map<CString, CString> eventsmap;
	GetPointStaubliEvents(lRow, eventsmap);
	std::map<CString, CString>::iterator iter;
	for (iter = eventsmap.begin(); iter != eventsmap.end(); iter++)
	{
		filewrite << iter->first;
		filewrite << _T("=");
		filewrite << iter->second;
		filewrite.WriteEndl();
	}
}

void CRBWCppDlg::GetMotionType(long lRow, CString& strMotion)
{
	GetEventData(lRow, 1, strMotion);
}