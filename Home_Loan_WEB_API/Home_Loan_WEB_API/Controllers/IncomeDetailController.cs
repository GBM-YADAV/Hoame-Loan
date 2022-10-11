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
            
            
                _context.IncomeDetails.Add(newobj);
                _context.SaveChanges();
                return CreatedAtAction("get", new { id = newobj.incomeId }, newobj);
            
        }

        
    }
}
