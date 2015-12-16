namespace BeerBellyGame.GameObjects.AI
{
    using BeerBellyGame.GameObjects.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IAIMovement
    {
        void Move(GameObject moveTo, ICollection<MazeItem> obstacles);
    }
}
