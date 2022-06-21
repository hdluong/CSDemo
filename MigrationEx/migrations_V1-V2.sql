BEGIN TRANSACTION;
GO

ALTER TABLE [article] ADD [Content] ntext NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220621030802_V2', N'5.0.17');
GO

COMMIT;
GO

