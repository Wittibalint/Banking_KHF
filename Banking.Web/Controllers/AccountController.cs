using Banking.data.Entitiy;
using Banking.Web.Shared;
using Banking.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Service;
using Microsoft.AspNetCore.Authorization;

namespace Banking.Web
{
    [Route("/account")]
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IServiceManager serviceManager;
        public AccountController(IServiceManager service)
        {
            serviceManager = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountByIdAsync(Int64 id)
        {
            try
            {
                return Ok(await serviceManager.GetAccount(id));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostAccount([FromBody] AccountWithCustomerId account)
        {
            try
            {
                account.account.Customer = await serviceManager.GetCustomer(account.customerId);
                return Ok(await serviceManager.CreateAccount(account.account));
            }
            catch
            {
                return NotFound();
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> PutAccountWithCustomer(Int64 id, [FromBody] AccountWithCustomerId account)
        {
            try
            {
                account.account.Customer = await serviceManager.GetCustomer(account.customerId);
                return Ok(await serviceManager.ModifyAccount(account.account));
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }
        [HttpPut("account/{id}")]
        public async Task<ActionResult<int>> PutAccount(Int64 id, [FromBody] Account account)
        {
            account.Customer = await serviceManager.GetCustomer(account.Customer.Id);
            try
            {
                return Ok(await serviceManager.ModifyAccount(account));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccountByIdAsync(Int64 id)
        {
            try
            {
                await serviceManager.DeleteAccount(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }


        }
    }
}
