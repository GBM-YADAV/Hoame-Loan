using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Home_Loan_WEB_API.Models;
using System.Security.Principal;

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
        [HttpGet]
        public ActionResult Get()
        {
            var data = _context.CustomerDetails.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult get(int id )
        {
            var data = _context.CustomerDetails.FirstOrDefault(c => c.customerId == id);
            return Ok(data);
        }
        [HttpGet]
        [Route("GetCostomerByPanNo/{panNo}")]
        public ActionResult get(string panNo)
        {
            var data = _context.CustomerDetails.FirstOrDefault(c => c.panNo== panNo);
            return Ok(data);
        }
        [HttpGet]
        [Route("GetCostomerByAadharNo/{aadharNo}")]
        public ActionResult Get(string aadharNo)
        {
            var data = _context.CustomerDetails.FirstOrDefault(c => c.aadharNo == aadharNo);
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
                return CreatedAtAction("get", new { id = newcust.customerId }, newcust);
            }
        }
  
    }
}