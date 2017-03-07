CREATE TABLE [dbo].[CategoryGrams]
(
	[Id] INT IDENTITY (1, 1)  NOT NULL PRIMARY KEY,
    [Category] NVARCHAR (200) NOT NULL,
	[Gram] NVARCHAR (200) NOT NULL, 
    [Weight] FLOAT NOT NULL
)

GO
CREATE NONCLUSTERED INDEX [IX_Gram] ON [dbo].[CategoryGrams]([Gram] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Gram_Category] 
	ON [dbo].[CategoryGrams] ([Gram]) INCLUDE ([Category]) WITH (ONLINE = ON)