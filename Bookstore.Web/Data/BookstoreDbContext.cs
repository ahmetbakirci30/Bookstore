using Bookstore.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bookstore.Web.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 1,
                AddedDate = DateTime.Now,
                FullName = "Bilal ÖZTÜRK"
            }, new Author
            {
                Id = 2,
                AddedDate = DateTime.Now,
                FullName = "Ali ÖZTÜRK"
            }, new Author
            {
                Id = 3,
                AddedDate = DateTime.Now,
                FullName = "Evliya ÇELEBİ"
            }, new Author
            {
                Id = 4,
                AddedDate = DateTime.Now,
                FullName = "Mustafa BAKIRCI"
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                AddedDate = DateTime.Now,
                AuthorId = 4,
                Title = "Dart Programming Tutorial For Beginners",
                Description = "My Last Book In Programming Languages.",
                ImagePath = "team-image-2-646x680.jpg"
            }, new Book
            {
                Id = 2,
                AddedDate = DateTime.Now,
                AuthorId = 3,
                Title = "Paython Programming Tutorial For Beginners",
                Description = "My Third Book In Programming Languages.",
                ImagePath = "about-1-570x350.jpg"
            }, new Book
            {
                Id = 3,
                AddedDate = DateTime.Now,
                AuthorId = 2,
                Title = "C# Programming Tutorial For Beginners",
                Description = "My Second Book In Programming Languages.",
                ImagePath = "team-image-1-646x680.jpg"
            }, new Book
            {
                Id = 4,
                AddedDate = DateTime.Now,
                AuthorId = 1,
                Title = "Java Programming Tutorial For Beginners",
                Description = "My First Book In Programming Languages.",
                ImagePath = "team-image-3-646x680.jpg"
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}