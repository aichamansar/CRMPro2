using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Activities.DTOs
{
    public class CreateActivityDto
    {
        public string TenantId { get; set; }

        public string Type { get; set; } = "";
       
        public string Title { get; set; } = "";

        public  string Priority { get; set; }

        public int EntityId { get; set; }

        public string ActivityType { get; set; }

        public string Description { get; set; }
        
        public DateTime DueDateTime { set; get; }
                
        public string Note { get; set; }
    }
}
