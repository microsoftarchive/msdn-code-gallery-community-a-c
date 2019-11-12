# console application in C# for Beginners
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- Getting Started
- Console Applications
## Updated
- 07/27/2012
## Description

<h1>Introduction</h1>
<p>In the early 1970s the creators of the C&nbsp;<a id="KonaLink1" class="kLink" href="http://www.techotopia.com/index.php/A_Simple_C_Sharp_Console_Application#" style="text-decoration:underline!important; position:static; font-family:inherit!important; font-weight:inherit!important; font-size:inherit!important"><span style="color:blue; font-family:inherit!important; font-weight:inherit!important; font-size:inherit!important; position:static"><span class="kLink" style="color:blue!important; font-family:inherit!important; font-weight:inherit!important; font-size:inherit!important; position:static; border-bottom:1px solid blue; background-color:transparent">&nbsp;</span></span></a>
 wrote a book of the same name intended to teach the skills necessary to program in C. One of the first chapters of this book contained a very simple C program which displayed the words &quot;Hello World&quot; in a console. Ever since that day most programming books
 have followed this tradition. Given that C# can trace its ancestry to the c programming language,C# essentials will be no exception to this rule.</p>
<p>Even if you are an experienced develpoer this simple C# example is still recommended if only to verify that the C# environment of development is correctly installed.</p>
<p>Even an example this simple requires that certain aspects of the C# and the environment will be runtime environment<a id="KonaLink5" class="kLink" href="http://www.techotopia.com/index.php/A_Simple_C_Sharp_Console_Application#" style="text-decoration:underline!important; position:static; font-family:inherit!important; font-weight:inherit!important; font-size:inherit!important"><span style="color:blue; font-family:inherit!important; font-weight:inherit!important; font-size:inherit!important; position:static"><span class="kLink" style="color:blue!important; font-family:inherit!important; font-weight:inherit!important; font-size:inherit!important; position:static">&nbsp;</span></span></a>
 that will be set up. Before we plunge into the example, therefore, we first need to spend a little time talking about setting up the environment.</p>
<p>This application will be very userful for beginners who start learning the c# console application.</p>
<p>&nbsp;</p>
<p><em>This is a Student marklist Report.Through this we can specify number of students and their mark details.Finally,we can view the Grand total with the Report.The user must enter the total number of students then Enter number of student's mark information.Then
 give Student Name subject1 that will be English mark,then subject2 will be the Maths mark,the subject 3 will be physics mark,subject 4 will be chemistry mark,subject 5 will be biology mark...then when we enter the entire report will be spooled by calculating
 the total value.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><img alt=""></p>
<p><span><br>
</span></p>
<p><em>&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__preproc">#&nbsp;region&nbsp;&quot;Namespaces</span>&quot;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Runtime.InteropServices.aspx" target="_blank" title="Auto generated link to System.Runtime.InteropServices">System.Runtime.InteropServices</a>;&nbsp;
<span class="cs__com">//This&nbsp;is&nbsp;the&nbsp;namespace&nbsp;provides&nbsp;a&nbsp;wide&nbsp;variety&nbsp;of&nbsp;members&nbsp;that&nbsp;support&nbsp;COM&nbsp;interop&nbsp;and&nbsp;platform&nbsp;invoke&nbsp;services</span><span class="cs__preproc">&nbsp;
&nbsp;
#&nbsp;endregion</span>&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;STUDENTS_MARKS_REPORT&nbsp;
{<span class="cs__preproc">&nbsp;
#&nbsp;region&nbsp;&quot;Class&nbsp;to&nbsp;get&nbsp;student&nbsp;Details</span>&quot;&nbsp;&nbsp;
&nbsp;<span class="cs__keyword">class</span>&nbsp;CStudentDetails&nbsp;<span class="cs__com">//class&nbsp;for&nbsp;Declarations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;studentname;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;studentmarks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[<span class="cs__number">5</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;totalmarks;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
#&nbsp;endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;#&nbsp;region&nbsp;&quot;Class&nbsp;that&nbsp;adds&nbsp;record</span>&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;CStudents&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;CStudentDetails&gt;&nbsp;studList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CStudentDetails&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;list&nbsp;contains&nbsp;the&nbsp;student&nbsp;list</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;MaxStudents;<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;
&nbsp;#region&nbsp;&quot;Function&nbsp;that&nbsp;adds&nbsp;record</span>&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;Function&nbsp;Adds&nbsp;the&nbsp;Record</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;AddRecord(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">int</span>[]&nbsp;marks)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CStudentDetails&nbsp;stud&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CStudentDetails();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stud.studentname&nbsp;=&nbsp;name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stud.studentmarks&nbsp;=&nbsp;marks;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stud.totalmarks&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__number">5</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stud.totalmarks&nbsp;&#43;=&nbsp;stud.studentmarks[i];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studList.Add(stud);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxStudents&nbsp;=&nbsp;studList.Count;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
#endregion</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;
&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;CStudents&nbsp;theStudents&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CStudents();<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;
&nbsp;
#&nbsp;region&nbsp;Method&nbsp;to&nbsp;view&nbsp;Records</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;method&nbsp;is&nbsp;to&nbsp;view&nbsp;Records&nbsp;as&nbsp;Report</span>&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ViewRecords()&nbsp;
{&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;_______________________________________________________________&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;SNo&nbsp;Student&nbsp;Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ENG&nbsp;&nbsp;&nbsp;MATH&nbsp;&nbsp;&nbsp;PHY&nbsp;&nbsp;&nbsp;&nbsp;CHE&nbsp;&nbsp;&nbsp;&nbsp;BIO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;_______________________________________________________________&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;theStudents.MaxStudents;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-5}&quot;</span>,&nbsp;i&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-19}&quot;</span>,&nbsp;theStudents.studList[i].studentname);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-7}&quot;</span>,&nbsp;theStudents.studList[i].studentmarks[<span class="cs__number">0</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-7}&quot;</span>,&nbsp;theStudents.studList[i].studentmarks[<span class="cs__number">1</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-7}&quot;</span>,&nbsp;theStudents.studList[i].studentmarks[<span class="cs__number">2</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-7}&quot;</span>,&nbsp;theStudents.studList[i].studentmarks[<span class="cs__number">3</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-7}&quot;</span>,&nbsp;theStudents.studList[i].studentmarks[<span class="cs__number">4</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0,&nbsp;-7}&quot;</span>,&nbsp;theStudents.studList[i].totalmarks);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;_______________________________________________________________&quot;</span>);&nbsp;
&nbsp;
}<span class="cs__preproc">&nbsp;
#endregion</span>&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InputRecords()&nbsp;
&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;Student&nbsp;Name:&nbsp;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>[]&nbsp;marks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[<span class="cs__number">5</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;=&nbsp;<span class="cs__number">5</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;Sub&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Mark:&nbsp;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;marks[i<span class="cs__number">-1</span>]&nbsp;=&nbsp;Convert.ToInt32(Console.ReadLine());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;theStudents.AddRecord(name,&nbsp;marks);&nbsp;
&nbsp;
}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Student&nbsp;MarkList&nbsp;Application&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;Enter&nbsp;the&nbsp;Total&nbsp;number&nbsp;&nbsp;of&nbsp;students:&nbsp;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;numStudents&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;s&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;numStudents&nbsp;=&nbsp;Convert.ToInt32(s);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;=&nbsp;numStudents;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nEnter&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Student&nbsp;Information\n&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InputRecords();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewRecords();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">char</span>&nbsp;ch&nbsp;=&nbsp;Console.ReadKey().KeyChar;&nbsp;
&nbsp;
}&nbsp;
&nbsp;
}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;#&nbsp;endregionClick&nbsp;here&nbsp;to&nbsp;add&nbsp;your&nbsp;code&nbsp;snippet</span>.</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><span><br>
</span></p>
<h1>More Information</h1>
<p><em><img id="62230" src="62230-studentmark.png" alt="" width="675" height="501"></em></p>
