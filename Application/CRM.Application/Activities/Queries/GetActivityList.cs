using CRM.Domain;
using CRM.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Activities.Queries
{
    public class GetActivityList
    {
        public class Query : IRequest<List<CrmActivity>> { }

        public class Handler(AppDbContext context) : IRequestHandler<Query, List<CrmActivity>>
        {
            public async Task<List<CrmActivity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
