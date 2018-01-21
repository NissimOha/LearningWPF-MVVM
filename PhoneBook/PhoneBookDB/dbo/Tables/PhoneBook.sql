CREATE TABLE [dbo].[PhoneBook] (
    [Id]          INT           NOT NULL,
    [FirstName]   VARCHAR (50)  NULL,
    [LastName]    VARCHAR (50)  NULL,
    [Address]     VARCHAR (50)  NULL,
    [PhoneNumber] VARCHAR (10)  NULL,
    [Image]       VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Customer_LastName]
    ON [dbo].[PhoneBook]([LastName] ASC);

