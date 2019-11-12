
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/21/2011 11:00:21
-- Generated from EDMX file: C:\Contoso University\cs\ContosoUniversity\DAL\AlumniAssociationModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AlumniAssociation];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alumni'
CREATE TABLE [dbo].[Alumni] (
    [AlumnusId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Donations'
CREATE TABLE [dbo].[Donations] (
    [DonationId] int IDENTITY(1,1) NOT NULL,
    [DateAndAmount] nvarchar(max)  NOT NULL,
    [AlumnusAlumnusId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AlumnusId] in table 'Alumni'
ALTER TABLE [dbo].[Alumni]
ADD CONSTRAINT [PK_Alumni]
    PRIMARY KEY CLUSTERED ([AlumnusId] ASC);
GO

-- Creating primary key on [DonationId] in table 'Donations'
ALTER TABLE [dbo].[Donations]
ADD CONSTRAINT [PK_Donations]
    PRIMARY KEY CLUSTERED ([DonationId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlumnusAlumnusId] in table 'Donations'
ALTER TABLE [dbo].[Donations]
ADD CONSTRAINT [FK_AlumnusDonation]
    FOREIGN KEY ([AlumnusAlumnusId])
    REFERENCES [dbo].[Alumni]
        ([AlumnusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnusDonation'
CREATE INDEX [IX_FK_AlumnusDonation]
ON [dbo].[Donations]
    ([AlumnusAlumnusId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------