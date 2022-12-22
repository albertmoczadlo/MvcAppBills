﻿
using HouseBills.Domain.Models;

namespace HouseBills
{
    public interface IBillsRepository
    {
        //Bills AddBill(Bills bill);
        Task<IEnumerable<Bill>> GetAllBills();
        void DeleteBill(Bill bill);
        Task<Bill> GetBillById(Guid id);
    }
}
