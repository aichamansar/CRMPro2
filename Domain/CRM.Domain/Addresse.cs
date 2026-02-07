using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Addresse : DomainBase
    {
        public string ContactId { get; set; }

        public int EntityId { get; set; }

        public int EntityType { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }

    }
}
