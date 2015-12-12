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
    using GameObjects.HUD;
    using GameObjects.Items;
    using GameUI.WpfUI;

    

    public class GameEngine
    {
        //the interval of time in milliseconds which the game will be redrawn
      
        private readonly IGameRenderer _renderer;
        private readonly IInputHandlerer _inputHandlerer;
       
        static Random rand = new Random();

        public GameEngine(IGameRenderer renderer, IInputHandlerer inputHandlerer)
        {
            this._renderer = renderer;
            this._inputHandlerer = inputHandlerer;
            this._inputHandlerer.UIActionHappened += this.HandleUIActionHappend;
        }

        public Player Player 
        {
            get { return MapLoader.Player; } 
        }
        public Friend Friend
        {
            get { return MapLoader.Friend; } 
        }

        public List<Enemy> Enemies
        {
            get { return MapLoader.Enemies; } 
        }

        public static List<GameObject> ItemToCollect
        {
            get { return MapLoader.ItemToCollect; } 
        }

        public static List<MazeItem> Maze
        {
            get { return MapLoader.Maze; } 
        }
        
        public Hud Hud
        { 
            get { return Hud.Instance; }
        }

        

        public void InitGame()
        {
            MapLoader.Load();
            this.Hud.Size = new Size(30, 70);
        }

        public void StartGame() 
        {
            //TODO setwaneto na timera, t.kato se prawi wednyv weroqtno trqbwa da se prawi w InitGame
            //the game cycle set by the  DisparcherTimer 
            //in every const Miliceconsd the objects will be redrawn
            var timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(AppSettings.TimerTickIntervalInMilliseconds)};
            timer.Tick += this.GameLoop;
            timer.Start();
           
        }

        private void GameLoop(object sender, EventArgs e)
        {
            this._renderer.Clear();
            foreach (var mazeItem in Maze)
            {
                this._renderer.Draw(mazeItem);
            }
            foreach (var itemToCollect in ItemToCollect)
            {
                this._renderer.Draw(itemToCollect);
            }
            this._renderer.Draw(this.Player);
            this._renderer.Draw(this.Friend);
            this._renderer.Draw(this.Hud);
            foreach (var enemy in Enemies)
            {
                this._renderer.Draw(enemy);
            }
            
            ////prowerka na koliziqta
            //foreach (var enemy in Enemies)
            //{
            //    int pBottomRight = 0;
            //    int pBottomLeft = 0;
            //    int pTopRight = 0;
            //    int pTopLeft = 0;

            //    int eBottomRight = 0;
            //    int eBottomLeft = 0;
            //    int eTopRight = 0;
            //    int eTopLeft = 0;




            //    bool shouldDie = false;
            //    if (shouldDie)
            //    {
            //        enemy.IsAlive = false;
            //    }
            //}


            this.Enemies.RemoveAll(enemy => enemy.IsAlive == false);
            //wzetite itemy trqbwa da se premahwat ot kolekciite
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
                    this.Player.Position = new Position(left, top + AppSettings.MopvementSpeed);
                    break;
                case GameCommand.MoveUp:
                    this.Player.Position = new Position(left, top - AppSettings.MopvementSpeed);
                    break;
                case GameCommand.MoveLeft:
                    this.Player.Position = new Position(left - AppSettings.MopvementSpeed, top);
                    break;
                case GameCommand.MoveRight:
                    this.Player.Position = new Position(left + AppSettings.MopvementSpeed, top);
                    break;
                case GameCommand.Attack:
                    this.Atack();
                    break;
            }
        }

        private void Atack()
        {
         //TODO implement 
        }
    }
}
