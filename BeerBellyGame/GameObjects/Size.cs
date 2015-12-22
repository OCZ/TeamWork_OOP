namespace BeerBellyGame.GameObjects
{
    using Exceptions;

    public struct Size
    {
        private int _width;
        private int _height;
        public Size(int width, int height): this()
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return this._width; }
            set 
            {
                if (value < 0 )
                {
                    throw new GameOutOfBourdersException("Width can not be negative;");
                }
                this._width = value;
            }
        }
        public int Height
        {
            get { return this._height; }
            set
            {
                if (value < 0)
                {
                    throw new GameOutOfBourdersException("Height can not be negative;");
                }
                this._height = value;
            }
        }

    }
}
