namespace BeerBellyGame.GameObjects.Characters
{
    using BeerBellyGame.GameObjects.Items;
    using Interfaces;
    using System.Collections.Generic;

    public abstract class Character: GameObject, ICharacter
    {
        private const double DeffHealth = 100;

        protected Character(int lifes, IRace race)
        {
            this.IsAlive = true;
            this.Life = lifes;
            this.Health = DeffHealth;
            this.Race = race;
            this.AggressionRange = race.DefaultAggressionRange;
            this.Aggression = race.DefaultAggression;
            this.Description = race.Description;

            //TODO: Money not implemented
            //avatarUri comes from GO
            this.AvatarUri = race.DefaultAvatar;
        }

        public IRace Race { get; set; }
        public bool IsAlive { get; set; }
        public int Life { get; set; }
        public double Health { get; set; }
        public int AggressionRange { get; set; }
        public double Aggression { get; set; }
        public string Description { get; set; }

        //TODO: Money not implemented
        public double Money { get; set; }

        public ICollection<Direction> PossibleMovements(ICollection<MazeItem> objs)
        {
            List<Direction> directions = new List<Direction>(){
                Direction.down,
                Direction.left,
                Direction.right,
                Direction.up
            };

            foreach (GameObject o in objs)
            {
                directions.Remove(this.IntersectWith(o));
            }

            return directions;
        }
    }
}
