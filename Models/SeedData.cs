using System;
using Resturants.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Resturants.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                     serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Seed the Categories table
                if (!context.Categories.Any())
                {
                    var categories = new Category[]
                    {
                    new Category{ ShortDescription = "Appetizers", LongDescription = "Start with one of our delicious appetizers." },
                    new Category{ ShortDescription = "Entrees", LongDescription = "Fill your stomach with one of our hearty entrees." },
                    new Category{ ShortDescription = "Desserts", LongDescription = "End your meal on a sweet note." },
                    };
                    foreach (Category c in categories)
                    {
                        context.Categories.Add(c);
                    }
                    context.SaveChanges();
                }

                // Seed the Meals table
                if (!context.Meals.Any())
                {
                    var meals = new Meal[]
                    {
                    new Meal{ Name = "Caesar Salad", Price = 9.99M, CategoryID = 1 },
                    new Meal{ Name = "Mozzarella Sticks", Price = 7.99M, CategoryID = 1 },
                    new Meal{ Name = "Buffalo Wings", Price = 9.99M, CategoryID = 1},
                    new Meal{ Name = "Broccoli Chicken Alfredo", Price = 16.99M, CategoryID = 2 },
                    new Meal{ Name = "Chocolate Cake", Price = 6.99M, CategoryID = 3 },
                    new Meal{ Name = "Cheesecake", Price = 7.99M, CategoryID = 3 },
                    };
                    foreach (Meal m in meals)
                    {
                        context.Meals.Add(m);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
