using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCashFlow.Models
{
    public class Accounts : BaseModel
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressNeighborhood { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressCep { get; set; }
        public string NameUser { get; set; }
        public string Email { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }

        public Accounts() : base ("Accounts", "AccountId")
        {

        }
    }
}
