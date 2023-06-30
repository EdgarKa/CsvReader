using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetRestAPI.Models;
using AspNetRestAPI.Data;

namespace AspNetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomerController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit([FromBody]Customer user)
        {
            _context.Customers.Add(user);
            _context.SaveChanges();
            return new JsonResult(Ok(user));
        }

        //Get
        [HttpGet("/{CustomerReference}")]
        public JsonResult Get(string CustomerReference)
        {
            var result = _context.Customers.Find(CustomerReference);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Get All
        [HttpGet("/getall")]
        public JsonResult GetAll()
        {
            var result = _context.Customers.ToList();
            return new JsonResult(Ok(result));
        }
    }
}
