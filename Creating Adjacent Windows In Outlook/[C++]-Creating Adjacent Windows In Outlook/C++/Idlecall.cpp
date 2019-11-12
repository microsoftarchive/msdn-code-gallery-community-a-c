/*!-----------------------------------------------------------------------
	Idlecall.cpp

	Implementation for running code on idle
-----------------------------------------------------------------------!*/
#include "stdafx.h"

#include "AdjacentWindowHelper.h"
#include "idlecall.h"
#include "ids.h"

HWND g_hWndHidden = NULL;

// This function handles calling functions during idle time
LRESULT CALLBACK WndProcHidden(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	switch (uMsg)
	{		
		case WM_TIMER:
		{
			int taskID = static_cast<int>(wParam);

			switch (taskID)
			{
				case idleFindTopLevelWindows:
					FindTopLevelWindows();
					break;
			}
			RemoveIdle(taskID);
		}
	}

	return DefWindowProc(hWnd, uMsg, wParam, lParam);
}

void InitializeIdle()
{
	WNDCLASS wc;

	// Create hidden window to receive WM_TIMER messages
	memset(&wc, 0, sizeof(WNDCLASS));
	wc.lpfnWndProc = WndProcHidden;
	wc.hInstance = AfxGetInstanceHandle();
	wc.lpszClassName = ADDIN_HIDDENWNDCLASS;
	
	RegisterClass(&wc);

	g_hWndHidden = ::CreateWindowEx(WS_EX_TOOLWINDOW,
									ADDIN_HIDDENWNDCLASS,
									ADDIN_HIDDENWNDCLASS,
									0,
									0, 0,
									0, 0,
									0, NULL,
									wc.hInstance, NULL);
}


void UninitializeIdle()
{
	DestroyWindow(g_hWndHidden);
	g_hWndHidden = NULL;
}

void CallIdle(IdleTaskId iIdleCall, UINT uElapsed)
{
	SetTimer(g_hWndHidden, iIdleCall, uElapsed, NULL);
}

void RemoveIdle(int iIdleCall)
{
	KillTimer(g_hWndHidden, iIdleCall);
}
