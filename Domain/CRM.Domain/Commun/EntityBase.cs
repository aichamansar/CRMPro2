using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Commun
{
    public class DomainBase
    {
        /// <summary>
        /// The Id of the Activity
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime DeletedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdateDate { get; set; }

        public int IsDeleted { get; set; }
    }
}
