namespace POSMidterm
{
    public class Program
    {
        public static void Main()
        {
            Order o = new Order();
            for(int i = 0; i < o.ItemsForSale.Count; i++)
            {
                Console.WriteLine(o.ItemsForSale[i].ProductName);
            }

            
        }
    }
}