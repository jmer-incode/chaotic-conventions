CREATE TABLE [dbo].[Convention] (
    [Name]     NVARCHAR (MAX)   NOT NULL,
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Venue_Id] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Convention] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Convention_Venue] FOREIGN KEY ([Venue_Id]) REFERENCES [dbo].[Venues] ([Id])
);



