namespace BeerBellyGame.GameObjects
{
    using Exceptions;

    public struct Position
    {
        private int _lef;
        private int _top;

        public Position(int left, int top): this()
        {
            this.Left = left;
            this.Top = top;
        }
        public int Left {
            get { return this._lef; }
            set
            {
                if (value < 0)
                {
                    throw new GameOutOfBourdersException("Position Left out of border");
                }
                this._lef = value;
            }
        }
        public int Top
        {
            get { return this._top; } 
            set
            {
                if (value < 0)
                {
                    throw new GameOutOfBourdersException("Position Top out of border");
                }
                this._top = value;
            }
        }
    }
}
