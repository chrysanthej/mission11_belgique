namespace mission11_belgique.Models
{
    public interface IBookRepository
    {
        // IQueryable property for accessing the collection of books
        public IQueryable<Book> Books { get; }

    }
}
