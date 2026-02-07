using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class CrmActivity : DomainBase
    {
        /// <summary>
        /// The tenantId correspondant to the Activity   
        /// </summary>
        public string TenantId { get; set; }

        public required string Type { get; set; }

        public required string Title { get; set; }

        public required string Priority { get; set; }

        public int EntityId { get; set; }

        public string ActivityType { get; set; }

        public string Description { get; set; }

        public required DateTime DueDateTime { set; get; }
        public string Note { get; set; }

        public Contact? RelatedContact { set; get; }

        public Account? RelatedAccount { set; get; }

        public User? AssignedUser { set; get; }

    }
}
