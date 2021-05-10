using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.data.Design
{
    internal class BankingDbContextDesign : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args) =>
            new BankingDbContext(new DbContextOptionsBuilder<BankingDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BankingWeb").Options);
    }
}
