# Code39 Barcode Control For Windows Applications
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Controls
- custom controls
## Updated
- 12/17/2011
## Description

<h1>Introduction</h1>
<p><em>This control generates the Code39 Barcode for any text.&nbsp;<em>And also you can export or print the barcode by right clicking.</em></em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You can download Code39Control.cs and add toy our project after adding this file to your project you can drag and drop this control to your form. To generate a barcode just set the text property of this control.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The name Code 3 of 9 means that the 3 of 9 lines is wide and the others is narrow. And here is atable that represents the codes of characters where i means narrow and k means wide</em></p>
<table border="0" cellspacing="0" cellpadding="0" width="512">
<tbody>
<tr height="21">
<td width="64" height="21">Character</td>
<td width="64">Barcode</td>
<td width="64">Character</td>
<td width="64">Barcode</td>
<td width="64">Character</td>
<td width="64">Barcode</td>
<td width="64">Character</td>
<td width="64">Barcode</td>
</tr>
<tr height="20">
<td width="64" height="20">1</td>
<td width="64">kiikiiiik</td>
<td width="64">B</td>
<td width="64">iikiikiik</td>
<td width="64">M</td>
<td width="64">kikiiiiki</td>
<td width="64">X</td>
<td width="64">ikiikiiik</td>
</tr>
<tr height="20">
<td width="64" height="20">2</td>
<td width="64">iikkiiiik</td>
<td width="64">C</td>
<td width="64">kikiikiii</td>
<td width="64">i</td>
<td width="64">iiiikiikk</td>
<td width="64">Y</td>
<td width="64">kkiikiiii</td>
</tr>
<tr height="20">
<td width="64" height="20">3</td>
<td width="64">kikkiiiii</td>
<td width="64">D</td>
<td width="64">iiiikkiik</td>
<td width="64">O</td>
<td width="64">kiiikiiki</td>
<td width="64">Z</td>
<td width="64">ikkikiiii</td>
</tr>
<tr height="20">
<td width="64" height="20">4</td>
<td width="64">iiikkiiik</td>
<td width="64">E</td>
<td width="64">kiiikkiii</td>
<td width="64">P</td>
<td width="64">iikikiiki</td>
<td width="64">-</td>
<td width="64">ikiiiikik</td>
</tr>
<tr height="20">
<td width="64" height="20">5</td>
<td width="64">kiikkiiii</td>
<td width="64">F</td>
<td width="64">iikikkiii</td>
<td width="64">Q</td>
<td width="64">iiiiiikkk</td>
<td width="64">.</td>
<td width="64">kkiiiikii</td>
</tr>
<tr height="20">
<td width="64" height="20">6</td>
<td width="64">iikkkiiii</td>
<td width="64">G</td>
<td width="64">iiiiikkik</td>
<td width="64">R</td>
<td width="64">kiiiiikki</td>
<td width="64">SPACE</td>
<td width="64">ikkiiikii</td>
</tr>
<tr height="20">
<td width="64" height="20">7</td>
<td width="64">iiikiikik</td>
<td width="64">H</td>
<td width="64">kiiiikkii</td>
<td width="64">S</td>
<td width="64">iikiiikki</td>
<td width="64">*</td>
<td width="64">ikiikikii</td>
</tr>
<tr height="20">
<td width="64" height="20">8</td>
<td width="64">kiikiikii</td>
<td width="64">I</td>
<td width="64">iikiikkii</td>
<td width="64">T</td>
<td width="64">iiiikikki</td>
<td width="64">$</td>
<td width="64">ikikikiii</td>
</tr>
<tr height="20">
<td width="64" height="20">9</td>
<td width="64">iikkiikii</td>
<td width="64">J</td>
<td width="64">iiiikkkii</td>
<td width="64">U</td>
<td width="64">kkiiiiiik</td>
<td width="64">/</td>
<td width="64">ikikiiiki</td>
</tr>
<tr height="20">
<td width="64" height="20">0</td>
<td width="64">iiikkikii</td>
<td width="64">K</td>
<td width="64">kiiiiiikk</td>
<td width="64">V</td>
<td width="64">ikkiiiiik</td>
<td width="64">&#43;</td>
<td width="64">ikiiikiki</td>
</tr>
<tr height="21">
<td width="64" height="21">A</td>
<td width="64">kiiiikiik</td>
<td width="64">L</td>
<td width="64">iikiiiikk</td>
<td width="64">k</td>
<td width="64">kkkiiiiii</td>
<td width="64">%</td>
<td width="64">iiikikik</td>
</tr>
</tbody>
</table>
<p><em><br>
</em></p>
<p>And there are 3 important points we should consider.</p>
<p><span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;a)The ratio between wide line and narrow line must be 1:2 or 1:3 .</span><br>
<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b)There should be a white line between characters</span><br>
<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c)* character must be at the begining and at the end of barcode.</span></p>
<p>&nbsp;</p>
<p><span>And the main idea of control is drawing black lines over white picture.</span></p>
<p><span>Here is a sample screenshot.</span></p>
<p><span><img src="47752-untitled.png" alt="" width="444" height="302"><br>
</span></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><a id="47753" href="/site/view/file/47753/1/Code39Control.csharp">Code39Control.cs</a><br>
</em></li></ul>
<h1>More Information</h1>
<p>You can download the control's source above. Feel free to improve the control. If you can share the improvements you made the community and I will be&nbsp;grateful.&nbsp;&nbsp;</p>
<p>Feel free to contact me for any questions.</p>
