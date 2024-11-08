namespace TravelersIO.Subscriptions.Domain.Model.Queries;

public record GetPlansByPlansNameAndMaxUsersQuery(string PlansName, int MaxUsers);