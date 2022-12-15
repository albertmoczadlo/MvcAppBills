
using HouseBills.Domain.Models;
using HouseBills.Infrastructure;

namespace HouseBills
{
    public class BillsRepository : IBillsRepository
    {
        private readonly HouseBillsWebMvcDbContext _mvcDbContext;

        public BillsRepository(HouseBillsWebMvcDbContext mvcDbContext)
        {
            _mvcDbContext= mvcDbContext;
        }

        public List<Bill> GetAllBills()
        {
            List<Bill> bills = _mvcDbContext.Bills.ToList();

            return bills;
        }

        public Bill GetBillById(int id)
        {
            throw new NotImplementedException();
        }




        //public Bills AddBill(Bills bill)
        //{
        //    Guid id = Guid.NewGuid();
        //    var registeredBill = new Bills
        //    {
        //        Id = id,
        //        Month = bill.Month,
        //        DateTimePay = bill.DateTimePay,
        //        Sum = bill.Sum,
        //        BlockEnergy = bill.BlockEnergy,
        //        Heating = bill.Heating,
        //        ColdWater = bill.ColdWater,
        //        HeatingWater = bill.HeatingWater,
        //        RenovationFund = bill.RenovationFund
        //    };

        //    using (StreamWriter file = new StreamWriter(fileName, true))
        //    {

        //        file.WriteLine
        //            ($"{registeredBill.Id};{registeredBill.Month};{registeredBill.DateTimePay};{registeredBill.Sum};"+
        //            $"{registeredBill.BlockEnergy};{registeredBill.Heating};" +
        //             $"{registeredBill.ColdWater};{registeredBill.HeatingWater};" +
        //                $"{registeredBill.RenovationFund}");
        //    }
        //    return registeredBill;
        //}

        ////public List<Bills> GetAllBills()
        ////{
        ////    List<Bills> bills = new List<Bills>();

        ////    var usersFromFile = File.ReadAllLines(fileName);
        ////    foreach (var line in usersFromFile)
        ////    { 
        ////        string[] columns = line.Split(';');
        ////        if(columns.Length==9)
        ////        bills.Add(
        ////            new Bills 
        ////            { 
        ////                Id =Guid.Parse(columns[0]),
        ////                Month = columns[1],
        ////                DateTimePay =columns[2].ToString(), 
        ////                Sum =decimal.Parse(columns[3]),
        ////                BlockEnergy = decimal.Parse(columns[4]),
        ////                Heating = decimal.Parse(columns[5]),
        ////                ColdWater = decimal.Parse(columns[6]),
        ////                HeatingWater = decimal.Parse(columns[7]),
        ////                RenovationFund = decimal.Parse(columns[8])
        ////            });
        ////    }
        ////    return bills;
        ////}
    }
}
