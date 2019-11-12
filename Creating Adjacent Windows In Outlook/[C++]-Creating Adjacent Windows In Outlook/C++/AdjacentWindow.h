// AdjacentWindow.h : Global declaration of the Adjacent Window
#pragma once

// Initialize the window class for the adjacent window
void InitializeAdjacentWindowClass();

class CAdjacentWindow;

typedef
	IDispEventSimpleImpl<1, CAdjacentWindow, &__uuidof(InspectorEvents)>
	InspectorEventsSink;

typedef
	IDispEventSimpleImpl<2, CAdjacentWindow, &__uuidof(ExplorerEvents)>
	ExplorerEventsSink;

// The CWnd window class to handle events from the adjacent window
class CAdjacentWindow
	: public CWnd
	, public InspectorEventsSink
	, public ExplorerEventsSink
{
public:
	CAdjacentWindow();
	~CAdjacentWindow();

	void Initialize(_InspectorPtr spInsp, _ExplorerPtr spExp, HWND hWndTopLevelWindow, HWND hWndSibling);
	void Create(HWND hWndParent);

	// When a user closes a mail window, the window is hidden instead of destroyed
	// CAdjacentWindow keeps track of this by setting the hidden flag
	void SetHidden(bool fHidden) { m_fHidden = fHidden; }
	bool FHidden()               { return m_fHidden; }

	static _ATL_FUNC_INFO DispatchFuncInfo0;

	BEGIN_SINK_MAP(CAdjacentWindow)
		SINK_ENTRY_INFO(1, __uuidof(InspectorEvents), dispidEventClose, EvtClose, &DispatchFuncInfo0)
		SINK_ENTRY_INFO(2, __uuidof(ExplorerEvents),  dispidEventClose, EvtClose, &DispatchFuncInfo0)
	END_SINK_MAP()

	STDMETHOD(EvtClose)();

	void RecalcPreviewPaneLayout();
	void SiblingWindowPosChanging(WINDOWPOS *pwindowPos);

protected:
	afx_msg int 	OnCreate(LPCREATESTRUCT lpcs);
	afx_msg void	OnDestroy();
	afx_msg LRESULT	OnNcHitTest(CPoint pt);
	afx_msg void	OnLButtonDblClk(UINT nFlags, CPoint pt);
	afx_msg void	OnPaint();
	afx_msg LRESULT	Print(WPARAM wParam, LPARAM lParam);
	afx_msg void	OnSize(UINT nType,int cx,int cy);
	afx_msg LRESULT	OnNegotiateWindow(WPARAM wParam, LPARAM lParam);

	void RecalcPreviewPaneLayoutController();
	void PaintToDC(HDC hdc);

	void UnadviseOMObjects();

	void FindTopMostInjectedPane();

	int GetCurrentPaneSize();

	DECLARE_MESSAGE_MAP()

protected:
	// Pointers to the Outlook OM object containing the adjacent pane
	_InspectorPtr m_spInsp;
	_ExplorerPtr m_spExp;

	// Window handles
	HWND m_hWndSibling;
	HWND m_hWndTopLevelWindow;
	HWND m_hWndPrev;
	HWND m_hWndNext;

	// Position information
	CRect m_rcFullClientArea;
	CRect m_rcPreviewPane;
	int m_position;
	int m_nCurrentPaneSize;

	// Flags
	bool m_fHidden;
	bool m_fSizing;
	bool m_fDestroyed;
};
