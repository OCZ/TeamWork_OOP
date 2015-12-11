namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using Interfaces;

    public class PlayerFactory: CharacterFactory
    {
        public override Character Create(IRace race)
        {
            var player = new Player(race);
            return player;
        }

    }
}
