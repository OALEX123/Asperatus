using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Website;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class NewsPageConfiguration : EntityTypeConfiguration<NewsPage>
    {
        public NewsPageConfiguration()
            : this("dbo")
        {
        }

        public NewsPageConfiguration(string schema)
        {
            ToTable(schema + ".NewsPages");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int");

            Property(x => x.VideoId).HasColumnName("VideoId").IsOptional().HasColumnType("int");
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasColumnType("datetime");
            Property(x => x.VideoLink).HasColumnName("VideoLink").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Uri).HasColumnName("Uri").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Content).HasColumnName("Content").IsOptional();
            Property(x => x.ContentLength).HasColumnName("ContentLength").IsOptional();
            Property(x => x.ContentType).HasColumnName("ContentType").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional();

            // Foreign keys
            HasRequired(a => a.FeedItem).WithOptional(b => b.NewsPage); // FK_dbo.NewsPages_dbo.FeedItems_Id

        }
    }
}