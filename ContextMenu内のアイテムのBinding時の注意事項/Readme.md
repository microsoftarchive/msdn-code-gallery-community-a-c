# ContextMenu内のアイテムのBinding時の注意事項
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- ViewModel pattern (MVVM)
## Topics
- Data Binding
- ContextMenu
## Updated
- 05/11/2011
## Description

<h1>概要</h1>
<p>ContextMenuのDataContextは、初回表示時に親要素のDataContextを取得します。その後、親のDataContextに変更があってもContextMenuのDataContextは更新されません。このサンプルは、この問題の確認と、この問題を回避するBindingの方法について説明します。</p>
<h1>サンプルプログラムの前提条件</h1>
<p>このサンプルプログラムを理解するために必要な前提知識を以下に示します。</p>
<ul>
<li>Model View ViewModel パターンによる実装を理解できる </li><li>基本的なWPFの使い方を知っている </li><li>PrismのNotificationObject(INotifyPropertyChangedの実装クラス)とDelegateCommandについて知っている
</li></ul>
<h1>サンプルプログラムの解説</h1>
<p>サンプルプログラムについて説明します。</p>
<h2>MVVMパターン用の基本クラスの作成</h2>
<p>ViewModelの基本クラスになるViewModelBaseクラスを作成します。このサンプルではINotifyPropertyChangedの実装が出来ていればいいのでPrismのNotificationObjectを継承しただけの簡単な実装になっています。</p>
<p>&nbsp;</p>
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace ContextMenuBindSample
{
    using Microsoft.Practices.Prism.ViewModel;

    /// &lt;summary&gt;
    /// ViewModelの基本クラス
    /// &lt;/summary&gt;
    public class ViewModelBase : NotificationObject
    {
    }
}
</pre>
<div class="preview">
<pre class="js">namespace&nbsp;ContextMenuBindSample&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;Microsoft.Practices.Prism.ViewModel;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;ViewModelの基本クラス</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ViewModelBase&nbsp;:&nbsp;NotificationObject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</h2>
<p>&nbsp;</p>
<h2>ContextMenuのMenuItem用のViewModelクラスの作成</h2>
<p>このサンプルでは、ContextMenuのメニューの1項目に対して１つのViewModelをバインドしています。MenuItem用のViewModelの定義を以下に示します。内容は、MenuItemに表示するテキストのプロパティを持っただけの単純なクラスになります。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace ContextMenuBindSample
{
    /// &lt;summary&gt;
    /// ContextMenuの1項目を表すViewModel
    /// &lt;/summary&gt;
    public class MenuItemViewModel
    {
        /// &lt;summary&gt;
        /// ContextMenuに表示するテキスト
        /// &lt;/summary&gt;
        public string Text { get; private set; }

        /// &lt;summary&gt;
        /// ContextMenuに表示するテキストを指定してインスタンスを作成します。
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;text&quot;&gt;ContextMenuに表示するテキスト&lt;/param&gt;
        public MenuItemViewModel(string text)
        {
            this.Text = text;
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;ContextMenuBindSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ContextMenuの1項目を表すViewModel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MenuItemViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ContextMenuに表示するテキスト</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Text&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ContextMenuに表示するテキストを指定してインスタンスを作成します。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;text&quot;&gt;ContextMenuに表示するテキスト&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MenuItemViewModel(<span class="cs__keyword">string</span>&nbsp;text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Text&nbsp;=&nbsp;text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:15px; font-weight:bold">MainWindow用のViewModelクラスの作成</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">次にMenuItemViewModelを持つMainWindowViewModelクラスを定義します。このViewModelには現在のContextMenuの項目を表すCurrentMenuItemというプロパティと、このプロパティの値を変更するコマンドが2種類定義されています。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace ContextMenuBindSample
{
    using Microsoft.Practices.Prism.Commands;

    /// &lt;summary&gt;
    /// MainWindow用のViewModleクラス
    /// &lt;/summary&gt;
    public class MainWindowViewModel : ViewModelBase
    {
        private MenuItemViewModel currentMenuItem;

        /// &lt;summary&gt;
        /// コンストラクタ
        /// &lt;/summary&gt;
        public MainWindowViewModel()
        {
            // コマンドの初期化
            this.SetMenu1Command = new DelegateCommand(
                () =&gt; this.CurrentMenuItem = new MenuItemViewModel(&quot;Menu1&quot;));

            this.SetMenu2Command = new DelegateCommand(
                () =&gt; this.CurrentMenuItem = new MenuItemViewModel(&quot;Menu2&quot;));
        }

        /// &lt;summary&gt;
        /// 現在表示したいContextMenuのMenuItem
        /// &lt;/summary&gt;
        public MenuItemViewModel CurrentMenuItem
        {
            get
            {
                return this.currentMenuItem;
            }

            set
            {
                this.currentMenuItem = value;
                this.RaisePropertyChanged(() =&gt; CurrentMenuItem);
            }
        }

        /// &lt;summary&gt;
        /// Menu1と表示されたMenuをContextMenuに設定するコマンド
        /// &lt;/summary&gt;
        public DelegateCommand SetMenu1Command { get; private set; }

        /// &lt;summary&gt;
        /// Menu2と表示されたMenuをContextMenuに設定するコマンド
        /// &lt;/summary&gt;
        public DelegateCommand SetMenu2Command { get; private set; }
    }
}
</pre>
<div class="preview">
<pre class="js">namespace&nbsp;ContextMenuBindSample&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;Microsoft.Practices.Prism.Commands;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;MainWindow用のViewModleクラス</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;MainWindowViewModel&nbsp;:&nbsp;ViewModelBase&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;MenuItemViewModel&nbsp;currentMenuItem;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;コンストラクタ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MainWindowViewModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;コマンドの初期化</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.SetMenu1Command&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DelegateCommand(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;()&nbsp;=&gt;&nbsp;<span class="js__operator">this</span>.CurrentMenuItem&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MenuItemViewModel(<span class="js__string">&quot;Menu1&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.SetMenu2Command&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DelegateCommand(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;()&nbsp;=&gt;&nbsp;<span class="js__operator">this</span>.CurrentMenuItem&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MenuItemViewModel(<span class="js__string">&quot;Menu2&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;現在表示したいContextMenuのMenuItem</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MenuItemViewModel&nbsp;CurrentMenuItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">this</span>.currentMenuItem;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.currentMenuItem&nbsp;=&nbsp;value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.RaisePropertyChanged(()&nbsp;=&gt;&nbsp;CurrentMenuItem);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Menu1と表示されたMenuをContextMenuに設定するコマンド</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DelegateCommand&nbsp;SetMenu1Command&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;private&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Menu2と表示されたMenuをContextMenuに設定するコマンド</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DelegateCommand&nbsp;SetMenu2Command&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;private&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2 class="endscriptcode">Viewの作成</h2>
<p>ViewModleが作成できたので、今回の本題であるMainWindowを定義します。今回作成する画面のイメージは以下のようなものになります。</p>
<p><img src="22205-ws000043.jpg" alt="" width="465" height="198"></p>
</div>
<div class="endscriptcode">NG Patternというラベルがついている赤い矩形の部分がViewModelの更新にContextMenuのMenuItemが追随しないパターンで、OKPatternが正しく動作するものになります。Menu1とMenu2のボタンは、先ほど定義したMainWindowViewModelのSetMenu1CommandとSetMenu2Commandにバインドしています。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">まずは、MainWindowのDataContextにMainWindowViewModelを設定します。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window x:Class=&quot;ContextMenuBindSample.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:local=&quot;clr-namespace:ContextMenuBindSample&quot;
        Title=&quot;MainWindow&quot; Height=&quot;188&quot; Width=&quot;455&quot; 
        ResizeMode=&quot;NoResize&quot; 
        WindowStartupLocation=&quot;CenterScreen&quot;&gt;
    &lt;Window.DataContext&gt;
        &lt;local:MainWindowViewModel /&gt;
    &lt;/Window.DataContext&gt;
    &lt;Grid&gt;
    &lt;/Grid&gt;
&lt;/Window&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;ContextMenuBindSample.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:ContextMenuBindSample&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;MainWindow&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;188&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;455&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ResizeMode</span>=<span class="xaml__attr_value">&quot;NoResize&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">WindowStartupLocation</span>=<span class="xaml__attr_value">&quot;CenterScreen&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Window</span>.DataContext<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:MainWindowViewModel&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Window.DataContext&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;ボタンは、Commandにバインドしているだけなので、以下のようにシンプルになります。</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Button 
    Content=&quot;Menu1&quot; 
    Height=&quot;23&quot; 
    HorizontalAlignment=&quot;Left&quot; 
    Margin=&quot;17,7,0,0&quot; 
    VerticalAlignment=&quot;Top&quot; 
    Width=&quot;75&quot; 
    Command=&quot;{Binding Path=SetMenu1Command}&quot; /&gt;
&lt;Button 
    Content=&quot;Menu2&quot; 
    Height=&quot;23&quot; 
    HorizontalAlignment=&quot;Left&quot; 
    Margin=&quot;98,7,0,0&quot; 
    VerticalAlignment=&quot;Top&quot; 
    Width=&quot;75&quot; 
    Command=&quot;{Binding Path=SetMenu2Command}&quot; /&gt;
</pre>
<div class="preview">
<pre class="js">&lt;Button&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Content=<span class="js__string">&quot;Menu1&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Height=<span class="js__string">&quot;23&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Margin=<span class="js__string">&quot;17,7,0,0&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;VerticalAlignment=<span class="js__string">&quot;Top&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Width=<span class="js__string">&quot;75&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Command=<span class="js__string">&quot;{Binding&nbsp;Path=SetMenu1Command}&quot;</span>&nbsp;/&gt;&nbsp;
&lt;Button&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Content=<span class="js__string">&quot;Menu2&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Height=<span class="js__string">&quot;23&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Margin=<span class="js__string">&quot;98,7,0,0&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;VerticalAlignment=<span class="js__string">&quot;Top&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Width=<span class="js__string">&quot;75&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Command=<span class="js__string">&quot;{Binding&nbsp;Path=SetMenu2Command}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode">次に、NG PatternのXAMLを示します。これはContextMenuをホストするGridのDataContextにCurrentMenuItemプロパティをバインドして、ContextMenu内のMenuItemのHeaderにMenuItemViewModelのTextプロパティをバインドしています。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid Background=&quot;Red&quot; DataContext=&quot;{Binding Path=CurrentMenuItem}&quot;&gt;
    &lt;Grid.ContextMenu&gt;
        &lt;ContextMenu&gt;
            &lt;!-- 普通にバインド --&gt;
            &lt;MenuItem Header=&quot;{Binding Path=Text}&quot; /&gt;
        &lt;/ContextMenu&gt;
    &lt;/Grid.ContextMenu&gt;
&lt;/Grid&gt;
</pre>
<div class="preview">
<pre class="js">&lt;Grid&nbsp;Background=<span class="js__string">&quot;Red&quot;</span>&nbsp;DataContext=<span class="js__string">&quot;{Binding&nbsp;Path=CurrentMenuItem}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.ContextMenu&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContextMenu&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;普通にバインド&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;MenuItem&nbsp;Header=<span class="js__string">&quot;{Binding&nbsp;Path=Text}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ContextMenu&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ContextMenu&gt;&nbsp;
&lt;/Grid&gt;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;このXAMLでは、初回にContextMenuが表示されたときにCurrentMenuItemに設定されているGridのDataContextがContextMenuに設定されて、そのTextプロパティがMenuItemのHeaderにBindingされます。このためSetMenu1CommandやSetMenu2CommandでCurrentMenuItemプロパティを書き換えてもContextMenuのDataContextは書き換わらないため、ContextMenuのMenuItemの内容は変わりません。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">では、この問題を解決するためのBindingの仕方としてOK Patternの方のXAMLを示します。これはHeaderをBindingする際に、FindAncestorでContextMenuをBindingのSourceになるようにして、ContextMenuのPlacementTargetからContextMenuを設定しているオブジェクト（今回の例ではGrid）を取得して、そのDataContext経由でMenuItemViewModelのTextプロパティにアクセスしています。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid Background=&quot;Green&quot; DataContext=&quot;{Binding Path=CurrentMenuItem}&quot;&gt;
    &lt;Grid.ContextMenu&gt;
        &lt;ContextMenu&gt;
            &lt;!-- コンテキストメニューをホストしてる要素のデータコンテキスト経由でバインド --&gt;
            &lt;MenuItem 
                Header=&quot;{Binding 
                    Path=PlacementTarget.DataContext.Text, 
                    RelativeSource={RelativeSource FindAncestor, AncestorType=ContextMenu}}&quot; /&gt;
        &lt;/ContextMenu&gt;
    &lt;/Grid.ContextMenu&gt;
&lt;/Grid&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;Green&quot;</span>&nbsp;<span class="xaml__attr_name">DataContext</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=CurrentMenuItem}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.ContextMenu<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ContextMenu</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;コンテキストメニューをホストしてる要素のデータコンテキスト経由でバインド&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;MenuItem</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Path=PlacementTarget.DataContext.Text,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RelativeSource={RelativeSource&nbsp;FindAncestor,&nbsp;AncestorType=ContextMenu}}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ContextMenu&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ContextMenu&gt;&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;このように、ContextMenuのDataContextの値が一度表示された時点から更新されないという挙動に影響されないように、ContextMenuをホストしているコントロールのDataContextを使用するようにすることで回避しています。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">因みに、親のDataContextが書き換わらなければ、この問題は起きないのでGridのDataContextの設定を辞めてMenuItemのHeaderプロパティのバインドを{Binding Path=CurrentMenuItem.Text}のようにすることで回避も可能です。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:20px; font-weight:bold">動作確認</span></div>
<p>プログラムの動作確認を行います。プログラムを起動してMenu1ボタンをクリックした状態でNGPatternとOKPatternのContextMenuを表示して内容を確認します。この状態では両者の表示に違いは無く、両方ともMenu1が表示されています。</p>
<p><img src="22206-ws000044.jpg" alt="" width="211" height="106"><img src="22207-ws000045.jpg" alt="" width="206" height="103"></p>
<p>次にMenu2ボタンをクリックしてCurrentMenuItemプロパティの値を書き換えて、上と同じようにContextMenuを表示させます。今度はNG Patternの方はCurrentMenuItemプロパティが書き換わったにも関わらず、古い値が表示されていることが確認できます。</p>
<p><img src="22208-ws000000.jpg" alt="" width="204" height="102"><img src="22209-ws000001.jpg" alt="" width="204" height="100"></p>
<h1>まとめ</h1>
<p>この挙動は、ContextMenuのVisualTreeが親とは関係ない独立した状態で作成されるという仕様によるもののようです。（ソース情報不明のためご存じの方は教えてください）この問題は、DataGridやListViewの項目単位でのContextMenuの表示や、複雑な親子関係にあるViewModelをバインドした画面内でContextMenuを使用した際によくおきると考えられます。</p>
<p>以上です。良いWPFライフを！</p>
<p>&nbsp;</p>
</div>
</div>
<div class="endscriptcode"></div>
