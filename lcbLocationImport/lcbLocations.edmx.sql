
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/05/2013 08:58:21
-- Generated from EDMX file: C:\Users\Ted\documents\visual studio 2012\Projects\lcbLocationImport\lcbLocationImport\lcbLocations.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [hotelratescan_dev];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CountryRegion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[lcbRegions] DROP CONSTRAINT [FK_CountryRegion];
GO
IF OBJECT_ID(N'[dbo].[FK_lcbRegionlcbSubRegion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[lcbSubRegions] DROP CONSTRAINT [FK_lcbRegionlcbSubRegion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[lcbCountries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lcbCountries];
GO
IF OBJECT_ID(N'[dbo].[lcbRegions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lcbRegions];
GO
IF OBJECT_ID(N'[dbo].[lcbSubRegions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lcbSubRegions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'lcbCountries'
CREATE TABLE [dbo].[lcbCountries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [lcbcountry_id] int  NOT NULL,
    [lcbcountry_description] nvarchar(max)  NOT NULL,
    [last_updated] datetime  NOT NULL
);
GO

-- Creating table 'lcbRegions'
CREATE TABLE [dbo].[lcbRegions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [lcbregion_id] int  NOT NULL,
    [lcbregion_description] nvarchar(max)  NOT NULL,
    [last_updated] datetime  NOT NULL,
    [CountryId] int  NOT NULL
);
GO

-- Creating table 'lcbSubRegions'
CREATE TABLE [dbo].[lcbSubRegions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [lcbsubregion_id] int  NOT NULL,
    [lcbsubregion_description] nvarchar(max)  NOT NULL,
    [last_updated] datetime  NOT NULL,
    [lcbRegionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'lcbCountries'
ALTER TABLE [dbo].[lcbCountries]
ADD CONSTRAINT [PK_lcbCountries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'lcbRegions'
ALTER TABLE [dbo].[lcbRegions]
ADD CONSTRAINT [PK_lcbRegions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'lcbSubRegions'
ALTER TABLE [dbo].[lcbSubRegions]
ADD CONSTRAINT [PK_lcbSubRegions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CountryId] in table 'lcbRegions'
ALTER TABLE [dbo].[lcbRegions]
ADD CONSTRAINT [FK_CountryRegion]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[lcbCountries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryRegion'
CREATE INDEX [IX_FK_CountryRegion]
ON [dbo].[lcbRegions]
    ([CountryId]);
GO

-- Creating foreign key on [lcbRegionId] in table 'lcbSubRegions'
ALTER TABLE [dbo].[lcbSubRegions]
ADD CONSTRAINT [FK_lcbRegionlcbSubRegion]
    FOREIGN KEY ([lcbRegionId])
    REFERENCES [dbo].[lcbRegions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_lcbRegionlcbSubRegion'
CREATE INDEX [IX_FK_lcbRegionlcbSubRegion]
ON [dbo].[lcbSubRegions]
    ([lcbRegionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------