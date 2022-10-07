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
    public class LoanDetailController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LoanDetailController(AppDbContext context)

        {
            _context = context;
        }


        public ActionResult Get()
        {
            var data = _context.LoanDetails.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult get(int id)
        {
            var data = _context.LoanDetails.FirstOrDefault(p => p.applicationId == id);
            return Ok(data);
        }

        [HttpPost]
        public ActionResult post(LoanDetail newproduct)
        {
            if (ModelState.IsValid)
            {
                _context.LoanDetails.Add(newproduct);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult put(int? id, LoanDetail modifiedobj)
        {
            if (id == null)
                return NotFound();
            else
            {// select productId,productname,price  from products where productid=id
                var data = _context.LoanDetails.FirstOrDefault(p => p.applicationId == id);





                data.tenure = modifiedobj.tenure;
                data.loanAmount = modifiedobj.loanAmount;
               
                data.loanStatus = modifiedobj.loanStatus;


                _context.SaveChanges();



                return Ok();




            }
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int? id)
        {
            var data = _context.LoanDetails.FirstOrDefault(p => p.applicationId== id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {

                _context.LoanDetails.Remove(data);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
    