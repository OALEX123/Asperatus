using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Category.Intelligence;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class CategoryGramConfiguration : EntityTypeConfiguration<CategoryGram>
    {
        public CategoryGramConfiguration()
            : this("dbo")
        {
        }

        public CategoryGramConfiguration(string schema)
        {
            ToTable(schema + ".CategoryGrams");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Category).HasColumnName("Category").IsRequired().HasColumnType("nvarchar");
            Property(x => x.Gram).HasColumnName("GramStatistics").IsRequired().HasColumnType("nvarchar");
            Property(x => x.Count).HasColumnName("Weight").IsRequired().HasColumnType("float");
        }
    }
}