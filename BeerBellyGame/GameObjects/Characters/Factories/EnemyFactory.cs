namespace BeerBellyGame.GameObjects.Characters.Factories
{
    using Interfaces;
    using Races;

    // TODO: implement ICOllection of races for Friend and Enemy and add randomly submission to constructor 

    public class EnemyFactory: CharacterFactory
    {
        public override Character Create()
        {
            IRace race = this.GetRace();
            var enemy = new Enemy(race);
            return enemy;
        }

        public override IRace GetRace()
        {
            //TODO =>  radomly generate Enemy Race
            IRace race = new PolicemanRace();

            return race;
        }
    }
}
