#include "stdafx.h"

namespace convert2pdf
{
   void CreatePdf(const L_TCHAR* targetFile, L_SvgNodeHandle hSvgDocument);
   BOOL LoadFileAsSvg(const L_TCHAR* sourceFile, L_UCHAR** buffer, L_UINT* bufferSize);
   void SaveAsPdf(const L_TCHAR* targetFile, const L_UCHAR* svgBuffer, L_UINT bufferSize);
   BOOL ExportFileToPdfViaSvg(const L_TCHAR* sourceFile, const L_TCHAR* targetFile);
}