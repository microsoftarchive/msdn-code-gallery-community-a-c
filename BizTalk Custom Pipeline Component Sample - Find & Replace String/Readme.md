# BizTalk Custom Pipeline Component Sample - Find & Replace String
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Studio 2008
- BizTalk Server
- BizTalk Custom Pipeline Component
- MemoryStream
## Topics
- C#
- BizTalk
- Custom Pipeline Component
- MemoryStream
## Updated
- 10/13/2011
## Description

<h1>Introduction</h1>
<p><em>It is a very common requirement to use a custom pipeline in a BizTalk solution to replace a string in a message. However such a simple pipeline component is neither provided by Biztalk Server or the ESB tool kit. The sample code
</em><strong>BizTalk Custom Pipeline Component Sample - Find &amp; Replace String</strong><em> is to provide a pipeline component with basic find and replace function, and it can be further modified to handle complicated senario such as multiple string replacement.
<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample code is build based on BizTalk 2009/Visual Studio 2008, you can directly build it if you have the same platform or copy it to another platform such as BizTalk 2010/</em><em>Visual Studio
</em><em>2010, it should work too, just make sure you add Microsoft.BizTalk.Pipeline.dll as reference.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>When you use the custom pipeline component to build a custom pipeline, you need to provide two properties, &quot;Find String&quot; and &quot;Replace With&quot;.
</em><em>The sample code simply finds a string and replaces with another string. That means if you have two different places in your message need to be replaced, you will need to use the custom pipeline component twice in the encode/decode stage. You can modify
 the code to allow finding multiple strings and replace them with different strings, to do that, you can add additional logic to parse comma delimited string and use the pair of each part to do the replacement.</em><em>&nbsp;
<br>
</em></p>
