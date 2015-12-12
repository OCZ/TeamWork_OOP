﻿namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using Interfaces;
    using Races;

    public class FriendFactory: CharacterFactory
    {
        public override Character Create()
        {
            IRace race = this.GetRace();
            var friend = new Friend(race);
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
