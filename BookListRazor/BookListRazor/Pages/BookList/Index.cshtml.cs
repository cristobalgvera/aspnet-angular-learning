using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet() => Books = await _dbContext.Book.ToListAsync();

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var dbBook = await _dbContext.Book.FindAsync(id);

            if (dbBook == null) return NotFound();

            _dbContext.Remove(dbBook);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}