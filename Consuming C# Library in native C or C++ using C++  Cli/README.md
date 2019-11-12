# Consuming C# Library in native C or C++ using C++ / Cli
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Interop
## Topics
- Interop
## Updated
- 11/12/2011
## Description

<h1>Introduction</h1>
<p><em>In order to consume a .Net library [C# class library] in native application using C&#43;&#43;/CLI. This approach avoids the tlb and registering headache. This approach enables to write better interface to native application. More control on the interface.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The solution created using VS2010.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span class="Apple" style="widows:2; text-transform:none; background-color:#ffffff; text-indent:0px; letter-spacing:normal; font:13px/19px 'Lucida Grande','Lucida Sans Unicode',Arial,sans-serif; white-space:normal; orphans:2; color:#565555; word-spacing:0px">In
 here I'll explain how to consume a C# library in native C or C&#43;&#43; with out using tlb export and import.
</p>
<div></div>
<div>Step 1. Create a empty solution.</div>
<div>Step 2. Load the C# project.</div>
<div>Step 3.&nbsp;Create a C&#43;&#43; project in Visual Studio. Lets call it Wrapper.</div>
<div><span>&nbsp; &nbsp; Choose empty project template.</span></div>
<div><span><span>&nbsp; &nbsp; After it is created change the settings.</span><br>
</span></div>
<div><span><span><span>&nbsp; &nbsp; Open project properties.</span><br>
</span></span></div>
<div>
<ol style="list-style-type:decimal">
<li>&nbsp; &nbsp; Go to Configuration properties -&gt; General
<ol style="list-style-type:decimal">
<li>change configuration type to<strong><span class="Apple">&nbsp;</span>Dynamic Library .dll</strong>
</li><li>change Common Language Runtime Support to &nbsp;&nbsp;<strong>Common Language Runtime Support&nbsp;(/clr)</strong>
</li></ol>
</li><li>Go to Common Properties -&gt; Framework and References
<ol style="list-style-type:decimal">
<li>Add new reference. Add the C# project.&nbsp; </li></ol>
</li></ol>
</div>
<div><span><span>Step 4: Create .cpp file in the Wrapper. Lets call it Test.cpp</span></span></div>
<div>Step 5: Add the namespace of the C# class in the Test.cpp after you Inculde statements.</div>
<div>like this.</div>
</span>
<p></p>
<div><span><span><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#include&nbsp;&quot;Stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;stdio.h&quot;</span>&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Runtime::InteropServices;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;MyLibrary::SomeStuff;&nbsp;
now&nbsp;you&nbsp;can&nbsp;write&nbsp;functions&nbsp;that&nbsp;can&nbsp;consume&nbsp;C#&nbsp;classes&nbsp;and&nbsp;methods.&nbsp;
<span class="cpp__datatype">int</span>&nbsp;getUserName(<span class="cpp__datatype">char</span>*&nbsp;uname)&nbsp;
{&nbsp;
UserManagement&nbsp;^&nbsp;umgmt&nbsp;=&nbsp;gcnew&nbsp;UserManagement();&nbsp;
<span class="cpp__com">//&nbsp;UserManagement&nbsp;is&nbsp;a&nbsp;C#&nbsp;class&nbsp;MyLibrary::SomeStuff</span>&nbsp;
String&nbsp;^&nbsp;managedname&nbsp;=&nbsp;umgmt.GetUserName();&nbsp;
<span class="cpp__com">//&nbsp;I&nbsp;expect&nbsp;uname&nbsp;is&nbsp;initialized</span>&nbsp;
copyManagedStringToCharPointer(uname&nbsp;,&nbsp;managedname);&nbsp;
}&nbsp;
<span class="cpp__keyword">void</span>&nbsp;copyManagedStringToCharPointer(<span class="cpp__datatype">char</span>&nbsp;target[],System::String&nbsp;^&nbsp;inputString)&nbsp;
{&nbsp;
<span class="cpp__datatype">int</span>&nbsp;maxSize&nbsp;=&nbsp;inputString-&gt;Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;maxSize&nbsp;&gt;&nbsp;<span class="cpp__number">0</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;index&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;index&nbsp;&lt;&nbsp;maxSize;&nbsp;&#43;&#43;index&nbsp;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;target[index]&nbsp;=&nbsp;(<span class="cpp__datatype">char</span>)inputString-&gt;<span class="cpp__keyword">default</span>[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;target[maxSize]&nbsp;=&nbsp;<span class="cpp__string">'\0'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;&nbsp;&nbsp;&nbsp;</span><br>
</span></span></div>
<p></p>
<div><span><span><span>Step 6. In order to use this in native C or C&#43;&#43; you function must be exposed to lib. so you need to put&nbsp;</span></span></span></div>
<div><span><span><span>__declspec(dllexport) infront of your function and you need to expose this as a c code. So it should be</span></span></span></div>
<p></p>
<div><span><span><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="js">#ifdef&nbsp;__cplusplus&nbsp;
&nbsp;&nbsp;&nbsp;extern&nbsp;<span class="js__string">&quot;C&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
#endif&nbsp;
__declspec(dllexport)&nbsp;&nbsp;int&nbsp;getUserName(char*&nbsp;uname)&nbsp;
<span class="js__brace">{</span>&nbsp;
UserManagement&nbsp;^&nbsp;umgmt&nbsp;=&nbsp;gcnew&nbsp;UserManagement();&nbsp;
<span class="js__sl_comment">//&nbsp;UserManagement&nbsp;is&nbsp;a&nbsp;C#&nbsp;class&nbsp;MyLibrary::SomeStuff</span>&nbsp;
<span class="js__object">String</span>&nbsp;^&nbsp;managedname&nbsp;=&nbsp;umgmt.GetUserName();&nbsp;
<span class="js__sl_comment">//&nbsp;I&nbsp;expect&nbsp;uname&nbsp;is&nbsp;initialized</span>&nbsp;
copyManagedStringToCharPointer(uname&nbsp;,&nbsp;managedname);&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__operator">void</span>&nbsp;copyManagedStringToCharPointer(char&nbsp;target[],System::<span class="js__object">String</span>&nbsp;^&nbsp;inputString)&nbsp;
<span class="js__brace">{</span>&nbsp;
int&nbsp;maxSize&nbsp;=&nbsp;inputString-&gt;Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(&nbsp;maxSize&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;index&nbsp;&lt;&nbsp;maxSize;&nbsp;&#43;&#43;index&nbsp;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;target[index]&nbsp;=&nbsp;(char)inputString-&gt;<span class="js__statement">default</span>[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;target[maxSize]&nbsp;=&nbsp;<span class="js__string">'\0'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
#ifdef&nbsp;__cplusplus&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
#endif&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span></span></span></div>
<p></p>
<div></div>
<p></p>
<p></p>
<div>Step 7: There is one more thing you need to do is create a header file with all the functions that you wan to use in native.</div>
<div>so Test.h</div>
<p></p>
<div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#ifdef&nbsp;__cplusplus</span>&nbsp;
<span class="cpp__keyword">extern</span>&nbsp;<span class="cpp__string">&quot;C&quot;</span>&nbsp;
{<span class="cpp__preproc">&nbsp;
#endif</span>&nbsp;
<span class="cpp__keyword">__declspec</span>(<span class="cpp__keyword">dllexport</span>)&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;getUserName(<span class="cpp__datatype">char</span>*&nbsp;uname);<span class="cpp__preproc">&nbsp;
#ifdef&nbsp;__cplusplus</span>&nbsp;
&nbsp;&nbsp;}<span class="cpp__preproc">&nbsp;
#endif</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p></p>
<div></div>
<div>Dont forget to add Test.h in Test.cpp in the include list.</div>
<div></div>
<div>Step 8: Now if you complie this you could see Wrapper.dll and Wrapper.lib</div>
<div></div>
<div>Step 9: Now consuming in native c or c&#43;&#43;</div>
<div>Open project properties.</div>
<div>
<ol style="list-style-type:decimal">
<li>In Common Properties -&gt; Framework and References
<ol style="list-style-type:decimal">
<li>Add Wrapper Project reference. </li></ol>
</li><li>In Configuration Properties --&gt; C/C&#43;&#43;
<ol style="list-style-type:decimal">
<li>Additional Include Directories<span class="Apple">&nbsp;</span><strong>Added the Wrapper Source directory.<span class="Apple">&nbsp;</span></strong>So that you can include Test.h
</li></ol>
</li><li>In Configuration Properties --&gt; Linker --&gt; Input
<ol style="list-style-type:decimal">
<li>Additional Dependencies<span class="Apple">&nbsp;</span><strong>Add the Wrapper project Output directory.<span class="Apple">&nbsp;</span></strong>So that linker can find Wrapper.Lib and link to Wrapper.dll
</li></ol>
</li></ol>
Step 10: You can include Test.h in C or C&#43;&#43; native and start calling all the&nbsp;functions.</div>
<div></div>
<div><span style="color:#00ff00; font-size:medium">Registering to C# Events&nbsp;</span></div>
<div></div>
<div>Refer the constructor in SampleWrapper.h in the attached source code.</div>
<p></p>
<p><span style="color:#000000; font-size:small"><strong>&nbsp;Debugging TIP:</strong></span></p>
<p>1. In this kind of solution you can either debug managed implementation or unmanaged implementation.</p>
<p>2. To debug the managed[Wrapper] implmentation. Set the Wrapper project as &quot;Startup Project&quot;. Open the properties of the Wrapper Project. Go to &quot;Configuration Properties&quot; and then &quot;Debug&quot;. In the command Locate your exe.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><em><em>source code file Worker.cs - C# Library Implementation.</em></em></em>
</li><li><em>source code file NativeInterface.h - Functions and types for the Native App</em>
</li><li><em>source code file SampleWrapper.h - Wrapper definition</em> </li><li><em>source code file SampleWrapper.cpp - Wrapper Implementation</em> </li><li><em><em>source code file NativeApp.cpp - A Native Application</em></em> </li></ul>
<h1>More Information</h1>
<p><em>This sample is created to solve this issue: <a href="http://social.msdn.microsoft.com/Forums/en-US/csharplanguage/thread/9d6a6533-3da6-45b3-8f2c-b041c69785ec">
http://social.msdn.microsoft.com/Forums/en-US/csharplanguage/thread/9d6a6533-3da6-45b3-8f2c-b041c69785ec</a></em></p>
