using System.Linq;

namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
  
    using GameUI;
    
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.Interfaces;
    using GameObjects.Items;
    using GameUI.WpfUI;

    

    public class GameEngine
    {

        private readonly IGameRenderer _renderer;
        private readonly IInputHandlerer _inputHandlerer;
      
        public GameEngine(IGameRenderer renderer, IInputHandlerer inputHandlerer)
        {
            this._renderer = renderer;
            this._inputHandlerer = inputHandlerer;
            this._inputHandlerer.UiActionHappened += this.HandleUiActionHappend;
        }

        public Player Player { get; set; }
        public Friend Friend{ get; set; }
        public List<Enemy> Enemies{ get; set; }
        public List<CollectableItem> ItemsToCollect {get; set; }
        public List<MazeItem> Maze { get; set; }
        
       
        public void InitGame()
        {
            MapLoader.Instance.Load();
            this.Player = MapLoader.Instance.Player;
            this.Friend = MapLoader.Instance.Friend;
            this.Enemies = MapLoader.Instance.Enemies;
            this.ItemsToCollect = MapLoader.Instance.ItemToCollect;
            this.Maze = MapLoader.Instance.Maze;
          
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

            foreach (var enemy in Enemies)
            {
                this._renderer.Draw(enemy);
            }

            this._renderer.Draw(this.Player);
            this._renderer.Draw(this.Friend);
            
            
            
           
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
        }

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
