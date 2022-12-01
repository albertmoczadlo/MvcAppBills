
namespace HouseBills
{
    public interface IBillsRepository
    {
        Bills AddBill(Bills bill);
        List<Bills> GetAllBills();
    }
}
