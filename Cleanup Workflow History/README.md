# Cleanup Workflow History
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- SharePoint 2007
- SharePoint 2010
## Topics
- SharePoint Workflow
- SharePoint Administration
## Updated
- 09/09/2011
## Description

<div class="wikidoc">A command-line tool to cleanup the workflow history list in a SharePoint site. SharePoint has a &quot;Workflow Auto Cleanup&quot; job that deletes the association, but it does not delete items from the Workflow History list.
<br>
<br>
<strong>Background</strong><br>
When I started my job, I was told that one of the Workflow History lists for an InfoPath form that uses SharePoint 2007 workflows had around 500,000 items in it. To clean the Workflow History list, they would delete &amp; recreate the site. I couldn't find
 any other solutions so I wrote this console application. I used it to get the list to under 10,000 items, and I still run it every night to keep the list at a manageable size.</div>
<div class="wikidoc"></div>
<div class="wikidoc"><span style="text-decoration:underline">Update </span>(2/9/11): I have confirmed with Microsoft Support that this issue still exists in SharePoint 2010</div>
<div class="wikidoc"><span style="text-decoration:underline">Update </span>(3/15/11): As discussed in the Q&amp;A section, if you are going to use this on SharePoint 2010 servers you will need to recompile the project using the .Net 3.5 Framework.&nbsp; If
 you are going to use this on SharePoint 2007, you don't have to make any changes.&nbsp; I will upload a VS2010 version of this project shortly.</div>
<div class="wikidoc"><br>
<a class="externalLink" href="http://technet.microsoft.com/en-us/library/cc298800%28office.12%29.aspx">http://technet.microsoft.com/en-us/library/cc298800%28office.12%29.aspx</a><br>
<em>By default, Microsoft Office SharePoint Server 2007 runs a daily Workflow Auto Cleanup job to permanently delete workflow instances and related task entries that still exist 60 days after a workflow is completed or cancelled.
<strong>Workflow history items themselves are not deleted</strong>, but the entry point to view them on the status page for a particular instance will no longer be available.</em><br>
<br>
<strong>Usage</strong><br>
Run CleanupWorkflowHistory .exe from the command line without any parameters to see how to use it. All of the parameters are required:<br>
&bull; SiteUrl &ndash; URL to the SharePoint site<br>
&bull; ListName &ndash; Name of the Workflow History list<br>
&bull; NumDays &ndash; Delete items with Last Modified date older than (Today &ndash; NumDays). The Auto Cleanup timer job uses 60 days by default, so use 60 if you are unsure what to use.<br>
&bull; MaxHistoryListDelete &ndash; Maximum number of items to delete from the Workflow History list<br>
&bull; MaxRecycleBinDelete &ndash; Maximum number of items to delete from the Recycle Bin<br>
&bull; PermanentDelete &ndash; Permanently delete list items from the Recycle Bin</div>
<div class="wikidoc">&bull; ReportOnly &ndash; Run in read-only mode<br>
&bull; LogFileName &ndash; Name of the file to use for logging (overwrite if it exists)<br>
<br>
<em>Example</em>:<br>
CleanupWorkflowHistory.exe http://moss/site &quot;Workflow History&quot; 60 100 100 false true Cleanup.log<br>
<br>
<strong>Recommendations</strong><br>
Some things to keep in mind when cleaning up the workflow history lists with this application:<br>
&bull; Do it during off-hours. In the application I use the most efficient way to do batch updates in SharePoint (SPWeb.ProcessBatchData). The WFE SharePoint servers won&rsquo;t be affected much, but the SQL database server may get busy.<br>
&bull; Pause SharePoint Search crawls if you have any scheduled to run while you are doing the clean up.<br>
&bull; Make sure you don&rsquo;t have a SharePoint / SQL backup scheduled to run while you are doing the clean up.<br>
&bull; Keep an eye on the SQL transaction logs. Depending on how many items you delete, the transaction logs could become pretty big. Here&rsquo;s my thread on TechNet that shows one problem I ran into, and how I fixed it:
<a class="externalLink" href="http://social.technet.microsoft.com/Forums/en-US/sharepointadmin/thread/05c2e4a1-33c2-439e-bacf-870410e4366a">
http://social.technet.microsoft.com/Forums/en-US/sharepointadmin/thread/05c2e4a1-33c2-439e-bacf-870410e4366a</a>.<br>
&bull; Once you have a feel for how long it takes to complete a &ldquo;cycle&rdquo;, you can use Scheduled Tasks to run it from the command line and have it run every X minutes (instead of running it manually).
<br>
For reference, I had a Workflow History list with 500,000 items, and I used this tool to clean it up. Initially, I was able to delete 7,500 items in 25 minutes, so I scheduled it to run every 30 minutes. As the size of the list gets smaller, less time is required
 to do the cleanup.<br>
&bull; Run it on a development server first so you know what to expect.</div>
<div class="wikidoc"></div>
<div class="wikidoc"></div>
<div class="wikidoc"></div>
<div class="wikidoc"><strong>CleanupWorkflowHistory.exe running in Report Mode (read-only):</strong></div>
<div class="wikidoc"><img src="http://i1.code.msdn.microsoft.com/cleanup-workflow-history-cee6e75e/image/file/18740/1/report_mode.jpg" alt="" width="668" height="355"></div>
<div class="wikidoc"></div>
<div class="wikidoc"></div>
<div class="wikidoc"></div>
<div class="wikidoc"><strong>CleanupWorkflowHistory logfile:</strong></div>
<div class="wikidoc"><img src="http://i3.code.msdn.microsoft.com/cleanup-workflow-history-cee6e75e/image/file/18741/1/cleanup_log.jpg" alt="" width="552" height="483"></div>
