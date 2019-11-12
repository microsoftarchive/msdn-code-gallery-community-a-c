
SET QUOTED_IDENTIFIER OFF;
GO
USE [MVCDemo];
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

-- Creating table 'CarSet'
CREATE TABLE [dbo].[CarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ModelSet'
CREATE TABLE [dbo].[ModelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CarId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [PK_CarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ModelSet'
ALTER TABLE [dbo].[ModelSet]
ADD CONSTRAINT [PK_ModelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarId] in table 'ModelSet'
ALTER TABLE [dbo].[ModelSet]
ADD CONSTRAINT [FK_CarModel]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[CarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarModel'
CREATE INDEX [IX_FK_CarModel]
ON [dbo].[ModelSet]
    ([CarId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------