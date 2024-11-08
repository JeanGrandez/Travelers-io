

using Microsoft.EntityFrameworkCore;
using TravelersIO.Shared.Infrastructure.Persistence.EFC.Configuration;
using TravelersIO.Shared.Infrastructure.Persistence.EFC.Repositories;
using TravelersIO.Subscriptions.Domain.Model.Aggregates;
using TravelersIO.Subscriptions.Domain.Repositories;

namespace TravelersIO.Subscriptions.Infrastructure.Repositories;

public class PlansRepository(AppDbContext context) : BaseRepository<Plan>(context), IPlansRepository
{
    
    public async Task<IEnumerable<Plan>> FindByPlansNameAsync(string plansName)
    {
        return await Context.Set<Plan>().Where(p => p.Name == plansName).ToListAsync();
    }

    public async Task<Plan?> FindByPlansNameAndMaxUsersAsync(string plansName, int maxUsers)
    {
        return await Context.Set<Plan>().FirstOrDefaultAsync(p => p.Name == plansName && p.MaxUsers == maxUsers);
    }
}