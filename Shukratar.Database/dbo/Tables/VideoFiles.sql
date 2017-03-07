CREATE TABLE [dbo].[VideoFiles]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
	[VideoId] INT NOT NULL, 
    [DownloadUrl] NVARCHAR(4000) NOT NULL, 
    [Resolution] INT NOT NULL, 
    [AudioBitrate] INT NOT NULL,
    [Is3D] BIT NOT NULL, 
    [AudioFormat] INT NOT NULL, 
    [VideoFormat] INT NOT NULL, 
    CONSTRAINT [FK_dbo.VideoFiles_dbo.Videos_Id] FOREIGN KEY ([VideoId]) REFERENCES [dbo].[Videos] ([Id])
)

GO
CREATE NONCLUSTERED INDEX [IX_VideoId]
    ON [dbo].[VideoFiles]([VideoId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Resolution]
    ON [dbo].[VideoFiles]([Resolution] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_AudioBitrate]
    ON [dbo].[VideoFiles]([AudioBitrate] ASC);