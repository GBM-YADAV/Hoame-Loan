using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Home_Loan_WEB_API.Models;

namespace Home_Loan_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailController : ControllerBase
    {
        private AppDbContext _context;
        public AccountDetailController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAccountsList")]
        public ActionResult get()
        {
            var data = _context.AccountDetails.ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("GetAccountById/{id}")]
        public ActionResult get(int id)
        {
            var data = _context.AccountDetails.FirstOrDefault(p => p.accountNumber == id);
            return Ok(data);
        }
        [HttpGet]
        [Route("GetMaxId")]
        public ActionResult GetMaxId()
        {
            var data=_context.AccountDetails.Max(p => p.accountNumber);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult post(AccountDetail newaccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.AccountDetails.Add(newaccount);
                _context.SaveChanges();
                return CreatedAtAction("get", new { id = newaccount.accountNumber }, newaccount);
            }
        }
       
    }
}