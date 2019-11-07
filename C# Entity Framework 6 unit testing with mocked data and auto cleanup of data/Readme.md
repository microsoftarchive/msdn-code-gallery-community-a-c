# C# Entity Framework 6 unit testing with mocked data and auto cleanup of data
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- SQL Server
- Unit Test
- Entity Framework 6
## Topics
- C#
- Unit Testing
- Unit of Work Pattern
## Updated
- 04/29/2018
## Description

<h1>Description</h1>
<p><span style="font-size:small"><span>This code sample focuses on setting up data for doing unit testing with Entity Framework by using a base class which another class inherits to create temporary data that is inserted into SQL-Server table(s), unit test
 do their assertion then in the test class clean up event all data which was created is removed from the database table(s). Other methods used for unit testing such EntityFramework.MoqHelper create in memory data that represents the entities representing data
 in the backend database which means they don&rsquo;t touch the database and therefore are faster to run test. The downside is there are no metrics to gauge performance on hitting the actual data. &nbsp;So in this code sample we actually hit against the database,
 first to create the data, next to run against the data and finally to clean up data that we created prior to running our test (thinking arrange, act assert).</span><span>&nbsp;&nbsp;</span></span></p>
<p><span style="font-size:small">Also shown (unlike the VB.NET <a href="https://code.msdn.microsoft.com/VBNet-Entity-Framework-6-f9d8c6fe" target="_blank">
code sample</a>) is the use of the Trait declarating of the test methods.</span></p>
<p><span style="font-size:small"><span>The key elements, each table in the entity mode implements the following Interface.</span></span></p>
<p>&nbsp;</p>
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public interface IBaseEntity
{
    int Identifier { get; }
}</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">public&nbsp;interface&nbsp;IBaseEntity&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;Identifier&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small">So Customers from Person.tt is setup as follows</div>
<div class="endscriptcode">
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public partial class Customer : IBaseEntity
{
    public int Identifier
    {
        get
        {
            return id;
        }
    }
}</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">public&nbsp;partial&nbsp;class&nbsp;Customer&nbsp;:&nbsp;IBaseEntity&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Identifier&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small"><span>Jumping ahead a little, the reason for the Interface is that now all classes used has a id field which is the primary key for that table e.g.</span></div>
<div class="endscriptcode" style="font-size:small"><span>&nbsp;</span>&nbsp;</div>
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public partial class GenderType : IBaseEntity
{
    public int Identifier
    {
        get
        {
            return GenderIdentifier;
        }
    }
}</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">public&nbsp;partial&nbsp;class&nbsp;GenderType&nbsp;:&nbsp;IBaseEntity&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Identifier&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;GenderIdentifier;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small"><span>This is so in the tear down of the test class a function AnnihilateData can find the items added to a list of objects can be typed and located then finally added to the DbContext with a state to remove
 the items when we execute SaveChanges. All of this code is in TestBase.cs in the unit test project.</span></div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode" style="font-size:small"><span><span><span>If you don't implement the Interface IBaseEntity when it comes time to remove objects an exception is thrown and finally a message in the unit test will indicate the database is dirty meaning
 all objects created at the beginning of the unit test were not removed from the database.</span></span></span></div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode">
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class CustomerCreateData : TestBase
{
    public void CreateMockData()
    {
        AddSandboxEntities(CreateCustomers());
        DbContext.SaveChanges();
    }
    public List&lt;Customer&gt; CreateCustomers()
    {
        var customerList = new List&lt;Customer&gt;();

        customerList.Add(new Customer
        {
            CompanyName = &quot;Alfreds Futterkiste&quot;,
            ContactName = &quot;Maria Anders&quot;,
            ContactTitle = &quot;Sales Representative&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Ana Trujillo Emparedados y helados&quot;,
            ContactName = &quot;Ana Trujillo&quot;,
            ContactTitle = &quot;Owner&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Antonio Moreno Taqueria&quot;,
            ContactName = &quot;Antonio Moreno&quot;,
            ContactTitle = &quot;Owner&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Around the Horn&quot;,
            ContactName = &quot;Thomas Hardy&quot;,
            ContactTitle = &quot;Sales Representative&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Berglunds snabbkop&quot;,
            ContactName = &quot;Christina Berglund&quot;,
            ContactTitle = &quot;Order Administrator&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Blauer See Delikatessen&quot;,
            ContactName = &quot;Hanna Moos&quot;,
            ContactTitle = &quot;Sales Representative&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;France restauration&quot;,
            ContactName = &quot;Carine Schmitt&quot;,
            ContactTitle = &quot;Marketing Manager&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Morgenstern Gesundkost&quot;,
            ContactName = &quot;Alexander Feuer&quot;,
            ContactTitle = &quot;Marketing Assistant&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Simons bistro &quot;,
            ContactName = &quot;Dominique Perrier&quot;,
            ContactTitle = &quot;Marketing Manager&quot;
        });
        customerList.Add(new Customer
        {
            CompanyName = &quot;Island Trading&quot;,
            ContactName = &quot;Helen Bennett&quot;,
            ContactTitle = &quot;Marketing Manager&quot;
        });

        return customerList;

    }

}</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">public&nbsp;class&nbsp;CustomerCreateData&nbsp;:&nbsp;TestBase&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;CreateMockData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddSandboxEntities(CreateCustomers());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DbContext.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;List&lt;Customer&gt;&nbsp;CreateCustomers()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;customerList&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;Customer&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Alfreds&nbsp;Futterkiste&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Maria&nbsp;Anders&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Sales&nbsp;Representative&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Ana&nbsp;Trujillo&nbsp;Emparedados&nbsp;y&nbsp;helados&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Ana&nbsp;Trujillo&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Owner&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Antonio&nbsp;Moreno&nbsp;Taqueria&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Antonio&nbsp;Moreno&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Owner&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Around&nbsp;the&nbsp;Horn&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Thomas&nbsp;Hardy&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Sales&nbsp;Representative&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Berglunds&nbsp;snabbkop&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Christina&nbsp;Berglund&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Order&nbsp;Administrator&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Blauer&nbsp;See&nbsp;Delikatessen&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Hanna&nbsp;Moos&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Sales&nbsp;Representative&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;France&nbsp;restauration&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Carine&nbsp;Schmitt&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Marketing&nbsp;Manager&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Morgenstern&nbsp;Gesundkost&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Alexander&nbsp;Feuer&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Marketing&nbsp;Assistant&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Simons&nbsp;bistro&nbsp;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Dominique&nbsp;Perrier&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Marketing&nbsp;Manager&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(<span class="js__operator">new</span>&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName&nbsp;=&nbsp;<span class="js__string">&quot;Island&nbsp;Trading&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactName&nbsp;=&nbsp;<span class="js__string">&quot;Helen&nbsp;Bennett&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactTitle&nbsp;=&nbsp;<span class="js__string">&quot;Marketing&nbsp;Manager&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;customerList;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small">The test</div>
<div class="endscriptcode">
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityLibrary;
using System.Collections.Generic;
using System.Linq;

namespace SampleUnitTest
{

    [TestClass]
    public class CustomerTest : CustomerCreateData
    {
        [TestTraits(Trait.Customers)]
        [TestMethod()]
        public void Customers_Has_SalesRepresentatives()
        {

            // ARRANGE create a list of customers
            CreateMockData();

            // get back the customers from the database table
            IEnumerable&lt;Customer&gt; customers = GetSandboxEntities&lt;Customer&gt;();

            //ACT
            var anySaleRepresenative = customers.Where((cust) =&gt; cust.ContactTitle == &quot;Sales Representative&quot;).Any();

            //ASSERT
            Assert.IsTrue(anySaleRepresenative, &quot;Expected to have some Sales Representative contacts&quot;);

        }
        [TestTraits(Trait.Customers)]
        [TestMethod()]
        public void LocateSpecificCustomerByContactNameAndContactTitle()
        {

            CreateMockData();

            var customers = GetSandboxEntities&lt;Customer&gt;();

            var result = (
                from cust in customers
                where cust.ContactName == &quot;Christina Berglund&quot; &amp;&amp; cust.ContactTitle == &quot;Order Administrator&quot;
                select cust).Count();

            Assert.AreEqual(1, result, &quot;Expected one customer&quot;);

        }
    }
}
</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">using&nbsp;Microsoft.VisualStudio.TestTools.UnitTesting;&nbsp;
using&nbsp;EntityLibrary;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.Linq;&nbsp;
&nbsp;
namespace&nbsp;SampleUnitTest&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestClass]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CustomerTest&nbsp;:&nbsp;CustomerCreateData&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestTraits(Trait.Customers)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Customers_Has_SalesRepresentatives()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;ARRANGE&nbsp;create&nbsp;a&nbsp;list&nbsp;of&nbsp;customers</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateMockData();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;get&nbsp;back&nbsp;the&nbsp;customers&nbsp;from&nbsp;the&nbsp;database&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;Customer&gt;&nbsp;customers&nbsp;=&nbsp;GetSandboxEntities&lt;Customer&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//ACT</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;anySaleRepresenative&nbsp;=&nbsp;customers.Where((cust)&nbsp;=&gt;&nbsp;cust.ContactTitle&nbsp;==&nbsp;<span class="js__string">&quot;Sales&nbsp;Representative&quot;</span>).Any();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//ASSERT</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(anySaleRepresenative,&nbsp;<span class="js__string">&quot;Expected&nbsp;to&nbsp;have&nbsp;some&nbsp;Sales&nbsp;Representative&nbsp;contacts&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestTraits(Trait.Customers)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;LocateSpecificCustomerByContactNameAndContactTitle()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateMockData();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;customers&nbsp;=&nbsp;GetSandboxEntities&lt;Customer&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;result&nbsp;=&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;from&nbsp;cust&nbsp;<span class="js__operator">in</span>&nbsp;customers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;cust.ContactName&nbsp;==&nbsp;<span class="js__string">&quot;Christina&nbsp;Berglund&quot;</span>&nbsp;&amp;&amp;&nbsp;cust.ContactTitle&nbsp;==&nbsp;<span class="js__string">&quot;Order&nbsp;Administrator&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;cust).Count();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="js__num">1</span>,&nbsp;result,&nbsp;<span class="js__string">&quot;Expected&nbsp;one&nbsp;customer&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small">And</div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode">
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityLibrary;
using System.Linq;

namespace SampleUnitTest
{
    [TestClass]
    public class PeopleTest : PersonCreateData
    {
        /// &lt;summary&gt;
        /// When asking for first person the first name should be Karen
        /// &lt;/summary&gt;
        [TestTraits(Trait.People)]
        [TestMethod()]
        public void FindPersonByFirstName()
        {

            CreateMockData();

            // get a mocked person
            var Person = GetSandboxEntities&lt;Person&gt;().FirstOrDefault();

            // validate they exist with first name of karen
            Assert.IsTrue(Person.FirstName == &quot;Karen&quot;);

            // change Karen to Mary
            SetFirstName(Person, &quot;Mary&quot;);
            Assert.IsFalse(Person.FirstName == &quot;Karen&quot;);

        }
        /// &lt;summary&gt;
        /// Check count of Person records equals how many were created
        /// in CreateMockData
        /// &lt;/summary&gt;
        [TestTraits(Trait.People)]
        [TestMethod()]
        public void PeopleCount()
        {

            CreateMockData();

            var thePeople = GetSandboxEntities&lt;Person&gt;();

            // assert there are two records matching mocked data
            Assert.AreEqual(2, thePeople.Count());
        }
        /// &lt;summary&gt;
        /// Get by first/last name and gender
        /// &lt;/summary&gt;
        [TestTraits(Trait.People)]
        [TestMethod()]
        public void ValidateIsFemale()
        {

            CreateMockData();

            // get Karen Payne and check gender type is female
            var Person = GetSandboxEntities&lt;Person&gt;().Where((p) =&gt; {
                return p.FirstName == &quot;Karen&quot; &amp;&amp; p.LastName == &quot;Payne&quot;;
            }).FirstOrDefault();

            Assert.IsTrue(Person.GenderType.Gender == &quot;Female&quot;);

        }
    }
}
</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">using&nbsp;Microsoft.VisualStudio.TestTools.UnitTesting;&nbsp;
using&nbsp;EntityLibrary;&nbsp;
using&nbsp;System.Linq;&nbsp;
&nbsp;
namespace&nbsp;SampleUnitTest&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestClass]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;PeopleTest&nbsp;:&nbsp;PersonCreateData&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;When&nbsp;asking&nbsp;for&nbsp;first&nbsp;person&nbsp;the&nbsp;first&nbsp;name&nbsp;should&nbsp;be&nbsp;Karen</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestTraits(Trait.People)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;FindPersonByFirstName()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateMockData();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;get&nbsp;a&nbsp;mocked&nbsp;person</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Person&nbsp;=&nbsp;GetSandboxEntities&lt;Person&gt;().FirstOrDefault();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;validate&nbsp;they&nbsp;exist&nbsp;with&nbsp;first&nbsp;name&nbsp;of&nbsp;karen</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(Person.FirstName&nbsp;==&nbsp;<span class="js__string">&quot;Karen&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;change&nbsp;Karen&nbsp;to&nbsp;Mary</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetFirstName(Person,&nbsp;<span class="js__string">&quot;Mary&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsFalse(Person.FirstName&nbsp;==&nbsp;<span class="js__string">&quot;Karen&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Check&nbsp;count&nbsp;of&nbsp;Person&nbsp;records&nbsp;equals&nbsp;how&nbsp;many&nbsp;were&nbsp;created</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;in&nbsp;CreateMockData</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestTraits(Trait.People)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;PeopleCount()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateMockData();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;thePeople&nbsp;=&nbsp;GetSandboxEntities&lt;Person&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;assert&nbsp;there&nbsp;are&nbsp;two&nbsp;records&nbsp;matching&nbsp;mocked&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="js__num">2</span>,&nbsp;thePeople.Count());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Get&nbsp;by&nbsp;first/last&nbsp;name&nbsp;and&nbsp;gender</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestTraits(Trait.People)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;ValidateIsFemale()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateMockData();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;get&nbsp;Karen&nbsp;Payne&nbsp;and&nbsp;check&nbsp;gender&nbsp;type&nbsp;is&nbsp;female</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Person&nbsp;=&nbsp;GetSandboxEntities&lt;Person&gt;().Where((p)&nbsp;=&gt;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;p.FirstName&nbsp;==&nbsp;<span class="js__string">&quot;Karen&quot;</span>&nbsp;&amp;&amp;&nbsp;p.LastName&nbsp;==&nbsp;<span class="js__string">&quot;Payne&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).FirstOrDefault();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(Person.GenderType.Gender&nbsp;==&nbsp;<span class="js__string">&quot;Female&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small"><span>Note to get at created data there is a function GetSandboxEntities&nbsp;</span></div>
<div class="endscriptcode">
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected IEnumerable&lt;T&gt; GetSandboxEntities&lt;T&gt;()
{
    var returnObject = (
        from item in annihilationList
        where item.GetType() == typeof(T)
        select (T)item);
    return returnObject;
}</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">protected&nbsp;IEnumerable&lt;T&gt;&nbsp;GetSandboxEntities&lt;T&gt;()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;returnObject&nbsp;=&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;from&nbsp;item&nbsp;<span class="js__operator">in</span>&nbsp;annihilationList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;item.GetType()&nbsp;==&nbsp;<span class="js__operator">typeof</span>(T)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;(T)item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;returnObject;&nbsp;
<span class="js__brace">}</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small">Usage</div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode">
<div class="scriptcode" style="font-size:small">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">IEnumerable&lt;Customer&gt; customers = GetSandboxEntities&lt;Customer&gt;();</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">IEnumerable&lt;Customer&gt;&nbsp;customers&nbsp;=&nbsp;GetSandboxEntities&lt;Customer&gt;();</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="font-size:small">To get a specific record use FirstOrDefault, a Where etc.</div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode" style="font-size:small">Let's look at Traits. The only thing to know is that you define your traits in the enum, give them useful names for when the show up in Test Explorer.</div>
<div class="endscriptcode" style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

public enum Trait
{
    Unit,
    Integration,
    Customers,
    People
}

public class TestTraitsAttribute : TestCategoryBaseAttribute
{
    private Trait[] traits;

    public TestTraitsAttribute(params Trait[] traits)
    {
        this.traits = traits;
    }

    public override IList&lt;string&gt; TestCategories
    {
        get
        {
            var traitStrings = new List&lt;string&gt;();

            foreach (var trait in this.traits)
            {
                string value = Enum.GetName(typeof(Trait), trait);
                traitStrings.Add(value);
            }

            return traitStrings;
        }
    }
}

</pre>
<div class="preview">
<pre class="js"><span style="font-size:small">using&nbsp;Microsoft.VisualStudio.TestTools.UnitTesting;&nbsp;
using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
&nbsp;
public&nbsp;enum&nbsp;Trait&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Unit,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Integration,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Customers,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;People&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;class&nbsp;TestTraitsAttribute&nbsp;:&nbsp;TestCategoryBaseAttribute&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;Trait[]&nbsp;traits;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;TestTraitsAttribute(params&nbsp;Trait[]&nbsp;traits)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.traits&nbsp;=&nbsp;traits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;override&nbsp;IList&lt;string&gt;&nbsp;TestCategories&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;traitStrings&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;trait&nbsp;<span class="js__operator">in</span>&nbsp;<span class="js__operator">this</span>.traits)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;value&nbsp;=&nbsp;Enum.GetName(<span class="js__operator">typeof</span>(Trait),&nbsp;trait);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;traitStrings.Add(value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;traitStrings;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">View from Test Explorer</div>
<div class="endscriptcode"><img id="171169" src="171169-19.jpg" alt="" width="324" height="285">&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">View</div>
<div class="endscriptcode"><img id="171170" src="171170-3.jpg" alt="" width="287" height="217"></div>
</div>
<div class="endscriptcode" style="font-size:small">In closing</div>
<div class="endscriptcode">
<ul>
<li><span style="font-size:small">Use the <a href="https://code.msdn.microsoft.com/VBNet-Entity-Framework-6-f9d8c6fe/sourcecode?fileId=171129&pathId=1753162865">
SQL script</a> to generate the database. </span></li><li><span style="font-size:small">In the app.config files, look for KARENS-PC, change it to the name of your SQL-Server server name.
</span></li><li><span style="font-size:small">Build/run test from Test Explorer or if your version/Edition of Visual Studio permits running test via Code Lens you that.
</span></li></ul>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:x-small">Code lens</span></div>
<div class="endscriptcode"><span style="font-size:x-small"><img id="171171" src="171171-30.jpg" alt="" width="743" height="179"><br>
</span></div>
<div class="endscriptcode" style="font-size:small"></div>
<div class="endscriptcode" style="font-size:small"><strong>Credits</strong></div>
<div class="endscriptcode" style="font-size:small">The method for creating and destroying mocked data was a joint effort of the team I work with in my daily developer job.</div>
<div class="endscriptcode" style="font-size:small"></div>
</div>
</div>
</div>
</div>
</div>
</div>
