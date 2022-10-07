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
    public class CustomerDetailController : ControllerBase
    {
        private AppDbContext _context;
        public CustomerDetailController(AppDbContext context)
        {
            _context = context;
        }
       
        [HttpGet("{id}")]
        public ActionResult get(int id)
        {
            var data = _context.CustomerDetails.FirstOrDefault(c => c.customerId == id);
            return Ok(data);
        }
       
        [HttpPost]
        public ActionResult post(CustomerDetail newcust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.CustomerDetails.Add(newcust);

                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public ActionResult put(int? id, CustomerDetail mod)
        {
            if (id == null)
                return NotFound();
            else
            {
                var data = _context.CustomerDetails.FirstOrDefault(c => c.customerId == id);
                data.firstName = mod.firstName;
                data.middleName = mod.middleName;
                data.lastName = mod.lastName;
                data.email = mod.email;
                data.password = mod.password;
                data.phoneNumber = mod.phoneNumber;
                data.dOB = mod.dOB;
                data.gender = mod.gender;
                data.nationality = mod.nationality;
                data.aadharNo = mod.aadharNo;
                data.panNo = mod.panNo;
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
                var data = _context.CustomerDetails.FirstOrDefault(c => c.customerId == id);
                _context.CustomerDetails.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet]
        public ActionResult Get()
        {
            var data = _context.CustomerDetails.ToList();
            return Ok(data);
        }
        [HttpPost("Authenticate")]
        public ActionResult<CustomerDetail> Authenticate(CustomerDetail l)
        {
            var data = _context.CustomerDetails.FirstOrDefault(a => (a.email == l.email && a.password == l.password));
            if (data == null)
            {
                return NotFound("no match");
            }
            return Ok(data);
        }
    }
}