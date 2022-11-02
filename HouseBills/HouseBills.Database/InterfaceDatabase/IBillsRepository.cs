using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBills
{
    public interface IBillsRepository
    {
        Bills AddBill(Bills bill);
        List<Bills> GetAllBills();
    }
}
