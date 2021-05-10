CREATE TABLE [dbo].[User] (
    [Username]  NVARCHAR (250)   NOT NULL,
    [Email]     NVARCHAR (250)   NOT NULL,
    [FirstName] NVARCHAR (MAX)   NULL,
    [LastName]  NVARCHAR (MAX)   NULL,
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

