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
    public class IncomeDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IncomeDetailController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult Get()
        {
            var data = _context.IncomeDetails.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult get(int id)
        {
            var data = _context.IncomeDetails.FirstOrDefault(p => p.incomeId == id);
            return Ok(data);
        }

        [HttpPost]
        public ActionResult post(IncomeDetail newobj)
        {
            if (ModelState.IsValid)
            {
                _context.IncomeDetails.Add(newobj);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult put(int? id, IncomeDetail modifiedobj)
        {
            if (id == null)
                return NotFound();
            else
            {// select productId,productname,price  from products where productid=id
                var data = _context.IncomeDetails.FirstOrDefault(p => p.incomeId== id);



               
                data.monthlyIncome = modifiedobj.monthlyIncome;
                data.typeofEmployment=modifiedobj.typeofEmployment;
                data.retirementAge=modifiedobj.retirementAge;
                data.organizationType=modifiedobj.organizationType;
                data.employerName=modifiedobj.employerName;

                _context.SaveChanges();



                return Ok();




            }
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int? id)
        {
            var data = _context.IncomeDetails.FirstOrDefault(p => p.incomeId == id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {

                _context.IncomeDetails.Remove(data);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
