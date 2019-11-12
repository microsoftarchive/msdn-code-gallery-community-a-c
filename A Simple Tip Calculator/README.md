# A Simple Tip Calculator
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Phone 7
- C# Language
- Windows Phone SDK 7.1
## Topics
- Controls
- Silverlight
- User Interface
- XML
- Windows Phone
## Updated
- 09/11/2018
## Description

<h1>Introduction</h1>
<p>This a Simple Tip Calculator, that I created over the summer for a school project.&nbsp;The calculator is not only used to calculate&nbsp;Tip Amounts but&nbsp;is also able to split a total amount of money between different amount of people.&nbsp; &nbsp;</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>There are several industries in which it is customary to leave a tip for services rendered, but how much to tip? Examples of some people that might deserve a tip from you are waiters and waitresses, hairdressers, taxi drivers, bellhops, maids, etc. The decision
 to leave a tip is most often based on your satisfaction of the service.&nbsp; Use&nbsp;this tip calculator as a resource to take the guesswork out of tipping.</p>
<p>&nbsp;The&nbsp;Tip is generally in the range of 10% to 20% depending on what services have been performed and how well the person did. For example, you may be more inclined to leave your restaurant server a 15% tip based on the amount of the bill as opposed
 to giving a 5% or 10% tip to a taxi driver. Calculating the amount of the tip can be confusing which is why the tip calculator below comes in so handy.</p>
<p><strong>The sample code below is needed to:</strong></p>
<p>To&nbsp;calculate the tip amount from the selected percentage. We need to create a new total amount to pay by adding the original bill amount to the tip amount. Lastly, we need to calculate how to split the bill among one or more people.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;doCalcs()&nbsp;
&nbsp;
{&nbsp;
&nbsp;
<span class="cs__keyword">try</span>&nbsp;
&nbsp;
{&nbsp;
&nbsp;
baseTab&nbsp;=&nbsp;<span class="cs__keyword">double</span>.Parse(txtTab.Text);&nbsp;
&nbsp;
toTip&nbsp;=&nbsp;tipPercentage&nbsp;/&nbsp;<span class="cs__number">100.0</span>&nbsp;*&nbsp;baseTab;&nbsp;
&nbsp;
txtTip.Text&nbsp;=&nbsp;toTip.ToString(<span class="cs__string">&quot;$###,##0.00&quot;</span>);&nbsp;
&nbsp;
total&nbsp;=&nbsp;baseTab&nbsp;&#43;&nbsp;toTip;&nbsp;
&nbsp;
txtTotal.Text&nbsp;=&nbsp;total.ToString(<span class="cs__string">&quot;$###,##0.00&quot;</span>);&nbsp;
&nbsp;
mySplit&nbsp;=&nbsp;total&nbsp;/&nbsp;splitAmong;&nbsp;
&nbsp;
txtSplit.Text&nbsp;=&nbsp;mySplit.ToString(<span class="cs__string">&quot;$###,##0.00&quot;</span>);&nbsp;
&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">catch</span>&nbsp;{&nbsp;}&nbsp;
&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
