// AdjacentWindowHelper.h : Global declaration of Adjacent Window helpers (locating and placing the Window)
#pragma once

// HWND-injection messages (messages that we use to communicate with other 
// windows that inject a window into the preview pane of Outlook)
#define WM_NEGOTIATE_WINDOW_PANE    (WM_USER + 0x7FFE)
#define WM_REMOVING_WNDPROC         (WM_USER + 0x7FFD)

// List of operations for WM_NEGOTIATE_WINDOW_PANE
enum
{
	AddCustomWindowToTop = 1,
	ReplacePrevWindow,
	ReplaceNextWindow,
	GetReservedRect,
	PlaceWindowAdjacentToRect,
	RecalcPaneLayout,
	GetFullClientArea,
};

// Initialization function
void InitializeAdjacentWindows(_Explorers *pExplorers, _Inspectors *pInspectors);

// Find all Outlook windows that need to have an Adjacent Window added
int FindTopLevelWindows();
