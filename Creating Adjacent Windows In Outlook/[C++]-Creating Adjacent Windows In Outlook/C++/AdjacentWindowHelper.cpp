/*!-----------------------------------------------------------------------
	AdjacentWindowHelper.cpp

	Implementation for Adjacent Window helpers (locating and placing the Window)
-----------------------------------------------------------------------!*/
#include "stdafx.h"
#include "AdjacentWindow.h"
#include "AdjacentWindowHelper.h"
#include "Idlecall.h"

static _ExplorersPtr 	s_spExplorers;
static _InspectorsPtr 	s_spInspectors;

const TCHAR g_tzWndClassRen[] = TEXT("rctrl_renwnd32");
const TCHAR	g_tzAfxWndW[] = TEXT("AfxWndW");
const TCHAR g_tzFolderBar[] = TEXT("FolderBar");

// Sets up variables and creates adjacent windows
void InitializeAdjacentWindows(_Explorers *pExplorers, _Inspectors *pInspectors)
{
	s_spExplorers = pExplorers;
	s_spInspectors = pInspectors;
	InitializeAdjacentWindowClass();

	// Create adjacent windows on all currently opened explorers and inspectors
	FindTopLevelWindows();
}

// Attempts to find the HWND of an explorer or inspector object (or any other
// IDispatch which implements IOleInPlaceFrame).
HWND HwndFromIDispatch(IDispatch * pdisp)
{
	IOleWindowPtr spOleFrame;
	HWND hwndFrame = NULL;

	spOleFrame = pdisp;

	if (spOleFrame)
		spOleFrame->GetWindow(&hwndFrame);

	return hwndFrame;
}

// Class WndProcInfo - contains information about the Window hook
class WndProcInfo
{
public:
	WndProcInfo()
		: m_hWnd(NULL)
		, m_wndProcOld(NULL)
		, m_wndProcNew(NULL)
		, m_pwndAdjacentWindow(NULL)
	{}

	~WndProcInfo()
	{
		Destroy();
	}
	
	bool operator==(const WndProcInfo &ei)
	{
		return (m_hWnd == ei.m_hWnd);
	}

	void Destroy()
	{
		// Remove ourselves from the window hook chain
		if (m_hWnd && m_wndProcOld)
		{
			if (GetWindowLongPtr(m_hWnd, GWLP_WNDPROC) != reinterpret_cast<LONG_PTR>(m_wndProcNew))
			{
				// If the current window hook doesn't match the one we added, this means someone
				// else has subclassed the window. We need to tell that client to update its old wndproc
				// to our old wndproc and unhook ourselves from this linked list of wndprocs
				int nResult = SendMessage(m_hWnd, WM_REMOVING_WNDPROC, reinterpret_cast<WPARAM>(m_wndProcOld), reinterpret_cast<LPARAM>(m_wndProcNew));
				assert(nResult == 1);
			}
			else
			{
				SetWindowLongPtr(m_hWnd, GWLP_WNDPROC, reinterpret_cast<LONG_PTR>(m_wndProcOld));
			}
		}

		// Clean up the window
		if (m_pwndAdjacentWindow)
		{
			m_pwndAdjacentWindow->DestroyWindow();
			delete m_pwndAdjacentWindow;
			m_pwndAdjacentWindow = NULL;
		}
	}

public:
	// Member variables
	HWND m_hWnd;
	WNDPROC m_wndProcOld;
	WNDPROC m_wndProcNew;
	CAdjacentWindow *m_pwndAdjacentWindow;
};

// The set of windows (explorers/inspectors) where we have an adjacent window
typedef shared_ptr<WndProcInfo>  WndProcInfoPtr;
typedef list<WndProcInfoPtr>  window_list_t;
window_list_t       s_rgHookedWindows;

// The set of explorers where we don't have a preview pane, but are
// listening in to when the preview pane is created
window_list_t       s_rgUnhookedWindows;

bool operator==(const WndProcInfoPtr & procInfo, const HWND & hwnd)
{
	return (procInfo->m_hWnd == hwnd);
}

bool FHandleRemovingWndProc(WPARAM wParam, LPARAM lParam, window_list_t::iterator result)
{
	// If our old wndproc matches the one that is being removed, update it
	// to the new old wndproc
	if (lParam == reinterpret_cast<LPARAM>((*result)->m_wndProcOld))
	{
		(*result)->m_wndProcOld = reinterpret_cast<WNDPROC>(wParam);
		return true;
	}
	return false;
}

// WindowProc that we inject into Outlook to make space for the adjacent window
LRESULT CALLBACK WndProcHookedWindow(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	window_list_t::iterator result;

	result = find(s_rgHookedWindows.begin(), s_rgHookedWindows.end(), hWnd);

	if (result == s_rgHookedWindows.end())
	{
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	else
	{
		WNDPROC wndProcOld = (*result)->m_wndProcOld; // Save off local so we still have the data after the erase

		switch (uMsg)
		{
		case WM_WINDOWPOSCHANGING:
			{
				WINDOWPOS *pwindowPos = reinterpret_cast<WINDOWPOS*>(lParam);
				(*result)->m_pwndAdjacentWindow->SiblingWindowPosChanging(pwindowPos);
				break;
			}
		case WM_REMOVING_WNDPROC:
			{
				if (FHandleRemovingWndProc(wParam, lParam, result))
					return 1;
				break;
			}
		case WM_DESTROY:
			{
				s_rgHookedWindows.erase(result);
				break;
			}
		}
		return CallWindowProc(wndProcOld, hWnd, uMsg, wParam, lParam);
	}
}

// WindowProc that we inject into Outlook to track when the preview pane might be created
LRESULT CALLBACK WndProcUnhookedWindow(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	window_list_t::iterator result;

	result = find(s_rgUnhookedWindows.begin(), s_rgUnhookedWindows.end(), hWnd);

	assert(result != s_rgUnhookedWindows.end());
	if (result == s_rgUnhookedWindows.end())
	{
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	else
	{
		WNDPROC wndProcOld = (*result)->m_wndProcOld; // Save off local so we still have the data after the erase
		
		switch (uMsg)
		{
		case WM_PARENTNOTIFY:
			{
				if (LOWORD(wParam) == WM_CREATE)
					CallIdle(idleFindTopLevelWindows);
				break;
			}
		case WM_REMOVING_WNDPROC:
			{
				if (FHandleRemovingWndProc(wParam, lParam, result))
					return 1;
				break;
			}
		case WM_DESTROY:
			{
				s_rgUnhookedWindows.erase(result);
				break;
			}
		}
		return CallWindowProc(wndProcOld, hWnd, uMsg, wParam, lParam);
	}
}

// Given the HWND of the frame, find the OM object (Explorer or Inspector) that corresponds to that frame
bool FMatchWindowToOMObject(HWND hwndToMatch, _Explorer **ppExp, _Inspector **ppInsp)
{
	long lCount = 0;
	bool fFound = false;

	*ppExp = NULL;
	*ppInsp = NULL;

	if (FAILED(s_spExplorers->get_Count(&lCount)))
		return false;

	for (int i = 1; i <= lCount; i++)
	{
		_ExplorerPtr explorer;
		CComVariant vCount(i);

		if (FAILED(s_spExplorers->Item(vCount, &explorer)))
			return false;

		if (hwndToMatch == HwndFromIDispatch(explorer))
		{
			*ppExp = explorer.Detach();
			fFound = true;
			goto Done;
		}
	}

	if (FAILED(s_spInspectors->get_Count(&lCount)))
		return false;

	for (int i = 1; i <= lCount; i++)
	{
		_InspectorPtr inspector;
		CComVariant vCount(i);

		if (FAILED(s_spInspectors->Item(vCount, &inspector)))
			return false;

		if (hwndToMatch == HwndFromIDispatch(inspector))
		{
			IDispatchPtr spdisp;
			// Check if the type matches.
			if (SUCCEEDED(inspector->get_CurrentItem(&spdisp)))
			{
				*ppInsp = inspector.Detach();
				fFound = true;
			}				
			goto Done;
		}
	}

Done:
	return fFound;
}

// Create the adjacentwindow
bool FCreateHookedAdjacentWindow(HWND hWndSibling, HWND hWndParent, HWND hWndTopLevelWindow)
{
	_ExplorerPtr spExp;
	_InspectorPtr spInsp;
	window_list_t::iterator iterHooked;
	bool fResult = false;

	if (FMatchWindowToOMObject(hWndTopLevelWindow, &spExp, &spInsp))
	{
		assert(spExp ^ spInsp);

		iterHooked = find(s_rgHookedWindows.begin(), s_rgHookedWindows.end(), hWndSibling);
		if (iterHooked == s_rgHookedWindows.end())
		{
			WndProcInfoPtr spProcHooked(new WndProcInfo);

			// Create the window
			spProcHooked->m_hWnd = hWndSibling;
			spProcHooked->m_pwndAdjacentWindow = new CAdjacentWindow();
			spProcHooked->m_pwndAdjacentWindow->Initialize(spInsp, spExp, hWndTopLevelWindow, hWndSibling);
			spProcHooked->m_pwndAdjacentWindow->Create(hWndParent);

			if (spProcHooked->m_pwndAdjacentWindow->GetSafeHwnd())
			{
				spProcHooked->m_wndProcNew = WndProcHookedWindow;
				spProcHooked->m_wndProcOld = reinterpret_cast<WNDPROC>(SetWindowLongPtr(hWndSibling, GWLP_WNDPROC, reinterpret_cast<LONG_PTR>(spProcHooked->m_wndProcNew)));
				spProcHooked->m_pwndAdjacentWindow->RecalcPreviewPaneLayout();
				s_rgHookedWindows.push_back(spProcHooked);
				fResult = true;
			}
		}
		else
		{
			// If the window already exists (i.e. re-using a mail inspector that was previously closed), then
			// refresh the inspector/explorer pointer
			if ((*iterHooked)->m_pwndAdjacentWindow->FHidden())
			{
				(*iterHooked)->m_pwndAdjacentWindow->Initialize(spInsp, spExp, hWndTopLevelWindow, hWndSibling);
				(*iterHooked)->m_pwndAdjacentWindow->SetHidden(false);
			}
		}
	}

	return fResult;
}

// Find the place to put the adjacent window in Outlook 2003/2007
int FindExplorerWindowsLegacyOutlook(HWND hWndOutlook, bool *pfFoundViewAndPrevPane)
{
	int nWindowsFound = 0;
	HWND hWndViewAndPrevPane = NULL;
	HWND hWndChildAfter2 = NULL;

	while (0 != (hWndViewAndPrevPane = FindWindowEx(hWndOutlook, hWndChildAfter2, g_tzWndClassRen, NULL)))
	{
		hWndChildAfter2 = hWndViewAndPrevPane;
		HWND hWndPrevPaneTop = NULL;
		HWND hWndChildAfter3 = NULL;
		bool fFoundPrevPane = false;

		*pfFoundViewAndPrevPane = true; // We've found the View/Preview pane container, which means this is an explorer

		window_list_t::iterator iterUnhooked;

		iterUnhooked = find(s_rgUnhookedWindows.begin(), s_rgUnhookedWindows.end(), hWndViewAndPrevPane);

		while (0 != (hWndPrevPaneTop = FindWindowEx(hWndViewAndPrevPane, hWndChildAfter3, g_tzWndClassRen, NULL)))
		{
			window_list_t::iterator iterHooked;

			hWndChildAfter3 = hWndPrevPaneTop;

			if (g_verOLMajor == 11)
			{
				// Make sure this isn't the find pane
				if (!FindWindowEx(hWndPrevPaneTop, NULL, g_tzAfxWndW, NULL))
					continue;
			}

			fFoundPrevPane = true;

			// If we're in the list of "unhooked" windows - the ones that we found the view and preview pane
			// container, but not the preview pane, we need to clean up, since we have now found the preview pane.
			if (iterUnhooked != s_rgUnhookedWindows.end())
			{
				s_rgUnhookedWindows.erase(iterUnhooked);
			}

			iterHooked = find(s_rgHookedWindows.begin(), s_rgHookedWindows.end(), hWndPrevPaneTop);
			if (iterHooked == s_rgHookedWindows.end())
			{
				if (FCreateHookedAdjacentWindow(hWndPrevPaneTop, hWndViewAndPrevPane, hWndOutlook))
					nWindowsFound++;
			}
			break;
		}

		// We didn't find the preview pane, but we still found the view and preview pane container.
		// Hook into this window's handler so we get notified if/when the preview pane is created.
		if (!fFoundPrevPane)
		{
			if (iterUnhooked == s_rgUnhookedWindows.end())
			{
				WndProcInfoPtr spHook(new WndProcInfo);

				spHook->m_hWnd       = hWndViewAndPrevPane;
				spHook->m_wndProcNew = WndProcUnhookedWindow;
				spHook->m_wndProcOld = reinterpret_cast<WNDPROC>(SetWindowLongPtr(hWndViewAndPrevPane, GWLP_WNDPROC, reinterpret_cast<LONG_PTR>(spHook->m_wndProcNew)));
				s_rgUnhookedWindows.push_back(spHook);
				nWindowsFound++;
			}
		}
		break;
	}
	assert(nWindowsFound == 0 || nWindowsFound == 1);
	return nWindowsFound;
}

// Find the place to put the adjacent window in Outlook 14 and above
int FindExplorerWindows(HWND hWndOutlook, bool *pfFoundViewAndPrevPane)
{
	int nWindowsFound = 0;

	if (FindWindowEx(hWndOutlook, NULL, g_tzAfxWndW, g_tzFolderBar))
	{
		HWND hWndPrevPaneTop = NULL;
		HWND hWndChildAfter3 = NULL;
		bool fFoundPrevPane = false;

		*pfFoundViewAndPrevPane = true; // We've found the FolderBar, which means this is an explorer

		window_list_t::iterator iterUnhooked;

		iterUnhooked = find(s_rgUnhookedWindows.begin(), s_rgUnhookedWindows.end(), hWndOutlook);

		while (0 != (hWndPrevPaneTop = FindWindowEx(hWndOutlook, hWndChildAfter3, g_tzWndClassRen, NULL)))
		{
			hWndChildAfter3 = hWndPrevPaneTop;
			HWND hWndPrevPaneAfxWnd = NULL;
			if (0 != (hWndPrevPaneAfxWnd = FindWindowEx(hWndPrevPaneTop, NULL, g_tzAfxWndW, NULL)))
			{
				window_list_t::iterator iterHooked;

				fFoundPrevPane = true;

				// If we're in the list of "unhooked" windows - the ones that we found the view and preview pane
				// container, but not the preview pane, we need to clean up, since we have now found the preview pane.
				if (iterUnhooked != s_rgUnhookedWindows.end())
				{
					s_rgUnhookedWindows.erase(iterUnhooked);
				}

				iterHooked = find(s_rgHookedWindows.begin(), s_rgHookedWindows.end(), hWndPrevPaneAfxWnd);
				if (iterHooked == s_rgHookedWindows.end())
				{
					if (FCreateHookedAdjacentWindow(hWndPrevPaneAfxWnd, hWndPrevPaneTop, hWndOutlook))
						nWindowsFound++;
				}
				break;
			}
		}

		// We didn't find the preview pane, but we still found the view and preview pane container.
		// Hook into this window's handler so we get notified if/when the preview pane is created.
		if (!fFoundPrevPane)
		{
			if (iterUnhooked == s_rgUnhookedWindows.end())
			{
				WndProcInfoPtr spHook(new WndProcInfo);

				spHook->m_hWnd       = hWndOutlook;
				spHook->m_wndProcNew = WndProcUnhookedWindow;
				spHook->m_wndProcOld = reinterpret_cast<WNDPROC>(SetWindowLongPtr(hWndOutlook, GWLP_WNDPROC, reinterpret_cast<LONG_PTR>(spHook->m_wndProcNew)));
				s_rgUnhookedWindows.push_back(spHook);
				nWindowsFound++;
			}
		}
	}
	assert(nWindowsFound == 0 || nWindowsFound == 1);
	return nWindowsFound;
}

int FindTopLevelWindows()
{
	int nWindowsFound = 0;

	HWND hWndOutlook = NULL;
	HWND hWndChildAfter1 = NULL;

	if (!s_spExplorers || !s_spInspectors)
		return 0;

	while (0 != (hWndOutlook = FindWindowEx(NULL, hWndChildAfter1, g_tzWndClassRen, NULL)))
	{
		hWndChildAfter1 = hWndOutlook;

		bool fFoundViewAndPrevPane = false;

		if (g_verOLMajor == 11 || g_verOLMajor == 12)
			nWindowsFound += FindExplorerWindowsLegacyOutlook(hWndOutlook, &fFoundViewAndPrevPane);
		else
			nWindowsFound += FindExplorerWindows(hWndOutlook, &fFoundViewAndPrevPane);

		// If we did not find a view/preview pane container, this may be an inspector.
		if (!fFoundViewAndPrevPane)
		{
			HWND hWndInspectorDialog;
			HWND hWndChildAfter2 = NULL;

			while (0 != (hWndInspectorDialog = FindWindowEx(hWndOutlook, hWndChildAfter2, g_tzAfxWndW, NULL)))
			{
				hWndChildAfter2 = hWndInspectorDialog;
				if (FCreateHookedAdjacentWindow(hWndInspectorDialog, hWndOutlook, hWndOutlook))
					nWindowsFound++;
				break;
			}
		}
	}

	return nWindowsFound;
}
