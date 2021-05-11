CREATE TABLE [dbo].[Venues] (
    [Id]      UNIQUEIDENTIFIER CONSTRAINT [DF_Venues_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Name]    NVARCHAR (MAX)   NOT NULL,
    [Address] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED ([Id] ASC)
);

