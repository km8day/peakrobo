// RBWCppDlg.h : header file
//

#pragma once
#include "CRBW65API.h"
#include "afxwin.h"
#include "afxcmn.h"
#include <vector>
#include <map>
#include "textfile.h"

class RobotPathObject 
{

public:
	RobotPathObject(long lStartIndex, long lEndIndex)
	{
		m_lStartIndex = lStartIndex;
		m_lEndIndex = lEndIndex;
	}

	long GetStartIndex()
	{
		return m_lStartIndex;
	}

	long GetEndIndex()
	{
		return m_lEndIndex;
	}

private:
	long m_lStartIndex;
	long m_lEndIndex;
};

// CRBWCppDlg dialog
class CRBWCppDlg : public CDialog
{
// Construction
public:
	CRBWCppDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_RBWCPP_DIALOG };

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
	afx_msg void OnBnClickedGeneratetext();

private:
	CRBW65API m_rbwAPI;
	bool m_bDispCreated;
	int m_iCurrentOutType; // 1 means Joint output, 2 means TCP output
	long m_lLandingIndex;
	long m_lTakeoffIndex;
	CString GetTableCellString(long lTable, long lRow, long lCol);
	void GetFrameData(CString &chx, CString &chy, CString &chz, 
									CString &chc, CString &chb, CString &cha);
	void GetToolData(CString &chtx, CString &chty, CString &chtz, 
								CString &chtc, CString &chtb, CString &chta);
	void GetCartesinaData(long lRow, CString &chtx, CString &chty, 
									CString &chtz, CString &chtc, CString &chtb, CString &chta);
	void GetJointData(long lRow, CString &strA1, CString &strA2, 
								CString &strA3, CString &strA4, CString &strA5, CString &strA6);
	void GetJointDataA1(long lRow, CString &strA1);
	void GetEventsData(long lRow, CString &ch1, CString &ch2, 
									CString &ch3, CString &ch4, CString &ch5, CString &ch6, 
									CString &ch7, CString &ch8, CString &ch9);
	void GetEventData(long lRow, long lColumn, CString &strVaule);
	void GetPointProcessType(long lRow, CString &strProcessType);
	bool GetRobotPaths(std::vector<RobotPathObject> &vPathes);
	void WriteToolData(CTextFileWrite& filewrite);
	void WriteFrameData(CTextFileWrite& filewrite);
	void WriteHomeData(CTextFileWrite& filewrite);
	void WriteJointData(long lRow, CTextFileWrite& filewrite);
	void WriteCartesianData(long lRow, CTextFileWrite& filewrite);
	bool DoPreCheck();
	void WriteFirstSection(CTextFileWrite& filewrite, long lPathsCnt);
	bool IsRBWRunning();
	void GetPointStaubliEvents(long lRow, std::map<CString, CString> &eventsvaluemap,
											bool bIncludeMotion = false);
	void WritePointStaubliEvents(long lRow, CTextFileWrite& filewrite);

public:
	CButton m_button;
	CProgressCtrl m_ProgressCtrl;
	afx_msg void OnBnClickedButtonAbout();
	afx_msg void OnBnClickedButtonJoint();
	afx_msg void OnBnClickedButtonTcp();
};
