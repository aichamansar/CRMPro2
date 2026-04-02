using CRM.Application.Activities.Commands;
using CRM.Application.Activities.DTOs;
using CRM.Application.Activities.Queries;
using CRM.Application.Core;
using CRM.Domain;
using CRM.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<CrmActivity>>> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetActivityList.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrmActivity>> GetActivityDetail(string id)
        {
            return HandleResult(await Mediator.Send(new GetActivityDetail.Query { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> CreateActivity(CreateActivityDto activityDto)
        {
            return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }));
        }

        [HttpPut]
        public async Task<ActionResult> EditActivity(EditActivityDto activity)
        {
            return HandleResult(await Mediator.Send(new EditActivity.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
        }
    }
}
