CREATE FULLTEXT INDEX ON [dbo].[FeedItems]
(
	[Title] LANGUAGE 1049,
	[Summary] LANGUAGE 1049,
	[Description] LANGUAGE 1049
)
KEY INDEX [PK_FeedItems_Id]
ON [FeedItems_Catalog];