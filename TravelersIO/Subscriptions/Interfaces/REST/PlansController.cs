using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;
using TravelersIO.Subscriptions.Domain.Model.Queries;
using TravelersIO.Subscriptions.Domain.Services;
using TravelersIO.Subscriptions.Interfaces.REST.Resources;
using TravelersIO.Subscriptions.Interfaces.REST.Transform;

namespace TravelersIO.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Plans")]



public class PlansController(
    IPlansCommandService plansCommandService,
    IPlansQueryService plansQueryService) : ControllerBase
{

    
    [SwaggerOperation(
        Summary = "Get Favorite Source by ID",
        Description = "Get Favorite Source Resource by given ID",
        OperationId = "GetFavoriteSourceById")]
    [SwaggerResponse(200, "The favorite source was found", typeof(PlanResource))]
    [SwaggerResponse(404, "The favorite source was not found")]
    [HttpGet("{id}")]
    
    
    public async Task<ActionResult> GetPlanById(int id)
    {
        var getPlanByIdQuery = new GetPlansByIdQuery(id);
        var result = await plansQueryService.Handle(getPlanByIdQuery);
        if (result is null) return NotFound();
        var resource = PlanResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [SwaggerOperation(
        Summary = "Create a new Plan",
        Description = "Create a new Plan with the given name, max users and default",
        OperationId = "CreatePlan"
        )]
    [SwaggerResponse(201, "The plan was created", typeof(PlanResource))]
    [SwaggerResponse(400, "The plan was not created")]
    [HttpPost]
    
    public async Task<ActionResult> CreatePlan([FromBody] CreatePlanResource resource)
    {
        var createPlanCommand = CreatePlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await plansCommandService.Handle(createPlanCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetPlanById), new { id = result.Id },
            PlanResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}