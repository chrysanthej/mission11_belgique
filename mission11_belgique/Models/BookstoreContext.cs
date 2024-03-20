using Microsoft.EntityFrameworkCore;

namespace mission11_belgique.Models
{
    // Represents the database context for the bookstore application
    public class BookstoreContext : DbContext

    {
        // Constructor to initialize the context with options
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }
        
        // DbSet representing the collection of books in the database
        public DbSet<Book> Books { get; set; }
    }
}
