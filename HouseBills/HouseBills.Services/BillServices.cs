﻿using HouseBills.Services;
using System.Security.Cryptography.X509Certificates;

namespace HouseBills
{
    public class BillServices:IBillService
    {

        private  IBillsRepository _billsRepository;
        private Bills _bills; 

        public BillServices(IBillsRepository billsRepository, Bills bills)
        {
            _billsRepository = billsRepository;
            _bills = bills;
        }

        public void RegisterBill()
        { 
            DateTime data = new DateTime();
           
            Console.WriteLine($"Data: dd.MM.yyyy");
            var datConsole = Console.ReadLine();
            var datFormat = data.ToString(datConsole);
            _bills.DateTimePay = datFormat;

            Console.WriteLine("Miesiąc:");
            _bills.Name = Console.ReadLine();

            Console.WriteLine("Razem:");
            _bills.Sum = Helpers.DecimalParse(Console.ReadLine());

            Console.WriteLine("Energia elektryczna:");
            _bills.BlockEnergy = Helpers.DecimalParse(Console.ReadLine());

            Console.WriteLine("Centralne ogrzewanie:");
            _bills.Heating = Helpers.DecimalParse(Console.ReadLine());
           
            Console.WriteLine("Zimna woda:");
            _bills.ColdWater = Helpers.DecimalParse(Console.ReadLine());

            Console.WriteLine("Podgrzanie wody:");
            _bills.HeatingWater = Helpers.DecimalParse(Console.ReadLine());

            Console.WriteLine("Fundusz remontowy");
            _bills.RenovationFund = Helpers.DecimalParse(Console.ReadLine());


            _billsRepository.AddBill(_bills);
        }
        public void ShowList()
        {
            List<Bills> list = _billsRepository.GetAllBills();

            Console.WriteLine("   Miesiąc   Data       Razem    Elekt   Centr   ZimWod  Podgrz  FunRem\n");

            foreach(Bills bill in list)
            {
                Console.WriteLine($" {bill.ToString()}");
            }
            Console.WriteLine("");
        }

        public IEnumerable<Bills> ShowMonth(string input)
        {
            List<Bills> list = _billsRepository.GetAllBills();
            
            var listMonth = list.Where(x => x.Name == input).OrderByDescending(x=>x.Sum);

            
            return  listMonth;
        }

        public static bool GetBackToMainMenuQuestion()
        {
            while (true)
            {
                Console.WriteLine("Go back to menu? Y/N");

                var selectedOption = Console.ReadLine();
                if (selectedOption.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else if (selectedOption.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Wrong option");
                }
            }
        }
    }
}
