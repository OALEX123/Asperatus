using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shukratar.Domain.Video;

namespace Shukratar.Data.Mapping.Configuration
{
    internal class VideoCategoryConfiguration : EntityTypeConfiguration<VideoCategory>
    {
        public VideoCategoryConfiguration()
            : this("dbo")
        {
        }

        public VideoCategoryConfiguration(string schema)
        {
            ToTable(schema + ".VideoCategories");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("Name").IsRequired().HasColumnType("nvarchar");
        }
    }
}