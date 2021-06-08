using System.Data.Entity;

namespace MainApp.Models
{
    class ModelContext : DbContext
    {
        public ModelContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<LeadTeachers> LeadTeachers { get; set; }
        public DbSet<Management> Management { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().ToTable("Students");
        }
    }
}
