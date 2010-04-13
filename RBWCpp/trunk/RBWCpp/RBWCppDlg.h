// RBWCppDlg.h : header file
//

#pragma once
#include "CRBW65API.h"

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
	CString GetTableCellString(long lTable, long lRow, long lCol);
	void GetFrameData(CString &chx, CString &chy, CString &chz, CString &chc, CString &chb, CString &cha);
	void GetToolData(CString &chtx, CString &chty, CString &chtz, CString &chtc, CString &chtb, CString &chta);
	void GetCartesinaData(long lRow, CString &chtx, CString &chty, CString &chtz, CString &chtc, CString &chtb, CString &chta);
	void GetEventsData(long lRow, CString &ch1, CString &ch2, CString &ch3, CString &ch4, CString &ch5, CString &ch6, 
									CString &ch7, CString &ch8, CString &ch9);
};
