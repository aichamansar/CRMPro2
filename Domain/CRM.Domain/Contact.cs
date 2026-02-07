using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Contact :  DomainBase
    {
        public string TenantId { get; set; }
        public string ContactId { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string OwnerUser { get; set; }

    }
}
