using HouseBills.Services;
using System.Security.Cryptography.X509Certificates;

namespace HouseBills
{
    public class BillServices:IBillService
    {
        public  IBillsRepository _billsRepository;
        public BillServices(IBillsRepository billsRepository)
        {
            _billsRepository = billsRepository;
        }

       

        public void RegisterBill()
        {
            Bills bills = new Bills();
            DateTime data = new DateTime();

            //Console.WriteLine("Id:");
            //bills.Id =int.Parse(Console.ReadLine());
            Console.WriteLine($"Data: dd.MM.yyyy");
            var datS = Console.ReadLine();
            var datSS = data.ToString(datS);
            bills.DateTimePay = datSS;
            Console.WriteLine("Miesiąc:");
            bills.Name = Console.ReadLine();
            Console.WriteLine("Razem:");
            bills.Sum = Helpers.DecimalParse(Console.ReadLine());
            //Console.WriteLine("Eksploatacja:");
            //bills.Exploitation = Helpers.DecimalParse(Console.ReadLine());
            //Console.WriteLine("Konserwacja Windy:");
            //bills.ElevatorMaintenance = Helpers.DecimalParse(Console.ReadLine());
            //Console.WriteLine("Opłaty bankowe:");
            //bills.BankCharges = Helpers.DecimalParse(Console.ReadLine());
            //Console.WriteLine("Dzierżawa pojemników:");
            //bills.LeaseContainers = Helpers.DecimalParse(Console.ReadLine());
            Console.WriteLine("Energia elektryczna:");
            bills.BlockEnergy = Helpers.DecimalParse(Console.ReadLine());
            Console.WriteLine("Centralne ogrzewanie:");
            bills.Heating = Helpers.DecimalParse(Console.ReadLine());
            //Console.WriteLine("Opłata smieciowa:");
            //bills.JunkFee = Helpers.DecimalParse(Console.ReadLine());
            Console.WriteLine("Zimna woda:");
            bills.ColdWater = Helpers.DecimalParse(Console.ReadLine());
            Console.WriteLine("Podgrzanie wody:");
            bills.HeatingWater = Helpers.DecimalParse(Console.ReadLine());
            Console.WriteLine("Fundusz remontowy");
            bills.RenovationFund = Helpers.DecimalParse(Console.ReadLine());


            _billsRepository.AddBill(bills);
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



        //public List<User> GetAllUsers()
        //{
        //    List<User> users = new List<User>();

        //    if (!File.Exists(fileName))
        //        return new List<User>();

        //    var usersFromFile = File.ReadAllLines(fileName);
        //    foreach (var line in usersFromFile)
        //    {
        //        var columns = line.Split(';');
        //        Guid.TryParse(columns[0], out var newGuid);
        //        Enum.TryParse(columns[3], out UserRole userRole);
        //        var wallet = new Wallet(columns[4]);
        //        users.Add(new User { Id = newGuid, Login = columns[1], Password = columns[2], Role = userRole, Wallets = wallet });
        //    }
        //    return users;
        //}

        //public User GetUserById(Guid id)
        //{
        //    List<User> users = GetAllUsers();

        //    return users.SingleOrDefault(x => x.Id == id);
        //}

        //public User GetUserByLogin(string login)
        //{
        //    List<User> users = GetAllUsers();

        //    return users.SingleOrDefault(x => x.Login.ToLowerInvariant().Contains(login.ToLowerInvariant()));
        //}

        //public List<User> BrowseUsers(string query)
        //{
        //    List<User> currencies = GetAllUsers();

        //    return currencies.Where(x => x.Login.ToLowerInvariant().Contains(query.ToLowerInvariant())).ToList();
        //}

        //public User GetLoginPassword(string login, string password)
        //{
        //    List<User> users = GetAllUsers();

        //    //var usersFromFile = File.ReadAllLines(fileName);

        //    //foreach (var line in usersFromFile)
        //    //{
        //    //    var columns = line.Split(';');
        //    //    Enum.TryParse(columns[3], out UserRole userRole);
        //    //    if (columns.Length == 5)
        //    //    users.Add(new User { Login = columns[1], Password = columns[2], Id = Guid.Parse(columns[0]),  Role = userRole });
        //    //}

        //    User user = users.FirstOrDefault(x => x.Login == login && x.Password == password);

        //    return user;
        //}
    }
}
