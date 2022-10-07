using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Home_Loan_WEB_API.Models
{
    public class LoanDetail
    {
        [Key]
        public int applicationId { get; set; }
        public int customerId { get; set; }
        public int propertyId { get; set; }

        public int incomeId { get; set; }
        public int tenure { get; set; }
        public decimal loanAmount { get; set; }
        public int documentId { get; set; }
        public string loanStatus { get; set; }

    }
}
