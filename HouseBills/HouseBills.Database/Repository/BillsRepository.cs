﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBills
{
    public class BillsRepository: IBillsRepository
    {

        private readonly string fileName = @"C:\Users\Albert\source\repos\HouseBills\rachunek.csv";

        public Bills AddBill(Bills bill)
        {
            Guid id = Guid.NewGuid();
            var registeredBill = new Bills
            {
                Id = id,
                Name = bill.Name,
                DateTimePay = bill.DateTimePay,
                Sum = bill.Sum,
                Exploitation = bill.Exploitation,
                ElevatorMaintenance = bill.ElevatorMaintenance,
                BankCharges = bill.BankCharges,
                LeaseContainers = bill.LeaseContainers,
                BlockEnergy = bill.BlockEnergy,
                Heating = bill.Heating,
                JunkFee = bill.JunkFee,
                ColdWater = bill.ColdWater,
                HeatingWater = bill.HeatingWater,
                RenovationFund = bill.RenovationFund
            };

            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                
                file.WriteLine
                    ($"{registeredBill.Id};{registeredBill.Name};{registeredBill.DateTimePay};{registeredBill.Sum};"+
                    $"{registeredBill.BlockEnergy};{registeredBill.Heating};" +
                     $"{registeredBill.ColdWater};{registeredBill.HeatingWater};" +
                        $"{registeredBill.RenovationFund}");
            }
            return registeredBill;
        }

        

        public List<Bills> GetAllBills()
        {
            List<Bills> bills = new List<Bills>();

            var usersFromFile = File.ReadAllLines(fileName);
            foreach (var line in usersFromFile)
            { 
                string[] columns = line.Split(';');
                if(columns.Length==9)
                bills.Add(
                    new Bills 
                    { 
                        Id =Guid.Parse(columns[0]),
                        Name = columns[1],
                        DateTimePay =columns[2], 
                        Sum =decimal.Parse(columns[3]),
                        //Exploitation = decimal.Parse(columns[3]),
                       // ElevatorMaintenance = decimal.Parse(columns[4]),
                        //BankCharges = decimal.Parse(columns[5]),
                        //LeaseContainers = decimal.Parse(columns[6]),
                        BlockEnergy = decimal.Parse(columns[4]),
                        Heating = decimal.Parse(columns[5]),
                        //JunkFee = decimal.Parse(columns[9]),
                        ColdWater = decimal.Parse(columns[6]),
                        HeatingWater = decimal.Parse(columns[7]),
                        RenovationFund = decimal.Parse(columns[8])
                    });
            }
            return bills;
        }

    }
}
