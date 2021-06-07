using Banking.data.Entitiy;
using Banking.data.Repository;
using Banking.services;
using JWTAuthentication.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace Banking.Web.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IServiceManager serviceManager;
        public CustomerController(IServiceManager service)
        {
            serviceManager = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerByIdAsync(int id)
        {
            try
            {
                return Ok(await serviceManager.GetCustomer(id));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostCustomer([FromBody] Customer customer)
        {
            try
            {
                return Ok(await serviceManager.CreateCustomer(customer));
            }
            catch
            {
                return NotFound();
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> PutCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                return Ok(await serviceManager.ModifyCustomer(customer));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerByIdAsync(int id)
        {
            try
            {
                await serviceManager.DeleteCustomer(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }


        }
    }
}
