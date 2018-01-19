using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnCore.Movie.Services;
using EnCore.Core;
using Microsoft.AspNetCore.Cors;
using EnCore.Movie.Core;

namespace WebNg.Controllers
{

    [Produces("application/json")]
    //[Route("api/[controller]")]
     [EnableCors("AllwAnyOrigin")]
    [Route("api/customer")]
    public class CustomerController : BaseApiController
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/Persons
        [HttpGet]
        public IActionResult Get(QueryRequest query)
        {
            return this.GetHttpResponse(() =>
            {
                var pagingResult = this.customerService.GetCustomers(query);

                return Ok(pagingResult);
                    /// System.Web.HttpContext.Current.Response.Headers.Add("Total-Count", total.ToString());

                    // Response.Headers.Add("Total-Count", pagingResult.ItemCount.ToString());


                    // return Ok(pagingResult.Items);
                });
        }

        //*
        // GET: api/Persons/5
        // [HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.GetHttpResponse(() =>
            {
                var result = this.customerService.GetCustomer(id);

                return Ok(result);
            });
        }

        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            return this.GetHttpResponse(() =>
            {
                this.customerService.AddCustomer(customer);

                return Ok(customer);
            });
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            return this.GetHttpResponse(() =>
            {
                customer.CustomerId = id;

                customerService.ModCustomer(customer);

                return Ok(customer);
            });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.GetHttpResponse(() =>
            {
                this.customerService.DelCustomer(id);

                return Ok(id);
            });
        }
    }
}