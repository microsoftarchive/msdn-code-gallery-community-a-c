# C++ UTF-8 Conversion Helpers
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Win32
- C++
- Windows SDK
- STL
## Topics
- Unicode
## Updated
- 10/29/2011
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">There are several encodings for Unicode; UTF-16 is the one used by Windows API's. Another important encoding is UTF-8, which is widely used for text travelling across the Internet. Win32 Platform SDK offers a couple of API's
 to convert between these two encodings: <a title="MultiByteToWideChar() MSDN documentation" href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd319072(v=vs.85).aspx" target="_blank">
MultiByteToWideChar</a>,&nbsp;which can be used to convert from UTF-8 to UTF-16, and
<a title="WideCharToMultiByte() MSDN documentation" href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd374130(v=vs.85).aspx" target="_blank">
WideCharToMultiByte</a>,&nbsp;which can be used for the opposite conversion.</span></p>
<p><span style="font-size:small">However, using these raw APIs is not very convenient.
<a title="ATL Conversion Helpers" href="http://msdn.microsoft.com/en-us/library/87zae4a3(v=vs.80).aspx" target="_blank">
Helper classes</a> are already available for code using ATL. Instead, in this sample, C&#43;&#43; conversion functions using
<strong>pure Win32 SDK and STL</strong> are presented.&nbsp;</span></p>
<p><span style="font-size:x-small"><br>
</span></p>
<p><em>&nbsp;</em><span style="font-size:20px; font-weight:bold">Building the Sample</span></p>
<p><span style="font-size:small">This sample uses pure Win32 SDK and STL, so it can be built also from the Express Edition of Visual Studio.</span></p>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">This sample implements some Unicode conversion helper functions, which wrap the calls to MultiByteToWideChar and WideCharToMultiByte raw API's. Error checking, accomodating buffers for the conversions, etc. are all hidden inside
 the body of these helper functions. The user just passes STL strings as input, and gets converted STL strings back as output. Errors during conversion are signaled throwing an
<em>ad hoc</em> C&#43;&#43; exception class (with some details about the conversion and error code packed inside).</span></p>
<p><span style="font-size:small">All these helpers are embedded in a C&#43;&#43; namespace to make it easy to integrate this module in bigger projects.</span></p>
<p><span style="font-size:small">To convert a Unicode string from UTF-16 to UTF-8 (for example to send it over the Internet), a C&#43;&#43; code like this can be used:</span></p>
<p><em><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;Source&nbsp;UTF-16&nbsp;string</span>&nbsp;
wstring&nbsp;utf16;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;...</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Get&nbsp;Unicode&nbsp;UTF-8&nbsp;string&nbsp;from&nbsp;an&nbsp;UTF-16&nbsp;string</span>&nbsp;
<span class="cpp__datatype">string</span>&nbsp;utf8&nbsp;=&nbsp;UTF8FromUTF16(utf16);&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Can&nbsp;catch&nbsp;an&nbsp;utf8_conversion_error&nbsp;</span>&nbsp;
<span class="cpp__com">//&nbsp;C&#43;&#43;&nbsp;exception&nbsp;to&nbsp;detect&nbsp;errors&nbsp;</span>&nbsp;
<span class="cpp__com">//&nbsp;occurred&nbsp;during&nbsp;the&nbsp;conversion.</span></pre>
</div>
</div>
</div>
<p><span style="font-size:small">UTF-8 strings are stored in <em>std::string</em>; UTF-16 strings are stored in
<em>std::wstring</em>.</span></p>
<p><span style="font-size:small">There are also overloads of the conversion functions that take raw C strings as input (to avoid conversions from raw C strings to temporary STL strings).</span></p>
<p><span style="font-size:small">Conversion errors are signaled using the <strong>
<em>utf8_conversion_error</em></strong> C&#43;&#43; exception class, which is integrated in the C&#43;&#43; standard exception hierarchy (in particular, it derives from
<em>std::runtime_error</em>).</span></p>
<p><span style="font-size:x-small"><br>
</span></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span style="font-size:small"><em><strong>utf8conv.h</strong>&nbsp;</em>- this is the public header file of the conversion helper module.</span>
</li><li><span style="font-size:small"><em><em><strong>utf8conv_inl.h</strong>&nbsp;</em></em>- this file contains inline implementations of the conversion helper module functions and methods (it is included by the previous header).</span>
</li><li><span style="font-size:small"><em><em>test.cpp </em></em>- this file contains some tests (in console mode).</span>
</li></ul>
<h1>More Information</h1>
<p><span style="font-size:small">For more details, see&nbsp;<a title="Conversion between Unicode UTF-8 and UTF-16 with STL strings" href="http://msmvps.com/blogs/gdicanio/archive/2011/02/04/conversion-between-unicode-utf-8-and-utf-16-with-stl-strings.aspx" target="_blank">Conversion
 between Unicode UTF-8 and UTF-16 with STL strings</a> blog post.</span></p>
<p><em><br>
</em></p>
