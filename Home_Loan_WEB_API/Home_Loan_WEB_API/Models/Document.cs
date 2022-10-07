using System.ComponentModel.DataAnnotations;

namespace Home_Loan_WEB_API.Models
{
    public class Document
    {
        [Key]
        public int documentId { get; set; }
        public int customerId { get; set; }
        public string panCard { get; set; }
        public string voterId { get; set; }
        public string salarySlip { get; set; }
        public string lOA { get; set; }
        public string nOCFromBuilder { get; set; }
        public string agreementToSale { get; set; }
    }
}
