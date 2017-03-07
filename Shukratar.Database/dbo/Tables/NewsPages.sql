CREATE TABLE [dbo].[NewsPages] (
    [Id]           INT             NOT NULL,
    [VideoId]      INT             NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [VideoLink]    NVARCHAR (4000) NULL,
    [Uri]          NVARCHAR (4000) NULL,
    [Content]      NVARCHAR (MAX)  NULL,
    [ContentType]  NVARCHAR(1000)  NULL, 
    [ContentLength] BIGINT NULL,
	[Status]       INT             NULL,
    CONSTRAINT [PK_dbo.NewsPages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.NewsPages_dbo.FeedItems_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[FeedItems] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].[NewsPages]([Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Status]
    ON [dbo].[NewsPages]([Status] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_VideoId]
    ON [dbo].[NewsPages]([VideoId] ASC);

