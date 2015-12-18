using System.Linq;

namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
  
    using GameUI;
    
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.HUD;
    using GameObjects.Interfaces;
    using GameObjects.Items;
    using GameUI.WpfUI;

    

    public class GameEngine
    {
        //the interval of time in milliseconds which the game will be redrawn
        private readonly IRace _playerRace;
        private readonly IGameRenderer _renderer;
        private readonly IInputHandlerer _inputHandlerer;
      
       
        public GameEngine(IGameRenderer renderer, IInputHandlerer inputHandlerer, IRace playerRace)
        {
            this._playerRace = playerRace;
            this._renderer = renderer;
            this._inputHandlerer = inputHandlerer;
            this._inputHandlerer.UiActionHappened += this.HandleUiActionHappend;
            MapLoader.Load(this._playerRace);
            this.ItemsToCollect = MapLoader.ItemToCollect;
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

        public List<CollectableItem> ItemsToCollect {get; set; }

        public List<MazeItem> Maze
        {
            get { return MapLoader.Maze; } 
        }
        
        public Hud Hud
        { 
            get { return Hud.Instance; }
        }

        

        public void InitGame()
        {
            this.Hud.Size = new Size(30, 70);
        }

        public void StartGame() 
        {
           var timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(AppSettings.TimerTickIntervalInMilliseconds)};
            timer.Tick += this.GameLoop;
            timer.Start();
           
        }

        private void GameLoop(object sender, EventArgs e)
        {
            this._renderer.Clear();
           
            foreach (var mazeItem in this.Maze)
            {
                this._renderer.Draw(mazeItem);
            }
            foreach (var item in this.ItemsToCollect)
            {
                this._renderer.Draw(item);
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
            EnemyAttack();
            this.Friend.Move(this.Player, Maze);
            this.Enemies.ForEach(en => en.Move(this.Player, Maze));
            this.Enemies.RemoveAll(enemy => enemy.IsAlive == false);

          //  wzetite itemy trqbwa da se premahwat ot kolekciite
        }

        //the method will be exec on UIaction happend
        private void HandleUiActionHappend(object sender, KeyDownEventArgs e)
        {
            var left = this.Player.Position.Left;
            var top = this.Player.Position.Top;

           
            var possibleMovements = this.Player.PossibleMovements(Maze);

            switch (e.Command)
            {
                case GameCommand.MoveDown:
                    if(possibleMovements.Contains(Direction.Down))
                        this.Player.Position = new Position(left, top + AppSettings.MopvementSpeed);
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.MoveUp:
                    if (possibleMovements.Contains(Direction.Up))
                        this.Player.Position = new Position(left, top - AppSettings.MopvementSpeed);
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.MoveLeft:
                    if (possibleMovements.Contains(Direction.Left))
                        this.Player.Position = new Position(left - AppSettings.MopvementSpeed, top);
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.MoveRight:
                    if (possibleMovements.Contains(Direction.Right))
                        this.Player.Position = new Position(left + AppSettings.MopvementSpeed, top);
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.Attack:
                    //this.PlayerAttack();
                    break;
            }
        }

        private void EnemyAttack()
        {
            foreach (var enemy in this.Enemies.Where(enemy => enemy.IntersectWith(this.Player) != Direction.None))
            {
                if (this.Player.Health - enemy.Aggression <= 0)
                {
                    if (this.Player.Life == 0)
                    {
                        this.Player.IsAlive = false;
                    }
                    else
                    {
                        this.Player.Life--;
                        this.Player.Health = 100;
                    }

                }
                else
                {
                    this.Player.Health -= enemy.Aggression;
                }                
            }
        }

        //Work in progress 
//        private void PlayerAttack()
//        {
//            foreach (var enemy in this.Enemies)
//            {
//                if (this.Player.IntersectWith(enemy) != Direction.None)
//                {
//                    enemy.Health -= this.Player.Aggression;
//                }
//            }
//        }
    }
}
