# CRM to Go - Sample app for Dynamics CRM
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Web Services
- OData
- Dynamics CRM
- SOAP
- Active Directory Authentication Library
## Topics
- Authentication
- Windows Phone 8.1
- Dynamics CRM web services
## Updated
- 05/20/2015
## Description

<ul>
<li><a href="#overview">Overview</a> </li><li><a href="#prereq">Prerequisites</a> </li><li><a href="#moreinfo">More Information</a> </li><li><a href="#copyright">Copyright</a> </li></ul>
<h1 id="overview">Overview</h1>
<p>This sample is an advanced full-featured app that can access Microsoft Dynamics CRM business data through the organization web service. The app supports both built-in (system) and custom entities, provides full CRUD (Create, Retrieve, Update, Delete) functionality,
 and includes search, email, and multi-language capabilities. The sample works with both Microsoft Dynamics CRM Online and 2013/2015 IFD (on-premises) deployments.</p>
<p>Use this sample to learn how to write an advanced app with Dynamics CRM access, or just build and run the app on your Windows 8 phone device for easy access to your CRM business data.</p>
<h1 id="prereq">Prerequisites</h1>
<p>To use this sample, you need to have:</p>
<ul>
<li>Windows 8.1 (x86) or a later revision </li><li>For the Windows Phone emulators, Windows 8.1 (x64) Professional or Enterprise edition, and a processor that supports Client Hyper-V and Second Level Address Translation (SLAT)
</li><li>Visual Studio 2013 Update 2 or later </li><li><a href="http://dev.windows.com/en-us/develop/multilingual-app-toolkit" target="_blank">Multilingual App Toolkit</a>
</li><li>Network access to a Dynamics CRM Online or IFD organization </li><li>A Microsoft Azure account for app registration (CRM Online only) </li></ul>
<h1 id="moreinfo">More Information</h1>
<p>Refer to the Readme.docx file for information on building and registering the app plus some details on the implementation.</p>
<p>The <a href="https://code.msdn.microsoft.com/CRM-Service-Utility-for-4ca0c93b" target="_blank">
CRM Service Utility for Mobile Development</a> tool provided the early-bound entity types used in this sample and the
<a href="https://code.msdn.microsoft.com/Mobile-Development-Helper-3213e2e6" target="_blank">
Mobile Development Helper Code for Dynamics CRM</a> provides the OData and SOAP web service messaging. Microsoft Azure
<a href="https://github.com/AzureAD/azure-activedirectory-library-for-dotnet" target="_blank">
Active Directory Authentication Library</a> (ADAL) is used to manage OAuth authentication to the web service.</p>
<p>For more information on Dynamics CRM authentication and app development, see <a href="http://msdn.microsoft.com/en-us/library/dn481568.aspx">
Write mobile and modern apps</a>.</p>
<p>You can find iOS and Android versions of a more basic sample application, named Activity Tracker, on GitHub under the organization named
<a href="https://github.com/dynamicscrm" target="_blank">DynamicsCRM</a>. A Windows 8 version of that same app can be found under the
<a href="https://code.msdn.microsoft.com/Activity-Tracker-Sample-c8da7a1e" target="_blank">
ActivityTracker</a> sample app for Dynamics CRM.</p>
<h1 id="copyright">Copyright</h1>
<p>This document is provided &quot;as-is&quot;. Information and views expressed in this document, including URL and other Internet Web site references, may change without notice.</p>
<p>Some examples depicted herein are provided for illustration only and are fictitious. No real association or connection is intended or should be inferred.</p>
<p>This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.</p>
<p>&copy; 2015 Microsoft Corporation. All rights reserved.</p>
<p>Microsoft, Active Directory, IntelliSense, Microsoft Dynamics, Visual Studio, and Windows are trademarks of the Microsoft group of companies.</p>
<p>All other trademarks are property of their respective owners.</p>
