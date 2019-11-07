--
-- Run this script to create the database, Customers table.
-- Currently setup for a name instance so if using SQLEXPRESS or local you may need to alter the script for the CREATE DATABASE part.
--
USE [master]
GO
CREATE DATABASE [BindingSourceFiltering]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BindingSourceFiltering', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BindingSourceFiltering.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BindingSourceFiltering_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BindingSourceFiltering_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BindingSourceFiltering] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BindingSourceFiltering].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BindingSourceFiltering] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET ARITHABORT OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BindingSourceFiltering] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BindingSourceFiltering] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BindingSourceFiltering] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BindingSourceFiltering] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BindingSourceFiltering] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET RECOVERY FULL 
GO
ALTER DATABASE [BindingSourceFiltering] SET  MULTI_USER 
GO
ALTER DATABASE [BindingSourceFiltering] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BindingSourceFiltering] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BindingSourceFiltering] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BindingSourceFiltering] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BindingSourceFiltering]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/8/2017 5:20:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerIdentifier] [int] NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[City] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (1, N'Alfreds Futterkiste', N'Maria Anders', N'Sales Representative', N'Berlin', N'12209', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (2, N'Ana Trujillo Emparedados y helados', N'Ana Trujillo', N'Owner', N'México D.F.', N'05021', N'Mexico')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (3, N'Antonio Moreno Taquería', N'Antonio Moreno', N'Owner', N'México D.F.', N'05023', N'Mexico')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (4, N'Around the Horn', N'Thomas Hardy', N'Sales Representative', N'London', N'WA1 1DP', N'UK')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (5, N'Berglunds snabbköp', N'Christina Berglund', N'Order Administrator', N'Luleå', N'S-958 22', N'Sweden')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (6, N'Blauer See Delikatessen', N'Hanna Moos', N'Sales Representative', N'Mannheim', N'68306', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (7, N'Blondesddsl père et fils', N'Frédérique Citeaux', N'Marketing Manager', N'Strasbourg', N'67000', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (8, N'Bólido Comidas preparadas', N'Martín Sommer', N'Owner', N'Madrid', N'28023', N'Spain')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (9, N'Bon app''', N'Laurence Lebihan', N'Owner', N'Marseille', N'13008', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (10, N'B''s Beverages', N'Victoria Ashworth', N'Sales Representative', N'London', N'EC2 5NT', N'UK')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (11, N'Cactus Comidas para llevar', N'Patricio Simpson', N'Sales Agent', N'Buenos Aires', N'1010', N'Argentina')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (12, N'Centro comercial Moctezuma', N'Francisco Chang', N'Marketing Manager', N'México D.F.', N'05022', N'Mexico')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (13, N'Chop-suey Chinese', N'Yang Wang', N'Owner', N'Bern', N'3012', N'Switzerland')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (14, N'Consolidated Holdings', N'Elizabeth Brown', N'Sales Representative', N'London', N'WX1 6LT', N'UK')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (15, N'Drachenblut Delikatessen', N'Sven Ottlieb', N'Order Administrator', N'Aachen', N'52066', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (16, N'Du monde entier', N'Janine Labrune', N'Owner', N'Nantes', N'44000', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (17, N'Eastern Connection', N'Ann Devon', N'Sales Agent', N'London', N'WX3 6FW', N'UK')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (18, N'Ernst Handel', N'Roland Mendel', N'Sales Manager', N'Graz', N'8010', N'Austria')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (19, N'FISSA Fabrica Inter. Salchichas S.A.', N'Diego Roel', N'Accounting Manager', N'Madrid', N'28034', N'Spain')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (20, N'Folies gourmandes', N'Martine Rancé', N'Assistant Sales Agent', N'Lille', N'59000', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (21, N'Folk och fä HB', N'Maria Larsson', N'Owner', N'Bräcke', N'S-844 67', N'Sweden')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (22, N'Frankenversand', N'Peter Franken', N'Marketing Manager', N'München', N'80805', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (23, N'France restauration', N'Carine Schmitt', N'Marketing Manager', N'Nantes', N'44000', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (24, N'Franchi S.p.A.', N'Paolo Accorti', N'Sales Representative', N'Torino', N'10100', N'Italy')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (25, N'Furia Bacalhau e Frutos do Mar', N'Lino Rodriguez', N'Sales Manager', N'Lisboa', N'1675', N'Portugal')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (26, N'Galería del gastrónomo', N'Eduardo Saavedra', N'Marketing Manager', N'Barcelona', N'08022', N'Spain')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (27, N'Godos Cocina Típica', N'José Pedro Freyre', N'Sales Manager', N'Sevilla', N'41101', N'Spain')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (28, N'Königlich Essen', N'Philip Cramer', N'Sales Associate', N'Brandenburg', N'14776', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (29, N'La corne d''abondance', N'Daniel Tonini', N'Sales Representative', N'Versailles', N'78000', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (30, N'La maison d''Asie', N'Annette Roulet', N'Sales Manager', N'Toulouse', N'31000', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (31, N'Lehmanns Marktstand', N'Renate Messner', N'Sales Representative', N'Frankfurt a.M.', N'60528', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (32, N'Magazzini Alimentari Riuniti', N'Giovanni Rovelli', N'Marketing Manager', N'Bergamo', N'24100', N'Italy')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (33, N'Maison Dewey', N'Catherine Dewey', N'Sales Agent', N'Bruxelles', N'B-1180', N'Belgium')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (34, N'Morgenstern Gesundkost', N'Alexander Feuer', N'Marketing Assistant', N'Leipzig', N'04179', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (35, N'North/South', N'Simon Crowther', N'Sales Associate', N'London', N'SW7 1RZ', N'UK')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (36, N'Océano Atlántico Ltda.', N'Yvonne Moncada', N'Sales Agent', N'Buenos Aires', N'1010', N'Argentina')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (37, N'Ottilies Käseladen', N'Henriette Pfalzheim', N'Owner', N'Köln', N'50739', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (38, N'Paris spécialités', N'Marie Bertrand', N'Owner', N'Paris', N'75012', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (39, N'Pericles Comidas clásicas', N'Guillermo Fernández', N'Sales Representative', N'México D.F.', N'05033', N'Mexico')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (40, N'Piccolo und mehr', N'Georg Pipps', N'Sales Manager', N'Salzburg', N'5020', N'Austria')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (41, N'Princesa Isabel Vinhos', N'Isabel de Castro', N'Sales Representative', N'Lisboa', N'1756', N'Portugal')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (42, N'QUICK Stop', N'Horst Kloss', N'Accounting Manager', N'Cunewalde', N'01307', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (43, N'Rancho grande', N'Sergio Gutiérrez', N'Sales Representative', N'Buenos Aires', N'1010', N'Argentina')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (44, N'Reggiani Caseifici', N'Maurizio Moroni', N'Sales Associate', N'Reggio Emilia', N'42100', N'Italy')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (45, N'Richter Supermarkt', N'Michael Holz', N'Sales Manager', N'Genève', N'1203', N'Switzerland')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (46, N'Romero y tomillo', N'Alejandra Camino', N'Accounting Manager', N'Madrid', N'28001', N'Spain')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (47, N'Santé Gourmet', N'Jonas Bergulfsen', N'Owner', N'Stavern', N'4110', N'Norway')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (48, N'Seven Seas Imports', N'Hari Kumar', N'Sales Manager', N'London', N'OX15 4NB', N'UK')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (49, N'Simons bistro', N'Jytte Petersen', N'Owner', N'Kobenhavn', N'1734', N'Denmark')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (50, N'Spécialités du monde', N'Dominique Perrier', N'Marketing Manager', N'Paris', N'75016', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (51, N'Suprêmes délices', N'Pascale Cartrain', N'Accounting Manager', N'Charleroi', N'B-6000', N'Belgium')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (52, N'Toms Spezialitäten', N'Karin Josephs', N'Marketing Manager', N'Münster', N'44087', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (53, N'Tortuga Restaurante', N'Miguel Angel Paolino', N'Owner', N'México D.F.', N'05033', N'Mexico')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (54, N'Vaffeljernet', N'Palle Ibsen', N'Sales Manager', N'Århus', N'8200', N'Denmark')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (55, N'Victuailles en stock', N'Mary Saveley', N'Sales Agent', N'Lyon', N'69004', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (56, N'Vins et alcools Chevalier', N'Paul Henriot', N'Accounting Manager', N'Reims', N'51100', N'France')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (57, N'Die Wandernde Kuh', N'Rita Müller', N'Sales Representative', N'Stuttgart', N'70563', N'Germany')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (58, N'Wartian Herkku', N'Pirkko Koskitalo', N'Accounting Manager', N'Oulu', N'90110', N'Finland')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (59, N'Wilman Kala', N'Matti Karttunen', N'Owner/Marketing Assistant', N'Helsinki', N'21240', N'Finland')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (60, N'Wolski  Zajazd', N'Zbyszek Piestrzeniewicz', N'Owner', N'Warszawa', N'01-012', N'Poland')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (61, N'Old World Delicatessen', N'Rene Phillips', N'Sales Representative', N'Anchorage', N'99508', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (62, N'Bottom-Dollar Markets', N'Elizabeth Lincoln', N'Accounting Manager', N'Tsawassen', N'T2F 8M4', N'Canada')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (63, N'Laughing Bacchus Wine Cellars', N'Yoshi Tannamuri', N'Marketing Assistant', N'Vancouver', N'V3F 2K1', N'Canada')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (64, N'Let''s Stop N Shop', N'Jaime Yorres', N'Owner', N'San Francisco', N'94117', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (65, N'Hungry Owl All-Night Grocers', N'Patricia McKenna', N'Sales Associate', N'Cork', NULL, N'Ireland')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (66, N'GROSELLA-Restaurante', N'Manuel Pereira', N'Owner', N'Caracas', N'1081', N'Venezuela')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (67, N'Save-a-lot Markets', N'Jose Pavarotti', N'Sales Representative', N'Boise', N'83720', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (68, N'Island Trading', N'Helen Bennett', N'Marketing Manager', N'Cowes', N'PO31 7PJ', N'UK')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (69, N'LILA-Supermercado', N'Carlos González', N'Accounting Manager', N'Barquisimeto', N'3508', N'Venezuela')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (70, N'The Cracker Box', N'Liu Wong', N'Marketing Assistant', N'Butte', N'59801', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (71, N'Rattlesnake Canyon Grocery', N'Paula Wilson', N'Assistant Sales Representative', N'Albuquerque', N'87110', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (72, N'LINO-Delicateses', N'Felipe Izquierdo', N'Owner', N'I. de Margarita', N'4980', N'Venezuela')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (73, N'Great Lakes Food Market', N'Howard Snyder', N'Marketing Manager', N'Eugene', N'97403', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (74, N'Hungry Coyote Import Store', N'Yoshi Latimer', N'Sales Representative', N'Elgin', N'97827', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (75, N'Lonesome Pine Restaurant', N'Fran Wilson', N'Sales Manager', N'Portland', N'97219', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (76, N'The Big Cheese', N'Liz Nixon', N'Marketing Manager', N'Portland', N'97201', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (77, N'Mère Paillarde', N'Jean Fresnière', N'Marketing Assistant', N'Montréal', N'H1J 1C3', N'Canada')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (78, N'Hanari Carnes', N'Mario Pontes', N'Accounting Manager', N'Rio de Janeiro', N'05454-876', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (79, N'Que Delícia', N'Bernardo Batista', N'Accounting Manager', N'Rio de Janeiro', N'02389-673', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (80, N'Ricardo Adocicados', N'Janete Limeira', N'Assistant Sales Agent', N'Rio de Janeiro', N'02389-890', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (81, N'Comércio Mineiro', N'Pedro Afonso', N'Sales Associate', N'Sao Paulo', N'05432-043', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (82, N'Familia Arquibaldo', N'Aria Cruz', N'Marketing Assistant', N'Sao Paulo', N'05442-030', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (83, N'Gourmet Lanchonetes', N'André Fonseca', N'Sales Associate', N'Campinas', N'04876-786', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (84, N'Queen Cozinha', N'Lúcia Carvalho', N'Marketing Assistant', N'Sao Paulo', N'05487-020', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (85, N'Tradição Hipermercados', N'Anabela Domingues', N'Sales Representative', N'Sao Paulo', N'05634-030', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (86, N'Wellington Importadora', N'Paula Parente', N'Sales Manager', N'Resende', N'08737-363', N'Brazil')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (87, N'HILARION-Abastos', N'Carlos Hernández', N'Sales Representative', N'San Cristóbal', N'5022', N'Venezuela')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (88, N'Lazy K Kountry Store', N'John Steel', N'Marketing Manager', N'Walla Walla', N'99362', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (89, N'Trail''s Head Gourmet Provisioners', N'Helvetius Nagy', N'Sales Associate', N'Kirkland', N'98034', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (90, N'White Clover Markets', N'Karl Jablonski', N'Owner', N'Seattle', N'98128', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (91, N'Split Rail Beer & Ale', N'Art Braunschweiger', N'Sales Manager', N'Lander', N'82520', N'USA')
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (92, N'Karen''s auto detailing', N'Karen Payne', N'Owner', NULL, NULL, NULL)
GO
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactName], [ContactTitle], [City], [PostalCode], [Country]) VALUES (94, N'Karen''s auto shop', N'Karen Payne', N'Owner', NULL, NULL, NULL)
GO
USE [master]
GO
ALTER DATABASE [BindingSourceFiltering] SET  READ_WRITE 
GO
