using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service
{
    public class TransactionJson
    {
        public int id { get; set; }
        public Int64 accountFrom { get; set; }
        public Int64 accountTo { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
    }
}
