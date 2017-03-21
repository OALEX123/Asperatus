using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Syndication;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class FeedCategoryConfiguration : EntityTypeConfiguration<FeedCategory>
    {
        public FeedCategoryConfiguration()
            : this("dbo")
        {
        }

        public FeedCategoryConfiguration(string schema)
        {
            ToTable(schema + ".FeedCategories");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
        }
    }
}