namespace BeerBellyGame.GameUI
{
    using System;
    using WpfUI;

    public interface IInputHandlerer
    {
        event EventHandler<KeyDownEventArgs> UIActionHappened;
    }
}
