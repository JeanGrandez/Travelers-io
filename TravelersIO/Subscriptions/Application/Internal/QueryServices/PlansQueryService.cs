using TravelersIO.Subscriptions.Domain.Model.Aggregates;
using TravelersIO.Subscriptions.Domain.Model.Queries;
using TravelersIO.Subscriptions.Domain.Repositories;
using TravelersIO.Subscriptions.Domain.Services;

namespace TravelersIO.Subscriptions.Application.Internal.QueryServices;

public class PlansQueryService(IPlansRepository plansRepository) : IPlansQueryService
{
    public async Task<IEnumerable<Plan>> Handle(GetAllPlansByNameQuery query)
    {
        return await plansRepository.FindByPlansNameAsync(query.PlansName);
    }

    public async Task<Plan?> Handle(GetPlansByPlansNameAndMaxUsersQuery query)
    {
        return await plansRepository.FindByPlansNameAndMaxUsersAsync(query.PlansName, query.MaxUsers);
    }

    public async Task<Plan?> Handle(GetPlansByIdQuery query)
    {
        return await plansRepository.FindByIdAsync(query.Id);
    }
}