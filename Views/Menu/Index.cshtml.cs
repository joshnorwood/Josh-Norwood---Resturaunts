using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Resturants.Data;
using Resturants.Models;

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

            var model = new IndexModel(_context)
            {
                Categories = Categories
            };

            return View(model);
        }
    }
}
