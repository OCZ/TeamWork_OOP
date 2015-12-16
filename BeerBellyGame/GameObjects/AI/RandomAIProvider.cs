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
        private DateTime time;
        private Direction rand;
        private Random random;

        public RandomAIProvider()
        {
            this.random = new Random();
        }

        public override Direction GetDirection(GameObject moveTo, ICollection<MazeItem> obstacles)
        {
            List<Direction> possibles = (List<Direction>)this.Character.PossibleMovements(obstacles);
            if (DateTime.Now > this.time.AddSeconds(random.Next(1, 3)) || !possibles.Contains(this.rand))
            {
                this.rand = possibles[random.Next(0, possibles.Count)];
                this.time = DateTime.Now;
            }

            return this.rand;
        }
    }
}
