# CRUD data operations for MS-Access (VB.NET)
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Data Access
- Exception handling
- VB.Net
- CRUD
- MS Access
- Class Inheritance
## Topics
- Data Binding
- Data Access
- Exception handling
- Databases
- data and storage
## Updated
- 01/07/2018
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This code sample intent is to show how to do simple add/edit/remove/show and find operations in a MS-Access database table using several classes to assist in building a repeatable pattern to perform these operations. Many of
 the things shown here can be adapted to SQL-Server with a little bit of changes. Originally this solution was non-oop done many years ago in one project with zero classes and with about two hours of updating now is a three project solution that is very tight
 and easily repeatable in other solutions. Much of what is shown is based off work I&rsquo;ve done in prior code samples done in C# and applied to VB.NET. So since much came from C# it of course will work in C# as in my
<a href="https://code.msdn.microsoft.com/Inserting-a-batch-of-51a5b511?redir=0">code sample</a> done in C# where I not only use BaseExceptionsProperties but also hook in another class too.</span></p>
<h1>Description</h1>
<p><span style="font-size:small">The solution is broken down into three projects, one for forms, one for data operations and the last one containing a single class which the data operation class inherits for exception handling.</span></p>
<p><span style="font-size:small">The class BaseExceptionProperties is used in the data operation class as follows.</span></p>
<p><span style="font-size:small">Implementing</span></p>
<p>&nbsp;</p>
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class DatabaseOperations
    Inherits BaseExceptionProperties</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;DatabaseOperations&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;BaseExceptionProperties</pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small">BaseExceptionsProperties class</div>
<div class="endscriptcode" style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class BaseExceptionProperties

    Protected mHasException As Boolean
    ''' &lt;summary&gt;
    ''' Indicate the last operation thrown an exception or not
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Public ReadOnly Property HasException() As Boolean
        Get
            Return mHasException
        End Get
    End Property
    Protected mLastException As Exception
    ''' &lt;summary&gt;
    ''' Provides access to the last exception thrown
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Public ReadOnly Property LastException() As Exception
        Get
            Return mLastException
        End Get
    End Property
    ''' &lt;summary&gt;
    ''' If you don't need the entire exception as in LastException this 
    ''' provides just the text of the exception
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Public ReadOnly Property LastExceptionMessage As String
        Get
            Return mLastException.Message
        End Get
    End Property
    ''' &lt;summary&gt;
    ''' Indicate for return of a function if there was an exception thrown or not.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Public ReadOnly Property IsSuccessFul As Boolean
        Get
            Return Not mHasException
        End Get
    End Property
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;BaseExceptionProperties&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;mHasException&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicate&nbsp;the&nbsp;last&nbsp;operation&nbsp;thrown&nbsp;an&nbsp;exception&nbsp;or&nbsp;not</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;HasException()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;mHasException&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;mLastException&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Provides&nbsp;access&nbsp;to&nbsp;the&nbsp;last&nbsp;exception&nbsp;thrown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;LastException()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;mLastException&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;If&nbsp;you&nbsp;don't&nbsp;need&nbsp;the&nbsp;entire&nbsp;exception&nbsp;as&nbsp;in&nbsp;LastException&nbsp;this&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;provides&nbsp;just&nbsp;the&nbsp;text&nbsp;of&nbsp;the&nbsp;exception</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;LastExceptionMessage&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;mLastException.Message&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Indicate&nbsp;for&nbsp;return&nbsp;of&nbsp;a&nbsp;function&nbsp;if&nbsp;there&nbsp;was&nbsp;an&nbsp;exception&nbsp;thrown&nbsp;or&nbsp;not.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;IsSuccessFul&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;mHasException&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Example usage for deleting a customer</div>
<div class="endscriptcode"><img id="185184" src="185184-1.jpg" alt="" width="506" height="520">&nbsp;</div>
</div>
<div class="endscriptcode" style="font-size:small">In the caller</div>
<div class="endscriptcode" style="font-size:small"><img id="185185" src="185185-1aaa.jpg" alt="" width="617" height="214"></div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode" style="font-size:small"><strong>Important things to know</strong>:&nbsp;</div>
<div class="endscriptcode">
<ul>
<li><span style="font-size:small">Each operations to change data e.g. add, edit, delete are done in such a way that there is zero reason to reload the data from the backend database table as many developer think needs to be done. On a side note the same applies
 when working with TableAdapters, when done right there is no reason to do a reloading of data.<br>
</span></li><li><span style="font-size:small">For each operations e.g. read, add, edit and delete are done in a single method for each operation where each method has a local connection and command sharing a single connection string.</span>
</li><li><span style="font-size:small">The Connection string defaults to one setup in the data class but can be overriden in the classes new constructor.</span>
</li><li><span style="font-size:small">For each data method they are wrapped in try-catch statements so nothing will crash the app but instead can be handled via the properties from BaseExceptionProperties</span>
</li><li><span style="font-size:small">For the add new record, upon success provides the new primary key which means if the add was in error you can immediately remove it as we have it's primary key. Many developers will simply add a row and not get the primary
 key which means they most likely will not care about removing a record or will need to reload data and as mentioned above there is zero reason to reload data when done right as done here.</span>
</li><li><span style="font-size:small">All SQL statements needing a WHERE condition use parameters.</span>
</li><li><span style="font-size:small">Update and add operations use parameters.</span>
</li><li><span style="font-size:small">The Add record for parameters uses Parameters.AddWithValue&nbsp;</span>
</li><li><span style="font-size:small">The Update record uses Parameters.Add which is more work and AddWithValue still works but wanted to show this is an option.</span>
</li><li><span style="font-size:small">Zero string concatenation used for SQL statements, instead they are created in xml literals. The idea is you can write the SQL in MS-Access, copy to your code, modify to work e.g. remove un-needed () and aliasing of fields
 for a single table etc. and then with .Value get the SQL statemnet without the &lt;SQL&gt;&lt;/SQL&gt; tags.</span>
</li><li><span style="font-size:small">For methods with parameters, each parameter is pre-fixed with 'p' so you know exactly where the variable came from, a parameter not a local or class level variable.</span>
</li><li><span style="font-size:small">A special code module handles asking the user questions in MyDialogs.vb</span>
</li><li><span style="font-size:small">There are several language extension methods which where designed to keep code clean and not having a need to cast objects over and over again.</span>
</li></ul>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:x-small"><strong>Screen shots</strong>:</span></div>
<div class="endscriptcode"><span style="font-size:x-small"><img id="185186" src="185186-s1.jpg" alt="" width="541" height="349"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:x-small"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small">Prompting to remove a record</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="185187" src="185187-s2.jpg" alt="" width="541" height="349"></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Edit the current record</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="185188" src="185188-s3.jpg" alt="" width="541" height="349"></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Add a new record</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="185189" src="185189-s4.jpg" alt="" width="541" height="349"></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><strong>Special note</strong>:</span></div>
<div class="endscriptcode"><span style="font-size:small">I do not validation, that should be easy for you to do such as is company name or contact name empty or perhaps a duplicate etc.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Classes</span><img id="185190" src="185190-all.jpg" alt="" width="379" height="710" style="font-size:small"></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="185191" src="185191-s5.jpg" alt="" width="413" height="952"><br>
</span></div>
<p>&nbsp;</p>
