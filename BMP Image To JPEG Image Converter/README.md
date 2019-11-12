# BMP Image To JPEG Image Converter
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- Win32
## Topics
- Image manipulation
## Updated
- 09/27/2012
## Description

<h1>Introduction</h1>
<p><em>This Application can load any BMP image and Display it and also we can able to convert it into JPG image format.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>we just need a BMP iamge file to test the sample.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>It uses the GDI&#43; library to convert BMP to JPG image.</em><br>
Windows GDI&#43; is the portion of the Windows&nbsp;XP operating system or Windows Server&nbsp;2003 operating system that provides two-dimensional vector graphics, imaging, and typography. GDI&#43; improves on Windows Graphics Device Interface (GDI) (the graphics device
 interface included with earlier versions of Windows) by adding new features and by optimizing existing features.Windows GDI&#43; provides the<strong> Image
</strong><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms534462%28v=vs.85%29.aspx"><strong></strong></a>class for working with raster images (bitmaps) and vector images (metafiles). The<strong> Bitmap
</strong><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms534420%28v=vs.85%29.aspx"><strong></strong></a>class and the<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms534477%28v=vs.85%29.aspx"><strong></strong></a> meteafile
 class both inherit from the <strong>Image</strong> class. The <strong>Bitmap</strong> class expands on the capabilities of the
<strong>Image</strong> class by providing additional methods for loading, saving, and manipulating raster images. The
<strong>Metafile</strong> class expands on the capabilities of the <strong>Image</strong> class by providing additional methods for recording and examining vector images.</p>
<p><em>You can include <em><strong>code snippets,&nbsp;</strong></em><strong>images</strong>,
<strong>videos</strong>. &nbsp;&nbsp;</em></p>
<p>&nbsp;Graphics graphics(hWnd);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GdiplusStartupInput startupInput;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ULONG_PTR token;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GdiplusStartup(&amp;token, &amp;startupInput, NULL);<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; _mbstowcs_l((wchar_t *)szFile,(const char *)szFile1,sizeof(szFile1),locale);<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; Image image(szFile, false);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CLSID clsid;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; int ret = -1;<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; _mbstowcs_l((wchar_t *)szFile3,(const char *)szFile2,sizeof(szFile2),locale);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; if(-1 != GetEncoderClsid(L&quot;image/jpeg&quot;, &amp;clsid))<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; Status status=&nbsp; image.Save(szFile3,&amp;clsid,NULL);<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; if(!status)<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;MessageBox(NULL,L&quot;File Saved!&quot;, L&quot;Success&quot;, MB_OK|MB_ICONINFORMATION);<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp; &nbsp; } <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GdiplusShutdown(token);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return 1;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
