namespace BeerBellyGame.GameObjects.Characters
{
    using AI;
    using Interfaces;

    public class Enemy: AIPlayer
    {
        public Enemy(IRace race, AIProvider ai)
            : base(race, ai, AppSettings.DefaultLifes)
        {
        }    
    }
}
