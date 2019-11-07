# Cyrillic to Roman Transliteration Utility
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
- CLR
- .NET Framework 4.0
## Topics
- Character Encoding
## Updated
- 06/28/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">The Cyrillic to Roman Transliteration Utility (CyrillicToRoman.exe) is a command-line utility that transliterates modern Cyrillic characters to the Roman character set. Its syntax is:</span></p>
<pre><span style="font-size:small">CyrillicToRoman &lt;sourceFile&gt; &lt;destinationFile&gt;</span></pre>
<p><span style="font-size:small">where <strong>&lt;sourceFile&gt;</strong> is the path and name of a text file that contains Cyrillic text to transliterate, and
<strong>&lt;destinationFile&gt;</strong> is the path and name of the file that contains the transliterated text.</span></p>
<p><span style="font-size:small">The utility illustrates the .NET Framework's support for a custom encoder fallback strategy that uses replacement fallback.&nbsp;</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">The example is packaged with an MSBuild project file that targets the .NET Framework Version 4. Download the sample code files to your computer. Open the solution (CyrillicToRoman.sln) in Visual Studio 2010 and build the solution.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">The Cyrillic to Roman Conversion Utility illustrates the extensibility of character encoding in the .NET
</span><span style="font-size:small">Framework. An encoding system consists of an encoder and a decoder. The encoder is
</span><span style="font-size:small">responsible for translating a sequence of characters into a sequence of bytes. The
</span><span style="font-size:small">decoder is responsible for translating the sequence of bytes into a sequence of
</span><span style="font-size:small">characters. The .NET Framework supports a sizable number of code page and Unicode
</span><span style="font-size:small">encodings, and also allows the Encoding class to be overridden to support otherwise
</span><span style="font-size:small">unsupported encodings. It also allows an encoder and a decoder's handling of
</span><span style="font-size:small">characters and bytes, respectively, that cannot be mapped to be customized.
</span><span style="font-size:small">Broadly, an encoder or a decoder can handle data that it cannot map by throwing
</span><span style="font-size:small">an exception or by using some alternate mapping.
</span></p>
<p><span style="font-size:small">The transliteration utility works by instantiating an
<strong>Encoding</strong> object that represents </span><span style="font-size:small">the Windows-1252 encoding. This encoding system supports ASCII characters in the
</span><span style="font-size:small">range from U&#43;0000 to U&#43;00FF. Because modern Cyrillic characters occupy the range from
</span><span style="font-size:small">U&#43;0410 to U&#43;044F, they do not automatically map to the Windows-1252 encoding. When
</span><span style="font-size:small">the utility instantiates its Encoding object, it passes its constructor an instance
</span><span style="font-size:small">of a class named CyrillicToRomanFallback that is derived from EncoderFallback. This
</span><span style="font-size:small">class maintains an internal table that maps modern Cyrillic characters to one or more
</span><span style="font-size:small">Roman characters.</span></p>
<p><span style="font-size:small">When the encoder encounters a character that it cannot encode, it calls the fallback
</span><span style="font-size:small">object's <strong>CreateFallbackBuffer</strong> method. This method instantiates a
<strong>CyrillicToRomanFallbackBuffer </strong></span><span style="font-size:small">object (a subclass of the
<strong>EncoderFallbackBuffer</strong> class) and passes its constructor </span><span style="font-size:small">the modern Cyrillic character mapping table. It then passes the
<strong>EncoderFallbackBuffer </strong></span><span style="font-size:small">object's
<strong><span style="color:#888888">Fallback</span></strong> method each character that it is unable to encode, and if a mapping
</span><span style="font-size:small">is available, the method can provide a suitable replacement.</span></p>
<h1><span>Source Code Files</span></h1>
<ul>
</ul>
<p><span style="font-size:small">The Cyrillic to Roman Transliteration Utility (CyrillicToRoman.exe) is a console-mode application that consists of the following project files:</span></p>
<ul>
<li><span style="font-size:small"><strong>CyrillicToRoman.sln</strong>, a Visual Studio solution file that serves as a container for its two individual language projects.</span>
</li><li><span style="font-size:small"><strong>CyrillicToRomanCS.sln</strong>, a C# project file.</span>
</li><li><span style="font-size:small"><strong>CyrillicToRomanVB.sln</strong>, a Visual Basic project file.</span>
</li></ul>
<h1>More Information</h1>
<p><span style="font-size:small">For additional information about encoding in the .NET Framework, see
<a title="Character Encoding in the .NET Framework" href="http://go.microsoft.com/fwlink/p/?LinkId=257277" target="_blank">
Character Encoding in the .NET Framework</a>.</span></p>
