#include "stdafx.h"

namespace convert2pdf
{
   // Uses the Document Writer function to create the PDF from the SVG object in memory
   void CreatePdf(const L_TCHAR* targetFile, L_SvgNodeHandle hSvgDocument)
   {
      L_INT nRet;
      DOCUMENTWRITER_HANDLE hDocWriter = NULL;

      // PDF options, if you want to.
      // DOCWRTPDFOPTIONS pdfOptions;

      nRet = L_DocWriterInit(&hDocWriter, (L_TCHAR*)targetFile, DOCUMENTFORMAT_PDF, NULL, NULL, NULL);
      if (!ltsupport::DisplayError(nRet, _T("L_DocWriterInit")))
      {
         DOCWRTSVGPAGE svgPage = { 0 };
         svgPage.hSvgHandle = hSvgDocument;

         nRet = L_DocWriterAddPage(hDocWriter, DOCWRTPAGETYPE_SVG, (L_VOID*)&svgPage);
         ltsupport::DisplayError(nRet, _T("L_DocWriterAddPage"));

         nRet = L_DocWriterFinish(hDocWriter);
         ltsupport::DisplayError(nRet, _T("L_DocWriterFinish"));
      }
   }

   BOOL LoadFileAsSvg(const L_TCHAR* sourceFile, L_UCHAR** buffer, L_UINT* bufferSize)
   {
      L_INT nRet = ERROR_FILE_FORMAT;
      L_BOOL canLoad = FALSE;
      nRet = L_CanLoadSvg((L_TCHAR*)sourceFile, &canLoad, NULL);
      if (canLoad)
      {
         // Setup the doc options to improve the quality to print level dpi
         RASTERIZEDOCOPTIONS docOptions = { 0 };
         L_GetRasterizeDocOptions(&docOptions, sizeof(RASTERIZEDOCOPTIONS));
         docOptions.uXResolution = 300;
         docOptions.uYResolution = 300;
         L_SetRasterizeDocOptions(&docOptions);

         LOADSVGOPTIONS svgOptions = { 0 };
         svgOptions.uStructSize = sizeof(LOADSVGOPTIONS);

         nRet = L_LoadSvg((L_TCHAR*)sourceFile, &svgOptions, NULL);
         if (ltsupport::DisplayError(nRet, _T("L_LoadSvg")))
            return FALSE;

         nRet = L_SvgSaveDocumentMemory(svgOptions.SvgHandle, buffer, bufferSize, NULL);
         ltsupport::DisplayError(nRet, _T("L_SvgSaveDocumentMemory"));

         // Free the source SVG document
         nRet = L_SvgFreeNode(svgOptions.SvgHandle);
         ltsupport::DisplayError(nRet, _T("L_SvgFreeNode"));
         svgOptions.SvgHandle = NULL;

         return TRUE;
      }
      else { return FALSE; }

   }


   /// Converts the SVG file in memory to a PDF file on disk
   void SaveAsPdf(const L_TCHAR* targetFile, const L_UCHAR* svgBuffer, L_UINT bufferSize)
   {
      L_INT nRet;
      L_SvgNodeHandle hSvgDocument;
      nRet = L_SvgLoadDocumentMemory(svgBuffer, bufferSize, &hSvgDocument, NULL);
      if (!ltsupport::DisplayError(nRet, _T("L_SvgLoadDocumentMemory")))
      {
         // Check if we need to flat it
         L_BOOL isFlat = FALSE;
         L_SvgIsFlatDocument(hSvgDocument, &isFlat);
         if (!isFlat)
         {
            L_SvgNodeHandle hFlatDocHandle = NULL;
            L_SvgFlatDocument(hSvgDocument, &hFlatDocHandle, NULL);
            L_SvgFreeNode(hSvgDocument);
            hSvgDocument = hFlatDocHandle;
         }
         L_SvgBounds bounds = { 0 };
         L_SvgGetBounds(hSvgDocument, &bounds, sizeof(L_SvgBounds));
         if (!bounds.IsValid)
            L_SvgCalculateBounds(hSvgDocument, FALSE);

         // Create the PDF from the SVG object in memory
         CreatePdf(targetFile, hSvgDocument);

         // Free memory
         L_SvgFreeNode(hSvgDocument);
         hSvgDocument = NULL;
      }
   }


   BOOL ExportFileToPdfViaSvg(const L_TCHAR* sourceFile, const L_TCHAR* targetFile)
   {
      BOOL bSuccess = FALSE;
      L_UCHAR* buffer = NULL;
      L_UINT ubufferSize = 0;

      // Set License so that we can use LEADTOOLS API functions
      if (ltsupport::SetLicense(ltsupport::szLicPath, ltsupport::szDevKey))
      {
         // Load the file into memory as SVG
         bSuccess = LoadFileAsSvg(sourceFile, &buffer, &ubufferSize);
         if (bSuccess)
         {
            SaveAsPdf(targetFile, buffer, ubufferSize);
         }
      }
      return bSuccess;
   }

}