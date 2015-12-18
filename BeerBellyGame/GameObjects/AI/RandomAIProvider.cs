namespace BeerBellyGame.GameObjects.AI
{
    using BeerBellyGame.GameObjects.Characters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Items;

   public class RandomAIProvider : AIProvider
    {
       private DateTime _time;
       private Direction _rand;
       private readonly Random _random;

        public RandomAIProvider()
        {
            this._random = new Random();
        }

        public override Direction GetDirection(GameObject moveTo, ICollection<MazeItem> obstacles)
        {
            List<Direction> possibles = (List<Direction>)this.Character.PossibleMovements(obstacles);
            if (DateTime.Now > this._time.AddSeconds(_random.Next(1, 3)) || !possibles.Contains(this._rand))
            {
                this._rand = possibles[_random.Next(0, possibles.Count)];
                this._time = DateTime.Now;
            }

            return this._rand;
        }
    }
}
