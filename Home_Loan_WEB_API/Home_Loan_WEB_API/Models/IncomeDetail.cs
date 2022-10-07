using System;
using System.ComponentModel.DataAnnotations;

namespace Home_Loan_WEB_API.Models
{
    public class IncomeDetail
    {
        [Key]
        public int incomeId { get; set; }
        public int customerId { get; set; }
        public decimal monthlyIncome { get; set; }
        public string typeofEmployment { get; set; }
        public int retirementAge { get; set; }
        public string organizationType { get; set; }
        public string employerName { get; set; }

    }
}
