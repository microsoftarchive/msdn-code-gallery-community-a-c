# AngularJs全面介绍
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- AngularJS
## Topics
- AngularJS
## Updated
- 05/07/2016
## Description

<h1>介绍</h1>
<p><span><span style="white-space:pre"></span>AngularJS是Google推出的一款Web应用开发框架。它提供了一系列兼容性良好并可扩展的服务，包括数据绑定、DOM操作、MVC和依赖注入等特性。</span></p>
<p><span><span style="white-space:pre"></span>AngularJs几乎支持构建一个Web应用的所有内容&mdash;&mdash;数据绑定、表单验证、路由、依赖注入、控制器、模板和视图等。</span></p>
<p><span>但并不是所有的应用都适合用AngularJs来做。AngularJS主要考虑的是构建CURD应用，但至少90%的Web应用都是CURD应用。哪什么不适合用AngularJs来做呢? 如游戏、图像界面编辑器等应用不适合用AngularJs来构建。</span></p>
<p><span style="font-size:20px"><strong>描述</strong></span></p>
<p><span>我们就详细介绍了AngularJS的几个核心知识点，其中包括：</span></p>
<ul>
<li><span>指令（directive）和&nbsp;数据绑定(Data Binding)</span> </li><li><span>模板(Module)</span> </li><li><span>控制器(Controller)</span> </li><li><span>路由(Route)</span> </li><li><span>服务(service)</span> </li><li><span>过滤器(Filter)</span> </li></ul>
<h3><span>3.1 指令和数据绑定</span></h3>
<p><span>在没有使用AngularJs的Web应用，要实现前台页面逻辑通过给HTML元素设置ID，然后使用Js或Jquery通过ID来获取HTML DOM元素。而AngularJS不再需要给HTML元素设置ID，而是使用指令的方式来指导HTML元素的行为。这样做的好处是开发人员看到HTML元素以及指令(Directive)就可以理解其行为，而传统设置Id的方式并不能给你带来任何有用的信息，你需要深入去查看对应的Js代码来理解其行为。</span></p>
<p><span>上面介绍了这么多，好像没有正式介绍指令是什么呢？光顾着介绍指令的好处和传统方式的不同了。指令可以理解为声明特殊的标签或属性。AngularJs内置了很多的指令，你所看到的所有以ng开头的所有标签，如ng-app、ng-init、ng-if、ng-model等。</span></p>
<p><span>ng-app:用于标识页面是一个AngularJs页面。一般加载HTML的根对象上。</span></p>
<p><span>ng-init 用于初始化了一个变量</span></p>
<p><span>ng-model：用户在Property和Html控件之间建立双向的数据绑定(Data Binding)。这样Html控件的&#20540;改变会反应到Property上，反过来也同样成立。</span></p>
<p><span>AngularJs通过表达式的方式将数据绑定到HTML标签内。AngularJs的表达式写在双大括号内：{{expression}}</span></p>
<h3><span>3.2 模板</span></h3>
<p><span>在Asp.net MVC中提供了两种页面渲染模板，一种是Aspx，另一种是Razor.然而Asp.net MVC的这两种模板都是后端模板，即页面的渲染都是在服务端来完成的。这样不可避免会加重服务器端的压力。AngularJs的模板指的是前端模板。AngularJS有内置的前端模板引擎，即所有页面渲染的操作都是放在浏览器端来渲染的，这也是SPA程序的一个优势所在，所有前端框架都内置了前端模板引擎，将页面的渲染放在前端来做，从而减轻服务端的压力。</span></p>
<p><span>在AngularJs中的模板就是指带有ng-app指令的HTML代码。AngularJs发现Html页面是否需要用AngularJs模板引擎去渲染的标志就是ng-app标签。</span></p>
<p><span>在AngularJs中，<strong>我们写的其实也并不是纯的Html页面，而是模板，最终用户看到的Html页面（也就是视图）是通过模板渲染后的结果</strong>。</span></p>
<h3>3.3 控制器</h3>
<p><span>其实模板中的例子中，我们就已经定义了名为&quot;tempController&quot;的控制器了。接下来，我们再详细介绍下AngularJs中的控制器。其实AngularJs中控制器的作用与Asp.net MVC中控制器的作用是一样的，都是模型和视图之间的桥梁。而AngularJs的模型对象就是$scope。所以AngularJs控制器知识$scope和视图之间的桥梁，它通过操作$scope对象来改变视图。</span></p>
<h3>3.4 路由</h3>
<p><span>之所以说AngularJs框架=MVC&#43;MVVM，是因为AngularJs除了支持双向绑定外（即MVVM特点），还支持路由。在之前介绍的KnockoutJs实现的SPA中，其中路由借用了Asp.net MVC中路由机制。有了AngularJs之后，我们Web前端页面完全可以不用Asp.net MVC来做了，完全可以使用AngularJs框架来做。</span></p>
<p><span>单页Web应用由于没有后端URL资源定位的支持，需要自己实现URL资源定位。AngularJs使用浏览器URL&quot;#&quot;后的字符串来定位资源。路由机制并非在AngularJS核心文件内，你需要另外加入angular-route.min.js脚本。并且创建mainApp模块的时候需要添加对ngRoute的依赖。</span></p>
<h3>3.6 服务</h3>
<p><span>在上面的路由例子和自定义指令中都有用到AngularJs中的服务。我理解AngularJs的服务主要是封装请求数据的内容。就如.NET解决方案的层次结构中的Services层。然后AngularJs中的服务一个很重要的一点是：服务是单例的。一个服务在AngularJS应用中只会被注入实例化一次，并贯穿整个生命周期，与控制器进行通信。即控制器操作$scope对象来改变视图，如果控制器需要请求数据的话，则是调用服务来请求数据的，而服务获得数据可以通过Http服务(AngularJS内置的服务)来请求后端的Web
 API来获得所需要的数据。</span></p>
<p><span>AngularJS系统内置的服务以$开头，我们也可以自己定义一个服务。定义服务的方式有如下几种：</span></p>
<ul>
<li><span>使用系统内置的$provide服务</span> </li><li><span>使用Module的factory方法</span> </li><li><span>使用Module的service方法</span> </li></ul>
<h3>3.7 过滤器</h3>
<p>&nbsp;　　<span>AngularJs过滤器就是用来&#26684;式化数据的，包括排序，筛选、转化数据等操作。</span></p>
<ul>
</ul>
<h1>更多信息</h1>
<p><span>&nbsp;</span>&nbsp;<a href="http://www.runoob.com/angularjs/angularjs-tutorial.html" target="_blank">AngularJS&nbsp;<span class="color_h1">教程</span></a></p>
<p><span class="color_h1">&nbsp;<a href="http://docs.angularjs.cn/guide" target="_blank">AngularJs官网</a></span></p>
