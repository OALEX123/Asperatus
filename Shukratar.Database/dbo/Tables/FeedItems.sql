CREATE TABLE [dbo].[FeedItems] (
    [Id]              INT                IDENTITY (1, 1) NOT NULL,
    [Guid]            NVARCHAR (2000)    NULL,
    [Title]           NVARCHAR (500)     NULL,
    [Link]            NVARCHAR (1000)    NULL,
    [Summary]         NVARCHAR (MAX)     NULL,
    [PublishDate]     DATETIMEOFFSET (7) NOT NULL,
    [Author]          NVARCHAR (500)    NULL,
    [FeedId]          INT                NOT NULL,
    [Copyright]       NVARCHAR (500)    NULL,
    [LastUpdatedTime] DATETIMEOFFSET (7) NOT NULL,
    [CreatedDate]     DATETIME           NOT NULL,
    [Description]     NVARCHAR(MAX)      NULL, 
	[Language]        NVARCHAR (30)      NULL,
    CONSTRAINT [PK_dbo.FeedItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.FeedItems_dbo.Feeds_FeedId] FOREIGN KEY ([FeedId]) REFERENCES [dbo].[Feeds] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FeedId]
    ON [dbo].[FeedItems]([FeedId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Link]
    ON [dbo].[FeedItems]([Link] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_PublishDate]
    ON [dbo].[FeedItems]([PublishDate] ASC);

GO
CREATE UNIQUE NONCLUSTERED INDEX [PK_FeedItems_Id]
    ON [dbo].[FeedItems]([Id] ASC);

