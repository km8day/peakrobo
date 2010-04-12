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
	char *GetTableCellString(long lTable, long lRow, long lCol);
	void GetFrameData(char *chtx, char *chty, char *chtz, char *chtc, char *chtb, char *chta);
	void GetToolData(char **chtx, char **chty, char **chtz, char **chtc, char **chtb, char **chta);
	void GetCartesinaData(long lRow, char *chtx, char *chty, char *chtz, char *chtc, char *chtb, char *chta);
	void GetEventsData(long lRow, char **ch1, char **ch2, char **ch3, char **ch4, char **ch5, char **ch6, 
									char **ch7, char **ch8, char **ch9);
};
