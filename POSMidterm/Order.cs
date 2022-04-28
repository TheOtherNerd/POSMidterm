using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSMidterm
{
    public class Order
    {
        public List<Product> ItemsForSale { get; set; } = new List<Product>();

        public Order()
        {
            ItemsForSale.Add(new Product("Coffee", CategoryType.Drink, "Nice hot coffee",5.99));
            ItemsForSale.Add(new Product("Tea", CategoryType.Drink, "Lemongrass tea", 3.99));
            ItemsForSale.Add(new Product("Cookies", CategoryType.Pastry, "Warm chocolate chip", .99));
            ItemsForSale.Add(new Product("Mug", CategoryType.Merch, "Cup with store logo", 9.99));
            ItemsForSale.Add(new Product("Egg Sandwich", CategoryType.Meal, "Delicious egg sandwich", 7.99));

        }
    }
}
