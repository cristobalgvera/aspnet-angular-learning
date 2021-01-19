using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class Edit : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Edit(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty] public Book Book { get; set; }

        public async Task OnGet(int id) => Book = await _dbContext.Book.FindAsync(id);

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dbBook = await _dbContext.Book.FindAsync(Book.Id);
            dbBook.Name = Book.Name;
            dbBook.Author = Book.Author;
            dbBook.ISBN = Book.ISBN;

            await _dbContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}