using System.ComponentModel.DataAnnotations;
using System;

namespace Home_Loan_WEB_API.Models
{
    public class AccountDetail
    {
        [Key]
        public Int64 accountNumber { get; set; }
        public decimal balance { get; set; }
        public int customerId { get; set; }
    }
}
