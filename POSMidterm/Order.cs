namespace POSMidterm
{
    public class Order
    {
        public List<Product> ItemsForSale { get; set; } = new List<Product>();
        public List<Product> ItemsPurchased { get; set; } = new List<Product>();

        public Order()
        {
            ItemsForSale.Add(new Product("Coffee", CategoryType.Drink, "Brewed Fresh Weekly!", 2.99));
            ItemsForSale.Add(new Product("Tea", CategoryType.Drink, "Not suitable for fortune telling.", 1.99));
            ItemsForSale.Add(new Product("Cookie", CategoryType.Pastry, "I'm pretty sure these are chocolate.", .99));
            ItemsForSale.Add(new Product("Mug", CategoryType.Merch, "Handle sold separately.", 9.99));
            ItemsForSale.Add(new Product("Egg Sandwich", CategoryType.Meal, "Delicious egg sandwich.", 7.99));
            ItemsForSale.Add(new Product("Croissant", CategoryType.Pastry, "Warm Cross-ant!", 1.99));
            ItemsForSale.Add(new Product("Espresso", CategoryType.Drink, "Double Shot for when you're double tired.", 3.99));
            ItemsForSale.Add(new Product("Grilled Cheese", CategoryType.Meal, "Bread - Cheese - Heat.", 3.99));
            ItemsForSale.Add(new Product("Insulated Thermos", CategoryType.Merch, "Keep it HOT! (or cold).", 29.99));
            ItemsForSale.Add(new Product("Tea Set", CategoryType.Merch, "Make your own tea! At home or on the go!", 59.99));
            ItemsForSale.Add(new Product("Cupcake", CategoryType.Pastry, "It's a cup (made of cake).", 2.99));
            ItemsForSale.Add(new Product("Bag of Coffee Beans", CategoryType.Drink, "Make your own damn coffee!", 14.99));
            ItemsForSale.Add(new Product("A bird that is definately not fake", CategoryType.Meal, "It's totally real. Stop asking questions.", 404));
        }
        public List<Product> AddToCart(int index, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                ItemsPurchased.Add(ItemsForSale[index]);
            }
            return ItemsPurchased;
        }
        // prints receipt and calculates subtotal, tax, and grand total
        public double PrintRecipt(bool isDiscount)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("            Receipt");
            Console.WriteLine("================================");
            double subtotal = 0;
            for (int i = 0; i < ItemsPurchased.Count; i++)
            {
                String b = String.Format("{0,-25} {1,-25}", ItemsPurchased[i].ProductName, "$" + ItemsPurchased[i].Price);
                Console.WriteLine($"{b}");
                subtotal += ItemsPurchased[i].Price;
            }
            Console.WriteLine();
            Console.WriteLine($"Subtotal:                 ${ Math.Round(subtotal, 2)}");
            if (isDiscount)
            {
                double discount = Math.Round(subtotal * .2, 2);
                Console.WriteLine($"Discount:                 ${discount}");
                subtotal -= discount;
                double taxAmount = .065 * subtotal;
                double grandTotal = subtotal + taxAmount;
                Console.WriteLine($"Tax:                      ${Math.Round(taxAmount, 2)}");
                Console.WriteLine($"Total:                    ${ Math.Round(grandTotal, 2)}");
                Console.ForegroundColor = ConsoleColor.White;
                return grandTotal;
            }
            else
            {
                double taxAmount = .065 * subtotal;
                double grandTotal = subtotal + taxAmount;
                Console.WriteLine($"Tax:                      ${Math.Round(taxAmount, 2)}");
                Console.WriteLine($"Total:                    ${Math.Round(grandTotal, 2)}");
                Console.ForegroundColor = ConsoleColor.White;
                return grandTotal;
            }
        }
        public double PayByCash(double grandTotal)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Your total is ${Math.Round(grandTotal, 2)}");
                Console.WriteLine();
                Console.WriteLine("What is the total value of the tender you are paying with");
                try
                {
                    double tender = double.Parse(Console.ReadLine());
                    if (tender >= grandTotal)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Thanks. That's ${Math.Round(tender - grandTotal, 2)} in change coming back to you.");
                        return tender;
                    }
                    else if (tender < grandTotal)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"That's not enough! You still owe ${Math.Round(grandTotal - tender, 2)}. Let's try that again.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("That is not a valid response. Please try again");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, that is not a valid response. Please try again.");
                    continue;
                }
            }
        }
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
                        Console.WriteLine();
                        Console.WriteLine("That is not a valid expiration date. Please try again.");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not a valid expiration date. Please try again.");
                    continue;
                }
            }
        }
        public string GetCreditCardYear()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine();
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
                        Console.WriteLine();
                        Console.WriteLine("That is not a valid expiration date. Please try again.");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not a valid expiration date. Please try again.");
                    continue;
                }
            }
        }
        public int GetCVV()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your CVV");
                try
                {
                    int cvv = int.Parse(Console.ReadLine());
                    return cvv;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not a valid CVV, please try again.");
                    continue;
                }
            }
        }
        public string GetCheckNumber()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your check number");
                string checkNumber = Console.ReadLine().ToLower().Trim();
                bool isNumeric = double.TryParse($"{checkNumber}", out _);
                if (isNumeric)
                {
                    return checkNumber;
                }
                else
                {
                    Console.WriteLine();
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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
                Console.WriteLine("Payment Method: Credit Card");
                Console.WriteLine($"Card Number: {creditCardNumber}");
                Console.WriteLine($"Expiration Date: {creditCardMonth} / {creditCardYear}");
                Console.WriteLine($"CVV : {cvv}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (method == "check")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
                Console.WriteLine("Payment Method: Check");
                Console.WriteLine($"Check Number: {checkNumber}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (method == "cash")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
                Console.WriteLine("Payment Method:  Cash");
                Console.WriteLine($"Amount Tendered: ${cashTender}");
                Console.WriteLine($"Change Due: \t ${Math.Round(cashTender - grandTotal, 2)}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Payment Method:  Five finger discount.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for shopping with us. Press enter to help the next customer.");
            Console.WriteLine();
            Console.ReadLine();
            ItemsPurchased.Clear();
        }
        public bool isDiscounted()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your coupon code.");
            string coupon = Console.ReadLine().Trim().ToLower();
            if (coupon == "loganisawesome" || coupon == "austinisawesome")
            {
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("That is not a valid coupon code.");
                return false;
            }
        }
    }
}