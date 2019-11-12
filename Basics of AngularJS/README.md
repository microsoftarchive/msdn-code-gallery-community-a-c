# Basics of AngularJS
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- HTML5
- AngularJS
## Topics
- Visual Studio
- HTML5
- AngularJS
## Updated
- 07/05/2016
## Description

<p><strong><span style="font-size:small">What Angular JS is</span></strong></p>
<p><span style="font-size:small">AngularJS has been introduced by the giant Google. It is a framework that helps you create dynamic web apps. Normally AngularJS uses HTML as the backbone. AngularJS creates extended HTML tags that can be used as normal HTML
 tags. These tags will help you to write efficient code. The interesting fact is you can reduce lines of codes you may need to write when you use normal JavaScript.</span></p>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">So let&rsquo;s start using AngularJS. What would be the first step you need to do? That would be to include the relevant JavaScript file as in the following:</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_956405">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Script/</span>angular.min.js&rdquo;&gt;&lt;/script&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Once you include this file, you are free to enter the world of AngularJS. You can download that file from:<a href="https://angularjs.org/">https://angularjs.org/</a></span></p>
<p><span style="font-size:small">Basic Directives:&nbsp;There are some basic directives that you must be aware of in AngularJS. They are the following.</span></p>
<ul>
<li><span style="font-size:small">ng-app</span> </li><li><span style="font-size:small">ng-init</span> </li><li><span style="font-size:small">ng-model</span> </li><li><span style="font-size:small">ng-repeat</span> </li></ul>
<p><span style="font-size:small">We will discuss them.&nbsp;Let&rsquo;s start with a basic example.</span></p>
<p><span style="font-size:small">As I said before, AngularJS uses our HTML to work. So here we will create HTML with minimal tags. Are you ready?</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_614365">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;ng-app&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;My&nbsp;name&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>&ldquo;Please&nbsp;make&nbsp;me&nbsp;upper&nbsp;<span class="js__statement">case</span>&nbsp;letter&rdquo;.toUpperCase()<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;&nbsp;
&lt;/div&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">In the preceding example we added the tag ng-app, right? So what is ng-app?</span></p>
<p><span style="font-size:small">ng-app</span></p>
<p><span style="font-size:small">The ng-app tag indicates the root element of our angular application. It normally acts as the owner of the application. We can use AngularJS only after the declaration of this tag. The important point to remember is that we
 can&rsquo;t use AngularJS before this tag. We will explain this with an example.</span></p>
<p><span style="font-size:small">What if we add a calculation of two numbers before the ng-app tag? We will check it out.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_219188">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;p&gt;Add&nbsp;me&nbsp;please:&nbsp;<span class="js__num">2</span><span class="js__num">&#43;2</span>:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;<span class="js__num">2</span><span class="js__num">&#43;2</span>&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;&nbsp;
&lt;div&nbsp;ng-app&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;My&nbsp;name&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>&ldquo;Please&nbsp;make&nbsp;me&nbsp;upper&nbsp;<span class="js__statement">case</span>&nbsp;letter&rdquo;.toUpperCase()<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;&nbsp;
&lt;/div&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">What would be the output of this? Any guess?</span></p>
<p><span style="font-size:small"><img src="-12.png" alt=""></span></p>
<p><span style="font-size:small">So what we need to make this work? For that you must put the code after the ng-app declaration. Can we try that? So our modified code would be as follows.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_405907">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;ng-app&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;My&nbsp;name&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>&ldquo;Please&nbsp;make&nbsp;me&nbsp;upper&nbsp;<span class="js__statement">case</span>&nbsp;letter&rdquo;.toUpperCase()<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;&nbsp;
&lt;p&gt;Add&nbsp;me&nbsp;please:&nbsp;<span class="js__num">2</span><span class="js__num">&#43;2</span>:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;<span class="js__num">2</span><span class="js__num">&#43;2</span>&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now our output is:</span></p>
<p><span style="font-size:small"><img src="-123.png" alt="" width="530" height="169"></span></p>
<p><span style="font-size:small">Well, that was the introduction to the directive ng-app. I hope you tried it. Now we will move on to the next one. What is it?</span></p>
<p><span style="font-size:small">ng-init</span></p>
<p><span style="font-size:small">As the name implies, ng-init is used to initialize the data of our AngularJS. We will try a demo.&nbsp;So the following is my HTML.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_319662">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;ng-init=&ldquo;myFavoriteWebsites=[&lsquo;http:<span class="js__sl_comment">//www.c-sharpcorner.com/&rsquo;,&rsquo;http://www.codeproject.com/&rsquo;,&rsquo;http://sibeeshpassion.com/&rsquo;]&rdquo;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My&nbsp;First&nbsp;fav&nbsp;website&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myFavoriteWebsites[<span class="js__num">0</span>]<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My&nbsp;Second&nbsp;fav&nbsp;website&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myFavoriteWebsites[<span class="js__num">1</span>]<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My&nbsp;Third&nbsp;fav&nbsp;website&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myFavoriteWebsites[<span class="js__num">2</span>]<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Please note that I have used the ng-init tag after the ng-app tag.&nbsp;Now can you&nbsp;guess what the output would be?</span></p>
<p><span style="font-size:small"><img src="-1234.png" alt=""></span></p>
<p><span style="font-size:small">I hope you understand what exactly ng-init tag is. Now we will see ng-model.</span></p>
<p><span style="font-size:small">ng-model</span></p>
<p><span style="font-size:small">Basically the ng-model directive binds the values from our HTML controls to our application data. Sounds good, right?</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_791225">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">Currency&nbsp;<span class="js__operator">in</span>&nbsp;INR:&nbsp;&lt;input&nbsp;type=&ldquo;number&rdquo;&nbsp;ng-model=&ldquo;curinr&rdquo;&nbsp;/&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;Dollar:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>curinr*<span class="js__num">62.27</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">In the preceding example, we are using ng-model &ldquo;curinr&rdquo; and we are accessing that in our application data. In this process, whenever you type any value into the number box area, in a fraction of time you can see
 the calculated value. That is the power of AngularJS.</span></p>
<p><span style="font-size:small"><img src="-capture.jpg" alt=""></span></p>
<p><span style="font-size:small">So I hope you understood how to use the ng-model directive.&nbsp;Now it is time to move on to our next directive, ng-repeat.</span></p>
<p><span style="font-size:small">ng-repeat</span></p>
<p><span style="font-size:small">This directive is used for looping through a collection or array just like we use a foreach loop in C#. Sounds pretty cool, right? It clones the HTML elements once for each item in the collection.</span></p>
<p><span style="font-size:small">To work with ng-repeat we will see our previous example. We will modify that example as follows:</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_142076">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;ng-init=&ldquo;myFavoriteWebsites=[&lsquo;http:<span class="js__sl_comment">//www.c-sharpcorner.com/&rsquo;,&rsquo;http://www.codeproject.com/&rsquo;,&rsquo;http://sibeeshpassion.com/&rsquo;]&rdquo;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My&nbsp;favorite&nbsp;websites&nbsp;are:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&nbsp;ng-repeat=&ldquo;n&nbsp;<span class="js__operator">in</span>&nbsp;myFavoriteWebsites&rdquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>n<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now see the output below. With less lines of codes we have done this process.&nbsp;That is all about the ng-repeat directive. I hope you liked it.</span></p>
<p><span style="font-size:small"><img src="-capture1.jpg" alt=""></span></p>
<p><span style="font-size:small">When you write any code, it must be light weight and easy, efficient.</span></p>
<p><span style="font-size:small"><img src="-codecomplex.jpg" alt=""></span></p>
<p><span style="font-size:small">If it is not easy, someone who looks at your code will be &hellip;..</span></p>
<p><strong><span style="font-size:small">What is controllers?</span></strong></p>
<p><span style="font-size:small">Angular JS controllers are Java script object. Simple . The main functionality of this object is controlling the data of our angular application. Sounds cool right?</span></p>
<p><span style="font-size:small">The directive used here is&nbsp;<em>ng-controller</em>.</span></p>
<p><span style="font-size:small">In the previous section we used ng-model right? We have seen an example too. Now we will reuse that example here.</span></p>
<p><span style="font-size:small">The following is the example we done with ng-model</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_607613">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">Currency&nbsp;<span class="js__operator">in</span>&nbsp;INR:&nbsp;&lt;input&nbsp;type=&ldquo;number&rdquo;&nbsp;ng-model=&ldquo;curinr&rdquo;&nbsp;/&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;Dollar:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>curinr*<span class="js__num">62.27</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">No we will change it to as follows.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_836514">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;b&gt;ng-Controller&lt;<span class="js__reg_exp">/b&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&lt;div&nbsp;&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;INR:&nbsp;
&lt;input&nbsp;type=&ldquo;number&rdquo;&nbsp;ng-model=&ldquo;inrvalue&rdquo;&nbsp;/&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;Dollar:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>inrToDollar()<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;/div&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">In the above piece of code you can find a new directive ng-controller and I have assigned a valueInrToDollar . So our next step is to create that controller.</span></p>
<p><span style="font-size:small">We can create a controller as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_947">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;my&nbsp;=&nbsp;angular.module(&lsquo;angularBasic&rsquo;,&nbsp;[]);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Here &lsquo;angularBasic&rsquo; is our application name. The complete code for creating our controller is as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_722160">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;script&gt;&nbsp;
<span class="js__statement">var</span>&nbsp;my&nbsp;=&nbsp;angular.module(&lsquo;angularBasic&rsquo;,&nbsp;[]);&nbsp;
my.controller(&lsquo;InrToDollar&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;($scope)&nbsp;<span class="js__brace">{</span>&nbsp;
$scope.inrToDollar&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
<span class="js__statement">return</span>&nbsp;$scope.inrvalue&nbsp;*&nbsp;<span class="js__num">62.27</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>);&nbsp;
&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">What is&nbsp;<em>$scope&nbsp;</em>in the above code block?</span></p>
<p><span style="font-size:small"><em>$scope</em>&nbsp;is a part of controller. Every controller must have its own $scope object. Here what exactly our controller do is setting the behaviors on $scope.</span></p>
<p><span style="font-size:small">In the above code block we used a function which returns a dollar value for the given Indian rupee. I have given the function body inside of our controller.</span></p>
<p><span style="font-size:small">No what would be our output?</span></p>
<p><span style="font-size:small"><img src="-controllerout1.png" alt=""></span></p>
<p><span style="font-size:small"><img src="-controller2.png" alt=""></span></p>
<p><span style="font-size:small">Now think if you are using normal java script and jquery for doing this task, how many lines of codes you may need to write?</span></p>
<p><strong><span style="font-size:small">Complete HTML</span></strong></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_362267">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
ViewBag.Title&nbsp;=&nbsp;&ldquo;Index&rdquo;;&nbsp;
<span class="js__brace">}</span>&nbsp;
&lt;h2&gt;Index&lt;/h2&gt;&nbsp;
&lt;b&gt;ng-app&lt;/b&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
&lt;div&nbsp;ng-app=&ldquo;angularBasic&rdquo;&nbsp;ng-controller=&ldquo;InrToDollar&rdquo;&gt;&nbsp;
&lt;p&gt;My&nbsp;name&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>&ldquo;Please&nbsp;make&nbsp;me&nbsp;upper&nbsp;<span class="js__statement">case</span>&nbsp;letter&rdquo;.toUpperCase()<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;&nbsp;
&lt;p&gt;Add&nbsp;me&nbsp;please:&nbsp;<span class="js__num">2</span><span class="js__num">&#43;2</span>:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;<span class="js__num">2</span><span class="js__num">&#43;2</span>&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;&nbsp;
&lt;b&gt;ng-init&lt;<span class="js__reg_exp">/b&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&lt;div&nbsp;ng-init=&ldquo;myFavoriteWebsites=[&lsquo;http:<span class="js__sl_comment">//www.c-sharpcorner.com/&rsquo;,&rsquo;http://www.codeproject.com/&rsquo;,&rsquo;http://sibeeshpassion.com/&rsquo;]&rdquo;&gt;</span>&nbsp;
My&nbsp;First&nbsp;fav&nbsp;website&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myFavoriteWebsites[<span class="js__num">0</span>]<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
My&nbsp;Second&nbsp;fav&nbsp;website&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myFavoriteWebsites[<span class="js__num">1</span>]<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
My&nbsp;Third&nbsp;fav&nbsp;website&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myFavoriteWebsites[<span class="js__num">2</span>]<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;/div&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
&lt;b&gt;ng-model&lt;<span class="js__reg_exp">/b&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;INR:&nbsp;
&lt;input&nbsp;type=&ldquo;number&rdquo;&nbsp;ng-model=&ldquo;curinr&rdquo;&nbsp;/&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;Dollar:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>curinr*<span class="js__num">62.27</span><span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
&lt;b&gt;nd-repeat&lt;<span class="js__reg_exp">/b&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&lt;div&nbsp;ng-init=&ldquo;myFavoriteWebsites=[&lsquo;http:<span class="js__sl_comment">//www.c-sharpcorner.com/&rsquo;,&rsquo;http://www.codeproject.com/&rsquo;,&rsquo;http://sibeeshpassion.com/&rsquo;]&rdquo;&gt;</span>&nbsp;
&lt;ul&gt;&nbsp;
My&nbsp;favorite&nbsp;websites&nbsp;are:&nbsp;
&lt;li&nbsp;ng-repeat=&ldquo;n&nbsp;<span class="js__operator">in</span>&nbsp;myFavoriteWebsites&rdquo;&gt;<span class="js__brace">{</span><span class="js__brace">{</span>n<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;/li&gt;&nbsp;
&lt;/ul&gt;&nbsp;
&lt;/div&gt;&nbsp;
&lt;b&gt;ng-Controller&lt;<span class="js__reg_exp">/b&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&lt;div&nbsp;&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;INR:&nbsp;
&lt;input&nbsp;type=&ldquo;number&rdquo;&nbsp;ng-model=&ldquo;inrvalue&rdquo;&nbsp;/&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
Currency&nbsp;<span class="js__operator">in</span>&nbsp;Dollar:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>inrToDollar()<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;/div&gt;&nbsp;
&lt;br&nbsp;/&gt;&nbsp;
&lt;/div&gt;&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Script/</span>angular.min.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&lt;script&gt;&nbsp;
<span class="js__statement">var</span>&nbsp;my&nbsp;=&nbsp;angular.module(&lsquo;angularBasic&rsquo;,&nbsp;[]);&nbsp;
my.controller(&lsquo;InrToDollar&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;($scope)&nbsp;<span class="js__brace">{</span>&nbsp;
$scope.inrToDollar&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
<span class="js__statement">return</span>&nbsp;$scope.inrvalue&nbsp;*&nbsp;<span class="js__num">62.27</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>);&nbsp;
&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong><span style="font-size:small">Conclusion</span></strong></p>
<p><span style="font-size:small">Now that is all for the day, I will return with another set of items in AngularJS soon. I hope you liked this article. Please provide your valuable suggestions.</span></p>
<h1></h1>
