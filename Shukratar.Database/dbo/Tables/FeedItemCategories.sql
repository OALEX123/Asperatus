CREATE TABLE [dbo].[FeedItemCategories]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(200) NOT NULL, 
    [FeedItemId] INT NOT NULL, 
	[Discriminator] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_dbo.FeedItemCategories_dbo.FeedItems_Id] FOREIGN KEY ([FeedItemId]) REFERENCES [dbo].[FeedItems] ([Id])
)

GO
CREATE NONCLUSTERED INDEX [IX_Discriminator]
    ON [dbo].[FeedItemCategories]([Discriminator] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[FeedItemCategories]([Name] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_FeedItemId_Discriminator] 
	ON [dbo].[FeedItemCategories] ([FeedItemId], [Discriminator]) INCLUDE ([Id], [Name]) WITH (ONLINE = ON)