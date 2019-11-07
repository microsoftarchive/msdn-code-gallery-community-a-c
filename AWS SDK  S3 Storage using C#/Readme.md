# AWS SDK  S3 Storage using C#
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- autofac
- Dependency Injection
- ASP.NET MVC 5
- Visual Studio 2017
- AWS SDK
- AWS S3
- AWS S3 Bucket
- AWS S3 Object
## Topics
- AWS S3 Storage
- AWS Security
- AWS S3 Bucket Creation using AWS SDk
- AWS S3 Object Creation using AWS SDK
- AWS S3 Bucket URL Creation using AWS SDk
- AWS S3 Download URL Creation using AWS SDK
## Updated
- 04/02/2018
## Description

<h1>Introduction</h1>
<p><em>I created this sample to access AWS S3 storage using AWS SDK and C#. This sample shows how you can create</em></p>
<p><em>Bucket and upload objects into buckets. I used ASP.net MVC 5 to perform all CRUD operations.&nbsp;</em></p>
<p><em>This sample also uses dependency injection using Autofac and used it inside controllers to inject.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>AWS SDK for .net</em></p>
<p><em>Autofac</em></p>
<p><em>Visual Studio 2015</em></p>
<p><em>.net framework 4.6</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This is first time i learned AWS. As per as my understanding , AWS SDK for .net is very easy to use API and Amazon provides rich documentation.&nbsp;</p>
<p>AWS S3 is is robust and fast storage system mostlly used for CDN and static website hosting. AWS S3 is budget friendly and secure .</p>
<p>In this sample , i showed how we can create Bucket and upload file inside it. I tried to make it simple as possible.</p>
<p>I hope it will be very helpful for developers for all level.</p>
<p><strong style="color:#ff0000">Visit and login&nbsp; <a href="https://www.console.aws.amazon.com/">
https://www.console.aws.amazon.com</a></strong></p>
<p>&nbsp;<img id="197459" src="197459-aws-step%201.png" alt=""></p>
<p><strong><span style="color:#ff0000">After Login Click on User Name , showing right side on top.</span></strong></p>
<p>&nbsp;<img id="197460" src="197460-aws-step%202.png" alt=""></p>
<p><span style="color:#ff0000"><strong>Click on My Security Credentials</strong></span></p>
<p>&nbsp;<img id="197461" src="197461-aws-step%203.png" alt=""></p>
<p><strong><span style="color:#ff0000">Click Continue to Security Credentials&nbsp; on the Dialog box</span></strong></p>
<p>&nbsp;<img id="197462" src="197462-aws-step%204.png" alt=""></p>
<p><strong><span style="color:#ff0000">Click Create New Access Key on Your Security Credentials Page</span></strong></p>
<p>&nbsp;<img id="197463" src="197463-aws-step%205.png" alt=""></p>
<p><strong><span style="color:#ff0000">Copy Access key and Secret key from Create Access key dialog, you can also download Access key for feature use into your machine.</span></strong></p>
<p>&nbsp;<img id="197464" src="197464-aws-step%206.png" alt=""></p>
<p><strong><span style="color:#ff0000">Add Secret key into Web.Config file</span></strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="color:#ff0000; font-size:medium"><strong>Output</strong></span></p>
<p><span style="font-size:20px; font-weight:bold"><br>
</span></p>
<p><img id="197452" src="197452-op1.png" alt="" width="1677" height="734"><img id="197455" src="197455-op2.png" alt="" width="1836" height="738"><img id="197456" src="197456-op3.png" alt="" width="1608" height="648"><img id="197457" src="197457-op4.png" alt="" width="1220" height="656"><img id="197458" src="197458-op5.png" alt="" width="1259" height="684"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Click here to add your code snippet.using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.S3;

namespace TestWeb.Utilities.Common
{
    public class AWSService : IAWSServce
    {
        public AWSService() { }
        //public AWSService(string accessKey,string secretkey,RegionEndpoint regionEndpoint )
        //{
        //    this.AccessKey = accessKey;
        //    this.SecretKey = secretkey;
        //    this.RegionEndpoint = regionEndpoint;
        //}
        public virtual IAmazonS3 Client {
            get { return Amazon.AWSClientFactory.CreateAmazonS3Client(Config.AccessKey,Config.SecretKey,RegionEndpoint.APNortheast1); }
        }

        //public string AccessKey { get; set; }
        //public string SecretKey { get; set; }
        //public RegionEndpoint RegionEndpoint {
        //    get { return RegionEndpoint.APNortheast2; }
        //    set { RegionEndpoint = value; }
        //}
    }
}</pre>
<div class="preview">
<pre class="csharp">Click&nbsp;here&nbsp;to&nbsp;add&nbsp;your&nbsp;code&nbsp;snippet.<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Amazon;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Amazon.S3;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;TestWeb.Utilities.Common&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AWSService&nbsp;:&nbsp;IAWSServce&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;AWSService()&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//public&nbsp;AWSService(string&nbsp;accessKey,string&nbsp;secretkey,RegionEndpoint&nbsp;regionEndpoint&nbsp;)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;this.AccessKey&nbsp;=&nbsp;accessKey;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;this.SecretKey&nbsp;=&nbsp;secretkey;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;this.RegionEndpoint&nbsp;=&nbsp;regionEndpoint;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;IAmazonS3&nbsp;Client&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;Amazon.AWSClientFactory.CreateAmazonS3Client(Config.AccessKey,Config.SecretKey,RegionEndpoint.APNortheast1);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//public&nbsp;string&nbsp;AccessKey&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//public&nbsp;string&nbsp;SecretKey&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//public&nbsp;RegionEndpoint&nbsp;RegionEndpoint&nbsp;{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;{&nbsp;return&nbsp;RegionEndpoint.APNortheast2;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;{&nbsp;RegionEndpoint&nbsp;=&nbsp;value;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><span></span></p>
<div class="endscriptcode">&nbsp;AWSService.cs</div>
<p>&nbsp;</p>
<p>&nbsp;IAWSService.cs</p>
<p>BucketController</p>
<p>UploadController</p>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
