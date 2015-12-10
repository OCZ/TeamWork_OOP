namespace BeerBellyGame.GameObjects.HUD
{
    public sealed class Hud : GameObject
    {
        private const string Avatar = "/Content/HUD/hud_bg.png";
        private static readonly Hud Instance = new Hud();

        private Hud()
        {
            
        }

        public static Hud HudInstance
        {
            get
            {
                return Instance;
            }
        }

        public override string AvatarUri
        {
            get { return Hud.Avatar; }
        }
    }
}
