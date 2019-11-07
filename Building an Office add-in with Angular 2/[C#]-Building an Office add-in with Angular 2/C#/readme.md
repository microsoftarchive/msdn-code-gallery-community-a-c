###Building an Office add-in with Angular 2 sample

This is a sample project showing how to get started building Office [add-ins](http://dev.office.com/getting-started/addins) with Angular 2 and Office UI Fabric.
The sample add-in is a task pane add-in for Excel.


####Latest

This sample has been updated for Angular 2 RC5.

####Requirements

Tools:

* [Node.js](https://nodejs.org/en/)
* [Visual Studio 2015 Community or > update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2015-update3-vs)
* [Office Developer Tools](https://www.visualstudio.com/en-us/features/office-tools-vs.aspx)
* [TypeScript for Visual Studio 2015 latest version](https://www.microsoft.com/en-us/download/details.aspx?id=48593)

NPM Packages:

* [TypeScript](https://www.typescriptlang.org/#download-links)
* [Typings](https://github.com/typings/typings)

These need to be installed globally. The setup script will do this (see the installation section).

Also recommended are:

* [Node.js Tools for Visual Studio 2015](https://www.visualstudio.com/en-us/features/node-js-vs.aspx)
* [NPM Task Runner](https://visualstudiogallery.msdn.microsoft.com/8f2f2cbc-4da5-43ba-9de2-c9d08ade4941)
* [Open Command Line](https://visualstudiogallery.msdn.microsoft.com/4e84e2cf-2d6b-472a-b1e2-b84932511379)


Visual Studio is required to be able to debug the add-in any of the Office desktop applications. 
That said you can run this sample using the **lite-server** and use you preferred IDE to work with it.
You can then still use Office Online for in browser debugging (see below). 

####Installation

Download or clone the repo to its own folder. Open a command prompt under the ./OfficeAddInWithAngular2Web folder and run the command:

```bash
npm run setup
```

This will install all the required NPM package and typings. If you are using Visual Studio now open the solution and build it.

**SSL issues**

Office add-ins require HTTPS and browser errors when the localhost certificate is not trusted. Make sure that the certificate being used by **IIS Express**
 or **lite-server** is trusted. See [this post](https://blogs.msdn.microsoft.com/robert_mcmurray/2013/11/15/how-to-trust-the-iis-express-self-signed-certificate/) for more information.

####Running the add-in

#####...in Excel Online

Either run start the **OfficeAddInWithAngular2Web** project in VS or from the **OfficeAddInWithAngular2Web** directory run

```bash
npm start
```

Open up a new workbook in Excel Online. Click on the **INSERT** tab and then **Office Add-ins**. On the Office Add-ins dialog click **Upload my Add-In** and select 
**OfficeAddInWithAngular2/OfficeAddInWithAngular2Manifest/OfficeAddInWithAngular2.xml**. The add-in will now be available on the **HOME** tab. **F12** to debug the addin in browser. 

#####...in Excel desktop

In Visual Studio 2015 build the project and run it.

####Resources

This sample is more of a reference project for people who are already familiar with Office add-ins, Angular 2 and TypeScript than a tutorial
 so if you need to get up to speed with anything here are some good resources.

* [Angular 2](https://angular.io/docs/ts/latest/quickstart.html)
* [TypeScript](https://www.typescriptlang.org/docs/tutorial.html)
* [Office UI Fabric](http://dev.office.com/fabric/get-started)
* [Office Add-ins](https://dev.office.com/getting-started/addins)