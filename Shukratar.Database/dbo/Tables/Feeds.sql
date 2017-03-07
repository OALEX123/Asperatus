CREATE TABLE [dbo].[Feeds] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (4000) NULL,
    [Description]     NVARCHAR (4000) NULL,
    [Link]            NVARCHAR (4000) NULL,
    [WebsiteId]       INT             NOT NULL,
    [LastUpdatedDate] DATETIME        NULL,
    [Status] INT NULL, 
    CONSTRAINT [PK_dbo.Feeds] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT UC_Link UNIQUE ([Link])
);


GO
CREATE NONCLUSTERED INDEX [IX_WebsiteId]
    ON [dbo].[Feeds]([WebsiteId] ASC);

