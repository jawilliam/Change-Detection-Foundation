
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/24/2017 12:46:56
-- Generated from EDMX file: E:\Projects\Change-Detection-Foundation\Jawilliam.CDF.Labs\GitRepository.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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

-- Creating table 'FileChanges'
CREATE TABLE [dbo].[FileChanges] (
    [ParentCommitId] uniqueidentifier  NOT NULL,
    [FileVersionId] uniqueidentifier  NOT NULL,
    [ChildCommitId] uniqueidentifier  NOT NULL,
    [LinesAdded] int  NOT NULL,
    [LinesDeleted] int  NOT NULL,
    [Patch] nvarchar(max)  NULL,
    [Annotations] xml  NULL
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
    [RevisionPair_ParentCommitId] uniqueidentifier  NULL,
    [RevisionPair_FileVersionId] uniqueidentifier  NULL,
    [RevisionPair_ChildCommitId] uniqueidentifier  NULL
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

-- Creating table 'FileChanges_FileModifiedChange'
CREATE TABLE [dbo].[FileChanges_FileModifiedChange] (
    [ToPath] nvarchar(max)  NOT NULL,
    [ParentCommitId] uniqueidentifier  NOT NULL,
    [FileVersionId] uniqueidentifier  NOT NULL,
    [ChildCommitId] uniqueidentifier  NOT NULL,
    [FromFileVersion_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'FileChanges_FileAddedChange'
CREATE TABLE [dbo].[FileChanges_FileAddedChange] (
    [ParentCommitId] uniqueidentifier  NOT NULL,
    [FileVersionId] uniqueidentifier  NOT NULL,
    [ChildCommitId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'FileChanges_FileDeletedChange'
CREATE TABLE [dbo].[FileChanges_FileDeletedChange] (
    [ParentCommitId] uniqueidentifier  NOT NULL,
    [FileVersionId] uniqueidentifier  NOT NULL,
    [ChildCommitId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'FileChanges_FileRenamedChange'
CREATE TABLE [dbo].[FileChanges_FileRenamedChange] (
    [FromPath] nvarchar(max)  NOT NULL,
    [ParentCommitId] uniqueidentifier  NOT NULL,
    [FileVersionId] uniqueidentifier  NOT NULL,
    [ChildCommitId] uniqueidentifier  NOT NULL
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

-- Creating primary key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges'
ALTER TABLE [dbo].[FileChanges]
ADD CONSTRAINT [PK_FileChanges]
    PRIMARY KEY CLUSTERED ([ParentCommitId], [FileVersionId], [ChildCommitId] ASC);
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

-- Creating primary key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileModifiedChange'
ALTER TABLE [dbo].[FileChanges_FileModifiedChange]
ADD CONSTRAINT [PK_FileChanges_FileModifiedChange]
    PRIMARY KEY CLUSTERED ([ParentCommitId], [FileVersionId], [ChildCommitId] ASC);
GO

-- Creating primary key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileAddedChange'
ALTER TABLE [dbo].[FileChanges_FileAddedChange]
ADD CONSTRAINT [PK_FileChanges_FileAddedChange]
    PRIMARY KEY CLUSTERED ([ParentCommitId], [FileVersionId], [ChildCommitId] ASC);
GO

-- Creating primary key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileDeletedChange'
ALTER TABLE [dbo].[FileChanges_FileDeletedChange]
ADD CONSTRAINT [PK_FileChanges_FileDeletedChange]
    PRIMARY KEY CLUSTERED ([ParentCommitId], [FileVersionId], [ChildCommitId] ASC);
GO

-- Creating primary key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileRenamedChange'
ALTER TABLE [dbo].[FileChanges_FileRenamedChange]
ADD CONSTRAINT [PK_FileChanges_FileRenamedChange]
    PRIMARY KEY CLUSTERED ([ParentCommitId], [FileVersionId], [ChildCommitId] ASC);
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

-- Creating foreign key on [ChildCommitId] in table 'FileChanges'
ALTER TABLE [dbo].[FileChanges]
ADD CONSTRAINT [FK_FileChange_DifferencingTo_Commit]
    FOREIGN KEY ([ChildCommitId])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileChange_DifferencingTo_Commit'
CREATE INDEX [IX_FK_FileChange_DifferencingTo_Commit]
ON [dbo].[FileChanges]
    ([ChildCommitId]);
GO

-- Creating foreign key on [ParentCommitId] in table 'FileChanges'
ALTER TABLE [dbo].[FileChanges]
ADD CONSTRAINT [FK_FileChange_DifferencingFrom_Commit]
    FOREIGN KEY ([ParentCommitId])
    REFERENCES [dbo].[RepositoryObjects_Commit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FileVersionId] in table 'FileChanges'
ALTER TABLE [dbo].[FileChanges]
ADD CONSTRAINT [FK_FileChanges_Originate_ManyFileVersions]
    FOREIGN KEY ([FileVersionId])
    REFERENCES [dbo].[RepositoryObjects_FileVersion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileChanges_Originate_ManyFileVersions'
CREATE INDEX [IX_FK_FileChanges_Originate_ManyFileVersions]
ON [dbo].[FileChanges]
    ([FileVersionId]);
GO

-- Creating foreign key on [FromFileVersion_Id] in table 'FileChanges_FileModifiedChange'
ALTER TABLE [dbo].[FileChanges_FileModifiedChange]
ADD CONSTRAINT [FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges]
    FOREIGN KEY ([FromFileVersion_Id])
    REFERENCES [dbo].[RepositoryObjects_FileVersion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges'
CREATE INDEX [IX_FK_OneFileVersion_CanBeModifiedFromBy_ManyFileChanges]
ON [dbo].[FileChanges_FileModifiedChange]
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

-- Creating foreign key on [RevisionPair_ParentCommitId], [RevisionPair_FileVersionId], [RevisionPair_ChildCommitId] in table 'Deltas'
ALTER TABLE [dbo].[Deltas]
ADD CONSTRAINT [FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas]
    FOREIGN KEY ([RevisionPair_ParentCommitId], [RevisionPair_FileVersionId], [RevisionPair_ChildCommitId])
    REFERENCES [dbo].[FileChanges_FileModifiedChange]
        ([ParentCommitId], [FileVersionId], [ChildCommitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas'
CREATE INDEX [IX_FK_FileModifiedChanges_CanBeDescribedByDifferent_Deltas]
ON [dbo].[Deltas]
    ([RevisionPair_ParentCommitId], [RevisionPair_FileVersionId], [RevisionPair_ChildCommitId]);
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

-- Creating foreign key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileModifiedChange'
ALTER TABLE [dbo].[FileChanges_FileModifiedChange]
ADD CONSTRAINT [FK_FileModifiedChange_inherits_FileChange]
    FOREIGN KEY ([ParentCommitId], [FileVersionId], [ChildCommitId])
    REFERENCES [dbo].[FileChanges]
        ([ParentCommitId], [FileVersionId], [ChildCommitId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileAddedChange'
ALTER TABLE [dbo].[FileChanges_FileAddedChange]
ADD CONSTRAINT [FK_FileAddedChange_inherits_FileChange]
    FOREIGN KEY ([ParentCommitId], [FileVersionId], [ChildCommitId])
    REFERENCES [dbo].[FileChanges]
        ([ParentCommitId], [FileVersionId], [ChildCommitId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileDeletedChange'
ALTER TABLE [dbo].[FileChanges_FileDeletedChange]
ADD CONSTRAINT [FK_FileDeletedChange_inherits_FileChange]
    FOREIGN KEY ([ParentCommitId], [FileVersionId], [ChildCommitId])
    REFERENCES [dbo].[FileChanges]
        ([ParentCommitId], [FileVersionId], [ChildCommitId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ParentCommitId], [FileVersionId], [ChildCommitId] in table 'FileChanges_FileRenamedChange'
ALTER TABLE [dbo].[FileChanges_FileRenamedChange]
ADD CONSTRAINT [FK_FileRenamedChange_inherits_FileModifiedChange]
    FOREIGN KEY ([ParentCommitId], [FileVersionId], [ChildCommitId])
    REFERENCES [dbo].[FileChanges_FileModifiedChange]
        ([ParentCommitId], [FileVersionId], [ChildCommitId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------