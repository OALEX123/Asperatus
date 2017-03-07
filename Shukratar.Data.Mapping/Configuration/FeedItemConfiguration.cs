using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Syndication;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class FeedItemConfiguration : EntityTypeConfiguration<FeedItem>
    {
        public FeedItemConfiguration()
            : this("dbo")
        {
        }

        public FeedItemConfiguration(string schema)
        {
            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Guid).HasColumnName("Guid").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Title).HasColumnName("Title").IsOptional();
            Property(x => x.Link).HasColumnName("Link").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Summary).HasColumnName("Summary").IsOptional();
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.PublishDate).HasColumnName("PublishDate").IsRequired().HasColumnType("datetimeoffset");
            Property(x => x.Author).HasColumnName("Author").IsOptional().HasColumnType("nvarchar");
            Property(x => x.FeedId).HasColumnName("FeedId").IsRequired().HasColumnType("int");
            Property(x => x.Copyright).HasColumnName("Copyright").IsOptional().HasColumnType("nvarchar");

            Property(x => x.LastUpdatedTime)
                .HasColumnName("LastUpdatedTime")
                .IsRequired()
                .HasColumnType("datetimeoffset");

            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasColumnType("datetime");

            Property(x => x.Language.Code).HasColumnName("Language");

            // Foreign keys
            HasRequired(a => a.Feed).WithMany(b => b.FeedItems).HasForeignKey(c => c.FeedId);
            // FK_dbo.FeedItems_dbo.Feeds_FeedId
        }
    }
}