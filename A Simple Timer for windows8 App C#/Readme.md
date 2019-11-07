# A Simple Timer for windows8 App C#
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Windows 8
- Visual Studio 2012
- Windows 8 Store Apps
- Windows Store app
## Topics
- A Timer for windows8 App
## Updated
- 05/04/2013
## Description

<h1>Introduction</h1>
<p><em>Explicitly there is no Timer control in VS2012 for windows store apps. This Sample gives a solution for this, by implementing a simple timer.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>A timer can be created with the help of the DispatcherTimer class.</em></p>
<p><em>Main Functionality:</em></p>
<p><em>For every n seconds (you specify as the timer interval), the Tick event is Fired untill the timer is stopped.</em></p>
<p><em>Many of the young developers having doubts related to timer like,&nbsp;</em></p>
<p><em>How to implement a Timer in windows8 App?</em></p>
<p><em>How to start and stop a Timer ?</em></p>
<p><em>The sample gives &nbsp;answer to all timer related questions in a simple and easy way.<br>
<br>
</em></p>
<p><em>&nbsp;</em></p>
<p><em>Only a few steps in implementation,</em></p>
<p><em>1, Create a object for the DispatcherTimer class.</em></p>
<p><em>2,Associate a Event &quot;Tick&quot; with the created object using the below code.</em></p>
<p><strong><em>&nbsp; &nbsp; timer.Tick &#43;= timer_Tick();</em></strong></p>
<p><em>3,Set a timer Interval for which periodically the Tick event is Fired(when the Timer is On) using the below line.</em></p>
<p><em><strong>&nbsp;&nbsp;&nbsp; timer.Interval = TimeSpan.FromSeconds(5);</strong>// here is set the interval as 5 seconds</em></p>
<p><em>4, Then define the <strong>timer_tick </strong>method according to your own usage(In my sample i just displayed the time consumed).</em></p>
<p><em><br>
</em></p>
<p><em><br>
</em></p>
<p><em>&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> 
        private DispatcherTimer timer;
        private int i,j;

       
          timer = new DispatcherTimer();
          timer.Tick &#43;= timer_Tick;
          timer.Interval = TimeSpan.FromSeconds(i);
      
      
        void timer_Tick(object sender, object e)
        {
            
            TimerTextBlock.Text = &quot;Time Consumed: &quot; &#43; (i) &#43; &quot; second(s)&quot;;
            i = i &#43; j;
        }

      </pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DispatcherTimer&nbsp;timer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;i,j;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DispatcherTimer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Tick&nbsp;&#43;=&nbsp;timer_Tick;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Interval&nbsp;=&nbsp;TimeSpan.FromSeconds(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;timer_Tick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;<span class="cs__keyword">object</span>&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TimerTextBlock.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Time&nbsp;Consumed:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;(i)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;second(s)&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i&nbsp;=&nbsp;i&nbsp;&#43;&nbsp;j;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><em>Only a few steps in implementation,</em></p>
<p><em>1, Create a object for the DispatcherTimer class.</em></p>
<p><em>2,Associate a Event &quot;Tick&quot; with the created object using the below code.</em></p>
<p><em>&nbsp; timer.Tick &#43;= timer_Tick();</em></p>
<p><em>3,Set a timer Interval for which periodically the Tick event is Fired(when the Timer is On) using the below line.</em></p>
<p><em>&nbsp;&nbsp;&nbsp; timer.Interval = TimeSpan.FromSeconds(5);// here is set the interval as 5 seconds</em></p>
<p><em>4, Then define the timer_tick method according to your own usage(In my sample i just displayed the time consumed).</em></p>
