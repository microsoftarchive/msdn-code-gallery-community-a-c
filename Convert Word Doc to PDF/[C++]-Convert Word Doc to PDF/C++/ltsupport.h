#include "stdafx.h"
namespace ltsupport
{
   L_TCHAR szLicPath[];
   L_TCHAR szDevKey[];

   BOOL SetLicense(L_TCHAR* pLicPath, L_TCHAR* pDevKey);
   BOOL DisplayError(L_INT nRet, L_TCHAR* pFun);
}