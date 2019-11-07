# Building camera app with library in Windows 10
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- Windows Runtime
- Metro style device app
- Windows Store Apps
## Topics
- Photo Gallery
- camera
## Updated
- 09/26/2015
## Description

<h1>Introduction</h1>
<p><em>This article provides an overview of creating a Camera application in Windows 10 metro applications. The source ccode sample provides the application, back-end code and other resources required to create application. The application not only shows how
 to create the app, but also how to create the library to display the images that were taken using the application.&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>I used Visual Studio 2015 to create the application. Windows 10 is also required to build and use the sample.&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Windows Runtime provides us with functions and objects required to create an application that lets us take photos and share data and read the data from the folders of the application's data.</em></p>
<p><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>
<pre class="hidden">private async void capturePhoto()
{
     if(!isRecording)
     {
          var file = await (await ApplicationData.Current.LocalFolder.CreateFolderAsync(&quot;Photos&quot;,     
                                      CreationCollisionOption.OpenIfExists)
                                      ).CreateFileAsync(&quot;Photo.jpg&quot;, 
                                      CreationCollisionOption.GenerateUniqueName);

          await capture.CapturePhotoToStorageFileAsync(ImageEncodingProperties.CreateJpeg(), file);
     } else
     {
          await new MessageDialog(&quot;Application is currently recording your camera, please stop recording and try again.&quot;, &quot;Recording&quot;).ShowAsync();
     }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;capturePhoto()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(!isRecording)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;file&nbsp;=&nbsp;await&nbsp;(await&nbsp;ApplicationData.Current.LocalFolder.CreateFolderAsync(<span class="cs__string">&quot;Photos&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreationCollisionOption.OpenIfExists)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;).CreateFileAsync(<span class="cs__string">&quot;Photo.jpg&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreationCollisionOption.GenerateUniqueName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;capture.CapturePhotoToStorageFileAsync(ImageEncodingProperties.CreateJpeg(),&nbsp;file);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;<span class="cs__keyword">new</span>&nbsp;MessageDialog(<span class="cs__string">&quot;Application&nbsp;is&nbsp;currently&nbsp;recording&nbsp;your&nbsp;camera,&nbsp;please&nbsp;stop&nbsp;recording&nbsp;and&nbsp;try&nbsp;again.&quot;</span>,&nbsp;<span class="cs__string">&quot;Recording&quot;</span>).ShowAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>&nbsp;</em></div>
<p>&nbsp;</p>
<p>I used the following code to capture the videos, all of them make use of the native Windows Runtime APIs and objects.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em>C#</em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span></em>
<pre class="hidden"><em>private async void alterRecording()
{
     if(isRecording)
     {
          // Stop recording
          await capture.StopRecordAsync();
          videoIcon.Foreground = new SolidColorBrush(new Windows.UI.Color() { A = 255, R = 0, G = 0, B = 0 }); // Black
          isRecording = false; // Not recording any more
     } else
     {
          encoding = getVideoEncoding(); // Get the current encoding selection.

          // Start recording
          var file = await (await ApplicationData.Current.LocalFolder.CreateFolderAsync(&quot;Videos&quot;, 
                                  CreationCollisionOption.OpenIfExists)).CreateFileAsync(
                                  string.Format(&quot;Recording_{0}-{1}.{2}&quot;, 
                                  myEncoding, 
                                  myQuality, 
                                  (myEncoding == &quot;MP4&quot;) ? &quot;mp4&quot; : &quot;wav&quot;), 
                                  CreationCollisionOption.GenerateUniqueName);

          await capture.StartRecordToStorageFileAsync(encoding, file);

          videoIcon.Foreground = new SolidColorBrush(new Windows.UI.Color() { A = 255, R = 255, G = 0, B = 0 }); // Red
          isRecording = true; // Capturing the video stream.
     }
}</em></pre>
<div class="preview">
<pre class="csharp"><em><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;alterRecording()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(isRecording)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Stop&nbsp;recording</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;capture.StopRecordAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;videoIcon.Foreground&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush(<span class="cs__keyword">new</span>&nbsp;Windows.UI.Color()&nbsp;{&nbsp;A&nbsp;=&nbsp;<span class="cs__number">255</span>,&nbsp;R&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;G&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;B&nbsp;=&nbsp;<span class="cs__number">0</span>&nbsp;});&nbsp;<span class="cs__com">//&nbsp;Black</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRecording&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<span class="cs__com">//&nbsp;Not&nbsp;recording&nbsp;any&nbsp;more</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;encoding&nbsp;=&nbsp;getVideoEncoding();&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;current&nbsp;encoding&nbsp;selection.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Start&nbsp;recording</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;file&nbsp;=&nbsp;await&nbsp;(await&nbsp;ApplicationData.Current.LocalFolder.CreateFolderAsync(<span class="cs__string">&quot;Videos&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreationCollisionOption.OpenIfExists)).CreateFileAsync(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Recording_{0}-{1}.{2}&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myEncoding,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myQuality,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(myEncoding&nbsp;==&nbsp;<span class="cs__string">&quot;MP4&quot;</span>)&nbsp;?&nbsp;<span class="cs__string">&quot;mp4&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;wav&quot;</span>),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreationCollisionOption.GenerateUniqueName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;capture.StartRecordToStorageFileAsync(encoding,&nbsp;file);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;videoIcon.Foreground&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush(<span class="cs__keyword">new</span>&nbsp;Windows.UI.Color()&nbsp;{&nbsp;A&nbsp;=&nbsp;<span class="cs__number">255</span>,&nbsp;R&nbsp;=&nbsp;<span class="cs__number">255</span>,&nbsp;G&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;B&nbsp;=&nbsp;<span class="cs__number">0</span>&nbsp;});&nbsp;<span class="cs__com">//&nbsp;Red</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRecording&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<span class="cs__com">//&nbsp;Capturing&nbsp;the&nbsp;video&nbsp;stream.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</em></pre>
</div>
</div>
</div>
<div class="endscriptcode"><em>&nbsp;I would suggest that you download and try the application's source code package out to learn more about this! I have personally made sure that the source code does not get you guys bores or puzzled. You can always understand
 the concept and the procedure.&nbsp;</em></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>The source code contains the UI pages, source files, back-end code for handling the requests and different states of application.</em>
</li></ul>
<h1>More Information</h1>
<p><em>I will publish the article explaining the usage of this sample.</em></p>
