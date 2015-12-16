namespace BeerBellyGame.GameUI.WpfUI
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Windows;
    using GameUI;

    public class WpfInputHandlerer: IInputHandlerer
    {
        private readonly Canvas _canvas;

        public WpfInputHandlerer(Canvas canvas)
        {
            this._canvas = canvas;
            //cast to MainWindow couse MainWindow has Focus, canvas does not have
            this.KeyboardHandlerer();
        }
        public event EventHandler<KeyDownEventArgs> UIActionHappened;

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

            (focusedControl).KeyDown += (sender, args) =>
            {
                var key = args.Key;
                //in cases the event is fired
                switch (key)
                {
                    case Key.Down:
                        this.UIActionHappened(this, new KeyDownEventArgs(GameCommand.MoveDown));
                        break;
                    case Key.Up:
                        this.UIActionHappened(this, new KeyDownEventArgs(GameCommand.MoveUp));
                        break;
                    case Key.Right:
                        this.UIActionHappened(this, new KeyDownEventArgs(GameCommand.MoveRight));
                        break;
                    case Key.Left:
                        this.UIActionHappened(this, new KeyDownEventArgs(GameCommand.MoveLeft));
                        break;
                    case Key.Space:
                        this.UIActionHappened(this, new KeyDownEventArgs(GameCommand.Attack));
                        break;
                }
            };
        }

        

    }
}
