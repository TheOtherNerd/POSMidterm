namespace POSMidterm
{
	public class Helper
	{
		public bool RunAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to view the menu again? Please enter y/n");
            string viewAgain = Console.ReadLine().ToLower().Trim();
            if (viewAgain == "y")
            {
                return true;
            }
            else if (viewAgain == "n")
            {
                return false;
            }
            else
            {
                return RunAgain();
            }
        }
	}	
}

