#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
   // TODO: Update with your LEADTOOLS license information.
   swprintf_s(ltsupport::szLicPath, (L_MAXPATH) / (sizeof ltsupport::szLicPath[0]), _T("D:\\GitHub\\LEADTOOLS\\eval-license-files.lic"));
   swprintf_s(ltsupport::szDevKey, (L_MAXPATH) / (sizeof ltsupport::szDevKey[0]), _T("{YourDeveloperKey}"));
  
   // TODO: Also, update the paths to these files
   L_TCHAR const szSourceDocument[] = _T("D:\\GitHub\\LEADTOOLS\\press-release.doc");
   L_TCHAR const szTargetDocument[] = _T("D:\\GitHub\\LEADTOOLS\\press-release.pdf");
   L_TCHAR const szSourceVector[] = _T("D:\\GitHub\\LEADTOOLS\\random.dxf");
   L_TCHAR const szTargetVector[] = _T("D:\\GitHub\\LEADTOOLS\\random.pdf");

   if (convert2pdf::ExportFileToPdfViaSvg(szSourceDocument, szTargetDocument))
      std::cout << "Document to PDF: Done" << std::endl;
   else
      std::cout << "Document to PDF: ERROR" << std::endl;

   if (convert2pdf::ExportFileToPdfViaSvg(szSourceVector, szTargetVector))
      std::cout << "Vector to PDF: Done" << std::endl;
   else
      std::cout << "Vector to PDF: ERROR" << std::endl;

   int i;
   std::cin >> i;
   return 0;
}
