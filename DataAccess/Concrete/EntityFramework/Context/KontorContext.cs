using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class KontorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-DITR34S;Database=kontorapi123;Trusted_Connection=true");/*Amine_Local*/
            optionsBuilder.UseSqlServer(@"Server=192.168.99.13\KONTORDB;Database=KontorApi;User Id = sa; Password = GthpsE3Zq2WWymyA;"); /*Yayın*/            
            // optionsBuilder.UseSqlServer("Data Source=DESKTOP-DITR34S;Integrated Security=True;")
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<UserCredit> UserCredits { get; set; }
        public DbSet<DiscountGroup> DiscountGroups { get; set; }
        public DbSet<UserDiscountGroup> UserDiscountGroups { get; set; }
        public DbSet<UseCredit> UseCredits { get; set; }
    }
}
