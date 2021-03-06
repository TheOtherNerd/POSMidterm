namespace POSMidterm
{
    public enum CategoryType
    {
        Drink,
        Pastry,
        Merch,
        Meal
    }

    public class Product
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
