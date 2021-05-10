using Banking.data.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Banking.data.Repository
{
    public interface IBankingRepository
    {
        Task<Account> GetAccountById(Int64 id);
        Task<Int64> InsertOrUpdateAccount(Account account);
        Task<Boolean> DeleteAccountById(Int64 id);
        Task<Customer> GetCustomerById(int id);
        Task<int> InsertOrUpdateCustomer(Customer customer);
        Task<Boolean> DeleteCustomerById(int id);
        Task<int> InsertTransaction(Transaction transaction);
        Task<ICollection<Transaction>> GetTransactionsByDate(DateTime from, DateTime to, Int64 accountId);
        Task<List<Account>> GetAccountByCustomerId(int id);
        Task<Customer> GetCustomerByAccount(Account account);
        Task<Transaction> GetTransactionyId(int id);
    }
}
