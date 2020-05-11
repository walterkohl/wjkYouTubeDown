CREATE TABLE [dbo].[Translate] (
    [ID]    INT              IDENTITY (1, 1) NOT NULL,
    [Form]  VARCHAR (100)    NOT NULL,
    [Lang]  VARCHAR (10)     NOT NULL,
    [Key]   VARCHAR (100)    NOT NULL,
    [Value] VARCHAR(1000) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

