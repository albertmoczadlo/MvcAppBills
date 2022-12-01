
namespace HouseBills.Domain.Models
{
    public class Bills
    {
        public Guid Id { get; set; } 
        public string Month { get; set; }
        public DateTime DateTimePay { get; set; }
        public decimal Sum { get; set; }
        public decimal BlockEnergy { get; set; }
        public decimal Heating { get; set; }
        public decimal ColdWater { get; set; }
        public decimal HeatingWater { get; set; }
        public decimal RenovationFund { get; set; }
    }
}
