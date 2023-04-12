using System;
using System.Collections.Generic;
using System.Linq;
using Resturants.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


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

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.Include(c => c.Meals).ThenInclude(m => m.Note).ToListAsync();
        }
    }
}

