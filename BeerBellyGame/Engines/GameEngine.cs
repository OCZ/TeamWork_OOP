﻿using System.Linq;

namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
  
    using GameUI;
    
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.HUD;
    using GameObjects.Items;
    using GameUI.WpfUI;

    
    public class GameEngine
    {

        private readonly IGameRenderer _renderer;
        private readonly IInputHandlerer _inputHandlerer;
        private DispatcherTimer _timer;
      
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
        public List<Bullet> Bullets { get; set; }
        public GameStage GameStage { get; set; }
      
        public void InitGame()
        {
            MapLoader.Instance.Load();
            this.Player = MapLoader.Instance.Player;
            this.Friend = MapLoader.Instance.Friend;
            this.Friend.AddFrined(this.Player);
            this.Enemies = MapLoader.Instance.Enemies;
            this.ItemsToCollect = MapLoader.Instance.ItemToCollect;
            this.Maze = MapLoader.Instance.Maze;
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

            this._renderer.Draw(this.Player);
            this._renderer.Draw(this.Friend);
            
            //remove bollets
            this.Bullets.RemoveAll(b => b.IsFlaying == false);

            //move bulets
            foreach (var bullet in this.Bullets)
            {
               this.Enemies = bullet.Move(this.Maze, this.Enemies);
                if (bullet.IsFlaying)
                {
                    this._renderer.Draw(bullet);     
                }
            }

            //draw boolets
            foreach (var bullet in this.Bullets)
            {
                this._renderer.Draw(bullet);
            }
           
            EnemyAttack();
            this.Friend.Move(this.Player, Maze);
            if (this.Friend.IsAlive == false)
            {
                //this.Friend = null;
            }

            this.Enemies.ForEach(en => en.Move(this.Player, Maze));
            this.Enemies.RemoveAll(enemy => enemy.IsAlive == false);
            this.Bullets.RemoveAll(bullet => bullet.IsFlaying == false);
            if (this.CheckGameEnd())
            {
                this._timer.Stop();
                this._renderer.ShowGameSatgeView(this.GameStage);
                return;
            }
            
        }

        private bool CheckGameEnd()
        {
            var beerCount = ItemsToCollect.Count(item => item.GetType() == typeof(BeerItem));
            if (beerCount == 0)
            {
                this.GameStage = GameStage.Won;
                return true;
            }
            else if (this.Player.IsAlive == false)
            {
                this.GameStage = GameStage.Lost;
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
