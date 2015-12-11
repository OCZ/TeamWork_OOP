namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using Interfaces;
    using Races;

    public class FriendFactory: CharacterFactory, IRandomRace
    {
        public override Character Create(IRace race)
        {
            var friend = new Friend(race);
            return friend;
        }


        public IRace GetRace()
        {
            // TODO: implement randomly select rom FRIENDRaces and submit to constructor 
            return null;
        }
    }
}
