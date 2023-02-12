using api.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Library.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book_Rental> Book_Rentals { get; set; }
        public DbSet<Members> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=root;password=Hakim13579");
            Console.WriteLine("db con hit");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ISBN);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Publisher)
                .WithMany(p => p.Books);
            });
            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Date_of_Birth).IsRequired();
            });
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Date_of_Birth).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Salary).IsRequired();
            });
            modelBuilder.Entity<Book_Rental>(entity =>
            {
                entity.HasKey(cs => new { cs.MemberId, cs.BookId });
            });
        }
    }
}