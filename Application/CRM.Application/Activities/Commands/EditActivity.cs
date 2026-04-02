using AutoMapper;
using CRM.Application.Activities.DTOs;
using CRM.Application.Core;
using CRM.Domain;
using CRM.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Activities.Commands
{
    public class EditActivity
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required EditActivityDto Activity { get; set; }
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken);
                
                if(activity == null) return Result<Unit>.Failure("Cannot find activity", 400);

                mapper.Map(request.Activity, activity);

                var result = await context.SaveChangesAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to update activity", 400);

                return Result<Unit>.Success(Unit.Value); 
            }
        }
    }
}
