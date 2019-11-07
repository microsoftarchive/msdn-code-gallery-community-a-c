# C# Winform Animated Image Slide Show in Winform
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- C#
- Windows Forms
## Topics
- C#
- Windows Forms
## Updated
- 04/14/2016
## Description

<h1>Introduction</h1>
<p><em><span>The main purpose of this article is to explain on how to create a simple Animated Image Slide Show for windows applications using C#.&nbsp;</span></em></p>
<p><em><span><img id="150924" src="150924-1_sound.jpg" alt="" width="560" height="360"></span></em></p>
<p>This Animated Image Slide Show User control has features as</p>
<p><br>
1) Load Images.<br>
2) Display both Thumb and Large size Image.<br>
3) Highlight the Selected and Current Image in Thumb image View.<br>
4) Previous, Next and Play Animation.<br>
5) Small to Big Zoom out Image Animation.<br>
6) Left to Right Scroll Animation.<br>
7) Right to Left Scroll Animation<br>
8) Top to Bottom Scroll Animation.<br>
9) Image Fade In Animation<br>
10) Transparent Horizontal Bar display on image Animation.<br>
11) Transparent Vertical Bar display on image Animation.<br>
12) Transparent Text display on Image Animation.<br>
13) Random Block transparent Animation.<br>
14) Play and Stop Music</p>
<h1><span>Building the Sample</span></h1>
<p><em><span>&nbsp;This application was developed using C# GDI&#43; functionality. The goal was to create a flash style animated Image Slide show for Windows Applications. We have added basic animation features for the Image Slide Show user control. Here we can
 see Fade and Vertical Transparent Bar Animation Screens.</span></em></p>
<p><em><span><img id="150928" src="150928-4.jpg" alt="" width="550" height="371"></span></em></p>
<p><em><span><img id="150929" src="150929-2.jpg" alt="" width="550" height="360"></span></em></p>
<p><em>Here we can see the Selected and Current Image in Thump View will be Highlighted with Border and little big Image size.</em></p>
<p><em><span>Now we start with our Code:<br>
We have created a Animated Image Slide Show as a User Control so that it can be used easily in all projects.<br>
In this article we have attached zip file named as SHANUImageSlideShow.zip. Which contains .<br>
1) &quot;ShanuImageSlideShow_Cntrl&quot; Folder (This folder contains the Image Slide Show User control Source code).<br>
2) &quot;SHANUImageSlideShow_Demo&quot; Folder (This folder conains the Demo program which includes the Image Slide Show user control ).<br>
</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>1) First we will start with the User Control .To Create a user control .</p>
<ol type="1">
<li>Create a new Windows Control Library project. </li><li>Set the Name of Project and Click Ok(here my user control name is ShanuImageSlideShow_Cntrl).
</li><li>Add all the controls which is needed. </li><li>In code behind declare all the public variables and Public property variables.
</li><li>Image Load Button Click.Here we load all the image from the Folder as Thump image view in our control.
</li></ol>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void LoadImages()
        {
            DirectoryInfo Folder;
            DialogResult result = this.folderBrowserDlg.ShowDialog();
            imageselected = false;
            if (result == DialogResult.OK)
            {
                Folder = new DirectoryInfo(folderBrowserDlg.SelectedPath);


                var imageFiles = Folder.GetFiles(&quot;*.jpg&quot;)
                      .Concat(Folder.GetFiles(&quot;*.gif&quot;))
                      .Concat(Folder.GetFiles(&quot;*.png&quot;))
                      .Concat(Folder.GetFiles(&quot;*.jpeg&quot;))
                      .Concat(Folder.GetFiles(&quot;*.bmp&quot;)).ToArray(); // Here we filter all image files 
                pnlThumb.Controls.Clear();
                if (imageFiles.Length &gt; 0)
                {
                    imageselected = true;
                    TotalimageFiles = imageFiles.Length;
                }
                else
                {
                    return;
                }
                int locnewX = locX;
                int locnewY = locY;

                ctrl = new PictureBox[TotalimageFiles];
                AllImageFielsNames = new String[TotalimageFiles];
                int imageindexs = 0;
                foreach (FileInfo img in imageFiles)
                {
                    AllImageFielsNames[imageindexs] = img.FullName;
                    loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY, imageindexs);
                    locnewX = locnewX &#43; sizeWidth &#43; 10;
                    imageindexs = imageindexs &#43; 1;

                }
                CurrentIndex = 0;
                StartIndex = 0;
                LastIndex = 0;

                DrawImageSlideShows();
            }
        }
// This Function will display the Thumb Images.
        private void loadImagestoPanel(String imageName, String ImageFullName, int newLocX, int newLocY, int imageindexs)
        {
            ctrl[imageindexs] = new PictureBox();
            ctrl[imageindexs].Image = Image.FromFile(ImageFullName);
            ctrl[imageindexs].BackColor = Color.Black;
            ctrl[imageindexs].Location = new Point(newLocX, newLocY);
            ctrl[imageindexs].Size = new System.Drawing.Size(sizeWidth - 30, sizeHeight - 60);
            ctrl[imageindexs].BorderStyle = BorderStyle.None;
            ctrl[imageindexs].SizeMode = PictureBoxSizeMode.StretchImage;
            //  ctrl[imageindexs].MouseClick &#43;= new MouseEventHandler(control_MouseMove);
            pnlThumb.Controls.Add(ctrl[imageindexs]);


        }</pre>
<div class="preview">
<pre class="js">public&nbsp;<span class="js__operator">void</span>&nbsp;LoadImages()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectoryInfo&nbsp;Folder;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DialogResult&nbsp;result&nbsp;=&nbsp;<span class="js__operator">this</span>.folderBrowserDlg.ShowDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageselected&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(result&nbsp;==&nbsp;DialogResult.OK)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Folder&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DirectoryInfo(folderBrowserDlg.SelectedPath);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;imageFiles&nbsp;=&nbsp;Folder.GetFiles(<span class="js__string">&quot;*.jpg&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Concat(Folder.GetFiles(<span class="js__string">&quot;*.gif&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Concat(Folder.GetFiles(<span class="js__string">&quot;*.png&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Concat(Folder.GetFiles(<span class="js__string">&quot;*.jpeg&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Concat(Folder.GetFiles(<span class="js__string">&quot;*.bmp&quot;</span>)).ToArray();&nbsp;<span class="js__sl_comment">//&nbsp;Here&nbsp;we&nbsp;filter&nbsp;all&nbsp;image&nbsp;files&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlThumb.Controls.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(imageFiles.Length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageselected&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TotalimageFiles&nbsp;=&nbsp;imageFiles.Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span><span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;locnewX&nbsp;=&nbsp;locX;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;locnewY&nbsp;=&nbsp;locY;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PictureBox[TotalimageFiles];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AllImageFielsNames&nbsp;=&nbsp;<span class="js__operator">new</span><span class="js__object">String</span>[TotalimageFiles];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;imageindexs&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(FileInfo&nbsp;img&nbsp;<span class="js__operator">in</span>&nbsp;imageFiles)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AllImageFielsNames[imageindexs]&nbsp;=&nbsp;img.FullName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadImagestoPanel(img.Name,&nbsp;img.FullName,&nbsp;locnewX,&nbsp;locnewY,&nbsp;imageindexs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locnewX&nbsp;=&nbsp;locnewX&nbsp;&#43;&nbsp;sizeWidth&nbsp;&#43;&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageindexs&nbsp;=&nbsp;imageindexs&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurrentIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StartIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LastIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawImageSlideShows();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;This&nbsp;Function&nbsp;will&nbsp;display&nbsp;the&nbsp;Thumb&nbsp;Images.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;loadImagestoPanel(<span class="js__object">String</span>&nbsp;imageName,&nbsp;<span class="js__object">String</span>&nbsp;ImageFullName,&nbsp;int&nbsp;newLocX,&nbsp;int&nbsp;newLocY,&nbsp;int&nbsp;imageindexs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[imageindexs]&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PictureBox();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[imageindexs].Image&nbsp;=&nbsp;Image.FromFile(ImageFullName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[imageindexs].BackColor&nbsp;=&nbsp;Color.Black;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[imageindexs].Location&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Point(newLocX,&nbsp;newLocY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[imageindexs].Size&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;System.Drawing.Size(sizeWidth&nbsp;-&nbsp;<span class="js__num">30</span>,&nbsp;sizeHeight&nbsp;-&nbsp;<span class="js__num">60</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[imageindexs].BorderStyle&nbsp;=&nbsp;BorderStyle.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[imageindexs].SizeMode&nbsp;=&nbsp;PictureBoxSizeMode.StretchImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;ctrl[imageindexs].MouseClick&nbsp;&#43;=&nbsp;new&nbsp;MouseEventHandler(control_MouseMove);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlThumb.Controls.Add(ctrl[imageindexs]);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p></p>
<p>Here we call the above function in Load Image Click Event.In this function load and display all the Images from the selected folder.</p>
<p>6.Once Image loaded we need highlight the selected and current image .for this we call the below function which will check for the current image and set the image border and Increase the Size of the present image.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">#region Highlight The Current Slected image
      public void HighlightCurrentImage()
      {
          for (int i = 0; i &lt;= ctrl.Length - 1; i&#43;&#43;)
          {
              if (i == CurrentIndex)
              {
                  ctrl[i].Left = ctrl[i].Left - 20;
                  ctrl[i].Size = new System.Drawing.Size(sizeWidth &#43; 10, sizeHeight);
                  ctrl[i].BorderStyle = BorderStyle.FixedSingle;

              }
              else
              {
                  // ctrl[i].Location = new Point(newLocX, newLocY);
                  ctrl[i].Size = new System.Drawing.Size(sizeWidth - 20, sizeHeight - 40);
                  ctrl[i].BorderStyle = BorderStyle.None;
              }
          }
      }
      #endregion</pre>
<div class="preview">
<pre class="js">#region&nbsp;Highlight&nbsp;The&nbsp;Current&nbsp;Slected&nbsp;image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;HighlightCurrentImage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;=&nbsp;ctrl.Length&nbsp;-&nbsp;<span class="js__num">1</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(i&nbsp;==&nbsp;CurrentIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[i].Left&nbsp;=&nbsp;ctrl[i].Left&nbsp;-&nbsp;<span class="js__num">20</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[i].Size&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;System.Drawing.Size(sizeWidth&nbsp;&#43;&nbsp;<span class="js__num">10</span>,&nbsp;sizeHeight);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[i].BorderStyle&nbsp;=&nbsp;BorderStyle.FixedSingle;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;ctrl[i].Location&nbsp;=&nbsp;new&nbsp;Point(newLocX,&nbsp;newLocY);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[i].Size&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;System.Drawing.Size(sizeWidth&nbsp;-&nbsp;<span class="js__num">20</span>,&nbsp;sizeHeight&nbsp;-&nbsp;<span class="js__num">40</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl[i].BorderStyle&nbsp;=&nbsp;BorderStyle.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;7.This is the important function of User control where wedo the Animation for the selected current Image.This function will be called in Timer Tick event .After the Animation is finished we stop the timer and activate the
 main timer to load next image.From main Timer we create the Random no from 1 to 11 and activate the sub timer ,Sub timer is used to display the animation.</div>
<p></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">#region Draw Animation on seleced Image
      public void drawAnimation()
     {
         try
         {

             switch (SlideType)
             {
                 case 0:// Small to big
                     SmalltoBigImage_Animation();
                     break;

                 case 1:// left to right
                     LefttoRight_Animation();
                     break;

                 case 2:// Rectangle Transparent
                     Transparent_Bar_Animation();
                     break;

                 case 3:// Right to Left
                     RighttoLeft_Animation();
                     break;

                 case 4:// Top to Bottom
                     ToptoBottom_Animation();
                     break;

                 case 5:// Bottom to Top
                     BottomTop_Animation();
                     break;

                 case 6:// Rectangle Vertical Block Transparent
                     Vertical_Bar_Animation();
                     break;

                 case 7:// Random Block Transparent
                     Random_Bar_Animation();
                     break;

                 case 8:// Rectangle Horizontal Block Transparent
                    Horizontal_Bar_Animation();
                     break;

                 case 9:// Text Transparent
                     Transparent_Text_Animation();
                     break;

                 case 10:// Random Circle and Bar Transparent
                     Random_Circle_Animation();
                     break;


                 default: // In Default there is no animation but load next image in time intervals.
                     picImageSlide.Width = pnlImg.Width;
                     picImageSlide.Height = pnlImg.Height;

                     timer1.Enabled = true;
                     timer1.Start();

                     break;
             }
         }
         catch (Exception ex)
         {
         }
     }

// Small to Big Size Image
     private void SmalltoBigImage_Animation()
     {
         int leftConstant_adjust = 40;
         int topconstant_adjust = 30;
         if ((picImageSlide.Width &lt; (MINMAX * pnlImg.Width)) &amp;&amp;
          (picImageSlide.Height &lt; (MINMAX * pnlImg.Height)))
         {
             picImageSlide.Width = Convert.ToInt32(picImageSlide.Width * ZOOMFACTOR);
             picImageSlide.Height = Convert.ToInt32(picImageSlide.Height * ZOOMFACTOR);
             picImageSlide.Left = Convert.ToInt32(picImageSlide.Left - leftConstant_adjust);
             if (picImageSlide.Top &lt;= 0)
             {
                 picImageSlide.Left = 0;
                 picImageSlide.Top = 0;
             }
             picImageSlide.Top = Convert.ToInt32(picImageSlide.Top - topconstant_adjust);
             picImageSlide.SizeMode = PictureBoxSizeMode.StretchImage;
         }
         else //In else part i check for the animation completed if its completed stop the timer 2 and start the timer 1 to load the next image .
         {
             picImageSlide.Width = pnlImg.Width;
             picImageSlide.Height = pnlImg.Height;
             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.

         }
     }

     //Left to Right Animation
     private void LefttoRight_Animation()
     {
         picImageSlide.Invalidate();
         if (picImageSlide.Location.X &gt;= 10)
         {
             picImageSlide.Left = 0;

             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
         }
         else
         {

             picImageSlide.Left = xval;
             xval = xval &#43; 100;
         }
         picImageSlide.Width = pnlImg.Width;
         picImageSlide.Height = pnlImg.Height;
     }

     //Left to Right Animation
     private void Transparent_Bar_Animation()
     {
         //   picImageSlide.Invalidate();

         if (opacity &gt;= 90)
         {
             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.

             opacity = 100;
         }
         //   picImageSlide.Refresh();
         Graphics g = Graphics.FromImage(picImageSlide.Image);
         g.FillRectangle(new SolidBrush(Color.FromArgb(58, Color.White)), 0, 0, picImageSlide.Image.Width, picImageSlide.Image.Height);
         opacity = opacity &#43; 10;
         picImageSlide.Image = PictuerBoxFadeIn(picImageSlide.Image, opacity);  //calling ChangeOpacity Function
     }
     // Right to Left Animation
     private void RighttoLeft_Animation()
     {
         picImageSlide.Invalidate();
         if (xval_Right &lt;= 100)
         {
             picImageSlide.Left = 0;
             xval_Right = 0;
             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
         }
         else
         {

             picImageSlide.Left = xval_Right;
             xval_Right = xval_Right - 100;
         }
         picImageSlide.Width = pnlImg.Width;
         picImageSlide.Height = pnlImg.Height;
     }



     // Top to Bottom Slide Animation
     private void ToptoBottom_Animation()
     {
         picImageSlide.Invalidate();
         if (yval &#43; 60 &gt;= 30)
         {
             picImageSlide.Top = 0;

             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
         }
         else
         {

             picImageSlide.Top = yval;
             yval = yval &#43; 100;
         }
         picImageSlide.Width = pnlImg.Width;
         picImageSlide.Height = pnlImg.Height;
     }

     // Bottom to Top Slide Animation
     private void BottomTop_Animation()
     {
         picImageSlide.Invalidate();
         if (yval_Right &lt;= 0)
         {
             picImageSlide.Left = 0;
             xval_Right = 0;

             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
         }
         else
         {

             picImageSlide.Top = yval_Right;
             yval_Right = yval_Right - 100;
         }
         picImageSlide.Width = pnlImg.Width;
         picImageSlide.Height = pnlImg.Height;

     }

        // vertical transparent Bar Animation
     private void Vertical_Bar_Animation()
     {
         if (opacity_new &lt;= 0)
         {
             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
             opacity_new = 100;
         }
         // picImageSlide.Refresh();
         Graphics g2 = Graphics.FromImage(picImageSlide.Image);


         recBlockYval = 0;
         barheight = barheight &#43; 100;

         g2.DrawRectangle(Pens.Black, recBlockXval, recBlockYval, barwidth, barheight);
         g2.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), recBlockXval, recBlockYval, barwidth - 1, barheight - 1);
         opacity_new = opacity_new - 10;
         recBlockXval = recBlockXval &#43; barwidth &#43; 4;

         picImageSlide.Refresh();
     }

      // Random bar and Circle transparent  Animation
     private void Random_Bar_Animation()
     {

         if (opacity_new &lt;= 0)
         {
             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
             opacity_new = 100;
         }
         // picImageSlide.Refresh();
         Graphics g3 = Graphics.FromImage(picImageSlide.Image);


         recBlockXval = 0;
         barwidth = barwidth &#43; 100;

         // g3.DrawRectangle(Pens.Black, rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(100, 600), rnd.Next(60, 400));
         g3.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), rnd.Next(10, 600), rnd.Next(10, 600), rnd.Next(100, 600), rnd.Next(60, 400));
         opacity_new = opacity_new - 5;
         recBlockYval = recBlockYval &#43; barheight &#43; 4;
         //recBlockYval = recBlockYval &#43; 100;
         //barheight = barheight &#43; 100;
         picImageSlide.Refresh();
     }
     //Horizontal transparent Bar Animation
     private void Horizontal_Bar_Animation()
     {
         if (opacity_new &lt;= 0)
         {
             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
             opacity_new = 100;
         }
         recBlockXval = 0;
         barwidth = barwidth &#43; 100;
         Graphics g4 = Graphics.FromImage(picImageSlide.Image);
         g4.DrawRectangle(Pens.Black, recBlockXval, recBlockYval, barwidth, barheight);
         g4.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), recBlockXval, recBlockYval, barwidth - 1, barheight - 1);
         opacity_new = opacity_new - 10;
         recBlockYval = recBlockYval &#43; barheight &#43; 4;
         picImageSlide.Refresh();
     }

     // transparent text Animation
     private void  Transparent_Text_Animation()
     {
                         if (opacity_new &lt;= 0)
                     {
                         Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
                         Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
                         opacity_new = 100;
                     }
                     // picImageSlide.Refresh();
                     Graphics g5 = Graphics.FromImage(picImageSlide.Image);

                     g5.DrawString(&quot;Shanu Slide Show&quot;, new Font(&quot;Arial&quot;, 86),
               new SolidBrush(Color.FromArgb(opacity_new, Color.FromArgb(this.rnd.Next(256), this.rnd.Next(256), this.rnd.Next(256)))),
               rnd.Next(600), rnd.Next(400));

                     opacity_new = opacity_new - 5;

                     picImageSlide.Refresh();
     }

     // Random Circle Animation
     private void Random_Circle_Animation()
     {
         if (opacity_new &lt;= 0)
         {
             Start_Stop_Timer_1(true); // Start the Timer 1 to load the next Image
             Start_Stop_Timer_2(false);// Stop the Timer 2 to stop the animation till the next image loaded.
             opacity_new = 100;
         }
         // picImageSlide.Refresh();
         Graphics g6 = Graphics.FromImage(picImageSlide.Image);

         recBlockXval = 0;
         barwidth = barwidth &#43; 100;

         // g3.DrawRectangle(Pens.Black, rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(100, 600), rnd.Next(60, 400));
         g6.FillRectangle(new SolidBrush(Color.FromArgb(opacity_new, Color.White)), rnd.Next(10, 600), rnd.Next(10, 600), rnd.Next(400, 800), rnd.Next(60, 400));
         g6.FillPie(new SolidBrush(Color.FromArgb(opacity_new, Color.FromArgb(this.rnd.Next(256), this.rnd.Next(256), this.rnd.Next(256)))), rnd.Next(600), rnd.Next(400), rnd.Next(400, 800), rnd.Next(400), 0, 360);
         opacity_new = opacity_new - 5;
         recBlockYval = recBlockYval &#43; barheight &#43; 4;
         //recBlockYval = recBlockYval &#43; 100;
         //barheight = barheight &#43; 100;
         picImageSlide.Refresh();
     }

     //for the Image Transparent
     public static Bitmap PictuerBoxFadeIn(Image img, int opacity)
     {
         Bitmap bmp = new Bitmap(img.Width, img.Height);

         Graphics g = Graphics.FromImage(bmp);
         ColorMatrix colmat = new ColorMatrix();
         colmat.Matrix33 = opacity;
         ImageAttributes imgAttr = new ImageAttributes();
         imgAttr.SetColorMatrix(colmat, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
         g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttr);
         g.Dispose();
         // return the new fade in Image
         return bmp;
     }
     #endregion</pre>
<div class="preview">
<pre class="js">#region&nbsp;Draw&nbsp;Animation&nbsp;on&nbsp;seleced&nbsp;Image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;drawAnimation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">try</span><span class="js__brace">{</span><span class="js__statement">switch</span>&nbsp;(SlideType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">case</span><span class="js__num">0</span>:<span class="js__sl_comment">//&nbsp;Small&nbsp;to&nbsp;big</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SmalltoBigImage_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">1</span>:<span class="js__sl_comment">//&nbsp;left&nbsp;to&nbsp;right</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LefttoRight_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">2</span>:<span class="js__sl_comment">//&nbsp;Rectangle&nbsp;Transparent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Transparent_Bar_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">3</span>:<span class="js__sl_comment">//&nbsp;Right&nbsp;to&nbsp;Left</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RighttoLeft_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">4</span>:<span class="js__sl_comment">//&nbsp;Top&nbsp;to&nbsp;Bottom</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ToptoBottom_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">5</span>:<span class="js__sl_comment">//&nbsp;Bottom&nbsp;to&nbsp;Top</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BottomTop_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">6</span>:<span class="js__sl_comment">//&nbsp;Rectangle&nbsp;Vertical&nbsp;Block&nbsp;Transparent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vertical_Bar_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">7</span>:<span class="js__sl_comment">//&nbsp;Random&nbsp;Block&nbsp;Transparent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random_Bar_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">8</span>:<span class="js__sl_comment">//&nbsp;Rectangle&nbsp;Horizontal&nbsp;Block&nbsp;Transparent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Horizontal_Bar_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">9</span>:<span class="js__sl_comment">//&nbsp;Text&nbsp;Transparent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Transparent_Text_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span><span class="js__num">10</span>:<span class="js__sl_comment">//&nbsp;Random&nbsp;Circle&nbsp;and&nbsp;Bar&nbsp;Transparent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random_Circle_Animation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">default</span>:&nbsp;<span class="js__sl_comment">//&nbsp;In&nbsp;Default&nbsp;there&nbsp;is&nbsp;no&nbsp;animation&nbsp;but&nbsp;load&nbsp;next&nbsp;image&nbsp;in&nbsp;time&nbsp;intervals.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Width&nbsp;=&nbsp;pnlImg.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Height&nbsp;=&nbsp;pnlImg.Height;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1.Enabled&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1.Start();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;Small&nbsp;to&nbsp;Big&nbsp;Size&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;SmalltoBigImage_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;leftConstant_adjust&nbsp;=&nbsp;<span class="js__num">40</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;topconstant_adjust&nbsp;=&nbsp;<span class="js__num">30</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;((picImageSlide.Width&nbsp;&lt;&nbsp;(MINMAX&nbsp;*&nbsp;pnlImg.Width))&nbsp;&amp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(picImageSlide.Height&nbsp;&lt;&nbsp;(MINMAX&nbsp;*&nbsp;pnlImg.Height)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Width&nbsp;=&nbsp;Convert.ToInt32(picImageSlide.Width&nbsp;*&nbsp;ZOOMFACTOR);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Height&nbsp;=&nbsp;Convert.ToInt32(picImageSlide.Height&nbsp;*&nbsp;ZOOMFACTOR);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Left&nbsp;=&nbsp;Convert.ToInt32(picImageSlide.Left&nbsp;-&nbsp;leftConstant_adjust);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(picImageSlide.Top&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Left&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Top&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Top&nbsp;=&nbsp;Convert.ToInt32(picImageSlide.Top&nbsp;-&nbsp;topconstant_adjust);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.SizeMode&nbsp;=&nbsp;PictureBoxSizeMode.StretchImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else&nbsp;//In&nbsp;<span class="js__statement">else</span>&nbsp;part&nbsp;i&nbsp;check&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;animation&nbsp;completed&nbsp;<span class="js__statement">if</span>&nbsp;its&nbsp;completed&nbsp;stop&nbsp;the&nbsp;timer&nbsp;<span class="js__num">2</span>&nbsp;and&nbsp;start&nbsp;the&nbsp;timer&nbsp;<span class="js__num">1</span>&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;image&nbsp;.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Width&nbsp;=&nbsp;pnlImg.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Height&nbsp;=&nbsp;pnlImg.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span><span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//Left&nbsp;to&nbsp;Right&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;LefttoRight_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(picImageSlide.Location.X&nbsp;&gt;=&nbsp;<span class="js__num">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Left&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span><span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Left&nbsp;=&nbsp;xval;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xval&nbsp;=&nbsp;xval&nbsp;&#43;&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Width&nbsp;=&nbsp;pnlImg.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Height&nbsp;=&nbsp;pnlImg.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//Left&nbsp;to&nbsp;Right&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Transparent_Bar_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;picImageSlide.Invalidate();</span><span class="js__statement">if</span>&nbsp;(opacity&nbsp;&gt;=&nbsp;<span class="js__num">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;picImageSlide.Refresh();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g&nbsp;=&nbsp;Graphics.FromImage(picImageSlide.Image);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillRectangle(<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(<span class="js__num">58</span>,&nbsp;Color.White)),&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;picImageSlide.Image.Width,&nbsp;picImageSlide.Image.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity&nbsp;=&nbsp;opacity&nbsp;&#43;&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Image&nbsp;=&nbsp;PictuerBoxFadeIn(picImageSlide.Image,&nbsp;opacity);&nbsp;&nbsp;<span class="js__sl_comment">//calling&nbsp;ChangeOpacity&nbsp;Function</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;Right&nbsp;to&nbsp;Left&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;RighttoLeft_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(xval_Right&nbsp;&lt;=&nbsp;<span class="js__num">100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Left&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xval_Right&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span><span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Left&nbsp;=&nbsp;xval_Right;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xval_Right&nbsp;=&nbsp;xval_Right&nbsp;-&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Width&nbsp;=&nbsp;pnlImg.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Height&nbsp;=&nbsp;pnlImg.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;Top&nbsp;to&nbsp;Bottom&nbsp;Slide&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;ToptoBottom_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(yval&nbsp;&#43;&nbsp;<span class="js__num">60</span>&nbsp;&gt;=&nbsp;<span class="js__num">30</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Top&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span><span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Top&nbsp;=&nbsp;yval;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yval&nbsp;=&nbsp;yval&nbsp;&#43;&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Width&nbsp;=&nbsp;pnlImg.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Height&nbsp;=&nbsp;pnlImg.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;Bottom&nbsp;to&nbsp;Top&nbsp;Slide&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;BottomTop_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(yval_Right&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Left&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xval_Right&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span><span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Top&nbsp;=&nbsp;yval_Right;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yval_Right&nbsp;=&nbsp;yval_Right&nbsp;-&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Width&nbsp;=&nbsp;pnlImg.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Height&nbsp;=&nbsp;pnlImg.Height;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;vertical&nbsp;transparent&nbsp;Bar&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Vertical_Bar_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(opacity_new&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;picImageSlide.Refresh();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g2&nbsp;=&nbsp;Graphics.FromImage(picImageSlide.Image);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockYval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;barheight&nbsp;=&nbsp;barheight&nbsp;&#43;&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g2.DrawRectangle(Pens.Black,&nbsp;recBlockXval,&nbsp;recBlockYval,&nbsp;barwidth,&nbsp;barheight);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g2.FillRectangle(<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(opacity_new,&nbsp;Color.White)),&nbsp;recBlockXval,&nbsp;recBlockYval,&nbsp;barwidth&nbsp;-&nbsp;<span class="js__num">1</span>,&nbsp;barheight&nbsp;-&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;opacity_new&nbsp;-&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockXval&nbsp;=&nbsp;recBlockXval&nbsp;&#43;&nbsp;barwidth&nbsp;&#43;&nbsp;<span class="js__num">4</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;Random&nbsp;bar&nbsp;and&nbsp;Circle&nbsp;transparent&nbsp;&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Random_Bar_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(opacity_new&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;picImageSlide.Refresh();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g3&nbsp;=&nbsp;Graphics.FromImage(picImageSlide.Image);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockXval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;barwidth&nbsp;=&nbsp;barwidth&nbsp;&#43;&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;g3.DrawRectangle(Pens.Black,&nbsp;rnd.Next(0,&nbsp;200),&nbsp;rnd.Next(0,&nbsp;200),&nbsp;rnd.Next(100,&nbsp;600),&nbsp;rnd.Next(60,&nbsp;400));</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g3.FillRectangle(<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(opacity_new,&nbsp;Color.White)),&nbsp;rnd.Next(<span class="js__num">10</span>,&nbsp;<span class="js__num">600</span>),&nbsp;rnd.Next(<span class="js__num">10</span>,&nbsp;<span class="js__num">600</span>),&nbsp;rnd.Next(<span class="js__num">100</span>,&nbsp;<span class="js__num">600</span>),&nbsp;rnd.Next(<span class="js__num">60</span>,&nbsp;<span class="js__num">400</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;opacity_new&nbsp;-&nbsp;<span class="js__num">5</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockYval&nbsp;=&nbsp;recBlockYval&nbsp;&#43;&nbsp;barheight&nbsp;&#43;&nbsp;<span class="js__num">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//recBlockYval&nbsp;=&nbsp;recBlockYval&nbsp;&#43;&nbsp;100;</span><span class="js__sl_comment">//barheight&nbsp;=&nbsp;barheight&nbsp;&#43;&nbsp;100;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//Horizontal&nbsp;transparent&nbsp;Bar&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Horizontal_Bar_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(opacity_new&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockXval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;barwidth&nbsp;=&nbsp;barwidth&nbsp;&#43;&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g4&nbsp;=&nbsp;Graphics.FromImage(picImageSlide.Image);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g4.DrawRectangle(Pens.Black,&nbsp;recBlockXval,&nbsp;recBlockYval,&nbsp;barwidth,&nbsp;barheight);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g4.FillRectangle(<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(opacity_new,&nbsp;Color.White)),&nbsp;recBlockXval,&nbsp;recBlockYval,&nbsp;barwidth&nbsp;-&nbsp;<span class="js__num">1</span>,&nbsp;barheight&nbsp;-&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;opacity_new&nbsp;-&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockYval&nbsp;=&nbsp;recBlockYval&nbsp;&#43;&nbsp;barheight&nbsp;&#43;&nbsp;<span class="js__num">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;transparent&nbsp;text&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;&nbsp;Transparent_Text_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(opacity_new&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;picImageSlide.Refresh();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g5&nbsp;=&nbsp;Graphics.FromImage(picImageSlide.Image);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g5.DrawString(<span class="js__string">&quot;Shanu&nbsp;Slide&nbsp;Show&quot;</span>,&nbsp;<span class="js__operator">new</span>&nbsp;Font(<span class="js__string">&quot;Arial&quot;</span>,&nbsp;<span class="js__num">86</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(opacity_new,&nbsp;Color.FromArgb(<span class="js__operator">this</span>.rnd.Next(<span class="js__num">256</span>),&nbsp;<span class="js__operator">this</span>.rnd.Next(<span class="js__num">256</span>),&nbsp;<span class="js__operator">this</span>.rnd.Next(<span class="js__num">256</span>)))),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rnd.Next(<span class="js__num">600</span>),&nbsp;rnd.Next(<span class="js__num">400</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;opacity_new&nbsp;-&nbsp;<span class="js__num">5</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;Random&nbsp;Circle&nbsp;Animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Random_Circle_Animation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(opacity_new&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_1(true);&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;Timer&nbsp;1&nbsp;to&nbsp;load&nbsp;the&nbsp;next&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start_Stop_Timer_2(false);<span class="js__sl_comment">//&nbsp;Stop&nbsp;the&nbsp;Timer&nbsp;2&nbsp;to&nbsp;stop&nbsp;the&nbsp;animation&nbsp;till&nbsp;the&nbsp;next&nbsp;image&nbsp;loaded.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;picImageSlide.Refresh();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g6&nbsp;=&nbsp;Graphics.FromImage(picImageSlide.Image);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockXval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;barwidth&nbsp;=&nbsp;barwidth&nbsp;&#43;&nbsp;<span class="js__num">100</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;g3.DrawRectangle(Pens.Black,&nbsp;rnd.Next(0,&nbsp;200),&nbsp;rnd.Next(0,&nbsp;200),&nbsp;rnd.Next(100,&nbsp;600),&nbsp;rnd.Next(60,&nbsp;400));</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g6.FillRectangle(<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(opacity_new,&nbsp;Color.White)),&nbsp;rnd.Next(<span class="js__num">10</span>,&nbsp;<span class="js__num">600</span>),&nbsp;rnd.Next(<span class="js__num">10</span>,&nbsp;<span class="js__num">600</span>),&nbsp;rnd.Next(<span class="js__num">400</span>,&nbsp;<span class="js__num">800</span>),&nbsp;rnd.Next(<span class="js__num">60</span>,&nbsp;<span class="js__num">400</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g6.FillPie(<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(opacity_new,&nbsp;Color.FromArgb(<span class="js__operator">this</span>.rnd.Next(<span class="js__num">256</span>),&nbsp;<span class="js__operator">this</span>.rnd.Next(<span class="js__num">256</span>),&nbsp;<span class="js__operator">this</span>.rnd.Next(<span class="js__num">256</span>)))),&nbsp;rnd.Next(<span class="js__num">600</span>),&nbsp;rnd.Next(<span class="js__num">400</span>),&nbsp;rnd.Next(<span class="js__num">400</span>,&nbsp;<span class="js__num">800</span>),&nbsp;rnd.Next(<span class="js__num">400</span>),&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">360</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;opacity_new&nbsp;=&nbsp;opacity_new&nbsp;-&nbsp;<span class="js__num">5</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recBlockYval&nbsp;=&nbsp;recBlockYval&nbsp;&#43;&nbsp;barheight&nbsp;&#43;&nbsp;<span class="js__num">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//recBlockYval&nbsp;=&nbsp;recBlockYval&nbsp;&#43;&nbsp;100;</span><span class="js__sl_comment">//barheight&nbsp;=&nbsp;barheight&nbsp;&#43;&nbsp;100;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picImageSlide.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//for&nbsp;the&nbsp;Image&nbsp;Transparent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;Bitmap&nbsp;PictuerBoxFadeIn(Image&nbsp;img,&nbsp;int&nbsp;opacity)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmp&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Bitmap(img.Width,&nbsp;img.Height);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g&nbsp;=&nbsp;Graphics.FromImage(bmp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ColorMatrix&nbsp;colmat&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ColorMatrix();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colmat.Matrix33&nbsp;=&nbsp;opacity;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageAttributes&nbsp;imgAttr&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ImageAttributes();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgAttr.SetColorMatrix(colmat,&nbsp;ColorMatrixFlag.Default,&nbsp;ColorAdjustType.Bitmap);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawImage(img,&nbsp;<span class="js__operator">new</span>&nbsp;Rectangle(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;bmp.Width,&nbsp;bmp.Height),&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;img.Width,&nbsp;img.Height,&nbsp;GraphicsUnit.Pixel,&nbsp;imgAttr);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;return&nbsp;the&nbsp;new&nbsp;fade&nbsp;in&nbsp;Image</span><span class="js__statement">return</span>&nbsp;bmp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</pre>
</div>
</div>
</div>
<p></p>
<p>8.After completion save,Build and run the project.</p>
<p>2) Now we create a Windows application and add test our &quot;SHANUImageSlideShow_Demo&quot; User Control.</p>
<ol type="1">
<li>Create a new Windows project. </li><li>Open your form and then from<strong>&nbsp;Toolbox &gt; right click &gt; choose items &gt;&nbsp;</strong>browse select your user control dll and add.
</li><li><strong>&nbsp;</strong>Drag the User Control to your windows form. </li><li>Run your program.now you can see the user control will be added in windows form.You can open your image folder and load all the images and play the Animated Image Slide Show.
</li></ol>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>SHANUImageSlideShow_Demo.zip</span> </li></ul>
