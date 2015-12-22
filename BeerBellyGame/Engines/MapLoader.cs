namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using Exceptions;
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.Characters.Factories;
    using GameObjects.Items;
    using Interfaces;
    using Size = GameObjects.Size;

    public class MapLoader
    {
        private readonly IRace _friendRace;
        private readonly IRace _enemyRace;
        private readonly Random _rand = new Random();
        private IRace _playerRace;
       
        public MapLoader()
        {
            this._friendRace = this.ChoseRandomFriendRace();
            this._enemyRace = this.ChoseRandomEnemyRace();
            this.Enemies = new List<Enemy>();
            this.ItemToCollect = new List<CollectableItem>();
            this.Maze = new List<MazeItem>();
        }

        public IRace PlayerRace
        {
            get { return this._playerRace; }
            set
            {
                if (value == null)
                {
                    throw new GameNullException("Player Race can not be null;");
                }
                this._playerRace = value;
            }
        }
        public Player Player {get; private set;}
        public Friend Friend { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public List<CollectableItem> ItemToCollect { get; private set; }
        public List<MazeItem> Maze { get; private set; }


        public void Load(IRace selectedPlayerRace)
        {
            //TODO implement diff levels //-> pass as parameter in methed the level create sweatch for levels and set for mapPath diff map resourse
            
            
            var mapPath = AppSettings.MapLevel1;
            var frientFactory = new FriendFactory();
            var enemyFactory = new EnemyFactory();

            this.PlayerRace = selectedPlayerRace;
            var width = AppSettings.MapElementSize.Width;
            var height = AppSettings.MapElementSize.Height; 
            

            try
            {
                using (var reader = new StreamReader(mapPath))
                {
                    for (var row = 0; row < AppSettings.MapElementsCountY; row++)
                    {
                        var top = (row*height)+AppSettings.MapPosition.Top;

                        var line = reader.ReadLine();
                        for (var col = 0; col < AppSettings.MapElementsCountX; col++)
                        {
                            var left = col*width;

                            var currentsymbol = line[col];
                            switch (currentsymbol)
                            {
                                case 'p':
                                    this.Player = new Player(this.PlayerRace)
                                    {
                                        Position = new Position (left, top),
                                        Size = new Size(width, height)
                                    };
                                    break;

                                case 'f':
                                    this.Friend = (Friend)frientFactory.Create(_friendRace);
                                    this.Friend.Position = new Position(left, top);
                                    this.Friend.Size = new Size(width, height);
                                    break;

                                case 'e':
                                    var enemy = (Enemy)enemyFactory.Create(_enemyRace);
                                    enemy.Position = new Position (left, top);
                                    enemy.Size = new Size(width, height);
                                    this.Enemies.Add(enemy);
                                    break;


                                case 'w': 
                                    var mazeElement = new MazeItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    this.Maze.Add(mazeElement);
                                    break;

                                case 'b': 
                                    var beer = new BeerItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    this.ItemToCollect.Add(beer);
                                    break;

                                case 'l': 
                                    var itemLife = new LifeItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    this.ItemToCollect.Add(itemLife);
                                    break;

                                case 'h':
                                    var itemHealth = new LargeHealthItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    this.ItemToCollect.Add(itemHealth);
                                    break;
                            }
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BB Game MapLoader");
            }
        }

        private IRace ChoseRandomEnemyRace()
        {
            var index = this._rand.Next(0,RacesExtractor.Instance.EnemyRaces.Count);
            return RacesExtractor.Instance.EnemyRaces[index];
        }

        private IRace ChoseRandomFriendRace()
        {
            var index = this._rand.Next(0, RacesExtractor.Instance.FriendRaces.Count);
            return RacesExtractor.Instance.FriendRaces[index];
        }
    }
}