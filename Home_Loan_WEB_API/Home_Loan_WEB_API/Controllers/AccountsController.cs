using Home_Loan_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Home_Loan_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult get()
        {
            var data = _context.AccountsSp.FromSqlInterpolated($"dbo.Accounts");
            return Ok(data);
        }
    }
}
