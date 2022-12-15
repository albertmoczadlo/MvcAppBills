
using HouseBills.Domain.Models;

namespace HouseBills
{
    public interface IBillsRepository
    {
        //Bills AddBill(Bills bill);
        List<Bill> GetAllBills();

        Bill GetBillById(Guid id);
    }
}
