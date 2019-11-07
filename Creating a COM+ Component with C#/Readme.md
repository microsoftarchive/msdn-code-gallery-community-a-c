# Creating a COM+ Component with C#
## Requires
- Visual Studio 2002
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- COM Interop
- COM+
## Updated
- 08/23/2011
## Description

<h1>Introduction</h1>
<p class="Text">The .NET Framework allows developers to create serviced (configured) components, which can take advantage of services offered by COM&#43;. The most commonly used of these services include Transaction management, Just-In-Time (JIT) Activation,
 Synchronization, and Object Pooling. The System.EnterpriseServices namespace provides the .NET developer with access to these services. This example demonstrates how to create a COM&#43; component, which takes advantage of Transaction management service within
 COM&#43;, assign a strong name to the assembly, register the assembly in the Global Assembly Cache, and finally register the component with COM&#43;.</p>
<h1>Contents</h1>
<ul>
<li>The Download contains the Visual Studio .NET solution file.
<ul>
<li><strong>COMPlusDotNet:</strong> Contains the source code for the COM&#43; Class Library project.
</li></ul>
<ul>
<li><strong>COMPlus:</strong>&nbsp;Contains the source code for the Windows Forms client project.
</li></ul>
</li></ul>
<h1>How to Use</h1>
<p class="Text">How these examples are set up for use depends upon where the self-extracting archive is unpacked. For the purposes of this example, the following variables are defined.</p>
<p class="Text">&ldquo;&lt;ServerAppPath&gt;&rdquo; = refers to the application directory of the &ldquo;COMPlusDotNet&rdquo; project.</p>
<p class="Text">&ldquo;&lt;ServerConfigPath&gt;&rdquo; = refers to the Build Configuration directory (i.e., Debug or Release) for the &ldquo;COMPlusDotNet&rdquo; project. If the project is built for release, then the location of &lt;ServerConfigPath&gt; is
 represented as &ldquo;&lt;ServerAppPath&gt;\obj\Release&rdquo;.</p>
<p class="Text">&ldquo;&lt;ClientAppPath&gt;&rdquo; = refers to the application directory of the &ldquo;COMPlus&rdquo; client project.</p>
<p class="Text">&ldquo;&lt;SDKRoot&gt;&rdquo; = refers to the location of the .NET Framework SDK on the local machine. If the local machine has Visual Studio.NET installed and default installation locations were accepted during setup, then the location of
 this directory is:&nbsp; &ldquo;C:\Program Files\Microsoft Visual Studio .NET\FrameworkSDK\Bin&rdquo;</p>
<p class="Text">&ldquo;&lt;FrameworkRoot&gt;&rdquo; = refers to the location of the .NET Framework on the local machine. Again, assuming the machine has Visual Studio .NET installed and default installation locations were accepted during setup, then the location
 of this directory is:&nbsp; &ldquo;C:\WINNT\Microsoft.NET\Framework\vX.X.XXXX&rdquo; where &ldquo;X.X.XXXX&rdquo; is the current version number of Visual Studio .NET.</p>
<p class="Text">Additionally, this example requires access to a SQL Server 2000 with the &ldquo;Northwind&rdquo; sample database installed.</p>
<p class="AlertText">Note&nbsp;&nbsp;&nbsp;This example assumes a local installation of SQL Server 2000 is present, with an administrator username of &ldquo;sa&rdquo; and password of blank. For simplicity, the connection string property for the ADO.NET connection
 used in the COMPlusDotNet server has been supplied in code. If this example is being run on a machine that does not have a local installation of SQL Server, or if the Administrator username and password are not as stated above, then the connection string property
 will have to be altered in both the Customers and CustomersDB classes in the COMPlusSample.cs file.</p>
<p class="Text">To begin using this example, unzip the files to a specified directory. Navigate to the &ldquo;COMPlusDotNet&rdquo; solution and open the solution in Visual Studio.NET. This example already contains Builds for the solution, and the Build Configuration
 is set to &ldquo;Release.&rdquo;&nbsp;</p>
<h5>Build the Solution</h5>
<p class="Text">To rebuild this solution with this configuration, select Build&gt;Rebuild COMPlusDotNet from the Visual Studio.NET menu.</p>
<h5>Register with the GAC</h5>
<p class="Text">The next step is to register this component with the Global Assembly Cache. To do this, open the command prompt and navigate to the &lt;SDKRoot&gt;. At the &lt;SDKRoot&gt; prompt, type the following:&nbsp;</p>
<p class="Code">gacutil &ndash;i <em>&lt;ServerConfigPath&gt;</em>\COMPlusDotNet.dll</p>
<p class="AlertText">Note&nbsp;&nbsp;&nbsp;Instead of moving the prompt to &lt;SDKRoot&gt;, it is also possible to type:</p>
<p class="Code">&lt;SDKRoot&gt;\gacutil &ndash;i &lt;ServerConfigPath&gt;\COMPlusDotNet.dll</p>
<p class="Text">If the &lt;SDKRoot&gt; path is unknown on the machine, perform a search for the gacutil.exe application and substitute the directory that contains that application for the &lt;SDKRoot&gt;.</p>
<p class="Text">This command will register the assembly with the Global Assembly Cache (GAC). To ensure the assembly has been successfully added to the cache, open Windows Explorer and type:</p>
<p class="Code">C:\WINNT\assembly</p>
<p class="Text">This opens the GAC Viewer, which shows all assemblies on the local machine, which are registered with the GAC. The COMPlusDotNet assembly should show up in the list, provided no errors were encountered during the registration of this assembly.</p>
<h5>Install the Component into COM&#43;</h5>
<p class="Text">The next step is to install the component into COM&#43; Services. To do this, open up the command prompt window again and move the prompt to the &lt;FrameworkRoot&gt;. At the &lt;FrameworkRoot&gt; type the following:</p>
<p class="Code">Regsvcs &lt;ServerConfigPath&gt;\COMPlusDotNet.dll</p>
<p class="Text">To verify the application has been installed in COM&#43;, open the Component Services MMC and expand the Component Services\Computers\My Computer\COM&#43; Applications node. The COM Plus Services Example application should be installed.</p>
<h5>Open the Client Application and Reference the COM&#43; Server</h5>
<p class="Text">The next step is to open the client application COMPlus and set a reference to the COMPlusDotNet.dll. To do this, right-click References in the Project Explorer or select Project from the menu. Select Add Reference and click the Browse button.
 Navigate to &lt;ServerConfigPath&gt; and select COMPlusDotNet.dll.</p>
<h4>Description</h4>
<p class="Text">This example consists of a client application (Windows Forms application) and a Server application (Library Application). Functionally, the example allows the user to select a customer from a combo box control and view all orders by clicking
 the Get Orders button. A data grid is populated with all orders for that customer. The user may then click on an order to get the associated order details. The user has the ability to edit the Quantity of items for that particular order and update this quantity
 by selecting the Update Details button. A message box is returned to the user informing the success or failure of the operation and transaction. This example will focus on the code inside of the COMPlusDotNet server.</p>
<p class="Text">To take advantage of the services offered by COM&#43;, the .NET Framework provides the System.EnterpriseServices namespace. To create a project to be installed in COM&#43;, a reference must be added to the project. Notice in the References section
 inside of Project Explorer that a reference to the System.EnterpriseServices namespace exists. Additionally, the using directive has been added to the top of the COMPlusSample.cs file. This assembly contains two classes: The CustomersDB class returns data
 used to populate the form in the client application (COMPlus). The Customers class contains code that will update the quantity of items for the specified order. Notice that both classes inherit from the ServiceComponent class. This means that both classes
 are able to programmatically access the services offered by COM&#43;. Also, notice that both classes provide a default constructor. To author a &ldquo;serviced&rdquo; component, then .NET Framework requires that only a default constructor be provided. Parameterized
 constructors are not allowed.</p>
<p class="Text">To specify the transaction options for a class the attribute [Trasaction(TransactionOption.Option)] must be added. Here, the CustomersDB class specifies that it Supports transactions, while the Customers class specifies that transactions are
 Required.</p>
<p>Here is the definition for the Customers class, to include the constructor:</p>
<p class="Code">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
[Transaction(TransactionOption.Required)]
public class Customers : ServicedComponent
{
public Customers()
{
}

//code for the class
}
This class is now considered a configured class, and consequently has access to its associated context object, when it is instantiated by another application.

A look at the UpdateDetailQuantity method will show this:

public bool UpdateDetailQuantity(int OrderID, string ProductName, int Quantity)
{
      SqlConnection cn = CreateConnection();
      cn.Open();
      try
      {
      if(!ContextUtil.IsInTransaction)
            throw new Exception(&quot;Requires Transaction&quot;);

string CommandText = &quot;Update [Order Details] set Quantity =
&quot;&#43;Quantity&#43;&quot; where
            OrderID = &quot;&#43;OrderID&#43;&quot; AND [Order Details].ProductID IN&quot;;

            CommandText&#43;= &quot;(Select ProductID from Products where ProductName =
'&quot;&#43;ProductName&#43;&quot;')&quot;;

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = cn;
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = CommandText;
      cmd.ExecuteNonQuery();
      ContextUtil.SetComplete();
      return true;
      }
     catch (Exception e)
      {
            cn.Close();
            ContextUtil.SetAbort();
            return false;
      }
      finally
      {
            cn.Close()
      }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.SqlClient;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.EnterpriseServices;&nbsp;
[Transaction(TransactionOption.Required)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Customers&nbsp;:&nbsp;ServicedComponent&nbsp;
{&nbsp;
<span class="cs__keyword">public</span>&nbsp;Customers()&nbsp;
{&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//code&nbsp;for&nbsp;the&nbsp;class</span>&nbsp;
}&nbsp;
This&nbsp;<span class="cs__keyword">class</span>&nbsp;<span class="cs__keyword">is</span>&nbsp;now&nbsp;considered&nbsp;a&nbsp;configured&nbsp;<span class="cs__keyword">class</span>,&nbsp;and&nbsp;consequently&nbsp;has&nbsp;access&nbsp;to&nbsp;its&nbsp;associated&nbsp;context&nbsp;<span class="cs__keyword">object</span>,&nbsp;when&nbsp;it&nbsp;<span class="cs__keyword">is</span>&nbsp;instantiated&nbsp;by&nbsp;another&nbsp;application.&nbsp;
&nbsp;
A&nbsp;look&nbsp;at&nbsp;the&nbsp;UpdateDetailQuantity&nbsp;method&nbsp;will&nbsp;show&nbsp;<span class="cs__keyword">this</span>:&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;UpdateDetailQuantity(<span class="cs__keyword">int</span>&nbsp;OrderID,&nbsp;<span class="cs__keyword">string</span>&nbsp;ProductName,&nbsp;<span class="cs__keyword">int</span>&nbsp;Quantity)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlConnection&nbsp;cn&nbsp;=&nbsp;CreateConnection();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(!ContextUtil.IsInTransaction)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;Requires&nbsp;Transaction&quot;</span>);&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;CommandText&nbsp;=&nbsp;&quot;Update&nbsp;[Order&nbsp;Details]&nbsp;<span class="cs__keyword">set</span>&nbsp;Quantity&nbsp;=&nbsp;
<span class="cs__string">&quot;&#43;Quantity&#43;&quot;</span>&nbsp;where&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrderID&nbsp;=&nbsp;<span class="cs__string">&quot;&#43;OrderID&#43;&quot;</span>&nbsp;AND&nbsp;[Order&nbsp;Details].ProductID&nbsp;IN&quot;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CommandText&#43;=&nbsp;&quot;(Select&nbsp;ProductID&nbsp;from&nbsp;Products&nbsp;where&nbsp;ProductName&nbsp;=&nbsp;
<span class="cs__string">'&quot;&#43;ProductName&#43;&quot;'</span>)&quot;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Connection&nbsp;=&nbsp;cn;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandType&nbsp;=&nbsp;CommandType.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;CommandText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContextUtil.SetComplete();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContextUtil.SetAbort();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">In the UpdateDetailQuantity method a connection to the Northwind database is opened, and the method attempts to update the quantity of items for the specified order ID and product name. The method first checks the ContextUtil object
 to determine if the method is contained within a transaction. If the calling application does not currently have a transaction open, then a transaction should have been created when the call was made to the UpdateDetailQuantity method. If the calling application
 did not currently have a transaction open, or one was not created automatically when the method was called, then an exception is thrown. Once the method completes its work in the Northwind database, a call is made to the ContextUtil.SetComplete() method. This
 means that everything has completed successfully, and this method has cast its &ldquo;vote&rdquo; to commit the transaction. In this example the transaction will commit, and the quantity will be updated.</div>
<p class="Text">This example is fairly simple, in that only one action is being performed within this transaction; however, if the calling application had enlisted a transaction and other methods were performed within UpdateQuantityMethod, then ContextUtil.SetComplete()
 would merely alert the transaction coordinator (MSDTC) that its work has completed successfully.</p>
<p class="Text">To see in this example what happens when a transaction completes successfully and when one fails, select a customer from the drop down list. Click on an order in the data grid. In the details data grid, select a detail, and set the quantity
 equal to a positive integer value. Click the Update Details button and a message box should return stating that the operation has completed successfully and the transaction has been committed. Now, change the quantity to zero and click the Update Details button
 again. A message box should return stating the operation has failed and the transaction has been aborted. This is because the Order Details table inside of the Northwind database has a check constraint on the Quantity column that ensures that values are greater
 than zero. In other words, every item listed in the Order Details table must have a quantity of at least one.</p>
<h5>Assembly Information</h5>
<p class="Text">When a new project is created in Visual Studio .NET, the environment automatically creates an AssemblyInfo.cs file. Prior to building a Serviced Component, some entries to the AssemblyInfo.cs file are required. First, the using System.EnterpriseServices
 directive should be added to the top of the file.</p>
<p class="Text">At the bottom of the file, add the following entries. These entries are required before a component can take advantage of COM&#43; Services.</p>
<p class="Code">[assembly: ApplicationActivation(ActivationOption.Server)]</p>
<p class="Code">[assembly: ApplicationID(&quot;96D7999B-439B-4aea-9A06-DF8E3BE5CAB0&quot;)]</p>
<p class="Code">[assembly: ApplicationName(&quot;COM Plus Services Example&quot;)]</p>
<p class="Code">[assembly: Description(&quot;An example of creating a COM&#43; application from .NET&quot;)]</p>
<p class="Text">The first entry specifies the Activation Option inside of COM&#43;. Here the value has been set to Server, which means that COM&#43; will create the application in its own dedicated process. If this application crashes, it will not crash the calling
 application. The other option for this entry is Library, which means the application will be created within the calling application process.</p>
<p class="Text">The next entry is the Application ID. This value can be generated using the GUID Generator from Visual Studio .NET. To create an Application ID, select Tools&gt;Create GUID and click the Copy button, when the dialog box appears. Paste the
 value into this entry.</p>
<p class="Text">The next entry is the Application Name. This name will appear inside of the Component Services MMC as the application&rsquo;s name.</p>
<p class="Text">The next entry is the Application Description. Though it is not necessarily required, it is a good idea to provide one.</p>
<h5>Creating a Strong Name</h5>
<p class="Text">Before an assembly can be registered with the GAC, a Strong Name must be created. The purpose of creating a Strong Name is to ensure that it is globally unique, and that no other assemblies, which may be installed on that machine, can have
 the same name. A Strong Name is comprised of the following:</p>
<p>1)&nbsp;&nbsp;&nbsp; The Name of the assembly itself.</p>
<p>2)&nbsp;&nbsp;&nbsp; The Version Number of the assembly.</p>
<p>3)&nbsp;&nbsp;&nbsp; A Public/Private Key pair.</p>
<p>4)&nbsp;&nbsp;&nbsp; A Culture.</p>
<p class="Text">To create a Strong Name for your assembly, build the solution, open the command prompt, and navigate to &lt;SDKRoot&gt;. At the &lt;SDKRoot&gt; prompt, type:</p>
<p class="Code">sn &ndash;k <em>&lt;ServerConfigPath&gt;</em>\mynewkey.snk</p>
<p class="Text">This will create the Public Key token inside the manifest for the assembly. Once this is complete, another entry should be included in the AssemblyInfo.cs:</p>
<p class="Code">[assembly: AssemblyKeyFile(&quot;mynewkey.snk&quot;)]</p>
<p class="Text">This entry specifies the location of the file, which includes the information about the Strong Name of this assembly. The value here is relative to the &lt;ServerConfigPath&gt; for the assembly. In this example, the .snk file is located in
 the same directory as the assembly. If the .snk file is located in the &lt;ServerAppRoot&gt; for instance, then the value here would be ../../mynewkey.snk.</p>
<p class="Text">Now the assembly can be added to the GAC and then installed in COM&#43; as described above.</p>
