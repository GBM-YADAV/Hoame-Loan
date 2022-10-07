using System.ComponentModel.DataAnnotations;

namespace Home_Loan_WEB_API.Models
{
    public class PropertyDetail
    {
        [Key]
        public int propertyId { get; set; }
        public int customerId { get; set; }
        public string propertyLocation { get; set; }
        public string propertyName { get; set; }
        public decimal estimatedAmount { get; set; }
    }
}
