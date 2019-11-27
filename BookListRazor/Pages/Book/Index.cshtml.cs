using System.Collections.Generic;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Model.Book> Books { get; set; }


        public async Task OnGet()
        {
            Books = await _dbContext.Books.ToListAsync();
        }
    }
}