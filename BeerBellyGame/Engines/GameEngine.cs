namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Channels;
    using System.Windows.Documents;
    using System.Windows.Threading;
  
    using GameUI;
    
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.Characters.Factories;
    using GameObjects.Characters.Races;
    using GameObjects.Interfaces;
   
    using GameUI.WpfUI;

    using BeerBellyGame.GameObjects.HUD;

    public class GameEngine
    {
        //the interval of time in milliseconds which the game will be redrawn
        private const int TimerTickIntervalInMilliseconds = 100;
        private const int MopvementSpeed = 10;
        private const int EnemyCount = 10;

        private readonly IGameRenderer _renderer;
        private readonly IInputHandlerer _inputHandlerer;
        private readonly PlayerFactory playerFactory = new PlayerFactory();
        private readonly FriendFactory friendFactory = new FriendFactory();
        private readonly EnemyFactory enemyFactory = new EnemyFactory();

        static Random rand = new Random();

        public GameEngine(IGameRenderer renderer, IInputHandlerer inputHandlerer)
        {
            this._renderer = renderer;
            this._inputHandlerer = inputHandlerer;
            this._inputHandlerer.UIActionHappened += this.HandleUIActionHappend;
           
        }

        public Player Player { get; set; }
        public ICollection<Enemy> Enemies { get; set; }
        
        public Hud Hud
        { 
            get { return Hud.Instance; }
        }

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
            //create player, playera move da se izwadi ot fabrikata za geroi
            this.Player = (Player)this.playerFactory.Create(new PickachuRace());
            this.Player.Position = new Position(10, 10);
            this.Player.Size = new Size(30, 70);
            
            this.Hud.Size = new Size(30, 70);

            //create enemy collection
            for (int i = 0; i < EnemyCount; i++)
            {
                var enemy = (Enemy)this.enemyFactory.Create(new PolicemanRace());
            }
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
            this._renderer.Draw(this.Hud);
        }

        private void Atack()
        {
         //TODO implement 
        }
    }
}
