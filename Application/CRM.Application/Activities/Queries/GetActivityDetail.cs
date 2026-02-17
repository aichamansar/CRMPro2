using CRM.Domain;
using CRM.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Activities.Queries
{
    public class GetActivityDetail
    {
        public class Query : IRequest<CrmActivity>// Return type
        {
            public required string Id { get; set; } // Parameter of the API
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, CrmActivity>
        {
            public async Task<CrmActivity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id, cancellationToken);

                if (activity == null) throw new Exception("Activity not found");

                return activity;

            }
        }
    }
}
