CREATE TABLE [dbo].[UserConventionRole] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_UserConventionRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

