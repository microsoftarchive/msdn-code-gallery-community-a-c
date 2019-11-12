// Exclude the min and max macros from Windows.h
#define NOMINMAX
#include <Windows.h>
#include "WinMainParameters.h"
#include "resource.h"

using namespace WinMainParameters;

#define MAX_LOADSTRING 100

// Global Variables (are (usually) evil; this code comes from the Visual C++ Win32 Application project template):
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

// ISO C++ conformant entry point. The project properties explicitly sets this as the entry point in the manner
// documented for the linker's /ENTRY option: http://msdn.microsoft.com/en-us/library/f9t8842e.aspx . As per
// the documentation, the value set as the entry point is "mainCRTStartup", not "main". Every C or C++ program
// must perform any initialization required by the language standards before it begins executing our code. In
// Visual C++, this is done by the *CRTStartup functions, each of which goes on to call the developer's entry
// point function.
int main(int /*argc*/, char* /*argv*/[]) {

	// Use the functions from WinMainParameters.h to get the values that would've been passed to WinMain.
	// Note that these functions are in the WinMainParameters namespace.
	HINSTANCE hInstance = GetHInstance();
	HINSTANCE hPrevInstance = GetHPrevInstance();
	LPWSTR lpCmdLine = GetLPCmdLine();
	int nCmdShow = GetNCmdShow();

	// Assert that the values returned are expected.
	assert(hInstance != nullptr);
	assert(hPrevInstance == nullptr);
	assert(lpCmdLine != nullptr);

	// Close the console window. This is not required, but if you do not need the console then it should be
	// freed in order to release the resources it is using. If you wish to keep the console open and use it
	// you can remove the call to FreeConsole. If you want to create a new console later you can call
	// AllocConsole. If you want to use an existing console you can call AttachConsole.
	FreeConsole();

	// ***********************
	// If you want to avoid creating a console in the first place, you can change the linker /SUBSYSTEM
	// option in the project properties to WINDOWS as documented here:
	// http://msdn.microsoft.com/en-us/library/fcc1zstk.aspx . If you do that you should comment out the
	// above call to FreeConsole since there will not be any console to free. The program will still
	// function properly. If you want the console back, change the /SUBSYSTEM option back to CONSOLE.
	// ***********************

	// Note: The remainder of the code in this file comes from the default Visual C++ Win32 Application
	// template (with a few minor alterations). It serves as an example that the program works, not as an
	// example of good, modern C++ code style.

	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_LAUNCHWIN32WINDOWFROMCONSOLE, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance(hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_LAUNCHWIN32WINDOWFROMCONSOLE));

	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int)msg.wParam;
}

//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_LAUNCHWIN32WINDOWFROMCONSOLE));
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCE(IDC_LAUNCHWIN32WINDOWFROMCONSOLE);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = NULL;

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	HWND hWnd;

	hInst = hInstance; // Store instance handle in our global variable

	hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

	if (!hWnd)
	{
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	switch (message)
	{
	case WM_COMMAND:
		wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		{
			RECT clientRect;
			GetClientRect(hWnd, &clientRect);
			// HGDIOBJ objects obtained from GetStockObject do not need to be deleted with DeleteObject as per the documentation: https://msdn.microsoft.com/en-us/library/dd144925(v=vs.85).aspx
			HGDIOBJ whiteBrushGDIObj = GetStockObject(WHITE_BRUSH);
			if (whiteBrushGDIObj == nullptr || GetObjectType(whiteBrushGDIObj) != OBJ_BRUSH) {
				PostQuitMessage(1);
			}
			else {
				HBRUSH whiteBrush = static_cast<HBRUSH>(whiteBrushGDIObj);
				FillRect(hdc, &clientRect, whiteBrush);
				COLORREF blackTextColor = 0x00000000;
				if (SetTextColor(hdc, blackTextColor) == CLR_INVALID) {
					PostQuitMessage(1);
				}
				else {
					const wchar_t helloWorldString[] = L"Hello world!";
					DrawTextW(hdc, helloWorldString, ARRAYSIZE(helloWorldString), &clientRect, DT_CENTER | DT_VCENTER | DT_SINGLELINE | DT_NOCLIP);
				}
			}
		}
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
