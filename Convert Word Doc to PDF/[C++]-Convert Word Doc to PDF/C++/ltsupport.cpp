#include "stdafx.h"

namespace ltsupport
{
   L_TCHAR szLicPath[L_MAXPATH];
   L_TCHAR szDevKey[L_MAXPATH];

   // Set the LEADTOOLS license to enable functionality
   BOOL SetLicense(L_TCHAR* pLicPath, L_TCHAR* pDevKey)
   {
      // Set LEADTOOLS License 
      L_INT nRet = L_SetLicenseFile(pLicPath, pDevKey);
      if (!DisplayError(nRet, _T("L_SetLicenseFile")))
         return !L_KernelHasExpired();

      return FALSE;
   }

   // Display any errors occurring from the C interface
   BOOL DisplayError(L_INT nRet, L_TCHAR* pFun)
   {
      if (nRet != SUCCESS)
      {
         L_TCHAR buf[255];
         
#ifdef _UNICODE
         swprintf_s(buf, _T("Error %d at %s"), nRet, pFun);
         std::wcout << buf << std::endl;
#else
         sprintf(buf, _T("Error %d at %s"), nRet, pFun);
         std::cout << buf << std::endl;
#endif
         
         return TRUE;
      }
      return FALSE;
   }

}
