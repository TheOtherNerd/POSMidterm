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
        public void PrintTable()
        {
            //spaces used to allign items
            Order o = new Order();
            o.ItemsForSale[0].ProductName = "1. Coffee                ";
            o.ItemsForSale[1].ProductName = "2. Tea                   ";
            o.ItemsForSale[2].ProductName = "3. Cookies               ";
            o.ItemsForSale[3].ProductName = "4. Mug                   ";
            o.ItemsForSale[4].ProductName = "5. Egg Sandwich          ";
            o.ItemsForSale[5].ProductName = "6. Croissant             ";
            o.ItemsForSale[6].ProductName = "7. Espresso              ";
            o.ItemsForSale[7].ProductName = "8. Grilled Cheese        ";
            o.ItemsForSale[8].ProductName = "9. Insulated Thermos     ";
            o.ItemsForSale[9].ProductName = "10. Tea Set              ";
            o.ItemsForSale[10].ProductName = "11. Cupcake              ";
            o.ItemsForSale[11].ProductName = "12. Bag of Coffee Beans   ";
      

            Console.WriteLine();
            Console.Write("Item" + "\t\t\t\t\t" + "Price" + "\t\t  " + "Description");
            Console.WriteLine();
            Console.Write("=======" +"\t\t\t\t\t" + "======" + "\t\t  " + "=================");
            Console.WriteLine();
            for (int i = 0; i < o.ItemsForSale.Count; i++)
            {
                Console.WriteLine(o.ItemsForSale[i].ProductName + "\t\t" + o.ItemsForSale[i].Price + "\t\t  " + o.ItemsForSale[i].Desc);
            }
            o.ItemsForSale[0].ProductName = "Coffee";
            o.ItemsForSale[1].ProductName = "Tea";
            o.ItemsForSale[2].ProductName = "Cookie";
            o.ItemsForSale[3].ProductName = "Mug";
            o.ItemsForSale[4].ProductName = "Egg Sandwich";
            o.ItemsForSale[5].ProductName = "Croissant";
            o.ItemsForSale[6].ProductName = "Espresso";
            o.ItemsForSale[7].ProductName = "Grilled Cheese";
            o.ItemsForSale[8].ProductName = "Insulated Thermos";
            o.ItemsForSale[9].ProductName = "Tea Set";
            o.ItemsForSale[10].ProductName = "Cupcake";
            o.ItemsForSale[11].ProductName = "Bag of Coffee";
        }
    }
}
   

