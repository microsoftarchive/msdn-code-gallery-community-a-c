// BMP to JPG.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "BMP to JPG.h"
#include <Commdlg.h>
#include <Windows.h>
#include <olectl.h>
#include <Shlwapi.h>
#include <WinBase.h>
#include <stdio.h>
#include <Gdiplus.h>
#include<math.h>
#pragma comment(lib, "gdiplus.lib")
#define MAX_LOADSTRING 100
#define TITLEBARSZ 42



using namespace Gdiplus;


// Global Variables:

HINSTANCE        hInst;								   // current instance
TCHAR            szTitle[MAX_LOADSTRING];			   // The title bar text
TCHAR            szWindowClass[MAX_LOADSTRING];	       // Main window class name
OPENFILENAMEA     ofn1,ofn2;
RECT             rClt1,rClt2;
BITMAP           bm;
HBITMAP          hBitmap=NULL,memBM;
HDC              hCompDc=NULL,hDc=NULL,hMemDC = NULL,hDc2=NULL,hMemDc =NULL;
BOOL             Sreturn=0;
int              Draw(HWND);
char                szFile1[200];
char                szFile2[200];
wchar_t             szFile[200],szFile3[200];
_locale_t           locale;
size_t              count ;
int              Fileflag=0;
double           Xoffset,Yoffset,X1,X2,Y1,Y2,Zx,Zy,X,Y,Height=0,Width=0;

// Forward declarations of functions included in this code module:

ATOM			    MyRegisterClass(HINSTANCE hInstance);
BOOL			    InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	Browse(HWND, UINT, WPARAM, LPARAM);
INT                 GetEncoderClsid(const WCHAR* format, CLSID* pClsid);
int                 Display(HWND);
int                 Browsefile(HWND);
int                 Savefile(HWND);
int                 Saveimagejpg(HWND);




int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_BMPTOJPG, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_BMPTOJPG));

	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_BMPTOJPG));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_BMPTOJPG);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

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
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		           
		      case ID_FILE_OPENBMPIMAGE:
			                  Browsefile(hWnd);
							   if(!GetOpenFileNameA(&ofn1))
							   {
							   MessageBox(NULL, L"GetsaveFileName Failed", L"Error", MB_OK);
							   return 0;
							   }
							   Fileflag=0;
							   Display(hWnd);
			  break;

			  case ID_FILE_SAVEASJPEG:

						   if(Fileflag==1)
						   {
					          Savefile(hWnd);
							  if(!GetSaveFileNameA(&ofn2))
							   {
							   MessageBox(NULL, L"GetsaveFileName Failed", L"Error", MB_OK);
							   return 0;
							   }
							  Saveimagejpg(hWnd);
						   }
						   else
							    MessageBox(NULL, L"Open Any BMP image First", L"Message", MB_OK);
			  break;
			
		   
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
		if(Fileflag==1)
		Display(hWnd);
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
int Browsefile(HWND hwnd)

  {
           ZeroMemory(&ofn1, sizeof(ofn1));
           ofn1.lStructSize = sizeof(ofn1);
           ofn1.hwndOwner = hwnd;
		   ofn1.lpstrFile = szFile1;
		   ofn1.lpstrFile[0] = '\0';
           ofn1.nMaxFile = sizeof(szFile1);
		   ofn1.lpstrFilter = "All Files\0*.*\0Bitmap(.bmp)\0*.bmp\0";
           ofn1.nFilterIndex = 1;
           ofn1.lpstrFileTitle = NULL;
           ofn1.nMaxFileTitle = 0;
           ofn1.lpstrInitialDir = NULL;
           ofn1.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
		   return 1;
			  
}
int Savefile(HWND hwnd)

  {
           ZeroMemory(&ofn2, sizeof(ofn2));
           ofn2.lStructSize = sizeof(ofn2);
           ofn2.hwndOwner = hwnd;
		   ofn2.lpstrFile = szFile2;
		   ofn2.lpstrFile[0] = '\0';
           ofn2.nMaxFile = sizeof(szFile2);
		   ofn2.lpstrFilter = "All File\0*.*\0JPEG(.jpg)\0*.jpg\0";
                             
		   ofn2.nFilterIndex = 2;
           ofn2.lpstrFileTitle = NULL;
           ofn2.nMaxFileTitle = 0;
           ofn2.lpstrInitialDir = NULL;
           ofn2.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
		   ofn2.lpstrDefExt = (LPCSTR)L"bmp";
		   return 1;
			  
}

int Display(HWND hDlg)
{
 int R;
    HGDIOBJ hold1,hold2;


    GdiplusStartupInput startupInput;
    ULONG_PTR token;
    GdiplusStartup(&token, &startupInput, NULL);
	
	_mbstowcs_l((wchar_t *)szFile,(const char *)szFile1,sizeof(szFile1),locale);
	

    Image image((const WCHAR *)szFile, true);



    Bitmap* pBitmap = (Bitmap *)image.Clone();
    Status status = pBitmap->GetHBITMAP(Color(0,0,0), &hBitmap);

        

    hDc     = GetDC(hDlg);
    GetClientRect(hDlg, &rClt2);
    GetObject( hBitmap, sizeof(BITMAP), &bm);
		 


    hCompDc = CreateCompatibleDC(hDc);                                     //COMPATIBLE DC FOR ON SCREEN WINDOW
	hold1=SelectObject(hCompDc, hBitmap);                                  // SELECT BITMAP FOR DISPLAY
	
         
       
        
	hMemDc = CreateCompatibleDC(hDc);                                    //COMPATIBLE DC FOR OFF SCREEN BUFFER
	memBM= CreateCompatibleBitmap(hDc, rClt2.right,rClt2.bottom);        //MEMORY BITMAP TO AVOID FLICKERING
    hold2=SelectObject(hMemDc,memBM);    


  

  if((bm.bmWidth>940)||(bm.bmHeight>680))
         {
	
             Xoffset=(rClt2.right-940)/2;
             Yoffset=(rClt2.bottom-680)/2;
			 X=Xoffset;
			 Y=Yoffset;
			 Width=940;
             Height=680;


           }
	   else
            {
             Xoffset=(rClt2.right-bm.bmWidth)/2;
             Yoffset=(rClt2.bottom-bm.bmHeight)/2;
			 X=Xoffset;
			 Y=Yoffset;
             Width=bm.bmWidth;
             Height=bm.bmHeight;
             }
   
  
   R=BitBlt(hMemDc,0,0,rClt2.right,rClt2.bottom,hMemDc,0,0,WHITENESS);
		 if (!R)
           {
             MessageBox(NULL, L"BitBlt Failed", L"Error", MB_OK);
			 return 0;
            
           } 
    

       
        Sreturn= StretchBlt(hMemDc,Xoffset,Yoffset,Width,Height,hCompDc,
                         0,0,bm.bmWidth,bm.bmHeight, SRCCOPY); 
	
		R=BitBlt(hDc,0,0,rClt2.right,rClt2.bottom,hMemDc,0,0,SRCCOPY);
		 if (!R)
           {
             MessageBox(NULL, L"BitBlt Failed", L"Error", MB_OK);
			 return 0;
            
           } 
 if (!Sreturn)
           {
             MessageBox(NULL, L"StretchBlt Failed", L"Error", MB_OK);
             return FALSE;
           } 
  else
	       Fileflag=1;


	SelectObject(hMemDc, hold2);
    DeleteObject(memBM);
    DeleteDC    (hMemDc);
	SelectObject(hCompDc, hold1);
	
    return 1;
 
}         
int GetEncoderClsid(const WCHAR* format, CLSID* pClsid)
{


        UINT  num = 0;            // number of image encoders
        UINT  size = 0;           // size of the image encoder array in bytes

        ImageCodecInfo* pImageCodecInfo = NULL;

        GetImageEncodersSize(&num, &size);
        if(size == 0)
                return -1;  // Failure

        pImageCodecInfo = (ImageCodecInfo*)malloc(size);
        if(pImageCodecInfo == NULL)
                return -1;  // Failure

        GetImageEncoders(num, size, pImageCodecInfo);

        for(UINT j = 0; j < num; ++j)
        {
                if( wcscmp(pImageCodecInfo[j].MimeType, format) == 0 )
                {
                        *pClsid = pImageCodecInfo[j].Clsid;
                        free(pImageCodecInfo);
                        return j;                                         // Success
                }
        }
        free(pImageCodecInfo);
        return -1;
}
int Saveimagejpg(HWND hWnd)
  {


	    Graphics graphics(hWnd);
        GdiplusStartupInput startupInput;
        ULONG_PTR token;
        GdiplusStartup(&token, &startupInput, NULL);
	    {
		  _mbstowcs_l((wchar_t *)szFile,(const char *)szFile1,sizeof(szFile1),locale);
		  Image image(szFile, false);
          CLSID clsid;
          int ret = -1;
		 
		  _mbstowcs_l((wchar_t *)szFile3,(const char *)szFile2,sizeof(szFile2),locale);

        
		  if(-1 != GetEncoderClsid(L"image/jpeg", &clsid))
		   {
		  Status status=  image.Save(szFile3,&clsid,NULL);
		  if(!status)
			 MessageBox(NULL,L"File Saved!", L"Success", MB_OK|MB_ICONINFORMATION);
		
		   }
			  
		
	  } 

        GdiplusShutdown(token);
        return 1;

	
  }