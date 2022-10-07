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
        public ActionResult get()
        {
            var data = _context.AccountDetails.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult get(int id)
        {
            var data = _context.AccountDetails.FirstOrDefault(p => p.accountNumber == id);
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
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public ActionResult put(int? id, AccountDetail mod)
        {
            if (id == null)
                return NotFound();
            else
            {
                var data = _context.AccountDetails.FirstOrDefault(c => c.accountNumber == id);
                //data.productid = mod.productid;
                data.balance = mod.balance;
                _context.SaveChanges();

                return Ok();

            }
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int? id)
        {
            if (id == null)
                return NotFound();
            else
            {
                var data = _context.AccountDetails.FirstOrDefault(c => c.accountNumber== id);
                _context.AccountDetails.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}