# Chart Control in WPF
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
- WPF
- WPF forms
## Topics
- Charts
- Bar Chart
- Chart Control
- Pie Chart
- Area Chart
- Line Chart
- Scatter Chart
- Column Chart
- Bubble Chart
## Updated
- 02/17/2014
## Description

<h1>Introduction</h1>
<p><em>Chart Control in WPF using WPF Toolkit. This Sample of Application describes how to use Chart Control in your application. There are Different Chart Controls are available in WPF Toolkit which is given below.</em></p>
<p><em>1) Area&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2) Bar</em></p>
<p><em>3) Column&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4) Pie</em></p>
<p><em>5) Line&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 6) Bubble</em></p>
<p><em>7) Scatter<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>To use the chart control in your application you require WPF Toolkit in your application.</em></p>
<p><em>1) You can download WPF Tookit from the below link</em></p>
<p><em><a href="http://wpf.codeplex.com/" target="_blank"><span style="background-color:#00ff00">Download Here</span></a></em></p>
<p>WPF Toolkit is free and open source.</p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">2) Add Reference in your application.</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">If you are not able to display Chart Control in Toolbox.</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">Right Click on Toolbox =&gt; Choose Item =&gt; Click on WPF Component =&gt; Select</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">1) Chart</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">2) Area Series</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">3) Bar Series</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">4) Column Series</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">5) Pie Series</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">6) Line Series</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">7) Bubble Series</span></span></em></p>
<p><em><span style="background-color:#00ff00"><span style="background-color:#ffffff">8) Scatter Series<br>
</span></span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This article presents how to use chart control in WPF using WPF Toolkit. Chart is use to display numerical data, statistical data and data virtualization in graphical format. There are five types of chart control available in WPF Toolkit. There are given
 below. </em></p>
<p><em>************************************************************************************************<br>
</em></p>
<p><em>1) Column Chart</em></p>
<p><em>2) Area Chart</em></p>
<p><em>3) Bar Chart</em></p>
<p><em>4) Pie Chart and</em></p>
<p><em>5) Line Chart</em></p>
<p><em>************************************************************************************************<br>
</em></p>
<p><em>This function contains some list of departments.<br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> private void showChart()
        {
            List&lt;KeyValuePair&lt;string, int&gt;&gt; MyValue = new List&lt;KeyValuePair&lt;string, int&gt;&gt;();
            MyValue.Add(new KeyValuePair&lt;string, int&gt;(&quot;Administration&quot;, 20));
            MyValue.Add(new KeyValuePair&lt;string, int&gt;(&quot;Management&quot;, 36));
            MyValue.Add(new KeyValuePair&lt;string, int&gt;(&quot;Development&quot;, 89));
            MyValue.Add(new KeyValuePair&lt;string, int&gt;(&quot;Support&quot;, 270));
            MyValue.Add(new KeyValuePair&lt;string, int&gt;(&quot;Sales&quot;, 140));

            ColumnChart1.DataContext = MyValue;
            AreaChart1.DataContext = MyValue;
            LineChart1.DataContext = MyValue;
            PieChart1.DataContext = MyValue;
            BarChart1.DataContext = MyValue;
            BubbleSeries1.DataContext = MyValue;
            ScatterSeries1.DataContext = MyValue;
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;showChart()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;KeyValuePair&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;&gt;&nbsp;MyValue&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;KeyValuePair&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyValue.Add(<span class="cs__keyword">new</span>&nbsp;KeyValuePair&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;(<span class="cs__string">&quot;Administration&quot;</span>,&nbsp;<span class="cs__number">20</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyValue.Add(<span class="cs__keyword">new</span>&nbsp;KeyValuePair&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;(<span class="cs__string">&quot;Management&quot;</span>,&nbsp;<span class="cs__number">36</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyValue.Add(<span class="cs__keyword">new</span>&nbsp;KeyValuePair&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;(<span class="cs__string">&quot;Development&quot;</span>,&nbsp;<span class="cs__number">89</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyValue.Add(<span class="cs__keyword">new</span>&nbsp;KeyValuePair&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;(<span class="cs__string">&quot;Support&quot;</span>,&nbsp;<span class="cs__number">270</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyValue.Add(<span class="cs__keyword">new</span>&nbsp;KeyValuePair&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;(<span class="cs__string">&quot;Sales&quot;</span>,&nbsp;<span class="cs__number">140</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ColumnChart1.DataContext&nbsp;=&nbsp;MyValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AreaChart1.DataContext&nbsp;=&nbsp;MyValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LineChart1.DataContext&nbsp;=&nbsp;MyValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PieChart1.DataContext&nbsp;=&nbsp;MyValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BarChart1.DataContext&nbsp;=&nbsp;MyValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BubbleSeries1.DataContext&nbsp;=&nbsp;MyValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ScatterSeries1.DataContext&nbsp;=&nbsp;MyValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h3>1) Column Chart</h3>
<p><img id="108864" src="108864-column%20chart.jpg" alt="" width="405" height="270"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;chartingToolkit:Chart Height=&quot;262&quot; HorizontalAlignment=&quot;Left&quot; 
            Margin=&quot;33,0,0,620&quot; Name=&quot;ColumnChart1&quot; Title=&quot;Total Marks&quot;
            VerticalAlignment=&quot;Bottom&quot; Width=&quot;380&quot;&gt;
                &lt;chartingToolkit:ColumnSeries DependentValuePath=&quot;Value&quot;  IndependentValuePath=&quot;Key&quot; ItemsSource=&quot;{Binding}&quot;
            IsSelectionEnabled=&quot;True&quot;&gt;&lt;/chartingToolkit:ColumnSeries&gt;
            &lt;/chartingToolkit:Chart&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;chartingToolkit</span>:Chart&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;262&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;33,0,0,620&quot;</span><span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ColumnChart1&quot;</span><span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Total&nbsp;Marks&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Bottom&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;380&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;chartingToolkit</span>:ColumnSeries&nbsp;<span class="xaml__attr_name">DependentValuePath</span>=<span class="xaml__attr_value">&quot;Value&quot;</span><span class="xaml__attr_name">IndependentValuePath</span>=<span class="xaml__attr_value">&quot;Key&quot;</span><span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__attr_name">IsSelectionEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:ColumnSeries&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:Chart&gt;</span></pre>
</div>
</div>
</div>
<h3>2) Area Chart</h3>
<p><img id="108857" src="108857-area%20chart.jpg" alt="" width="393" height="264"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;chartingToolkit:Chart  Name=&quot;AreaChart1&quot; Title=&quot;Department&quot; Margin=&quot;828,39,0,629&quot; HorizontalAlignment=&quot;Left&quot; Width=&quot;378&quot;&gt;
                &lt;chartingToolkit:AreaSeries DependentValuePath=&quot;Value&quot;
          IndependentValuePath=&quot;Key&quot; ItemsSource=&quot;{Binding}&quot;
            IsSelectionEnabled=&quot;True&quot;/&gt;
            &lt;/chartingToolkit:Chart&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;chartingToolkit</span>:Chart&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;AreaChart1&quot;</span><span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Department&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;828,39,0,629&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;378&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;chartingToolkit</span>:AreaSeries&nbsp;<span class="xaml__attr_name">DependentValuePath</span>=<span class="xaml__attr_value">&quot;Value&quot;</span><span class="xaml__attr_name">IndependentValuePath</span>=<span class="xaml__attr_value">&quot;Key&quot;</span><span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__attr_name">IsSelectionEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:Chart&gt;</span></pre>
</div>
</div>
</div>
<h3>3) Bar Chart</h3>
<p><img id="108858" src="108858-bar%20chart.jpg" alt="" width="458" height="262"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;chartingToolkit:Chart  Name=&quot;BarChart1&quot; Title=&quot;Department&quot; Margin=&quot;547,307,19,358&quot; Width=&quot;450&quot;&gt;
                &lt;chartingToolkit:BarSeries  DependentValuePath=&quot;Value&quot;
            IndependentValuePath=&quot;Key&quot; ItemsSource=&quot;{Binding}&quot;
            IsSelectionEnabled=&quot;True&quot;/&gt;
            &lt;/chartingToolkit:Chart&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;chartingToolkit</span>:Chart&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;BarChart1&quot;</span><span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Department&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;547,307,19,358&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;450&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;chartingToolkit</span>:BarSeries&nbsp;&nbsp;<span class="xaml__attr_name">DependentValuePath</span>=<span class="xaml__attr_value">&quot;Value&quot;</span><span class="xaml__attr_name">IndependentValuePath</span>=<span class="xaml__attr_value">&quot;Key&quot;</span><span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__attr_name">IsSelectionEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:Chart&gt;</span></pre>
</div>
</div>
</div>
<h3>4) Pie Chart</h3>
<p><img id="108859" src="108859-pie%20chart.jpg" alt="" width="395" height="277"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden"> &lt;chartingToolkit:Chart  Name=&quot;PieChart1&quot; Title=&quot;Department&quot; Width=&quot;380&quot;
            VerticalAlignment=&quot;Top&quot; Margin=&quot;428,39,0,0&quot; Height=&quot;262&quot; HorizontalAlignment=&quot;Left&quot;&gt;
                &lt;chartingToolkit:PieSeries DependentValuePath=&quot;Value&quot;
            IndependentValuePath=&quot;Key&quot; ItemsSource=&quot;{Binding}&quot;
            IsSelectionEnabled=&quot;True&quot; /&gt;
            &lt;/chartingToolkit:Chart&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;chartingToolkit</span>:Chart&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;PieChart1&quot;</span><span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Department&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;380&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;428,39,0,0&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;262&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;chartingToolkit</span>:PieSeries&nbsp;<span class="xaml__attr_name">DependentValuePath</span>=<span class="xaml__attr_value">&quot;Value&quot;</span><span class="xaml__attr_name">IndependentValuePath</span>=<span class="xaml__attr_value">&quot;Key&quot;</span><span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__attr_name">IsSelectionEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:Chart&gt;</span></pre>
</div>
</div>
</div>
<h3>5) Line Chart</h3>
<p><img id="108860" src="108860-line%20chart.jpg" alt="" width="458" height="263"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;chartingToolkit:Chart  Name=&quot;LineChart1&quot; Title=&quot;Department&quot; Width=&quot;450&quot; Margin=&quot;33,309,533,358&quot;&gt;
                &lt;chartingToolkit:LineSeries  DependentValuePath=&quot;Value&quot;
            IndependentValuePath=&quot;Key&quot; ItemsSource=&quot;{Binding}&quot;
            IsSelectionEnabled=&quot;True&quot;/&gt;
            &lt;/chartingToolkit:Chart&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;chartingToolkit</span>:Chart&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LineChart1&quot;</span>&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Department&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;450&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;33,309,533,358&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;chartingToolkit</span>:LineSeries&nbsp;&nbsp;<span class="xaml__attr_name">DependentValuePath</span>=<span class="xaml__attr_value">&quot;Value&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">IndependentValuePath</span>=<span class="xaml__attr_value">&quot;Key&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">IsSelectionEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/chartingToolkit:Chart&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">
<h3>6) Bubble Chart</h3>
</div>
<p><img id="108865" src="108865-bubble.jpg" alt="" width="429" height="307"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;chartingToolkit:Chart Name=&quot;BubbleSeries1&quot; Title=&quot;Department&quot; Width=&quot;420&quot; Height=&quot;300&quot; Margin=&quot;573,570,302,51&quot;&gt;
                &lt;chartingToolkit:BubbleSeries IndependentValuePath=&quot;Key&quot; DependentValuePath=&quot;Value&quot; IsSelectionEnabled=&quot;True&quot; ItemsSource=&quot;{Binding}&quot;&gt;&lt;/chartingToolkit:BubbleSeries&gt;
            &lt;/chartingToolkit:Chart&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;chartingToolkit</span>:Chart&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;BubbleSeries1&quot;</span><span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Department&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;420&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;300&quot;</span><span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;573,570,302,51&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;chartingToolkit</span>:BubbleSeries&nbsp;<span class="xaml__attr_name">IndependentValuePath</span>=<span class="xaml__attr_value">&quot;Key&quot;</span><span class="xaml__attr_name">DependentValuePath</span>=<span class="xaml__attr_value">&quot;Value&quot;</span><span class="xaml__attr_name">IsSelectionEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:BubbleSeries&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:Chart&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h3>7) Scatter Chart</h3>
<p><img id="108866" src="108866-scatter.jpg" alt="" width="427" height="310"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;chartingToolkit:Chart Name=&quot;ScatterSeries1&quot; Title=&quot;Department&quot; Width=&quot;420&quot; Height=&quot;300&quot; Margin=&quot;138,570,737,51&quot;&gt;
                    &lt;chartingToolkit:ScatterSeries IndependentValuePath=&quot;Key&quot; DependentValuePath=&quot;Value&quot; IsSelectionEnabled=&quot;True&quot; ItemsSource=&quot;{Binding}&quot;&gt;&lt;/chartingToolkit:ScatterSeries&gt;
                &lt;/chartingToolkit:Chart&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;chartingToolkit</span>:Chart&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ScatterSeries1&quot;</span>&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Department&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;420&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;300&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;138,570,737,51&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;chartingToolkit</span>:ScatterSeries&nbsp;<span class="xaml__attr_name">IndependentValuePath</span>=<span class="xaml__attr_value">&quot;Key&quot;</span>&nbsp;<span class="xaml__attr_name">DependentValuePath</span>=<span class="xaml__attr_value">&quot;Value&quot;</span>&nbsp;<span class="xaml__attr_name">IsSelectionEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/chartingToolkit:ScatterSeries&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/chartingToolkit:Chart&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
