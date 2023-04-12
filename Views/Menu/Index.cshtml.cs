using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Resturants.Models;
using Resturants.Data;


namespace Resturants.Views.Menu
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Categories
                .Include(c => c.Meals)
                .ThenInclude(m => m.Note)
                .ToListAsync();

            return Page();
        }
    }
}
