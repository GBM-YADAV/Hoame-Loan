using System.ComponentModel.DataAnnotations;

namespace Home_Loan_WEB_API.Models
{
    public class Applications
    {
        [Key]
        public int applicationId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int customerId  { get; set; }

        public int propertyId { get; set; }
        public int incomeId { get; set; }
        public int DocumentId { get; set; }
        public int tenure { get; set; }
        public decimal loanAmount { get; set; }
        public string loanStatus { get; set; }
    }
}
