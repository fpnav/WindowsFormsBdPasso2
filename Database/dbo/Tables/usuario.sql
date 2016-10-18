CREATE TABLE [dbo].[usuario] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [nome]  NVARCHAR (50) NOT NULL,
    [email] NVARCHAR (50) NOT NULL,
    [senha] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

