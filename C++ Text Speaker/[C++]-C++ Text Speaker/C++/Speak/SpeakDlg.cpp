
// SpeakDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Speak.h"
#include "SpeakDlg.h"



#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CSpeakDlg dialog




CSpeakDlg::CSpeakDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSpeakDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSpeakDlg::DoDataExchange(CDataExchange* pDX)
{
    CDialog::DoDataExchange(pDX);
    DDX_Control(pDX, IDC_TEXT, m_UserText);
}

BEGIN_MESSAGE_MAP(CSpeakDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
    ON_BN_CLICKED(IDC_SPEAK, &CSpeakDlg::OnBnClickedSpeak)
END_MESSAGE_MAP()


// CSpeakDlg message handlers

BOOL CSpeakDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CSpeakDlg::OnPaint()
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
HCURSOR CSpeakDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



//------------------------------------------------------------------------
// Speak user text
//------------------------------------------------------------------------
void CSpeakDlg::OnBnClickedSpeak()
{
    //
    // Get user text (cut text after a maximum length)
    //
    static const int cchMaxUserTextLen = 200;
    WCHAR szUserText[cchMaxUserTextLen + 1];  
    m_UserText.GetWindowText(szUserText, cchMaxUserTextLen);
    
    // Wrap user text in a convenient CString instance
    CStringW text(szUserText);
    if (text.Trim().IsEmpty())
    {
        // User text must not be empty
        AfxMessageBox(IDS_ERROR_TEXT_IS_EMPTY, MB_OK|MB_ICONERROR);
        return;
    }

    //
    // Speak text
    //
    m_TextSpeaker.Speak(text);
}

