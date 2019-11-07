# Building a web browser in C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- XAML
- system.windows.forms.webbrowser
## Topics
- WebBrowser
## Updated
- 08/04/2012
## Description

<h1>Introduction</h1>
<p>Web Browser is a very simple application that shows the possibility and the easyness&nbsp;to develop a customised browser. In the Visual Studio ToolBox's, you will find a feature called &quot;Web Browser&quot;. When using it, you will see how much powerfull it is.
 By providing options like Go Back, Forward, Refresh,... a lot of work is done for you.Then you just have to add the options you want as adding shortcuts to your favorite sites,show all your preferred sites on starting the application to save some moments.
 You can think about other ideas like making a customized and simple to use browser to your child.</p>
<p>What you need to run this application on windows:</p>
<p><em>To run this application, you will need to have Visual Studio installed to build it to generatethe .exe file, so you can run it every time directly without opening Visual Studio.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>NB: Please don't forget to write the link beginning with &quot;http://&quot; and then you add your web site.</em></p>
<p><em><img id="59491" src="59491-untitled.jpg" alt="" width="482" height="301"><br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void downloadButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.Navigate(webSiteAdr.Text);
        }

        private void refreshButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void forwardButtonClick(object sender, RoutedEventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void helpButtonClick(object sender, RoutedEventArgs e)
        {
            //open my personal page on msdn.microsoft
            webBrowser1.Navigate(&quot;http://social.msdn.microsoft.com/profile/houssem%20dellai/&quot;);
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;downloadButtonClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1.Navigate(webSiteAdr.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;refreshButtonClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;backButtonClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1.GoBack();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;forwardButtonClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1.GoForward();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;helpButtonClick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//open&nbsp;my&nbsp;personal&nbsp;page&nbsp;on&nbsp;msdn.microsoft</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1.Navigate(<span class="cs__string">&quot;http://social.msdn.microsoft.com/profile/houssem%20dellai/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml.cs is the file containing the logical code - the code of every button and their effects.</em>
</li><li><em><em><em>MainWindow.xaml</em> - this file contains the declaration of buttons and the Web Browser.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em><em>Feel free to add your magic on this application, and to contact me whenever you want.</em></em></p>
