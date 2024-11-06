using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Moddels;
using WebApplication2.Moddels.ViewModels;

namespace WebApplication2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public List<Book> AllBooks { get; set; } = new List<Book>();
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories).ThenInclude(i => i.Book)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

            AllBooks = await _context.Book
            .Include(b => b.Author)
            .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(b => b.Book).ToList();
            }
        }
    }
}
