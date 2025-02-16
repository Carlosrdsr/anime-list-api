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
CREATE TABLE [Tb_Animes] (
    [Id] bigint NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    [Diretor] nvarchar(50) NOT NULL,
    [Resumo] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Tb_Animes] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250216043816_AddTableAnime', N'9.0.2');

COMMIT;
GO

