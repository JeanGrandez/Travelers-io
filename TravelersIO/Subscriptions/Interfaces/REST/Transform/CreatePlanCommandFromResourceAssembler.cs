using TravelersIO.Subscriptions.Domain.Model.Commands;
using TravelersIO.Subscriptions.Interfaces.REST.Resources;

namespace TravelersIO.Subscriptions.Interfaces.REST.Transform;

public static class CreatePlanCommandFromResourceAssembler
{
    public static CreateNewPlansCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreateNewPlansCommand(resource.Name, resource.MaxUsers, resource.Default);
    }
}