/*!-----------------------------------------------------------------------
	AdjacentWindow.cpp

	Implementation for the Adjacent Window
-----------------------------------------------------------------------!*/
#include "stdafx.h"
#include "AdjacentWindow.h"
#include "AdjacentWindowHelper.h"
#include "ids.h"

enum
{
	PositionLeft,
	PositionTop,
	PositionRight,
	PositionBottom,
	PositionMax
};

_ATL_FUNC_INFO CAdjacentWindow::DispatchFuncInfo0 = {CC_STDCALL, VT_EMPTY, 0, {}};

extern bool g_fHostShutdown;

// Register the window class for the adjacent window
void InitializeAdjacentWindowClass()
{
	WNDCLASS wc;
	memset(&wc, 0, sizeof(WNDCLASS));
	wc.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS;
	wc.lpfnWndProc = ::DefWindowProc;
	wc.hInstance = AfxGetInstanceHandle();
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.lpszClassName = ADDIN_WNDCLASS;
	wc.hbrBackground = NULL;
	
	RegisterClass(&wc);
}

CAdjacentWindow::CAdjacentWindow()
:	m_hWndSibling(NULL)
,	m_hWndTopLevelWindow(NULL)
,	m_hWndPrev(NULL)
,	m_hWndNext(NULL)
,	m_position(PositionTop)
,	m_nCurrentPaneSize(0)
,	m_fHidden(false)
,	m_fSizing(false)
,	m_fDestroyed(false)
{
	m_rcFullClientArea.SetRectEmpty();	
	m_rcPreviewPane.SetRectEmpty();
}

CAdjacentWindow::~CAdjacentWindow()
{
	UnadviseOMObjects();
}

// Set up our pointers/references to the inspector/explorer and the parent/sibling windows
void CAdjacentWindow::Initialize(_InspectorPtr spInsp, _ExplorerPtr spExp, HWND hWndTopLevelWindow, HWND hWndSibling)
{
	assert(spInsp || spExp);
	UnadviseOMObjects();
	if (spInsp)
	{
		m_spInsp = spInsp;
		InspectorEventsSink::DispEventAdvise(m_spInsp);
	}
	else if (spExp)
	{
		m_spExp = spExp;
		ExplorerEventsSink::DispEventAdvise(m_spExp);
	}
	m_hWndSibling = hWndSibling;
	m_hWndTopLevelWindow = hWndTopLevelWindow;
}

// Create the adjacent window
void CAdjacentWindow::Create(HWND hWndParent)
{
	CreateEx(WS_EX_CONTROLPARENT,
		ADDIN_WNDCLASS,
		ADDIN_WINDOWTITLE,
		WS_CHILD | WS_VISIBLE | WS_TABSTOP | WS_CLIPCHILDREN | WS_CLIPSIBLINGS,
		0, 0, 
		100, 100,
		hWndParent, NULL);
}

// Handle the Close event on the inspector - unadvise on events and hide ourselves
HRESULT CAdjacentWindow::EvtClose()
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	UnadviseOMObjects();
	SetHidden(true);
	return S_OK;
}

void CAdjacentWindow::RecalcPreviewPaneLayout()
{
	if (m_hWndPrev)
	{
		// Tell the controller window to layout everything
		::SendMessage(m_hWndPrev, WM_NEGOTIATE_WINDOW_PANE, RecalcPaneLayout, 0);
	}
	else
	{
		// We are the controller
		RecalcPreviewPaneLayoutController();
	}
}

void CAdjacentWindow::SiblingWindowPosChanging(WINDOWPOS *pwindowPos)
{
	if (!m_hWndPrev) // Only process if we're the controller
	{
		if (!(pwindowPos->flags & SWP_NOSIZE))
		{
			if (pwindowPos->flags & SWP_NOMOVE)
			{
				// Compute the needed parameters
				RECT rc;
				POINT pt;
				pt.x = pt.y = 0;
				::GetClientRect(pwindowPos->hwnd, &rc);
				::MapWindowPoints(pwindowPos->hwnd, ::GetParent(pwindowPos->hwnd), &pt, 1);
				pwindowPos->x = pt.x;
				pwindowPos->y = pt.y;
			}

			if (!m_fSizing)
			{
				m_fSizing = true;

				CRect rc;
				CRect rcReserved;
				CRect rcNewClientArea;

				rcReserved.SetRectEmpty();

				// Find out the required area
				
				int nResult = SendMessage(WM_NEGOTIATE_WINDOW_PANE, GetReservedRect, reinterpret_cast<LPARAM>(&rcReserved));
				assert(nResult == 1);

				// When the theme changes, we get a WindowPosChanging for which rcNewClientArea = preview pane area. 
				// Don't recompute the areas in that case - they haven't really changed.
				// Note: if we get the WindowPosChanging from Outlook, rcNewClientArea = preview pane + injected panes.
				rcNewClientArea.SetRect(pwindowPos->x, pwindowPos->y, pwindowPos->x + pwindowPos->cx, pwindowPos->y + pwindowPos->cy);
				if (m_rcPreviewPane != rcNewClientArea)
				{
					pwindowPos->x += rcReserved.left;
					pwindowPos->y += rcReserved.top;
					pwindowPos->cx -= (rcReserved.left + rcReserved.right);
					pwindowPos->cy -= (rcReserved.top + rcReserved.bottom);

					// This is the area already taken out by the preview pane
					m_rcPreviewPane.SetRect(pwindowPos->x, pwindowPos->y, pwindowPos->x + pwindowPos->cx, pwindowPos->y + pwindowPos->cy);
					m_rcFullClientArea = rcNewClientArea;
				}
				rc = m_rcPreviewPane;

				// Tell everyone (from the top down) to lay itself out
				SendMessage(WM_NEGOTIATE_WINDOW_PANE, PlaceWindowAdjacentToRect, reinterpret_cast<LPARAM>(&rc));

				// Assert that everyone has laid itself out and it is taking up all the available space
				assert(rc.Width() == pwindowPos->cx + (rcReserved.left + rcReserved.right) && rc.Height() == pwindowPos->cy + (rcReserved.top + rcReserved.bottom));

				m_fSizing = false;
			}
		}
	}
}


BEGIN_MESSAGE_MAP(CAdjacentWindow, CWnd)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_WM_NCHITTEST()
	ON_WM_LBUTTONDBLCLK()
	ON_WM_PAINT()
	ON_MESSAGE(WM_PRINT, Print)
	ON_WM_SIZE()
	ON_MESSAGE(WM_NEGOTIATE_WINDOW_PANE, OnNegotiateWindow)
END_MESSAGE_MAP()

int CAdjacentWindow::OnCreate(LPCREATESTRUCT lpcs)
{
	int nRet = CWnd::OnCreate(lpcs);
	if (nRet == 0)
	{
		FindTopMostInjectedPane();
		m_fDestroyed = false;
	}

	return nRet;
}

void CAdjacentWindow::OnDestroy()
{
	if (!m_fDestroyed)
	{
		// May be reentrant, as releasing the OM objects could cause the Outlook frame
		// to be destroyed, thus destroying us again (since we are a child window of the frame)
		m_fDestroyed = true;

		if (!g_fHostShutdown)
		{
			// If Outlook isn't shutting down, resize the host preview pane back to its original size
			RecalcPreviewPaneLayout();

			// Unhook ourselves from the list of injected panes
			if (m_hWndPrev)
				::SendMessage(m_hWndPrev, WM_NEGOTIATE_WINDOW_PANE, ReplaceNextWindow, reinterpret_cast<LPARAM>(m_hWndNext));
			if (m_hWndNext)
				::SendMessage(m_hWndNext, WM_NEGOTIATE_WINDOW_PANE, ReplacePrevWindow, reinterpret_cast<LPARAM>(m_hWndPrev));
		}

		UnadviseOMObjects();
	}
	CWnd::OnDestroy();
}

LRESULT CAdjacentWindow::OnNcHitTest(CPoint pt)
{
	// Change the cursor at the boundary so the user can resize the pane
	CRect rect;
	GetWindowRect(&rect);
	const int iSplitterSize = 5;

	switch (m_position)
	{
		case PositionLeft:
			if (pt.x > rect.right - iSplitterSize)
				return HTRIGHT;
			break;
		case PositionTop:
			if (pt.y > rect.bottom - iSplitterSize)
				return HTBOTTOM;
			break;
		case PositionRight:
			if (pt.x < rect.left + iSplitterSize)
				return HTLEFT;
			break;
		case PositionBottom:
			if (pt.y < rect.top + iSplitterSize)
				return HTTOP;
			break;
	}

	return CWnd::OnNcHitTest(pt);
}

// Change the position of the window
void CAdjacentWindow::OnLButtonDblClk(UINT, CPoint)
{
	m_position = (m_position + 1) % PositionMax;
	RecalcPreviewPaneLayout();
}

void CAdjacentWindow::OnPaint()
{
	CPaintDC dc(this);
	PaintToDC(dc.m_hDC);
}

LRESULT CAdjacentWindow::Print(WPARAM wParam, LPARAM)
{
	HDC hdc = (HDC) wParam;
	PaintToDC(hdc);
	return 1;
}

void CAdjacentWindow::OnSize(UINT nType,int cx,int cy)
{
	if (cx != 0 && cy != 0)
	{
		if (!m_fSizing)
			RecalcPreviewPaneLayout();

		switch (m_position)
		{
			case PositionLeft:
			case PositionRight:
				m_nCurrentPaneSize = cx;
				break;
			case PositionTop:
			case PositionBottom:
				m_nCurrentPaneSize = cy;
				break;
		}
	}

	CWnd::OnSize(nType, cx, cy);
}

// Handle cooperative placement of multiple injected panes
LRESULT CAdjacentWindow::OnNegotiateWindow(WPARAM wParam, LPARAM lParam)
{
	switch (wParam)
	{
		case AddCustomWindowToTop:
			{
				// This message is broadcasted to all windows in the preview pane area
				// Input: the HWND of the new pane
				// Output: the HWND of the previous top pane
				// Result: the new HWND becomes the topmost, and is linked to the previous topmost
				
				// Add the given window to the top of the list of window
				// Only do this if we're currently the top
				if (!m_hWndPrev)
				{
					m_hWndPrev = reinterpret_cast<HWND>(lParam);
					return reinterpret_cast<LRESULT>(m_hWnd);
				}
				else
				{
					return 0;
				}
			}
		case ReplacePrevWindow:
			{
				// This message is sent to the "next" pane when the direct "prev" pane is going away
				// Input: the HWND of the new prev pane
				// Result: the prev pane is replaced with the new parameter
				HWND hWndPrev = reinterpret_cast<HWND>(lParam);
				if (hWndPrev != NULL)
				{
					// If we are now the controller, then ask the previous controller what the client area is
					::SendMessage(hWndPrev, WM_NEGOTIATE_WINDOW_PANE, GetFullClientArea, reinterpret_cast<LPARAM>(&m_rcFullClientArea));					
				}
				m_hWndPrev = hWndPrev;
				return 0;
			}
		case ReplaceNextWindow:
			{
				// This message is sent to the "prev" pane when the direct "next" pane is going away
				// Input: the HWND of the new next pane
				// Result: the next pane is replaced with the new parameter
				m_hWndNext = reinterpret_cast<HWND>(lParam);
				return 0;
			}
		case GetReservedRect:
			{
				// This message is sent by the topmost pane to the next next pane (recursively)
				// to find out how much room to reserve on each side of the preview pane
				// Note that LPARAM points to a rect, but the rect does not refer to coordinates in the
				// usual sense. It is just the pixel width to reserve on each side of the preview pane
				
				if (m_hWndNext)
				{
					int nResult = ::SendMessage(m_hWndNext, WM_NEGOTIATE_WINDOW_PANE, GetReservedRect, lParam);
					assert(nResult == 1);
				}

				RECT *prc = reinterpret_cast<RECT *>(lParam);

				switch (m_position)
				{
				case PositionLeft:
					prc->left += GetCurrentPaneSize();
					break;
				case PositionTop:
					prc->top += GetCurrentPaneSize();
					break;
				case PositionRight:
					prc->right += GetCurrentPaneSize();
					break;
				case PositionBottom:
					prc->bottom += GetCurrentPaneSize();
					break;
				}

				return 1;
			}
		case PlaceWindowAdjacentToRect:
			{
				// This message is sent by the topmost pane to the next next pane (recursively)
				// to position the pane (using SetWindowPos)
				// Input: The current rect that is already occupied by the preview pane and other panes above this one
				// Action: Place our window to the bottom or right of the occupied space
				// You must update the rect to include our new space as occupied and pass the new rect to the next window
				int nClientSize = GetCurrentPaneSize();

				CRect *prc = reinterpret_cast<CRect *>(lParam);

				switch (m_position)
				{
				case PositionLeft:
					SetWindowPos(NULL, prc->left - nClientSize, prc->top, nClientSize, prc->Height(), SWP_NOZORDER);
					// Adjust the given rect to fill our space now
					prc->left -= nClientSize;
					break;
				case PositionTop:
					SetWindowPos(NULL, prc->left, prc->top - nClientSize, prc->Width(), nClientSize, SWP_NOZORDER);
					// Adjust the given rect to fill our space now
					prc->top -= nClientSize;
					break;
				case PositionRight:
					SetWindowPos(NULL, prc->left + prc->Width(), prc->top, nClientSize, prc->Height(), SWP_NOZORDER);
					// Adjust the given rect to fill our space now
					prc->right += nClientSize;
					break;
				case PositionBottom:
					SetWindowPos(NULL, prc->left, prc->bottom, prc->Width(), nClientSize, SWP_NOZORDER);
					// Adjust the given rect to fill our space now
					prc->bottom += nClientSize;
					break;
				}


				if (m_hWndNext)
				{
					::SendMessage(m_hWndNext, WM_NEGOTIATE_WINDOW_PANE, PlaceWindowAdjacentToRect, lParam);
				}
				return 0;
			}
		case RecalcPaneLayout:
			{
				// This message is sent by any pane and must be passed up the chain to the topmost pane
				// to tell it to relayout all the injected panes
				RecalcPreviewPaneLayout();
				return 0;
			}
		case GetFullClientArea:
			{
				assert(!m_rcFullClientArea.IsRectEmpty());
				CRect *prc = reinterpret_cast<CRect *>(lParam);
				*prc = m_rcFullClientArea;
				return 0;
			}
		default:
			{
				return 0;
			}
	}
}

void CAdjacentWindow::RecalcPreviewPaneLayoutController()
{
	if (m_fSizing)
		return;

	CRect rcReserved;
	CRect rcAll;

	rcReserved.SetRectEmpty();

	int nResult = SendMessage(WM_NEGOTIATE_WINDOW_PANE, GetReservedRect, reinterpret_cast<LPARAM>(&rcReserved));
	assert(nResult == 1);

	if (m_rcFullClientArea.IsRectEmpty())
	{
		// If we don't have the client area already, then calculate it
		// This calculation assumes that the preview pane (m_hWndSibling) is currently
		// occuping the entire space that we wish to put the preview pane + injected panes.
		// This is only true initially when no add-ins have injected any panes in the
		// preview pane area
		HWND hwndParent = ::GetParent(m_hWndSibling);
		::GetClientRect(m_hWndSibling, &m_rcFullClientArea);
		::MapWindowPoints(m_hWndSibling, hwndParent, reinterpret_cast<LPPOINT>(&m_rcFullClientArea), 2);
	}

	rcAll = m_rcFullClientArea;

	rcAll.left += rcReserved.left;
	rcAll.top += rcReserved.top;
	rcAll.right -= rcReserved.right;
	rcAll.bottom -= rcReserved.bottom;

	m_fSizing = true;

	// Lay out the preview pane/inspector
	::SetWindowPos(m_hWndSibling, NULL, rcAll.left, rcAll.top, rcAll.Width(), rcAll.Height(), SWP_NOZORDER);

	m_rcPreviewPane = rcAll;

	// Lay out the injected panes
	SendMessage(WM_NEGOTIATE_WINDOW_PANE, PlaceWindowAdjacentToRect, reinterpret_cast<LPARAM>(&rcAll));

	m_fSizing = false;
}

// Simple painting function
void CAdjacentWindow::PaintToDC(HDC hdc)
{
	CRect rcClient;
	GetClientRect(&rcClient);
	COLORREF clrBkColorOld; 
	COLORREF clrFgColorOld; 

	clrBkColorOld = SetBkColor(hdc, 0xDDDDDD);
	clrFgColorOld = SetTextColor(hdc, 0x0);

	// Paint the background
	ExtTextOut(hdc, 0, 0, ETO_OPAQUE, &rcClient, NULL, 0, NULL);

	// Write text
	rcClient.DeflateRect(10, 10);
	DrawText(hdc, _T("Double click here to change the position of the pane"), -1, &rcClient, 0);

	SetTextColor(hdc, clrFgColorOld);
	SetBkColor(hdc, clrBkColorOld);
}

// Tell Outlook we don't want to receive any more events
void CAdjacentWindow::UnadviseOMObjects()
{
	if (m_spInsp)
	{
		InspectorEventsSink::DispEventUnadvise(m_spInsp);
		m_spInsp = NULL;
	}
	if (m_spExp)
	{
		ExplorerEventsSink::DispEventUnadvise(m_spExp);
		m_spExp = NULL;
	}
}

void CAdjacentWindow::FindTopMostInjectedPane()
{
	// Step through the list of windows that might be injected panes.
	// Ask whether it is the top most and add ourselves to the list.
	HWND hWndChild = ::GetWindow(::GetParent(m_hWndSibling), GW_CHILD);
	while (hWndChild)
	{
		if (hWndChild != m_hWnd)
		{
			HWND hWndNext = reinterpret_cast<HWND>(::SendMessage(hWndChild, WM_NEGOTIATE_WINDOW_PANE, AddCustomWindowToTop, reinterpret_cast<LPARAM>(m_hWnd)));
			if (hWndNext)
			{
				m_hWndNext = hWndNext;
				break;
			}
		}
		hWndChild = ::GetWindow(hWndChild, GW_HWNDNEXT);
	}

	if (m_hWndNext)
	{
		// If there was a previous controller, then ask the previous controller what the client area is
		// If not, the first call to SiblingWindowPosChanging or RecalcPreviewPaneLayoutController will
		// calculate it.
		::SendMessage(m_hWndNext, WM_NEGOTIATE_WINDOW_PANE, GetFullClientArea, reinterpret_cast<LPARAM>(&m_rcFullClientArea));
	}
}

int CAdjacentWindow::GetCurrentPaneSize()
{
	CRect rcClient;

	if (m_fDestroyed)
		return 0;
	else
		return m_nCurrentPaneSize;
}

