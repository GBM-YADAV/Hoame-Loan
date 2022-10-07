using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Home_Loan_WEB_API.Models;

namespace Home_Loan_Web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminDetailController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult Get()
        {
            var data = _context.AdminDetails.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult get(int id)
        {
            var data = _context.AdminDetails.FirstOrDefault(a => a.adminId == id);
            return Ok(data);
        }

        [HttpPost]
        public ActionResult post(AdminDetail newobj)
        {
            if (ModelState.IsValid)
            {
                _context.AdminDetails.Add(newobj);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult put(int? id, AdminDetail modifiedobj)
        {
            if (id == null)
                return NotFound();
            else
            {// select productId,productname,price  from products where productid=id
                var data = _context.AdminDetails.FirstOrDefault(p => p.adminId == id);




                data.name = modifiedobj.name;
                data.email = modifiedobj.email;
                data.password = modifiedobj.password;


                _context.SaveChanges();



                return Ok();




            }
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int? id)
        {
            var data = _context.AdminDetails.FirstOrDefault(p => p.adminId == id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {

                _context.AdminDetails.Remove(data);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}