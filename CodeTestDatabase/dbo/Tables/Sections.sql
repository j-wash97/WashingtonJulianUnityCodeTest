CREATE TABLE [dbo].[Sections] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [ProjID]            INT            NOT NULL,
    [SecTitle]          NVARCHAR (MAX) NULL,
    [BackgroundImgPath] NVARCHAR (MAX) NULL,
    [BckgrndImgToken]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Sections] PRIMARY KEY CLUSTERED ([ID] ASC)
);

