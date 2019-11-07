# Angular 2 with MVC and WebApi and Entity Framework
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET Web API
- ASP.NET MVC 5
- Entity Framework 6
- Angular 2
## Topics
- ASP.NET MVC 5
- Angular2
## Updated
- 10/14/2017
## Description

<p><strong>Introduction</strong></p>
<p><em>A Visual Studio 2015 (Update 3) project which shows how to use the Angular 2 in an ASP.NET&nbsp;MVC 5 web application project and web api restful services, using the entity framewrok 6 Code First development approach.</em></p>
<p><strong>Building the Sample</strong></p>
<ul>
<li><em>Visual Studio 2015 Update 3</em> </li><li><em>NPM</em> </li><li><em>Node JS</em> </li><li><em>Entity Framework 6</em> </li><li><em>Local DB</em> </li></ul>
<p><strong>Description</strong></p>
<p>This solutions will explain the how Angular 2 integrated to MVC Web API project.&nbsp;<em>If you are experienced developer and only need an overview, you canjust download the attached project and go through it. You need Visual Studio and SQL Server Management
 Studio to develop the projectalong the article and compile the attached project.</em></p>
<p><strong>Develop Angular 2 Application</strong></p>
<p>Before actually writing the code, it is very important to understand the Angular 2 architechture, so please go throught angular.io website for free tutorials and free videos.</p>
<p>Still I am covering some of the basic conecept that I have used in this project.</p>
<p><strong>1. Modules:</strong>&nbsp;Every Angular app has at least one NgModule class,&nbsp;<a title="Bootstrapping" href="https://angular.io/guide/bootstrapping">the&nbsp;<em>root module</em></a>, conventionally named&nbsp;AppModule.While the&nbsp;<em>root
 module</em>&nbsp;may be the only module in a small application, most apps have many more&nbsp;<em>feature modules</em>, each a cohesive block of code dedicated to an application domain, a workflow, or a closely related set of capabilities.In AppModule we specify
 allcomponents, services or custom pipe filters used by application</p>
<p><strong>2.Components:&nbsp;</strong>A&nbsp;<em>component</em>&nbsp;controls a patch of screen called a&nbsp;<em>view</em>.</p>
<p><strong>3.&nbsp;Templates:&nbsp;</strong>You define a component's view with its companion&nbsp;template. A template is a form of HTML that tells Angular how to render the component.</p>
<p><strong>4.Metadata:&nbsp;</strong>Metadata tells Angular how to process a class.</p>
<p><strong>5.&nbsp;Data binding:&nbsp;</strong>Angular supports&nbsp;data binding, a mechanism for coordinating parts of a template with parts of a component. Add binding markup to the template HTML to tell Angular how to connect both sides.</p>
<p><strong>6.Directives:</strong>&nbsp;Angular templates are&nbsp;<em>dynamic</em>. When Angular renders them, it transforms the DOM according to the instructions given by&nbsp;directives.</p>
<p><strong>7.Services:&nbsp;</strong>Service is a broad category encompassing any value, function, or feature that your application needs. There isnothing specifically Angular2 about services. Angular2 has no definition of a service. There is no service base
 class, and noplace to register a service. Services example are Error, Log, HTTP etc. Component should only play the facilitator rolebetween template and user. It should delegate rest of functionality e.g. fetching data from server, deleting or updating,logging,
 showing error etc. to service.</p>
<p><strong>8.Dependency injection:&nbsp;</strong><em>Dependency injection</em>&nbsp;is a way to supply a new instance of a class with the fully-formed dependencies it requires. Most dependencies are services. Angular uses dependency injection to provide new
 components with the services they need.</p>
<p>To know more, take down the solution, build and go through the solution.&nbsp;</p>
<p>Before building the solution, update the packages by right clicking on the package.json file and upgrade the node modules. and then do test.</p>
