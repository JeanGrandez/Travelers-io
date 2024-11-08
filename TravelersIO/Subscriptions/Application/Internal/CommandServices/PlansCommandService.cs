using TravelersIO.Shared.Domain.Repositories;
using TravelersIO.Subscriptions.Domain.Model.Aggregates;
using TravelersIO.Subscriptions.Domain.Model.Commands;
using TravelersIO.Subscriptions.Domain.Repositories;
using TravelersIO.Subscriptions.Domain.Services;

namespace TravelersIO.Subscriptions.Application.Internal.CommandServices;

public class PlansCommandService(IPlansRepository plansRepository, 
    IUnitOfWork unitOfWork) : IPlansCommandService
{
    public async Task<Plan?> Handle(CreateNewPlansCommand command)
    {
        var plans = await plansRepository.FindByPlansNameAndMaxUsersAsync(command.Name, 
            command.MaxUsers);
        if(plans != null) throw new Exception("Plans with this Name and MaxUsers already exists");
        plans = new Plan(command);
        try
        {
            await plansRepository.AddAsync(plans);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return plans;
    }
}