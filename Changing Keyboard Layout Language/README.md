# Changing Keyboard Layout Language
## License
- MS-LPL
## Technologies
- Windows Forms
## Topics
- User Controls
- User Interface
## Updated
- 02/25/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In general, developers want to set the layout of keyboard prior to application localized language. In this demonstration, I will develop a simple helper class to be used in windows based applications with custom control in type
 of text box. So, we can make the default input language of this text box as property</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small"><em>Building this sample is just include the sample file or copy and paste it's functions in your soruce code.</em></span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">In more cases some&nbsp;developers need there applications to automatically swich input language in&nbsp;windows forms to target language (i.e. English / Arabic) &nbsp;if you want to set the layout of keyboard prior to application
 localized language.&nbsp;<a id="50309" href="/site/view/file/50309/1/InputLanguageHelper.csharp">InputLanguageHelper.cs</a> I will develop a simple fucntions to do the job. So, we can make the default input language of &nbsp;any&nbsp;text editor control
 as property, and or change it in run time on conrol's get foucs event</span></p>
<p><span style="font-size:small">&nbsp;The code is separated into two parts, one of them deals with keyboard layout and the other is a client which tests this.</span></p>
<p><strong><span style="font-size:small">1- For better performance, get the machine installed language as follows:</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;InputLanguage&nbsp;GetInputLanguageByName(<span class="cs__keyword">string</span>&nbsp;inputName)&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(InputLanguage&nbsp;lang&nbsp;<span class="cs__keyword">in</span>&nbsp;InputLanguage.InstalledInputLanguages)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(lang.Culture.EnglishName.ToLower().StartsWith(inputName))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lang;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<h1><span style="font-size:small">2- Set your preferred language at run time:</span></h1>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetKeyboardLayout(InputLanguage&nbsp;layout)&nbsp;&nbsp;
{&nbsp;&nbsp;
InputLanguage.CurrentInputLanguage&nbsp;=&nbsp;layout;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></h1>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file InputLanguageHelper - Include implementatoin of mentioned method.</em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on changing key boark language see my original post at
<a href="http://www.codeproject.com/Articles/90218/Changing-Keyboard-Layout">http://www.codeproject.com/Articles/90218/Changing-Keyboard-Layout</a></em></p>
