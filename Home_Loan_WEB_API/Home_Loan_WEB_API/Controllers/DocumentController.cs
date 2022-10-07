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
    public class DocumentController : ControllerBase
    {
       
            private readonly AppDbContext _context;

            public DocumentController(AppDbContext context)
            {
                _context = context;
            }


            public ActionResult Get()
            {
                var data = _context.Documents.ToList();
                return Ok(data);
            }
            [HttpGet("{id}")]
            public ActionResult get(int id)
            {
                var data = _context.Documents.FirstOrDefault(p => p.documentId == id);
                return Ok(data);
            }

            [HttpPost]
            public ActionResult post(Document newdoc)
            {
                if (ModelState.IsValid)
                {
                    _context.Documents.Add(newdoc);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                    return BadRequest();
            }

            [HttpPut("{id}")]
            public ActionResult put(int? id, Document modifiedobj)
            {
                if (id == null)
                    return NotFound();
                else
                {// select productId,productname,price  from products where productid=id
                    var data = _context.Documents.FirstOrDefault(p => p.documentId == id);




                    data.customerId = modifiedobj.customerId;
                    data.panCard = modifiedobj.panCard;
                    data.lOA = modifiedobj.lOA;
                    data.salarySlip = modifiedobj.salarySlip;
                    data.nOCFromBuilder = modifiedobj.nOCFromBuilder;
                    data.agreementToSale = modifiedobj.agreementToSale;
                    data.voterId = modifiedobj.voterId;

                    _context.SaveChanges();



                    return Ok();




                }
            }

            [HttpDelete("{id}")]
            public ActionResult delete(int? id)
            {
                var data = _context.Documents.FirstOrDefault(p => p.documentId == id);

                if (data == null)
                {
                    return NotFound();
                }
                else
                {

                    _context.Documents.Remove(data);
                    _context.SaveChanges();
                    return Ok();
                }

            }
        }
    }
