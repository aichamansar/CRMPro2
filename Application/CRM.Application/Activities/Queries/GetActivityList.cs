using CRM.Application.Core;
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
        public class Query : IRequest<Result<List<CrmActivity>>> { }

        public class Handler(AppDbContext context) : IRequestHandler<Query, Result<List<CrmActivity>>>
        {
            public async Task<Result<List<CrmActivity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await context.Activities.ToListAsync(cancellationToken);
                if (result == null || !result.Any())
                {
                    return Result<List<CrmActivity>>.Failure("No activities found", 404);
                }
                return Result<List<CrmActivity>>.Success(result);
            }
        }
    }
}
