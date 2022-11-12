using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBills.Services
{
    public class MenuServices
    {
        //BillServices _billServices = new BillServices(new BillsRepository());

        private readonly IBillService _billServices;
        //private readonly IBillsRepository _billsRepository;

        public MenuServices(IBillService billService)
        {
            _billServices = billService;
        }

       
        public void MenuAction()
        {
            Console.WriteLine("Wybierz operacje:");
            Console.WriteLine("1. Dodaj rachunek.");
            Console.WriteLine("2. Sprawdź rachunki za mieszkanie.");
            Console.WriteLine("3. Szukaj po miesiącu");
            Console.WriteLine("4. Rachunki malejąco");
            Console.WriteLine("5. Powrót do menu.");

            int selectOption = int.Parse(Console.ReadLine());

            switch (selectOption)
            {
                case 1:
                    _billServices.RegisterBill();
                    break;
                case 2:
                    _billServices.ShowList();
                    break;
                case 3:

                    while (true)
                    {
                        Console.WriteLine("\nPodaj miesiąc:");
                        string month = Helpers.CheckMonth(Console.ReadLine());

                        var monthList = _billServices.ShowMonth(month);

                        if (monthList.Count() == 0)
                        {
                            Console.WriteLine("Brak wyników\n");
                            break;
                        }

                        Console.WriteLine("\nMiesiąc      Data          Razem        Elekt       Centr       ZimWod       Podgrz      FunRem\n");

                        foreach (var item in monthList)
                        {
                            if (item.Month == month)
                            {
                                Console.WriteLine($"{item.Month}  |  {item.DateTimePay}  |    {item.Sum}  |    {item.BlockEnergy}  |    {item.Heating}  |" +
                                $"   {item.ColdWater}   |    {item.HeatingWater}   |    {item.RenovationFund}  |");
                            }
                        }

                        Console.WriteLine("\nKolejny miesiąc wciśnij y, wyjście n\n");
                        string option = Console.ReadLine();

                        if (option != "y")
                            break;
                    }

                    break;

                default: throw new Exception("Opcja nie istnieje");
            }

            var backToMenu = Helpers.BackToMenu();

            if (backToMenu)
            {
                MenuAction();
            }
            else
            {
                Console.WriteLine("Żegnaj");//new method not defined
            }
        }
    }
}
