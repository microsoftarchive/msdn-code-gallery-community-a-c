
// SpeakDlg.h : header file
//

#pragma once
#include "afxwin.h"




// CSpeakDlg dialog
class CSpeakDlg : public CDialog
{
// Construction
public:
	CSpeakDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_SPEAK_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
    afx_msg void OnBnClickedSpeak();
    DECLARE_MESSAGE_MAP()

private:
    // Text input by user
    CEdit m_UserText;

    // Text speaker
    gds::CTextSpeaker m_TextSpeaker;
};
