# Close Windows Forms application when last Form was closed
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Windows Forms
- Visual C#
## Topics
- Windows Forms
## Updated
- 05/27/2016
## Description

<h1>Introduction</h1>
<p><em>By default, a Windows Forms applications exits when the main form is closed. When an application offers multiple windows, it is often required that the application continues to run till the last window was closed by the user. This sample shows an easy
 solution for this request which only requires adding one small class and a small change to Program.cs</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample was build with Visual Studio 2015 Professional targeting .Net 4.6.2. The code itself should also work with other versions (e.g. Visual Studio 2015 / .Net 3.5) but in that case you have to create a new solution / project and add the existing
 code files.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>By default a Windows Forms application starts the main form inside Program.cs with a call to Application.Run(new Form1());</em></p>
<p><em>This code sample introduces a Class FormsApplication which will manage an ApplicationContext object internaly and makes sure that the main form inside the context is replaced when that form is closed.</em></p>
<p>To do this, the FormsApplication will suscribe to the Closed event of the main form.</p>
<p>The FormsApplication class:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Windows.Forms;

namespace CloseApplicationAfterLastFormClosed
{
    /// &lt;summary&gt;
    /// Manages open Forms and makes sure that the ApplicationContext of the main loop always has
    /// an open form till the last form is closed.
    /// &lt;/summary&gt;
    /// &lt;remarks&gt;
    /// To use this class: Simply replace the Application.Run call in program.cs with
    /// FormsApplication.Run.
    /// &lt;/remarks&gt;
    public static class FormsApplication
    {
        /// &lt;summary&gt;
        /// Application context
        /// &lt;/summary&gt;
        private static ApplicationContext _appContext;

        /// &lt;summary&gt;
        /// Run the Application Loop
        /// &lt;/summary&gt;
        public static void Run()
        {
            _appContext = new ApplicationContext();
            Application.Run(_appContext);
        }

        /// &lt;summary&gt;
        /// Run the Application Loop with a given context.
        /// &lt;/summary&gt; 
        public static void Run(ApplicationContext context)
        {
            // Validate arguments
            if (context == null) throw new ArgumentNullException(nameof(context));

            // Set the application context 
            _appContext = context;

            // add us to the closed event.
            if (context.MainForm != null)
                context.MainForm.Closed &#43;= ClosedEventHandler;

            // Start the main loop.
            Application.Run(context);
        }

        /// &lt;summary&gt;
        /// Run the Application Loop with a given form.
        /// &lt;/summary&gt;
        public static void Run(Form form)
        {
            // Validate arguments
            if (form == null) throw new ArgumentNullException(nameof(form));

            form.Closed &#43;= ClosedEventHandler;
            _appContext = new ApplicationContext { MainForm = form };
            Application.Run(_appContext);
        }

        /// &lt;summary&gt;
        /// Event handler that removes a form when it is closed
        /// &lt;/summary&gt;
        /// &lt;remarks&gt;
        /// The Application.OpenForms collection contained the window that was closing in my tests. But
        /// that is something that I do not trust because that might change depending on implementation
        /// details. So this code is safe.
        /// 
        /// Important: This code is not thread safe! I trust that all changes are done by the UI thread
        /// as it should be done in all Windows Forms actions!
        /// &lt;/remarks&gt;
        private static void ClosedEventHandler(object sender, EventArgs e)
        {
            // Validate arguments
            if (sender == null) throw new ArgumentNullException(nameof(sender));
            if (e == null) throw new ArgumentNullException(nameof(e));

            // Do nothing if the closed form is not the main form or if the count of open forms is 0.
            if (_appContext.MainForm != sender || Application.OpenForms.Count == 0)
                return;

            // Search for a form which is not 
            foreach (Form form in Application.OpenForms)
            {
                // Continue search if form is sender.
                if (form == sender) continue;
                
                // Set the MainForm, add listener to Closed Event and leave method.
                _appContext.MainForm = form;
                _appContext.MainForm.Closed &#43;= ClosedEventHandler;
                return;
            }

            // no other form found, nothing to do.
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;CloseApplicationAfterLastFormClosed&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Manages&nbsp;open&nbsp;Forms&nbsp;and&nbsp;makes&nbsp;sure&nbsp;that&nbsp;the&nbsp;ApplicationContext&nbsp;of&nbsp;the&nbsp;main&nbsp;loop&nbsp;always&nbsp;has</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;an&nbsp;open&nbsp;form&nbsp;till&nbsp;the&nbsp;last&nbsp;form&nbsp;is&nbsp;closed.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;To&nbsp;use&nbsp;this&nbsp;class:&nbsp;Simply&nbsp;replace&nbsp;the&nbsp;Application.Run&nbsp;call&nbsp;in&nbsp;program.cs&nbsp;with</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;FormsApplication.Run.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;FormsApplication&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Application&nbsp;context</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;ApplicationContext&nbsp;_appContext;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Run&nbsp;the&nbsp;Application&nbsp;Loop</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Run()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_appContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationContext();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Run(_appContext);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Run&nbsp;the&nbsp;Application&nbsp;Loop&nbsp;with&nbsp;a&nbsp;given&nbsp;context.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Run(ApplicationContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Validate&nbsp;arguments</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(nameof(context));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;the&nbsp;application&nbsp;context&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_appContext&nbsp;=&nbsp;context;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;add&nbsp;us&nbsp;to&nbsp;the&nbsp;closed&nbsp;event.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context.MainForm&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.MainForm.Closed&nbsp;&#43;=&nbsp;ClosedEventHandler;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Start&nbsp;the&nbsp;main&nbsp;loop.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Run(context);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Run&nbsp;the&nbsp;Application&nbsp;Loop&nbsp;with&nbsp;a&nbsp;given&nbsp;form.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Run(Form&nbsp;form)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Validate&nbsp;arguments</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(form&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(nameof(form));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;form.Closed&nbsp;&#43;=&nbsp;ClosedEventHandler;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_appContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationContext&nbsp;{&nbsp;MainForm&nbsp;=&nbsp;form&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Run(_appContext);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Event&nbsp;handler&nbsp;that&nbsp;removes&nbsp;a&nbsp;form&nbsp;when&nbsp;it&nbsp;is&nbsp;closed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;The&nbsp;Application.OpenForms&nbsp;collection&nbsp;contained&nbsp;the&nbsp;window&nbsp;that&nbsp;was&nbsp;closing&nbsp;in&nbsp;my&nbsp;tests.&nbsp;But</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;that&nbsp;is&nbsp;something&nbsp;that&nbsp;I&nbsp;do&nbsp;not&nbsp;trust&nbsp;because&nbsp;that&nbsp;might&nbsp;change&nbsp;depending&nbsp;on&nbsp;implementation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;details.&nbsp;So&nbsp;this&nbsp;code&nbsp;is&nbsp;safe.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Important:&nbsp;This&nbsp;code&nbsp;is&nbsp;not&nbsp;thread&nbsp;safe!&nbsp;I&nbsp;trust&nbsp;that&nbsp;all&nbsp;changes&nbsp;are&nbsp;done&nbsp;by&nbsp;the&nbsp;UI&nbsp;thread</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;as&nbsp;it&nbsp;should&nbsp;be&nbsp;done&nbsp;in&nbsp;all&nbsp;Windows&nbsp;Forms&nbsp;actions!</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ClosedEventHandler(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Validate&nbsp;arguments</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(sender&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(nameof(sender));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(nameof(e));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Do&nbsp;nothing&nbsp;if&nbsp;the&nbsp;closed&nbsp;form&nbsp;is&nbsp;not&nbsp;the&nbsp;main&nbsp;form&nbsp;or&nbsp;if&nbsp;the&nbsp;count&nbsp;of&nbsp;open&nbsp;forms&nbsp;is&nbsp;0.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_appContext.MainForm&nbsp;!=&nbsp;sender&nbsp;||&nbsp;Application.OpenForms.Count&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Search&nbsp;for&nbsp;a&nbsp;form&nbsp;which&nbsp;is&nbsp;not&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Form&nbsp;form&nbsp;<span class="cs__keyword">in</span>&nbsp;Application.OpenForms)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Continue&nbsp;search&nbsp;if&nbsp;form&nbsp;is&nbsp;sender.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(form&nbsp;==&nbsp;sender)&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;the&nbsp;MainForm,&nbsp;add&nbsp;listener&nbsp;to&nbsp;Closed&nbsp;Event&nbsp;and&nbsp;leave&nbsp;method.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_appContext.MainForm&nbsp;=&nbsp;form;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_appContext.MainForm.Closed&nbsp;&#43;=&nbsp;ClosedEventHandler;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;no&nbsp;other&nbsp;form&nbsp;found,&nbsp;nothing&nbsp;to&nbsp;do.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>FormsApplication - Static class with the logic required</em> </li><li><em><em>Program.cs - Default Program.cs file with just a small change.</em></em>
</li><li><em><em>ExampleForm - just a small example form which can be opened multiple times.</em></em>
</li></ul>
<h1>More Information</h1>
<ul>
<li><em><a href="http://social.technet.microsoft.com/wiki/contents/articles/34371.close-windows-forms-application-when-last-window-closed.aspx" target="_blank">Technet Wiki: Close Windows Forms Application when last window closed.</a></em>
</li></ul>
