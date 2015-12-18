namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using AI;
    using Interfaces;
  
    public class FriendFactory : CharacterFactory
    {
       public override Character Create(IRace race)
        {
            var friend = new Friend(race, new RandomAIProvider());
            return friend;
        }
    }
}