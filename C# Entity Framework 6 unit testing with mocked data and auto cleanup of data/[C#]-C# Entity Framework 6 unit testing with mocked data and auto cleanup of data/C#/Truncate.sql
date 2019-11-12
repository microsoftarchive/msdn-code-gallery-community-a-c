/*
	When done unit testing truncate the table
	You can check the last primary key via the SELECT below.

	I could had created SQL to detect if a truncate was need then perform
	it but I want you to do a check and then make the decision to do the
	truncation so no mistakes are made.
*/

SELECT CASE WHEN (SELECT COUNT(1) FROM dbo.Person) = 0 THEN 1 ELSE IDENT_CURRENT('dbo.Person') + 1 END AS Current_Identity
--TRUNCATE TABLE dbo.Person

SELECT CASE WHEN (SELECT COUNT(1) FROM dbo.Customers) = 0 THEN 1 ELSE IDENT_CURRENT('dbo.Customers') + 1 END AS Current_Identity
--TRUNCATE TABLE dbo.Customers
