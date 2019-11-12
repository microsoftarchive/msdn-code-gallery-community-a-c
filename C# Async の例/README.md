# C# Async の例
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- Async
## Topics
- 非同期処理
## Updated
- 05/10/2011
## Description

<h1>概要</h1>
<p><a href="index.html">C# によるプログラミング入門</a>「<a href="http://ufcpp.net/study/csharp/sp5_async.html">非同期処理</a>」向けのサンプルです。</p>
<p>C# Async（おそらくC# 5.0で導入される非同期処理）に関して、何ができるのか、内部的な仕組みがどうなっているのかを説明するためのものです。</p>
<h1><span>サンプルのビルド</span></h1>
<p>ビルドには<a href="http://msdn.microsoft.com/en-us/vstudio/async.aspx">Visual Studio Async CTP (SP1 Refresh)</a>が必要です。</p>
<h1><span style="font-size:20px; font-weight:bold">説明</span></h1>
<p>5つのプロジェクトが含まれています。</p>
<ul>
<li>AsyncSample </li><li>PseudoAsync </li><li>AwaiterPatternSample </li><li>SynchronizationContextSample </li><li>ProgressSample </li></ul>
<h2>&nbsp;AsyncSample</h2>
<p>C# 4.0までの書き方とAsyncを使った書き方の比較です。また、同期処理との比較（UIスレッドで同期的に時間のかかる処理を行うと、プログラムがフリーズする）例も含まれています。</p>
<h2>PseudoAsync</h2>
<p>Asyncの内部的な仕組みは、イテレーターブロック（yield return）からの列挙子の自動生成に&#20284;ています。</p>
<p>この例では、逆に、イテレーターブロックを使って非同期処理を行う例を紹介します。</p>
<p>また、async/await を使ったコードがどう展開されているのかも例を挙げて説明します。</p>
<h2>AwaiterPatternSample</h2>
<p>awaitは、以下のような条件を満たす型ならば何にでも使うことができます。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;同名のメソッドを持っていれば型は問わない。</span>&nbsp;
<span class="cs__keyword">class</span>&nbsp;Awatable&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Awaiter&nbsp;GetAwaiter()&nbsp;{&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;同上、同名のメソッドを持っていれば型は問わない。</span>&nbsp;
<span class="cs__keyword">struct</span>&nbsp;Awaiter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsCompleted&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnCompleted(Action&nbsp;continuation)&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;T&nbsp;GetResult()&nbsp;{&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">この例では、このAwaitableを自作する例を紹介しています。</div>
<p></p>
<p>（あくまでもサンプルです。せっかくTaskを使っているのに、Task終了までブロッキングして同期するという微妙な作りになっています。）</p>
<h2>SynchronizationContextSample</h2>
<p>C# Asyncは、内部的にSynchronizationContextを利用しています。例えば、WindowsフォームやWPFアプリの場合、UIの更新はUIスレッドからしかできないという制限がありますが、C# AsyncにはSynchronizationContextを介してUIスレッドに非同期処理の結果を渡す仕組みを内部持っていて、ロックやディスパッチャーを明示的に使う必要はありません。</p>
<p>ここでは、SynchronizationContextを自作する例を示します。GUIアプリケーションのメッセージ ポンプのような仕組みを自作しています。</p>
<h2>ProgressSample</h2>
<p>Taskクラスを使った新しい非同期パターンでは、処理の進捗報告のためにIProgressインターフェイスというものを導入しました。ここではこのIProgressインターフェイスの利用例を示します。</p>
<p>.NET Framework 2.0以降には、非同期処理＋進捗報告を行うためのBackgroundWorkerクラスがありました。しかし、このクラスには以下のような問題があります。</p>
<ul>
<li>非同期処理と進捗報告は元々別の関心事なので、1つのクラスにまとめてしまうのは関心の分離ができていない </li><li>BackgroundWorkerからさらに別の非同期処理を呼び出したい場合に面倒 </li></ul>
<p>Taskクラス＋IProgressインターフェイスではこの問題が解消されます。</p>
