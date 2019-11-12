// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#include <stdio.h>
#include <tchar.h>



// TODO: reference additional headers your program requires here
#include <iostream>

#define LTV19_CONFIG
#include "C:\LEADTOOLS 19\Include\l_bitmap.h"
#include "C:\LEADTOOLS 19\Include\ltsvg.h"
#include "C:\LEADTOOLS 19\Include\ltdocwrt.h"


#if defined(WIN64)
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\x64\\Ltkrn_x.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\x64\\Ltfil_x.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\x64\\Ltsvg_x.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\x64\\Ltdrw_x.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\x64\\Lvkrn_x.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\x64\\ltdocwrt_x.lib")
#else
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\Win32\\Ltkrn_u.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\Win32\\Ltfil_u.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\Win32\\Ltsvg_u.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\Win32\\Ltdrw_u.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\Win32\\Lvkrn_u.lib")
#pragma comment(lib, "C:\\LEADTOOLS 19\\Lib\\CDLLVC12\\Win32\\ltdocwrt_u.lib")
#endif // #if defined(WIN64)


#include "convert2pdf.h"
#include "ltsupport.h"