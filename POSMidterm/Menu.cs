using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSMidterm
{
    public class Menu : Product
    {
        public Menu(string ProductName, CategoryType Category, string Desc, double Price) : base(ProductName, Category, Desc, Price)
        {

        }

        public void PrintMenu()
        {
            Order o = new Order();
            for (int i = 0; i < o.ItemsForSale.Count; i++)
            {
                Console.WriteLine($"{i+1} { o.ItemsForSale[i].ProductName}");
            }
        }

        public void PrintInfo()
        {
            Order o = new Order();
            for (int i = 0; i < o.ItemsForSale.Count; i++)
            {
                Console.WriteLine($"{i + 1} { o.ItemsForSale[i].Desc}");
                Console.WriteLine($"{i + 1} { o.ItemsForSale[i].Price}");
            }
        }

    }
}
