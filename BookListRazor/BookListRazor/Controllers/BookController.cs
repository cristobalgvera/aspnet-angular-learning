using System;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Json(new
        {
            data = await _dbContext.Book.ToListAsync()
        });

        [HttpDelete]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var dbBook = await _dbContext.Book.FindAsync(id);

            if (dbBook == null)
                return Json(new
                {
                    success = false,
                    message = "Error while deleting"
                });
            
            _dbContext.Remove(dbBook);
            await _dbContext.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Delete successful"
            });
        }
    }
}