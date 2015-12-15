using BeerBellyGame.GameObjects.Characters;
using BeerBellyGame.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerBellyGame.GameObjects.AI
{
    public abstract class AIProvider
    {
        public Character Character { get; set; }
        public abstract Direction GetDirection(GameObject moveTo, ICollection<MazeItem> obstacles);
    }
}
