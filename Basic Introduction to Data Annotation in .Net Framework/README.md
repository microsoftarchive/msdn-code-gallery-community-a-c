# Basic Introduction to Data Annotation in .Net Framework
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET Framework
- .NET Framework 4.0
- Data Annotation
- System.ComponentModel.DataAnnotations
## Topics
- C#
- .NET 4
- C# Language Features
- Data Annotation
## Updated
- 10/09/2014
## Description

<h1>Introduction</h1>
<p>Data Annotation in .Net framework means add extra meaning to the data by adding attribute tags. The advantage of using Data Annotation feature is that by applying Data Attributes we can manage the data definition in a single place and do not need re-write
 the same rules in multiple places.</p>
<p>The Data Annotation feature got introduced in.Net 3.5 and the <strong><em><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a></em></strong> namespace contains the classes that are used as data attributes.</p>
<p>The Data Annotation attributes falls into three categories:&ndash;</p>
<p>(1)<strong>Validation Attributes</strong>: Used to enforce validation rules.</p>
<p>(2)<strong>Display Attributes</strong>: Used to specify how data from a class /member is displayed in the UI.</p>
<p>(3) <strong>Modelling Attributes</strong>: Used to specify the intended use of class member and the relationship between classes.</p>
<p>Here in this article I will be walking through the basic steps involved in implementing the Data Annotation feature. I am using Visual Studio Express 2013 for Desktop as my development environment targeting .Net framework 4.5.</p>
<p>&nbsp;</p>
<p>First we will be creating our Data class, let call it <strong><em>Employee</em></strong>. The requirement says Employee class should have properties like Name, Age, Email and Phone Number with the below criteria.</p>
<div>
<p><strong>Name </strong>cannot be blank and should be of 3 characters minimum and 100 maximum characters.</p>
<p><strong>Age </strong>should be between 18 and 99.</p>
<p><strong>Email and Phone number </strong>should hold the respective data type validations<strong>.</strong></p>
</div>
<p><strong>&nbsp;</strong></p>
<p><strong>Note: </strong>This is only a sample intended to demonstrate the .Net Data Annotation feature. I will be using some of the basic Data Annotation attributes and for more details on data annotation attribute please refer Data Annotation documentation.</p>
<p>To implement the above requirement we need to code in the UI layer to accommodate/validate the above criteria&rsquo;s. The disadvantage is that if are using the Employee class in multiple places we need to re-write the validation logic creating duplicate
 code which is not a good practice.</p>
<p>Here comes the beauty of .Net Data Annotation feature. We add Data Annotation attributes to the Employee class properties and the .Net frameworks takes care of the validation/display for us .We can add custom error messages as part of Data Annotation attribute.</p>
<h1><span>Building the Sample</span></h1>
<p><span><br>
</span></p>
<p><strong>Step1</strong></p>
<p>Create an empty solution as below. This will help us to add more Projects later.</p>
<p>&nbsp;</p>
<p><img alt=""></p>
<p><img id="126691" src="126691-1.png" alt="" width="704" height="429"></p>
<p><strong>Step2</strong></p>
<p>Next create a class library project to hold Employee class as below to the Solution .</p>
<p><img id="126692" src="126692-2.png" alt=""></p>
<p><img alt=""></p>
<p>&nbsp;</p>
<p>Add a class named <strong>Employee.cs</strong> and add reference to <strong><em><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>
</em></strong>assembly to utilize the Data Annotation feature as below.</p>
<p>&nbsp;</p>
<p><img alt=""></p>
<p><img id="126693" src="126693-3.png" alt="" width="1344" height="603"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Step3</strong></p>
<p>To allow the usage of types in <strong><em><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a> add the below code to Employee.cs .</em></strong></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img alt=""></div>
<p><img id="126694" src="126694-4.png" alt="" width="880" height="393"></p>
<p>&nbsp;</p>
<p><strong><em>&nbsp;</em></strong></p>
<div class="endscriptcode"><strong><em><br>
</em></strong></div>
<div class="endscriptcode"><strong><em><br>
</em></strong></div>
<div class="endscriptcode"><strong><em><br>
</em></strong></div>
<p>&nbsp;</p>
<p><strong>Step4</strong></p>
<p>Add the below properties to the Employee class with the respective Data Annotation attributes.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required&nbsp;(ErrorMessage=<span class="cs__string">&quot;Employee&nbsp;{0}&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StringLength&nbsp;(<span class="cs__number">100</span>,MinimumLength=<span class="cs__number">3</span>,ErrorMessage=<span class="cs__string">&quot;Name&nbsp;Should&nbsp;be&nbsp;minimum&nbsp;3&nbsp;characters&nbsp;and&nbsp;a&nbsp;maximum&nbsp;of&nbsp;100&nbsp;characters&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataType(DataType.Text)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Range(<span class="cs__number">18</span>,<span class="cs__number">99</span>,&nbsp;ErrorMessage=<span class="cs__string">&quot;Age&nbsp;should&nbsp;be&nbsp;between&nbsp;18&nbsp;and&nbsp;99&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;Age&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataType(DataType.PhoneNumber)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Phone]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;<span class="cs__keyword">string</span>&nbsp;PhoneNumber&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataType(DataType.EmailAddress)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[EmailAddress]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><img alt=""></div>
<div class="endscriptcode"></div>
<p><img id="126695" src="126695-5.png" alt="" width="981" height="537"></p>
<p><strong>Step5 </strong></p>
<p><strong>Testing the Employee class Data Validation using a Console Application.</strong></p>
<p>Create a new Console Application project and add reference to <strong><em>Employee</em></strong> class library and
<strong><em><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a> </em></strong><em>assembly.</em></p>
<p>Our Solution explorer looks as below.</p>
<p>&nbsp;</p>
<p><img alt=""></p>
<p><img id="126696" src="126696-6.png" alt="" width="350" height="315"></p>
<p>&nbsp;</p>
<p><strong>Step6</strong></p>
<p>To allow the usage of types in <strong><em><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>
</em></strong>and <strong><em>Employee </em></strong>class add the below code to <strong>
<em>Program.cs.</em></strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Model.Employee;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;TestEmployeeValidation&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.White;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Employee&nbsp;class&nbsp;Validation&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;---------------------------\n&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employee&nbsp;objEmployee&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objEmployee.Name&nbsp;=&nbsp;<span class="cs__string">&quot;sa&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objEmployee.Age&nbsp;=&nbsp;<span class="cs__number">12</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objEmployee.PhoneNumber&nbsp;=&nbsp;<span class="cs__string">&quot;1234as&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objEmployee.Email&nbsp;=&nbsp;<span class="cs__string">&quot;test@re&quot;</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ValidationContext&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ValidationContext(objEmployee,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;ValidationResult&gt;&nbsp;results&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ValidationResult&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;valid&nbsp;=&nbsp;Validator.TryValidateObject(objEmployee,&nbsp;context,&nbsp;results,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!valid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(ValidationResult&nbsp;vr&nbsp;<span class="cs__keyword">in</span>&nbsp;results)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.Blue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;Member&nbsp;Name&nbsp;:{0}&quot;</span>,&nbsp;vr.MemberNames.First());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;::&nbsp;&nbsp;{0}{1}&quot;</span>,&nbsp;vr.ErrorMessage,&nbsp;Environment.NewLine);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.White;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nPress&nbsp;any&nbsp;key&nbsp;to&nbsp;exit&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Hit F5 <em>(or whatever you have configured your debug key in Visual Studio)
</em>to validate <strong>Employee</strong> class.<em> </em></div>
<p>Now we can see the validation details as below in the Console Window displaying Validation errors based on the Data Annotation attributes added to Employee class.</p>
<p><img alt=""></p>
<p>&nbsp;</p>
<p><img id="126697" src="126697-7.png" alt="" width="787" height="265"></p>
<p>Here the advantage of using Data Annotation attributes is that now if we want to reuse the Employee class in an ASP.Net MVC application or Windows Forms Application we can still use the same validation without writing any extra piece of Validation code.</p>
