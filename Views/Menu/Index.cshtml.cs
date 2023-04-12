using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturants.Models;


namespace Resturants.Views.Menu
{
	public class Index
	{
        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Categories
                .Include(c => c.Meals)
                .ThenInclude(m => m.Notes)
                .ToListAsync();

            return Page();
        }

    }
}

