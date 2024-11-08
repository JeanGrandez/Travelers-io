using TravelersIO.Subscriptions.Domain.Model.Commands;

namespace TravelersIO.Subscriptions.Domain.Model.Aggregates;

public class Plan
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int MaxUsers{ get; private set; }
    public int Default { get; private set; }


    protected Plan()
    {
        this.Name = string.Empty;
        this.MaxUsers = 0;
        this.Default = 0;
        
    }

    public Plan(CreateNewPlansCommand command)
    {
        this.Name = command.Name;
        this.MaxUsers = command.MaxUsers;
        this.Default = command.Default;
    }
}