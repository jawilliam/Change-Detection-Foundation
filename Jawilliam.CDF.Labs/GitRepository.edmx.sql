
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2017 09:07:29
-- Generated from EDMX file: E:\MyRepositories\Change-Detection-Foundation\Jawilliam.CDF.Labs\GitRepository.edmx
-- --------------------------------------------------
USE [master]
GO

/****** Object:  Database [XxXxYyYy]    Script Date: 11/05/2017 17:06:50 ******/
CREATE DATABASE [XxXxYyYy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XxXxYyYy', FILENAME = N'E:\DBs\XxXxYyYy.mdf' , SIZE = 2312192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'XxXxYyYy_log', FILENAME = N'E:\DBs\XxXxYyYy_log.ldf' , SIZE = 268288KB , MAXSIZE = 2048GB , FILEGROWTH = 10240KB )
GO

ALTER DATABASE [XxXxYyYy] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XxXxYyYy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [XxXxYyYy] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [XxXxYyYy] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [XxXxYyYy] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [XxXxYyYy] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [XxXxYyYy] SET ARITHABORT OFF 
GO

ALTER DATABASE [XxXxYyYy] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [XxXxYyYy] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [XxXxYyYy] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [XxXxYyYy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [XxXxYyYy] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [XxXxYyYy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [XxXxYyYy] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [XxXxYyYy] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [XxXxYyYy] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [XxXxYyYy] SET  DISABLE_BROKER 
GO

ALTER DATABASE [XxXxYyYy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [XxXxYyYy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [XxXxYyYy] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [XxXxYyYy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [XxXxYyYy] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [XxXxYyYy] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [XxXxYyYy] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [XxXxYyYy] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [XxXxYyYy] SET  MULTI_USER 
GO

ALTER DATABASE [XxXxYyYy] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [XxXxYyYy] SET DB_CHAINING OFF 
GO

ALTER DATABASE [XxXxYyYy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [XxXxYyYy] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [XxXxYyYy] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [XxXxYyYy] SET  READ_WRITE 
GO

SET QUOTED_IDENTIFIER OFF;
GO
USE [XxXxYyYy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Contributor_IsAuthorOf_Commits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_Commit] DROP CONSTRAINT [FK_Contributor_IsAuthorOf_Commits];
GO
IF OBJECT_ID(N'[dbo].[FK_Branch_PointTo_OneCommit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_Branch] DROP CONSTRAINT [FK_Branch_PointTo_OneCommit];
GO
IF OBJECT_ID(N'[dbo].[FK_Branch_Contains_Commits_Commit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Branch_Contains_Commits] DROP CONSTRAINT [FK_Branch_Contains_Commits_Commit];
GO
IF OBJECT_ID(N'[dbo].[FK_Branch_Contains_Commits_Branch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Branch_Contains_Commits] DROP CONSTRAINT [FK_Branch_Contains_Commits_Branch];
GO
IF OBJECT_ID(N'[dbo].[FK_Commits_AreParentsOf_Commits_Commit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Commits_AreParentsOf_Commits] DROP CONSTRAINT [FK_Commits_AreParentsOf_Commits_Commit];
GO
IF OBJECT_ID(N'[dbo].[FK_Commits_AreParentsOf_Commits_Commit1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Commits_AreParentsOf_Commits] DROP CONSTRAINT [FK_Commits_AreParentsOf_Commits_Commit1];
GO
IF OBJECT_ID(N'[dbo].[FK_OneFileVersion_HasExactly_OneFileContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContents] DROP CONSTRAINT [FK_OneFileVersion_HasExactly_OneFileContent];
GO
IF OBJECT_ID(N'[dbo].[FK_OneFile_HasMany_Versions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileVersion] DROP CONSTRAINT [FK_OneFile_HasMany_Versions];
GO
IF OBJECT_ID(N'[dbo].[FK_FileChange_DifferencingTo_Commit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileChange] DROP CONSTRAINT [FK_FileChange_DifferencingTo_Commit];
GO
IF OBJECT_ID(N'[dbo].[FK_FileChange_DifferencingFrom_Commit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileChange] DROP CONSTRAINT [FK_FileChange_DifferencingFrom_Commit];
GO
IF OBJECT_ID(N'[dbo].[FK_FileChanges_Originate_ManyFileVersions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileChange] DROP CONSTRAINT [FK_FileChanges_Originate_ManyFileVersions];
GO
IF OBJECT_ID(N'[dbo].[FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileModifiedChange] DROP CONSTRAINT [FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges];
GO
IF OBJECT_ID(N'[dbo].[FK_OneFileVersion_HasExactly_OneFileContentSummary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContentSummaries] DROP CONSTRAINT [FK_OneFileVersion_HasExactly_OneFileContentSummary];
GO
IF OBJECT_ID(N'[dbo].[FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Deltas] DROP CONSTRAINT [FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas];
GO
IF OBJECT_ID(N'[dbo].[FK_Commit_inherits_RepositoryObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_Commit] DROP CONSTRAINT [FK_Commit_inherits_RepositoryObject];
GO
IF OBJECT_ID(N'[dbo].[FK_Contributor_inherits_RepositoryObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_Contributor] DROP CONSTRAINT [FK_Contributor_inherits_RepositoryObject];
GO
IF OBJECT_ID(N'[dbo].[FK_Branch_inherits_RepositoryObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_Branch] DROP CONSTRAINT [FK_Branch_inherits_RepositoryObject];
GO
IF OBJECT_ID(N'[dbo].[FK_FileVersion_inherits_RepositoryObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileVersion] DROP CONSTRAINT [FK_FileVersion_inherits_RepositoryObject];
GO
IF OBJECT_ID(N'[dbo].[FK_File_inherits_RepositoryObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_File] DROP CONSTRAINT [FK_File_inherits_RepositoryObject];
GO
IF OBJECT_ID(N'[dbo].[FK_FileChange_inherits_RepositoryObject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileChange] DROP CONSTRAINT [FK_FileChange_inherits_RepositoryObject];
GO
IF OBJECT_ID(N'[dbo].[FK_FileModifiedChange_inherits_FileChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileModifiedChange] DROP CONSTRAINT [FK_FileModifiedChange_inherits_FileChange];
GO
IF OBJECT_ID(N'[dbo].[FK_FileAddedChange_inherits_FileChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileAddedChange] DROP CONSTRAINT [FK_FileAddedChange_inherits_FileChange];
GO
IF OBJECT_ID(N'[dbo].[FK_FileDeletedChange_inherits_FileChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileDeletedChange] DROP CONSTRAINT [FK_FileDeletedChange_inherits_FileChange];
GO
IF OBJECT_ID(N'[dbo].[FK_FileRenamedChange_inherits_FileModifiedChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileRenamedChange] DROP CONSTRAINT [FK_FileRenamedChange_inherits_FileModifiedChange];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RepositoryObjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects];
GO
IF OBJECT_ID(N'[dbo].[FileContents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileContents];
GO
IF OBJECT_ID(N'[dbo].[FileContentSummaries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileContentSummaries];
GO
IF OBJECT_ID(N'[dbo].[Deltas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Deltas];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_Commit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_Commit];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_Contributor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_Contributor];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_Branch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_Branch];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_FileVersion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_FileVersion];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_File]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_File];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_FileChange]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_FileChange];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_FileModifiedChange]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_FileModifiedChange];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_FileAddedChange]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_FileAddedChange];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_FileDeletedChange]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_FileDeletedChange];
GO
IF OBJECT_ID(N'[dbo].[RepositoryObjects_FileRenamedChange]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepositoryObjects_FileRenamedChange];
GO
IF OBJECT_ID(N'[dbo].[Branch_Contains_Commits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branch_Contains_Commits];
GO
IF OBJECT_ID(N'[dbo].[Commits_AreParentsOf_Commits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Commits_AreParentsOf_Commits];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RepositoryObjects'
CREATE TABLE [dbo].[RepositoryObjects] (
    [Id] uniqueidentifier  NOT NULL,
    [ExternalID] nvarchar(max)  NULL,
    [Annotations] xml  NULL
);
GO

-- Creating table 'FileContents'
CREATE TABLE [dbo].[FileContents] (
    [Id] uniqueidentifier  NOT NULL,
    [SourceCode] nvarchar(max)  NULL,
    [Annotations] xml  NULL,
    [FileVersion_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'FileContentSummaries'
CREATE TABLE [dbo].[FileContentSummaries] (
    [Id] uniqueidentifier  NOT NULL,
    [Size] bigint  NOT NULL,
    [TotalLines] bigint  NULL,
    [BlankLines] bigint  NULL,
    [CommentLines] bigint  NULL,
    [CodeLines] bigint  NULL,
    [StatementLines] bigint  NULL,
    [SyntaxKindAnnotations] xml  NULL,
    [Annotations] xml  NULL,
    [FileVersion_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Deltas'
CREATE TABLE [dbo].[Deltas] (
    [Id] uniqueidentifier  NOT NULL,
    [Matching] xml  NULL,
    [Differencing] xml  NULL,
    [Report] xml  NULL,
    [Annotations] xml  NULL,
    [Approach] int  NOT NULL,
    [RevisionPair_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'RepositoryObjects_Commit'
CREATE TABLE [dbo].[RepositoryObjects_Commit] (
    [Date] datetimeoffset  NOT NULL,
    [Message] nvarchar(max)  NULL,
    [Index] int  NOT NULL,
    [Id] uniqueidentifier  NOT NULL,
    [Committer_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_Contributor'
CREATE TABLE [dbo].[RepositoryObjects_Contributor] (
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_Branch'
CREATE TABLE [dbo].[RepositoryObjects_Branch] (
    [FullName] nvarchar(max)  NOT NULL,
    [IsRemote] bit  NOT NULL,
    [Id] uniqueidentifier  NOT NULL,
    [Tip_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_FileVersion'
CREATE TABLE [dbo].[RepositoryObjects_FileVersion] (
    [Path] nvarchar(max)  NOT NULL,
    [Id] uniqueidentifier  NOT NULL,
    [File_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'RepositoryObjects_File'
CREATE TABLE [dbo].[RepositoryObjects_File] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_FileChange'
CREATE TABLE [dbo].[RepositoryObjects_FileChange] (
    [LinesAdded] int  NOT NULL,
    [LinesDeleted] int  NOT NULL,
    [Patch] nvarchar(max)  NULL,
    [Id] uniqueidentifier  NOT NULL,
    [ToCommit_Id] uniqueidentifier  NOT NULL,
    [FromCommit_Id] uniqueidentifier  NULL,
    [FileVersion_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_FileModifiedChange'
CREATE TABLE [dbo].[RepositoryObjects_FileModifiedChange] (
    [ToPath] nvarchar(max)  NOT NULL,
    [Id] uniqueidentifier  NOT NULL,
    [FromFileVersion_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_FileAddedChange'
CREATE TABLE [dbo].[RepositoryObjects_FileAddedChange] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_FileDeletedChange'
CREATE TABLE [dbo].[RepositoryObjects_FileDeletedChange] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RepositoryObjects_FileRenamedChange'
CREATE TABLE [dbo].[RepositoryObjects_FileRenamedChange] (
    [FromPath] nvarchar(max)  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Branch_Contains_Commits'
CREATE TABLE [dbo].[Branch_Contains_Commits] (
    [Commits_Id] uniqueidentifier  NOT NULL,
    [Branches_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Commits_AreParentsOf_Commits'
CREATE TABLE [dbo].[Commits_AreParentsOf_Commits] (
    [Childs_Id] uniqueidentifier  NOT NULL,
    [Parents_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RepositoryObjects'
ALTER TABLE [dbo].[RepositoryObjects]
ADD CONSTRAINT [PK_RepositoryObjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FileContents'
ALTER TABLE [dbo].[FileContents]
ADD CONSTRAINT [PK_FileContents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FileContentSummaries'
ALTER TABLE [dbo].[FileContentSummaries]
ADD CONSTRAINT [PK_FileContentSummaries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Deltas'
ALTER TABLE [dbo].[Deltas]
ADD CONSTRAINT [PK_Deltas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_Commit'
ALTER TABLE [dbo].[RepositoryObjects_Commit]
ADD CONSTRAINT [PK_RepositoryObjects_Commit]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_Contributor'
ALTER TABLE [dbo].[RepositoryObjects_Contributor]
ADD CONSTRAINT [PK_RepositoryObjects_Contributor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_Branch'
ALTER TABLE [dbo].[RepositoryObjects_Branch]
ADD CONSTRAINT [PK_RepositoryObjects_Branch]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_FileVersion'
ALTER TABLE [dbo].[RepositoryObjects_FileVersion]
ADD CONSTRAINT [PK_RepositoryObjects_FileVersion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_File'
ALTER TABLE [dbo].[RepositoryObjects_File]
ADD CONSTRAINT [PK_RepositoryObjects_File]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_FileChange'
ALTER TABLE [dbo].[RepositoryObjects_FileChange]
ADD CONSTRAINT [PK_RepositoryObjects_FileChange]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_FileModifiedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileModifiedChange]
ADD CONSTRAINT [PK_RepositoryObjects_FileModifiedChange]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_FileAddedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileAddedChange]
ADD CONSTRAINT [PK_RepositoryObjects_FileAddedChange]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_FileDeletedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileDeletedChange]
ADD CONSTRAINT [PK_RepositoryObjects_FileDeletedChange]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RepositoryObjects_FileRenamedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileRenamedChange]
ADD CONSTRAINT [PK_RepositoryObjects_FileRenamedChange]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Commits_Id], [Branches_Id] in table 'Branch_Contains_Commits'
ALTER TABLE [dbo].[Branch_Contains_Commits]
ADD CONSTRAINT [PK_Branch_Contains_Commits]
    PRIMARY KEY CLUSTERED ([Commits_Id], [Branches_Id] ASC);
GO

-- Creating primary key on [Childs_Id], [Parents_Id] in table 'Commits_AreParentsOf_Commits'
ALTER TABLE [dbo].[Commits_AreParentsOf_Commits]
ADD CONSTRAINT [PK_Commits_AreParentsOf_Commits]
    PRIMARY KEY CLUSTERED ([Childs_Id], [Parents_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Committer_Id] in table 'RepositoryObjects_Commit'
ALTER TABLE [dbo].[RepositoryObjects_Commit]
ADD CONSTRAINT [FK_Contributor_IsAuthorOf_Commits]
    FOREIGN KEY ([Committer_Id])
    REFERENCES [dbo].[RepositoryObjects_Contributor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contributor_IsAuthorOf_Commits'
CREATE INDEX [IX_FK_Contributor_IsAuthorOf_Commits]
ON [dbo].[RepositoryObjects_Commit]
    ([Committer_Id]);
GO

-- Creating foreign key on [Tip_Id] in table 'RepositoryObjects_Branch'
ALTER TABLE [dbo].[RepositoryObjects_Branch]
ADD CONSTRAINT [FK_Branch_PointTo_OneCommit]
    FOREIGN KEY ([Tip_Id])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Branch_PointTo_OneCommit'
CREATE INDEX [IX_FK_Branch_PointTo_OneCommit]
ON [dbo].[RepositoryObjects_Branch]
    ([Tip_Id]);
GO

-- Creating foreign key on [Commits_Id] in table 'Branch_Contains_Commits'
ALTER TABLE [dbo].[Branch_Contains_Commits]
ADD CONSTRAINT [FK_Branch_Contains_Commits_Commit]
    FOREIGN KEY ([Commits_Id])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Branches_Id] in table 'Branch_Contains_Commits'
ALTER TABLE [dbo].[Branch_Contains_Commits]
ADD CONSTRAINT [FK_Branch_Contains_Commits_Branch]
    FOREIGN KEY ([Branches_Id])
    REFERENCES [dbo].[RepositoryObjects_Branch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Branch_Contains_Commits_Branch'
CREATE INDEX [IX_FK_Branch_Contains_Commits_Branch]
ON [dbo].[Branch_Contains_Commits]
    ([Branches_Id]);
GO

-- Creating foreign key on [Childs_Id] in table 'Commits_AreParentsOf_Commits'
ALTER TABLE [dbo].[Commits_AreParentsOf_Commits]
ADD CONSTRAINT [FK_Commits_AreParentsOf_Commits_Commit]
    FOREIGN KEY ([Childs_Id])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Parents_Id] in table 'Commits_AreParentsOf_Commits'
ALTER TABLE [dbo].[Commits_AreParentsOf_Commits]
ADD CONSTRAINT [FK_Commits_AreParentsOf_Commits_Commit1]
    FOREIGN KEY ([Parents_Id])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Commits_AreParentsOf_Commits_Commit1'
CREATE INDEX [IX_FK_Commits_AreParentsOf_Commits_Commit1]
ON [dbo].[Commits_AreParentsOf_Commits]
    ([Parents_Id]);
GO

-- Creating foreign key on [FileVersion_Id] in table 'FileContents'
ALTER TABLE [dbo].[FileContents]
ADD CONSTRAINT [FK_OneFileVersion_HasExactly_OneFileContent]
    FOREIGN KEY ([FileVersion_Id])
    REFERENCES [dbo].[RepositoryObjects_FileVersion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneFileVersion_HasExactly_OneFileContent'
CREATE INDEX [IX_FK_OneFileVersion_HasExactly_OneFileContent]
ON [dbo].[FileContents]
    ([FileVersion_Id]);
GO

-- Creating foreign key on [File_Id] in table 'RepositoryObjects_FileVersion'
ALTER TABLE [dbo].[RepositoryObjects_FileVersion]
ADD CONSTRAINT [FK_OneFile_HasMany_Versions]
    FOREIGN KEY ([File_Id])
    REFERENCES [dbo].[RepositoryObjects_File]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneFile_HasMany_Versions'
CREATE INDEX [IX_FK_OneFile_HasMany_Versions]
ON [dbo].[RepositoryObjects_FileVersion]
    ([File_Id]);
GO

-- Creating foreign key on [ToCommit_Id] in table 'RepositoryObjects_FileChange'
ALTER TABLE [dbo].[RepositoryObjects_FileChange]
ADD CONSTRAINT [FK_FileChange_DifferencingTo_Commit]
    FOREIGN KEY ([ToCommit_Id])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileChange_DifferencingTo_Commit'
CREATE INDEX [IX_FK_FileChange_DifferencingTo_Commit]
ON [dbo].[RepositoryObjects_FileChange]
    ([ToCommit_Id]);
GO

-- Creating foreign key on [FromCommit_Id] in table 'RepositoryObjects_FileChange'
ALTER TABLE [dbo].[RepositoryObjects_FileChange]
ADD CONSTRAINT [FK_FileChange_DifferencingFrom_Commit]
    FOREIGN KEY ([FromCommit_Id])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileChange_DifferencingFrom_Commit'
CREATE INDEX [IX_FK_FileChange_DifferencingFrom_Commit]
ON [dbo].[RepositoryObjects_FileChange]
    ([FromCommit_Id]);
GO

-- Creating foreign key on [FileVersion_Id] in table 'RepositoryObjects_FileChange'
ALTER TABLE [dbo].[RepositoryObjects_FileChange]
ADD CONSTRAINT [FK_FileChanges_Originate_ManyFileVersions]
    FOREIGN KEY ([FileVersion_Id])
    REFERENCES [dbo].[RepositoryObjects_FileVersion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileChanges_Originate_ManyFileVersions'
CREATE INDEX [IX_FK_FileChanges_Originate_ManyFileVersions]
ON [dbo].[RepositoryObjects_FileChange]
    ([FileVersion_Id]);
GO

-- Creating foreign key on [FromFileVersion_Id] in table 'RepositoryObjects_FileModifiedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileModifiedChange]
ADD CONSTRAINT [FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges]
    FOREIGN KEY ([FromFileVersion_Id])
    REFERENCES [dbo].[RepositoryObjects_FileVersion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges'
CREATE INDEX [IX_FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges]
ON [dbo].[RepositoryObjects_FileModifiedChange]
    ([FromFileVersion_Id]);
GO

-- Creating foreign key on [FileVersion_Id] in table 'FileContentSummaries'
ALTER TABLE [dbo].[FileContentSummaries]
ADD CONSTRAINT [FK_OneFileVersion_HasExactly_OneFileContentSummary]
    FOREIGN KEY ([FileVersion_Id])
    REFERENCES [dbo].[RepositoryObjects_FileVersion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneFileVersion_HasExactly_OneFileContentSummary'
CREATE INDEX [IX_FK_OneFileVersion_HasExactly_OneFileContentSummary]
ON [dbo].[FileContentSummaries]
    ([FileVersion_Id]);
GO

-- Creating foreign key on [RevisionPair_Id] in table 'Deltas'
ALTER TABLE [dbo].[Deltas]
ADD CONSTRAINT [FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas]
    FOREIGN KEY ([RevisionPair_Id])
    REFERENCES [dbo].[RepositoryObjects_FileModifiedChange]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas'
CREATE INDEX [IX_FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas]
ON [dbo].[Deltas]
    ([RevisionPair_Id]);
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_Commit'
ALTER TABLE [dbo].[RepositoryObjects_Commit]
ADD CONSTRAINT [FK_Commit_inherits_RepositoryObject]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_Contributor'
ALTER TABLE [dbo].[RepositoryObjects_Contributor]
ADD CONSTRAINT [FK_Contributor_inherits_RepositoryObject]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_Branch'
ALTER TABLE [dbo].[RepositoryObjects_Branch]
ADD CONSTRAINT [FK_Branch_inherits_RepositoryObject]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_FileVersion'
ALTER TABLE [dbo].[RepositoryObjects_FileVersion]
ADD CONSTRAINT [FK_FileVersion_inherits_RepositoryObject]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_File'
ALTER TABLE [dbo].[RepositoryObjects_File]
ADD CONSTRAINT [FK_File_inherits_RepositoryObject]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_FileChange'
ALTER TABLE [dbo].[RepositoryObjects_FileChange]
ADD CONSTRAINT [FK_FileChange_inherits_RepositoryObject]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_FileModifiedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileModifiedChange]
ADD CONSTRAINT [FK_FileModifiedChange_inherits_FileChange]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects_FileChange]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_FileAddedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileAddedChange]
ADD CONSTRAINT [FK_FileAddedChange_inherits_FileChange]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects_FileChange]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_FileDeletedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileDeletedChange]
ADD CONSTRAINT [FK_FileDeletedChange_inherits_FileChange]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects_FileChange]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'RepositoryObjects_FileRenamedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileRenamedChange]
ADD CONSTRAINT [FK_FileRenamedChange_inherits_FileModifiedChange]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[RepositoryObjects_FileModifiedChange]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------