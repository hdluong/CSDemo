IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [article] (
    [ArticleId] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NULL,
    CONSTRAINT [PK_article] PRIMARY KEY ([ArticleId])
);
GO

CREATE TABLE [Tag] (
    [TagId] nvarchar(20) NOT NULL,
    [Content] ntext NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([TagId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220621023452_V0', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[article].[Title]', N'Name', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220621025841_V1', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [article] ADD [Content] ntext NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220621030802_V2', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Tag] DROP CONSTRAINT [PK_Tag];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tag]') AND [c].[name] = N'TagId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tag] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tag] DROP COLUMN [TagId];
GO

ALTER TABLE [Tag] ADD [TagIdNew] int NOT NULL IDENTITY;
GO

ALTER TABLE [Tag] ADD CONSTRAINT [PK_Tag] PRIMARY KEY ([TagIdNew]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220621031601_V3-RemoveTagId', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Tag].[TagIdNew]', N'TagId', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220621031901_V3-RenameTagId', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ArticleTag] (
    [ArticleTagId] int NOT NULL IDENTITY,
    [TagId] int NOT NULL,
    [ArticleId] int NOT NULL,
    CONSTRAINT [PK_ArticleTag] PRIMARY KEY ([ArticleTagId]),
    CONSTRAINT [FK_ArticleTag_article_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [article] ([ArticleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArticleTag_Tag_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([TagId]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_ArticleTag_ArticleId_TagId] ON [ArticleTag] ([ArticleId], [TagId]);
GO

CREATE INDEX [IX_ArticleTag_TagId] ON [ArticleTag] ([TagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220621033724_V4', N'5.0.17');
GO

COMMIT;
GO

