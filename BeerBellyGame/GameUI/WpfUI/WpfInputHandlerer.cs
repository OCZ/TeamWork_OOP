namespace BeerBellyGame.GameUI.WpfUI
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Windows;
    using Enums;
    using GameUI;

    public class WpfInputHandlerer: IInputHandlerer
    {
        private readonly Canvas _canvas;

        public WpfInputHandlerer(Canvas canvas)
        {
            this._canvas = canvas;
            this.KeyboardHandlerer();
        }
        public event EventHandler<KeyDownEventArgs> UiActionHappened;

        private void KeyboardHandlerer()
        {
            MainWindow focusedControl;
            if (this._canvas.Parent is Grid)
            {
                var grid = this._canvas.Parent as Grid;
                focusedControl = grid.Parent as MainWindow;
            }
            else
            {
                focusedControl = this._canvas.Parent as MainWindow;
            }
            if (focusedControl == null)
            {
                throw new NullReferenceException("Canvas focus parent is null");
            }

            (focusedControl).KeyDown += (sender, args) =>
            {
                var key = args.Key;
                switch (key)
                {
                    case Key.Down:
                        this.UiActionHappened(this, new KeyDownEventArgs(GameCommand.MoveDown));
                        break;
                    case Key.Up:
                        this.UiActionHappened(this, new KeyDownEventArgs(GameCommand.MoveUp));
                        break;
                    case Key.Right:
                        this.UiActionHappened(this, new KeyDownEventArgs(GameCommand.MoveRight));
                        break;
                    case Key.Left:
                        this.UiActionHappened(this, new KeyDownEventArgs(GameCommand.MoveLeft));
                        break;
                    case Key.Space:
                        this.UiActionHappened(this, new KeyDownEventArgs(GameCommand.Attack));
                        break;
                }
            };       
        }
    }
}
