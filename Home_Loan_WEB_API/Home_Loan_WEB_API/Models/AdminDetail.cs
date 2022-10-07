using System.ComponentModel.DataAnnotations;

namespace Home_Loan_WEB_API.Models
{
    public class AdminDetail
    {
        [Key]
        public int adminId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
