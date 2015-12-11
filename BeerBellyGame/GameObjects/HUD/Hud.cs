namespace BeerBellyGame.GameObjects.HUD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class Hud : GameObject
    {
        private const string _avatarUri = "Content/Characters/Policeman_64x64.png"; // TODO ADD FOLDER/FILE(s) FOR HUD
        private static volatile Hud instance;
        private static object syncRoot = new Object();

        private Hud() 
        {
        }

        public static Hud Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Hud();
                        }
                    }
                }

                instance.AvatarUri = _avatarUri;
                return instance;
            }
        }
    }
}
