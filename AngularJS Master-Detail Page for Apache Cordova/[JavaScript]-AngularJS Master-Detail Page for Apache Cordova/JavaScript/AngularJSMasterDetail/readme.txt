***
.jsproj file includes a Powershell script refernce to download AngularJS library.
You must build the app to install AngularJS.
***

Build and Run the app

1. After downloading the .zip, rename the .zip to remove spaces in the filename, and move the .zip to a folder that does not contain spaces (this resolves a Cordova issues with spaces in the path name for Windows build targets). 
2. Extract the .zip files. 
3. In Visual Studio, open the solution file (.sln) for the project. 
4. The first time you build the app in VS, a PowerShell script referenced in the .jsproj project file will download the required AngularJS library files. 

   Note: If the framework files (in /scripts/frameworks/) do not download, you will need to
   unblock the PowerShell script from running. For more info, see this post 
   (http://stackoverflow.com/questions/24410962/winjs-sample-code-js-file-missing). 

5. For more info on using the Multi-Device Hybrid Apps extension, see Getting Started with Multi-Device Hybrid Apps (http://msdn.microsoft.com/library/dn771545.aspx). 

