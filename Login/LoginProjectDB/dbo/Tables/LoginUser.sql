CREATE TABLE [dbo].[LoginUser] (
    [UserId]      INT          NOT NULL,
    [FirstName]   VARCHAR (30) NULL,
    [LastName]    VARCHAR (30) NULL,
    [Address]     VARCHAR (50) NULL,
    [PhoneNumber] NCHAR (10)   NULL,
    [Email]       VARCHAR (50) NULL,
    [UserName]    VARCHAR (20) NOT NULL,
    [Password]    VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    UNIQUE NONCLUSTERED ([UserId] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC)
);

