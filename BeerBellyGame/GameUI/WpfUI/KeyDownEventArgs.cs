namespace BeerBellyGame.GameUI.WpfUI
{
    using System;
    using Enums;

    public class KeyDownEventArgs: EventArgs
    {
        public KeyDownEventArgs(GameCommand command)
        {
            this.Command = command;
        }
        public GameCommand Command { get; set; }
    }
}
