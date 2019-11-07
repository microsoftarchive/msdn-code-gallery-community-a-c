# Add random quotes in your Outlook email signature
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
- C# Language
## Topics
- Outlook
## Updated
- 11/29/2011
## Description

<h2>Introduction</h2>
<p>This article contains few funny things, which I would like to share with you guys. Well we will discuss about how we can add random quotes in our email signature, please note that we will use Microsoft Office Outlook 2007 as our email client software.</p>
<h2>Background</h2>
<p>I love quotes especially inspiration or motivational quotes &amp; I really enjoy using quotes in my email signature.&nbsp; When I &lsquo;m trying to choose quotes for my email signature I stuck! Which one I took, there are huge quotes are available and I
 can&rsquo;t choose one of them. Finally I decided that I will write a program which will randomly add quotes in my Outlook email signature</p>
<p><br>
So let&rsquo;s start, from the very beginning when I start writing this program I was little bit confused cause I could not decided which one I use, should I go for Add-In or windows services or a simple win32 Form application. So finally I decided that I will
 go for win32 application.<br>
<br>
</p>
<h2>How I do that&nbsp;</h2>
<p>I use very basic techniques / ways to do this are listed below:</p>
<ol>
<li>Create a signature in Microsoft Office Outlook. </li><li>Add a key word (#quotes#) at the bottom of the signature. </li><li>Create a template of the current signature. </li><li>Create an Xml document that contains all the quotes. </li><li>Finally add the quotes when Outlook is running. </li></ol>
<p>Let&rsquo;s discuss it with more detail &amp; go thru the list above:</p>
<h3>Create a signature in Microsoft Office Outlook</h3>
<p>Well at first we will create a signature file; it&rsquo;s very simple just open / run Microsoft Office Outlook and selects &ldquo;Option&rdquo; from the tools menu. A single windows Form will appear with multiple tabs ? select &ldquo;Mail Format&rdquo; tab.
 You will be found a button called &ldquo;Signatures&hellip;&rdquo; under this tab click on the button and create you Outlook email signature.
<br>
<br>
</p>
<h3>Add a key word (#quotes#) at the bottom of the signature</h3>
<p>Great! You create your signature and now add the key word (&ldquo;quotes&rdquo;) at the bottom of your signature.&nbsp; The following figure-A shows the key word with a signature.</p>
<p><img src="46868-quotes-init.png" alt=""></p>
<p>&nbsp;</p>
<p>Figure-A shows the key word with a signature</p>
<h2>Create a template of the current signature</h2>
<p>Now we will create the template of the current signature, we will use this template for randomly selected quotes and update the Microsoft Office Outlook signature file.&nbsp; Note that I face a lot of issues when I update the Outlook signature file, for
 example text encoding, getting garbage manipulating the string etc. I would appreciate your idea to resolve this in good manner, actually the current code is a little bit sloppy (my personal opinion).&nbsp;&nbsp; Anyway a sample code snippets is given below
 for the current scenario.</p>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        public void SignatureRawText(int index, bool isStart)
        {
            applicationDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) &#43; &quot;\\Microsoft\\Signatures&quot;;
            
            signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(applicationDataDir);
            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles(&quot;*.htm&quot;);
                if (fiSignature.Length &gt; 0)
                {
                    applicationDir = Environment.CurrentDirectory;
                    fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);

                    if (File.Exists(applicationDir &#43; @&quot;\template.htm&quot;))
                    {
                        diInfo = null;
                        diInfo = new DirectoryInfo(applicationDir);
                        fiSignature = diInfo.GetFiles(&quot;*.htm&quot;);
                        StreamReader streamReader = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                        signature = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                    else
                    {
                        File.Copy(fiSignature[0].FullName, applicationDir &#43; &quot;/template.htm&quot;);
                    }
                    if (!string.IsNullOrEmpty(signature))
                    {
                        try
                        {
                            QuotesService32.Class.IQuotesSignature quotesSignature = new QuotesSignature();

                            string strQuotes = Environment.NewLine
                                               &#43; &quot;&lt;p style=&quot;
                                               &#43; Convert.ToChar(34)
                                               &#43; &quot;font-family: Arial, Helvetica, sans-serif; font-size: 10px; font-weight: normal; font-style: normal; color: #008000; text-shadow: 2px 2px 8px #444&quot;
                                               &#43; Convert.ToChar(34)
                                               &#43; &quot;&gt;&quot;
                                               &#43; quotesSignature.GetQuotes(index).Replace(Convert.ToString(index), &quot;&quot;)
                                               &#43; &quot;&lt;/p&gt;&quot;;
                            if (isStart)
                            {
                                signatureText = signature.Replace(&quot;#quotes#&quot;, strQuotes);
                            }
                            else
                            {
                                signatureText = signature.Replace(&quot;#quotes#&quot;, &quot;&quot;);

                            }
                            byte[] seeds = System.Text.Encoding.ASCII.GetBytes(signatureText);
                            FileStream fileStream = new FileStream(applicationDataDir &#43; &quot;/&quot; &#43; fileName &#43; &quot;.htm&quot;, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                            if (fileStream.CanWrite)
                            {
                                for (int i = 0; i &lt; seeds.Length; i&#43;&#43;)
                                {
                                    if ((seeds[i]) != Convert.ToByte('?'))
                                    {
                                        binaryWriter.Write(seeds[i]);
                                    }

                                }

                                binaryWriter.Flush();
                                binaryWriter.Close();
                            }

                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }

                    }
                }
            }


        }
</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;SignatureRawText(<span class="cs__keyword">int</span>&nbsp;index,&nbsp;<span class="cs__keyword">bool</span>&nbsp;isStart)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;applicationDataDir&nbsp;=&nbsp;Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\\Microsoft\\Signatures&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signature&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectoryInfo&nbsp;diInfo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryInfo(applicationDataDir);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(diInfo.Exists)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileInfo[]&nbsp;fiSignature&nbsp;=&nbsp;diInfo.GetFiles(<span class="cs__string">&quot;*.htm&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(fiSignature.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;applicationDir&nbsp;=&nbsp;Environment.CurrentDirectory;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileName&nbsp;=&nbsp;fiSignature[<span class="cs__number">0</span>].Name.Replace(fiSignature[<span class="cs__number">0</span>].Extension,&nbsp;<span class="cs__keyword">string</span>.Empty);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(File.Exists(applicationDir&nbsp;&#43;&nbsp;@<span class="cs__string">&quot;\template.htm&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;diInfo&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;diInfo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryInfo(applicationDir);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fiSignature&nbsp;=&nbsp;diInfo.GetFiles(<span class="cs__string">&quot;*.htm&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;streamReader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(fiSignature[<span class="cs__number">0</span>].FullName,&nbsp;Encoding.Default);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signature&nbsp;=&nbsp;streamReader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;streamReader.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File.Copy(fiSignature[<span class="cs__number">0</span>].FullName,&nbsp;applicationDir&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/template.htm&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(signature))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QuotesService32.Class.IQuotesSignature&nbsp;quotesSignature&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QuotesSignature();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strQuotes&nbsp;=&nbsp;Environment.NewLine&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;p&nbsp;style=&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;Convert.ToChar(<span class="cs__number">34</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;font-family:&nbsp;Arial,&nbsp;Helvetica,&nbsp;sans-serif;&nbsp;font-size:&nbsp;10px;&nbsp;font-weight:&nbsp;normal;&nbsp;font-style:&nbsp;normal;&nbsp;color:&nbsp;#008000;&nbsp;text-shadow:&nbsp;2px&nbsp;2px&nbsp;8px&nbsp;#444&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;Convert.ToChar(<span class="cs__number">34</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;quotesSignature.GetQuotes(index).Replace(Convert.ToString(index),&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/p&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isStart)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signatureText&nbsp;=&nbsp;signature.Replace(<span class="cs__string">&quot;#quotes#&quot;</span>,&nbsp;strQuotes);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signatureText&nbsp;=&nbsp;signature.Replace(<span class="cs__string">&quot;#quotes#&quot;</span>,&nbsp;<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;seeds&nbsp;=&nbsp;System.Text.Encoding.ASCII.GetBytes(signatureText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileStream&nbsp;fileStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileStream(applicationDataDir&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;fileName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.htm&quot;</span>,&nbsp;FileMode.Open,&nbsp;FileAccess.ReadWrite,&nbsp;FileShare.ReadWrite);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BinaryWriter&nbsp;binaryWriter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BinaryWriter(fileStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(fileStream.CanWrite)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;seeds.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;((seeds[i])&nbsp;!=&nbsp;Convert.ToByte(<span class="cs__string">'?'</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;binaryWriter.Write(seeds[i]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;binaryWriter.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;binaryWriter.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;exception;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>A function to check is your Office Outlook is running or not:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        public bool IsOutlook7Running()
        {
            bool retVal = false;
            try
            {
                foreach (Process availableProcess in Process.GetProcesses(&quot;.&quot;))
                {
                    if (availableProcess.MainWindowTitle.Length &gt; 0)
                    {
                        //Check the available process 
                        if (availableProcess.ProcessName == &quot;OUTLOOK&quot;)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                retVal = false;
                throw exception;
            }

            return retVal;
        }</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">bool</span>&nbsp;IsOutlook7Running()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;retVal&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Process&nbsp;availableProcess&nbsp;<span class="cs__keyword">in</span>&nbsp;Process.GetProcesses(<span class="cs__string">&quot;.&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(availableProcess.MainWindowTitle.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;the&nbsp;available&nbsp;process&nbsp;</span><span class="cs__keyword">if</span>&nbsp;(availableProcess.ProcessName&nbsp;==&nbsp;<span class="cs__string">&quot;OUTLOOK&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;retVal&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;exception;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;retVal;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p></p>
<h2>Create an Xml document that contains all the quotes&nbsp;</h2>
<p>We will create a very simple xml file which will contain all the quotes with an ID. I use x-path for retrieve quotes from the xml document.&nbsp; A simple xml template is given below:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
&lt;dataroot xmlns:od=&quot;urn:schemas-microsoft-com:officedata&quot; generated=&quot;2011-11-26T15:32:29&quot;&gt;
&lt;T_QUOTES_TEXT&gt;
&lt;id_quotes_key&gt;1&lt;/id_quotes_key&gt;
&lt;tx_quotes&gt;&amp;quot;What lies behind us and what lies before us are tiny matters compared to what lies within us.&amp;quot; - Ralph Waldo Emerson&lt;/tx_quotes&gt;
&lt;/T_QUOTES_TEXT&gt;
&lt;T_QUOTES_TEXT&gt;
&lt;id_quotes_key&gt;2&lt;/id_quotes_key&gt;
&lt;tx_quotes&gt;&amp;quot;God, grant me the serenity to accept the things I cannot change, the courage to change the things I can, and the wisdom to know the difference.&amp;quot; - Reinhold Niebuhr&lt;/tx_quotes&gt;
&lt;/T_QUOTES_TEXT&gt;
&lt;T_QUOTES_TEXT&gt;
&lt;id_quotes_key&gt;3&lt;/id_quotes_key&gt;
&lt;tx_quotes&gt;&amp;quot;Honesty is the first chapter in the book of wisdom.&amp;quot; - Author Unknown&lt;/tx_quotes&gt;
&lt;/T_QUOTES_TEXT&gt;
&lt;T_QUOTES_TEXT&gt;
.........</pre>
<div class="preview">
<pre id="codePreview" class="xml"><span class="xml__tag_start">&lt;?xml</span><span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span><span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;UTF-8&quot;</span><span class="xml__tag_start">?&gt;</span><span class="xml__tag_start">&lt;dataroot</span><span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">od</span>=<span class="xml__attr_value">&quot;urn:schemas-microsoft-com:officedata&quot;</span><span class="xml__attr_name">generated</span>=<span class="xml__attr_value">&quot;2011-11-26T15:32:29&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;T_QUOTES_TEXT</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;id_quotes_key</span><span class="xml__tag_start">&gt;</span>1<span class="xml__tag_end">&lt;/id_quotes_key&gt;</span><span class="xml__tag_start">&lt;tx_quotes</span><span class="xml__tag_start">&gt;&amp;</span>quot;What&nbsp;lies&nbsp;behind&nbsp;us&nbsp;and&nbsp;what&nbsp;lies&nbsp;before&nbsp;us&nbsp;are&nbsp;tiny&nbsp;matters&nbsp;compared&nbsp;to&nbsp;what&nbsp;lies&nbsp;within&nbsp;us.<span class="xml__entity">&amp;quot;</span>&nbsp;-&nbsp;Ralph&nbsp;Waldo&nbsp;Emerson<span class="xml__tag_end">&lt;/tx_quotes&gt;</span><span class="xml__tag_end">&lt;/T_QUOTES_TEXT&gt;</span><span class="xml__tag_start">&lt;T_QUOTES_TEXT</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;id_quotes_key</span><span class="xml__tag_start">&gt;</span>2<span class="xml__tag_end">&lt;/id_quotes_key&gt;</span><span class="xml__tag_start">&lt;tx_quotes</span><span class="xml__tag_start">&gt;&amp;</span>quot;God,&nbsp;grant&nbsp;me&nbsp;the&nbsp;serenity&nbsp;to&nbsp;accept&nbsp;the&nbsp;things&nbsp;I&nbsp;cannot&nbsp;change,&nbsp;the&nbsp;courage&nbsp;to&nbsp;change&nbsp;the&nbsp;things&nbsp;I&nbsp;can,&nbsp;and&nbsp;the&nbsp;wisdom&nbsp;to&nbsp;know&nbsp;the&nbsp;difference.<span class="xml__entity">&amp;quot;</span>&nbsp;-&nbsp;Reinhold&nbsp;Niebuhr<span class="xml__tag_end">&lt;/tx_quotes&gt;</span><span class="xml__tag_end">&lt;/T_QUOTES_TEXT&gt;</span><span class="xml__tag_start">&lt;T_QUOTES_TEXT</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;id_quotes_key</span><span class="xml__tag_start">&gt;</span>3<span class="xml__tag_end">&lt;/id_quotes_key&gt;</span><span class="xml__tag_start">&lt;tx_quotes</span><span class="xml__tag_start">&gt;&amp;</span>quot;Honesty&nbsp;is&nbsp;the&nbsp;first&nbsp;chapter&nbsp;in&nbsp;the&nbsp;book&nbsp;of&nbsp;wisdom.<span class="xml__entity">&amp;quot;</span>&nbsp;-&nbsp;Author&nbsp;Unknown<span class="xml__tag_end">&lt;/tx_quotes&gt;</span><span class="xml__tag_end">&lt;/T_QUOTES_TEXT&gt;</span><span class="xml__tag_start">&lt;T_QUOTES_TEXT</span><span class="xml__tag_start">&gt;&nbsp;
</span>.........</pre>
</div>
</div>
</div>
<p></p>
<p>A sample code snippets for retrive the quote from the xml document</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        public string GetQuotes(int index)
        {
            string Quotes = string.Empty;

            XPathNavigator xPathNavigator;
            XPathDocument xPathDocument;
            XPathNodeIterator xPathNodeIterator;
            String strExpression;
            applicationDir = Environment.CurrentDirectory;
            try
            {
                xPathDocument = new XPathDocument(applicationDir &#43; @&quot;\Xml\T_QUOTES_TEXT.xml&quot;);
                xPathNavigator = xPathDocument.CreateNavigator();
                strExpression = &quot;/dataroot/T_QUOTES_TEXT[./id_quotes_key=&quot; &#43; Convert.ToString(index) &#43; &quot;]&quot;;
                xPathNodeIterator = xPathNavigator.Select(strExpression);
                while (xPathNodeIterator.MoveNext())
                {
                    Quotes &#43;= xPathNodeIterator.Current.Value;
                };

            }
            catch
            {
                Quotes = string.Empty;
            }


            return Quotes;

        }
</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;GetQuotes(<span class="cs__keyword">int</span>&nbsp;index)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;Quotes&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XPathNavigator&nbsp;xPathNavigator;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XPathDocument&nbsp;xPathDocument;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XPathNodeIterator&nbsp;xPathNodeIterator;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;strExpression;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;applicationDir&nbsp;=&nbsp;Environment.CurrentDirectory;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xPathDocument&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XPathDocument(applicationDir&nbsp;&#43;&nbsp;@<span class="cs__string">&quot;\Xml\T_QUOTES_TEXT.xml&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xPathNavigator&nbsp;=&nbsp;xPathDocument.CreateNavigator();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strExpression&nbsp;=&nbsp;<span class="cs__string">&quot;/dataroot/T_QUOTES_TEXT[./id_quotes_key=&quot;</span>&nbsp;&#43;&nbsp;Convert.ToString(index)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;]&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xPathNodeIterator&nbsp;=&nbsp;xPathNavigator.Select(strExpression);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(xPathNodeIterator.MoveNext())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Quotes&nbsp;&#43;=&nbsp;xPathNodeIterator.Current.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Quotes&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Quotes;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>For more about x-path could be found at <a title="x-path" href="http://msdn.microsoft.com/en-us/magazine/cc164116.aspx">
this link</a>.</p>
<h3>Finally add the quotes when Outlook is running&nbsp;</h3>
<p>Well, we are almost done! Now we will create a simple windows application which will be run and display as system tray application with the following menu:<br>
&nbsp;&nbsp;&nbsp;&nbsp; 1. Start<br>
&nbsp;&nbsp;&nbsp;&nbsp; 2. Stop<br>
&nbsp;&nbsp;&nbsp;&nbsp; 3. Settings<br>
&nbsp;&nbsp;&nbsp;&nbsp; 4. Exit<br>
Well, the figure-B show the quotes addition and figure-C show the running state of this program:</p>
<p><img src="46869-quotes-add.png" alt=""></p>
<p>Figure-B show the output / randomly selected quote in your email signature.</p>
<p>&nbsp;</p>
<p><img src="46870-running-apps.png" alt="" width="302" height="225"></p>
<p>Figure-B showing the application running state.</p>
<h2>Points of Interest</h2>
<p>Few more things i would do, that is make it geniric, xml data manupulation &amp; some more features.</p>
<h2>Conclusion</h2>
<p>I hope you guys get scenario,&nbsp; So if you want to use quotes in your Outlook email signature now you can create your own application.</p>
<h2>History</h2>
<ul>
<li>Tuesday, November 29, 2011: Initial post. </li></ul>
<p>&nbsp;</p>
