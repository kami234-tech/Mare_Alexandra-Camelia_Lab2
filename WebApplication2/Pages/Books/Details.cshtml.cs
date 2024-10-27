using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Moddels;

namespace WebApplication2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailsModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;
        public IEnumerable<BookCategory> BookCategories { get; set; } = Enumerable.Empty<BookCategory>();


        public async Task<IActionResult> OnGetAsync(int? id)
        {
           
            var book = await _context.Book
                .Include(b => b.Author)
                .Include(i => i.BookCategories)
                .ThenInclude(bc=>bc.Category)
               .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
                BookCategories = book.BookCategories;
            }
            return Page();
        }
    }
}
