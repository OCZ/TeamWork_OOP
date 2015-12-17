using BeerBellyGame.GameObjects.AI;
using BeerBellyGame.GameObjects.Characters.Races;
using BeerBellyGame.GameObjects.Interfaces;

namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Atributes;

    public class FriendFactory : CharacterFactory
    {
        private static readonly Random Rand = new Random();

        public override Character Create()
        {
            var race = GetRace();
            var friend = new Friend(race, new RandomAIProvider());
            return friend;
        }

        public override IRace GetRace()
        {
            var friendRaces = Assembly.GetExecutingAssembly().GetTypes()
               .Where(t => t.IsClass)
               .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(FriendAttribute)))
               .ToArray();

            int index = Rand.Next(0, friendRaces.Length);

            var race = Activator.CreateInstance(friendRaces[index]) as IRace;

            return race;
        }
    }
}