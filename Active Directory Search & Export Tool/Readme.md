# Active Directory Search & Export Tool
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- CSV
- LDAP
- apps for Office
- Visual Studio 2017
## Topics
- TreeView
- LDAP (Lightweight Directory Access Protocol)
- export grid
## Updated
- 01/24/2019
## Description

<h1><img id="214397" src="214397-picture1.png" alt="" width="750" height="244"></h1>
<p>This Active Directory Search &amp; Export Tool was written in Visual Studio Community 2017 C# Windows Forms and exports the results from LDAP (Lightweight Directory Access Protocol) to csv format. A common use of LDAP is to provide a central place to store
 usernames and passwords. This allows many different applications and services to connect to the LDAP server to validate users. This project is now on
<a href="https://github.com/Visual-Studio-projects/Active-Directory-Search/blob/master/README.md">
GitHub</a>. There is also an older version in <a href="https://code.msdn.microsoft.com/office/Active-Directory-search-5997d18d">
VB.NET</a></p>
<p>Please rate this code. :)</p>
<p><span>&nbsp;</span><a rel="nofollow" href="https://gitter.im/ActiveDirectorySearch/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge"><img src=":-68747470733a2f2f6261646765732e6769747465722e696d2f4163746976654469726563746f72795365617263682f4c6f6262792e737667" alt="Join the chat at https://gitter.im/ScriptHelp/Lobby"></a><span>&nbsp;</span><a title="MIT License Copyright © Anthony Duguid" href="https://github.com/Visual-Studio-projects/Active-Directory-Search/blob/master/LICENSE"><img src=":-68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4c6963656e73652d4d49542d79656c6c6f772e737667" alt="License: MIT"></a><span>&nbsp;</span><a href="https://github.com/Visual-Studio-projects/Active-Directory-Search/releases"><img src=":-68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f72656c656173652f56697375616c2d53747564696f2d70726f6a656374732f4163746976652d4469726563746f72792d5365617263682e7376673f6c6162656c3d6c617465737425323072656c65617365" alt="Latest Release"></a><span>&nbsp;</span><a href="https://github.com/Visual-Studio-projects/Active-Directory-Search/commits/master"><img src=":-68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f636f6d6d6974732d73696e63652f56697375616c2d53747564696f2d70726f6a656374732f4163746976652d4469726563746f72792d5365617263682f6c61746573742e737667" alt="Github commits (since latest release)"></a><span>&nbsp;</span><a href="https://github.com/Visual-Studio-projects/Active-Directory-Search/issues"><img src=":-68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f6973737565732f56697375616c2d53747564696f2d70726f6a656374732f4163746976652d4469726563746f72792d5365617263682e737667" alt="GitHub issues"></a></p>
<p><img id="201844" src="201844-2018-06-22_11-46-58.png" alt="" width="700" height="562"></p>
<p><span style="font-size:1.5em">Overview</span></p>
<p>This application uses LDAP (Lightweight Directory Access Protocol) to search Active Directory items from the treeview, the toolbar &quot;Find&quot; button or double clicking on the item in the listview</p>
<div>
<p><strong>Dependencies</strong></p>
</div>
<table border="0" cellspacing="0" cellpadding="0" style="width:0px">
<thead>
<tr style="background-color:#cfd2d3">
<td>
<p><strong>&nbsp;Software</strong></p>
</td>
<td>
<p><strong>&nbsp;Dependency &nbsp; &nbsp;</strong></p>
</td>
</tr>
</thead>
<tbody>
<tr>
<td>
<p>&nbsp;<a href="https://www.visualstudio.com/vs/whatsnew/">Microsoft Visual Studio Community 2017</a>&nbsp; &nbsp; &nbsp;</p>
</td>
<td>
<p>&nbsp;Solution</p>
</td>
</tr>
<tr>
<td>
<p>&nbsp;<a href="http://www.iconarchive.com/show/silk-icons-by-famfamfam.html">www.IconArchive.com</a></p>
</td>
<td>
<p>&nbsp;Icons</p>
</td>
</tr>
<tr>
<td>
<p>&nbsp;<a href="http://discover.techsmith.com/snagit-non-brand-desktop/?gclid=CNzQiOTO09UCFVoFKgod9EIB3g">Snagit</a></p>
</td>
<td>
<p>&nbsp;Read Me</p>
</td>
</tr>
</tbody>
</table>
<div>
<p><strong>Glossary of Terms</strong></p>
</div>
<table border="0" cellspacing="0" cellpadding="0" width="0">
<thead>
<tr style="background-color:#cfd2d3">
<td>
<p><strong>&nbsp;Term &nbsp; &nbsp;</strong></p>
</td>
<td>
<p><strong>&nbsp;Meaning</strong></p>
</td>
</tr>
</thead>
<tbody>
<tr>
<td>
<p>&nbsp;LDAP</p>
</td>
<td>
<p>&nbsp;Lightweight Directory Access Protocol &nbsp;&nbsp;</p>
</td>
</tr>
<tr>
<td>
<p>&nbsp;CSV</p>
</td>
<td>
<p>&nbsp;Comma-Separated Values</p>
</td>
</tr>
</tbody>
</table>
<div>
<p><strong>Functionality</strong></p>
</div>
<p>Listed below is the detailed functionality of this application and its components.</p>
<h4><a id="user-content-find-text-dropdown" class="anchor" href="https://github.com/aduguid/ActiveDirectorySearch#find-text-dropdown"></a>Find Text (Dropdown)</h4>
<ul>
<li>Lists all the values searched for in the current session </li></ul>
<h4><a id="user-content-find-button" class="anchor" href="https://github.com/aduguid/ActiveDirectorySearch#find-button"></a>Find (Button)</h4>
<ul>
<li>Queries Active Directory for the text in the &quot;Find Text&quot; textbox </li></ul>
<h4><a id="user-content-save-button" class="anchor" href="https://github.com/aduguid/ActiveDirectorySearch#save-button"></a>Save (Button)</h4>
<ul>
<li>Saves the current listbox view to a .csv file </li></ul>
<h4><a id="user-content-user-list-button" class="anchor" href="https://github.com/aduguid/ActiveDirectorySearch#user-list-button"></a>User List (Button)</h4>
<ul>
<li>This will change the layout of the listbox to show more information about each member of a group
</li></ul>
<h4><a id="user-content-settings-button" class="anchor" href="https://github.com/aduguid/ActiveDirectorySearch#settings-button"></a>Settings (Button)</h4>
<ul>
<li>Opens the settings form. The domain name must be updated here. </li></ul>
<h4><a id="user-content-about-button" class="anchor" href="https://github.com/aduguid/ActiveDirectorySearch#about-button"></a>About (Button)</h4>
<ul>
<li>Opens the about form </li></ul>
