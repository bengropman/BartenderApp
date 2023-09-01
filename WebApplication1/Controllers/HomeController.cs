using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BartenderApp.Models;

namespace BartenderApp.Controllers
{
    public class HomeController : Controller
    {
        private Cocktail cocktailModel;

        public HomeController(BartenderDbContext context)
        {
            _context = context;
            cocktailModel = new Cocktail();
        }

        public IActionResult Index()
        {
  
            return View();
        }

        public IActionResult Menu()
        {
            var menu = _context.CocktailMenus.ToList();
            var dictionaryMenu = menu.ToDictionary(x => x.CocktailName, x => x.Price);
            return View(dictionaryMenu);
        }

        [HttpPost]
        public IActionResult PlaceOrder(string cocktailName)
        {
            _context.Orders.Add(new Order { CocktailName = cocktailName });
            _context.SaveChanges();
            return RedirectToAction("Menu");
        }
        [HttpPost]
        public IActionResult CompleteOrder(int OrderID)
        {
            var orderToComplete = _context.Orders.Find(OrderID);
            if (orderToComplete != null)
            {
                _context.Orders.Remove(orderToComplete);
                _context.SaveChanges();
            }
            return RedirectToAction("Orders");
        }

        public IActionResult Orders()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }
        private readonly BartenderDbContext _context;

    }
}