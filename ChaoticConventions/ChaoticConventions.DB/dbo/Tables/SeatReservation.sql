CREATE TABLE [dbo].[SeatReservation] (
    [User_Id]               UNIQUEIDENTIFIER NOT NULL,
    [Convention_Id]         UNIQUEIDENTIFIER NOT NULL,
    [UserConventionRole_Id] UNIQUEIDENTIFIER NOT NULL,
    [Seat_Id]               UNIQUEIDENTIFIER NOT NULL,
    [TalkSchedule_Id]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_SeatReservation_Convention] FOREIGN KEY ([Convention_Id]) REFERENCES [dbo].[Convention] ([Id]),
    CONSTRAINT [FK_SeatReservation_Seat] FOREIGN KEY ([Seat_Id]) REFERENCES [dbo].[Seat] ([Id]),
    CONSTRAINT [FK_SeatReservation_TalkSchedule] FOREIGN KEY ([TalkSchedule_Id]) REFERENCES [dbo].[TalkSchedule] ([Id]),
    CONSTRAINT [FK_SeatReservation_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_SeatReservation_UserConventionRole] FOREIGN KEY ([UserConventionRole_Id]) REFERENCES [dbo].[UserConventionRole] ([Id])
);

