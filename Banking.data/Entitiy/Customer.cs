using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.data.Entitiy
{
    public class Customer
    {
        public int Id { get; set; }
        public DateTime CustomerOpenDate { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public Boolean isDeleted { get; set; }
        public CustomUser customUser { get; set; }

    }
}
