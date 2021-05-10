CREATE TABLE [dbo].[IsAbout] (
    [Talk_Id]  UNIQUEIDENTIFIER NOT NULL,
    [Topic_Id] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_IsAbout_Talk] FOREIGN KEY ([Talk_Id]) REFERENCES [dbo].[Talk] ([Id]),
    CONSTRAINT [FK_IsAbout_Topic] FOREIGN KEY ([Topic_Id]) REFERENCES [dbo].[Topic] ([Id])
);

