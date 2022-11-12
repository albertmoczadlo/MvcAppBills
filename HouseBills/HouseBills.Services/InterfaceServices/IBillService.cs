

namespace HouseBills.Services
{
    public interface IBillService
    {
        void RegisterBill();
        void ShowList();
        IEnumerable<Bills> ShowMonth(string input);
    }
}
