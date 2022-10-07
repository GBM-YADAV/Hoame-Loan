using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Home_Loan_WEB_API.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<IncomeDetail> IncomeDetails { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<AdminDetail> AdminDetails { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<PropertyDetail> PropertyDetails { get; set; }
        public DbSet<Applications> ApplicationsSp { get; set; }
        public DbSet<Accounts> AccountsSp { get; set; }
    }
}
