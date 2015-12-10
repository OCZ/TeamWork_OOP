namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;

    using System.Windows.Threading;
    using GameUI;
    using GameObjects;
    using GameObjects.Interfaces;
    using GameUI.WpfUI;

    public class GameEngine
    {
        //the interval of time in milliseconds which the game will be redrawn
        private const int TimerTickIntervalInMilliseconds = 100;
        private const int MopvementSpeed = 10;

        private readonly IGameRenderer _renderer;
        private readonly IInputHandlerer _inputHandlerer;

        static Random rand = new Random();

        public GameEngine(IGameRenderer renderer, IInputHandlerer inputHandlerer)
        {
            this._renderer = renderer;
            this._inputHandlerer = inputHandlerer;
            this._inputHandlerer.UIActionHappened += this.HandleUIActionHappend;
            this.Bulets = new List<Bulet>();
        }

        public IPlayer Player { get; set; }
        private List<Bulet> Bulets { get; set; }

        //the method will be exec on UIaction happend
        private void HandleUIActionHappend(object sender, KeyDownEventArgs e)
        {
            var left = this.Player.Position.Left;
            var top = this.Player.Position.Top;
            //TODO - check if it new position is in the map
            switch (e.Command)
            {
                case GameCommand.MoveDown:
                    this.Player.Position = new Position(left, top + MopvementSpeed);
                    break;
                case GameCommand.MoveUp:
                    this.Player.Position = new Position(left, top - MopvementSpeed);    
                break;
                case GameCommand.MoveLeft:
                    this.Player.Position = new Position(left - MopvementSpeed, top);    
                break;
                case GameCommand.MoveRight:
                    this.Player.Position = new Position(left + MopvementSpeed, top);    
                break;
                case GameCommand.Attack:
                    this.Atack();
                break;
            }
        }

        public void InitGame()
        {
            this.Player = new Pickachu()
            {
                Position = new Position(10, 10),
                Size = new Size(30, 70)
            };
            this.Bulets.Clear();
            
        }

        public void StartGame() 
        {
            //TODO setwaneto na timera, t.kato se prawi wednyv weroqtno trqbwa da se prawi w InitGame
            //the game cycle set by the  DisparcherTimer 
            //in every const Miliceconsd the objects will be redrawn
            var timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(TimerTickIntervalInMilliseconds)};
            timer.Tick += this.GameLoop;
            timer.Start();
           
        }

        private void GameLoop(object sender, EventArgs e)
        {
            this._renderer.Clear();
            this._renderer.Draw(this.Player);
            foreach (var bulet in Bulets)
            {
                this._renderer.Draw(bulet);
            }
        }

        private void Atack()
        {
         var bulet = new Bulet()
            {
                Position = new Position(this.Player.Position.Left+this.Player.Size.Width, this.Player.Position.Top),
                Size = new Size(15, 15)
            };
        }
    }
}
