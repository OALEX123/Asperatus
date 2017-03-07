using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Syndication;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class FeedConfiguration : EntityTypeConfiguration<Feed>
    {
        public FeedConfiguration()
            : this("dbo")
        {
        }

        public FeedConfiguration(string schema)
        {
            ToTable(schema + ".Feeds");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Title).HasColumnName("Title").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Link).HasColumnName("Link").IsOptional().HasColumnType("nvarchar");
            Property(x => x.LastUpdatedDate).HasColumnName("LastUpdatedDate").IsOptional().HasColumnType("datetime");
            Property(x => x.WebsiteId).HasColumnName("WebsiteId").IsRequired().HasColumnType("int");
            Property(x => x.Status).HasColumnName("Status").IsOptional().HasColumnType("int");
        }
    }
}