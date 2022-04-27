using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSMidterm
{
    public enum CategoryType
    {
        Drink,
        Pastry,
        Merch,
        Meal
    }

    public /*abstract*/ class Product
    {
        public string ProductName { get; set; }
        public CategoryType Category { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }

        public Product(string ProductName, CategoryType Category, string Desc, double Price)
        {
            this.ProductName = ProductName;
            this.Category = Category;
            this.Desc = Desc;
            this.Price = Price;
        }

    }
}
