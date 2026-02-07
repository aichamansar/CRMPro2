using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Tenant : DomainBase
    {
        /// <summary>
        /// The name of the Tenant
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Yearly Plan or Monthly Plan
        /// </summary>
        public string Plan { get; set; }

        /// <summary>
        /// The status of the tenant
        /// </summary>
        public int Status { get; set; }

    }
}
