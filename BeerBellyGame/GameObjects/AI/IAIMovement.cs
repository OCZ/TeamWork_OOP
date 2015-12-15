using BeerBellyGame.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerBellyGame.GameObjects.AI
{
    interface IAIMovement
    {
        void Move(GameObject moveTo, ICollection<MazeItem> obstacles);
    }
}
