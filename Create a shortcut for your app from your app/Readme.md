# Create a shortcut for your app from your app
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Basic .NET
- VB.Net
- functions
- System.Reflection Namespace
- Visual C#
## Topics
- C#
- Visual Basic .NET
- VB.Net
- System.Reflection
- functions
- Visual C#
- References
## Updated
- 06/13/2014
## Description

<h1>Introduction</h1>
<p><em><span style="font-size:small">If you would like to have an option on your applications form to let the user choose to have a shortcut on the Desktop, in the Startup Folder, or elsewhere by simply checking or unchecking a CheckBox on your applications
 form then here is a simple example for doing just that.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></em></p>
<h1><span>Building the Sample</span></h1>
<p><em><span style="font-size:small">&nbsp;Built using VS2008 targeting .Net 3.5 Framework</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:20px; font-weight:bold"><img id="116806" src="116806-form%20image.png" alt="" width="263" height="152"><br>
</span></p>
<p><span style="font-size:small">This example is pretty simple an strait forword. You only need to create a new Form project with 2 CheckBoxes added to the Form and use the code below in the Form. If you are creating the project yourself from the code below
 then you will need to add a reference to the <strong>Windows Scripting Host Object Model</strong>. I have explained at the top of the code how to add the reference but, i will explain here also.</span><em>&nbsp;</em></p>
<ol>
<li><em><span style="font-size:small">Create your new Form project using VB or C#</span></em>
</li><li><span style="font-size:small">On the menu click (Project) and then select (Add Reference...)</span>
</li><li><span style="font-size:small">When the dialog opens click on the (Com) tab</span>
</li><li><span style="font-size:small">Find the (Windows Scripting Host Object Model) and double click on it</span>
</li></ol>
<p><span style="font-size:small">&nbsp;Now the reference is added.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;If you have an icon for your app then you may also want to change the icon that the executable file uses because, in this example it will be the icon that is used for the shortcut too. I am sure you don`t want the ugly
 default icon for your shortcut or your apps exe file. To change the icon from the default icon to your icon you can follow these steps.</span></p>
<ol>
<li><span style="font-size:small">On the menu click (Project) and select (<em>YourProjectsName</em> Properties...)</span>
</li><li><span style="font-size:small">When the properties window opens select the (Application) tab.</span>
</li><li><span style="font-size:small">You will see a ComboBox where you can choose the icon similar to the image below</span>
</li><li><span style="font-size:small">Browse to your icon and double click on it.<br>
</span></li></ol>
<p><span style="font-size:small"><img id="116805" src="116805-set%20exe%20icon.png" alt="" width="666" height="271"><br>
</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">'After starting your new project go to the VB menu and click (Project) then click (Add Refference...)
'When the window opens click the (Com) tab and scroll down and doubleclick (Windows Scripting Host Object Model).

Imports IWshRuntimeLibrary

Public Class Form1
    'Adds the applications AssemblyName to the Desktops path and adds the .lnk extension used for shortcuts
    Private DesktopPathName As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), My.Application.Info.AssemblyName &amp; &quot;.lnk&quot;)

    'Adds the applications AssemblyName to the Startup folder path and adds the .lnk extension used for shortcuts
    Private StartupPathName As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), My.Application.Info.AssemblyName &amp; &quot;.lnk&quot;)

    'Used to stop the CheckBoxes CheckedChanged events from calling the CreateShortcut sub when the form is
    'loading and setting the Checkboxes states to true if the shortcuts exist.
    Private Loading As Boolean = True

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Sets the Desktop checkbox checked state to true if the desktop shortcut exists
        CheckBox1.Checked = IO.File.Exists(DesktopPathName)

        'Sets the Startup Folder checkbox checked state to true if the Startup folder shortcut exists
        CheckBox2.Checked = IO.File.Exists(StartupPathName)

        'The checkboxes checked states have been set so set Loading to false to allow the CreateShortcut sub to be called now
        Loading = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not Loading Then
            If CheckBox1.Checked Then
                CreateShortcut(DesktopPathName, True) 'Create a shortcut on the desktop
            Else
                CreateShortcut(DesktopPathName, False) 'Remove the shortcut from the desktop
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Not Loading Then
            If CheckBox2.Checked Then
                CreateShortcut(StartupPathName, True) 'Create a shortcut in the startup folder
            Else
                CreateShortcut(StartupPathName, False) 'Remove the shortcut in the startup folder
            End If
        End If
    End Sub

    ''' &lt;summary&gt;Creates or removes a shortcut for this application at the specified pathname.&lt;/summary&gt;
    ''' &lt;param name=&quot;shortcutPathName&quot;&gt;The path where the shortcut is to be created or removed from including the (.lnk) extension.&lt;/param&gt;
    ''' &lt;param name=&quot;create&quot;&gt;True to create a shortcut or False to remove the shortcut.&lt;/param&gt;
    Private Sub CreateShortcut(ByVal shortcutPathName As String, ByVal create As Boolean)
        If create Then
            Try
                Dim shortcutTarget As String = System.IO.Path.Combine(Application.StartupPath, My.Application.Info.AssemblyName &amp; &quot;.exe&quot;)
                Dim myShell As New WshShell()
                Dim myShortcut As WshShortcut = CType(myShell.CreateShortcut(shortcutPathName), WshShortcut)
                myShortcut.TargetPath = shortcutTarget 'The exe file this shortcut executes when double clicked
                myShortcut.IconLocation = shortcutTarget &amp; &quot;,0&quot; 'Sets the icon of the shortcut to the exe`s icon
                myShortcut.WorkingDirectory = Application.StartupPath 'The working directory for the exe
                myShortcut.Arguments = &quot;&quot; 'The arguments used when executing the exe
                myShortcut.Save() 'Creates the shortcut
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Try
                If IO.File.Exists(shortcutPathName) Then IO.File.Delete(shortcutPathName)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class
</pre>
<pre class="hidden">//After starting your new project go to the VB menu and click (Project) then click (Add Refference...)
//When the window opens click the (Com) tab and scroll down and doubleclick (Windows Scripting Host Object Model).

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using IWshRuntimeLibrary;

namespace Creating_Shortcuts_Demo
{
    public partial class Form1 : Form
    {
        //Get the Assembly Name of the application
        string appname = Assembly.GetExecutingAssembly().FullName.Remove(Assembly.GetExecutingAssembly().FullName.IndexOf(&quot;,&quot;));

        private string DesktopPathName;
        private string StartupPathName;
 
        //Used to stop the CheckBoxes CheckedChanged events from calling the CreateShortcut sub when the form is
        //loading and setting the Checkboxes states to true if the shortcuts exist.
        private bool Loading = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Adds the applications AssemblyName to the Desktops path and adds the .lnk extension used for shortcuts
            DesktopPathName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), appname &#43; &quot;.lnk&quot;);
            //Adds the applications AssemblyName to the Startup folder path and adds the .lnk extension used for shortcuts
            StartupPathName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), appname &#43; &quot;.lnk&quot;);
            //Sets the Desktop checkbox checked state to true if the desktop shortcut exists
            CheckBox1.Checked = System.IO.File.Exists(DesktopPathName);
            //Sets the Startup Folder checkbox checked state to true if the Startup folder shortcut exists
            CheckBox2.Checked = System.IO.File.Exists(StartupPathName);
            //The checkboxes checked states have been set so set Loading to false to allow the CreateShortcut sub to be called now
            Loading = false;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                if (CheckBox1.Checked)
                {
                    CreateShortcut(DesktopPathName, true); //Create a shortcut on the desktop
                }
                else
                {
                    CreateShortcut(DesktopPathName, false); //Remove the shortcut from the desktop
                }
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                if (CheckBox2.Checked)
                {
                    CreateShortcut(StartupPathName, true); //Create a shortcut in the startup folder
                }
                else
                {
                    CreateShortcut(StartupPathName, false); //Remove the shortcut in the startup folder
                }
            }
        }

        /// &lt;summary&gt;Creates or removes a shortcut for this application at the specified pathname.&lt;/summary&gt;
        /// &lt;param name=&quot;shortcutPathName&quot;&gt;The path where the shortcut is to be created or removed from including the (.lnk) extension.&lt;/param&gt;
        /// &lt;param name=&quot;create&quot;&gt;True to create a shortcut or False to remove the shortcut.&lt;/param&gt;
        private void CreateShortcut(string shortcutPathName, bool create)
        {
            if (create)
            {
                try
                {
                    string shortcutTarget = System.IO.Path.Combine(Application.StartupPath, appname &#43; &quot;.exe&quot;);
                    WshShell myShell = new WshShell();
                    WshShortcut myShortcut = (WshShortcut)myShell.CreateShortcut(shortcutPathName);
                    myShortcut.TargetPath = shortcutTarget; //The exe file this shortcut executes when double clicked
                    myShortcut.IconLocation = shortcutTarget &#43; &quot;,0&quot;; //Sets the icon of the shortcut to the exe`s icon
                    myShortcut.WorkingDirectory = Application.StartupPath; //The working directory for the exe
                    myShortcut.Arguments = &quot;&quot;; //The arguments used when executing the exe
                    myShortcut.Save(); //Creates the shortcut
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (System.IO.File.Exists(shortcutPathName))
                        System.IO.File.Delete(shortcutPathName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'After&nbsp;starting&nbsp;your&nbsp;new&nbsp;project&nbsp;go&nbsp;to&nbsp;the&nbsp;VB&nbsp;menu&nbsp;and&nbsp;click&nbsp;(Project)&nbsp;then&nbsp;click&nbsp;(Add&nbsp;Refference...)</span>&nbsp;
<span class="visualBasic__com">'When&nbsp;the&nbsp;window&nbsp;opens&nbsp;click&nbsp;the&nbsp;(Com)&nbsp;tab&nbsp;and&nbsp;scroll&nbsp;down&nbsp;and&nbsp;doubleclick&nbsp;(Windows&nbsp;Scripting&nbsp;Host&nbsp;Object&nbsp;Model).</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;IWshRuntimeLibrary&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Adds&nbsp;the&nbsp;applications&nbsp;AssemblyName&nbsp;to&nbsp;the&nbsp;Desktops&nbsp;path&nbsp;and&nbsp;adds&nbsp;the&nbsp;.lnk&nbsp;extension&nbsp;used&nbsp;for&nbsp;shortcuts</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;DesktopPathName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),&nbsp;My.Application.Info.AssemblyName&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;.lnk&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Adds&nbsp;the&nbsp;applications&nbsp;AssemblyName&nbsp;to&nbsp;the&nbsp;Startup&nbsp;folder&nbsp;path&nbsp;and&nbsp;adds&nbsp;the&nbsp;.lnk&nbsp;extension&nbsp;used&nbsp;for&nbsp;shortcuts</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;StartupPathName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup),&nbsp;My.Application.Info.AssemblyName&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;.lnk&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Used&nbsp;to&nbsp;stop&nbsp;the&nbsp;CheckBoxes&nbsp;CheckedChanged&nbsp;events&nbsp;from&nbsp;calling&nbsp;the&nbsp;CreateShortcut&nbsp;sub&nbsp;when&nbsp;the&nbsp;form&nbsp;is</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'loading&nbsp;and&nbsp;setting&nbsp;the&nbsp;Checkboxes&nbsp;states&nbsp;to&nbsp;true&nbsp;if&nbsp;the&nbsp;shortcuts&nbsp;exist.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;Loading&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Sets&nbsp;the&nbsp;Desktop&nbsp;checkbox&nbsp;checked&nbsp;state&nbsp;to&nbsp;true&nbsp;if&nbsp;the&nbsp;desktop&nbsp;shortcut&nbsp;exists</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CheckBox1.Checked&nbsp;=&nbsp;IO.File.Exists(DesktopPathName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Sets&nbsp;the&nbsp;Startup&nbsp;Folder&nbsp;checkbox&nbsp;checked&nbsp;state&nbsp;to&nbsp;true&nbsp;if&nbsp;the&nbsp;Startup&nbsp;folder&nbsp;shortcut&nbsp;exists</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CheckBox2.Checked&nbsp;=&nbsp;IO.File.Exists(StartupPathName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'The&nbsp;checkboxes&nbsp;checked&nbsp;states&nbsp;have&nbsp;been&nbsp;set&nbsp;so&nbsp;set&nbsp;Loading&nbsp;to&nbsp;false&nbsp;to&nbsp;allow&nbsp;the&nbsp;CreateShortcut&nbsp;sub&nbsp;to&nbsp;be&nbsp;called&nbsp;now</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loading&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CheckBox1_CheckedChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;CheckBox1.CheckedChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;Loading&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;CheckBox1.Checked&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateShortcut(DesktopPathName,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;<span class="visualBasic__com">'Create&nbsp;a&nbsp;shortcut&nbsp;on&nbsp;the&nbsp;desktop</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateShortcut(DesktopPathName,&nbsp;<span class="visualBasic__keyword">False</span>)&nbsp;<span class="visualBasic__com">'Remove&nbsp;the&nbsp;shortcut&nbsp;from&nbsp;the&nbsp;desktop</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CheckBox2_CheckedChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;CheckBox2.CheckedChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;Loading&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;CheckBox2.Checked&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateShortcut(StartupPathName,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;<span class="visualBasic__com">'Create&nbsp;a&nbsp;shortcut&nbsp;in&nbsp;the&nbsp;startup&nbsp;folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateShortcut(StartupPathName,&nbsp;<span class="visualBasic__keyword">False</span>)&nbsp;<span class="visualBasic__com">'Remove&nbsp;the&nbsp;shortcut&nbsp;in&nbsp;the&nbsp;startup&nbsp;folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Creates&nbsp;or&nbsp;removes&nbsp;a&nbsp;shortcut&nbsp;for&nbsp;this&nbsp;application&nbsp;at&nbsp;the&nbsp;specified&nbsp;pathname.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;shortcutPathName&quot;&gt;The&nbsp;path&nbsp;where&nbsp;the&nbsp;shortcut&nbsp;is&nbsp;to&nbsp;be&nbsp;created&nbsp;or&nbsp;removed&nbsp;from&nbsp;including&nbsp;the&nbsp;(.lnk)&nbsp;extension.&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;create&quot;&gt;True&nbsp;to&nbsp;create&nbsp;a&nbsp;shortcut&nbsp;or&nbsp;False&nbsp;to&nbsp;remove&nbsp;the&nbsp;shortcut.&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CreateShortcut(<span class="visualBasic__keyword">ByVal</span>&nbsp;shortcutPathName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;create&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;create&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;shortcutTarget&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;System.IO.Path.Combine(Application.StartupPath,&nbsp;My.Application.Info.AssemblyName&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;.exe&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myShell&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;WshShell()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myShortcut&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;WshShortcut&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(myShell.CreateShortcut(shortcutPathName),&nbsp;WshShortcut)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myShortcut.TargetPath&nbsp;=&nbsp;shortcutTarget&nbsp;<span class="visualBasic__com">'The&nbsp;exe&nbsp;file&nbsp;this&nbsp;shortcut&nbsp;executes&nbsp;when&nbsp;double&nbsp;clicked</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myShortcut.IconLocation&nbsp;=&nbsp;shortcutTarget&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;,0&quot;</span>&nbsp;<span class="visualBasic__com">'Sets&nbsp;the&nbsp;icon&nbsp;of&nbsp;the&nbsp;shortcut&nbsp;to&nbsp;the&nbsp;exe`s&nbsp;icon</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myShortcut.WorkingDirectory&nbsp;=&nbsp;Application.StartupPath&nbsp;<span class="visualBasic__com">'The&nbsp;working&nbsp;directory&nbsp;for&nbsp;the&nbsp;exe</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myShortcut.Arguments&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__com">'The&nbsp;arguments&nbsp;used&nbsp;when&nbsp;executing&nbsp;the&nbsp;exe</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myShortcut.Save()&nbsp;<span class="visualBasic__com">'Creates&nbsp;the&nbsp;shortcut</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;IO.File.Exists(shortcutPathName)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;IO.File.Delete(shortcutPathName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</ul>
