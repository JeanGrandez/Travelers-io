using TravelersIO.Subscriptions.Domain.Model.Aggregates;
using TravelersIO.Subscriptions.Interfaces.REST.Resources;

namespace TravelersIO.Subscriptions.Interfaces.REST.Transform;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
    {
        return new PlanResource(entity.Id, entity.Name, entity.MaxUsers, entity.Default);
    }
}