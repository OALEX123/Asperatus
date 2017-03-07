using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Video;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
            : this("dbo")
        {
        }

        public VideoConfiguration(string schema)
        {
            ToTable(schema + ".Videos");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map<YouTubeVideo>(x => x.Requires("Discriminator").HasValue("YouTube"));

            Property(x => x.Link).HasColumnName("Link").IsOptional().HasColumnType("nvarchar");

            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.Title).HasColumnName("Title");
            Property(x => x.PublishDate).HasColumnName("PublishDate");
            Property(x => x.ExternalId).HasColumnName("ExternalId");

            Property(x => x.Statistics.ViewCount).HasColumnName("ViewCount");
            Property(x => x.Statistics.CommentCount).HasColumnName("CommentCount");
            Property(x => x.Statistics.DislikeCount).HasColumnName("DislikeCount");
            Property(x => x.Statistics.FavoriteCount).HasColumnName("FavoriteCount");
            Property(x => x.Statistics.LikeCount).HasColumnName("LikeCount");

            // Foreign keys
            HasMany(a => a.NewsPages).WithOptional(b => b.Video).HasForeignKey(x => x.VideoId);
            HasOptional(a => a.VideoCategory).WithMany(b => b.Videos).HasForeignKey(x => x.CategoryId);
        }
    }
}