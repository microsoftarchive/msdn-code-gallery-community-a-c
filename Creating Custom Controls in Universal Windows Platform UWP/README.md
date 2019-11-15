# Creating Custom Controls in Universal Windows Platform UWP
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Phone Development
- universal windows app
- Universal Windows App Development
- Universal Windows Platform
## Topics
- Blend
- UWP
- Custom Controls in Universal Windows Platform
## Updated
- 12/01/2015
## Description

<h2><span>Why we need custom controls?</span></h2>
<p><span>Microsoft Blend Provided you the different controls that you can use in your application style, layout and animation. Let suppose you have to design profiles of 80 students of computer science batch. What you need every time to design profile.</span></p>
<ol>
<li><span>Rectangle</span> </li><li><span>Image Control</span> </li><li><span>TextBlock for Name</span> </li><li><span>TextBlock for Age</span> </li></ol>
<p><span>This will take average 35-40 seconds every time drag and drop of controls then changing content of each student. Approximately 55 minutes required for same basic steps of 80&rsquo;s students profile design. Here comes a think why not we create a custom
 control named &ldquo;ProfileDesign&rdquo; that would be composite of all required control for profile design by programming a class that inherits from one of the <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Controls.aspx" target="_blank" title="Auto generated link to System.Windows.Controls">System.Windows.Controls</a> classes of Windows Presentation Foundation (WPF) or Microsoft Silverlight.
 To include properties in our custom control that can be modified in the Properties panel of Blend, we define dependency properties in your class. So That we just drag and drop ProfileDesign control every time and update its properties respectively to each
 student. This is will reduce your attention and half the total time required as using generic method.</span></p>
<h3><strong>Now Let&rsquo;s starts how to create custom controls!</strong></h3>
<p><span>Please hold on before starting, be attentive, you have to focus just five minutes of your life and after that this technique or the versatility of Blend, I assured you will save your many hours of life.</span></p>
<h3><span>Setp1:</span></h3>
<p><span>In Blend 2015 create your windows universal blank app project here named it CustomControls.</span></p>
<p><span><img id="145419" src="145419-1.png" alt="" width="942" height="577"><br>
</span></p>
<p>&nbsp;</p>
<h3><strong>Step 2:</strong></h3>
<p><span>Add new user control named ProfileDesign. For user control right click on you project click on add - -&gt; new item - - &gt; user control.</span></p>
<p><span><img id="145420" src="145420-2.png" alt="" width="944" height="578"><br>
</span></p>
<h3><span>Step 3:</span></h3>
<p><span>Now in ProfileDesign Control we have to design the Rectangle, Image Control and two text Blocks for name and age respectively.</span></p>
<p><img id="145461" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145461/1/3.png" alt="" width="751" height="451"></p>
<p>&nbsp;</p>
<h3><span>Step 4:</span></h3>
<p><span>Now we have to define the dependency propertied of these controls so that we can use these for data binding later. Open your class ProfileDesign.Xaml.Cs you will get by expanding ProfileDesign.Xaml. For creating dependcy properties write propdp,press
 tab twice.</span></p>
<p><span>1<sup>st</sup>&nbsp;For Rectangle properties we have use the Brush Property Name OverlayBrush,In typeof owner class name of the property (ProfileDesign) and then null the meta data, the data before the actual data.</span></p>
<p><span>2<sup>nd</sup>&nbsp;For the Image property we will use the ImageSource, Property name ProfileImage, update the owner class name (ProfileDesign) and metadata null.</span></p>
<p><span>3<sup>rd</sup>&nbsp;for the textBlocks Student name and age use string and named StudentName, StudentAge respectively with same owner class (ProfileDesign) and null meta data.</span></p>
<p><img id="145422" src="145422-4.png" alt="" width="925" height="518"></p>
<p>&nbsp;</p>
<p><img id="145423" src="145423-5.png" alt="" width="943" height="536"></p>
<p>&nbsp;</p>
<p><strong><span>Press Ctrl&#43;s, Ctrl&#43;Shift&#43;B.</span></strong></p>
<h3><span>Step 5 :</span></h3>
<p><span>Now binding the controls. Select the Image control form objects and timeline, in Properties Source, create databinding, databinding name, Element Name. Select User Control and in Path the name of property in our case ProfileImage. Respective properties
 for others controls as shown in inmages.</span></p>
<p><img id="145462" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145462/1/6.png" alt="" width="751" height="451"></p>
<p>&nbsp;</p>
<p><img id="145425" src="145425-7.png" alt="" width="438" height="492"></p>
<p>&nbsp;</p>
<p><img id="145463" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145463/1/8.png" alt="" width="751" height="451"></p>
<p>&nbsp;</p>
<p><img id="145427" src="145427-9.png" alt="" width="439" height="493"></p>
<p>&nbsp;</p>
<p><img id="145478" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145478/1/10.png" alt="" width="751" height="450"></p>
<p>&nbsp;</p>
<p><img id="145429" src="145429-11.png" alt="" width="438" height="495"></p>
<p>&nbsp;</p>
<p><img id="145430" src="145430-12.png" alt="" width="438" height="496"></p>
<p><strong><span>Then Build the solution Ctrl&#43;Shift&#43;B.</span></strong></p>
<h3><span>Step 6:</span></h3>
<p><span>As Builded, go to the MainPage.xaml. In Assets let see, is my control available there?</span></p>
<p><span><img id="145479" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145479/1/13.png" alt="" width="751" height="451"><br>
</span></p>
<p>&nbsp;</p>
<p><span>Now just drag and drop on main page. Go to properties. Remember all of the properties of our custom control except the brush are in the miscellaneous tab.</span></p>
<p><span>I have added the six ProfileDesign Controls in Main Page at miscellaneous tab click on Profile Image add the image. Student Name and Student Age.</span></p>
<p><span><img id="145450" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145450/1/14.png" alt="" width="751" height="451"><br>
</span></p>
<p>&nbsp;</p>
<p><img id="145458" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145458/1/15.png" alt="" width="751" height="451"></p>
<p><span>Now go to the brush tab, Overlay Brush and chose your color.</span></p>
<p><img id="145459" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145459/1/16.png" alt="" width="751" height="450"></p>
<p><span>So there is your custom control. After that I have design five new profile of my fellows just in one minutes. Simple drag and drop the ProfileDesign Control from and Update the contents.</span></p>
<p><img id="145460" src="https://i1.code.msdn.s-msft.com/creating-custom-controls-a031a7ea/image/file/145460/1/17.png" alt="" width="751" height="451"></p>
<p><span>You can do anything with your custom controls such as, styling, data binding, animation.</span></p>
<p><span>Below is the link of hands on work code.Keep learning...!!<br>
<br>
<a href="https://github.com/samarkhan140/CustomControls" target="_blank">https://github.com/samarkhan140/CustomControls</a></span></p>
