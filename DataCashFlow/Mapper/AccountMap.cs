using System.Data.Entity.ModelConfiguration;
using DataCashFlow.Models;


namespace DataCashFlow.Mapper
{
    public class AccountMap : EntityTypeConfiguration<Accounts>
    {
        public AccountMap()
        {
            ToTable("Accounts");

            HasKey(t => t.AccountId);

            Property(t => t.UserId)
                    .IsRequired();

            Property(t => t.Name)
                    .IsRequired();

            Property(t => t.Cnpj)
                    .IsRequired();

            Property(t => t.Address)
                   .IsRequired();

            Property(t => t.AddressNumber)
                    .IsRequired();

            Property(t => t.AddressNeighborhood)
                   .IsRequired();

            Property(t => t.AddressCity)
                    .IsRequired();

            Property(t => t.AddressState)
                   .IsRequired();

            Property(t => t.AddressCep)
                    .IsRequired();

            Property(t => t.NameUser)
                .IsRequired();

            Property(t => t.Email)
                    .IsRequired();

            Property(t => t.Password1)
                   .IsRequired();

            Property(t => t.Password2)
                    .IsRequired();
        }
    }
}
