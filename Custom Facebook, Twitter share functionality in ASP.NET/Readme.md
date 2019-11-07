# Custom Facebook, Twitter share functionality in ASP.NET
## Requires
- 
## License
- MIT
## Technologies
- Twitter
- Facebook
- Facebook SDK
- ASP.NET 4.5
## Topics
- Custom facebook share in asp.net
- custom twitter share in asp.net
- how to share on facebook from local
- how to share on twitter from local
- facebook share
- twitter share
- share url on facebook
- share url on twitter
## Updated
- 01/06/2015
## Description

<p><span style="font-size:small">In this article I will explain how to achieve share custom parameters like title, URL, description, image in asp.net.</span></p>
<p><span style="font-size:small">First of all let&rsquo;s create a new app on Facebook to get app id and app secret and select Website.</span></p>
<p><img id="132070" src="132070-img1.jpg" alt="" width="929" height="608"></p>
<p><span style="font-size:small">Image1.</span></p>
<p><span style="font-size:small">Now enter app name and click create button.</span></p>
<p><img id="132071" src="132071-img2.jpg" alt="" width="924" height="339">&nbsp;</p>
<p><span style="font-size:small">Image2.</span></p>
<p><span style="font-size:small">You can choose app category.</span></p>
<p><img id="132072" src="132072-img3.jpg" alt="" width="598" height="494"></p>
<p><span style="font-size:small">Image3.</span></p>
<p><span style="font-size:small">Here your app id and app secret ready.</span></p>
<p><img id="132073" src="132073-img4.jpg" alt="" width="728" height="254">&nbsp;</p>
<p><span style="font-size:small">Image4.</span></p>
<p><span style="font-size:small">Copy app id and app secret.</span></p>
<p><span style="font-size:small">Now let&rsquo;s make twitter app and generate API key and secret. Open
<a href="https://apps.twitter.com/">https://apps.twitter.com/</a> and click Create New App button and fill all app details and click create.</span></p>
<p><img id="132074" src="132074-img5.jpg" alt="" width="964" height="188">&nbsp;</p>
<p><span style="font-size:small">Image 5.</span></p>
<p><img id="132076" src="132076-img6.jpg" alt="" width="944" height="324">&nbsp;</p>
<p><span style="font-size:small">Image6.</span></p>
<p><span style="font-size:small">You can see consumer key, callback URL, access level. Note down the consumer key.</span></p>
<p><img id="132077" src="132077-img7.jpg" alt="" width="686" height="527">&nbsp;</p>
<p><span style="font-size:small">Image7.</span></p>
<p><span style="font-size:small">Here we are done with app things. Now let&rsquo;s go in project and implement custom share functionality on Facebook and twitter.</span></p>
<p><span style="font-size:small">First of all make some keys in web.config file and copy API keys and secret.</span></p>
<p><img id="132078" src="132078-img8.jpg" alt="" width="491" height="253">&nbsp;</p>
<p><span style="font-size:small">Image8.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&lt;div id=&quot;DetailDiv&quot;&gt;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &lt;/div&gt;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;script src=&quot;Scripts/jquery-2.1.3.min.js&quot;&gt;&lt;/script&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&lt;script type=&quot;text/javascript&quot;&gt;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $(document).ready(function () {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; createHtml();</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //create html //</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; function createHtml() {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var title = &quot;How to Authenticate and Get Data Using Instagram API&quot;;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var summary = &quot;This article explains how to authenticate an Instagram API and how to get user photos, user details and popular photos
 using the Instagram API.&quot;;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var url = &quot;https://www.facebook.com/raj2511984&quot;;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var image = 'https://fbcdn-sphotos-d-a.akamaihd.net/hphotos-ak-xpa1/v/t1.0-9/10153182_10153281334431040_8373343421018856197_n.jpg?oh=2f5cbcae8d125e72e0cbc6131c3634ea&amp;oe=552C0BE0&amp;__gda__=1429949942_5641254857be91dda7dd0653815ebf48';</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var appid = '&lt;%=ConfigurationManager.AppSettings[&quot;FacebookConsumerKey&quot;].ToString() %&gt;';</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //login pop height, width</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var w = 600;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var h = 400;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var left = Number((screen.width / 2) - (w / 2));</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var top = Number((screen.height / 2) - (h / 2));</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //****//</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //facebook login window and pass paramemters like title, summary, url, image</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var fb = '&lt;a rel=&quot;nofollow&quot;&nbsp;&nbsp; title=\&quot;Share this post on Facebook\&quot; onclick=&quot;FbApp_Login(\'' &#43; title &#43; '\',\'' &#43; summary
 &#43; '\',\'' &#43; url &#43; '\',\'' &#43; image &#43; '\');&quot;&gt;&lt;img src=&quot;Images/fb.png&quot; /&gt;&lt;/a&gt;';</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //****//</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //twitter login window and pass paramemters like title, url</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var twitter = &quot;&lt;a&nbsp; href=https://twitter.com/intent/tweet?original_referer=&quot; &#43; encodeURIComponent(url) &#43; &quot;&amp;amp;related=ModelQ-Job&amp;amp;text=&quot;
 &#43; encodeURIComponent(title) &#43; &quot;&amp;amp;tw_p=tweetbutton&amp;amp;url=&quot; &#43; encodeURIComponent(url) &#43; &quot;&amp;amp;via=_ModelQ title=\&quot;Share this post on Twitter\&quot; onclick=\&quot;javascript:window.open(this.href,&nbsp; '', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,width=&quot;
 &#43; w &#43; &quot;, height=&quot; &#43; h &#43; &quot;, top=&quot; &#43; top &#43; &quot;, left=&quot; &#43; left &#43; &quot;');return false;\&quot;&gt;&lt;img src='Images/twitter.png' /&gt;&lt;/a&gt;&quot;;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //****//</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var socialMediaButtons = fb &#43; &quot;&amp;nbsp;&amp;nbsp;&quot; &#43; twitter;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //bind social variables into div</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; jQuery(&quot;#DetailDiv&quot;).append(' &lt;div&gt;&lt;table width=&quot;100%&quot;&gt;&lt;tr&gt;&lt;td valign=&quot;top&quot; style=&quot; width:100px; height:100px;&quot;&gt;&lt;div&gt;'
 &#43; socialMediaButtons &#43; '&lt;/div&gt;&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt; &lt;/div&gt;');</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //****//</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small">// Facebook login</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; function FbApp_Login(title, sumary, url, image) {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FB.login(function (response) {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (response.authResponse) {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; statusChangeCallback(response, title, summary, url, image);</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }, { scope: 'email,user_photos,publish_actions' });</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; window.fbAsyncInit = function () {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FB.init({</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; appId: '&lt;%=ConfigurationManager.AppSettings[&quot;FacebookConsumerKey&quot;].ToString() %&gt;',</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cookie: true,&nbsp; // enable cookies to allow the server to access</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xfbml: true,&nbsp; // parse social plugins on this page</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; version: 'v2.0' // use version 2.0</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // This is called with the results from from FB.getLoginStatus().</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; function statusChangeCallback(response, title, summary, url, image) {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (response.status === 'connected') {</span></p>
<p><span style="font-size:small">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Logged into your app and Facebook.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FB.ui(</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; method: 'feed',</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; name: title,</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; link: url,</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;picture: image,</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; caption: title,</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; description: summary,</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // source: url,</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; redirect_uri: url,</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; )</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;}</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Load the SDK asynchronously</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (function (d, s, id) {</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var js, fjs = d.getElementsByTagName(s)[0];</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (d.getElementById(id)) return;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; js = d.createElement(s); js.id = id;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; js.src = &quot;//connect.facebook.net/en_US/sdk.js&quot;;</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fjs.parentNode.insertBefore(js, fjs);</span></p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }(document, 'script', 'facebook-jssdk'));</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/script&gt;</span></p>
<p><span style="font-size:small">Time to run the application.</span></p>
<p>&nbsp;</p>
<p><img id="132079" src="132079-img9.jpg" alt="" width="463" height="219">&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small">Image9.</span></p>
<p><span style="font-size:small">Click on Facebook icon to connect.</span></p>
<p><img id="132080" src="132080-img10.jpg" alt="" width="491" height="333">&nbsp;</p>
<p><span style="font-size:small">Image10.</span></p>
<p><img id="132082" src="132082-img11.jpg" alt="" width="593" height="332">&nbsp;</p>
<p><span style="font-size:small">Image11.</span></p>
<p><span style="font-size:small">Click share. Now login on facebook and check in my account.</span></p>
<p><img id="132083" src="132083-img12.jpg" alt="" width="499" height="426">&nbsp;</p>
<p><span style="font-size:small">Image12.</span></p>
<p><span style="font-size:small">Now let&rsquo;s share on twitter. Click on twitter share icon.</span></p>
<p><img id="132084" src="132084-img13.jpg" alt="" width="615" height="459">&nbsp;</p>
<p><span style="font-size:small">Image13.</span></p>
<p><span style="font-size:small">And fill email and password and click Log in and Tweet button. Now logged in on twitter and check latest tweets.</span></p>
<p><img id="132085" src="132085-img14.jpg" alt="" width="591" height="255">&nbsp;</p>
<p><span style="font-size:small">Image14.</span></p>
<p><span style="font-size:small"><strong>Conclusion &ndash;</strong></span></p>
<p><span style="font-size:small">In this article we have learned how to share custom parameters on Facebook and on twitter from local. For more details I have attached sample application.</span></p>
