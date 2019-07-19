using GraphQL.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Book>().HasKey(a => a.BookId);

            //Vztah M:N
            modelBuilder.Entity<AuthorBook>()
                        .HasKey(ab => new { ab.AuthorId, ab.BookId });
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Author)
                                                .WithMany(a => a.CreatedBooks)
                                                .HasForeignKey(ab => ab.AuthorId);
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Book)
                                                .WithMany(b => b.Authors)
                                                .HasForeignKey(ab => ab.BookId);
        }
    }
}
