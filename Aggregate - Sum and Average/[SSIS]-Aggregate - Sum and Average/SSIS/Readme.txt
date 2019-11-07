Purpose
=======
This sample demonstrates how to use the Aggregate transform. In this example we have a package
that uses an Aggregate transform to calculate the total sales quantity and average unit price
for each product. The GroupBy column is the productID.

Before running the package
==========================

External dependencies
---------------------
This sample assumes that:
- You have already downloaded and attached to a local, default instance of SQL Server the
AdventureWorks sample database from codeplex.com.
- The SQL Server instance hosting the AdventureWorks database uses Windows Authentication, and
your user account has access to the AdventureWorks database.
- You have attached the database with the name, "AdventureWorks". If the instance of the
AdventureWorks sample database you want to use is attached to another instance and/or the name
of the database as attached is not "AdventureWorks" edit the AdventureWorks connection manager.