# Bluetooth communication between Arduino and Windows 8.1
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Bluetooth
- arduino
- Windows 8.1
## Topics
- Bluetooth
- Bluetooth RF Comm
## Updated
- 11/13/2014
## Description

<h1>Introduction</h1>
<p>In this sample you can learn how to establish a serial Bluetooth link between an Arduino and a Windows 8.1 app.<em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>To test this, you need an <strong>Arduino with Bluetooth capabilities</strong> (for example an Arduino Uno R3 and a JY-MCU Bluetooth module) and a
<strong>Windows 8.1 device with Bluetooth</strong> capabilities. (A Bluetooth dongle will do as well.)</p>
<p>The sample is provided as a Visual Studio 2013 solution that includes the Windows Store app code and the Arduino code. You can open the Arduino code with the default Arduino IDE.</p>
<p>This sample was inspired by and is based on the <a href="http://developer.nokia.com/Community/Wiki/Windows_Phone_8_communicating_with_Arduino_using_Bluetooth" target="_blank">
Windows Phone 8 implementation of Bluetooth/Arduino communication</a> by Marcos Pereira. This
<a href="http://channel9.msdn.com/Events/Build/2013/3-026" target="_blank">BUILD talk by Ellick Sung</a> and the related sample application were also helpful in porting the code to WinRT.<em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Set up the Arduino with a <strong>Bluetooth module, two LEDs and a potentiometer</strong>, according to the following diagram:</p>
<p><em><img id="97044" src="97044-bt-2xled-poti.png" alt="" width="462" height="377"><br>
</em></p>
<p>Communication with the Bluetooth module is accomplished using the <strong>SoftwareSerial.h</strong> library.</p>
<p>The Windows 8.1 app has to <strong>declare Bluetooth serial communication capabilities in Package.appxmanifest</strong>:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Capabilities</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;m2</span>:DeviceCapability&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;bluetooth.rfcomm&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;m2</span>:Device&nbsp;<span class="xml__attr_name">Id</span>=<span class="xml__attr_value">&quot;any&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;m2</span>:Function&nbsp;<span class="xml__attr_name">Type</span>=<span class="xml__attr_value">&quot;name:serialPort&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/m2:Device&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/m2:DeviceCapability&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Capabilities&gt;</span></pre>
</div>
</div>
</div>
<p>To deploy the Arduino code with VisualMicro, right click the Project in the Solution Explorer and select Debug\Start new instance.</p>
<p><strong>IMPORTANT: Before running the Windows App you need to &quot;pair&quot; your Bluetooth device with your computer. To do this, go to the &quot;PC Settings&quot; and select Devices/Bluetooth. Then select your Bluetooth device, enter the pin (try 1234 if you are not sure..)
 and the device will be paired. (You only have to do this once!)</strong></p>
<p>When the Windows 8.1 app starts, you can establish a connection and control the LEDs, or subscribe to analog inputs as seen in the following video:</p>
<p>&lt;object type=&quot;application/x-silverlight-2&quot; width=&quot;350&quot; height=&quot;300&quot; data=&quot;data:application/x-silverlight-2,&quot;&gt; &lt;param name=&quot;source&quot; value=&quot;/Content/Common/videoplayer.xap&quot; /&gt; &lt;param name=&quot;initParams&quot; value=&quot;deferredLoad=false,duration=0,m=http://i1.code.msdn.s-msft.com/bluetooth-communication-7130c260/image/file/113904/1/bluetoothcommunicationsample.wmv,autostart=false,autohide=true,showembed=true&quot;
 /&gt; &lt;param name=&quot;background&quot; value=&quot;#00FFFFFF&quot; /&gt; &lt;param name=&quot;minRuntimeVersion&quot; value=&quot;3.0.40624.0&quot; /&gt; &lt;param name=&quot;enableHtmlAccess&quot; value=&quot;true&quot; /&gt; &lt;param name=&quot;src&quot; value=&quot;http://i1.code.msdn.s-msft.com/bluetooth-communication-7130c260/image/file/113904/1/bluetoothcommunicationsample.wmv&quot;
 /&gt; &lt;param name=&quot;id&quot; value=&quot;113904&quot; /&gt; &lt;param name=&quot;name&quot; value=&quot;BluetoothCommunicationSample.wmv&quot; /&gt;<span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 &lt;/object&gt; <br>
<em>&nbsp;</em><a id="x_/site/view/file/97046/1/BluetoothCommunicationSample.wmv" href="http://code.msdn.microsoft.com/site/view/file/97046/1/BluetoothCommunicationSample.wmv">Download video</a></p>
<p><a href="http://www.youtube.com/watch?v=lhj0aShdcz8" target="_blank">Youtube backup link</a></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>BluetoothCommunicationSample.zip - VS 2013 solution with Arduino &amp; Windows 8.1 code
</li></ul>
<h1>More Information</h1>
<p>For more information on this sample, see <a href="http://blog.mosthege.net/2013/09/24/bluetooth-communication-between-arduino-and-windows-8-1" target="_blank">
my blogpost about it</a>.</p>
