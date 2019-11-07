# Create Word table with data and format cells in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Silverlight
- .NET
- Class Library
- WPF
- Word API
- .NET word
- C# word
## Topics
- How to
- Word table of contents
- table
- Converting DOCX/DOC/HTML/RTF to PDF/XPS/Image
- docx
## Updated
- 11/25/2014
## Description

<h1>Introduction</h1>
<p>This guide introduces a solution to create Word table with data and format cells in C# and VB.NET via Spire.Doc for .NET.
<a href="http://www.e-iceblue.com/Introduce/word-for-net-introduce.html">Spire.Doc for .NET</a>,&nbsp;a professional .NET Word component to operate Word document, provides a
<strong>Table class</strong> to perform tasks on table, for example, including rows, columns, cells and table layout operation.</p>
<p><strong>Effective screenshot:</strong></p>
<p><strong><img id="130277" src="130277-word%20table.png" alt="" width="852" height="493"></strong></p>
<p><strong>Main Features offered by Spire.Doc:</strong></p>
<p><strong>Generating , Writing, Editing and Saving</strong></p>
<ul>
<li>Generate and save Word documents (Word 97-2003, Word 2007, Word 2010 and Word 2013).
</li><li>Load and save document with macros, including .doc (Word 97-2003) document with macros and .docm(Word 2007, Word 2010 and Word 2013) document.
</li><li>Write and edit text and paragraphs. </li></ul>
<p><br>
<strong>Converting</strong><br>
users can save Word Doc/Docx to stream, save as web response and convert Word Doc/Docx to XML, RTF, EMF, TXT, XPS, EPUB, HTML and vice versa. Spire.Doc for .NET also supports to convert Word Doc/Docx to PDF and HTML to image.</p>
<p><br>
<strong>Inserting, Editing and Removing Objects</strong></p>
<ul>
<li>Find and replace specified strings. </li><li>Copy and remove comment, bookmark, table, texts, paragraph or sections. </li><li>Merge multiple Word documents into one. </li><li>Protect documents to prevent from opening, editing, printing etc. </li><li>Open and decrypt documents in protection. </li><li>Extract texts, comments, images etc. from document. </li><li>Load and save document with macros. Remove macros in document. </li><li>Create form field including elements: cells, texts, radio button, dropdown list, checkbox etc.
</li><li>Fill form field by connecting data from xml file. </li><li>Create and edit document properties. </li><li>Clear macros in .doc and .docm document. </li></ul>
<p><br>
<br>
<strong>Mail Merge</strong></p>
<ul>
<li>Perform simple mail merge fields (name and value) to create single item. </li><li>Execute mail merge to create a group of data records with connecting customized data source.
</li><li>Populate document with data from .NET data source including DataSet, DataTable, DataView or any other files (for example, xml) to create large amounts of records or report by using mail merge.
</li></ul>
<p><strong>Tools we need:</strong></p>
<p>- Spire.Doc dll <br>
- Visual Studio</p>
<p><strong>Prepare the environment</strong></p>
<p>This solution is based on a .NET Word component - Spire.Doc, <a href="http://www.e-iceblue.com/Download/download-word-for-net-now.html">
download the package</a> and unzip it, you&rsquo;ll get dll file and sample demo at the same time. Create or open a .NET class application in Visual Studio 2005 or above versions, add Spire.Doc.dll as a reference to your .NET project assemblies, set &ldquo;Target
 framework&rdquo; to &ldquo;.NET Framework 4&rdquo;.</p>
<p><strong>Namespaces to be used</strong></p>
<p>using Spire.Doc;<br>
using Spire.Doc.Documents;</p>
<p><strong>How to Use DLLS</strong><br>
Users need to add dll files in project as reference to perform Spire.Doc for .NET to compile.<br>
There are several folders, which save dlls for different .NET Framework version under Bin directory. After creating a project, right click project name &rarr; Add Reference &rarr; Browse &rarr; Spire.Doc folder &rarr; Bin &rarr; .NET 2.0/3.5/4.0/4.5/4.0 ClientProfile
 &rarr; Spire.Doc.dll.&nbsp;</p>
<p><strong>More Information</strong></p>
<p>Spire.Doc for .NET is a professional Word .NET library specially designed for developers to create, read, write, convert and print Word document files from any .NET( C#, VB.NET, ASP.NET) platform with fast and high quality performance. By using Spire.Doc
 for .NET, users can save Word Doc/Docx to stream, save as web response and convert Word Doc/Docx to XML, RTF, EMF, TXT, XPS, EPUB, HTML and vice versa. Spire.Doc for .NET also supports to convert Word Doc/Docx to PDF and HTML to image.</p>
