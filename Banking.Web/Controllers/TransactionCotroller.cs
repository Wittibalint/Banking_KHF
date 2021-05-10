using Banking.data.Entitiy;
using Banking.Service;
using Banking.services;
using Banking.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Web
{
    [Route("/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        IServiceManager serviceManager;
        public TransactionController(IServiceManager service)
        {
            serviceManager = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<Transaction>>> GetTransactionById(int id)
        {
            try
            {
                return Ok(await serviceManager.GetTransactionById(id));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("list")]
        public async Task<ActionResult<ICollection<Transaction>>> GetTransactionsByDateAsync([FromBody] TransactionListJson transaction)
        {
            try
            {
                return Ok(await serviceManager.GetTransactionByDate(transaction.fromDate, transaction.toDate, transaction.accountId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostTransaction([FromBody] TransactionJson transaction)
        {
            try
            {
                Transaction newTransaction = new Transaction()
                {
                    AccountFrom = await serviceManager.GetAccount(transaction.accountFrom),
                    AccountTo = await serviceManager.GetAccount(transaction.accountTo),
                    Amount = transaction.amount,
                    Description = transaction.description
                };

                return Ok(await serviceManager.CreateTransaction(newTransaction));
            }
            catch(Exception e)
            {
                if(e.Message == "Not enough money")
                {
                    return NotFound("Not enough money");
                }
                return NotFound();
            }

        }
    }
}
