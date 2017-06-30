
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/29/2017 18:31:58
-- Generated from EDMX file: c:\users\ifct\documents\visual studio 2017\Projects\Actividad2_Azure_Khalifa_Boulbayem\Teams_EF_ModelFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Actividad2_BBDD_Khalifa_Boulbayem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StadiumTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_StadiumTeam];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[Stadiums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stadiums];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ChampionsLeagueNum] int  NOT NULL,
    [LeagueNum] int  NOT NULL,
    [Stadium_Id] int  NOT NULL
);
GO

-- Creating table 'Stadiums'
CREATE TABLE [dbo].[Stadiums] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Capacity] int  NOT NULL,
    [City] nvarchar(75)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stadiums'
ALTER TABLE [dbo].[Stadiums]
ADD CONSTRAINT [PK_Stadiums]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Stadium_Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_StadiumTeam]
    FOREIGN KEY ([Stadium_Id])
    REFERENCES [dbo].[Stadiums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StadiumTeam'
CREATE INDEX [IX_FK_StadiumTeam]
ON [dbo].[Teams]
    ([Stadium_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------