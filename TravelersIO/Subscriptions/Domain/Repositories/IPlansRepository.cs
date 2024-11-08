using TravelersIO.Shared.Domain.Repositories;
using TravelersIO.Subscriptions.Domain.Model.Aggregates;

namespace TravelersIO.Subscriptions.Domain.Repositories;

public interface IPlansRepository : IBaseRepository<Plan>
{
    Task<IEnumerable<Plan>> FindByPlansNameAsync(string plansName);
    Task<Plan?> FindByPlansNameAndMaxUsersAsync(string plansName, int maxUsers);
}