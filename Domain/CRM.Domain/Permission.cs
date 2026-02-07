using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Permission : DomainBase
    {
        /// <summary>
        /// The Id of the Tenant Correspondent to the User
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The role Name
        /// </summary>
        public string PermissionCode { get; set; }

    }
}
