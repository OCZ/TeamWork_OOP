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

        public List<GameObject> ItemToCollect
        {
            get { return MapLoader.ItemToCollect; } 
        }

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
            //this._renderer.Draw(new MazeItem()
            //{
            //    Position = new Position(40, 20),
            //    Size = new Size(20, 20),
            //    AvatarUri = this.Player.AvatarUri
            //});

            //this._renderer.Draw(new Player(new PickachuRace())
            //{
            //    Position = new Position(this.Player.Position.Left, this.Player.Position.Top),
            //    Size = new Size(20, 20),
            //    AvatarUri = AppSettings.MazeItemAvatar
            //});
           
            foreach (var mazeItem in this.Maze)
            {
                this._renderer.Draw(mazeItem);
            }
            foreach (var item in this.ItemToCollect)
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
            this.Friend.Move(this.Player, Maze);
            this.Enemies.ForEach(en => en.Move(this.Player, Maze));
            this.Enemies.RemoveAll(enemy => enemy.IsAlive == false);
          //  wzetite itemy trqbwa da se premahwat ot kolekciite
        }

        //the method will be exec on UIaction happend
        private void HandleUIActionHappend(object sender, KeyDownEventArgs e)
        {
            var left = this.Player.Position.Left;
            var top = this.Player.Position.Top;
           
            var possibleMovements = this.Player.PossibleMovements(Maze);

            switch (e.Command)
            {
                case GameCommand.MoveDown:
                    if(possibleMovements.Contains(Direction.down))
                        this.Player.Position = new Position(left, top + AppSettings.MopvementSpeed);
                    break;
                case GameCommand.MoveUp:
                    if (possibleMovements.Contains(Direction.up))
                        this.Player.Position = new Position(left, top - AppSettings.MopvementSpeed);
                    break;
                case GameCommand.MoveLeft:
                    if (possibleMovements.Contains(Direction.left))
                        this.Player.Position = new Position(left - AppSettings.MopvementSpeed, top);
                    break;
                case GameCommand.MoveRight:
                    if (possibleMovements.Contains(Direction.right))
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
