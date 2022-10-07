using Home_Loan_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Home_Loan_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult get()
        {
            var data = _context.ApplicationsSp.FromSqlInterpolated($"dbo.Applications");
            return Ok(data);
        }
        [HttpGet]
        [Route("ApplicationsBystatus")]

        public ActionResult ApplicationsBystatus()
        {
            var data = _context.ApplicationsSp.FromSqlInterpolated($"dbo.ApplicationsByStatus");
            return Ok(data);
        }
    }
}
