using Microsoft.AspNetCore.Mvc;
using mission11_belgique.Models;
using mission11_belgique.Models.ViewModels;
using System.Diagnostics;

namespace mission11_belgique.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var blah = new BookListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip(pageSize * (pageNum - 1))
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };
            return View(blah);
        }
    }
}
