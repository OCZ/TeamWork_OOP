namespace BeerBellyGame.Exceptions
{
    using System;

    public class GameNullException : Exception
    {
        public GameNullException(string message) : base(message)
        {
        }
    }
}
