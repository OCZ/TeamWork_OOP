namespace BeerBellyGame.Exceptions
{
    using System;

    public class GameOutOfBourdersException : Exception
    {
        public GameOutOfBourdersException (string message) : base(message)
        {
        }
    }
}
