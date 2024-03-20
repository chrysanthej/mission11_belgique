namespace mission11_belgique.Models.ViewModels
{
    // ViewModel for displaying a list of books with pagination information
    public class BookListViewModel
    {
        // Collection of books to display
        public IQueryable<Book> Books { get; set; }

        // Pagination information for the book list
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    }
}
