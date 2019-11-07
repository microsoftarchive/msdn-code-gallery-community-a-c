# C++ Text Speaker
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C++
- Speech
## Topics
- Text to Speech
## Updated
- 10/29/2011
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Making the computer &quot;speak&quot; can improve the user-interface experience of an application. A C&#43;&#43; class is presented here, to simplify SAPI programming, hiding the complexity of COM and of the underlying SAPI text-to-speech engine.&nbsp;</span></p>
<p><span style="font-size:small">An MFC dialog-based application demoing text-to-speech in C&#43;&#43; using SAPI is provided here.</span></p>
<p><span style="font-size:small">(However, the text speaker class can be reused also in non-MFC projects.)</span></p>
<p><span style="font-size:small"><br>
</span></p>
<h1>Description</h1>
<p><span style="font-size:small">The details of initializing COM, initializing SAPI text-to-speech engine, setting the default voice, etc. are hidden in the implementation of the
<strong>CTextSpeaker</strong> C&#43;&#43; class. Thanks to the C&#43;&#43; <em>RAII</em> pattern, initialization and cleanup code can be ignored by the class user: the only thing that he/she has to do to make the computer speak some text is to call the
<em>CTextSpeaker::Speak()</em> method, passing a Unicode string to it.e.g.:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">CTextSpeaker speaker;
speaker.Speak(L&quot;Hello world&quot;);
</pre>
<div class="preview">
<pre class="cplusplus">CTextSpeaker&nbsp;speaker;&nbsp;
speaker.Speak(L<span class="cpp__string">&quot;Hello&nbsp;world&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="font-size:small">The <em>CTextSpeaker</em> class is implemented in the header file
<strong>TextSpeaker.h</strong>. This file must be included in projects that use this wrapper class. Another file worth noting is
<em>ComAutoInit.h</em>; in this file a C&#43;&#43; RAII class to automatically initialize and cleanup COM is defined.</span></p>
<p><span style="font-size:small">The <em>CTextSpeaker</em> class can be used also in non-MFC projects; but ATL must be available: in fact, this class uses some ATL classes like
<em><a title="ATL::CComPtr" href="http://msdn.microsoft.com/en-us/library/ezzw7k98(v=vs.80).aspx" target="_blank">CComPtr</a></em>.</span></p>
<p><span style="font-size:small"><br>
</span></p>
