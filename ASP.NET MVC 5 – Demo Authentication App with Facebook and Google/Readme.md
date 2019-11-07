# ASP.NET MVC 5 – Demo Authentication App with Facebook and Google
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- ASP.NET MVC
- .NET Framework
- .NET Framework 4.0
- ASP.NET MVC 4
- MVC
- MVC Examples
- ASP.NET MVC 5
- MVC5
## Topics
- Controls
- C#
- Data Binding
- User Interface
- Data Access
- ASP.NET MVC
- ASP.NET MVC Basics
- MVC Example
## Updated
- 02/01/2014
## Description

<p><span><span>MVC5 came with some really nice stuff. In this post I&rsquo;ll dig into the authentication with external logins as Microsoft calls them.&nbsp;</span></span><span>With this demo, I will demonstrate how it&rsquo;s possible to configure application,
 to allow authentication using Google and Facebook.&nbsp;</span></p>
<p>&nbsp;</p>
<h1>STEP1. Create new project on Visual Studio 2013</h1>
<p class="Instructions">Open Visual Studio</p>
<p class="Instructions">Create new ASP.NET Web Application Project</p>
<p class="Instructions">Give a name to the project (in this case I call him MVC5Authentication)</p>
<p class="Instructions"><img id="106477" src="106477-mvc1.jpg" alt="" width="951" height="536"></p>
<p class="Instructions">&nbsp;</p>
<h1>STEP2. Select option Change Authentication</h1>
<p class="Instructions">Select MVC template</p>
<p class="Instructions">Select option Change Authentication</p>
<p>&nbsp;</p>
<p><img id="106478" src="106478-mvc2.jpg" alt="" width="765" height="537"></p>
<p>&nbsp;</p>
<p class="Instructions">This option open a new window, were we need to check the option &ldquo;Individual User Account&rdquo;</p>
<p class="Instructions"><img id="106479" src="106479-mvc3.jpg" alt="" width="716" height="315"></p>
<p>&nbsp;</p>
<p>Start application.</p>
<p>As we see on the next image on the right part where it&rsquo;s possible to have other authentication services it&rsquo;s empty.</p>
<p>On the next step, we will configure the application, to provide two new authentication services (Google and Facebook)</p>
<p><img id="106480" src="106480-mvc4.jpg" alt="" width="1298" height="498"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>STEP3. Enable Google and Facebook OpenID</h1>
<p class="Instructions">Open&nbsp;App_Start\Startup.Auth.cs&nbsp;file and remove the comment&nbsp;characters in&nbsp;//app.UseGoogleAuthentication();&nbsp; to&nbsp;enable Google authentication and in app.UseFacebookAuthentication to enable Facebook authentication.</p>
<p class="Instructions">&nbsp;</p>
<p class="Instructions"><img id="106481" src="106481-mvc5.jpg" alt="" width="1306" height="546"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public partial class Startup

    {

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864

        public void ConfigureAuth(IAppBuilder app)

        {

            // Enable the application to use a cookie to store information for the signed in user

            app.UseCookieAuthentication(new CookieAuthenticationOptions

            {

                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                LoginPath = new PathString(&quot;/Account/Login&quot;)

            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

 

            // Uncomment the following lines to enable logging in with third party login providers

            //app.UseMicrosoftAccountAuthentication(

            //    clientId: &quot;&quot;,

            //    clientSecret: &quot;&quot;);

 

            //app.UseTwitterAuthentication(

            //   consumerKey: &quot;&quot;,

            //   consumerSecret: &quot;&quot;);

 

            app.UseFacebookAuthentication(

               appId: &quot;&quot;,

               appSecret: &quot;&quot;);

 

            app.UseGoogleAuthentication();

        }

    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Startup&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;configuring&nbsp;authentication,&nbsp;please&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkId=301864</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConfigureAuth(IAppBuilder&nbsp;app)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Enable&nbsp;the&nbsp;application&nbsp;to&nbsp;use&nbsp;a&nbsp;cookie&nbsp;to&nbsp;store&nbsp;information&nbsp;for&nbsp;the&nbsp;signed&nbsp;in&nbsp;user</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseCookieAuthentication(<span class="cs__keyword">new</span>&nbsp;CookieAuthenticationOptions&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AuthenticationType&nbsp;=&nbsp;DefaultAuthenticationTypes.ApplicationCookie,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoginPath&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PathString(<span class="cs__string">&quot;/Account/Login&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;a&nbsp;cookie&nbsp;to&nbsp;temporarily&nbsp;store&nbsp;information&nbsp;about&nbsp;a&nbsp;user&nbsp;logging&nbsp;in&nbsp;with&nbsp;a&nbsp;third&nbsp;party&nbsp;login&nbsp;provider</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Uncomment&nbsp;the&nbsp;following&nbsp;lines&nbsp;to&nbsp;enable&nbsp;logging&nbsp;in&nbsp;with&nbsp;third&nbsp;party&nbsp;login&nbsp;providers</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//app.UseMicrosoftAccountAuthentication(</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;clientId:&nbsp;&quot;&quot;,</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;clientSecret:&nbsp;&quot;&quot;);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//app.UseTwitterAuthentication(</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;consumerKey:&nbsp;&quot;&quot;,</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;consumerSecret:&nbsp;&quot;&quot;);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseFacebookAuthentication(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appId:&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appSecret:&nbsp;<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseGoogleAuthentication();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Start application again.</div>
<p>&nbsp;</p>
<p>On the start, the application, give us the following error.</p>
<p>This error, happens because is necessary to create and configure an App on Facebook, that provide us an appID and appSecret, which will be use on the UseFacebookAuthentocation method.</p>
<p>&nbsp;</p>
<p><img id="106482" src="106482-mvc6.jpg" alt="" width="1279" height="520"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>STEP4. Setting up SSL</h1>
<p>To connect to Facebook, you will need to set up IIS-Express to use SSL. Even&nbsp;though Google doesn't require you to use SSL to log in, it's a security best &nbsp;practice to require SSL in your application.&nbsp;</p>
<p>On the project solution Press F4.</p>
<p>Enable SSL (a new URL will be provided)</p>
<p>&nbsp;</p>
<p>&nbsp;<img id="106484" src="106484-mvc7.jpg" alt="" width="309" height="442"></p>
<p>&nbsp;</p>
<p>Access to the properties of the solution and change the project URL, providing the URL given on the project properties SSL URL</p>
<p><img id="106485" src="106485-mvc8.jpg" alt="" width="1008" height="528"></p>
<p>&nbsp;</p>
<h1>STEP5. Configure App Facebook</h1>
<p>Open Facebook web page and create a new App</p>
<p>Set the Display Name and the Category</p>
<p>&nbsp;</p>
<p><img id="106486" src="106486-mvc10.jpg" alt="" width="961" height="520"></p>
<p>&nbsp;</p>
<p>After create the app, we get access to appID and appSecret</p>
<p><img id="106487" src="106487-mvc11.jpg" alt="" width="953" height="234"></p>
<p>&nbsp;</p>
<p>Set the SSL URL, on the valid OAuth URLs, to give access of our application to Facebook.</p>
<p>&nbsp;<img id="106489" src="106489-mvc11.jpg" alt="" width="953" height="234"></p>
<p>&nbsp;</p>
<p>Set appID and appSecret into our code.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864

        public void ConfigureAuth(IAppBuilder app)

        {

            // Enable the application to use a cookie to store information for the signed in user

            app.UseCookieAuthentication(new CookieAuthenticationOptions

            {

                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                LoginPath = new PathString(&quot;/Account/Login&quot;)

            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

 

            // Uncomment the following lines to enable logging in with third party login providers

            //app.UseMicrosoftAccountAuthentication(

            //    clientId: &quot;&quot;,

            //    clientSecret: &quot;&quot;);

 

            //app.UseTwitterAuthentication(

            //   consumerKey: &quot;&quot;,

            //   consumerSecret: &quot;&quot;);

 

            //change the id and secret toconnect to your application

            app.UseFacebookAuthentication(

               appId: &quot;574609735957646&quot;,

               appSecret: &quot;4339c983ffa2685c1b09d580e3380455&quot;);

 

            app.UseGoogleAuthentication();

        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;configuring&nbsp;authentication,&nbsp;please&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkId=301864</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConfigureAuth(IAppBuilder&nbsp;app)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Enable&nbsp;the&nbsp;application&nbsp;to&nbsp;use&nbsp;a&nbsp;cookie&nbsp;to&nbsp;store&nbsp;information&nbsp;for&nbsp;the&nbsp;signed&nbsp;in&nbsp;user</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseCookieAuthentication(<span class="cs__keyword">new</span>&nbsp;CookieAuthenticationOptions&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AuthenticationType&nbsp;=&nbsp;DefaultAuthenticationTypes.ApplicationCookie,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoginPath&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PathString(<span class="cs__string">&quot;/Account/Login&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;a&nbsp;cookie&nbsp;to&nbsp;temporarily&nbsp;store&nbsp;information&nbsp;about&nbsp;a&nbsp;user&nbsp;logging&nbsp;in&nbsp;with&nbsp;a&nbsp;third&nbsp;party&nbsp;login&nbsp;provider</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Uncomment&nbsp;the&nbsp;following&nbsp;lines&nbsp;to&nbsp;enable&nbsp;logging&nbsp;in&nbsp;with&nbsp;third&nbsp;party&nbsp;login&nbsp;providers</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//app.UseMicrosoftAccountAuthentication(</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;clientId:&nbsp;&quot;&quot;,</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;clientSecret:&nbsp;&quot;&quot;);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//app.UseTwitterAuthentication(</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;consumerKey:&nbsp;&quot;&quot;,</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;consumerSecret:&nbsp;&quot;&quot;);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//change&nbsp;the&nbsp;id&nbsp;and&nbsp;secret&nbsp;toconnect&nbsp;to&nbsp;your&nbsp;application</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseFacebookAuthentication(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appId:&nbsp;<span class="cs__string">&quot;574609735957646&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appSecret:&nbsp;<span class="cs__string">&quot;4339c983ffa2685c1b09d580e3380455&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseGoogleAuthentication();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1>STEP6. Run application</h1>
<p>Run application after save all the changes below.</p>
<p>As you see, now after our configuration, we application provide two new services of logn (Google and Facebook)</p>
<h1><img id="106488" src="106488-mvc13.jpg" alt="" width="1280" height="503"></h1>
<h1>Resources</h1>
<p class="Instructions">&nbsp;</p>
<p class="Instructions"><a href="http://openid.net/specs/openid-authentication-2_0.html">http://openid.net/specs/openid-authentication-2_0.html</a></p>
<p class="Instructions"><a href="http://oauth.net/2/">http://oauth.net/2/</a></p>
<p class="Instructions">&nbsp;</p>
<p>For more examples, follow my blog at</p>
<p><a href="http://joaoeduardosousa.wordpress.com/">http://joaoeduardosousa.wordpress.com/</a></p>
