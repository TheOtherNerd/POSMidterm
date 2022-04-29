using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSMidterm
{
    public class Order
    {
        public List<Product> ItemsForSale { get; set; } = new List<Product>();
        public List<Product> ItemsPurchased { get; set; } = new List<Product>();

        public Order()
        {
            ItemsForSale.Add(new Product("Coffee", CategoryType.Drink, "Nice hot coffee", 5.99));
            ItemsForSale.Add(new Product("Tea", CategoryType.Drink, "Lemongrass tea", 3.99));
            ItemsForSale.Add(new Product("Cookie", CategoryType.Pastry, "Warm chocolate chip", .99));
            ItemsForSale.Add(new Product("Mug", CategoryType.Merch, "Cup with store logo", 9.99));
            ItemsForSale.Add(new Product("Egg Sandwich", CategoryType.Meal, "Delicious egg sandwich", 7.99));
            ItemsForSale.Add(new Product("Croissant", CategoryType.Pastry, "Warm Cross-ant!", 1.99));
            ItemsForSale.Add(new Product("Espresso", CategoryType.Drink, "Double Shot when you're double tired", 3.99));
            ItemsForSale.Add(new Product("Grilled Cheese", CategoryType.Meal, "Bread, Cheese - Hot", 3.99));
            ItemsForSale.Add(new Product("Insulated Thermos", CategoryType.Merch, "Keep it HOT! (or cold)", 29.99));
            ItemsForSale.Add(new Product("Tea Set", CategoryType.Merch, "Make your own tea! At home or on the go!", 59.99));
            ItemsForSale.Add(new Product("Cupcake", CategoryType.Pastry, "It's a cup, made of cake.", 2.99));
            ItemsForSale.Add(new Product("Bag of Coffee Beans", CategoryType.Drink, "Make your own damn coffee!", 14.99));
        }

        //stores selected products in a list
        public List<Product> AddToCart(int index, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                ItemsPurchased.Add(ItemsForSale[index]);
            }
            return ItemsPurchased;
        }
        // prints items selected for purchace, subtotal, tax (6.5%), and grand total
        public double PrintRecipt()
        {
            Console.WriteLine("Receipt");
            Console.WriteLine("=============");
            double subtotal = 0;
            for (int i = 0; i < ItemsPurchased.Count; i++)
            {
                Console.WriteLine($"{ItemsPurchased[i].ProductName}  ${ItemsPurchased[i].Price}");
                subtotal += ItemsPurchased[i].Price;
            }
            Console.WriteLine();
            Console.WriteLine($"Subtotal:   ${ Math.Round(subtotal, 2)}");
            double taxAmount = .065 * subtotal;
            double grandTotal = subtotal + taxAmount;
            Console.WriteLine($"Tax:        ${Math.Round(taxAmount, 2)}");
            Console.WriteLine($"Total:      ${Math.Round(grandTotal, 2)}");

            return grandTotal;
        }
        //only runs if cash is payment method, returns change
        public double PayByCash(double grandTotal)
        {
            while (true)
            {
                Console.WriteLine($"Your total is ${Math.Round(grandTotal, 2)}");
                Console.WriteLine("What is the total value of the tender you are paying with");
                try
                {
                    double tender = double.Parse(Console.ReadLine());
                    if (tender >= grandTotal)
                    {
                        Console.WriteLine($"Thanks. That's ${Math.Round(tender - grandTotal, 2)} in change coming back to you.");
                        return tender;
                    }
                    else if (tender < grandTotal)
                    {
                        Console.WriteLine($"That's not enough! You still owe ${Math.Round(grandTotal - tender, 2)}. Let's try that again.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid response. Please try again");
                        continue;
                    }


                }
                catch
                {
                    Console.WriteLine("Sorry, that is not a valid response. Please try again.");
                    continue;
                }
            }
        }
        //only runs if credit card was selected as payment, gets a 16 numerical string
        public string GetCreditNumber()
        {
            while (true)
            {
                Console.WriteLine("Please enter your credit card number");
                string creditCardNumber = Console.ReadLine().Trim().ToLower();
                bool isNumeric = double.TryParse($"{creditCardNumber}", out _);

                if (isNumeric && creditCardNumber.Length == 16)
                {
                    return creditCardNumber;
                }
                else
                {
                    Console.WriteLine("That is not a valid credit card number. Please try again.");
                    continue;
                }
            }
        }
        //only runs with card payment method, gets a numerical string of 2
        public string GetCreditCardMonth()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("In which month does your credit card expire? Please enter in MM format.");
                    string creditCardMonth = Console.ReadLine().Trim().ToLower();
                    bool isNumeric = double.TryParse($"{creditCardMonth}", out _);
                    int monthNum = int.Parse(creditCardMonth);

                    if (isNumeric && creditCardMonth.Length == 2 && monthNum <= 12)
                    {
                        return creditCardMonth;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid expiration date. Please try again.");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("That is not a valid expiration date. Please try again.");
                    continue;
                }

            }
        }
        //same as creditCardMonth but with a string of 4
        public string GetCreditCardYear()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("In which year does your credit card expire? Please enter in YYYY format");
                    string creditCardYear = Console.ReadLine().Trim().ToLower();
                    bool isNumeric = double.TryParse($"{creditCardYear}", out _);
                    int yearNum = int.Parse(creditCardYear);

                    if (isNumeric && creditCardYear.Length == 4 && yearNum > 2021)
                    {
                        return creditCardYear;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid expiration date. Please try again.");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("That is not a valid expiration date. Please try again.");
                    continue;
                }
            }
        }
        //gets a 3 digit number, small enough to use int
        public int GetCVV()
        {
            while (true)
            {
                Console.WriteLine("Please enter your CVV");
                try
                {
                    int cvv = int.Parse(Console.ReadLine());
                    return cvv;
                }
                catch
                {
                    Console.WriteLine("That is not a valid CVV, please try again.");
                    continue;
                }
            }
        }
        //only used if payment method is check, checks if string entered is numerical
        public string GetCheckNumber()
        {
            while (true)
            {
                Console.WriteLine("Please enter your check number");
                string checkNumber = Console.ReadLine().ToLower().Trim();
                bool isNumeric = double.TryParse($"{checkNumber}", out _);
                if (isNumeric)
                {
                    return checkNumber;
                }
                else
                {
                    Console.WriteLine("That is not a valid check number. Please try again");
                    continue;
                }
            }
        }
        //Prints payment method for user to review then clears list to be ready for next customer
        public void PrintPayment(string method, string creditCardNumber, string creditCardMonth, string creditCardYear, int cvv, string checkNumber, double cashTender, double grandTotal)
        {
            if (method == "credit")
            {
                Console.WriteLine();
                Console.WriteLine("Payment Method: Credit Card");
                Console.WriteLine($"Card Number:     {creditCardNumber}");
                Console.WriteLine($"Expiration Date: {creditCardMonth} / {creditCardYear}");
                Console.WriteLine($"CVV :            {cvv}");
            }
            else if (method == "check")
            {
                Console.WriteLine();
                Console.WriteLine("Payment Method: Check");
                Console.WriteLine($"Check Number: {checkNumber}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Payment Method: Cash");
                Console.WriteLine($"Amount Tendered: ${cashTender}");
                Console.WriteLine($"Change Due: ${Math.Round(cashTender - grandTotal, 2)}");
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for shopping with us. Press enter to help the next customer.");
            Console.WriteLine();
            Console.ReadLine();
            ItemsPurchased.Clear();
            
        }
    }
}
    


