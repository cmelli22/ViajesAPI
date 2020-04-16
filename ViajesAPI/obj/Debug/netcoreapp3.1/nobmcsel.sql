IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Users] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    [lastName] nvarchar(max) NOT NULL,
    [telefono] nvarchar(30) NULL,
    [email] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([id])
);

GO

CREATE TABLE [Messages] (
    [idMeesage] int NOT NULL IDENTITY,
    [message] nvarchar(max) NOT NULL,
    [readed] bit NOT NULL,
    [userId] int NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([idMeesage]),
    CONSTRAINT [FK_Messages_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Messages_userId] ON [Messages] ([userId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200406210552_Initial Migration', N'3.1.3');

GO

