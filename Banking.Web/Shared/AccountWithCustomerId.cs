using Banking.data.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service
{
    public class AccountWithCustomerId
    {
        public int customerId { get; set; }
        public Account account { get; set; }
    }
}
