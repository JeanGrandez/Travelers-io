using TravelersIO.Subscriptions.Domain.Model.Aggregates;
using TravelersIO.Subscriptions.Domain.Model.Commands;

namespace TravelersIO.Subscriptions.Domain.Services;

public interface IPlansCommandService
{
    Task<Plan?> Handle(CreateNewPlansCommand command);
    
}