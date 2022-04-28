namespace POSMidterm
{
    public class Program
    {
        static Order o = new Order();
        public static void Main()
        {
            
            Menu m = new Menu("",CategoryType.Drink,"", 5);
            Helper h = new Helper();
            int userInput;
            int desiredQuantity;
            bool runAgain = true;
            
            Console.WriteLine("Welcome to our Coffee Shop. Please take a look at our menu. ");
            while (runAgain)
            {
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
                        {

                            while (true)
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
                                        o.AddToCart(userInput - 1, desiredQuantity);
                                        Console.WriteLine($"Okay, that'll be ${Math.Round(desiredQuantity * o.ItemsForSale[userInput - 1].Price, 2)}");
                                        Console.WriteLine();
                                        break;
                                    }
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
                runAgain = h.RunAgain();
            }
                
                double grandTotal = o.PrintRecipt();
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("How would you like to pay? We accept cash, credit, and checks.");
                    try
                    {
                        string paymentMethod = Console.ReadLine().ToLower().Trim();
                        if (paymentMethod == "cash")
                        {
                            o.PayByCash(grandTotal);
                            break;
                        }
                        else if (paymentMethod == "credit")
                        {
                        string creditCardNumber = o.GetCreditNumber();
                        string creditCardMonth = o.GetCreditCardMonth();
                        string creditCardYear = o.GetCreditCardYear();
                        int cvv = o.GetCVV();
                            break;
                        }
                        else if(paymentMethod == "check")
                        {
                            //add method for paying with check
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, I didn't understand, please try again.");
                            continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Sorry, that is not a valid entry. Please try again.");
                        continue;
                    }
                }

            
            



           

        }
    }
}