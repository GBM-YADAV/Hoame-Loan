using System.ComponentModel.DataAnnotations;
using System;

namespace Home_Loan_WEB_API.Models
{
    public class CustomerDetail
    {
        [Key]
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dOB { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public string aadharNo { get; set; }
        public string panNo { get; set; }
    }
}
