using CRM.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Entity : DomainBase
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
