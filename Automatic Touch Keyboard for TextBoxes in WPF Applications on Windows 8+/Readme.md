# Automatic Touch Keyboard for TextBoxes in WPF Applications on Windows 8+
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- WPF
- Windows 8.1
- Windows 8.1 XAML/C#
## Topics
- On-screen keyboard
## Updated
- 12/16/2013
## Description

<h1>Introduction</h1>
<p><img src="104379-touch%20keyboard.png" id="104379" alt="" width="399" height="95"></p>
<p>Desktop applications running on Windows 8&#43;, such as those built using WPF, behave differently from their Windows Store counterparts when the device running them does not have a physical keyboard available. The difference stems from how Windows 8 works, in
 that it won&rsquo;t automatically display the touch keyboard when an editable textbox takes focus; something that happens automatically for Windows Store applications.</p>
<p><strong>Tip</strong> &ndash; Learn more about the <a href="http://blogs.windows.com/windows/b/windowsexperience/archive/2013/10/29/windows-8-1-is-great-for-touch-mouse-and-keyboard.aspx">
Windows 8.1 input options</a>.</p>
<p>This might not be ideal for your application but the keyboard <em>is</em> still available. The user can manually bring up the touch keyboard anytime by clicking on the taskbar icon, typically in the bottom-right of the screen.&nbsp;</p>
<p><img src="104380-taskbar%20-%20touch%20keyboard%20icon.png" id="104380" alt="" width="85" height="30"></p>
<p>(The keyboard is also available from the charms bar, but it&rsquo;s a few more steps to get it from there)</p>
<p>Of course this isn&rsquo;t the ideal implementation for desktop applications and instead developers wish for a similar experience to that of the Windows Store apps. In this sample i'll show how to use all supported Windows 8 API's to achieve an automatic
 touch keyboard for <strong>WPF Desktop Applications</strong> and also explore some limitations.</p>
<h1>Disclaimer</h1>
<ul>
<li>This is <strong>NOT a formal sample</strong> from the Windows or WPF Product Team,
<span>&nbsp;I&rsquo;m&nbsp;</span>merely a fan of WPF and wanted to get this code sample out to our community
<ul>
<li>While this is NOT a formal sample from Microsoft, at the same time it <span>doesn&rsquo;t&nbsp;</span>use any hidden or unsupported API's, so developers that do their own research and testing can use this type of approach in their applications. Remember,
 this is just a sample! </li></ul>
</li><li>It&rsquo;s impossible for me to claim that this code/approach works perfectly for every app, environment and scenario so please test your applications fully!&nbsp;
</li></ul>
<h1><span style="font-size:40px">Exploring the Sample</span></h1>
<h2>Introduction</h2>
<p>The sample was built with Visual Studio 2013, targets .NET 4.5 and was tested on Windows 8.0 and 8.1. If you have both the same setup on your developer machine then you&rsquo;ll be able to open the solution and run my sample project.</p>
<p><strong>Note, not tested on Windows 7 or XP&nbsp;</strong>&ndash; I have not tested this sample on anything other than Windows 8.0&#43;. For all I know, this will throw an exception if executed on Windows 7, XP, etc. I do plan to test these scenarios further
 when time allows but for now please do your own testing</p>
<h2>Required Project References</h2>
<p>First let&rsquo;s explore the references in the sample project:</p>
<p><img src="104383-sample%20-%20solution%20structure.png" id="104383" alt="" width="253" height="251"></p>
<p>Two things should stand out, <strong>we need references to:</strong></p>
<ul>
<li>UIAutomationClient </li><li>InputPanelConfigurationLib </li></ul>
<p><strong>Add a UIAutomationClient reference</strong></p>
<p>UIAutomationClient.DLL is a standard DLL that can be easily found and added to any project using the Reference Manager, and by searching for &ldquo;UIAU&rdquo; should filter down enough to find:</p>
<p><img src="104384-uiautomationclient%20reference.png" id="104384" alt="" width="627" height="187"></p>
<p><strong>Using IFrameworkInputPane from managed code</strong></p>
<p>For InputPanelConfigurationLib.dll it&rsquo;s a bit trickier; unfortunately this isn&rsquo;t an assembly you can easily reference as it doesn&rsquo;t exist as a DLL. Instead it must be built using the IDL file that can be found in your Windows Kits folder
 under Program Files (x86), here is where to look:</p>
<p>On Windows 8.0: <br>
C:\Program Files (x86)\Windows Kits\8.0\Include\um\InputpanelConfiguration.idl</p>
<p>On Windows 8.1: <br>
c:\Program Files (x86)\Windows Kits\8.1\Include\um\inputpanelconfiguration.idl</p>
<p>To build a DLL from the IDL use the following steps:</p>
<ol>
<li>Start a command prompt </li><li>Use the MIDL compiler tool to build a Type Library TLB file (learn more about MIDL Compiler
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa367300(v=vs.85).aspx">
see here on MSDN</a>)
<ol>
<li>Example: midl /tbld {filename} </li></ol>
</li><li>Use the TLBIMP tool to convert the above generated Type Library (TLB file) into a DLL that .NET can use by running the following command (learn more about Tlbimp.exe
<a href="http://msdn.microsoft.com/en-us/library/tt0cf3sx(v=vs.110).aspx">here on MSDN</a>)
<ol>
<li>Example: TLBIMP.exe InputpanelConfiguration.tlb /publickey:{pathToKey} /delaysign
</li></ol>
</li></ol>
<p>To help make the sample work out-of-the-box I have generated this DLL and included it with the sample project. Keep in mind that my version is not signed and therefore a real file you plan to distribute with your application should probably be signed.</p>
<p><span style="font-size:20px; font-weight:bold">Source Code</span></p>
<p>The sample itself is fairly straight forward, and the main files to review are:</p>
<ul>
<li><strong>MainWindow.cs</strong> - In the <span>Constructor&nbsp;</span>we disable Inking support (or Touch keyboard won't work), we then use Automation to mark all TextBoxes as touch keyboard enabled
</li><li><strong>MainWindow.xaml</strong> - Contains the sample UI to test the keyboard when touch input
<span>occurs&nbsp;</span>and also provide some additional User Controls (button, listbox, checkbox) so that developers can see what
<span>happens&nbsp;</span>when a user clicks on these when keyboard is visible </li><li><strong>InkInputHelper.cs</strong> - Helper code to disable inking (since touch keyboard
<span>doesn&rsquo;t&nbsp;</span>work when Inking is enabled) </li></ul>
<h1><strong>Q&amp;A</strong></h1>
<p><strong>Q: Winform Sample?</strong></p>
<p><strong>A: </strong>Unfortunately my sample will only work with WPF and not WinForm applications, I must be honest I have not done the research to determine if anything is possible for these other type of Desktop Applications, but if time allows I&rsquo;ll
 do the research</p>
<p><span style="font-size:2em">Questions or Corrections?</span></p>
<p>I do hope as more folks try to use this code they can provide me with information on any issues and also ask good questions that can help me further improve this sample. Please post your comments here and I will do what I can to respond.</p>
