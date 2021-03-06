using Bookstore.Web.Data;
using Bookstore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookstoreDbContext _context;

        public HomeController(BookstoreDbContext context)
            => _context = context;

        public async Task<IActionResult> Index()
            => View(await _context.Books.ToListAsync());

        public IActionResult Search(string text)
            => View(nameof(Index), _context.Books.Where(book =>
            book.AuthorName.Contains(text) || book.Description.Contains(text) ||
            book.Title.Contains(text) || book.Publisher.Contains(text)));

        public IActionResult Privacy()
            => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}