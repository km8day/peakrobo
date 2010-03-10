// RBWCppDlg.cpp : implementation file
//

#include "stdafx.h"
#include "RBWCpp.h"
#include "RBWCppDlg.h"
#include "CSimple.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


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
}

void CRBWCppDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CRBWCppDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
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
		OrientationData *pData;// = new OrientationData;
		CLSID clsid;//= _T("{15c6f1e1-c97f-4c9a-8be9-7e9f3aea588b}");
		HRESULT hr = CLSIDFromProgID(L"RobotWorks500.API", &clsid);
		IDispatch *pDis;
		hr = CoCreateInstance(clsid, NULL, CLSCTX_LOCAL_SERVER, IID_IDispatch, (void**)&pDis);
		if(hr == S_OK)
		{
			//VARIANT vnt;
			IRecordInfo *pRI;
			OrientationData* data = (OrientationData*)CoTaskMemAlloc(sizeof(OrientationData));
			data->q4 = 0.0;
			data->X = 0.0;data->Y = 0.0; data->z = 0.0;
			data->Rx = 0.0; data->Ry = 0.0; data->Rz = 0.0;
			hr = GetRecordInfoFromGuids(__uuidof(__RobotWorks500), 1, 0, 0x409, __uuidof(OrientationData), &pRI);
			VARIANTARG v[2];
			VariantInit(&v[0]);
			VariantInit(&v[1]);
			//////////////////////////////////////////////////////////////////////////
			//very import step
			v[0].vt = VT_RECORD|VT_BYREF;
			//////////////////////////////////////////////////////////////////////////
			v[0].pvRecord = data;
			v[0].pRecInfo = pRI;
			v[1].vt = VT_I4;
			v[1].lVal = 3;
			DISPPARAMS dispParam = {v, NULL, 2, 0};
			VARIANT varResult;
			VariantInit(&varResult);
			EXCEPINFO excep;
			UINT uArgErr;
			hr = pDis->Invoke(0x60030003, IID_NULL, LOCALE_SYSTEM_DEFAULT, DISPATCH_METHOD, &dispParam, &varResult, &excep, &uArgErr );
			if(hr == S_OK)
			{
				VARIANTARG *pvarg = dispParam.rgvarg;
				VARIANT var = pvarg[0];
				OrientationData *pD = (OrientationData*)var.pvRecord;
				//OrientationData *pDa = *pD;
				double dX = pD->X;
				//VARIANT vX; VariantInit(&vX); vX.vt = VT_R8;
				//hr = pRI->GetField(pdata, _T("X"), &vX);
				int a = 1;
			}
		}
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

