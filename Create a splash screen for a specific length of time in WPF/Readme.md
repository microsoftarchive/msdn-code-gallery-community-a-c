# Create a splash screen for a specific length of time in WPF
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Splash Screen
## Updated
- 06/14/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This sample identifies how to create a splash screen easily by WPF&nbsp;</span></p>
<p><span style="font-size:medium"><strong>Building the Sample</strong></span></p>
<h2>Adding a basic splash screen</h2>
<p>Adding &nbsp;a Splash Screen to a WPF application is very easy :</p>
<p>1-Create a WPF application using Visual Studio. And add your Splash Screen image to the project</p>
<p>2-<span>change the build action of your image Properties&nbsp;to &ldquo;SplashScreen&rdquo;.</span></p>
<p><span><img id="95940" src="95940-splash.png" alt="" width="256" height="249"><br>
</span></p>
<p>Now your splash screen will be seen before the main window of your application .</p>
<p>---------------------------------------------------------------------------------------------------------------------------<br>
<strong><span style="font-size:large">If you want to create a splash screen with WPF application for specific lenght of time&nbsp;</span></strong></p>
<h3><span style="font-size:medium">Step 1 :</span></h3>
<p>1-Create a WPF application using Visual Studio. And add your Splash Screen image to the project</p>
<p>2-Make sure that the build action of your image Properties is set to &quot;<span>Resource</span>&quot; Not &ldquo;SplashScreen&rdquo;.</p>
<h3>Step 2 :</h3>
<h3><span>1-Open the App.xaml file and r<strong>emove the StartupUri tag seen below in line 4</strong>.</span>&nbsp;</h3>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Application x:Class=&quot;Splash_Screen.App&quot;
             xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
             xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
             StartupUri=&quot;MainWindow.xaml&quot;&gt;
    &lt;Application.Resources&gt;
         
    &lt;/Application.Resources&gt;
&lt;/Application&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Application</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;Splash_Screen.App&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">StartupUri</span>=<span class="xaml__attr_value">&quot;MainWindow.xaml&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Application</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Application.Resources&gt;&nbsp;
<span class="xaml__tag_end">&lt;/Application&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small"><strong>2- <span>Open the App.xaml.cs and change it with this code :<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Splash_Screen
{
    /// &lt;summary&gt;
    /// Interaction logic for App.xaml
    /// &lt;/summary&gt;
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1500; // Miliseconds
        private const int SPLASH_FADE_TIME = 500;     // Miliseconds

        protected override void OnStartup(StartupEventArgs e)
        {
            // Step 1 - Load the splash screen
            SplashScreen splash = new SplashScreen(&quot;splash.png&quot;);
            splash.Show(false, true);

            // Step 2 - Start a stop watch
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Step 3 - Load your windows but don't show it yet
            base.OnStartup(e);
            MainWindow main = new MainWindow();

            // Step 4 - Make sure that the splash screen lasts at least two seconds
            timer.Stop();
            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash &gt; 0)
                Thread.Sleep(remainingTimeToShowSplash);

            // Step 5 - show the page
            splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));
            main.Show();
        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Configuration;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Diagnostics;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Splash_Screen&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Interaction&nbsp;logic&nbsp;for&nbsp;App.xaml</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;App&nbsp;:&nbsp;Application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;MINIMUM_SPLASH_TIME&nbsp;=&nbsp;<span class="cs__number">1500</span>;&nbsp;<span class="cs__com">//&nbsp;Miliseconds</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;SPLASH_FADE_TIME&nbsp;=&nbsp;<span class="cs__number">500</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Miliseconds</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnStartup(StartupEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;1&nbsp;-&nbsp;Load&nbsp;the&nbsp;splash&nbsp;screen</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SplashScreen&nbsp;splash&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SplashScreen(<span class="cs__string">&quot;splash.png&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;splash.Show(<span class="cs__keyword">false</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;2&nbsp;-&nbsp;Start&nbsp;a&nbsp;stop&nbsp;watch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stopwatch&nbsp;timer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Stopwatch();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Start();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;3&nbsp;-&nbsp;Load&nbsp;your&nbsp;windows&nbsp;but&nbsp;don't&nbsp;show&nbsp;it&nbsp;yet</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnStartup(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MainWindow&nbsp;main&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MainWindow();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;4&nbsp;-&nbsp;Make&nbsp;sure&nbsp;that&nbsp;the&nbsp;splash&nbsp;screen&nbsp;lasts&nbsp;at&nbsp;least&nbsp;two&nbsp;seconds</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Stop();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;remainingTimeToShowSplash&nbsp;=&nbsp;MINIMUM_SPLASH_TIME&nbsp;-&nbsp;(<span class="cs__keyword">int</span>)timer.ElapsedMilliseconds;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(remainingTimeToShowSplash&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(remainingTimeToShowSplash);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;5&nbsp;-&nbsp;show&nbsp;the&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;main.Show();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong> </strong></div>
<div class="endscriptcode">What actually i do :<br>
<ol>
<li>Add two integer variables, one for the minimum time, 1.5 seconds, and one for the splash screen fade time, .5 seconds.
</li><li>Override the OnStartup method. </li><li>Add a SplashScreen object using the image you added earlier and show it. </li><li>Add a StopWatch object to monitor the time and start timing. </li><li>Load the Window object that previously was being loaded by the StartupUri, but don&rsquo;t show the window yet.
</li><li>Stop the StopWatch and then see how much time has elapsed. </li><li>If the time is less than 1.5 seconds sleep the remaining time. </li><li>Stop the SplashScreen. </li><li>show your window. </li></ol>
&nbsp;</div>
<div class="endscriptcode"><strong>
<div class="endscriptcode" style="display:inline!important">
<ol style="display:inline!important">
<li style="display:inline!important">I hope to be useful :)&nbsp; </li></ol>
</div>
</strong></div>
</span><br>
&nbsp;</strong></span></div>
<div class="endscriptcode"><span style="font-size:small"><strong><br>
</strong></span></div>
