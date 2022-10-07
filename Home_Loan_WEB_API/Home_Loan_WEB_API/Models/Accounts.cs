using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Home_Loan_WEB_API.Models
{
    public class Accounts
    {
        [Key]
        public Int64 accountNumber { get; set; }
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public  string phoneNumber { get; set; }
        public decimal balance { get; set; }
    }
}
