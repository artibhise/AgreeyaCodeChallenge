using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Shared.Helpers;

namespace MVC_Application.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController()
        {
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await HttpClientWrapper<List<Customer>>.Get("https://localhost:7283/api/CustomersApi"));
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(await HttpClientWrapper<Customer>.Get("https://localhost:7283/api/CustomersApi/" + id));
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Password,LoginUser,Email,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer = await HttpClientWrapper<Customer>.PostRequest("https://localhost:7283/api/CustomersApi", customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var customer = await HttpClientWrapper<Customer>.Get("https://localhost:7283/api/CustomersApi/" + id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Password,LoginUser,Email,PhoneNumber")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await HttpClientWrapper<Customer>.PutRequest("https://localhost:7283/api/CustomersApi/" + id, customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var customer = await HttpClientWrapper<Customer>.Get("https://localhost:7283/api/CustomersApi/" + id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await HttpClientWrapper<Customer>.DeleteRequest("https://localhost:7283/api/CustomersApi/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}
