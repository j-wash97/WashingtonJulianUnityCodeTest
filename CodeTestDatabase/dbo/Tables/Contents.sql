CREATE TABLE [dbo].[Contents] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [ProjID]   INT            NOT NULL,
    [SecID]    INT            NOT NULL,
    [Type]     INT            NOT NULL,
    [Main]     NVARCHAR (MAX) NULL,
    [Sub]      NVARCHAR (MAX) NULL,
    [ImgToken] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Contents] PRIMARY KEY CLUSTERED ([ID] ASC)
);

