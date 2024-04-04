using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.IService;

namespace WebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersApiController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(_customerService.GetAll());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Customer> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            Customer savedCustomer = _customerService.UpdateCustomer(customer);

            return Ok(savedCustomer);
        }



        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            Customer customerSaved = _customerService.SaveCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = customerSaved.Id }, customerSaved);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_customerService.DeleteCustomer(customer));
        }
    }
}
