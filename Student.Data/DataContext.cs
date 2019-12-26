using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student.Data.Entities;

namespace Student.Data
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        private string connectionString ;

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonUserMap> ClassUserMaps { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //public DataContext(string connStr): base()
        //{
        //    connectionString = connStr;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonUserMap>()
                .HasOne(i => i.User)
                .WithMany(c => c.ClassUserMaps)
                .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
