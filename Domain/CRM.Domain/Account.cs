using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Account : DomainBase
    {
        public string TenantId { get; set; }
        public required string Name { get; set; }
        public string OwnerUser { get; set; }

        public string Website { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime LastActivity { get; set; }

    }
}
