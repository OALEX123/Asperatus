using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Category;
using Shukratar.Domain.Category.Intelligence;
using Shukratar.Domain.Syndication;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
            : this("dbo")
        {
        }

        public CategoryConfiguration(string schema)
        {
            ToTable(schema + ".FeedItemCategories");

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map<IntelligentCategory>(x => x.Requires("Discriminator").HasValue("Intelligent"));
            Map<FeedItemCategory>(x => x.Requires("Discriminator").HasValue("FeedItem"));

            Property(x => x.Name).HasColumnName("Name").IsRequired();

            Property(x => x.FeedItemId).HasColumnName("FeedItemId").IsRequired();

            HasRequired(a => a.FeedItem).WithMany(b => b.Categories).HasForeignKey(c => c.FeedItemId);
        }
    }
}