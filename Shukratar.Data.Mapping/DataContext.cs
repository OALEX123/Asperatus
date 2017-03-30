using System.Data.Entity;
using Shukratar.Data.Mapping.Configuration;

namespace Shukratar.Data.Mapping
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            //Database.SetInitializer<DataContext>(new DbInitializer());
            Database.Initialize(true);
        }

        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            //Database.SetInitializer<DataContext>(new DbInitializer());
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FeedConfiguration());
            modelBuilder.Configurations.Add(new FeedItemConfiguration());
            modelBuilder.Configurations.Add(new FeedCategoryConfiguration());
            modelBuilder.Configurations.Add(new FeedCountryConfiguration());
            modelBuilder.Configurations.Add(new NewsPageConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new VideoFileConfiguration());
            modelBuilder.Configurations.Add(new VideoCategoryConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CategoryGramConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}