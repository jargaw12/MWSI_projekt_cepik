
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/09/2017 20:25:08
-- Generated from EDMX file: C:\Users\Jaroslaw\Source\Repos\mwsiApp\mwsiApp\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [proba1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Model_S_Marka_S_id_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Model_S] DROP CONSTRAINT [FK_Model_S_Marka_S_id_fk];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Marka_S]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marka_S];
GO
IF OBJECT_ID(N'[dbo].[Model_S]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Model_S];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Marka_S'
CREATE TABLE [dbo].[Marka_S] (
    [id] int IDENTITY(1,1) NOT NULL,
    [marka] varchar(30)  NOT NULL
);
GO

-- Creating table 'Model_S'
CREATE TABLE [dbo].[Model_S] (
    [id] int IDENTITY(1,1) NOT NULL,
    [marka_id] int  NOT NULL,
    [model] varchar(30)  NOT NULL
);
GO

-- Creating table 'Osobas'
CREATE TABLE [dbo].[Osobas] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Osobas_Uzytkownik'
CREATE TABLE [dbo].[Osobas_Uzytkownik] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Osobas_Policjant'
CREATE TABLE [dbo].[Osobas_Policjant] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Osobas_Pracownik'
CREATE TABLE [dbo].[Osobas_Pracownik] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Marka_S'
ALTER TABLE [dbo].[Marka_S]
ADD CONSTRAINT [PK_Marka_S]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Model_S'
ALTER TABLE [dbo].[Model_S]
ADD CONSTRAINT [PK_Model_S]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Osobas'
ALTER TABLE [dbo].[Osobas]
ADD CONSTRAINT [PK_Osobas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Osobas_Uzytkownik'
ALTER TABLE [dbo].[Osobas_Uzytkownik]
ADD CONSTRAINT [PK_Osobas_Uzytkownik]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Osobas_Policjant'
ALTER TABLE [dbo].[Osobas_Policjant]
ADD CONSTRAINT [PK_Osobas_Policjant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Osobas_Pracownik'
ALTER TABLE [dbo].[Osobas_Pracownik]
ADD CONSTRAINT [PK_Osobas_Pracownik]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [marka_id] in table 'Model_S'
ALTER TABLE [dbo].[Model_S]
ADD CONSTRAINT [FK_Model_S_Marka_S_id_fk]
    FOREIGN KEY ([marka_id])
    REFERENCES [dbo].[Marka_S]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Model_S_Marka_S_id_fk'
CREATE INDEX [IX_FK_Model_S_Marka_S_id_fk]
ON [dbo].[Model_S]
    ([marka_id]);
GO

-- Creating foreign key on [Id] in table 'Osobas_Uzytkownik'
ALTER TABLE [dbo].[Osobas_Uzytkownik]
ADD CONSTRAINT [FK_Uzytkownik_inherits_Osoba]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Osobas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Osobas_Policjant'
ALTER TABLE [dbo].[Osobas_Policjant]
ADD CONSTRAINT [FK_Policjant_inherits_Osoba]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Osobas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Osobas_Pracownik'
ALTER TABLE [dbo].[Osobas_Pracownik]
ADD CONSTRAINT [FK_Pracownik_inherits_Osoba]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Osobas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------