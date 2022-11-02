using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBills.Services
{
    public interface IBillService
    {
        void RegisterBill();
        void ShowList();
        IEnumerable<Bills> ShowMonth(string input);
    }
}
