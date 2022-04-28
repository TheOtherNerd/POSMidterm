namespace POSMidterm
{
    public class Program
    {
        public static void Main()
        {
            Order o = new Order();
            Menu m = new Menu("",CategoryType.Drink,"", 5);
            int userInput;
            int desiredQuantity;
            

            Console.WriteLine("Welcome to our Coffee Shop. Please take a look at our menu. ");

            m.PrintTable();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("To order an item, please enter the number that corresponds with the desired item.");
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    if (userInput < 0 || userInput > o.ItemsForSale.Count)
                    {
                        Console.WriteLine("Sorry, that was not a valid input. Please try again.");
                        continue;
                    }
                    else
                    {   while (true)
                        {   
                            Console.WriteLine($"How many {o.ItemsForSale[userInput - 1].ProductName}s would you like to purchase?");
                            try
                            {
                                 desiredQuantity = int.Parse(Console.ReadLine());
                                if (desiredQuantity < 1)
                                {
                                    Console.WriteLine("You must enter an integer greater than zero.");
                                    continue;
                                }
                                else
                                {
                                    o.AddToCart(userInput -1, desiredQuantity);
                                }

                                break;
                            }   
                            catch
                            {
                                Console.WriteLine("Sorry, that was not a valid input. Please try again.");
                                continue;
                            }
                        }
                        break;

                    }
                }
                catch
                {
                    Console.WriteLine("Sorry, that was not a valid input. Please try again.");
                    continue;
                }
            }
            double total = 0;
            for (int i = 0; i < o.ItemsPurchased.Count; i++)
            {
                Console.WriteLine(o.ItemsPurchased[i].ProductName);
                total += o.ItemsPurchased[i].Price;
                
            }
            Console.WriteLine($"${ Math.Round(total, 2)}");
            

        }
    }
}