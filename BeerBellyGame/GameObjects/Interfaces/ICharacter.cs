using BeerBellyGame.GameObjects.Items;
using System.Collections.Generic;
namespace BeerBellyGame.GameObjects.Interfaces
{
    public interface ICharacter
    {
        bool IsAlive { get; set; }
        int Life { get; set; }
        double Health { get; set; }
        
        int AggressionRange { get; set; }
        double Aggression { get; set; }
        double Money { get; set; }
        string Description { get; set; }

        ICollection<Direction> PossibleMovements(ICollection<MazeItem> objs);
    }
}
