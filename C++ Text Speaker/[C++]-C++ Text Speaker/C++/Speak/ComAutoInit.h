#ifndef GDS_COMAUTOINIT_H_INCLUDED
#define GDS_COMAUTOINIT_H_INCLUDED


//////////////////////////////////////////////////////////////////////////
//
// FILE: ComAutoInit.h
//
// This header file defines a C++ RAII class to automatically 
// initialize and cleanup COM.
//
// By Giovanni Dicanio <gdicanio@mvps.org>
//
// 2010, December 28th
//
//////////////////////////////////////////////////////////////////////////



#include <ObjBase.h>        // COM initialization functions
#include <WinError.h>       // HRESULT, FAILED

#include <atldef.h>         // AtlThrow
#include <atltrace.h>       // ATLTRACE



namespace gds
{

    
//------------------------------------------------------------------------
// Class to *automatically* initialize and release COM.
// CoInitialize(Ex) is called in the constructor, and CoUninitialize is
// called in the destructor.
//------------------------------------------------------------------------
class CComAutoInit
{
public:

    // Initializes COM using CoInitialize.
    // On failure, signals error using AtlThrow.
    CComAutoInit()
    {
        HRESULT hr = ::CoInitialize(NULL);
        if (FAILED(hr))
        {
            ATLTRACE(TEXT("CoInitialize() failed in CComAutoInit constructor (hr=0x%08X).\n"), hr);
            AtlThrow(hr);
        }
    }


    // Initializes COM using CoInitializeEx.
    // On failure, signals error using AtlThrow.
    explicit CComAutoInit(__in DWORD dwCoInit)
    {
        HRESULT hr = ::CoInitializeEx(NULL, dwCoInit);
        if (FAILED(hr))
        {
            ATLTRACE(TEXT("CoInitializeEx() failed in CComAutoInit constructor (hr=0x%08X).\n"), hr);
            AtlThrow(hr);
        }
    }


    // Uninitializes COM using CoUninitialize.
    ~CComAutoInit()
    {
        ::CoUninitialize();
    }


    //
    // Ban copy
    //
private:
    CComAutoInit(const CComAutoInit &);
    CComAutoInit & operator=(const CComAutoInit &);
};


} // namespace gds


#endif // GDS_COMAUTOINIT_H_INCLUDED
