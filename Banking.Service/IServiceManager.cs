using Banking.data.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Banking.services
{
    public interface IServiceManager
    {
        Task<int> CreateCustomer(Customer customer);
        Task<int> ModifyCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task DeleteCustomer(int id);
        Task<Int64> CreateAccount(Account account);
        Task<Int64> ModifyAccount(Account account);
        Task<Account> GetAccount(Int64 id);
        Task DeleteAccount(Int64 id);
        Task<int> CreateTransaction(Transaction transaction);
        Task<ICollection<Transaction>> GetTransactionByDate(DateTime fromDate, DateTime toDate, Int64 accountId);
        Task<Transaction> GetTransactionById(int id);
    }
}
