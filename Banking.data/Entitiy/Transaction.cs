using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.data.Entitiy
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public Account AccountFrom { get; set; }
        public Account AccountTo { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
