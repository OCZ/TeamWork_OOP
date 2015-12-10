namespace BeerBellyGame.GameUI.WpfUI
{
    using System;

    public class KeyDownEventArgs: EventArgs
    {
        public KeyDownEventArgs(GameCommand command)
        {
            this.Command = command;
        }
        public GameCommand Command { get; set; }
    }
}
