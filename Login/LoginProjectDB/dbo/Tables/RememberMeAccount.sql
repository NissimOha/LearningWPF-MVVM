CREATE TABLE [dbo].[RememberMeAccount] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (20) NULL,
    [Password] VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

