using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/Book")] //This is the route that was configure in the endpoint of the configure Startup
    [ApiController] //This will flag this controller as an API Controller.
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _dbContext.Books.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}