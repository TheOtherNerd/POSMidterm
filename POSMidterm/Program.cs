namespace POSMidterm
{
    public class Program
    {
        public static void Main()
        {
            Order o = new Order();
            Menu m = new Menu("",CategoryType.Drink,"", 5);

            m.PrintTable();
            
          
            
        }
    }
}