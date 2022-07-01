using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;
using NetCoreWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ITelephoneService _telephoneService;
        private readonly IAddressService _addressService;

        public CustomersController(ICustomerService customerService, ITelephoneService telephoneService, IAddressService addressService)
        {
            _customerService = customerService;
            _telephoneService = telephoneService;
            _addressService = addressService;
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(_customerService.FindAllCustomers());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customerService.FindCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET: api/Customers/details/5
        [HttpGet("details/{id}")]
        public ActionResult<Customer> GetCustomerDetails(int id)
        {
            var customer = _customerService.FindCustomerById(id);
            var telephone = _telephoneService.FindTelephoneByCustomerId(id);
            var address = _addressService.FindAddressByCustomerId(id);

            if (customer == null)
                return NotFound();

            return Ok(new CustomerDTO() { Customer = customer, Telephone = telephone, Address = address });
        }

        // GET: api/Customers/name/fulano
        [HttpGet("name/{name}")]
        public ActionResult<Customer> GetCustomerDetails(string name)
        {
            var customers = _customerService.FindCustomerByName(name);

            if (!customers.Any())
                return NotFound();

            List<CustomerDTO> customersDetails = new List<CustomerDTO>();
            IEnumerable<Telephone> telephone;
            IEnumerable<Address> address;

            foreach (var customer in customers)
            {
                telephone = _telephoneService.FindTelephoneByCustomerId(customer.Id);
                address = _addressService.FindAddressByCustomerId(customer.Id);
                customersDetails.Add(new CustomerDTO() { Customer = customer, Telephone = telephone, Address = address });
            }

            return Ok(customersDetails);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.Id)
                    return BadRequest();

                _customerService.UpdateCustomer(customer);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            try
            {
                _customerService.InsertCustomer(customer);
                return CreatedAtAction("PostCustomer", new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.FindCustomerById(id);

            if (customer == null)
                return NotFound();

            _customerService.DeleteCustomer(id);

            return NoContent();
        }
    }
}
