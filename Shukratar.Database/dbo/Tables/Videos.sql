CREATE TABLE [dbo].[Videos] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Link]          NVARCHAR (4000) NULL,
    [CommentCount]  BIGINT NULL, 
    [LikeCount]     BIGINT NULL, 
    [DislikeCount]  BIGINT NULL, 
    [ViewCount]     BIGINT NULL, 
    [FavoriteCount] BIGINT NULL, 
    [Discriminator] NVARCHAR(1000) NULL, 
    [Title]         NVARCHAR(4000) NULL, 
    [PublishDate]   DATETIME NULL, 
    [Description]   NVARCHAR(MAX) NULL, 
	[CategoryId]    INT NULL,
	[ExternalId]    NVARCHAR (4000) NULL,
    CONSTRAINT [PK_dbo.Videos] PRIMARY KEY CLUSTERED ([Id] ASC),
);


GO
CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].[Videos]([Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Videos_PublishDate]
    ON [dbo].[Videos]([PublishDate] ASC);