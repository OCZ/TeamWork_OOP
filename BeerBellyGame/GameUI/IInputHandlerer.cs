namespace BeerBellyGame.GameUI
{
    using System;
    using GameObjects.Interfaces;
    using WpfUI;

    public interface IInputHandlerer
    {
        event EventHandler<KeyDownEventArgs> UIActionHappened;
    }
}
