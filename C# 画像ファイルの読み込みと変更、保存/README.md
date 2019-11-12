# C#: 画像ファイルの読み込みと変更、保存
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2013
## Topics
- 逆引きサンプル コード
- ファイル・ディレクトリ操作
## Updated
- 12/18/2014
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#ikehara" target="_blank">
インフラジスティックス・ジャパン株式会社 池原 大然</a></p>
<p>動作確認環境: Visual Studio 2013、.NET Framework 4.5.2、Windows 8.1 Enterprise 64 bit</p>
<hr>
<p><a href="http://msdn.microsoft.com/ja-jp/library/system.drawing.image.aspx" target="_blank">System.Drawing.Image</a> クラス、あるいは Image クラスを継承した
<a href="http://msdn.microsoft.com/ja-jp/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> クラスを利用することで画像ファイルの作成やロード、変更、保存を行うことができます。既存の画像ファイルを Bitmap クラスで読み取る場合にはコンストラクタにてファイル名を指定します。Bitmap クラスでサポートしている形式は、BMP、GIF、EXIF、JPG、PNG、TIFF などになります。</p>
<p>なお、コンソールアプリケーションは初期状態でSystem.Drawing.dll アセンブリがプロジェクトで参照されていないため、[ソリューション エクスプローラ] から [参照の追加] を実行し、アセンブリを予めプロジェクトに追加しておく必要があります。</p>
<p><img id="131382" src="131382-52_cs_01.png" alt="" width="382" height="277"></p>
<p><img id="131384" src="131384-52_cs_02.png" alt="" width="700" height="305"></p>
<p>Bitmap クラスでは読み込んだ画像オブジェクトに対し、<a href="http://msdn.microsoft.com/ja-jp/library/system.drawing.bitmap.setpixel.aspx" target="_blank">SetPixel</a> メソッドを使用することで画像オブジェクトの特定のピクセルを変更することができます。</p>
<p>例として、&rdquo;C:\Images\sample.jpg&rdquo; という画像ファイルを読み込み、ピクセルを変更させた後、&rdquo;C:\Images\sampleNew.jpg&rdquo; と新しい画像ファイルを保存するコードは下記のようになります。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="vb">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ja-JP/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ja-JP/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
namespace&nbsp;CodeRecipe_ImageLoading_CS&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;class&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;void&nbsp;Main(string[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;oFileName&nbsp;=&nbsp;@<span class="visualBasic__string">&quot;C:\Images\sample.jpg&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;nFileName&nbsp;=&nbsp;@<span class="visualBasic__string">&quot;C:\Images\sampleNew.jpg&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(Bitmap&nbsp;oImage&nbsp;=&nbsp;new&nbsp;Bitmap(oFileName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;for&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;oImage.Width;&nbsp;i&nbsp;&#43;=&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;for&nbsp;(int&nbsp;j&nbsp;=&nbsp;<span class="visualBasic__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;oImage.Height;&nbsp;j&nbsp;&#43;=&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oImage.SetPixel(i,&nbsp;j,&nbsp;Color.Blue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oImage.Save(nFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ja-JP/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(nFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">上記のサンプルコードでは <a href="http://msdn.microsoft.com/ja-jp/library/system.drawing.bitmap.save.aspx" target="_blank">
Save</a> メソッドを使用し保存するファイル名を指定しています。</div>
<p>また、画像オブジェクトに関する処理を終えたあとは、画像オブジェクト インスタンスを<a href="http://msdn.microsoft.com/ja-jp/library/8th8381z.aspx" target="_blank"> Dispose</a> し、リソースを解放する必要があることについても注意してくさい。今回は using ステートメントの使用により、自動的にこの処理が行われるように設定しています。</p>
<p>最後にすべての作業が終了した後に保存するファイルの拡張子に関連付けられたアプリケーションが起動するよう、<a class="libraryLink" href="https://msdn.microsoft.com/ja-JP/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a> メソッドを実行しています。</p>
<h2>関連リンク</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/k7e7b2kd.aspx" target="_blank">Image クラス</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/4e7y164x.aspx" target="_blank">Bitmap クラス</a>
</li></ul>
<p><span style="color:#ffffff">＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝</span></p>
