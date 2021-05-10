CREATE TABLE [dbo].[TalkSchedule] (
    [StartsAt] DATETIMEOFFSET (7) NOT NULL,
    [EndsAt]   DATETIMEOFFSET (7) NOT NULL,
    [Talk_Id]  UNIQUEIDENTIFIER   NOT NULL,
    [Id]       UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_TalkSchedule] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TalkSchedule_Talk] FOREIGN KEY ([Talk_Id]) REFERENCES [dbo].[Talk] ([Id])
);

