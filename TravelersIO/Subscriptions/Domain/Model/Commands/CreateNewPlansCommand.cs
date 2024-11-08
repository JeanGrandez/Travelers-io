namespace TravelersIO.Subscriptions.Domain.Model.Commands;

public record CreateNewPlansCommand(string Name, int MaxUsers, int Default);