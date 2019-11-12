Install this below package for workign with EF
Go to Tools and then select  -> NuGet Package Manager -> Package Manager Console.You can see the Console at the bottom of the VS 2017 IDE and in right side of the combobox on the console select the default project as your shared project  Select Shared¡± 

Install-Package Microsoft.EntityFrameworkCore.SqlServer

Install-Package Microsoft.EntityFrameworkCore.Tools
 
Scaffold-DbContext "Server= YourServerName;Database=StudentsDB;user id= UserID;password=Password;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables StudentMasters