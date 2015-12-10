namespace BeerBellyGame.GameObjects
{
    public class Pickachu: Player
    {
        private const string Avatar = "/Content/Characters/pikachu50.png";

        public Pickachu()
        {
            
        }

        public override string AvatarUri
        {
            get { return Pickachu.Avatar; }
        }
    }
}
