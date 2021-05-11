CREATE TABLE [dbo].[Room] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (MAX)   NOT NULL,
    [Capacity] INT              NOT NULL,
    [Venue_Id] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Room_Venue] FOREIGN KEY ([Venue_Id]) REFERENCES [dbo].[Venues] ([Id])
);



