# Calling an external assembly from Custom XSLT in BizTalk Server 2010 Maps
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- BizTalk Server 2010
## Topics
- BizTalk Server
- BizTalk
- BizTalk Mapper
## Updated
- 02/27/2017
## Description

<h1>Introduction</h1>
<p>So is usual in complex maps to have scripting functoid with custom inline XSLT, and sometimes is useful to call custom .Net components directly from XSLT.</p>
<h1><span>Building the Sample</span></h1>
<p>To illustrate this functionality, I decided to create a Class Library project: MapperExtensionsFunctions with a simple class where it is implemented a method to format the numbers in three decimal places:</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MapperExtensionsFunctions
{
    public class MappingFunctions
    {
        public MappingFunctions()
		{
		}

        public string ToDecimalPoint(string Input)
        {
            CultureInfo ciEN = new CultureInfo(&quot;en-US&quot;, false);

            double ConvertionDouble = double.Parse(Input, ciEN);
            string Output = string.Format(&quot;{0:0.000}&quot;, ConvertionDouble);
            return Output;
        }
    }
}</pre>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.Linq;&nbsp;
using&nbsp;System.Text;&nbsp;
using&nbsp;System.Globalization;&nbsp;
&nbsp;
namespace&nbsp;MapperExtensionsFunctions&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;MappingFunctions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MappingFunctions()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;ToDecimalPoint(string&nbsp;Input)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CultureInfo&nbsp;ciEN&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CultureInfo(<span class="js__string">&quot;en-US&quot;</span>,&nbsp;false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;double&nbsp;ConvertionDouble&nbsp;=&nbsp;double.Parse(Input,&nbsp;ciEN);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;Output&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;{0:0.000}&quot;</span>,&nbsp;ConvertionDouble);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Output;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><strong>How can we extend BizTalk map to support this functionality?</strong></p>
<p>You can add a custom extension xml file to your solution in order to declare the namespace and use a method from a .Net assembly from XSLT.</p>
<p>The extension file should look something like this:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;ExtensionObjects&gt;
  &lt;ExtensionObject Namespace=&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot; AssemblyName=&quot;MapperExtensionsFunctions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=cdbffba4cc751306&quot; ClassName=&quot;MapperExtensionsFunctions.MappingFunctions&quot; /&gt;
&lt;/ExtensionObjects&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;ExtensionObjects</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;ExtensionObject</span><span class="xml__attr_name">Namespace</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot;</span><span class="xml__attr_name">AssemblyName</span>=<span class="xml__attr_value">&quot;MapperExtensionsFunctions,&nbsp;Version=1.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=cdbffba4cc751306&quot;</span><span class="xml__attr_name">ClassName</span>=<span class="xml__attr_value">&quot;MapperExtensionsFunctions.MappingFunctions&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/ExtensionObjects&gt;</span></pre>
</div>
</div>
</div>
<p><strong>Note</strong>: &ldquo;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&rdquo; is the &ldquo;default namespace&rdquo;, However you can change it (see more
<a href="http://msdn.microsoft.com/en-us/library/aa547368%28v=bts.9%29.aspx">here</a>)</p>
<p>In the properties of your BizTalk Mapper, use the <strong>Custom Extension XML
</strong>property to open the <strong>Select Custom Extension XML File</strong> dialog box, in which you can select the file that contains the custom extension XML for the map (file above).</p>
<p><img id="62625" src="62625-custom-extension-xml.png" alt="" width="641" height="373"></p>
<p>&nbsp;</p>
<p>Finally in your Inline XSLT functoid you can use the methods from the assembly by:</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;xsl:variable name=&quot;result&quot; xmlns:ScriptNS0=&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot; select=&quot;ScriptNS0:ToDecimalPoint(MarketPrice/text())&quot; /&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">variable</span><span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;result&quot;</span><span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">ScriptNS0</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot;</span><span class="xml__attr_name">select</span>=<span class="xml__attr_value">&quot;ScriptNS0:ToDecimalPoint(MarketPrice/text())&quot;</span><span class="xml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<p>Or in this case, inside Inline XSLT Call Template:</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;xsl:template name=&quot;PriceTemplate&quot;&gt;
  &lt;xsl:param name=&quot;market&quot; /&gt;
  &lt;xsl:param name=&quot;owner&quot; /&gt;
  &lt;xsl:element name=&quot;Price&quot;&gt;
    &lt;xsl:variable name=&quot;pmarket&quot; xmlns:ScriptNS0=&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot; select=&quot;ScriptNS0:ToDecimalPoint($market)&quot; /&gt;
    &lt;xsl:variable name=&quot;powner&quot; xmlns:ScriptNS0=&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot; select=&quot;ScriptNS0:ToDecimalPoint($owner)&quot; /&gt;
    &lt;PriceMarket&gt;
      &lt;xsl:value-of select=&quot;$pmarket&quot; /&gt;
    &lt;/PriceMarket&gt;
    &lt;PriceOwner&gt;
      &lt;xsl:value-of select=&quot;$powner&quot; /&gt;
    &lt;/PriceOwner&gt;
  &lt;/xsl:element&gt;
&lt;/xsl:template&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">template</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;PriceTemplate&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">param</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;market&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">param</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;owner&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">element</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Price&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">variable</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;pmarket&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">ScriptNS0</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot;</span>&nbsp;<span class="xml__attr_name">select</span>=<span class="xml__attr_value">&quot;ScriptNS0:ToDecimalPoint($market)&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">variable</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;powner&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">ScriptNS0</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/BizTalk/2003/ScriptNS0&quot;</span>&nbsp;<span class="xml__attr_name">select</span>=<span class="xml__attr_value">&quot;ScriptNS0:ToDecimalPoint($owner)&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;PriceMarket</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">value-of</span>&nbsp;<span class="xml__attr_name">select</span>=<span class="xml__attr_value">&quot;$pmarket&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/PriceMarket&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;PriceOwner</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">value-of</span>&nbsp;<span class="xml__attr_name">select</span>=<span class="xml__attr_value">&quot;$powner&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/PriceOwner&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/xsl:element&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/xsl:template&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span style="font-size:20px; font-weight:bold">Houston we have a problem!</span></p>
<p>After Build, deploy and configure my project with success I decided to test my solution, but I keep getting the following error:</p>
<p style="padding-left:30px"><em>The Messaging Engine failed while executing the inbound map for the message coming from source URL:&quot;C:\TEMP\PORTS\IN_CAR\*.xml&quot; with the Message Type &quot;http://BizTalk.CallingExternalAssemblyFromInlineXSLT.CarInfo#CarProperty&quot;.
 Details:&quot;Cannot find the script or external object that implements prefix 'ScriptNS0'.&quot;</em></p>
<p>At first glance, this error suggests that the assembly in question is not published in the GAC&hellip; However even after re-publish, the assembly in the GAC the problem remained</p>
<p>Don&rsquo;t panic, believe it or not, you did everything right&hellip; BizTalk Server 2010/Visual Studio 2010 have a bug (or issue): Visual Studio does not persist the path of
<strong>Custom Extension XML </strong>property in the .BTM file.</p>
<p>So if someone wishes to use an external assembly in via a Inline XSLT/XSLT Template scripting functoid they cannot specify the external assembly through an extension xml file.</p>
<p>I tried to install the latest cumulative update package for BizTalk (CU5) and Visual Studio service pack but the issue still remain active (you can see more detail and vote to fix it
<a href="http://connect.microsoft.com/BizTalk/feedback/details/588819/visual-studio-does-not-save-custom-extension-xml-in-btm-file-if-custom-xslt-path-is-not-specified">
here</a>)</p>
<h1><span>&nbsp;</span><strong>Workaround (unfortunately it's manual)</strong></h1>
<p>You need to manually edit .BTM file to add this node between the elements &lt;/ScriptTypePrecedence&gt; and &lt;TreeValues&gt;:</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;CustomXSLT XsltPath=&quot;&quot; ExtObjXmlPath=&quot;.\xslt\ExternalAssembly.xml&quot; /&gt;</pre>
<div class="preview">
<pre class="js">&lt;CustomXSLT&nbsp;XsltPath=<span class="js__string">&quot;&quot;</span>&nbsp;ExtObjXmlPath=<span class="js__string">&quot;.\xslt\ExternalAssembly.xml&quot;</span>&nbsp;/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Note</strong>: Is not mandatory the CustomXSLT node stand between the elements &lt;/ScriptTypePrecedence&gt; and &lt;TreeValues&gt; however this is normal behavior of the compiler.</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<h1><strong>Workaround 2 (</strong><span id="result_box" class="short_text" lang="en"><span class="hps">automatic</span></span><strong>)</strong></h1>
<p>Using PowerShell script associated with the Pre-build actions of Visual Studio project will automatically fix this issue for us.</p>
<p>PowerShell script available for download on TechNet Gallery <a href="http://gallery.technet.microsoft.com/BizTalk-Mapper-Custom-3050cb3e">
here</a>.</p>
<p>The script accepts two parameters:</p>
<ul>
<li>The first parameter is the path to the map that we want to configure the custom extension XML;
</li><li>The second is the path to the ExternalAssembly.xml file file that refers the namespace to the FullyQualifiedName (FQN) of the .NET assembly.
</li></ul>
<p>Then we need to configure Pre-build actions of Visual Studio project to run this script:</p>
<ul>
<li>Copy the PowerShell script file: ExternalAssembluFix.ps1 to your project directory;
</li><li>Right-click on BizTalk project name and select &ldquo;Properties&rdquo; option;
</li><li>On the right three choose &ldquo;Build Events&rdquo; option:
<ul>
<li>Select the button &ldquo;Edit Pre-Build &hellip;&rdquo; and in the &ldquo;Pre-Build event command line&rdquo; windows type the following command:
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>PowerShell</span></div>
<pre class="powershell">Powershell&nbsp;<span class="powerShell__operator">-</span>File&nbsp;<span class="powerShell__string">&quot;$(ProjectDir)ExternalAssemblyFix.ps1&quot;</span>&nbsp;<span class="powerShell__string">&quot;$(ProjectDir)&lt;name_of_the_map&gt;&quot;</span>&nbsp;<span class="powerShell__string">&quot;$(ProjectDir)ExternalAssembly.xml&quot;</span></pre>
</div>
</div>
<ul>
<li><strong>Note</strong>: you must replace &lt;name_of_the_map&gt; with the name of your map.
</li></ul>
</li></ul>
</li></ul>
<p>You can learn more about this on my <a href="http://sandroaspbiztalkblog.wordpress.com/2012/07/30/biztalk-mapper-custom-extension-xml-property-fixed-with-powershell-script-biztalk-2010/">
blog</a>.</p>
<h1>About Me</h1>
<p><strong>Sandro Pereira</strong><br>
<a href="http://www.devscope.net/">DevScope</a>&nbsp;| MVP &amp; MCTS BizTalk Server 2010<br>
<a href="http://sandroaspbiztalkblog.wordpress.com/">http://sandroaspbiztalkblog.wordpress.com/</a>&nbsp;|&nbsp;<a href="http://twitter.com/sandro_asp">@sandro_asp</a></p>
<p><a href="http://www.devscope.net/"><img id="129835" src="129835-devscope-monochrome-black.png" alt="" width="166" height="51"></a></p>
