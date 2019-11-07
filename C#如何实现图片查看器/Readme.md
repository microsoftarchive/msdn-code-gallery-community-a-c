# C#如何实现图片查看器
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- WinForms
## Topics
- C#
- 图片查看器
- 旋转图片
## Updated
- 06/02/2013
## Description

<h1>简介</h1>
<p><span style="font-size:small"><span style="white-space:pre"></span>因为最近在MSDN中的论坛和CSDN论坛都看到有些朋友问到如何用C#实现一个像Windows自带的图片查看器的功能等类&#20284;的问题(当然还有如何如何旋转图片的，如何通过按钮来变换图片的功能等)，为了帮助大家更好地解决类&#20284;的这样的问题，该示例演示了如何使用C#来实现一个图片查看器的功能的，该示例具有功能有：</span></p>
<ol>
<li><span style="font-size:small"><strong>&nbsp;可以通过&ldquo;上一张&rdquo; &ldquo;下一张&rdquo;这样的按钮来轮换浏览图片</strong></span>
</li><li><span style="font-size:small"><strong>&nbsp;实现对图片的旋转</strong></span> </li><li><span style="font-size:small"><strong>&nbsp;实现对旋转后图片的保存功能。本程序不仅提供旋转90/180/270这样的实现，同时提供一个方法来完成旋转任意角度的实现</strong></span>
</li><li><span style="font-size:small"><strong>该程序未实现Windows图片查看图片缩放的功能，这部分的功能主要要点是改变图片在PictureBox控件中的高度和宽度就可以的</strong></span>
</li></ol>
<h1>运行示例</h1>
<p><span style="font-size:small">第一步、下载示例，打开&quot;PictureView.sln&quot;文件来打开项目</span></p>
<p><span style="font-size:x-small">第二步、按&ldquo;F5&rdquo;运行项目，你将看到下面的界面：</span></p>
<p><img id="83150" src="83150-9.png" alt="" width="699" height="336"><span style="font-size:x-small"><br>
</span></p>
<p>第三步、选择打开图片来打开一张本地图片，打开之后操作图片的按钮的按钮将会变得可见，你将看到下面的一个窗体：</p>
<p><img id="83152" src="83152-10.png" alt="" width="700" height="333"></p>
<p>第四步、此时可以点击按钮来对图片进行旋转操作和图片轮换浏览操作。</p>
<p>第五步、当对图片进行旋转之后，当关闭窗体时，此时旋转的图片将会保存旋转之后的图片到本地路径下。</p>
<h1>实现思路</h1>
<p>第一步、<span>获得目录下所有图片的集合，此时使用</span><strong>Directory.GetFiles()</strong><span>来获得目录下所有文件，然后再对该集合进行筛选，筛选出是图片的文件，代码用扩展名进行筛选.</span></p>
<p>第二步、<span>获得所有图片集合之后，实现图片轮换就需要改变这个集合的索引就可以实现上一张和下一张的功能。</span></p>
<p><span><span>第三步、需要考虑到最后一张或者第一张的情况下，再点击下一张或上一张图片来轮换成第一张或最后一张.</span></span></p>
<p><span><span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> // 上一张图片
        private void btnPre_Click(object sender, EventArgs e)
        {
            int index = GetIndex(imgPath);
            // 释放上一张图片的资源，避免保存的时候出现ExternalException异常
            newbitmap.Dispose();
            if (index == 0)
            {
                SwitchImg(imgArray.Count - 1);
            }
            else
            {
                SwitchImg(index - 1);
            }
        }

        // 下一张图片
        private void btnNext_Click(object sender, EventArgs e)
        {
            int index = GetIndex(imgPath);
            // 释放上一张图片的资源，避免保存的时候出现ExternalException异常
            // 经常在调用Save方法的时候都会出现 一个GDI一般性错误,主要原因是文件没有被释放,当保存到原位置时,就会出现该异常,要避免这个错误就要释放图片占有的资源
            newbitmap.Dispose();
            if (index != imgArray.Count - 1)
            {
                SwitchImg(index &#43; 1);
            }
            else
            {
                SwitchImg(0);
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">//&nbsp;上一张图片</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnPre_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;GetIndex(imgPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;释放上一张图片的资源，避免保存的时候出现ExternalException异常</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(index&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SwitchImg(imgArray.Count&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SwitchImg(index&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;下一张图片</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnNext_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;GetIndex(imgPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;释放上一张图片的资源，避免保存的时候出现ExternalException异常</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;经常在调用Save方法的时候都会出现&nbsp;一个GDI一般性错误,主要原因是文件没有被释放,当保存到原位置时,就会出现该异常,要避免这个错误就要释放图片占有的资源</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(index&nbsp;!=&nbsp;imgArray.Count&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SwitchImg(index&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SwitchImg(<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</span></span>
<p></p>
<p>第四步、<span>使用</span><span><strong>Image.RotateFlip(RotateFlipType)</strong></span><span>方法来对图片进行旋转</span></p>
<p><span>第五步、对旋转之后的图片进行保存</span></p>
<p><span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 关闭窗体后保存旋转后的图片到文件中
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgPath == null || isRotate == false)
            {
                return;
            }

            // 保存旋转后的图片
            switch (Path.GetExtension(imgPath).ToLower())
            {
                case &quot;.png&quot;:
                    newbitmap.Save(imgPath, ImageFormat.Png);
                    newbitmap.Dispose();
                    break;
                case &quot;.jpg&quot;:
                    newbitmap.Save(imgPath);
                    newbitmap.Dispose();
                    break;
                default:
                    newbitmap.Save(imgPath, ImageFormat.Bmp);
                    newbitmap.Dispose();
                    break;
            }
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;关闭窗体后保存旋转后的图片到文件中</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_FormClosed(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;FormClosedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(imgPath&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;||&nbsp;isRotate&nbsp;==&nbsp;<span class="cs__keyword">false</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;保存旋转后的图片</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(Path.GetExtension(imgPath).ToLower())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;.png&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Save(imgPath,&nbsp;ImageFormat.Png);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;.jpg&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Save(imgPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Save(imgPath,&nbsp;ImageFormat.Bmp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbitmap.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span>
<p></p>
<ul>
</ul>
<h1>更多信息</h1>
<p>Image.RotateFlip 方法</p>
<p><a href="http://msdn.microsoft.com/zh-cn/library/system.drawing.image.rotateflip.aspx" target="_blank">http://msdn.microsoft.com/zh-cn/library/system.drawing.image.rotateflip.aspx</a></p>
<p>Image.Save 方法</p>
<p><a href="http://msdn.microsoft.com/zh-cn/library/system.drawing.image.save.aspx" target="_blank">http://msdn.microsoft.com/zh-cn/library/system.drawing.image.save.aspx</a></p>
<p>PictureBox 类</p>
<p><a href="http://msdn.microsoft.com/zh-cn/library/system.windows.forms.picturebox.aspx" target="_blank">http://msdn.microsoft.com/zh-cn/library/system.windows.forms.picturebox.aspx</a></p>
<p>Directory.GetFiles 方法 (String)</p>
<p><a href="http://msdn.microsoft.com/zh-cn/library/07wt70x2.aspx" target="_blank">http://msdn.microsoft.com/zh-cn/library/07wt70x2.aspx</a></p>
