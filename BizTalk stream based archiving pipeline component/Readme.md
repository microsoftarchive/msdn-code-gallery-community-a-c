# BizTalk stream based archiving pipeline component
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- BizTalk Server 2010
## Topics
- Streaming
- Custom Pipeline Component
## Updated
- 03/15/2012
## Description

<h1>Introduction</h1>
<p><em>Pipeline components are an advanced aspect of BizTalk often overlooked or often implemented in a manner that breaks the careful streaming model of BizTalk Server.&nbsp; Implementing pipeline components in a truly stream based way allows BizTalk to process
 messages of arbitrary and effectively unlimited size.&nbsp; This example shows how to use&nbsp;a stream to archive received messages in a way that avoids reading the entire message into memory.&nbsp;
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Once build this component can be added to the [Drive]:\Program Files (x86)\Microsoft BizTalk Server 2010\Pipeline Components directory and then be used from Visual Studio in BizTalk Pipelines (*.btp).</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The key to this sample is the ArchivingStream class that extends Stream and implements IDisposable.&nbsp; The constructor to this class takes a stream and an archive path as parameters.&nbsp;
</em></p>
<p>The StreamingArchive class instantiates an instance of ArchivingStream in the Execute method, adds this new stream as a resource to the ResourceTracker of the IPipelineContext so that BizTalk's infrastructure can track and eventually clean it up.&nbsp; This
 new stream instance then replaces the original body part of the message.&nbsp;</p>
<p>The stream based nature of BizTalk means that the archiving happens as later stage component call Read() on the message body stream.&nbsp; This avoids loading the entire message into memory and is the real key.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public Microsoft.BizTalk.Message.Interop.IBaseMessage Execute(Microsoft.BizTalk.Component.Interop.IPipelineContext pc, Microsoft.BizTalk.Message.Interop.IBaseMessage inmsg)
{
    if (_ArchiveFiles)
    {
        string archiveFileName = inmsg.Context.Read(_FileNameProperty, _FileNamePropertyNamespace) as string;
        if (archiveFileName != null &amp;&amp; !string.IsNullOrEmpty(archiveFileName))
        {
            if (archiveFileName.Contains(&quot;\\&quot;))
                archiveFileName = archiveFileName.Substring(archiveFileName.LastIndexOf(&quot;\\&quot;) &#43; 1);

            ArchivingStream archivingStream = new ArchivingStream(inmsg.BodyPart.Data, _ArchivePath &#43; &quot;\\&quot; &#43; archiveFileName);
            pc.ResourceTracker.AddResource(archivingStream);
            inmsg.BodyPart.Data = archivingStream;
        }
    }
    return inmsg;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;Microsoft.BizTalk.Message.Interop.IBaseMessage&nbsp;Execute(Microsoft.BizTalk.Component.Interop.IPipelineContext&nbsp;pc,&nbsp;Microsoft.BizTalk.Message.Interop.IBaseMessage&nbsp;inmsg)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_ArchiveFiles)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;archiveFileName&nbsp;=&nbsp;inmsg.Context.Read(_FileNameProperty,&nbsp;_FileNamePropertyNamespace)&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(archiveFileName&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;!<span class="cs__keyword">string</span>.IsNullOrEmpty(archiveFileName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(archiveFileName.Contains(<span class="cs__string">&quot;\\&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;archiveFileName&nbsp;=&nbsp;archiveFileName.Substring(archiveFileName.LastIndexOf(<span class="cs__string">&quot;\\&quot;</span>)&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ArchivingStream&nbsp;archivingStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ArchivingStream(inmsg.BodyPart.Data,&nbsp;_ArchivePath&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\\&quot;</span>&nbsp;&#43;&nbsp;archiveFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pc.ResourceTracker.AddResource(archivingStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;inmsg.BodyPart.Data&nbsp;=&nbsp;archivingStream;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;inmsg;&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>StreamingArchive.cs - Actual pipeline component that can be used from a BizTalk Pipeline (*.btp) to archive files.&nbsp; This class contains the properties for configuring the pipeline component as well as the Execute method called by the BizTalk infrastructure.&nbsp;
</em></li><li><em><em>ArchivingStream&nbsp;- This stream class is responsible for writing out the file archive as the original base stream is read.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on archiving pipeline components see Steef-Jan's excellent example here:
<a href="http://code.msdn.microsoft.com/BizTalk-Messaging-Archive-6208b57f">http://code.msdn.microsoft.com/BizTalk-Messaging-Archive-6208b57f</a>&nbsp;
</em></p>
<p><em>This example was built using the BizTalk Service Pipeline Component Wizard available at
<a href="http://btsplcw.codeplex.com/">http://btsplcw.codeplex.com/</a>.&nbsp; This wizard makes creating pipeline component much easier.&nbsp; I cannot recommend it enough.&nbsp;
</em></p>
