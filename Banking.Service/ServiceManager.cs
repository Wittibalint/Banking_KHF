using Banking.data.Entitiy;
using Banking.data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace Banking.services
{
    public class ServiceManager : IServiceManager
    {
        private IBankingRepository repository;

        public ServiceManager(IBankingRepository repo)
        {
            repository = repo;
        }

        public async Task<long> CreateAccount(Account account)
        {
            if (account.Customer.isDeleted == false)
            {
                account.AccountOpenDate = DateTime.Now;
                account.isActive = true;
                account.isDeleted = false;
                return await repository.InsertOrUpdateAccount(account);
            }
            else
            {
                throw new Exception("Customer has been deleted");
            }
        }

        public async Task<int> CreateCustomer(Customer customer)
        {
            return await repository.InsertOrUpdateCustomer(customer);
        }

        public async Task<int> CreateTransaction(Transaction transaction)
        {
            if (!transaction.AccountFrom.isActive||transaction.AccountFrom.Customer.isDeleted
                || !transaction.AccountTo.isActive || transaction.AccountTo.Customer.isDeleted)
            {
                throw new Exception("Customer has been deleted");
            }
            else if(transaction.Amount > transaction.AccountFrom.Amount){
                throw new Exception("Not enough money");
            }
            return await repository.InsertTransaction(transaction);
        }

        public async Task DeleteAccount(Int64 id)
        {
            await repository.DeleteAccountById(id);
        }

        public async Task DeleteCustomer(int id)
        {
            await repository.DeleteCustomerById(id);
        }

        public async Task<Account> GetAccount(Int64 id)
        {
            return await repository.GetAccountById(id);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await repository.GetCustomerById(id);
        }


        public async Task<ICollection<Transaction>> GetTransactionByDate(DateTime fromDate, DateTime toDate, Int64 accountId)
        {
            return await repository.GetTransactionsByDate(fromDate, toDate, accountId);
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await repository.GetTransactionyId(id);
        }

        public async Task<long> ModifyAccount(Account account)
        {
            if (account.Customer.isDeleted == true)
            {
                throw new Exception("Customer has been deleted");
            }
            Account oldAccount = await repository.GetAccountById(account.Id);
            oldAccount.Amount = account.Amount;
            oldAccount.Customer = account.Customer;
            oldAccount.isActive = account.isActive;
            return await repository.InsertOrUpdateAccount(oldAccount);
        }

        public async Task<int> ModifyCustomer(Customer customer)
        {
            if(customer.isDeleted == true)
            {
                throw new Exception("Customer has been deleted");
            }
            Customer oldCustomer = await repository.GetCustomerById(customer.Id);
            oldCustomer.Email = customer.Email;
            oldCustomer.Address = customer.Address;
            oldCustomer.IdentificationNumber = customer.IdentificationNumber;
            oldCustomer.Name = customer.Name;
            oldCustomer.Type = customer.Type;
            return await repository.InsertOrUpdateCustomer(oldCustomer);
        }
    }
}
