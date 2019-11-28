using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.Book
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public UpsertModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Model.Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Model.Book();

            if (!id.HasValue)
            {
                //Create
                return Page();
            }
            
            //Update
            //You can use FindAsync or FirstOrDefaultAsync to get the book from the DB.
            Book = await _dbContext.Books.FindAsync(id);
            //Book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Create or Update
                if (Book.Id == 0)
                {
                    _dbContext.Books.Add(Book);
                }
                else
                {
                    _dbContext.Books.Update(Book);
                }

                await _dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}