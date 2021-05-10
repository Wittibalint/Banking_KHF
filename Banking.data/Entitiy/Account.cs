using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.data.Entitiy
{
    public class Account
    {
        public Int64 Id { get; set; }
        public DateTime AccountOpenDate { get; set; }
        public int Amount { get; set; }
        public Boolean isActive { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Transaction> TransactionsIn { get; set; }
        public ICollection<Transaction> TransactionsOut { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
