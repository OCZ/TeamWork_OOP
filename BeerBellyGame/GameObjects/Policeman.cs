using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerBellyGame.GameObjects
{
    public class Policeman: Enemy
    {
        private const string Avatar = "/Content/Characters/Policeman_64x64.png"; 

        public override string AvatarUri
        {
            get { return Policeman.Avatar; }
        }
    }
}
