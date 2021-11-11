using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCashFlow.Models
{
    public class Context : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Database.SetInitializer<Context>(null);
            modelBuilder.Configurations.Add(new Mapper.AccountMap());

        }

        public Context() : base ("CashContext")
        {

        }
    }
}
