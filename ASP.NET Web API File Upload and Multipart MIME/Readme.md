# ASP.NET Web API: File Upload and Multipart MIME
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API
## Topics
- ASP.NET Web API
## Updated
- 09/21/2012
## Description

<p>This sample contains the finished code for the tutorial <a href="http://www.asp.net/web-api/overview/working-with-http/sending-html-form-data,-part-2">
Sending HTML Form Data</a>.</p>
<p>[Excerpt from the tutorial follows]</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<p>This tutorial shows how to upload files to a web API. It also describes how to process multipart MIME data.</p>
<p>Here is an example of an HTML form for uploading a file:</p>
<pre class="prettyprint">&lt;form name=&quot;form1&quot; method=&quot;post&quot; enctype=&quot;multipart/form-data&quot; action=&quot;api/upload&quot;&gt;
    &lt;div&gt;
        &lt;label for=&quot;caption&quot;&gt;Image Caption&lt;/label&gt;
        &lt;input name=&quot;caption&quot; type=&quot;text&quot; /&gt;
    &lt;/div&gt;
    &lt;div&gt;
        &lt;label for=&quot;image1&quot;&gt;Image File&lt;/label&gt;
        &lt;input name=&quot;image1&quot; type=&quot;file&quot; /&gt;
    &lt;/div&gt;
    &lt;div&gt;
        &lt;input type=&quot;submit&quot; value=&quot;Submit&quot; /&gt;
    &lt;/div&gt;
&lt;/form&gt;</pre>
<p>This form contains a text input control and a file input control. When a form contains a file&nbsp;input control, the
<strong>enctype</strong> attribute&nbsp;should always be &quot;multipart/form-data&quot;, which specifies&nbsp;that the form will be sent as a multipart MIME message.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>The format of a multipart MIME&nbsp;message is easiest to&nbsp;&nbsp;understand by looking at an example request:</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<pre class="prettyprint">POST http://localhost:50460/api/values/1 HTTP/1.1
User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0
Accept: text/html,application/xhtml&#43;xml,application/xml;q=0.9,*/*;q=0.8
Accept-Language: en-us,en;q=0.5
Accept-Encoding: gzip, deflate
Content-Type: multipart/form-data; boundary=---------------------------41184676334
Content-Length: 29278

-----------------------------41184676334
Content-Disposition: form-data; name=&quot;caption&quot;

Summer vacation
-----------------------------41184676334
Content-Disposition: form-data; name=&quot;image1&quot;; filename=&quot;GrandCanyon.jpg&quot;
Content-Type: image/jpeg

<em>(Binary data not shown)</em>
-----------------------------41184676334--
</pre>
<p><br>
This message is divided into two <em>parts</em>, one for each form control. Part boundaries are indicated by the lines that start with dashes.</p>
<p>&nbsp;</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;