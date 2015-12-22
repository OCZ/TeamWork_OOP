namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Threading;
    using Enums;
    using Exceptions;
    using GameUI;
    
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.HUD;
    using GameObjects.Items;
    using GameUI.WpfUI;
    using Interfaces;


    public class GameEngine
    {
        private readonly IGameRenderer _renderer;
        private readonly IInputHandlerer _inputHandlerer;
        private DispatcherTimer _timer;
        private Player _player;
        private Friend _friend;
        private List<Enemy> _enemies;
        private List<CollectableItem> _itemsToCollect;
        private List<MazeItem> _maze;
        private List<Bullet> _bullets;

        public GameEngine(IGameRenderer renderer, IInputHandlerer inputHandlerer)
        {
            this._renderer = renderer;
            this._inputHandlerer = inputHandlerer;
            this._inputHandlerer.UiActionHappened += this.HandleUiActionHappend;
        }

        public List<Bullet> Bullets { get; set; }
        public GameResult GameResult { get; set; }
        public Player Player
        {
            get { return this._player; }
            private set
            {
                if (value == null)
                {
                    throw new GameNullException("Player can not be null");
                }
                else
                {
                    this._player = value;
                }
            }
        }
        public Friend Friend
        {
            get { return this._friend; }
            private set
            {
                if (value == null)
                {
                    throw new GameNullException("Friend can not be null");
                }
                else
                {
                    this._friend = value;
                }
            }
        }
        public List<Enemy> Enemies { get; set; }
        public List<CollectableItem> ItemsToCollect
        {
            get { return this._itemsToCollect; }
            private set
            {
                if (value.Count == 0)
                {
                    throw new GameNullException("Items to collect can not be null");
                }
                else
                {
                    this._itemsToCollect = value;
                }
            }
        }
        public List<MazeItem> Maze
        {
            get { return this._maze; }
            private set
            {
                if (value.Count == 0)
                {
                    throw new GameNullException("Maze Items can not be null");
                }
                else
                {
                    this._maze = value;
                }
            }
        }
        
      
        public void InitGame(IRace selectedPlayerRace)
        {
            var mapLoader = new MapLoader();
            mapLoader.Load(selectedPlayerRace);

            this.Player = mapLoader.Player;
            this.Friend = mapLoader.Friend;
            this.Friend.AddFrined(this.Player);
            this.Enemies = mapLoader.Enemies;
            this.ItemsToCollect = mapLoader.ItemToCollect;
            this.Maze = mapLoader.Maze;
            Hud.Instance.PopulateElements(this.Player, this.Friend);
            this.Bullets = new List<Bullet>();
          
        }

        public void StartGame() 
        {
            this._timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(AppSettings.TimerTickIntervalInMilliseconds) };
            this._timer.Tick += this.GameLoop;
            this._timer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            this._renderer.Clear();

            Hud.Instance.RefreshDynamicElements(this.Player, this.Friend);
            this._renderer.Draw(Hud.Instance);

            foreach (var mazeItem in this.Maze)
            {
                this._renderer.Draw(mazeItem);
            }
       
            foreach (var item in this.ItemsToCollect)
            {
                this._renderer.Draw(item);
            }
            
            foreach (var enemy in this.Enemies)
            {
                this._renderer.Draw(enemy);
            }

            if (this.Player.IsAlive)
            {
                this._renderer.Draw(this.Player);    
            }
            
            if (this.Friend.IsAlive)
            {
                this._renderer.Draw(this.Friend);
            }
            
            foreach (var bullet in this.Bullets)
            {
               this.Enemies = bullet.Move(this.Maze, this.Enemies);
                if (bullet.IsFlaying)
                {
                    this._renderer.Draw(bullet);     
                }
            }

            foreach (var bullet in this.Bullets)
            {
                this._renderer.Draw(bullet);
            }
           
            EnemyAttack();
            
            this.Friend.Move(this.Player, Maze);

            this.Enemies.ForEach(en => en.Move(this.Player, Maze));
            
            this.Enemies.RemoveAll(enemy => enemy.IsAlive == false);
            
            this.Bullets.RemoveAll(bullet => bullet.IsFlaying == false);
            
            if (this.CheckGameEnd())
            {
                this._timer.Stop();
                this._renderer.ShowGameSatgeView(this.GameResult);
                return;
            }
            
        }

        private bool CheckGameEnd()
        {
            var beerCount = ItemsToCollect.Count(item => item.GetType() == typeof(BeerItem));
            if (beerCount == 0)
            {
                this.GameResult = GameResult.Won;
                return true;
            }
            else if (this.Player.IsAlive == false)
            {
                 this.GameResult = GameResult.Lost;
                return true;
            }
            return false;
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
                        this.Player.LastMoveDirection = Direction.Down;
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.MoveUp:
                    if (possibleMovements.Contains(Direction.Up))
                        this.Player.Position = new Position(left, top - AppSettings.MopvementSpeed);
                        this.Player.LastMoveDirection = Direction.Up;
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.MoveLeft:
                    if (possibleMovements.Contains(Direction.Left))
                        this.Player.Position = new Position(left - AppSettings.MopvementSpeed, top);
                        this.Player.LastMoveDirection = Direction.Left;
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.MoveRight:
                    if (possibleMovements.Contains(Direction.Right))
                        this.Player.Position = new Position(left + AppSettings.MopvementSpeed, top);
                        this.Player.LastMoveDirection = Direction.Right;
                        this.ItemsToCollect = this.Player.PosibleCollection(this.ItemsToCollect);
                    break;
                case GameCommand.Attack:
                    this.Fire();
                    break;
            }
        }

        private void Fire()
        {
            var bullet = new Bullet(this.Player);
            this.Bullets.Add(bullet);
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

    }
}
