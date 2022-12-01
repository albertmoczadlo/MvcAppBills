namespace HouseBills.Application.Services
{
    public static class Helpers
    {
        public static decimal DecimalParse(string input)
        {
            decimal result = 0;
            while (true)
            {
                if (decimal.TryParse(input, out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Złe dane");
                    input = Console.ReadLine();
                }
            }
            return result;
        }
        public static string CheckMonth(string input)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Zły wpis");
                    input = Console.ReadLine();
                }
                else
                {
                    return input;
                }
            }
        }

        public static bool BackToMenu()
        {
            while (true)
            {
                Console.WriteLine("Powrót do menu y/n");
                string select = Console.ReadLine();

                if (select.Equals("y", StringComparison.CurrentCulture))
                {
                    Console.Clear();
                    return true;
                }
                else if (select.Equals("n", StringComparison.CurrentCulture))
                {
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.WriteLine("Zły wybór");
                    select = Console.ReadLine();
                }
            }
        }
    }
}
