# ColorMatrix Image Filters
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- GDI+
- ASP.NET
- .NET
- Windows Forms
- Visual Studio 2010
- .NET Framework 4
- .NET 3.0
- .NET Framework 3.5 SP1
- .NET Framework
- .NET Framework 4.0
- Windows General
- C# Language
- WinForms
- Visual C Sharp .NET
- Image process
- ASP.NET 4.5
- asp.net 4.0
- .NET 4.5
## Topics
- Graphics
- GDI+
- Graphics and 3D
- Images
- ImageViewer
- 2d graphics
- Image manipulation
- Image
- Imaging
- Generic C# resuable code
- Image Optimization
- C# Language Features
- System.Drawing.Drawing2D
- BitmapImage
- Load Image
- Extension methods
## Updated
- 03/03/2013
## Description
&nbsp;
<h1>Introduction</h1>
<p style="text-align:justify">This article is based around creating basic <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> filters. The different types of filters discussed are: <strong>Grayscale</strong>,
<strong>Transparency</strong>, <strong>Image Negative</strong> and <strong>Sepia tone</strong>. All filters are implemented as extension methods targeting the
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx">Image</a> class, as well as the
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx">Bitmap</a> class as the result of inheritance and upcasting.</p>
<p style="text-align:justify"><strong><em>Note:</em></strong> This article is a follow up to
<a title="ARGB Image Filters" href="http://code.msdn.microsoft.com/ARGB-Image-Filters-57af976b" target="_blank">
ARGB Image Filters</a>. The previously published related article implements image filtering by performing calculations and updating image pixel colour component values namely Alpha, Red, Green and Blue. This article achieves the same image filtering through
 implementing various <a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> transformations, in essence providing an alternative solution. For the sake of convenience I have included the pixel manipulation extension methods in addition to the
<a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> extension methods detailed by this article.</p>
<h1>Implementing a ColorMatrix</h1>
<p>From <a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
MSDN Documentation</a>:</p>
<blockquote>
<p style="text-align:justify">Defines a 5 x 5 matrix that contains the coordinates for the RGBAW space. Several methods of the
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imageattributes.aspx">
ImageAttributes</a> class adjust image colors by using a color matrix. The matrix coefficients constitute a 5 x 5 linear transformation that is used for transforming ARGB homogeneous values. For example, an ARGB vector is represented as red, green, blue, alpha
 and w, where w is always 1.</p>
</blockquote>
<p style="text-align:justify">When implementing a translation using the <a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> class values specified are added to one or more of the four colour components. A value that is to be added may only range from 0 to 1 inclusive. Note that adding a negative value results in subtracting values. A good article that illustrates
 implementing a <a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> can be found here: <a href="http://msdn.microsoft.com/library/ys160710.aspx">
How to: Translate Image Colors</a>.</p>
<p style="text-align:justify">The following code snippet provides the implementation of the
<strong><em>ApplyColorMatrix</em></strong> method.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private static Bitmap ApplyColorMatrix(Image sourceImage, ColorMatrix colorMatrix)
{
    Bitmap bmp32BppSource = GetArgbCopy(sourceImage);
    Bitmap bmp32BppDest = new Bitmap(bmp32BppSource.Width, bmp32BppSource.Height, 
PixelFormat.Format32bppArgb);

    using (Graphics graphics = Graphics.FromImage(bmp32BppDest))
    {
        ImageAttributes bmpAttributes = new ImageAttributes();
        bmpAttributes.SetColorMatrix(colorMatrix);

        graphics.DrawImage(bmp32BppSource, new Rectangle(0, 0, bmp32BppSource.Width,
              bmp32BppSource.Height),
              0, 0, bmp32BppSource.Width,
              bmp32BppSource.Height, GraphicsUnit.Pixel, bmpAttributes);

    }

    bmp32BppSource.Dispose();

    return bmp32BppDest;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;ApplyColorMatrix(Image&nbsp;sourceImage,&nbsp;ColorMatrix&nbsp;colorMatrix)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmp32BppSource&nbsp;=&nbsp;GetArgbCopy(sourceImage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmp32BppDest&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(bmp32BppSource.Width,&nbsp;bmp32BppSource.Height,&nbsp;&nbsp;
PixelFormat.Format32bppArgb);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Graphics&nbsp;graphics&nbsp;=&nbsp;Graphics.FromImage(bmp32BppDest))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageAttributes&nbsp;bmpAttributes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ImageAttributes();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpAttributes.SetColorMatrix(colorMatrix);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;graphics.DrawImage(bmp32BppSource,&nbsp;<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;bmp32BppSource.Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp32BppSource.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;bmp32BppSource.Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp32BppSource.Height,&nbsp;GraphicsUnit.Pixel,&nbsp;bmpAttributes);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmp32BppSource.Dispose();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;bmp32BppDest;&nbsp;
}</pre>
</div>
</div>
</div>
<p style="text-align:justify">The <strong><em>ApplyColorMatrix</em></strong> method signature defines a parameter of type Image and a second parameter of type
<a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a>. This method is intended to apply the specified <a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> upon the Image parameter specified.</p>
<p style="text-align:justify">The source image is firstly copied in order to ensure that the image that is to be transformed is defined with a pixel format of 32 bits per pixel, consisting of the colour components Alpha, Red, Green and Blue &ndash;
<a title="PixelFormat.Format32bppArgb" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.pixelformat.aspx" target="_blank">
PixelFormat.Format32bppArgb</a>. Next we create a blank memory bitmap defined to reflect the same size dimensions as the original source image. A
<a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> can be implemented by means of applying an <a title="ImageAttribute" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imageattributes.aspx" target="_blank">
ImageAttribute</a> when invoking the <a title="DrawImage" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.graphics.drawimage.aspx" target="_blank">
DrawImage</a> defined by the <a title="Graphics" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.graphics.aspx" target="_blank">
Graphics</a> class.&nbsp;</p>
<h1><span>Creating an ARGB copy</span></h1>
<p><span>The source code snippet listed below converts source images into 32Bit ARGB formatted images:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private static Bitmap GetArgbCopy(Image sourceImage)
{
    Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);

    using (Graphics graphics = Graphics.FromImage(bmpNew))
    {
        graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height),
            new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
        graphics.Flush();
    }

    return bmpNew;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;GetArgbCopy(Image&nbsp;sourceImage)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmpNew&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(sourceImage.Width,&nbsp;sourceImage.Height,&nbsp;PixelFormat.Format32bppArgb);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Graphics&nbsp;graphics&nbsp;=&nbsp;Graphics.FromImage(bmpNew))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;graphics.DrawImage(sourceImage,&nbsp;<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;bmpNew.Width,&nbsp;bmpNew.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;bmpNew.Width,&nbsp;bmpNew.Height),&nbsp;GraphicsUnit.Pixel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;graphics.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;bmpNew;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:justify">The <strong><em>GetArgbCopy</em></strong> method creates a blank memory
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx">Bitmap</a> having the same size dimensions as the source image. The newly created
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx">Bitmap</a> is explicitly specified to conform to a 32Bit ARGB format. By making use of a
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.graphics.aspx">Graphics</a> object of which the context is bound to the new
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx">Bitmap</a> instance the source code draws the original image to the new
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx">Bitmap</a>.</p>
<div>&nbsp;</div>
<h1><span>The Transparency Filter</span></h1>
<p style="text-align:justify"><span>The transparency filter is intended to create a copy of an image, increase the copy&rsquo;s level of transparency and return the modified copy to the calling code. Listed below is source code which defines the
<strong><em>DrawWithTransparency </em></strong><a href="http://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx">extension method</a>.</span></p>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap DrawWithTransparency(this Image sourceImage)
{
    ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                                        {
                                            new float[] {1, 0, 0, 0, 0},
                                            new float[] {0, 1, 0, 0, 0},
                                            new float[] {0, 0, 1, 0, 0},
                                            new float[] {0, 0, 0, 0.3f, 0},
                                            new float[] {0, 0, 0, 0, 1}
                                        });
            
    return ApplyColorMatrix(sourceImage, colorMatrix);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;DrawWithTransparency(<span class="cs__keyword">this</span>&nbsp;Image&nbsp;sourceImage)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ColorMatrix&nbsp;colorMatrix&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColorMatrix(<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[][]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>.3f,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ApplyColorMatrix(sourceImage,&nbsp;colorMatrix);&nbsp;
}</pre>
</div>
</div>
</div>
</span></div>
<p style="text-align:justify">Due to the <strong><em>ApplyColorMatrix</em></strong> method defined earlier implementing an image filter simply consists of defining the filter algorithm in the form of a
<a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> and then invoking <strong><em>ApplyColorMatrix. </em></strong>The
<a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> is defined to apply no change to the Red, Green and Blue components whilst reducing the Alpha component by 70%.</p>
<div style="text-align:justify">&nbsp;</div>
<div><span><img id="76991" src="76991-imagefilters_transparency_colormatrix.png" alt="" width="605" height="409"></span></div>
<div></div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<h1>The Grayscale Filter</h1>
<p>All of the image filter extension methods illustrated in this article are implemented in a fashion similar to the
<strong><em>DrawWithTransparency</em> method. The <em>DrawAsGrayscale </em></strong>extension method is implemented as follows:</p>
<div style="text-align:justify">&nbsp;</div>
<div></div>
<div style="text-align:justify">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap DrawAsGrayscale(this Image sourceImage)
{
    ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                                        {
                                            new float[] {.3f, .3f, .3f, 0, 0},
                                            new float[] {.59f, .59f, .59f, 0, 0},
                                            new float[] {.11f, .11f, .11f, 0, 0},
                                            new float[] {0, 0, 0, 1, 0},
                                            new float[] {0, 0, 0, 0, 1}
                                        });

    return ApplyColorMatrix(sourceImage, colorMatrix);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;DrawAsGrayscale(<span class="cs__keyword">this</span>&nbsp;Image&nbsp;sourceImage)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ColorMatrix&nbsp;colorMatrix&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColorMatrix(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[][]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{.3f,&nbsp;.3f,&nbsp;.3f,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{.59f,&nbsp;.59f,&nbsp;.59f,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{.11f,&nbsp;.11f,&nbsp;.11f,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ApplyColorMatrix(sourceImage,&nbsp;colorMatrix);&nbsp;
}</pre>
</div>
</div>
</div>
&nbsp;</div>
<p>The grayscale filter is achieved by adding together 11% blue, 59% green and 30% red, then assigning the total value to each colour component.</p>
<div>&nbsp;</div>
<div></div>
<div><span><img id="76992" src="76992-imagefilters_grayscale_colormatrix.png" alt="" width="605" height="409"></span></div>
<div></div>
<div><span>&nbsp;</span></div>
<h1><span>The Sepia Tone Filter</span></h1>
<p style="text-align:justify"><span>The sepia tone filter is implemented in the extension method
<strong><em>DrawAsSepiaTone</em></strong>. Notice how this method follows the same convention as the previously discussed filters. The source code listing is detailed below.</span></p>
<div></div>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap DrawAsSepiaTone(this Image sourceImage)
{
    ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                                        {
                                            new float[] {.393f, .349f, .272f, 0, 0},
                                            new float[] {.769f, .686f, .534f, 0, 0},
                                            new float[] {.189f, .168f, .131f, 0, 0},
                                            new float[] {0, 0, 0, 1, 0},
                                            new float[] {0, 0, 0, 0, 1}
                                        });

    return ApplyColorMatrix(sourceImage, colorMatrix);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;DrawAsSepiaTone(<span class="cs__keyword">this</span>&nbsp;Image&nbsp;sourceImage)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ColorMatrix&nbsp;colorMatrix&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColorMatrix(<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[][]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{.393f,&nbsp;.349f,&nbsp;.272f,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{.769f,&nbsp;.686f,&nbsp;.534f,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{.189f,&nbsp;.168f,&nbsp;.131f,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ApplyColorMatrix(sourceImage,&nbsp;colorMatrix);&nbsp;
}</pre>
</div>
</div>
</div>
</span></div>
<div></div>
<p style="text-align:justify">The formula used to calculate a sepia tone differs significantly from the grayscale filter discussed previously. The formula can be simplified as follows:</p>
<ul>
<li>
<div><strong>Red Component:</strong> <em>Sum total of:</em> 39.3% red, 34.9% green , 27.2% blue</div>
</li><li>
<div><strong>Green Component:</strong> <em>Sum total of:</em> 76.9% red, 68.6% green , 53.4% blue</div>
</li><li>
<div><strong>Blue Component:</strong> <em>Sum total of:</em> 18.9% red, 16.8% green , 13.1% blue</div>
&nbsp; </li></ul>
<div></div>
<div><span><img id="76993" src="76993-imagefilters_sepia_colormatrix.png" alt="" width="605" height="409"></span></div>
<div></div>
<div><span>&nbsp;</span></div>
<h1><span>The Negative Image Filter</span></h1>
<p style="text-align:justify"><span>We can implement an image filter that resembles film negatives by literally inverting every pixel&rsquo;s colour components. Listed below is the source code implementation of the
<strong><em>DrawAsNegative</em></strong> extension method.</span></p>
<div></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap DrawAsNegative(this Image sourceImage)
{
    ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                                        {
                                            new float[] {-1, 0, 0, 0, 0},
                                            new float[] {0, -1, 0, 0, 0},
                                            new float[] {0, 0, -1, 0, 0},
                                            new float[] {0, 0, 0, 1, 0},
                                            new float[] {1, 1, 1, 1, 1}
                                        });

    return ApplyColorMatrix(sourceImage, colorMatrix);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;DrawAsNegative(<span class="cs__keyword">this</span>&nbsp;Image&nbsp;sourceImage)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ColorMatrix&nbsp;colorMatrix&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColorMatrix(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[][]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ApplyColorMatrix(sourceImage,&nbsp;colorMatrix);&nbsp;
}</pre>
</div>
</div>
</div>
<p>Notice how the negative image filter subtracts 1 from each colour component, remember the valid range being 0 to 1 inclusive. This
<a title="ColorMatrix" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix.aspx" target="_blank">
ColorMatrix</a> in reality inverts each pixel&rsquo;s colour component bits. The transform being applied can also be expressed as implementing the bitwise compliment operator on each pixel.</p>
<div>&nbsp;</div>
<div></div>
<div><span><img id="76995" src="76995-imagefilters_negative_colormatrix.png" alt="" width="605" height="409"></span></div>
<div></div>
<div><span>&nbsp;</span></div>
<h1><span>The implementation</span></h1>
<p style="text-align:justify"><span>The image filters described in this article are all implemented by means of a Windows Forms application. Image filtering is applied by selecting the corresponding radio button. The source image loaded from the file system
 serves as input to the various image filter methods, the filtered image copy returned will be displayed next to the original source image.</span></p>
<div></div>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void OnCheckChangedEventHandler(object sender, EventArgs e)
{
    if (picSource.BackgroundImage != null)
    {
        if (rdGrayscaleBits.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.CopyAsGrayscale();
        }
        else if (rdGrayscaleDraw.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.DrawAsGrayscale();
        }
        else if (rdTransparencyBits.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.CopyWithTransparency();
        }
        else if (rdTransparencyDraw.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.DrawWithTransparency();
        }
        else if (rdNegativeBits.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.CopyAsNegative();
        }
        else if (rdNegativeDraw.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.DrawAsNegative();
        }
        else if (rdSepiaBits.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.CopyAsSepiaTone();
        }
        else if (rdSepiaDraw.Checked == true)
        {
            picOutput.BackgroundImage = picSource.BackgroundImage.DrawAsSepiaTone();
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnCheckChangedEventHandler(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(picSource.BackgroundImage&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdGrayscaleBits.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.CopyAsGrayscale();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdGrayscaleDraw.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.DrawAsGrayscale();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdTransparencyBits.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.CopyWithTransparency();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdTransparencyDraw.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.DrawWithTransparency();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdNegativeBits.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.CopyAsNegative();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdNegativeDraw.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.DrawAsNegative();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdSepiaBits.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.CopyAsSepiaTone();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(rdSepiaDraw.Checked&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picOutput.BackgroundImage&nbsp;=&nbsp;picSource.BackgroundImage.DrawAsSepiaTone();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</span>
<h1 class="endscriptcode"><span>Source Code Files</span></h1>
</div>
<ul>
<li>
<div><em><em><em>ExtBitmap.cs - Source code definition of image filter extension methods.</em></em></em></div>
</li><li><em><em><em><em>MainForm.cs- Implementation of image filter methods.</em></em></em></em>
</li></ul>
<h1>More Information</h1>
<p>This article is based on an article originally posted on my <a href="http://softwarebydefault.com">
blog</a>:&nbsp;<a href="http://softwarebydefault.com/2013/03/03/colomatrix-image-filters/">http://softwarebydefault.com/2013/03/03/colomatrix-image-filters/</a> If you have any questions/comments please feel free to make use of the Q&amp;A section on this page,
 also please remember to rate this article.</p>
<p><strong><em>Dewald Esterhuizen</em></strong></p>
<ul>
</ul>
