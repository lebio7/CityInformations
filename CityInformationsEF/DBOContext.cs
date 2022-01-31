
using CityInformationsEF.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CityInformationsEF
{
    public class DBOContext : DbContext
    {
        public DbSet<DATA> Data { get; set; }
        public DbSet<DATATYPE> DataType { get; set; }
        public DbSet<DESCR> Descr { get; set; }
        public DbSet<EVENT> Event { get; set; }
        public DbSet<LANGUAGE> Language { get; set; }
        public DbSet<LOCATION> Location { get; set; }
        public DbSet<LOCATIONDATA> LocationData { get; set; }
        public DbSet<NEWS> News { get; set; }
        public DbSet<NEWSDATA   > NewsData { get; set; }
        public DbSet<OBJECTLOCATION> ObjectLocation { get; set; }

        public DBOContext() : base(nameof(DBOContext))
        {
            this.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
