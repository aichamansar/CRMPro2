using AutoMapper;
using CRM.Application.Activities.DTOs;
using CRM.Domain;
using CRM.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Activities.Commands
{
    public class CreateActivity
    {
        public class Command : IRequest<string> // Return type
        {
            public required CreateActivityDto ActivityDto { get; set; } // Parameter of the API
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = mapper.Map<CrmActivity>(request.ActivityDto);

                activity.CreatedBy = "System"; // Set the creator of the activity (you can replace this with actual user info)
                activity.CreatedDate = DateTime.UtcNow; // Set the creation date to the current UTC time
                activity.IsDeleted = 0; // Set the activity as not deleted
                activity.UpdateDate = DateTime.UtcNow.ToString("o"); // Set the update date to the current UTC time in ISO 8601 format
                activity.UpdatedBy = "System"; // Set the updater of the activity (you can replace this with actual user info)
                activity.DeletedDate = DateTime.MinValue;
                activity.DeletedBy = "System";

                context.Activities.Add(activity);

                await context.SaveChangesAsync(cancellationToken);

                return activity.Id; // Return the ID of the created activity
            }
        }
    }
}
