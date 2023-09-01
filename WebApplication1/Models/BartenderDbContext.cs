using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BartenderApp.Models
{
    public class BartenderDbContext : DbContext
    {
        public BartenderDbContext(DbContextOptions<BartenderDbContext> options)
            : base(options)
        {
        }

        // DbSet for the cocktail menu table
        public DbSet<CocktailMenu> CocktailMenus { get; set; }

        // DbSet for the orders table
        public DbSet<Order> Orders { get; set; }
    }

    // Class to represent a record in the cocktail menu table
    public class CocktailMenu
    {
        public int Id { get; set; }
        public string? CocktailName { get; set; }
        public double Price { get; set; }
    }

    // Class to represent a record in the orders table
    public class Order
    {
        public int OrderId { get; set; }
        public string? CocktailName { get; set; }
    }
}

