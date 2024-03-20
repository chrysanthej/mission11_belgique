namespace mission11_belgique.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookstoreContext _context;

        // Constructor to initialize the repository with a database context
        public EFBookRepository(BookstoreContext temp)
        {
            _context = temp;
        }

        // IQueryable property for accessing the collection of books in the database
        public IQueryable<Book> Books => _context.Books;
    }
}
