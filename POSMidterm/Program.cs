namespace POSMidterm
{
    public class Program
    {
        static Order o = new Order();
        static Menu m = new Menu();
        static Helper h = new Helper();
        static string paymentMethod;
        static string creditCardNumber;
        static string creditCardMonth;
        static string creditCardYear;
        static string checkNumber;
        static double cashTender;
        static int cvv;
        static int userInput;
        static int desiredQuantity;
        

        public static void Main()
        {

            bool isDiscount = false;

            bool runAgain = true;
            Console.WriteLine("Welcome to our Coffee Shop. Please take a look at our menu. ");
            while (runAgain) //gives user chance to see the menu again for multiple purchaces
            {
                m.PrintTable();
                Console.WriteLine();

                while (true) //failsafe 1 incase of bad inputs for desired item
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
                            while (true) //failsafe 2 incase of bad inputs for quantity of selected item
                            {
                                Console.WriteLine($"Okay, {o.ItemsForSale[userInput - 1].ProductName}. How many would you like to purchase?");
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
                                        break; //ends failsafe 2
                                    }
                                }
                                catch 
                                {
                                    Console.WriteLine("Sorry, that was not a valid input. Please try again.");
                                    continue;
                                }
                            }
                            break; //ends failsafe 1
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
            //picking items to buy ends here move onto paying  
            double grandTotal = o.PrintRecipt(isDiscount);
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
                    else if (paymentMethod == "coupon")
                    {
                        isDiscount = o.isDiscounted();
                        continue;
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
            o.PrintRecipt(isDiscount);
            o.PrintPayment(paymentMethod, creditCardNumber, creditCardMonth, creditCardYear, cvv, checkNumber, cashTender, grandTotal);
            Main();
        }
    }
}