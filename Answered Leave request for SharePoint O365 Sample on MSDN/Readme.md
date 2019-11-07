# Answered: Leave request for SharePoint O365 Sample on MSDN
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Office 365
- Sharepoint Online
- Windows Workflow 4
- SharePoint Server 2013
- apps for SharePoint
- Visual Studio 2013
## Topics
- Business Process Flows
## Updated
- 11/10/2013
## Description

<h2>Pr&eacute;cis</h2>
<p><span style="font-size:small">So, I as a cure for insomnia i decided to troll the CODE.MSDN site for questions that interested me. I found this request and figured it was something i could knock out, so i did. There was not much to go on interms of HARD
 requirements so i posed a question, I assumed if Im up and about, the person making the request must be up too :-) but alas no. So, i went ahead and did the sample as I would envision it. In fact, internally at work, we have something On Prem that is similar
 so this actually made it more appealing. I can and will make this example more robust and may submit it up on the MarketPlace, I dont know, just to say that I have, but it seems something that Im sure must already be there, Ill just endeavor to make mine better
 :-) </span></p>
<h2>Requirements</h2>
<p><span style="font-size:small">As this is an Office 365 SharePoint Online example, you basically don't need anything as you would for an On-Prem solution, all you need really is:
</span></p>
<ul>
<li><span style="font-size:small">A Office 365 SharePoint Online Site to build against
</span></li><li><span style="font-size:small">Visual Studio [for completeness I am using 2013 but others will do]
</span></li><li><span style="font-size:small">Your Brain &amp; some Idle time </span></li></ul>
<p><span style="font-size:small">&nbsp;What this example will set out to do in this version is the following
</span></p>
<ol>
<li><span style="font-size:small">Permit an End User to Request Leave off Work/ Holiday/ Vacation etc.
</span></li><li><span style="font-size:small">Send a Request for Approval to the End Users Manager/ or the person On Behalf Of
</span></li><li><span style="font-size:small">Permit the Approver to Adjudicate the request in an Approval Workflow in SharePoint 2013</span>
</li><li><span style="font-size:small">Send a &lsquo;Contract of Sorts&rdquo; to the Requester alerting them of the decision for their acknowledgement
</span>
<ol>
<li><span style="font-size:small">Notification includes a process to Accept the decision or Appeal it
</span></li></ol>
</li><li><span style="font-size:small">If Approved, update a Leave/Out of Office (OOF) Calendar with the relevant information to show the person being OOF I plan to extend this example later on to flesh out the Appeals Process, make pretty App Icon and put some
 more bells and whistles on it. Sexy it up so to speak :-) </span></li></ol>
<h2>Approach</h2>
<p><span style="font-size:small">As with all my work when I set out to do a SharePoint project that involves List/Libraries, Content Types, Workflows/Event Receivers, etc, I often will create my own Site Columns, Content Types, List Definition and Instance
 (see post here on how to do that). Once I complete that process I typically will Branch my Project (in TFS Online) and start to Dev out the Unit of work/ Story (Agile). I created a branch for Workflows and set up folders for what I will build out now and later
 on image This is what my Visual Studio Solution looks like now image So, with that heavy lifting complete, lets focus on the Workflow.</span></p>
<p><span style="font-size:small">See My blog post here for a Deep Dive: <a href="http://fabiangwilliams.wordpress.com/2013/11/10/answered-leave-request-for-sharepoint-o365-sample-on-msdn">
http://fabiangwilliams.wordpress.com/2013/11/10/answered-leave-request-for-sharepoint-o365-sample-on-msdn</a>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
