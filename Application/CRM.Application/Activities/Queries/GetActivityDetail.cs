using CRM.Application.Core;
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
        public class Query : IRequest<Result<CrmActivity>>// Return type
        {
            public required string Id { get; set; } // Parameter of the API
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, Result<CrmActivity>>
        {
            public async Task<Result<CrmActivity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id, cancellationToken);

                if (activity == null) return Result<CrmActivity>.Failure("Cannot find activity", 400);

                return Result<CrmActivity>.Success(activity);

            }
        }
    }
}
