using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Activities.DTOs;
using CRM.Domain;

namespace CRM.Application.Core
{
    public class MappingProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                // Define your mappings here
                // Example:
                // CreateMap<SourceType, DestinationType>();
                CreateMap<CrmActivity, CrmActivity>();

                CreateMap<CreateActivityDto, CrmActivity>();
            }
        }
    }
}
