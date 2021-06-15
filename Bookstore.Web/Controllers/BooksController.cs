using Bookstore.Web.Data;
using Bookstore.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookstoreDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksController(BookstoreDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Authors()
            => View(await _context.Books.Select(book => new AuthorViewModel
            {
                AddedDate = book.AddedDate,
                FullName = book.AuthorName
            }).ToListAsync());

        public IActionResult Search(string text)
            => Ok(_context.Books.Select(book => book.AuthorName)
                .FirstOrDefault(c => c.ToLower().Contains(text.ToLower())));

        // GET: Books
        public async Task<IActionResult> Index()
            => View(await _context.Books.ToListAsync());

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
            => View();

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.ImagePath = UploadImage(book.Image);
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var path = UploadImage(book.Image);
                book.ImagePath = string.IsNullOrWhiteSpace(path) ? book.ImagePath : path;

                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return _context.Books.Any(e => e.Id == id) ?
                        View(book) : NotFound();
                }
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                DeleteImage(book.Image);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete));
            }
        }

        private void DeleteImage(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", image.FileName);

                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
        }

        private string UploadImage(IFormFile image)
        {
            string fileName = null;

            if (image != null && image.Length > 0)
            {
                fileName = image.FileName;
                image.CopyTo(new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName), FileMode.Create));
            }

            return fileName;
        }
    }
}