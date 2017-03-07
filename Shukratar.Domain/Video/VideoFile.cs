using Shukratar.Domain.Video.Audio;

namespace Shukratar.Domain.Video
{
    public class VideoFile
    {
        public int Id { get; set; }

        public int AudioBitrate { get; set; }

        public string DownloadUrl { get; set; }

        public int Resolution { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }

        public bool Is3D { get; set; }

        public AudioFormat AudioFormat { get; set; }

        public VideoFormat VideoFormat { get; set; }

        public string AudioExtension
        {
            get
            {
                switch (AudioFormat)
                {
                    case AudioFormat.Aac:
                        return ".aac";
                    case AudioFormat.Mp3:
                        return ".mp3";
                    case AudioFormat.Vorbis:
                        return ".ogg";
                    default:
                        return null;
                }
            }
        }

        public string VideoExtension
        {
            get
            {
                switch (VideoFormat)
                {
                    case VideoFormat.Mobile:
                        return ".3gp";
                    case VideoFormat.Flash:
                        return ".flv";
                    case VideoFormat.Mp4:
                        return ".mp4";
                    case VideoFormat.WebM:
                        return ".webm";
                    default:
                        return null;
                }
            }
        }
    }
}