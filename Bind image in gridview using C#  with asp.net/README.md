# Bind image in gridview using C#  with asp.net
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Server
- ASP.NET
## Topics
- GridView
- image upload
- bind image in gridview
- how to bind image in gridview
- display image in gridview
- how to file upload
## Updated
- 10/10/2012
## Description

<h1>Introduction</h1>
<p><em>In case of using&nbsp;</em><em>image</em><em>&nbsp;uploading and downloading from database, the following sample will help you.</em></p>
<p><em>download the sample and change the connection string then it will work..</em></p>
<p><em><span>If you want to really have a data-bound GridViewImageColumn, the column in the database should contain the actual images. Since the column in your database contains only the paths to the images,&nbsp;</span><br>
</em></p>
<p><em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<ol>
<li><span style="text-decoration:underline">ADD,</span> </li><li><span style="text-decoration:underline">UPLOAD,</span> </li><li><span style="text-decoration:underline">VIEW and</span> </li><li><span style="text-decoration:underline">REMOVE CATEGORY:</span> </li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">BIND THE IMAGE IN GRIDVIEW:</span></p>
<p><span style="font-size:small">This application is developed to Bind and view the images in the grid along with their details. Here we can add the category name which specifies, under which the image and details to be bounded. In upload category, Specify
 the name and description Select the category under which you wish to upload the Image choose the file path and bind. Further view the image with its name and category in View category. Remove category will delete the entire category.</span></p>
<p>&nbsp;</p>
<p><img id="61331" src="http://i1.code.msdn.s-msft.com/bind-image-in-gridview-f88fc0f7/image/file/61331/1/view.jpg" alt="" width="1024" height="768"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&lt;asp:GridView&nbsp;ID=<span class="cs__string">&quot;GridView1&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;CellPadding=<span class="cs__string">&quot;4&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;#333333&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutoGenerateColumns=<span class="cs__string">&quot;false&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;AlternatingRowStyle&nbsp;BackColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="cs__string">&quot;Image&nbsp;Name&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;Label1&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ImgName&quot;)%&gt;'</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="cs__string">&quot;Image&nbsp;Description&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;Label2&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ImgDesc&quot;)%&gt;'</span>&nbsp;Width=<span class="cs__string">&quot;200&quot;</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="cs__string">&quot;Image&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Image&nbsp;ID=<span class="cs__string">&quot;Image1&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;Width=<span class="cs__string">&quot;150&quot;</span>&nbsp;Height=<span class="cs__string">&quot;100&quot;</span>&nbsp;ImageUrl=<span class="cs__string">'&lt;%#Eval(&quot;ImgPath&quot;)%&gt;'</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;Label3&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EditRowStyle&nbsp;BackColor=<span class="cs__string">&quot;#2461BF&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterStyle&nbsp;BackColor=<span class="cs__string">&quot;#507CD1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;HeaderStyle&nbsp;BackColor=<span class="cs__string">&quot;#507CD1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PagerStyle&nbsp;BackColor=<span class="cs__string">&quot;#2461BF&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;HorizontalAlign=<span class="cs__string">&quot;Center&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowStyle&nbsp;BackColor=<span class="cs__string">&quot;#EFF3FB&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SelectedRowStyle&nbsp;BackColor=<span class="cs__string">&quot;#D1DDF1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;#333333&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedAscendingCellStyle&nbsp;BackColor=<span class="cs__string">&quot;#F5F7FB&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedAscendingHeaderStyle&nbsp;BackColor=<span class="cs__string">&quot;#6D95E1&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedDescendingCellStyle&nbsp;BackColor=<span class="cs__string">&quot;#E9EBEF&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedDescendingHeaderStyle&nbsp;BackColor=<span class="cs__string">&quot;#4870BE&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:GridView&gt;</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>bindCategory.sql</em> </li><li><em><em>BindImage.sql</em></em> </li></ul>
<h1>More Information</h1>
<p><strong><span style="font-size:small"><span style="text-decoration:underline">ADD CATEGORY</span>: Include the category Name.</span></strong></p>
<p>&nbsp;</p>
<p><img id="61325" src="61325-add.jpg" alt="" width="1024" height="768"></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong><span style="text-decoration:underline">UPLOAD CATEGORY</span>: Give the Image Name, Image Description and select the category to which the Details to be bounded. Select the image file to be uploaded then Bind.</strong></span></p>
<p>&nbsp;</p>
<p><img id="61324" src="61324-upload.jpg" alt="" width="1024" height="768"></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small"><span style="text-decoration:underline">VIEW CATEGORY</span>: Select the category to be viewed; this displays the image by category wise.</span></strong></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small"><span style="text-decoration:underline">REMOVE CATEGORY</span>: Remove category deletes the category and its contents.</span></strong></p>
<p>&nbsp;</p>
<p><img id="61326" src="61326-remove.jpg" alt="" width="1024" height="768"></p>
