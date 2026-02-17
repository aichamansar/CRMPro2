using CRM.Domain;
using CRM.Persistence;
using MediatR;
using AutoMapper;
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
        public class Command : IRequest
        {
            public required CrmActivity Activity { get; set; }
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken)
                    ?? throw new Exception("Cannot find activity");
                              
                mapper.Map(request.Activity, activity);

                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
