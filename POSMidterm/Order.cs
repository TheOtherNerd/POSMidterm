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
        public List<Product> ItemsPurchased { get; set; } =  new List<Product>();

        public Order()
        {
            ItemsForSale.Add(new Product("Coffee", CategoryType.Drink, "Nice hot coffee",5.99));
            ItemsForSale.Add(new Product("Tea", CategoryType.Drink, "Lemongrass tea", 3.99));
            ItemsForSale.Add(new Product("Cookie", CategoryType.Pastry, "Warm chocolate chip", .99));
            ItemsForSale.Add(new Product("Mug", CategoryType.Merch, "Cup with store logo", 9.99));
            ItemsForSale.Add(new Product("Egg Sandwich", CategoryType.Meal, "Delicious egg sandwich", 7.99));
            ItemsForSale.Add(new Product("Croissant", CategoryType.Pastry, "Warm Cross-ant!", 1.99));
            ItemsForSale.Add(new Product("Espresso", CategoryType.Drink, "Double Shot when you're double tired", 3.99));
            ItemsForSale.Add(new Product("Grilled Cheese", CategoryType.Meal, "Bread, Cheese - Hot", 3.99));
            ItemsForSale.Add(new Product("Insulated Thermos", CategoryType.Merch, "Keep it HOT! (or cold)", 29.99));
            ItemsForSale.Add(new Product("Tea Set", CategoryType.Merch, "Make your own tea! At home or on the go!", 59.99));
            ItemsForSale.Add(new Product("Cupcake", CategoryType.Pastry, "It's a cup, made of cake.", 2.99));
            ItemsForSale.Add(new Product("Bag of Coffee Beans", CategoryType.Drink, "Make your own damn coffee!", 14.99));
        }

        public List<Product> AddToCart(int index, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                ItemsPurchased.Add(ItemsForSale[index]);
            }
            return ItemsPurchased;
        }

        public double PrintRecipt()
        {
            Console.WriteLine("Receipt");
            Console.WriteLine("=============");
            double subtotal = 0;
            for (int i = 0; i < ItemsPurchased.Count; i++)
            {
                Console.WriteLine(ItemsPurchased[i].ProductName);
                subtotal += ItemsPurchased[i].Price;
            }
            Console.WriteLine($"Subtotal: ${ Math.Round(subtotal, 2)}");
            double taxAmount = .065 * subtotal;
            double grandTotal = subtotal + taxAmount;
            Console.WriteLine($"Tax: {Math.Round(taxAmount, 2)}");
            Console.WriteLine($"Total: {Math.Round(grandTotal, 2)}");
            
            return grandTotal;
        }
    }
}


