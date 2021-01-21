using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class Upsert : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Upsert(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty] public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            // Create
            if (id == null)
            {
                Book = new Book();
                return Page();
            }

            // Update
            Book = await _dbContext.Book.FindAsync(id);
            return Book == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (Book.Id == 0) await _dbContext.Book.AddAsync(Book);
            else _dbContext.Book.Update(Book);
            
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}