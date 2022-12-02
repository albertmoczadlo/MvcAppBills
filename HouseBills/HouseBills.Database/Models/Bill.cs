

namespace HouseBills.Domain.Models
{
    public class Bill
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DateTimePay { get; set; }
        public decimal Sum { get; set; }
        public decimal BlockEnergy { get; set; }
        public decimal Heating { get; set; }
        public decimal ColdWater { get; set; }
        public decimal HeatingWater { get; set; }
        public decimal RenovationFund { get; set; }
        public string UserAppId { get; set; }

        public UserApp UserApps { get; set; }



    }
}
