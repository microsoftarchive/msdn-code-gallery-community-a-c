# CCS LABS C#: Accessing the Master File Table
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- COM
- File System
- Win32
- Windows Forms
## Topics
- Interop
- File Systems
- Master File Table
## Updated
- 12/17/2013
## Description

<h1>Introduction</h1>
<p><em>A common question in .Net circles is howdo we access the Master File Table? There are plently of discussions on the topic but very little practical help and as yet we have not found a working example for the .Net language. Thanks to code by&nbsp;<span style="color:#000000">StCroixSkipper
 we have developed a small application which uses his library; and present a fully operational console application which reads the MFT and displays all discovered files.</span><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This solution was built using Visual Studio 2010 on a Windows Server 2008 R2 machine. It should operate normally on any&nbsp; Window's operating system from Vista up. If you test this on a Windows XP machine then tell us how it performed in the Q&amp;A
 Section.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>There are three projects in this solution. The main console class, the MFT class, and a USNJournal class - the latter two were provided by
<span style="color:#000000">StCroixSkipper and a discussion can be found here: </span>
</em></p>
<pre style="background:#10100d; color:#e8e8e8; font-family:Consolas"><span style="color:#756f51; font-weight:bold; background-color:#ffffff"><a href="http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/c1550294-d121-4511-ac32-31551497f64e/">http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/c1550294-d121-4511-ac32-31551497f64e/</a></span></pre>
<p>&nbsp;</p>
<p>The main program which calls the MFT scanning functionality is quite short and relatively easy to understand:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
		{
			string[] fExt= new string[1];
			fExt[0] = &quot;exe&quot;;

			Dictionary&lt;ulong, FileNameAndParentFrn&gt; mDict = new Dictionary&lt;ulong, FileNameAndParentFrn&gt;();

			EnumerateVolume.PInvokeWin32 mft = new EnumerateVolume.PInvokeWin32();
			mft.Drive = &quot;C:&quot;;
			mft.EnumerateVolume(out mDict, new string[] { &quot;*&quot; });
			foreach (KeyValuePair&lt;UInt64, FileNameAndParentFrn&gt; entry in mDict)
			{
				FileNameAndParentFrn file = (FileNameAndParentFrn)entry.Value;
				
				Console.WriteLine(file.Name &#43; &quot; &quot; &#43; file.ParentFrn);
			}

			Console.WriteLine(&quot;DONE&quot;);
			Console.ReadKey();  
		}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;fExt=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fExt[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;exe&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dictionary&lt;<span class="cs__keyword">ulong</span>,&nbsp;FileNameAndParentFrn&gt;&nbsp;mDict&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">ulong</span>,&nbsp;FileNameAndParentFrn&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnumerateVolume.PInvokeWin32&nbsp;mft&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EnumerateVolume.PInvokeWin32();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mft.Drive&nbsp;=&nbsp;<span class="cs__string">&quot;C:&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mft.EnumerateVolume(<span class="cs__keyword">out</span>&nbsp;mDict,&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;*&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(KeyValuePair&lt;UInt64,&nbsp;FileNameAndParentFrn&gt;&nbsp;entry&nbsp;<span class="cs__keyword">in</span>&nbsp;mDict)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileNameAndParentFrn&nbsp;file&nbsp;=&nbsp;(FileNameAndParentFrn)entry.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(file.Name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;file.ParentFrn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DONE&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;As expressed there is nothing to this code. The actual MFT library is more complicated and you will need to read about the MFT prior to trying to understand the code</div>
