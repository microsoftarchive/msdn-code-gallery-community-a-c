//////////////////////////////////////////////////////////////////////////
//
// FILE: test.cpp
//
// Defines the entry point for the console *test* application for
// UTF-8 conversion functions.
//
// By Giovanni Dicanio <gdicanio@mvps.org>
//
//////////////////////////////////////////////////////////////////////////


#include "stdafx.h"         // precompiled headers
#include <iostream>         // console output
#include "utf8conv.h"       // UTF-8 conversion helpers


using namespace std;
using namespace utf8util;



//------------------------------------------------------------------------
// Some tests for UTF-8 <-> UTF-16 conversion.
//------------------------------------------------------------------------
void Test()
{
    //
    // Test a simple UTF-16 <-> UTF-8 conversion
    //
    
    // Source UTF-16 string
    wstring utf16(L"Euro sign (U+20AC): \x20AC");
    
    // Convert from UTF-16 to UTF-8
    string utf8 = UTF8FromUTF16(utf16);
    
    // Convert back from UTF-8 to UTF-16
    wstring utf16New = UTF16FromUTF8(utf8);
    
    // Check conversion result
    if (utf16New != utf16)
        throw runtime_error("UTF-16 <-> UTF-8 conversion failed.");

    cout << "Conversion test with STL strings passed." << endl;



    //
    // Test a simple UTF-16 <-> UTF-8 conversion with raw C strings
    //
    
    // Convert from UTF-16 to UTF-8 - force raw C string with c_str()
    utf8 = UTF8FromUTF16(utf16.c_str());

    // Convert back from UTF-8 to UTF-16 - force raw C string with c_str()
    utf16New = UTF16FromUTF8(utf8.c_str());

    // Check conversion result
    if (utf16New != utf16)
        throw runtime_error("UTF-16 <-> UTF-8 with raw C strings failed.");

    cout << "Conversion test with raw C strings passed." << endl;



    //
    // Test with empty strings
    //

    string empty;
    wstring wempty;
    if (! UTF16FromUTF8(empty).empty())
        throw runtime_error("Empty UTF-8 string not converted to empty UTF-16 string.");

    if (! UTF8FromUTF16(wempty).empty())
        throw runtime_error("Empty UTF-16 string not converted to empty UTF-8 string.");

    cout << "Conversion test with empty strings passed." << endl;



    //
    // Test with empty raw C strings
    //

    if (! UTF16FromUTF8("").empty())
        throw runtime_error("Empty UTF-8 raw C string not converted to empty UTF-16 string.");

    if (! UTF8FromUTF16(L"").empty())
        throw runtime_error("Empty UTF-16 raw C string not converted to empty UTF-8 string.");

    cout << "Conversion test with empty raw C strings passed." << endl;



    //
    // Test with NULL pointers
    //

    if (! UTF16FromUTF8(NULL).empty())
        throw runtime_error("NULL UTF-8 string not converted to empty UTF-16 string.");

    if (! UTF8FromUTF16(NULL).empty())
        throw runtime_error("NULL UTF-16 string not converted to empty UTF-8 string.");

    cout << "Conversion test with NULL pointers passed." << endl;



    //
    // Test with invalid UTF-8 bytes
    //

    try
    {
        // 0xC0 0xAF UTF-8 sequence is discussed in "Writing Secure Code" 
        // (Chapter 11, "How UTF-8 Encodes Data", page 380)
        char utf8Invalid[] = "UTF-8 invalid sequence: \xC0\xAF";
        wstring utf16Invalid = UTF16FromUTF8(utf8Invalid);
    }
    catch (const utf8_conversion_error & e)
    {
        if (e.error_code() == ERROR_NO_UNICODE_TRANSLATION)
        {
            cout << "Invalid UTF-8 sequence was correctly detected." << endl;
        }
    }

}



//------------------------------------------------------------------------
// Entry-point for the console app.
//------------------------------------------------------------------------
int main(int argc, char* argv[])
{
    static const int kOk = 0;
    static const int kFail = 1;
    int exit_code = kOk;

    try
    {
        cout << "*** Testing UTF-8 <-> UTF-16 Conversion ***" << endl;
        cout << "    by Giovanni Dicanio <gdicanio@mvps.org>" << endl << endl;
        Test();
        cout << endl;
        cout << "All right." << endl;
    }
    catch(const utf8_conversion_error & e)
    {
        cerr << "*** UTF-8 Conversion Error:" << endl;
        cerr << e.what() << endl;

        if (e.conversion() == utf8_conversion_error::conversion_utf16_from_utf8)
        {
            cerr << "Was attempting conversion from UTF-8 to UTF-16." << endl;
        }
        else
        {
            cerr << "Was attempting conversion from UTF-16 to UTF-8." << endl;
        }
        
        cerr << "Error code: " << e.error_code() << endl;
        
        cerr << endl;
        exit_code = kFail;
    }
    catch(const exception & e)
    {
        cerr << "*** ERROR: " << e.what() << endl;
        exit_code = kFail;
    }

    return exit_code;
}


//////////////////////////////////////////////////////////////////////////

