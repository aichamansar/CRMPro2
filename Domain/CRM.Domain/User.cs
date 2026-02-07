using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class User : DomainBase
    {
        /// <summary>
        /// The Id of the Tenant Correspondant to the User
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The status of the tenant
        /// </summary>
        public int IsActive { get; set; }

    }
}
