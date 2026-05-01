using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace CRM.Domain
{
    public class User : IdentityUser
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

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime DeletedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdateDate { get; set; }

        public int IsDeleted { get; set; }

        public string? DisplayName { get; set; }

        public string? Bio { get; set; }

        public string? ImageUrl { get; set; }

        public string? SecondName { get; set; }


    }
}
