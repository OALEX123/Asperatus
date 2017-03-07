using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Video;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class VideoFileConfiguration : EntityTypeConfiguration<VideoFile>
    {
        public VideoFileConfiguration()
            : this("dbo")
        {
        }

        public VideoFileConfiguration(string schema)
        {
            ToTable(schema + ".VideoFiles");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.VideoId).HasColumnName("VideoId");

            Property(x => x.DownloadUrl).HasColumnName("DownloadUrl");
            Property(x => x.Resolution).HasColumnName("Resolution");
            Property(x => x.AudioBitrate).HasColumnName("AudioBitrate");
            Property(x => x.VideoFormat).HasColumnName("VideoFormat");
            Property(x => x.AudioFormat).HasColumnName("AudioFormat");
            Property(x => x.Is3D).HasColumnName("Is3D");

            HasRequired(a => a.Video).WithMany(b => b.VideoFiles).HasForeignKey(x => x.VideoId);
        }
    }
}