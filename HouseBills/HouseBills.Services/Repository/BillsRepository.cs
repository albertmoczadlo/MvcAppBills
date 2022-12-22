
using HouseBills.Domain.Models;
using HouseBills.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HouseBills
{
    public class BillsRepository : IBillsRepository
    {
        private readonly HouseBillsWebMvcDbContext _mvcDbContext;

        public BillsRepository(HouseBillsWebMvcDbContext mvcDbContext)
        {
            _mvcDbContext= mvcDbContext;
        }

        public async Task<IEnumerable<Bill>>  GetAllBills()
        {
            var bills =await _mvcDbContext.Bills.ToListAsync();

            return bills;
        }
        public async Task<Bill> GetBillById(Guid id)
        {
            var bill = await _mvcDbContext.Bills.FindAsync(id);

            return bill;
        }

        public void DeleteBill(Bill bill)
        {
            _mvcDbContext.Remove(bill);

            _mvcDbContext.SaveChangesAsync();
        }

    }
}
