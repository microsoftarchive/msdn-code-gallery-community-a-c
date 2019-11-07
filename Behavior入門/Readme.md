# Behavior入門
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Behaivor
## Updated
- 05/21/2011
## Description

<h1>概要</h1>
<p>このサンプルでは、Expression BlendでサポートされているBehaviorの使い方、カスタムのBehaviorの作り方とXAMLでの設定方法について説明します。BehaviorはExpression Blendでサポートされていますが、Visual StudioでもExpression Blend SDKをダウンロードすることで使用できます。</p>
<ul>
<li><a href="http://www.microsoft.com/downloads/ja-jp/details.aspx?FamilyID=75E13D71-7C53-4382-9592-6C07C6A00207" target="_blank">Expression Blend SDK for .NET4</a>
</li><li><a href="http://www.microsoft.com/downloads/ja-jp/details.aspx?FamilyID=D197F51A-DE07-4EDF-9CBA-1F1B4A22110D" target="_blank">Expression Blend SDK for Silverlight4</a>
</li></ul>
<p>このサンプルでは、上記SDKをインストールしたVisual Studio上でのBehaviorを使うことを前提にしています。Behaviorを使うときに、どのようなXAMLが記述されるのか把握することでExpression Blendでドラッグアンドドロップしたときに、どのようなXAMLが生成されるのかイメージしやすくなると思います。</p>
<h1>Behaviorとは</h1>
<p>Behaviorとは、添付ビヘイビアとしてコミュニティ内で広がっていた添付プロパティの使い方を、Expression Blend3で公式にツールサポートが提供されたものになります。それまで、ばらばらに実装されていた添付ビヘイビアの実装をBehavior&lt;T&gt;クラスとして基本実装を提供することで、必要最低限のメソッドを実装するだけで作成可能にしています。</p>
<p>Behaviorを使用することで、XAMLで部品化されたプレゼンテーションロジックを記述することが出来ます。添付ビヘイビアについての記事は、<a href="http://blog.sharplab.net/" target="_blank">SharpLab</a>の以下の翻訳記事が非常にわかりやすいです。</p>
<ul>
<li><a href="http://blog.sharplab.net/computer/cprograming/wpf/1856/" target="_blank">M-V-VMパターンについての記事を訳してみた4　原題&quot;Introduction to Attached Behaviors in WPF&quot;</a>
</li></ul>
<h1>BehaviorをXAMLで記述するための手順</h1>
<p>BehaviorをXAMLで記述するための手順は以下の通りになります。</p>
<p>以下のアセンブリを参照に追加します。</p>
<ul>
<li>System.Windows.Interactivity.dll </li><li>Microsoft.Expression.Interactions.dll </li></ul>
<p>Behaviorを追加したいXAMLに以下の名前空間を定義します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">xmlns:i=&quot;http://schemas.microsoft.com/expression/2010/interactivity&quot;
xmlns:ei=&quot;http://schemas.microsoft.com/expression/2010/interactions&quot;
</pre>
<div class="preview">
<pre class="xaml">xmlns:i=&quot;http://schemas.microsoft.com/expression/2010/interactivity&quot;&nbsp;
xmlns:ei=&quot;http://schemas.microsoft.com/expression/2010/interactions&quot;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Behaviorを追加したいコントロールの下に、以下のようにi:Interaction.Behaviors/i:Interaction.Triggers添付プロパティを追加し、その下にBehavior（Triggersの下にはTriggerとTriggerAction)を設定します。以下にMessageBoxBehaviorというビヘイビアをButtonに追加するXAMLの例を示します。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Button Content=&quot;MessageBox Behavior&quot;&gt;
    &lt;i:Interaction.Behaviors&gt;
        &lt;!-- Behaviorにはプロパティも作成可能。添付プロパティとして作成するとBindingも可能。 --&gt;
        &lt;local:MessageBoxBehavior Message=&quot;こんにちは世界&quot; /&gt;
    &lt;/i:Interaction.Behaviors&gt;
&lt;/Button&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Button</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;MessageBox&nbsp;Behavior&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;i</span>:Interaction.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__comment">&lt;!--&nbsp;Behaviorにはプロパティも作成可能。添付プロパティとして作成するとBindingも可能。&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;local</span>:MessageBoxBehavior&nbsp;<span class="xaml__attr_name">Message</span>=<span class="xaml__attr_value">&quot;こんにちは世界&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/i:Interaction.Behaviors&gt;</span><span class="xaml__tag_end">&lt;/Button&gt;</span></pre>
</div>
</div>
</div>
<h1 class="endscriptcode">カスタムBehaviorの作成方法</h1>
<p>Behaviorを自作するには、System.Windows.Interactivity.Behavior&lt;T&gt;クラスを継承して作成します。Behaviorクラスには、Behaviorがコントロールにアタッチされたときの呼び出されるOnAttacheｄメソッドと、コントロールから切り離されるときによびだされるOnDetachingメソッドが定義されています。この２つのメソッドをオーバーライドすることで、コントロールのイベントを購読して、独自のプレゼンテーションロジックを実行していきます。</p>
<p>ボタンのClickイベントを購読してHello worldと表示するBehaviorは以下のようになります。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace Behavior.Sample1
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    /// &lt;summary&gt;
    /// ボタンをクリックするとHello worldというメッセージを表示する
    /// 動作を追加するビヘイビア。
    /// &lt;/summary&gt;
    public class HelloWorldBehavior : Behavior&lt;Button&gt;
    {
        /// &lt;summary&gt;
        /// ボタンにアタッチされたときに呼ばれる。
        /// &lt;/summary&gt;
        protected override void OnAttached()
        {
            base.OnAttached();
            // 一般的にイベントの設定のような初期化処理をここでおこなう
            this.AssociatedObject.Click &#43;= this.Button_Click;
        }

        /// &lt;summary&gt;
        /// デタッチされたときに呼ばれる。
        /// &lt;/summary&gt;
        protected override void OnDetaching()
        {
            // 一般的にOnAttachedでした初期化の後始末をここで行う
            this.AssociatedObject.Click -= this.Button_Click;
            base.OnDetaching();
        }

        /// &lt;summary&gt;
        /// Hello worldを表示する。
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(&quot;Hello world&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;Behavior.Sample1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows.Controls;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows.Interactivity;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;ボタンをクリックするとHello&nbsp;worldというメッセージを表示する</span><span class="cs__com">///&nbsp;動作を追加するビヘイビア。</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;HelloWorldBehavior&nbsp;:&nbsp;Behavior&lt;Button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;ボタンにアタッチされたときに呼ばれる。</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__keyword">protected</span><span class="cs__keyword">override</span><span class="cs__keyword">void</span>&nbsp;OnAttached()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnAttached();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;一般的にイベントの設定のような初期化処理をここでおこなう</span><span class="cs__keyword">this</span>.AssociatedObject.Click&nbsp;&#43;=&nbsp;<span class="cs__keyword">this</span>.Button_Click;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;デタッチされたときに呼ばれる。</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__keyword">protected</span><span class="cs__keyword">override</span><span class="cs__keyword">void</span>&nbsp;OnDetaching()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;一般的にOnAttachedでした初期化の後始末をここで行う</span><span class="cs__keyword">this</span>.AssociatedObject.Click&nbsp;-=&nbsp;<span class="cs__keyword">this</span>.Button_Click;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnDetaching();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;Hello&nbsp;worldを表示する。</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;Button_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Hello&nbsp;world&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">BehaviorのAssociatedObjectでBehaviorに紐づけられたオブジェクトを参照することが出来ます。ここでは、OnAttachedでボタンのClickイベントを購読し、OnDetachingでボタンのClickイベントの購読を解除しています。そして、ボタンのClickイベントでメッセージボックスを表示しています。Behaviorのジェネリックパラメータには、Behaviorを適用できるクラスを指定します。（今回の例ではButton）</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">このBehaviorをボタンに設定するXAMLは以下のようになります。（local名前空間にはBehavior.Sample1名前空間が設定されています）</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Button Content=&quot;Hello world Behavior&quot;&gt;
    &lt;!-- i:Interaction.Behaviors添付プロパティにBehaviorを設定する --&gt;
    &lt;i:Interaction.Behaviors&gt;
        &lt;!-- 自作のHelloWorldBehaviorを追加。Behaviorは必要に応じて複数追加できる。 --&gt;
        &lt;local:HelloWorldBehavior /&gt;
    &lt;/i:Interaction.Behaviors&gt;
&lt;/Button&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Button</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Hello&nbsp;world&nbsp;Behavior&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__comment">&lt;!--&nbsp;i:Interaction.Behaviors添付プロパティにBehaviorを設定する&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;i</span>:Interaction.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__comment">&lt;!--&nbsp;自作のHelloWorldBehaviorを追加。Behaviorは必要に応じて複数追加できる。&nbsp;--&gt;</span><span class="xaml__tag_start">&lt;local</span>:HelloWorldBehavior&nbsp;<span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/i:Interaction.Behaviors&gt;</span><span class="xaml__tag_end">&lt;/Button&gt;</span></pre>
</div>
</div>
</div>
<h1 class="endscriptcode">TriggerとTriggerAction</h1>
<p>Behaviorを実装していると、Behaviorは以下の要素で構成されていることがわかります。</p>
<ul>
<li>Behaviorで実行する処理を起動するきっかけ </li><li>Behaviorで実行する処理 </li></ul>
<p>上記のHelloWorldBehaviorでは、処理を起動するきっかけはボタンのClickイベントで、処理は、メッセージボックスの表示になります。では、ボタンのクリックではなく、テキストボックスでEnterキーが押された時にメッセージボックスを表示するBehaviorを作成しようと考えます。そうするとOnAttachedとOnDetachingで購読/購読解除する処理が違うだけのコードになります。このままだと、処理を起動するきっかけｘ実行する処理の数だけBehaviorを作成しなければなりません。</p>
<p>TriggerとTriggerActionは、この処理のきっかけと実行する処理を分離したものになります。Triggerで、処理を起動するきっかけを定義して、TriggerActionで実行する処理を定義します。上記のHelloWorldBehaviorをTriggerとTriggerActionに分離すると以下のようになります。</p>
<p>まず、処理を実行するきっかけのTriggerはSystem.Windows.Interactivity.TriggerBase&lt;T&gt;を継承してBehaviorと同様にOnAttachedとOnDetachingを実装します。そして、処理を実行する部分でInvokeActionというメソッドを呼び出します。</p>
</div>
<p>&nbsp;</p>
</div>
<p>&nbsp;</p>
<div class="endscriptcode">
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace Behavior.Sample3
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    /// &lt;summary&gt;
    /// Triggerを作成するにはTriggerBaseを継承する。
    /// ジェネリックパラメータには、Triggerを置けるコントロールを指定する。
    /// &lt;/summary&gt;
    public class ButtonClickTrigger : TriggerBase&lt;Button&gt;
    {
        // OnAttachedとOnDetachingは、Behaviorと同じように作る。
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Click &#43;= this.Button_Click;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= this.Button_Click;
            base.OnDetaching();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // 子要素のActionを実行する。
            this.InvokeActions(e);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;Behavior.Sample3&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows.Controls;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows.Interactivity;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Triggerを作成するにはTriggerBaseを継承する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ジェネリックパラメータには、Triggerを置けるコントロールを指定する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ButtonClickTrigger&nbsp;:&nbsp;TriggerBase&lt;Button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;OnAttachedとOnDetachingは、Behaviorと同じように作る。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAttached()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnAttached();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.AssociatedObject.Click&nbsp;&#43;=&nbsp;<span class="cs__keyword">this</span>.Button_Click;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnDetaching()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.AssociatedObject.Click&nbsp;-=&nbsp;<span class="cs__keyword">this</span>.Button_Click;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnDetaching();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Button_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;子要素のActionを実行する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.InvokeActions(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">次に、メッセージボックスを表示するTriggerActionを定義します。TriggerActionは、System.Windows.Interactivity.TriggerAction&lt;T&gt;を継承して作成します。そして、実行する処理をInvokeメソッドをオーバーライドして定義します。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace Behavior.Sample3
{
    using System.Windows;
    using System.Windows.Interactivity;

    /// &lt;summary&gt;
    /// HelloWorldとメッセージボックスに表示するアクション。
    /// &lt;/summary&gt;
    public class HelloWorldAction : TriggerAction&lt;DependencyObject&gt;
    {
        protected override void Invoke(object parameter)
        {
            MessageBox.Show(&quot;Hello world&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;Behavior.Sample3&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows.Interactivity;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;HelloWorldとメッセージボックスに表示するアクション。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;HelloWorldAction&nbsp;:&nbsp;TriggerAction&lt;DependencyObject&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Invoke(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Hello&nbsp;world&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">TriggerとTriggerActionが出来たので、XAMLで指定します。Triggerはi:Interaction.Triggersに以下のように指定します。</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Button Content=&quot;Custom trigger&quot;&gt;
    &lt;i:Interaction.Triggers&gt;
        &lt;!-- 自作トリガーの設定 --&gt;
        &lt;local:ButtonClickTrigger&gt;
            &lt;!-- HelloWorldと表示する --&gt;
            &lt;local:HelloWorldAction /&gt;
        &lt;/local:ButtonClickTrigger&gt;
    &lt;/i:Interaction.Triggers&gt;
&lt;/Button&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Custom&nbsp;trigger&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:Interaction.Triggers<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;自作トリガーの設定&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span><span class="xaml__tag_start">:ButtonClickTrigger&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;HelloWorldと表示する&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:HelloWorldAction&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/local:ButtonClickTrigger&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:Interaction.Triggers&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Button&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">今回作成したButtonClickTriggerのようにイベントを処理の実行のきっかけとするTriggerクラスの汎用的な実装としてEventTriggerというTriggerがExpression Blend SDKで定義されています。単純にイベントを処理のきっかけにするには、こちらのTriggerを使用します。上記の例をEventTriggerを使用した方法に書き換えると以下のようになります。</p>
<p class="endscriptcode">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Button Content=&quot;Event Trigger&quot;&gt;
    &lt;i:Interaction.Triggers&gt;
        &lt;!-- 自作トリガーの設定 --&gt;
        &lt;i:EventTrigger EventName=&quot;Click&quot;&gt;
            &lt;!-- HelloWorldと表示する --&gt;
            &lt;local:HelloWorldAction /&gt;
        &lt;/i:EventTrigger&gt;
    &lt;/i:Interaction.Triggers&gt;
&lt;/Button&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Event&nbsp;Trigger&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:Interaction.Triggers<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;自作トリガーの設定&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:EventTrigger&nbsp;<span class="xaml__attr_name">EventName</span>=<span class="xaml__attr_value">&quot;Click&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;HelloWorldと表示する&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:HelloWorldAction&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:EventTrigger&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:Interaction.Triggers&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Button&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:20px; font-weight:bold">BehaviorとTrigger＆TriggerActionの使い分け</span></div>
<p>&nbsp;</p>
BehaviorとTrigger&amp;TriggerActionの使い分けですが、基本的にTrigger＆TriggerActionを使用するほうが再利用性が高くなります。Behaviorを使用するのは、処理のきっかけと実行する処理が分離できない特殊なケースの場合に使用します。Expression Blend SDKでは、ドラッグすることで移動可能にするMouseDragElementBehaviorが提供されています。これはドラッグすることと、移動することはきっても切れない（普通クリックだけで移動するという動作は考えられないですよね？）ためBehaviorとして提供されていると考えられます。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Ellipse Width=&quot;50&quot; Height=&quot;50&quot; Fill=&quot;Pink&quot;&gt;
    &lt;i:Interaction.Behaviors&gt;
        &lt;!-- Expression Blendのアセンブリには、いくつか組み込みのBehaviorが提供されている。 --&gt;
        &lt;ei:MouseDragElementBehavior ConstrainToParentBounds=&quot;True&quot; /&gt;
    &lt;/i:Interaction.Behaviors&gt;
&lt;/Ellipse&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Ellipse</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Fill</span>=<span class="xaml__attr_value">&quot;Pink&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:Interaction.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;Expression&nbsp;Blendのアセンブリには、いくつか組み込みのBehaviorが提供されている。&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:MouseDragElementBehavior&nbsp;<span class="xaml__attr_name">ConstrainToParentBounds</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:Interaction.Behaviors&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Ellipse&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">その他には、デモとして一番魅力的なFluidMoveBehaviorも動作のきっかけと動作が切り離せない例になると思います。FluidMoveBehaviorは、コンテナの子要素の移動をなめらかにするものです。以下に動作例を示します。このBehaviorの使用方法としてListBoxなどのItemsPanelに設定することで、要素の削除や挿入時の動作を滑らかにすることができます。</div>
<div class="endscriptcode"><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=http://code.msdn.microsoft.com/site/view/file/22382/1/ScreenCapture_2011-05-22%201.35.36.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="/site/view/file/22382/1/ScreenCapture_2011-05-22%201.35.36.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> <br>
<a id="x_/site/view/file/22382/1/ScreenCapture_2011-05-22%201.35.36.wmv" href="http://code.msdn.microsoft.com/site/view/file/22382/1/ScreenCapture_2011-05-22%201.35.36.wmv">ビデオをダウンロードする</a></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">Behaviorへのプロパティの定義</h1>
<p>BehaviorやTrigger&amp;TriggerActionにはプロパティを定義することが出来ます。これによって、Behaviorの挙動を利用者がカスタマイズすることが出来ます。Behaviorのプロパティは一般的に依存プロパティとして定義します。こうすることでBindingに対応する柔軟な設定が出来るようになります。以下に指定したメッセージをMessageBoxに表示するTriggerActionの実装例を示します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace Behavior.Sample3
{
    using System.Windows;
    using System.Windows.Interactivity;

    /// &lt;summary&gt;
    /// Messageプロパティに設定した文字列をMessageBoxに表示するアクション。
    /// &lt;/summary&gt;
    public class MessageBoxAction : TriggerAction&lt;DependencyObject&gt;
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                &quot;Message&quot;,
                typeof(string),
                typeof(MessageBoxAction),
                new PropertyMetadata(string.Empty));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            // Messageプロパティの値を表示する
            MessageBox.Show(this.Message);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;Behavior.Sample3&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Windows.Interactivity;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Messageプロパティに設定した文字列をMessageBoxに表示するアクション。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MessageBoxAction&nbsp;:&nbsp;TriggerAction&lt;DependencyObject&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;DependencyProperty&nbsp;MessageProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Message&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">typeof</span>(MessageBoxAction),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyMetadata(<span class="cs__keyword">string</span>.Empty));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Message&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">string</span>)GetValue(MessageProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(MessageProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Invoke(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Messageプロパティの値を表示する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__keyword">this</span>.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">以上で、Behaviorについての基本的な説明は終わりです。</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">サンプルプログラムの説明</h1>
<p>サンプルプログラムは、以下の３つのプロジェクトで構成されています。</p>
<ul>
<li>Behavior.Sample1プロジェクト<br>
独自のBehaviorの定義と使用例と、MouseDragElementBehaviorの使用例です。 </li><li>Behavior.Sample2プロジェクト<br>
FluidMoveBehaviorの使用例です。&nbsp; </li><li>Behavior.Sample3プロジェクト<br>
独自のTriggerとTriggerActionの実装と使用例です。 </li></ul>
<br>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<br>
<br>
</div>
</div>
</div>
