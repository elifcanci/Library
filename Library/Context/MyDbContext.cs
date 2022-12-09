using Library.Configurations;
using Library.Initializer;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
            modelBuilder.ApplyConfiguration(new OperationConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            // Author
            //modelBuilder.Entity<Author>().Property(X => X.FirstName).HasColumnName("İsim");
            //modelBuilder.Entity<Author>().Property(X => X.FirstName).IsRequired(); Alanı zorunlu yapar

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
  