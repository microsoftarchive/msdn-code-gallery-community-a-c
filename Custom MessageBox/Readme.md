# Custom MessageBox
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
## Topics
- messagebox
- Custom MessageBox
## Updated
- 02/28/2017
## Description

<p><span style="font-size:large"><strong>Preface</strong></span></p>
<p><span style="font-size:small">In this chapter we want &nbsp;to Create A Custom MessageBox DLL.</span></p>
<p><span style="font-size:large"><strong>Preface</strong></span></p>
<p><span style="font-size:small">The following steps show how Calculate Body Mass Index (BMI):</span></p>
<p><span style="font-size:small">1. First, Click <strong>New Project </strong>in Start Page or On
<strong>File Menu.</strong></span></p>
<p><span style="font-size:small">2. In <strong>New Project </strong>Dialog , Click
<strong>Windows</strong> On Left Pane And <strong>Class library </strong>On Middle Pane .</span></p>
<p><span style="font-size:small">3. Delete The <strong>Class1 </strong>And Create New Windows Form.</span></p>
<p><span style="font-size:small">4. Change form layout to this Mode:</span></p>
<p><strong>&nbsp;</strong><strong>&nbsp;<img id="170434" src="170434-image001.jpg" alt="" width="382" height="215"></strong></p>
<p><span style="font-size:small"><strong>&nbsp;</strong></span></p>
<p><span style="font-size:small">5. Set DialogResult Property Of <strong>btnNo</strong> To
<strong>No , btnYes </strong>To<strong> Yes </strong>And<strong> btnOK </strong>To Ok.<strong></strong></span></p>
<p><span style="font-size:small">6. Write This Method To Show The MessageBox :</span></p>
<p><span style="white-space:pre"></span><span style="color:#0000ff">public </span>
<span style="color:#008000">DialogResult </span>ShowDialog(<span style="color:#0000ff">string
</span>title, <span style="color:#0000ff">string </span>text, <span style="color:#0000ff">
int</span> Cbtn, <span style="color:#0000ff">string </span>btnOK,<span style="color:#0000ff">string
</span>btnNO, <span style="color:#0000ff">string </span>btnYES, <span style="color:#008000">
Image</span> img)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pictureBox1.Image = img;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color:#0000ff">
this</span>.Text = title;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label1.Text = text;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_OK.Text = btnOK;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_No.Text = btnNO;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_Yes.Text = btnYES;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color:#0000ff">
switch </span>(Cbtn)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="color:#0000ff">case </span>1:</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_No.Visible =
<span style="color:#0000ff">false</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_Yes.Visible =
<span style="color:#0000ff">false</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="color:#0000ff">break</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="color:#0000ff">case </span>2:</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_OK.Visible =
<span style="color:#0000ff">false</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="color:#0000ff">break</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="color:#0000ff">case </span>3:</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_OK.Visible =
<span style="color:#0000ff">true</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_No.Visible =
<span style="color:#0000ff">true</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btn_Yes.Visible =
<span style="color:#0000ff">true</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="color:#0000ff">break</span>;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color:#0000ff">
return this</span>.ShowDialog();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p><span style="font-size:small">7. Write This Code In Click Event Of Buttons To Close The MessageBox When Click a Button :</span></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color:#0000ff">
this</span>.Close();</p>
<p><strong>More Information</strong></p>
<p>My Email-Address is pc_age82@yahoo.com .</p>
<p>To open&nbsp;this sample&nbsp;you'll need&nbsp;Visual Studio&nbsp;2015 .</p>
<p>This Sample Does Not Have exe output .</p>
