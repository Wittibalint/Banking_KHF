using Banking.data.Entitiy;
using Banking.Service;
using Banking.services;
using Banking.Web.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Web
{
    [Route("/transaction")]
    [Authorize]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        IServiceManager serviceManager;
        public TransactionController(IServiceManager service)
        {
            serviceManager = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionJson>> GetTransactionById(int id)
        {
            try
            {
                Transaction transaction = await serviceManager.GetTransactionById(id);
                TransactionJson response = new TransactionJson()
                {
                    id = transaction.Id,
                    accountFrom = transaction.AccountFrom.Id,
                    accountTo = transaction.AccountTo.Id,
                    amount = transaction.Amount,
                    description = transaction.Description
                };
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("list")]
        public async Task<ActionResult<ICollection<Transaction>>> GetTransactionsByDateAsync(Int64 accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                if(toDate == DateTime.MinValue)
                {
                    toDate = DateTime.Now;
                }
                return Ok(await serviceManager.GetTransactionByDate(fromDate, toDate, accountId));
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
            catch
            {
                return NotFound();
            }

        }
    }
}
