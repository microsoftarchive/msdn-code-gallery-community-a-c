# ASP.NET MVC SAP Crystal report
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- .NET Framework 4.0
- ASP.NET MVC 4
- Visual Studio 2012
## Topics
- Using Crystal Report in ASP.net MVC
- Crystal Report in Visual Studio 2012
- Crystal report using datasource
## Updated
- 11/27/2014
## Description

<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
1.Download the latest version Crystal report from SAP:</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
3. Close your VS-2012/2013&nbsp; and install the new downloaded<span class="Apple-converted-space">&nbsp;</span><strong>CRforVS<span class="Apple-converted-space">
</span></strong>.</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
4. Take a new MVC project</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
code sample</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
&nbsp;&nbsp; SqlConnectionStringBuilder SConn = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[&quot;ConnectionStringOther&quot;].ConnectionString);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SqlConnection thisConnection = new SqlConnection(thisConnectionString);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // store procedure<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand(&quot;PIS_GetAllEmployeeInfo&quot;, thisConnection);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mySelectCommand.CommandType = CommandType.StoredProcedure;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; reportDocument = new ReportDocument();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Report path<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string reportPath = Server.MapPath(&quot;~/Reports/Crystal/EmployeeListCrystalReport.rpt&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; reportDocument.Load(reportPath);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Report connection<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ConnectionInfo connInfo = new ConnectionInfo();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connInfo.ServerName = SConn.DataSource;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connInfo.DatabaseName = SConn.InitialCatalog;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connInfo.UserID = SConn.UserID;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connInfo.Password = SConn.Password;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tableLogOnInfo.ConnectionInfo = connInfo;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportDocument.Database.Tables)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.ApplyLogOnInfo(tableLogOnInfo);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.Location = &quot;dbo.&quot; &#43; table.Location;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // You can pass parameter in your store procedure if you need<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //reportDocument.SetParameterValue(&quot;@FromDate&quot;, ProjectUtilities.ConvertToDate(txtFromDate.Text));<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //reportDocument.SetParameterValue(&quot;@ToDate&quot;, ProjectUtilities.ConvertToDate(txtToDate.Text));<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EmployeeListCrystalReport.ReportSource = reportDocument;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EmployeeListCrystalReport.DataBind();</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
</div>
<div style="color:#000000; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
&nbsp;&nbsp;
<div class="endscriptcode">&nbsp;</div>
</div>
<p><em><img id="130445" src="130445-17.png" alt="" width="1104" height="508"></em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="130446" src="130446-25.png" alt=""></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> public ActionResult EmployeeListReport()
        {
            ReportViewerViewModel model = new ReportViewerViewModel();
            string content = Url.Content(&quot;~/Reports/CrystalViewer/EmployeeList.aspx&quot;);
            model.ReportPath = content;
            return View(&quot;ReportViewer&quot;, model);
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;EmployeeListReport()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReportViewerViewModel&nbsp;model&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ReportViewerViewModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;content&nbsp;=&nbsp;Url.Content(<span class="cs__string">&quot;~/Reports/CrystalViewer/EmployeeList.aspx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.ReportPath&nbsp;=&nbsp;content;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(<span class="cs__string">&quot;ReportViewer&quot;</span>,&nbsp;model);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><em></em></p>
<h1>More Information</h1>
<p><em>For more information you can see</em></p>
<p><a href="http://atikpassion.blogspot.com/2014/11/aspnet-mvc-sap-crystal-report.html"><em>http://atikpassion.blogspot.com/2014/11/aspnet-mvc-sap-crystal-report.html</em></a></p>
<p><em><br>
</em></p>
