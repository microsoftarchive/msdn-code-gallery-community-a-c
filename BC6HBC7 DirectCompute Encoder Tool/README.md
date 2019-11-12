# BC6H/BC7 DirectCompute Encoder Tool
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
GitHub</a>, and this functionality is also available in <a href="http://go.microsoft.com/fwlink/?LinkId=248926">
DirectXTex</a>.</p>
<p>This sample implements BC6H/BC7 encoding using DirectCompute 4.0 acceleration. BC6H and BC7 are two new block-compressed texture formats introduced in Direct3D 11 that target much better visual quality than previous BC texture formats. On systems that have
 a graphics card with Compute Shader 4.0 support, this sample utilizes DirectCompute 4.0 to accelerate encoding.</p>
<p>Note that this sample utilizes DirectCompute 4.0 to accelerate BC6H/BC7 encoding, because DirectCompute 4.0 is available on most Direct3D 10 devices available today (proper driver update necessary), you can encode images to BC6H/BC7 format very fast on a
 system with such a D3D10&#43; card installed. However, to be able to sample from BC6H/BC7 textures directly in a shader, a Direct3D 11 display card is required. In other words, you can produce BC6H/BC7 textures fast on a D3D10 CS40 capable system using this sample
 utility, but your application still needs to run on a real D3D11 graphics card.</p>
<p>With the full source available, you can easily integrate this utility into your content creation pipeline to make your title benefit from these new BC formats.</p>
<p><em>Note that this functionailty has been integrated into the <a href="http://go.microsoft.com/fwlink/?LinkId=248926">
DirectXTex</a> library.</em></p>
<p>&nbsp;</p>
<p><img id="66010" src="66010-hdrtest.jpg" alt="" width="267" height="201"></p>
<h1>Command-line usage</h1>
<p><code>BC6HBC7EncoderCS.exe (options) (filter) Filename0 Filename1 Filename2...</code></p>
<ul>
<li><code>/bc6hs</code>: Encode to BC6H_SF16 and save the encoded texture. </li><li><code>/bc6hu</code>: Encode to BC6H_UF16 and save the encoded texture. </li><li><code>/bc7</code>: Encode to BC7 and save the encoded texture. </li><li><code>/nomips</code>: Disables the automatic generation or use of mipmaps </li><li><code>/srgb</code>: causes the /bc7 case to use BC7_UNORM_SRGB rather than BC7_UNORM in the output file
</li><li><code>/aw &lt;float&gt;</code>: Sets the weight for BC7 encoding of alpha. For images with alpha, you can increase this past 1.0 to give the alpha quality more weight than the color information. For images without alpha, you can set this to 0 to increase
 the color information encoding quality particularly if the alpha channel is noisy.
</li><li><code>/point, /linear, /cubic, /fant, /point_dither, /cubic_dither, /fant_dither</code>: Controls the DirectXTex filter settings when generating mipmaps
</li></ul>
<p>Note: mipmapping in this tool is only supported for power-of-2 textures. All source images must be multiples of 4 in width and height.</p>
<p>The input filename can be any WIC-supported bitmap format (.BMP, .PNG, HD Photo, etc.), a .DDS file, or a .TGA file.</p>
<p>The output filename is generated from the input filename as a .DDS file with _BC6 or _BC7 added.</p>
<h1>Building with Visual Studio 2010</h1>
<p>The code in BC6HBC7EncoderCS can be built using Visual Studio 2010 rather than Visual Studio 2012. The changes required are:</p>
<ul>
<li>Change the Platform Toolset to &quot;v100&quot; </li><li>Obtain the <a href="http://directxtex.codeplex.com/">DirectXTex</a> library from Codeplex to get the VS 2010 project files&nbsp;and update the solution/project to use them
</li><li>Obtain the <a href="http://msdn.microsoft.com/en-us/windows/hardware/hh852363">
Windows SDK 8.0</a> </li><li>Use the <a href="http://blogs.msdn.com/b/vcblog/archive/2012/11/23/using-the-windows-8-sdk-with-visual-studio-2010-configuring-multiple-projects.aspx">
instructions </a>for adding the Windows 8.0 SDK headers for VS 2010 projects </li></ul>
<h1>Version History</h1>
<p><strong>June 2010</strong></p>
<p>The DirectX SDK (June 2010) release included the <strong>BC6HBC7EncoderDecoder11
</strong>sample.</p>
<p><strong>June 2011</strong></p>
<p>The <strong>BC6HBC7EncoderDecoder11 </strong>sample was updated on the <em>Games for Windows &amp; DirectX</em>
<a href="http://blogs.msdn.com/b/chuckw/archive/2011/06/02/bc6hbc7encoderdecoder-sample-update.aspx">
blog</a>.</p>
<p><strong>September 12, 2012</strong></p>
<ul>
<li>Support for mipmaps in the source as a .DDS or auto-generation of mipmaps </li><li>Uses DirectXTex rather than D3DX for loading and save textures </li><li>Shaders are compiled as headers to avoid long compilation time at startup </li><li>This version does not support decode (/decode, /sre, or /srf) to simplify the code. The software decoder in DirectXTex can be used to convert the image back to uncompressed form.
</li></ul>
<p><strong>December 20, 2012</strong></p>
<ul>
<li>Improved BC6H compression shaders </li><li>Updated with December 2012 release of DirectXTex </li></ul>
<p><strong>April 20, 2013</strong></p>
<ul>
<li>Improved BC7 compression shaders including new /aw switch </li><li>Updated with April 2013 release of DirectXTex </li></ul>
<h1>More Information</h1>
<p><a href="http://msdn.microsoft.com/en-us/library/hh308955.aspx">Texture Block Compression in Direct3D 11</a></p>
<p><a href="http://directxtex.codeplex.com/">DirectXTex project</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a></p>
