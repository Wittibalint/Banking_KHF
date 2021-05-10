using Banking.data.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.data.Repository
{
    public class BankingRepository : IBankingRepository

    {
        BankingDbContext BankingDbContext;

        public BankingRepository(BankingDbContext db)
        {
            BankingDbContext = db;
        }


        public async Task<Boolean> DeleteAccountById(Int64 id)
        {
            Account account = await BankingDbContext.Accounts.Select(a => a).Where(a => a.Id == id).SingleAsync();
            account.isActive = false;
            account.isDeleted = true;
            BankingDbContext.Accounts.Update(account);
            await BankingDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteCustomerById(int id)
        {
            Customer customer = await BankingDbContext.Customers.Select(c => c).Where(c => c.Id == id).Include(a => a.Accounts).SingleAsync();
            customer.isDeleted = true;
            customer.Accounts.Select(c => { c.isDeleted = true; return c; }).ToList();
            BankingDbContext.Customers.Update(customer);
            BankingDbContext.SaveChanges();
            return true;
        }

        public async Task<Account> GetAccountById(Int64 id)
        {
            try
            {
                Account account = await BankingDbContext.Accounts.Select(a => a).Where(a => a.Id == id).FirstAsync();
                return account;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<List<Account>> GetAccountByCustomerId(int id)
        {
            try
            {
                List<Account> account = await BankingDbContext.Accounts.Select(a => a).Where(a => a.Customer.Id == id).ToListAsync();
                return account;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Customer> GetCustomerByAccount(Account account)
        {
            try
            {
                Customer customer = await BankingDbContext.Customers.Select(a => a).Where(a => a.Accounts.Contains(account)).FirstAsync();
                return customer;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                Customer customer = await BankingDbContext.Customers.Select(c => c).Where(c => c.Id == id).Include(a => a.Accounts).SingleAsync();
                return customer;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ICollection<Transaction>> GetTransactionsByDate(DateTime from, DateTime to, Int64 accountId)
        {
            List<Transaction> transactions = await BankingDbContext.Transactions.Select(t => t).Where(t => t.TransactionDate >= from && t.TransactionDate <= to && (t.AccountFrom.Id == accountId || t.AccountTo.Id == accountId)).ToListAsync();
            if (transactions.Count() <= 20)
            {
                return transactions;
            }
            return transactions.GetRange(1, 20);
        }

        public async Task<Int64> InsertOrUpdateAccount(Account account)
        {
            if (account.Id == 0)
            {
                BankingDbContext.Accounts.Add(account);
            }
            else
            {
                BankingDbContext.Accounts.Update(account);
            }
            await BankingDbContext.SaveChangesAsync();
            return account.Id;

        }

        public async Task<int> InsertOrUpdateCustomer(Customer customer)
        {
            try
            {
                if (customer.Id == 0)
                {
                    customer.CustomerOpenDate = DateTime.Now;
                    BankingDbContext.Customers.Add(customer);
                }
                else
                {
                    BankingDbContext.Customers.Update(customer);
                }
                await BankingDbContext.SaveChangesAsync();
                return customer.Id;
            }
            catch (Exception e)
            {
                var s = e.Message;
                return 0;
            }

        }

        public async Task<int> InsertTransaction(Transaction transaction)
        {
            transaction.AccountTo.Amount += transaction.Amount;
            transaction.AccountFrom.Amount -= transaction.Amount;
            BankingDbContext.Transactions.Add(transaction);
            await BankingDbContext.SaveChangesAsync();
            return transaction.Id;
        }
        public async Task<Transaction> GetTransactionyId(int id)
        {
            return await BankingDbContext.Transactions.Select(t => t).Where(t => t.Id == id).SingleAsync();
        }
    }
}
