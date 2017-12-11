
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/11/2017 16:18:44
-- Generated from EDMX file: E:\MyRepositories\Change-Detection-Foundation\Jawilliam.CDF.Labs\GitRepository.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GitRepositoryDb];
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
IF OBJECT_ID(N'[dbo].[FK_OneFile_CanHave_ManyRevisionPairs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileRevisionPairs] DROP CONSTRAINT [FK_OneFile_CanHave_ManyRevisionPairs];
GO
IF OBJECT_ID(N'[dbo].[FK_FileRevisionPairFileModifiedChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileRevisionPairs] DROP CONSTRAINT [FK_FileRevisionPairFileModifiedChange];
GO
IF OBJECT_ID(N'[dbo].[FK_FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepositoryObjects_FileModifiedChange] DROP CONSTRAINT [FK_FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges];
GO
IF OBJECT_ID(N'[dbo].[FK_OneFileRevisionPair_MayHave_ManyReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_OneFileRevisionPair_MayHave_ManyReview];
GO
IF OBJECT_ID(N'[dbo].[FK_OneDelta_MayHave_ManySymptoms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Symptoms] DROP CONSTRAINT [FK_OneDelta_MayHave_ManySymptoms];
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
IF OBJECT_ID(N'[dbo].[FK_MissedNameSymptom_inherits_Symptom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Symptoms_MissedNameSymptom] DROP CONSTRAINT [FK_MissedNameSymptom_inherits_Symptom];
GO
IF OBJECT_ID(N'[dbo].[FK_NameCoexistenceSymptom_inherits_Symptom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Symptoms_NameCoexistenceSymptom] DROP CONSTRAINT [FK_NameCoexistenceSymptom_inherits_Symptom];
GO
IF OBJECT_ID(N'[dbo].[FK_IncompatibleMatchingSymptom_inherits_Symptom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Symptoms_IncompatibleMatchingSymptom] DROP CONSTRAINT [FK_IncompatibleMatchingSymptom_inherits_Symptom];
GO
IF OBJECT_ID(N'[dbo].[FK_SpuriositySymptom_inherits_Symptom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Symptoms_SpuriositySymptom] DROP CONSTRAINT [FK_SpuriositySymptom_inherits_Symptom];
GO
IF OBJECT_ID(N'[dbo].[FK_GhostSymptom_inherits_Symptom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Symptoms_GhostSymptom] DROP CONSTRAINT [FK_GhostSymptom_inherits_Symptom];
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
IF OBJECT_ID(N'[dbo].[FileRevisionPairs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileRevisionPairs];
GO
IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[Symptoms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Symptoms];
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
IF OBJECT_ID(N'[dbo].[Symptoms_MissedNameSymptom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Symptoms_MissedNameSymptom];
GO
IF OBJECT_ID(N'[dbo].[Symptoms_NameCoexistenceSymptom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Symptoms_NameCoexistenceSymptom];
GO
IF OBJECT_ID(N'[dbo].[Symptoms_IncompatibleMatchingSymptom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Symptoms_IncompatibleMatchingSymptom];
GO
IF OBJECT_ID(N'[dbo].[Symptoms_SpuriositySymptom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Symptoms_SpuriositySymptom];
GO
IF OBJECT_ID(N'[dbo].[Symptoms_GhostSymptom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Symptoms_GhostSymptom];
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
    [Annotations] nvarchar(max)  NULL
);
GO

-- Creating table 'FileContents'
CREATE TABLE [dbo].[FileContents] (
    [Id] uniqueidentifier  NOT NULL,
    [SourceCode] nvarchar(max)  NULL,
    [Annotations] nvarchar(max)  NULL,
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
    [SyntaxKindAnnotations] nvarchar(max)  NULL,
    [Annotations] nvarchar(max)  NULL,
    [CodeCategory] smallint  NULL,
    [FileVersion_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Deltas'
CREATE TABLE [dbo].[Deltas] (
    [Id] uniqueidentifier  NOT NULL,
    [Matching] nvarchar(max)  NULL,
    [Differencing] nvarchar(max)  NULL,
    [Report] nvarchar(max)  NULL,
    [Annotations] nvarchar(max)  NULL,
    [Approach] int  NOT NULL,
    [OriginalTree] nvarchar(max)  NULL,
    [ModifiedTree] nvarchar(max)  NULL,
    [GlobalSubcorpus] int  NULL,
    [GlobalInsertPorcentageSubcorpus] int  NULL,
    [GlobalDeletePorcentageSubcorpus] int  NULL,
    [GlobalUpdatePorcentageSubcorpus] int  NULL,
    [GlobalMovePorcentageSubcorpus] int  NULL,
    [RevisionPair_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'FileRevisionPairs'
CREATE TABLE [dbo].[FileRevisionPairs] (
    [Id] uniqueidentifier  NOT NULL,
    [Annotations] nvarchar(max)  NULL,
    [Versioning_Path] nvarchar(max)  NOT NULL,
    [Versioning_FromVersion] int  NOT NULL,
    [Versioning_ToVersion] int  NOT NULL,
    [Flags] bigint  NULL,
    [OneFile_CanHave_ManyRevisionPairs_FileRevisionPair_Id] uniqueidentifier  NOT NULL,
    [Principal_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [Id] uniqueidentifier  NOT NULL,
    [Kind] int  NOT NULL,
    [Severity] int  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Comments] nvarchar(max)  NULL,
    [Topics] smallint  NOT NULL,
    [Annotations] nvarchar(max)  NULL,
    [CaseKind] int  NOT NULL,
    [SpuriousMatch] bit  NULL,
    [UnnaturalMatch] bit  NULL,
    [GhostMatch] bit  NULL,
    [MissedMatch] bit  NULL,
    [ArbitraryMatch] bit  NULL,
    [RedundantChanges] bit  NULL,
    [GhostChanges] bit  NULL,
    [SpuriousChanges] bit  NULL,
    [RevisionPair_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Id] uniqueidentifier  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [AbbreviatedName] nvarchar(max)  NOT NULL,
    [From] datetime  NOT NULL,
    [To] datetime  NOT NULL,
    [Link] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Annotations] nvarchar(max)  NULL
);
GO

-- Creating table 'Symptoms'
CREATE TABLE [dbo].[Symptoms] (
    [Id] uniqueidentifier  NOT NULL,
    [Notes] int  NULL,
    [Certainty_Method] nvarchar(max)  NULL,
    [Certainty_Value] tinyint  NULL,
    [Delta_Id] uniqueidentifier  NOT NULL
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
    [FromFileVersion_Id] uniqueidentifier  NOT NULL,
    [FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges_FileModifiedChange_Id] uniqueidentifier  NULL
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

-- Creating table 'Symptoms_MissedElementSymptom'
CREATE TABLE [dbo].[Symptoms_MissedElementSymptom] (
    [Pattern] nvarchar(max)  NOT NULL,
    [Original_Hint] nvarchar(max)  NULL,
    [Original_Element_Type] nvarchar(max)  NOT NULL,
    [Original_Element_Id] nvarchar(max)  NOT NULL,
    [Original_Element_Hint] nvarchar(max)  NULL,
    [Original_AncestorOfReference_Type] nvarchar(max)  NOT NULL,
    [Original_AncestorOfReference_Id] nvarchar(max)  NOT NULL,
    [Original_AncestorOfReference_Hint] nvarchar(max)  NULL,
    [Original_CommonAncestorOfReference_Type] nvarchar(max)  NOT NULL,
    [Original_CommonAncestorOfReference_Id] nvarchar(max)  NOT NULL,
    [Original_CommonAncestorOfReference_Hint] nvarchar(max)  NULL,
    [Original_ScopeHint] nvarchar(max)  NULL,
    [Modified_Hint] nvarchar(max)  NULL,
    [Modified_Element_Type] nvarchar(max)  NOT NULL,
    [Modified_Element_Id] nvarchar(max)  NOT NULL,
    [Modified_Element_Hint] nvarchar(max)  NULL,
    [Modified_AncestorOfReference_Type] nvarchar(max)  NOT NULL,
    [Modified_AncestorOfReference_Id] nvarchar(max)  NOT NULL,
    [Modified_AncestorOfReference_Hint] nvarchar(max)  NULL,
    [Modified_CommonAncestorOfReference_Type] nvarchar(max)  NOT NULL,
    [Modified_CommonAncestorOfReference_Id] nvarchar(max)  NOT NULL,
    [Modified_CommonAncestorOfReference_Hint] nvarchar(max)  NULL,
    [Modified_ScopeHint] nvarchar(max)  NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Symptoms_MissedNameSymptom'
CREATE TABLE [dbo].[Symptoms_MissedNameSymptom] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Symptoms_CoexistenceSymptom'
CREATE TABLE [dbo].[Symptoms_CoexistenceSymptom] (
    [Original_Element_Type] nvarchar(max)  NOT NULL,
    [Original_Element_Id] nvarchar(max)  NOT NULL,
    [Original_Element_Hint] nvarchar(max)  NULL,
    [Original_ScopeHint] nvarchar(max)  NULL,
    [Modified_Element_Type] nvarchar(max)  NOT NULL,
    [Modified_Element_Id] nvarchar(max)  NOT NULL,
    [Modified_Element_Hint] nvarchar(max)  NULL,
    [Modified_ScopeHint] nvarchar(max)  NULL,
    [CoexistingOriginal_Element_Type] nvarchar(max)  NOT NULL,
    [CoexistingOriginal_Element_Id] nvarchar(max)  NOT NULL,
    [CoexistingOriginal_Element_Hint] nvarchar(max)  NULL,
    [CoexistingOriginal_ScopeHint] nvarchar(max)  NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Symptoms_NameCoexistenceSymptom'
CREATE TABLE [dbo].[Symptoms_NameCoexistenceSymptom] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Symptoms_IncompatibleMatchingSymptom'
CREATE TABLE [dbo].[Symptoms_IncompatibleMatchingSymptom] (
    [Pattern] nvarchar(max)  NOT NULL,
    [Original_Element_Type] nvarchar(max)  NOT NULL,
    [Original_Element_Id] nvarchar(max)  NOT NULL,
    [Original_Element_Hint] nvarchar(max)  NULL,
    [Original_ScopeHint] nvarchar(max)  NULL,
    [Modified_Element_Type] nvarchar(max)  NOT NULL,
    [Modified_Element_Id] nvarchar(max)  NOT NULL,
    [Modified_Element_Hint] nvarchar(max)  NULL,
    [Modified_ScopeHint] nvarchar(max)  NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Symptoms_SpuriositySymptom'
CREATE TABLE [dbo].[Symptoms_SpuriositySymptom] (
    [TransformationsInfo] nvarchar(max)  NULL,
    [TransformationSummary] nvarchar(max)  NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Symptoms_GhostSymptom'
CREATE TABLE [dbo].[Symptoms_GhostSymptom] (
    [Pattern] nvarchar(max)  NOT NULL,
    [Original_Element_Type] nvarchar(max)  NOT NULL,
    [Original_Element_Id] nvarchar(max)  NOT NULL,
    [Original_Element_Hint] nvarchar(max)  NULL,
    [Original_ScopeHint] nvarchar(max)  NULL,
    [Modified_Element_Type] nvarchar(max)  NOT NULL,
    [Modified_Element_Id] nvarchar(max)  NOT NULL,
    [Modified_Element_Hint] nvarchar(max)  NULL,
    [Modified_ScopeHint] nvarchar(max)  NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Symptoms_SpuriousElementSymptom'
CREATE TABLE [dbo].[Symptoms_SpuriousElementSymptom] (
    [Pattern] nvarchar(max)  NOT NULL,
    [Original_Element_Type] nvarchar(max)  NOT NULL,
    [Original_Element_Id] nvarchar(max)  NOT NULL,
    [Original_Element_Hint] nvarchar(max)  NULL,
    [Original_ScopeHint] nvarchar(max)  NULL,
    [Modified_Element_Type] nvarchar(max)  NOT NULL,
    [Modified_Element_Id] nvarchar(max)  NOT NULL,
    [Modified_Element_Hint] nvarchar(max)  NULL,
    [Modified_ScopeHint] nvarchar(max)  NULL,
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

-- Creating primary key on [Id] in table 'FileRevisionPairs'
ALTER TABLE [dbo].[FileRevisionPairs]
ADD CONSTRAINT [PK_FileRevisionPairs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms'
ALTER TABLE [dbo].[Symptoms]
ADD CONSTRAINT [PK_Symptoms]
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

-- Creating primary key on [Id] in table 'Symptoms_MissedElementSymptom'
ALTER TABLE [dbo].[Symptoms_MissedElementSymptom]
ADD CONSTRAINT [PK_Symptoms_MissedElementSymptom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms_MissedNameSymptom'
ALTER TABLE [dbo].[Symptoms_MissedNameSymptom]
ADD CONSTRAINT [PK_Symptoms_MissedNameSymptom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms_CoexistenceSymptom'
ALTER TABLE [dbo].[Symptoms_CoexistenceSymptom]
ADD CONSTRAINT [PK_Symptoms_CoexistenceSymptom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms_NameCoexistenceSymptom'
ALTER TABLE [dbo].[Symptoms_NameCoexistenceSymptom]
ADD CONSTRAINT [PK_Symptoms_NameCoexistenceSymptom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms_IncompatibleMatchingSymptom'
ALTER TABLE [dbo].[Symptoms_IncompatibleMatchingSymptom]
ADD CONSTRAINT [PK_Symptoms_IncompatibleMatchingSymptom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms_SpuriositySymptom'
ALTER TABLE [dbo].[Symptoms_SpuriositySymptom]
ADD CONSTRAINT [PK_Symptoms_SpuriositySymptom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms_GhostSymptom'
ALTER TABLE [dbo].[Symptoms_GhostSymptom]
ADD CONSTRAINT [PK_Symptoms_GhostSymptom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Symptoms_SpuriousElementSymptom'
ALTER TABLE [dbo].[Symptoms_SpuriousElementSymptom]
ADD CONSTRAINT [PK_Symptoms_SpuriousElementSymptom]
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

-- Creating foreign key on [OneFile_CanHave_ManyRevisionPairs_FileRevisionPair_Id] in table 'FileRevisionPairs'
ALTER TABLE [dbo].[FileRevisionPairs]
ADD CONSTRAINT [FK_OneFile_CanHave_ManyRevisionPairs]
    FOREIGN KEY ([OneFile_CanHave_ManyRevisionPairs_FileRevisionPair_Id])
    REFERENCES [dbo].[RepositoryObjects_File]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneFile_CanHave_ManyRevisionPairs'
CREATE INDEX [IX_FK_OneFile_CanHave_ManyRevisionPairs]
ON [dbo].[FileRevisionPairs]
    ([OneFile_CanHave_ManyRevisionPairs_FileRevisionPair_Id]);
GO

-- Creating foreign key on [Principal_Id] in table 'FileRevisionPairs'
ALTER TABLE [dbo].[FileRevisionPairs]
ADD CONSTRAINT [FK_FileRevisionPairFileModifiedChange]
    FOREIGN KEY ([Principal_Id])
    REFERENCES [dbo].[RepositoryObjects_FileModifiedChange]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileRevisionPairFileModifiedChange'
CREATE INDEX [IX_FK_FileRevisionPairFileModifiedChange]
ON [dbo].[FileRevisionPairs]
    ([Principal_Id]);
GO

-- Creating foreign key on [FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges_FileModifiedChange_Id] in table 'RepositoryObjects_FileModifiedChange'
ALTER TABLE [dbo].[RepositoryObjects_FileModifiedChange]
ADD CONSTRAINT [FK_FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges]
    FOREIGN KEY ([FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges_FileModifiedChange_Id])
    REFERENCES [dbo].[FileRevisionPairs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges'
CREATE INDEX [IX_FK_FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges]
ON [dbo].[RepositoryObjects_FileModifiedChange]
    ([FileRevisionPair_AlsoReferences_TheDuplicatedFileModifiedChanges_FileModifiedChange_Id]);
GO

-- Creating foreign key on [RevisionPair_Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_OneFileRevisionPair_MayHave_ManyReview]
    FOREIGN KEY ([RevisionPair_Id])
    REFERENCES [dbo].[FileRevisionPairs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneFileRevisionPair_MayHave_ManyReview'
CREATE INDEX [IX_FK_OneFileRevisionPair_MayHave_ManyReview]
ON [dbo].[Reviews]
    ([RevisionPair_Id]);
GO

-- Creating foreign key on [Delta_Id] in table 'Symptoms'
ALTER TABLE [dbo].[Symptoms]
ADD CONSTRAINT [FK_OneDelta_MayHave_ManySymptoms]
    FOREIGN KEY ([Delta_Id])
    REFERENCES [dbo].[Deltas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneDelta_MayHave_ManySymptoms'
CREATE INDEX [IX_FK_OneDelta_MayHave_ManySymptoms]
ON [dbo].[Symptoms]
    ([Delta_Id]);
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

-- Creating foreign key on [Id] in table 'Symptoms_MissedElementSymptom'
ALTER TABLE [dbo].[Symptoms_MissedElementSymptom]
ADD CONSTRAINT [FK_MissedElementSymptom_inherits_Symptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Symptoms_MissedNameSymptom'
ALTER TABLE [dbo].[Symptoms_MissedNameSymptom]
ADD CONSTRAINT [FK_MissedNameSymptom_inherits_MissedElementSymptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms_MissedElementSymptom]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Symptoms_CoexistenceSymptom'
ALTER TABLE [dbo].[Symptoms_CoexistenceSymptom]
ADD CONSTRAINT [FK_CoexistenceSymptom_inherits_Symptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Symptoms_NameCoexistenceSymptom'
ALTER TABLE [dbo].[Symptoms_NameCoexistenceSymptom]
ADD CONSTRAINT [FK_NameCoexistenceSymptom_inherits_CoexistenceSymptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms_CoexistenceSymptom]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Symptoms_IncompatibleMatchingSymptom'
ALTER TABLE [dbo].[Symptoms_IncompatibleMatchingSymptom]
ADD CONSTRAINT [FK_IncompatibleMatchingSymptom_inherits_Symptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Symptoms_SpuriositySymptom'
ALTER TABLE [dbo].[Symptoms_SpuriositySymptom]
ADD CONSTRAINT [FK_SpuriositySymptom_inherits_Symptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Symptoms_GhostSymptom'
ALTER TABLE [dbo].[Symptoms_GhostSymptom]
ADD CONSTRAINT [FK_GhostSymptom_inherits_Symptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Symptoms_SpuriousElementSymptom'
ALTER TABLE [dbo].[Symptoms_SpuriousElementSymptom]
ADD CONSTRAINT [FK_SpuriousElementSymptom_inherits_Symptom]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Symptoms]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------