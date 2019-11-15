# C# Send Fax using fax Modem
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- WPF
## Topics
- C#
## Updated
- 12/28/2016
## Description

<h1>Sending Fax</h1>
<p><em><span>faxcom library can send fax. Although interfax create a list of problem for faxcoblib</span></em></p>
<p><em><span><a href="https://www.interfax.net/en/dev/faxcomexlib"><span>https://www.interfax.net/en/dev/faxcomexlib</span></a></span></em></p>
<p><em><span>I think if you follow my instruction there will be no problem for sending fax.</span></em></p>
<p><strong>&nbsp;</strong></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h1><span>How add faxcomlib on your project</span></h1>
<p><em><span>In my sample i have use 4 extra dll</span></em></p>
<p><em><span>&nbsp;Interop.FAXCOMEXLib.dll</span></em></p>
<p><em><span>System.Management.dll</span></em></p>
<p><em><span>System.Management.Instrumentation.dll</span></em></p>
<p><em><span>System.Windows.Interactivity.dll</span></em></p>
<p><em><span>all of them you will find out on Package DLL folder.<strong>&nbsp;</strong>&nbsp;</span></em></p>
<p><em><span>if you want to add faxcomlib from your visual studio.</span></em></p>
<p><em><span><img id="166401" src="166401-1.png" alt="" width="819" height="542"></span></em><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold"><br>
</span></p>
<p><em><span><em>if you run the sample you can see the fax status runtime on the left hand side and fax information on the right hand side.</em></span><strong>&nbsp;</strong><em>&nbsp;</em></em></p>
<p><em>&nbsp;<img id="166402" src="166402-2.png" alt="" width="819" height="474"></em></p>
<p>&nbsp;</p>
<p>preparing document</p>
<p>&nbsp; private void FaxDocumentSetup()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc = new FaxDocument();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.Priority = FAX_PRIORITY_TYPE_ENUM.fptHIGH;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.ReceiptType = FAX_RECEIPT_TYPE_ENUM.frtNONE;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.AttachFaxToReceipt = true;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CheckFileIsNotInUse();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.Sender.Name = FaxObj.SenderName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.Sender.Company = FaxObj.SenderCompany;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.Body = FaxObj.FaxBodyPath;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.Subject = FaxObj.FaxSubject;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.DocumentName = FaxObj.FaxDocumentName;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; faxDoc.Recipients.Add(FaxObj.RecipientFaxNumber, FaxObj.RecipientName);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PrintFaxStatus(FaxJobStatus&nbsp;faxJobStatus)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Dispatcher.Invoke((Action)(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesRECEIVING)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;is&nbsp;receiving&nbsp;a&nbsp;fax.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesPARTIALLY_RECEIVED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;incoming&nbsp;fax&nbsp;was&nbsp;partially&nbsp;received.&nbsp;Some&nbsp;(but&nbsp;not&nbsp;all)&nbsp;of&nbsp;the&nbsp;pages&nbsp;are&nbsp;available.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesNO_DIAL_TONE)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;has&nbsp;encountered&nbsp;a&nbsp;fatal&nbsp;protocol&nbsp;error.&nbsp;Please&nbsp;check&nbsp;your&nbsp;fax&nbsp;line&nbsp;connection.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesNO_ANSWER)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;receiving&nbsp;device&nbsp;did&nbsp;not&nbsp;answer&nbsp;the&nbsp;call.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesNOT_FAX_CALL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;received&nbsp;a&nbsp;call&nbsp;that&nbsp;was&nbsp;a&nbsp;data&nbsp;call&nbsp;or&nbsp;a&nbsp;voice&nbsp;call.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesNONE)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;No&nbsp;extended&nbsp;status&nbsp;value&nbsp;Fax&nbsp;Call&nbsp;None...&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesLINE_UNAVAILABLE)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;is&nbsp;not&nbsp;available&nbsp;because&nbsp;it&nbsp;is&nbsp;in&nbsp;use&nbsp;by&nbsp;another&nbsp;application.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesINITIALIZING)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;is&nbsp;initializing&nbsp;a&nbsp;call.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesFATAL_ERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;has&nbsp;encountered&nbsp;a&nbsp;fatal&nbsp;protocol&nbsp;error:&nbsp;To&nbsp;resolve&nbsp;the&nbsp;issue&nbsp;please&nbsp;connect&nbsp;your&nbsp;modem&nbsp;driver&nbsp;and&nbsp;if&nbsp;required&nbsp;install&nbsp;driver&nbsp;software&nbsp;for&nbsp;your&nbsp;modem.&nbsp;If&nbsp;your&nbsp;are&nbsp;connecting&nbsp;your&nbsp;modem&nbsp;to&nbsp;this&nbsp;computer&nbsp;for&nbsp;the&nbsp;first&nbsp;time&nbsp;please&nbsp;restart&nbsp;your&nbsp;computer.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesDISCONNECTED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;sender&nbsp;or&nbsp;the&nbsp;caller&nbsp;disconnected&nbsp;the&nbsp;fax&nbsp;call.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_DELAYED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;delayed&nbsp;a&nbsp;fax&nbsp;call&nbsp;because&nbsp;the&nbsp;sending&nbsp;device&nbsp;received&nbsp;a&nbsp;busy&nbsp;signal&nbsp;multiple&nbsp;times.&nbsp;The&nbsp;device&nbsp;cannot&nbsp;retry&nbsp;the&nbsp;call&nbsp;because&nbsp;dialing&nbsp;restrictions&nbsp;exist.&nbsp;(Some&nbsp;countries/regions&nbsp;restrict&nbsp;the&nbsp;number&nbsp;of&nbsp;retry&nbsp;attempts&nbsp;when&nbsp;a&nbsp;number&nbsp;is&nbsp;busy.)&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_BLACKLISTED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;could&nbsp;not&nbsp;complete&nbsp;a&nbsp;call&nbsp;because&nbsp;the&nbsp;telephone&nbsp;number&nbsp;was&nbsp;blocked&nbsp;or&nbsp;reserved;&nbsp;emergency&nbsp;numbers&nbsp;such&nbsp;as&nbsp;911&nbsp;are&nbsp;blocked.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_ABORTED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;call&nbsp;was&nbsp;aborted.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesBUSY)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;encountered&nbsp;a&nbsp;busy&nbsp;signal.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesDIALING)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;is&nbsp;dialing&nbsp;a&nbsp;fax&nbsp;number.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesHANDLED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;fax&nbsp;service&nbsp;processed&nbsp;the&nbsp;outbound&nbsp;fax;&nbsp;the&nbsp;fax&nbsp;service&nbsp;provider&nbsp;will&nbsp;transmit&nbsp;the&nbsp;fax.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesBAD_ADDRESS)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;dialed&nbsp;an&nbsp;invalid&nbsp;fax&nbsp;number.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesTRANSMITTING)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;device&nbsp;is&nbsp;sending&nbsp;a&nbsp;fax.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.Status&nbsp;==&nbsp;FAX_JOB_STATUS_ENUM.fjsCOMPLETED&nbsp;&amp;&amp;&nbsp;faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_COMPLETED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;Fax&nbsp;is&nbsp;sent&nbsp;successfully&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FindAndKillProcess(<span class="cs__string">&quot;WFS&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(faxJobStatus.ExtendedStatusCode&nbsp;==&nbsp;FAX_JOB_EXTENDED_STATUS_ENUM.fjesPROPRIETARY)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faxStatusTextBox.Document.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(<span class="cs__keyword">new</span>&nbsp;Run(<span class="cs__string">&quot;The&nbsp;ExtendedStatusCode&nbsp;property&nbsp;specifies&nbsp;a&nbsp;code&nbsp;describing&nbsp;the&nbsp;job's&nbsp;extended&nbsp;status.&quot;</span>&nbsp;&#43;&nbsp;Environment.NewLine)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>&nbsp;</span></h1>
<p><span>You need to ensure&nbsp;4 tings on your PC.</span></p>
<p><span>1. A Faxmodem with line. to check the modem status you can follow</span></p>
<p><span><img id="166405" src="https://i1.code.msdn.s-msft.com/c-send-fax-using-fax-modem-357aca81/image/file/166405/1/3.png" alt="" width="681" height="508"></span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span>2. Phone and Modem area code<img id="166406" src="https://i1.code.msdn.s-msft.com/c-send-fax-using-fax-modem-357aca81/image/file/166406/1/4.png" alt="" width="809" height="522"></span></p>
<p><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>&nbsp;</p>
<p><span>3. Windows fax and scan service on.</span></p>
<p>&nbsp;</p>
<p><span><img id="166408" src="https://i1.code.msdn.s-msft.com/c-send-fax-using-fax-modem-357aca81/image/file/166408/1/5.png" alt="" width="418" height="407"><br>
</span></p>
<p><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>&nbsp;</p>
<p><span>4. Free&nbsp;adobe reader <a href="https://get.adobe.com/reader/"><span>https://get.adobe.com/reader/</span></a></span></p>
<p>&nbsp;</p>
<p><strong>After completing these 4 steps if you run the application you will see modem information</strong></p>
<p><strong>&nbsp;<img id="166430" src="https://i1.code.msdn.s-msft.com/c-send-fax-using-fax-modem-357aca81/image/file/166430/1/f1.png" alt="" width="812" height="467"></strong><em>
</em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>After giving the fax information when you will click send fax button it will dial the fax number, sending fax and complete the send fax.</p>
<p><img id="166431" src="https://i1.code.msdn.s-msft.com/c-send-fax-using-fax-modem-357aca81/image/file/166431/1/f2.png" alt="" width="1294" height="765"></p>
<p>&nbsp;</p>
<p><img id="166432" src="https://i1.code.msdn.s-msft.com/c-send-fax-using-fax-modem-357aca81/image/file/166432/1/f3.png" alt="" width="1245" height="835"></p>
<p>&nbsp;</p>
<p><img id="166433" src="https://i1.code.msdn.s-msft.com/c-send-fax-using-fax-modem-357aca81/image/file/166433/1/f4.png" alt=""></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Thank you</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span><br>
</span></p>
<p><strong>&nbsp;</strong><em>&nbsp;</em></p>
