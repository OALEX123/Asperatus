using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Shukratar.Domain.Video;
using Shukratar.Domain.Video.Audio;
using YoutubeExtractor;

namespace Shukratar.Shared.VideoHosting.YouTube
{
    public class YouTubeProvider : IYouTubeProvider
    {
        private readonly YouTubeService _youtubeService;

        public YouTubeProvider() : this(Certificate)
        {
        }

        public YouTubeProvider(X509Certificate2 x509Certificate2)
        {
            // const string serviceAccountEmail = "shukratar@shukratar.iam.gserviceaccount.com";
            const string serviceAccountEmail = "asperatus@asperatus-161707.iam.gserviceaccount.com";

            var certificate = x509Certificate2;

            var credential = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = new[] {YouTubeService.Scope.Youtube}
                }.FromCertificate(certificate));

            _youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });
        }

        public static X509Certificate2 Certificate
        {
            get
            {
                //var name = typeof(YouTubeProvider).Namespace + ".Google.Certificate.p12";

                //var names = Assembly.GetExecutingAssembly();

                //var names2 = System.Reflection.Assembly.GetEntryAssembly().
                //    GetManifestResourceNames();

                

                //var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);

                //byte[] bytes;

                //using (var memoryStream = new MemoryStream())
                //{
                //    stream?.CopyTo(memoryStream);
                //    bytes = memoryStream.ToArray();
                //}

                return new X509Certificate2(Shukratar.Shared.Properties.Resources.Google_Certificate_p12, "notasecret",
                    X509KeyStorageFlags.MachineKeySet |
                    X509KeyStorageFlags.PersistKeySet |
                    X509KeyStorageFlags.Exportable);
            }
        }

        public Video Get(string id)
        {
            Trace.TraceInformation("Getting metadata from YouTube for video {0}", id);

            var request = _youtubeService.Videos.List("Statistics,Snippet");

            request.Id = id;

            var response = request.Execute();

            if (response.Items.Count != 1) return null;

            var video = response.Items[0];

            var downloadUrls = DownloadUrlResolver.GetDownloadUrls("https://www.youtube.com/watch?v=" + id);

            return new YouTubeVideo
            {
                ExternalId = id,
                Title = video.Snippet.Title,
                PublishDate = video.Snippet.PublishedAt,
                Description = video.Snippet.Description,

                Statistics = new VideoStatistics
                {
                    CommentCount = Convert.ToInt64(video.Statistics.CommentCount),
                    LikeCount = Convert.ToInt64(video.Statistics.LikeCount),
                    DislikeCount = Convert.ToInt64(video.Statistics.DislikeCount),
                    ViewCount = Convert.ToInt64(video.Statistics.ViewCount),
                    FavoriteCount = Convert.ToInt64(video.Statistics.FavoriteCount)
                },

                VideoFiles = downloadUrls.Select(x => new VideoFile
                {
                    AudioBitrate = x.AudioBitrate,
                    DownloadUrl = x.DownloadUrl,
                    AudioFormat = (AudioFormat) x.AudioType,
                    VideoFormat = (VideoFormat) x.VideoType,
                    Is3D = x.Is3D,
                    Resolution = x.Resolution
                }).ToList()
            };
        }
    }
}