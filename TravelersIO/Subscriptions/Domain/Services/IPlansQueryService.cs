using TravelersIO.Subscriptions.Domain.Model.Aggregates;
using TravelersIO.Subscriptions.Domain.Model.Queries;

namespace TravelersIO.Subscriptions.Domain.Services;

public interface IPlansQueryService
{
    Task<IEnumerable<Plan>> Handle(GetAllPlansByNameQuery query);
    Task<Plan?> Handle(GetPlansByPlansNameAndMaxUsersQuery query);
    Task<Plan?> Handle(GetPlansByIdQuery query);
}