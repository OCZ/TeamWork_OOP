namespace BeerBellyGame.GameObjects.Interfaces
{
    public interface IRace
    {
        int DefaultAggressionRange { get; }
        double DefaultAggression { get; }
        string DefaultAvatar { get; }
        string Description { get; }
        //TODO: only Enemy has default money(now non have), only player has description (now all have)
    }
}
