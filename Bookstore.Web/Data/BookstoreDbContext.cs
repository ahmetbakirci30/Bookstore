using Bookstore.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Web.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                AuthorName = "Bilal ÖZTÜRK",
                Title = "Dart Programming Tutorial For Beginners",
                Description = "My Last Book In Programming Languages.",
                Publisher = "Time Magazine",
                ImagePath = "team-image-2-646x680.jpg"
            }, new Book
            {
                Id = 2,
                AuthorName = "Mustafa Kaslı",
                Title = "Paython Programming Tutorial For Beginners",
                Description = "My Third Book In Programming Languages.",
                Publisher = "The Cut",
                ImagePath = "about-1-570x350.jpg"
            }, new Book
            {
                Id = 3,
                AuthorName = "Ahmet Demir",
                Title = "C# Programming Tutorial For Beginners",
                Description = "My Second Book In Programming Languages.",
                Publisher = "The Next Web",
                ImagePath = "team-image-1-646x680.jpg"
            }, new Book
            {
                Id = 4,
                AuthorName = "Leyla ÖZTÜRK",
                Title = "Java Programming Tutorial For Beginners",
                Description = "My First Book In Programming Languages.",
                Publisher = "BBC TV",
                ImagePath = "team-image-3-646x680.jpg"
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}