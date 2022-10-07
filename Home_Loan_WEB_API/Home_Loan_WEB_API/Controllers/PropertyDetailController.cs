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
    public class PropertyDetailController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PropertyDetailController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult get()
        {
            var data = _context.PropertyDetails.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult get(int id)
        {
            var data = _context.PropertyDetails.FirstOrDefault(p => p.propertyId == id);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult post(PropertyDetail newproperty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.PropertyDetails.Add(newproperty);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public ActionResult put(int? id, PropertyDetail mod)
        {
            if (id == null)
                return NotFound();
            else
            {
                var data = _context.PropertyDetails.FirstOrDefault(c => c.propertyId == id);
                //data.productid = mod.productid;
                data.propertyLocation = mod.propertyLocation;
                data.propertyName = mod.propertyName;
                data.estimatedAmount = mod.estimatedAmount;
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
                var data = _context.PropertyDetails.FirstOrDefault(c => c.propertyId == id);
                _context.PropertyDetails.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}