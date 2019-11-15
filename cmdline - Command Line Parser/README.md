# cmdline - Command Line Parser
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Console
## Topics
- Command Line Arguments
## Updated
- 04/09/2012
## Description

<h2 class="endscriptcode">Introduction</h2>
<div>Dealing with command line arguments can be tricky.&nbsp; .NET does some rudimentary command parsing for you but there are a number of things that you probably need to do that it&nbsp;doesn't do that you probably need to&nbsp;do.</div>
<ul>
<li>Parse the command line into switches i.e. &quot;/E&quot;, switches with arguments &quot;/F:Filename.txt&quot; and parameters (no switch)
</li><li>Parse switches with options &quot;/Y-&quot; </li><li>Throw exceptions with unknown switches or invalid values </li></ul>
<div>
<h3 class="endscriptcode">Install From NuGet</h3>
<h3 class="endscriptcode"><em>&nbsp;<img src="http://i1.code.msdn.s-msft.com/command-line-parser-library-a8ba828a/image/file/25293/1/cmdlineicon.png" alt="" width="99" height="85">&nbsp;</em></h3>
<p>The easiest way to add this to your project is with <a href="http://nuget.org">
NuGet</a></p>
<pre style="font-family:Consolas; font-size:12px; color:black; background:none repeat scroll 0% 0% white">PM&gt;&nbsp;install-package&nbsp;<a href="http://nuget.org/List/Packages/CmdLine">cmdline</a>
Successfully&nbsp;installed&nbsp;'CmdLine&nbsp;1.0.0.720'.
Successfully&nbsp;added&nbsp;'CmdLine&nbsp;1.0.0.720'&nbsp;to&nbsp;CleanProject.</pre>
</div>
<h1>Using CmdLine</h1>
<div>This library provides a very simple way to parse the command line.&nbsp;It operates in one of two modes.</div>
<h3 class="endscriptcode">Argument Mode</h3>
<div class="endscriptcode">With this mode you begin by declaring a class with properties decorated with the [CommandLineArguments] attribute.</div>
<div>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">[CommandLineArguments(Program&nbsp;=&nbsp;<span class="cs__string">&quot;SimpleCopy&quot;</span>,&nbsp;Title&nbsp;=&nbsp;<span class="cs__string">&quot;Simple&nbsp;Copy&nbsp;Title&quot;</span>,&nbsp;Description=<span class="cs__string">&quot;Sample&nbsp;copy&nbsp;command&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SimpleCopyArguments&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CommandLineParameter(Command&nbsp;=&nbsp;<span class="cs__string">&quot;?&quot;</span>,&nbsp;Default&nbsp;=&nbsp;<span class="cs__keyword">false</span>,&nbsp;Description&nbsp;=&nbsp;<span class="cs__string">&quot;Show&nbsp;Help&quot;</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Help&quot;</span>,&nbsp;IsHelp&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;Help&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CommandLineParameter(Name&nbsp;=&nbsp;<span class="cs__string">&quot;source&quot;</span>,&nbsp;ParameterIndex&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;Required=<span class="cs__keyword">true</span>,&nbsp;Description&nbsp;=&nbsp;<span class="cs__string">&quot;Specifies&nbsp;the&nbsp;file&nbsp;or&nbsp;files&nbsp;to&nbsp;be&nbsp;copied.&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Source&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CommandLineParameter(Name&nbsp;=&nbsp;<span class="cs__string">&quot;destination&quot;</span>,&nbsp;ParameterIndex&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;Description&nbsp;=&nbsp;<span class="cs__string">&quot;Specifies&nbsp;the&nbsp;directory&nbsp;and/or&nbsp;filename&nbsp;for&nbsp;the&nbsp;new&nbsp;file(s).&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Destination&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CommandLineParameter(Command&nbsp;=&nbsp;<span class="cs__string">&quot;A&quot;</span>,&nbsp;Required&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;Description&nbsp;=&nbsp;<span class="cs__string">&quot;Indicates&nbsp;an&nbsp;ASCII&nbsp;text&nbsp;file&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;ASCIITextFile&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CommandLineParameter(Command&nbsp;=&nbsp;<span class="cs__string">&quot;B&quot;</span>,&nbsp;Description&nbsp;=&nbsp;<span class="cs__string">&quot;Indicates&nbsp;a&nbsp;binary&nbsp;file.&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;BinaryFile&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;etc.</span>&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Then you parse the command line which will be interpreted based on the CommandLineParameter attributes.&nbsp; If the command line is invalid, it will throw a CommandLineException which contains an ArgumentHelp class which you can use to provide help on valid
 command line arguments.</div>
<div>&nbsp;</div>
<div>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;arguments&nbsp;=&nbsp;CommandLine.Parse&lt;SimpleCopyArguments&gt;();&nbsp;
}&nbsp;
<span class="cs__keyword">catch</span>&nbsp;(CommandLineException&nbsp;exception)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(exception.ArgumentHelp.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(exception.ArgumentHelp.GetHelpText(Console.BufferWidth));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Or&nbsp;show&nbsp;it&nbsp;in&nbsp;a&nbsp;message&nbsp;box&nbsp;if&nbsp;you&nbsp;like.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(exception.ArgumentHelp.GetHelpText(Console.BufferWidth),&nbsp;Title);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
The help text will be correctly formatted for width allowing you to show the help text on the command line or in a mesage box.</div>
<h1><span>&nbsp;<img src="http://i1.code.msdn.s-msft.com/command-line-parser-library-a8ba828a/image/file/41740/1/simplecopy.png" alt="" width="742" height="325"></span></h1>
<h3>Tokenize Mode</h3>
<div>In Tokenize mode, the class simply Tokenizes the command line and allows you to do what you want with the token collection</div>
<div>In this example, given the command</div>
<div><span style="font-family:courier new,courier">xcopy \customer h:\public\address /s /e /k /p</span></div>
<div>If I were writing my own version of Xcopy I could parse the command line like this</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">bool</span>&nbsp;copySubdirectories;&nbsp;
<span class="cs__keyword">bool</span>&nbsp;copyEmptyDirectories;&nbsp;
&nbsp;
<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;token&nbsp;<span class="cs__keyword">in</span>&nbsp;CommandLine.Tokenize())&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(token.Command.ToLower())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;s&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;copySubdirectories&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;e&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;copyEmptyDirectories&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;etc.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h2>&nbsp;Change Log</h2>
<p>Version 1.0.4</p>
<p>Modify the CommandArgumentHelp class to use the CommandLineParameter.ValueExample property (if defined) for command syntax.&nbsp; The old version simply used the seperator and command name.</p>
<p>Version 1.0.6</p>
<p>Strong named assembly</p>
<p><em><br>
</em></p>
</div>
