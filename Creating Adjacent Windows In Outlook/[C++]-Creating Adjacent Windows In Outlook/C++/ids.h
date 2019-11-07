/*!-----------------------------------------------------------------------
	ids.h

	Contains all the progids/guids/clsids/strings used across the addin. If an
	id is needed to be updated then it should only need to be changed
	here and nowhere else.

	Remember these ids need to be unique on each system so they should be
	changed if this sample addin is used as a base for a another addin.

-----------------------------------------------------------------------!*/
#pragma once

// Strings
#define ADDIN_PROGID            OLESTR("AdjacentWindowCOMAddin.Connect")
#define ADDIN_HIDDENWNDCLASS    _T("AdjacentWindowSampleHiddenWindow")
#define ADDIN_WNDCLASS          _T("AdjacentWindowSampleWindow")
#define ADDIN_WINDOWTITLE       _T("AdjacentWindowSample")

// GUIDs
#define TYPELIB_GUID            5029A5EB-68CA-4D93-AA80-5291CFC9F2AE
#define ADDIN_CLSID             362E635A-4AC0-4003-B45E-01ED1BDC30F6

// Remember to keep these string version in sync with the ones above
#define TYPELIB_GUID_STR        OLESTR("5029A5EB-68CA-4D93-AA80-5291CFC9F2AE")
#define ADDIN_CLSID_STR         OLESTR("362E635A-4AC0-4003-B45E-01ED1BDC30F6")

