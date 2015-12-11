namespace BeerBellyGame.GameObjects.Characters.Races
{
    using Interfaces;

    public abstract class AbstractRace: IRace
    {
        private readonly int _defaultAggressionRange;
        private readonly double _defaultAggression;
        private readonly string _defaultAvatar;
        private readonly string _defaultDescription;

        protected AbstractRace(int range, double aggression, string avatar, string description)
        {
            this._defaultAggressionRange = range;
            this._defaultAggression = aggression;
            this._defaultAvatar = avatar;
            this._defaultDescription = description;
        }

        public int DefaultAggressionRange
        {
            get { return this._defaultAggressionRange; }
        }

        public double DefaultAggression
        {
            get { return this._defaultAggression; }
        }

        public string DefaultAvatar
        {
            get { return this._defaultAvatar; }
        }

        public string Description 
        {
            get { return this._defaultDescription; }
        }
    }
}
