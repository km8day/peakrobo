// RBWCppDlg.cpp : implementation file
//

#include "stdafx.h"
#include "RBWCpp.h"
#include "RBWCppDlg.h"
#include "textfile.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define  STR_COMMA _T(",")
#define  STR_LINE _T("\r\n")
#define  STR_SPACE _T(" ")

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
	DDX_Control(pDX, IDC_GenerateText, m_button);
	DDX_Control(pDX, IDC_PROGRESS, m_ProgressCtrl);
}

BEGIN_MESSAGE_MAP(CRBWCppDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_GenerateText, &CRBWCppDlg::OnBnClickedGeneratetext)
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
	filewrite << STR_LINE;
	filewrite << STR_LINE;

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
		filewrite << STR_LINE;

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
		strRet = _T(" ");
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