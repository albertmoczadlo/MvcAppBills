
using HouseBills.Domain.Models;

namespace HouseBills
{
    public interface IBillsRepository
    {
        //Bills AddBill(Bills bill);
        Task<IEnumerable<Bill>> GetAllBills();

        Task<Bill> GetBillById(string id);
    }
}
