# Compare Two Word Documents or PDF Files in C# and Display Diffs in ASP.NET
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Document Comparison in C#/ASP.NET
- GroupDocs.Comparison for .NET
## Topics
- Compare Two Word Documents
- Compare PDF Files
- Compare Excel Spreadsheets
- Display Differences in ASP.NET
- Diff View UI
- Accept/Reject Changes
## Updated
- 09/16/2015
## Description

<h2>Introduction</h2>
<p><span style="font-size:small"><a href="http://groupdocs.com/dot-net/document-comparison-library" target="_blank">GroupDocs.Comparison for .NET</a> is a lightweight library that allows you to compare two documents of the same type, detect all differences
 (changes) between them and merge the compared documents to a resulting file by applying or rejecting the differences found.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">The library supports multiple file formats, yet doesn&rsquo;t have any 3<sup>rd</sup> party dependencies. It can be used to compare two Word documents, PDF files, Excel spreadsheets, PowerPoint presentations, as well as ODT,
 plain text and HTML documents without the need to install Microsoft Office, Adobe Acrobat or any other software.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Basically, GroupDocs.Compariosn for .NET is a standard .NET assembly written in a 100% managed code that can be used in any .NET project with any CLR-compatible language like C# or VB.NET.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">However, one of the core features of the library is focused towards web applications - the library provides special API methods for ASP.NET projects and comes with a diff view web interface. This allows you to compare documents
 and show the found differences on a web-page with just a few lines of code. </span>
<br class="atl-forced-newline">
</p>
<p><span style="font-size:small">This sample will help you discover how GroupDocs.Comparison for .NET works and can be used in your own projects.</span></p>
<h2>Requirements</h2>
<p><span style="font-size:small"><strong>Please note:</strong> this sample is built based on the commercial .NET library -
<a href="http://groupdocs.com/dot-net/document-comparison-library">GroupDocs.Comparison for .NET</a>. In order to use the sample, please download a free evaluation copy of the library from
<a href="http://groupdocs.com/Community/files/8/.net-libraries/groupdocs_comparison_for_.net/entry5663.aspx">
this page</a>. If you want to test the library without any limitations, please contact
<a rel="nofollow" href="http://groupdocs.com/corporate/contact-us" target="_blank">
GroupDocs support</a> for a free 30-day trial license.</span></p>
<p><span style="font-size:small">GroupDocs.Comparison for .NET requires an installed
<strong>.NET Framework version 4.0</strong> or higher. In order to use it in an ASP.NET application, you also need
<strong>ASP.NET WebForms</strong> or <strong>ASP.NET MVC version 3&#43;</strong>. </span>
<br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Additionally, for ASP.NET applications, GroupDocs.Comparison requires
<strong>System.Web.Optimization.dll</strong> version 1.1.0.0 and <strong>WebGrease.dll</strong> version 1.6.5135.21930. These libraries come with the package.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">To run the sample, you also need to have a web-server. The project can be opened using MS Visual Studio 2012 or higher and run via
<strong>IIS Express.</strong> Or, you can create a web-site using the <strong>IIS Manager</strong> and run it under the
<strong>IIS</strong>. Please note that the ASP.NET Development Server (also known as Cassini) is not supported by the library.
</span><br class="atl-forced-newline">
</p>
<h2>Running the Sample Project</h2>
<h3>Library Overview</h3>
<p><span style="font-size:small">As already mentioned, GroupDocs.Comparison for .NET compares two documents of the same type (format). You just need to specify a source and a target document, and then start the comparison process. Here I&rsquo;d like to notice
 that input documents are not equivalent or interchangeable. There is a <strong>source document</strong>, which is considered by GroupDocs.Comparison as a &ldquo;base&rdquo;, or &ldquo;root&rdquo;, and a
<strong>target document</strong>, considered as some sort of an &ldquo;alternative version&rdquo;. When comparing them, the library detects objects present in the
<strong>source document</strong> and absent in the <strong>target document</strong>, and vice versa.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Depending on a document type, GroupDocs.Comparison for .NET can detect not only differences in content, but also document structure and style/formatting changes. The enumeration
<em>&quot;Groupdocs.Comparison.Common.ChangeType</em>&rdquo; contains all possible types of differences (mismatches) that can be processed by the library.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Once documents are compared, GroupDocs.Comparison provides you with a list of all the differences found. You can apply or reject them one-by-one and generate a new final document that will be based on these manipulations.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Specifically for ASP.NET projects (both, WebForms and MVC version 3&#43;), GroupDocs.Comparison for .NET contains a diff view widget that can be seamlessly embedded to a web-page. This widget transforms the compared documents to
 the web-content and renders them with a redline change tracking view. The page also contains a web GUI that allows users to view, navigate and manipulate the documents they compare right in a web-browser.</span></p>
<h3>Project structure</h3>
<p><span style="font-size:small">In the package you will find a &ldquo;<em>ComparisonDemoSolution</em>&rdquo; solution, which contains one ASP.NET MVC 3 project - &ldquo;<em>ComparisonDemo</em>&rdquo;.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">The &ldquo;<em>libs</em>&rdquo; folder contains all necessary libraries except the
<em>&quot;Groupdocs.Web.UI.Comparison.dll&quot;</em> - this is the assembly name of the GroupDocs.Comparison for .NET. Please download this missing library from the GroupDocs website using
<a href="http://groupdocs.com/Community/files/8/.net-libraries/groupdocs_comparison_for_.net/entry5663.aspx">
this link</a>. Once downloaded, please add the library (<em>Groupdocs.Web.UI.Comparison.dll</em>) to the &ldquo;<em>libs</em>&rdquo; folder.</span></p>
<p><span style="font-size:small"><span style="font-size:small">The &ldquo;<em>App_Data</em>&rdquo; folder contains sample documents. It also serves as storage for output documents and temporary data (this will be described later in this article). All the rest
 files and folders are standard for a simple MVC project. </span></span></p>
<p><span style="font-size:small">The <em>&quot;web.config&quot;</em> file is quite simple. We&rsquo;ve deliberately removed all the extra stuff that is included there when an empty project is generated by Visual Studio (such as different providers, authorization and
 authentication, Entity Framework configuration, etc).</span></p>
<h3>Initializing GroupDocs.Comparison</h3>
<p><span style="font-size:small">Please open the <em>&quot;Global.asax&quot;</em> file and take a look at the
<em>&ldquo;Application_Start&rdquo;</em> method. There are 3 lines of code: </span>
<br class="atl-forced-newline">
</p>
<ul>
<li><span style="font-size:small">Specifying a root storage path (<em>&ldquo;GroupdocsComparison.SetRootStoragePath&rdquo;</em>) static method. This is absolutely necessary, since GroupDocs.Comparison requires a place where it can store temporary and output
 files.</span> </li><li><span style="font-size:small">Specifying a license file (<em>&ldquo;GroupdocsComparison.SetLicensePath&rdquo;</em>) method. This is optional. When a valid license file is specified, GroupDocs.Comparison works in an unlimited full-featured mode. Otherwise,
 it has several functional restrictions. As already noticed, you can get a free 30-day fully-functional license simply by
<a rel="nofollow" href="http://groupdocs.com/corporate/contact-us" target="_blank">
contacting</a> GroupDocs support.</span> </li><li><span style="font-size:small">Initializing GroupDocs.Comparison using the <em>
&ldquo;GroupdocsComparison.Init&rdquo;</em> static method. You need to initialize GroupDocs.Comparison before starting using it. But at this point the root storage should be already initialized. Otherwise an exception will be thrown.
</span></li></ul>
<h2>Basic Usage of the GroupDocs.Comparison</h2>
<p><span style="font-size:small">Open the <em>&ldquo;HomeController&rdquo;</em> and take a look at the
<em>&ldquo;Index&rdquo;</em> action. In this action the <em>&ldquo;ComparisonService&rdquo;</em> class is instantiated. Then the source file, which represents the initial document, and the target document are specified. Now, in the next line you should find
 the specified resulting filename. When a comparison is accomplished, a new file with this name will be created in the
<em>&ldquo;App_Data&rdquo;</em> folder. </span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Next, the <em>&ldquo;service.Compare&rdquo;</em> file is called. This method creates a resulting file (it is usually called as
<em>&ldquo;Redline&rdquo;</em> in our internal GroupDocs.Comparison terminology) and returns an array of instances of the
<em>&ldquo;ChangeInfo&rdquo;</em> class. Let&rsquo;s take a look at this class more closely.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">The <em>&ldquo;Groupdocs.Comparison.Common.ChangeInfo&rdquo;</em> instance class may be considered as a container for each separate difference (mismatch) between the source and the target document. It contains data about the
 difference found (textual content that was changed; a type of change, like insertion or deletion; details about style changes; page number; part of the document where changes were found, etc.) and the
<em>&ldquo;comparison action&rdquo;</em>. </span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">But what is the <em>&ldquo;comparison action&rdquo;</em> for? This is the method that allows you to specify how to process each particular difference found. Here you can select one of three values that are defined by the
<em>&ldquo;Groupdocs.Comparison.Common.ComparisonAction&rdquo;</em> enumeration: </span>
<br class="atl-forced-newline">
</p>
<ul>
<li><span style="font-size:small"><em>ComparisonAction.None</em> - merge the old value with the new value, so that both values will be included in the resulting document.</span>
</li><li><span style="font-size:small"><em>ComparisonAction.Accept</em> - accept the new value from the
<strong>target</strong> document and replace the old value from the <strong>source</strong> document.</span>
</li><li><span style="font-size:small"><em>ComparisonAction.Reject</em> - cancel the new value from the
<strong>target</strong> document and leave the old value from the <strong>source</strong> document.
</span><br class="atl-forced-newline">
</li></ul>
<p><span style="font-size:small">You can select different actions for each individual mismatch found and then apply them using the
<em>&ldquo;service.UpdateChanges&rdquo;</em> method. </span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">That&rsquo;s all for the <em>&ldquo;Index&rdquo;</em> action. Basically, it only includes the comparison service and comparison action methods. Now, the differences can be sent to the view, where they are listed one after another.</span></p>
<p><span style="font-size:small"><img id="132455" src="132455-comparison-summary.png" alt="Document Comparison Summary" width="734" height="556"></span></p>
<p><span style="font-size:small">With the <em>&ldquo;ComparisonService&rdquo;</em> class you can perform comparison and changes (mismatches) selection programmatically in any type of applications, even if it doesn&rsquo;t have a GUI at all (for example, in
 a console app). But what if you&rsquo;d like to use GroupDocs.Comparison in an ASP.NET web-site?</span></p>
<h2>Web-oriented Usage of the GroupDocs.Comparison</h2>
<p><span style="font-size:small">Please take a look at the <em>&ldquo;StandardGui&rdquo;</em> action within the same
<em>&ldquo;HomeController&rdquo;</em>. You can find <em>&quot;Groupdocs.Web.UI.Comparison.GroupdocsComparison&quot;</em> there, which works almost the same way: you just specify source and target documents and in the output you get this:</span></p>
<p><img id="132456" src="132456-diff-view-ui.png" alt="Comparing Two Documents in ASP.NET – Diff View UI" width="734" height="479"></p>
<p><span style="font-size:small">This is a standard GroupDocs.Comparison-enabled web-interface. Please take a look at the
<em>&ldquo;Comparison(&quot;#comparison-wrapper&quot;)</em>&rdquo; method and its value in the
<em>&ldquo;StandardGui&rdquo;</em> action. In the <em>&ldquo;StandardGui.cshtml&rdquo;</em> view you can find a DIV block with the
<em>&quot;comparison-wrapper&quot;</em> ID. The <em>&ldquo;ImmediateCompare()&rdquo;</em> method performs comparison before the page is rendered. If this method is not invoked, comparison will be accomplished on demand and you will see an empty page in the web-browser
 (with the GUI, but without documents). </span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small"><em>&ldquo;GroupdocsComparison&rdquo;</em> should be considered as an advanced, high-level wrapper around the
<em>&ldquo;ComparisonService&rdquo;</em> class which was described earlier. <em>&quot;GroupdocsComparison&quot;</em> internally invokes a low-level
<em>&quot;ComparisonService&quot;</em>, obtains a result and generates a web-layout/markup, showing it on a web-page with the standard GUI.</span></p>
<h2>Working with Streams</h2>
<p><span style="font-size:small">There are situations when you can&rsquo;t work with documents as with files, so the only acceptable form is a byte stream (<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.Stream.aspx" target="_blank" title="Auto generated link to System.IO.Stream">System.IO.Stream</a>). GroupDocs.Comparison allows you to specify the documents you&rsquo;d like to compare
 (source and target documents), as well as the resulting (redline) document as streams.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Setting source and target documents as streams is quite easy - you just need to specify an actual stream (please don&rsquo;t forget to check the position!) and the file name, which should be compatible with the file system and
 is considered as a unique identifier for the stream. </span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Setting a stream for the redline document is a bit harder. You should use the
<em>&quot;ComparisonSaving&quot;</em> event handler with the attached <em>&quot;ComparisonSaveHandler&quot;</em> delegate. Here are several important things that require your attention.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Please take a look on the <em>&quot;StrHandler&quot;</em> method, which implements a signature of the
<em>&quot;ComparisonSaveHandler&quot;</em> delegate type. Its full signature is: </span><br class="atl-forced-newline">
</p>
<p><em><span style="font-size:small">void ComparisonSaveHandler(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.Stream.aspx" target="_blank" title="Auto generated link to System.IO.Stream">System.IO.Stream</a> redlineStream, out string fileName)
</span></em><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">The first parameter - <em>&quot;redlineStream&quot;</em> - contains a stream with all the content inside. The second output parameter -
<em>&ldquo;fileName&rdquo;</em> - contains a filename. GroupDocs.Comparison uses it when saving streams to files.
</span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Please take into account that when using the <em>
&quot;ComparisonSaveHandler&quot;</em> delegate instance, there is no need for the <em>&quot;ResultFileName&quot;</em> method. GroupDocs.Comparison creates a temporary redline file with the filename from the
<em>&ldquo;fileName&rdquo;</em> parameter. So there is no need for specifying a resulting filename somewhere else. But, of course, when you don&rsquo;t use streams, you should do this anyway.</span></p>
<h2>Final Notes</h2>
<p><span style="font-size:small">This project and article give you only a basic idea of the GroupDocs.Comparison for .NET concept and how it can be used to compare documents of common business formats like Word, PDF and Excel files. The library contains a lot
 more advanced features that allow you to integrate the document comparison workflow into your own projects and apps seamlessly. For more details on the library, please visit GroupDocs website at:</span><br>
<span style="font-size:small"><a href="http://groupdocs.com/dot-net/document-comparison-library" target="_blank">http://groupdocs.com/dot-net/document-comparison-library</a></span><br class="atl-forced-newline">
</p>
<p><span style="font-size:small">Also, please do not hesitate to <a rel="nofollow" href="http://groupdocs.com/corporate/contact-us" target="_blank">
contact</a> GroupDocs support if you have any questions, want to request a 30-day free trial, or report a bug.</span></p>
