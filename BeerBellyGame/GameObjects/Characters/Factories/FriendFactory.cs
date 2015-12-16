using BeerBellyGame.GameObjects.AI;
using BeerBellyGame.GameObjects.Characters.Races;
using BeerBellyGame.GameObjects.Interfaces;

namespace BeerBellyGame.GameObjects.Characters.Factories
{
    public class FriendFactory : CharacterFactory
    {
        public override Character Create()
        {
            var race = GetRace();
            var friend = new Friend(race, new RandomAIProvider());
            return friend;
        }

        public override IRace GetRace()
        {
            //TODO =>  radomly generate Friend Race
            IRace race = new LeprechaunRace();
            return race;
        }
    }
}