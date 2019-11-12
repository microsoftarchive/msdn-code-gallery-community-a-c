# BizTalk: Accessing and change message values inside orchestration
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- BizTalk Server 2010
## Topics
- BizTalk
## Updated
- 11/27/2011
## Description

<h1>Introduction</h1>
<p><span style="font-family:Tahoma; font-size:small">There are 3 ways that we can read and set values of the message inside orchestration:
</span></p>
<ul>
<li><span style="font-family:Tahoma; font-size:small">Using Property promotion</span>
</li><li><span style="font-family:Tahoma; font-size:small">Using XPath expressions</span>
</li><li><span style="font-family:Tahoma; font-size:small">Using C#/VB.NET object (serialization)</span>
</li></ul>
<p><span style="font-family:Tahoma; font-size:small">The last one is the most uncommon but it can be done, serializing the message into object.
</span></p>
<h1>Using Property promotion</h1>
<p><span style="font-family:Tahoma; font-size:small">Property promotion is about getting easy and fast access to data.
</span></p>
<ul>
<li><span style="font-family:Tahoma"><span style="font-size:small"><strong>Easy</strong>: Because you typically do not have to know anything about your data to get access to it. Rather than some long XPath query with possible errors.</span></span>
</li><li><span style="font-family:Tahoma"><span style="font-size:small"><strong>Fast</strong>: Because you do not have to load the whole message into memory to get access to the data. It is placed inside the message context (a collection of key-value pairs that
 are associated with a message).</span></span> </li></ul>
<p><span style="font-family:Tahoma; font-size:small">BizTalk provides two different types of promoted properties based on what you want to do with the data. The two types are:
</span></p>
<ul>
<li><span style="font-family:Tahoma; font-size:small">Promoted Properties: are system wide.
</span></li><li><span style="font-family:Tahoma; font-size:small">Distinguished Fields: are light weight and only accessible inside an Orchestration.</span>
</li></ul>
<p><span style="font-family:Tahoma; font-size:small">They are read/write so it provides an easy way to change values inside your message without using a map &ndash; such as updating a status field.
</span></p>
<p><span style="font-family:Tahoma; font-size:small">Learn more: </span><a href="http://sandroaspbiztalkblog.wordpress.com/2009/03/28/distinguished-fields-vs-promoted-properties/"><span style="font-family:Tahoma; font-size:small">Distinguished Fields vs. Promoted
 Properties</span></a><span style="font-family:Tahoma; font-size:small">, </span>
<a href="http://geekswithblogs.net/sthomas/archive/2005/06/27/44906.aspx"><span style="font-family:Tahoma; font-size:small">Basics of Promoted Properties</span></a></p>
<p><span style="font-family:Tahoma; font-size:small"><img src="45323-property-promotion.jpg" alt="" width="300" height="205" style="display:block; margin-left:auto; margin-right:auto"></span></p>
<p><strong><span style="font-family:Tahoma; font-size:small">Using Promoted Properties:</span></strong></p>
<p><em>//Read</em><br>
<em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.EventLog.WriteEntry.aspx" target="_blank" title="Auto generated link to System.Diagnostics.EventLog.WriteEntry">System.Diagnostics.EventLog.WriteEntry</a>(&ldquo;Orchestration&rdquo;, <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Convert.ToString.aspx" target="_blank" title="Auto generated link to System.Convert.ToString">System.Convert.ToString</a>(</em><br>
<em>msgOutput1(AccessingAndChangeMessageValuesInOrchestration.PropertySchema.FirstName)), System.Diagnostics.EventLogEntryType.Error);</em><br>
<br>
<em>//SET (Write)</em><br>
<em>msgOutput1(AccessingAndChangeMessageValuesInOrchestration.PropertySchema.FirstName) = &ldquo;Sandro&rdquo;;</em></p>
<p><strong><span style="font-family:Tahoma; font-size:small">Using Distinguished Field:
</span></strong></p>
<p><em>//Read</em><br>
<em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.EventLog.WriteEntry.aspx" target="_blank" title="Auto generated link to System.Diagnostics.EventLog.WriteEntry">System.Diagnostics.EventLog.WriteEntry</a>(</em><br>
<em>&nbsp;&nbsp;&nbsp; &ldquo;Orchestration&rdquo;,</em><br>
<em>&nbsp;&nbsp;&nbsp; <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Convert.ToString.aspx" target="_blank" title="Auto generated link to System.Convert.ToString">System.Convert.ToString</a>(msgOutput2.LastName), System.Diagnostics.EventLogEntryType.Error);</em><br>
<br>
<em>//SET (Write)</em><br>
<em>msgOutput2.LastName = &ldquo;Pereira&rdquo;;</em></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Using XPath expressions</span></p>
<p><span style="font-family:Tahoma; font-size:small">Working with XPath inside Orchestrations is a powerful and simple feature of BizTalk. XPath can be used to both read values and set values inside your Message. To set values in your message, you need to be
 inside a Message Construct shape. </span></p>
<p><span style="font-family:Tahoma; font-size:small">XPath queries can only be done against a Message &ndash; can also be executed against untyped messages (that is, a Message that is of type <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Xml.XmlDocument.aspx" target="_blank" title="Auto generated link to System.Xml.XmlDocument">System.Xml.XmlDocument</a>) &ndash; and the results can be set to a Message,
 XML Document or other orchestration variables. </span></p>
<p><span style="font-family:Tahoma; font-size:small">Learn more: </span><a href="http://sandroaspbiztalkblog.wordpress.com/2009/08/29/biztalk-working-with-xpath-%E2%80%93-xpath-1-0-function-library-quick-reference/"><span style="font-family:Tahoma; font-size:small">XPath
 1.0 Function Library Quick Reference</span></a><span style="font-family:Tahoma; font-size:small">,
</span><a href="http://sandroaspbiztalkblog.wordpress.com/2009/08/29/biztalk-working-with-xpath-%E2%80%93-xpath-1-0-operators-and-special-characters-quick-reference/"><span style="font-family:Tahoma; font-size:small">Operators and Special Characters Quick Reference</span></a><span style="font-family:Tahoma; font-size:small">
</span></p>
<p><span style="font-family:Tahoma; font-size:small">To see what is the XPath expression of the field:
</span></p>
<ul>
<li><span style="font-family:Tahoma; font-size:small">Go to schema and select the field that you want
</span></li><li><span style="font-family:Tahoma; font-size:small">Right-click and select &ldquo;Properties&rdquo;</span>
</li><li><span style="font-family:Tahoma; font-size:small">Select the value of the property &ldquo;Instance XPath&rdquo;</span>
</li></ul>
<p><img src="45324-instance-xpath.jpg" alt="" style="display:block; margin-left:auto; margin-right:auto"></p>
<p><strong>Using XPath Expression in Message Assign:</strong></p>
<p><em>//Read</em><br>
<em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.EventLog.WriteEntry.aspx" target="_blank" title="Auto generated link to System.Diagnostics.EventLog.WriteEntry">System.Diagnostics.EventLog.WriteEntry</a>(&ldquo;Orchestration&rdquo;, <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Convert.ToString.aspx" target="_blank" title="Auto generated link to System.Convert.ToString">System.Convert.ToString</a>(xpath(msgOutput3,&rdquo;string(/*[local-name()='Person' and namespace-uri()='http://AccessingAndChangeMessageValuesInOrchestration.Schema1']/*[local-name()='Age'
 and namespace-uri()=''])&rdquo;)), System.Diagnostics.EventLogEntryType.Error);</em><br>
<br>
<em>//SET (Write)</em><br>
<em>xpath(msgOutput3,&rdquo;/*[local-name()='Person' and namespace-uri()='http://AccessingAndChangeMessageValuesInOrchestration.Schema1']/*[local-name()='Age' and namespace-uri()='']&ldquo;) = &ldquo;00&Prime;;</em></p>
<h1>Using C#/VB.NET object (serialization)</h1>
<ul>
</ul>
<p><span style="font-family:Tahoma; font-size:small">BizTalk is able to automatically convert message in C# object and C# object into BizTalk message.
</span></p>
<p><span style="font-family:Tahoma; font-size:small">To accomplish this we have to generate C#/VB.NET classes based on Schemas using XSD.EXE, or those of you not familiar with XSD.EXE it&rsquo;s a command line tool shipped with Visual Studio .NET that allows
 you to generate Classes or Typed DataSets based on XML Schemas, normally you might try to write code to create a XML Document (based on a schema), you end up writing pages and pages of painful code to construct a XML document by using the DOM (XmlDocument).
</span></p>
<p><span style="font-family:Tahoma; font-size:small">How to create class from schema:
</span></p>
<ul>
<li><span style="font-family:Tahoma; font-size:small">Start Menu -&gt; All Programs -&gt; Microsoft Visual Studio &hellip; -&gt; Visual Studio Tools -&gt; Visual Studio &hellip; Command Prompt</span>
</li><li><span style="font-family:Tahoma; font-size:small">Go to the Schema folder and type &ldquo;xsd /classes /language:CS Schema1.xsd&rdquo;</span>
</li></ul>
<p><span style="font-family:Tahoma; font-size:small">Create Orchestration variable
</span></p>
<ul>
<li><span style="font-family:Tahoma; font-size:small">First you have to create an orchestration variable from the class that you create previous</span>
</li><li><span style="font-family:Tahoma; font-size:small">On property Type select &lt;.NET Class&hellip;&gt; and select Person class that you create previous</span>
</li></ul>
<p><img src="45325-variable-person.jpg" alt="" style="display:block; margin-left:auto; margin-right:auto"><strong>Using C# object inside Message Assign:</strong></p>
<p><em>//CONVERT MESSAGE INTO C# OBJECT</em><br>
<em>varPersonMsg = msgInput;</em><br>
<br>
<em>//Read</em><br>
<em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.EventLog.WriteEntry.aspx" target="_blank" title="Auto generated link to System.Diagnostics.EventLog.WriteEntry">System.Diagnostics.EventLog.WriteEntry</a>(&ldquo;Orchestration&rdquo;, varPersonMsg.FirstName &#43; &rdquo; &rdquo; &#43; varPersonMsg.LastName, System.Diagnostics.EventLogEntryType.Error);</em><br>
<br>
<em>//SET (Write)</em><br>
<em>varPersonMsg.FirstName = &ldquo;Sandro&rdquo;;</em><br>
<em>varPersonMsg.LastName = &ldquo;Pereira&rdquo;;</em><br>
<em>varPersonMsg.Age = &ldquo;00&Prime;;</em><br>
<br>
<em>//CONVERT C# OBJECT INTO BIZTALK MESSAGE</em><br>
<em>msgOutput4 = varPersonMsg;</em></p>
<ul>
</ul>
<h1>About Me</h1>
<p><strong>Sandro Pereira</strong><br>
DevScope | MVP &amp; MCTS BizTalk Server 2010<br>
<a href="http://sandroaspbiztalkblog.wordpress.com/" target="_blank">http://sandroaspbiztalkblog.wordpress.com/</a> |
<a href="http://twitter.com/sandro_asp" target="_blank">@sandro_asp</a></p>
