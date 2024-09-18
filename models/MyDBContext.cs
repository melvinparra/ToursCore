using Microsoft.EntityFrameworkCore;

namespace tour.models
{
    public class MyDBContext:DbContext
    {
        public DbSet<Users> Users { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> option): base(option)
        {
                
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("YourConnectionStringHere");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DateOfBirth).IsRequired();
            });
        }
    }
}
