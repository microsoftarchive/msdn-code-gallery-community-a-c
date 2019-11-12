# Basic DXUT Win32 Samples
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Win32
- DirectX
- DirectX SDK
## Topics
- Graphics and 3D
## Updated
- 10/12/2015
## Description

<p>The latest version of this sample is hosted on <a href="https://github.com/walbourn/directx-sdk-samples">
GitHub</a>.</p>
<p>This is the DirectX SDK's Direct3D 11 BasicHLSL11, EmptyProject11, and SimpleSample11 samples updated to use Visual Studio 2012 and the Windows SDK 8.0 without any dependencies on legacy DirectX SDK content. These are samples Win32 desktop DirectX 11.0 applications
 for Windows 8, Windows 7, and Windows Vista Service Pack 2 with the DirectX 11.0 runtime.&nbsp;</p>
<p><strong>This is based on the the legacy DirectX SDK (June 2010) Win32 desktop samples running on Windows Vista, Windows 7, and Windows 8. This is not intended for use with Windows Store apps or Windows RT.</strong></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>These samples are&nbsp;basic samples using the&nbsp;<a href="http://go.microsoft.com/fwlink/?LinkId=320437">DXUT for Direct3D 11</a>&nbsp;framework for Win32 desktop applications.</p>
<h2>BasicHLSL11</h2>
<p><img id="96126" src="96126-basichlsl.jpg" alt="" width="90" height="71"></p>
<p>This sample loads a mesh, create vertex and pixel shaders from files, and then uses the shaders to render the mesh.</p>
<h3>How the sample works</h3>
<p>First the sample checks for the currently supported feature level and compiles and creates vertex and pixel shaders from a file.</p>
<p>Next, the sample creates an input layout that matches the input layout of the mesh that will be loaded. This will be the same for all meshes loaded through CDXUTSDKMesh.</p>
<p>Next, the sample loads the geometry using the CDXUTSDKMesh class.</p>
<p>In OnD3D11FrameRender, the sample updates dynamic state contained in constant buffers such as the World*View*Projection matrix, then sets both static and dynamic state such as the current input layout and samplers to be used for rendering using the immediate
 context. The mesh is rendered using DrawIndexed calls called in a loop over the mesh subsets.</p>
<h2>EmptyProject11</h2>
<p><img id="96127" src="96127-emptyproject11.jpg" alt="" width="90" height="74"></p>
<p>This sample is a bare-bones DXUT application provided as a convenient starting point for your own Win32 desktop Direct3D 11 application. This is the minimum needed to get a DXUT-based application running, but it does nothing but clear the screen to a background
 color.</p>
<h2>SimpleSample11</h2>
<p><img id="96128" src="96128-simplesample.jpg" alt="" width="90" height="74"></p>
<p>This sample can be used as a starting point for your own Win32 desktiop Direct3D 11 application. This builds on EmptyProject11 by adding a simple status HUD, common controls, and access to the device settings dialog.&nbsp;</p>
<h1>Dependancies</h1>
<p>DXUT-based samples typically make use of runtime HLSL compilation. Build-time compilation is recommended for all production Direct3D applications, but for experimentation and samples development runtime HLSL compiliation is preferred. Therefore, the D3DCompile*.DLL
 must be available in the search path when these programs are executed.</p>
<ul>
<li>When using the Windows 8.x SDK and targeting Windows Vista or later, you can include the D3DCompile_46 or D3DCompile_47 DLL side-by-side with your application copying the file from the REDIST folder.
</li></ul>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.0\Redist\D3D\arm, x86 or x64</pre>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.1\Redist\D3D\arm, x86 or x64</pre>
<h1>Building with Visual Studio 2010</h1>
<p>The code in these samples can be built using Visual Studio 2010 rather than Visual Studio 2012. The changes required are:</p>
<ul>
<li>Change the Platform Toolset to &quot;v100&quot; </li><li>Obtain the <a href="http://msdn.microsoft.com/en-us/windows/hardware/hh852363">
Windows SDK 8.0</a> </li><li>Use the <a href="http://blogs.msdn.com/b/vcblog/archive/2012/11/23/using-the-windows-8-sdk-with-visual-studio-2010-configuring-multiple-projects.aspx">
instructions </a>for adding the Windows 8.0 SDK headers for VS 2010 projects </li></ul>
<h1>Building with Visual Studio 2013</h1>
<p>This sample can be modified to build with Visual Studio 2013 using the Windows 8.1 SDK. Set the Platform Toolset to &quot;v120&quot; for all configurations, and obtain the latest DXUT package. Remove the &quot;DXUT_2012.vcxproj&quot; &amp; &quot;DXUTOpt_2012.vcxproj&quot; references,
 add the projects &quot;DXUT_2013.vcxproj&quot; &amp; &quot;DXUTOpt_2013.vcxproj&quot;, and add new References to these projects.</p>
<p>You can also allow VS 2013 to upgrade the projects in place.</p>
<h1>Version History</h1>
<ul>
<li>July 28, 2014 - Updated for DXUT July 2014 release </li><li>September 16, 2013 - Initial release </li></ul>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a>&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/09/14/dxut-for-win32-desktop-update.aspx">DXUT for Win32 Desktop Update</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
<ul>
</ul>
