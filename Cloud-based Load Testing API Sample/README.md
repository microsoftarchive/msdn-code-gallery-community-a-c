# Cloud-based Load Testing API Sample
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Visual Studio Online Cloud Load Testing
## Topics
- Performance testing
## Updated
- 07/30/2015
## Description

<h1>
<div class="endscriptcode">&nbsp;</div>
Introduction</h1>
<p><em>This sample enables the user to run a load test using the &quot;Visual Studio Online - Cloud-based Load Testing Service&quot;</em></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><em>The sample does the following to run a load test using the &quot;Visual Studio Online - Cloud-based Load Testing Service&quot;</em></p>
<ol>
<li><em>Creates a Test Drop </em></li><li><em>Upload the Load Test Solution into the test Drop</em> </li><li><em>Creates a load test run with above created test drop ID</em> </li><li><em>Queue the above created load test run</em> </li><li><em>Tracks the status and waits for the run to be completed.</em> </li></ol>
<p>Note : This Sample doesn't have the functionality to download and import the load test run results. If you're looking for the API sample to import load test tesults, go here.</p>
<p>Note : This sample require uses &quot;Basic authentication&quot; mechanism. For this you to use the alternate credentials that is enabled against your VSO account. More information on how to create alternate credentail is @
<a href="http://www.visualstudio.com/en-us/integrate/get-started/get-started-auth-introduction-vsi">
http://www.visualstudio.com/en-us/integrate/get-started/get-started-auth-introduction-vsi</a></p>
<p><em>&nbsp;</em><span>Source Code Files</span></p>
<ul>
<li><em>CloudLoadTestingClient.cs - Driver program that parses the command line parameter and invokes only of the following action</em>
<ul>
<li><em>Gets all test run belonging to the VSO account</em> </li><li><em>Create, Queue and tracks the run till completion</em> </li><li><em>Get a particular test run details</em> </li></ul>
</li><li><em><em>ClthttpClientWrapper.cs - Wrapper to the HttpClient </em></em></li><li><em>CltObjectFactory.cs - Factory class that creates Cloud load testing specific objects like TestRun, TestDrop etc</em>
</li><li><em>Cltoperations.cs - This is a layer between the driver program and REST calls</em>
</li><li><em>CltUploadAndDownloadHelper.cs - This uploads and downloads the load test solution contents to&nbsp; azure blob</em>
</li><li><em>CltWebApi.cs - This is the layer that actually invokes the REST API</em> </li><li><em>HttpClientExtensions.cs - This is an extension to the HttpClient class that implements PATCH methods</em>
</li><li><em>Logger.cs - a console logger</em> </li></ul>
<p>How to unzip the loadtest archieve?</p>
<p>1. The download archive file will have &quot;.ltrar.zip&quot; as extension</p>
<p>2. Change the file extension from &quot;.ltrar.zip&quot; to &quot;.ltrar.gz&quot;</p>
<p>3. Run &quot;gzip.exe -d &lt;filename.ltar.gz&gt;</p>
<p>4. After this you open the ltrar using &quot;Open and Manage Load Test Results&quot;.</p>
<p>&nbsp;</p>
<h1><em>&nbsp;</em></h1>
