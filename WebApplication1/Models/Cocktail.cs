namespace BartenderApp.Models
{
    public class Cocktail
    {
        public Dictionary<string, double> Menu { get; set; }
        public List<string> Orders { get; set; }

        public Cocktail()
        {
            Menu = new Dictionary<string, double>
            {
                { "Mojito", 10.0 },
                { "Martini", 12.0 },
                { "Margarita", 11.0 }
            };
            Orders = new List<string>();
        }

        public void AddOrder(string cocktailName)
        {
            Orders.Add(cocktailName);
        }
    }
}