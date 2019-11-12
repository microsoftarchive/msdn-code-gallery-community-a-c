# C#: ContextMenuStrip の使用
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- .NET Framework 2.0
- Windows 7 Ultimate 64 bit
## Topics
- Windows フォーム
- 逆引きサンプル コード
## Updated
- 03/02/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#ikehara" target="_blank">
インフラジスティックス・ジャパン株式会社　池原 大然</a></p>
<p>動作確認環境: Visual Studio 2010、.NET Framework 2.0、Windows 7 Ultimate 64 bit</p>
<hr>
<p>Windows のエクスプローラーではマウスの右クリック ボタンを押下することで切り取り、貼り付けなどの項目を含んだコンテキスト メニューを表示することが可能です。Windows フォーム アプリケーションにおいては
<a href="http://msdn.microsoft.com/ja-jp/library/aszetbbk%28v=VS.100%29.aspx" target="_blank">
ContextMenuStrip</a>&nbsp;を用いてこの機能を下記のように実装することが可能です。なお、Windows フォーム アプリケーションの作成方法については
<a href="/ja-jp//C-Windows-dc42087f/">[C#]&nbsp;Windows フォームによるクライアント アプリケーション開発</a>を参照してください。</p>
<ol>
<li>Windows フォーム アプリケーション プロジェクトを作成し、フォームに TextBox コントロール、ContextMenuStrip コントロールを追加します。
<p><img src="18757-image001.gif" alt="図 1" width="580" height="344"></p>
</li><li>ContextMenuStrip コントロールに &ldquo;新しいウィンドウ&rdquo; という表記の項目を追加し、追加された <a href="http://msdn.microsoft.com/ja-jp/library/system.windows.forms.toolstripmenuitem%28v=VS.100%29.aspx" target="_blank">
ToolStripMenuItem</a>&nbsp;の Name を &ldquo;newWindowMenuItem&rdquo; と設定します。
<p><img src="18758-image002.gif" alt="図 2" width="580" height="289"></p>
</li><li>メニュー項目がマウスでクリックされたイベントについては、<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.forms.toolstrip.itemclicked.aspx" target="_blank">ContextMenuStrip.ItemClicked</a>&nbsp;イベント、あるいは 先ほど追加したアイテムの
<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.forms.toolstripitem.click.aspx" target="_blank">
ToolStripMenuItem.Click</a>&nbsp;イベントのいずれかをハンドルします。ContextMenuStrip.ItemClicked イベントをハンドルし、Name プロパティを判定基準として新しいウィンドウを表示させるコードは下記の通りです。
<p><img src="18759-image003.gif" alt="図 3" width="500" height="347"></p>
<br>
<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;contextMenuStrip1_ItemClicked(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;ToolStripItemClickedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;クリックされた項目の&nbsp;Name&nbsp;を判定します。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(e.ClickedItem.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;newWindowMenuItem&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Form&nbsp;frm&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Form();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frm.Text&nbsp;=&nbsp;<span class="cs__keyword">this</span>.textBox1.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frm.Show();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
</li><li>最後に TextBox.ContextMenuStrip プロパティに先ほどの ContextMenuStrip を設定します。
<p><img src="18760-image004.gif" alt="図 4" width="360" height="414"></p>
<p>実行結果は下記の通りです。</p>
<p><img src="18761-image005.gif" alt="図 5" width="580" height="371"></p>
<p>TextBox に入力したタイトルを持ったウィンドウが作成されます。</p>
</li></ol>
<p>今回は UI 部分についてはデザイナーを使用しました。コードでの UI 部分を含めた設定方法については <a href="/ja-jp/10-ContextMenuStrip-C-0eb623dc/">
10 行でズバリ!! ContextMenuStrip の利用 (C#)</a>&nbsp;において解説されていますのでこちらもご確認ください。</p>
<h2>関連リンク</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/aszetbbk.aspx" target="_blank">ContextMenuStrip&nbsp;クラス</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/z5b29tk4.aspx" target="_blank">ToolMenuStripItem クラス</a>
</li><li><a href="/ja-jp/10-ContextMenuStrip-C-0eb623dc/">10 行でズバリ!! ContextMenuStrip の利用 (C#)</a>
</li></ul>
<div>
<div>
<div></div>
</div>
</div>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank"><img src="-ff950935.windows_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Windows デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/ja-jp">Code Recipe へ</a>
</li><li>もっと Windows の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank">
Windows デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
