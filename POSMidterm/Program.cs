namespace POSMidterm
{
    public class Program
    {
        static Order o = new Order();
        static string paymentMethod;
        static string creditCardNumber;
        static string creditCardMonth;
        static string creditCardYear;
        static string checkNumber;
        static double cashTender;
        static int cvv;

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
                    paymentMethod = Console.ReadLine().ToLower().Trim();
                    if (paymentMethod == "cash")
                    {
                        cashTender = o.PayByCash(grandTotal);
                        break;
                    }
                    else if (paymentMethod == "credit")
                    {
                         creditCardNumber = o.GetCreditNumber();
                         creditCardMonth = o.GetCreditCardMonth();
                         creditCardYear = o.GetCreditCardYear();
                         cvv = o.GetCVV();
                        break;
                    }
                    else if (paymentMethod == "check")
                    {
                        checkNumber = o.GetCheckNumber();
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
            Console.WriteLine();
            o.PrintRecipt();
            if (paymentMethod == "credit")
            {
                Console.WriteLine();
                Console.WriteLine("Payment Method: Credit Card");
                Console.WriteLine($"Card Number:     {creditCardNumber}");
                Console.WriteLine($"Expiration Date: {creditCardMonth} / {creditCardYear}");
                Console.WriteLine($"CVV :            {cvv}");
            }
            else if (paymentMethod == "check")
            {
                Console.WriteLine();
                Console.WriteLine("Payment Method: Check");
                Console.WriteLine($"Check Number: {checkNumber}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Payment Method: Cash");
                Console.WriteLine($"Amount Tendered: {cashTender}");
                Console.WriteLine($"Change Due: {Math.Round(cashTender - grandTotal,2)}");
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for shopping with us. Press enter to help the next customer.");
            Console.WriteLine();
            Console.ReadLine();
            o.ItemsPurchased.Clear();
            Main();
        }
    }
}