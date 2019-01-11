CREATE TABLE [dbo].[Projects] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (MAX) NULL,
    [Developer] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED ([ID] ASC)
);

