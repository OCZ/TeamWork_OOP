namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.Characters.Factories;

    using GameObjects.Interfaces;
    using GameObjects.Items;

    public class MapLoader
    {
        private static volatile MapLoader instance;
        private static object syncRoot = new Object();

        private IRace _friendRace;
        private IRace _enemyRace;

        private readonly IList<IRace> _enemyRaces;
        private readonly IList<IRace> _frienRaces;
        private readonly Random Rand = new Random();

        
        

        private MapLoader()
        {
            this._frienRaces = RacesExtractor.Instance.FriendRaces;
            this._enemyRaces = RacesExtractor.Instance.EnemyRaces;
            this._friendRace = this.ChoseRandomFriendRace();
            this._enemyRace = this.ChoseRandomEnemyRace();
            this.Enemies = new List<Enemy>();
            this.ItemToCollect = new List<CollectableItem>();
            this.Maze = new List<MazeItem>();
            
            
        }

        public static MapLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MapLoader();
                        }
                    }
                }
                return instance;
            }
        }

        public IRace PlayerRace { get; set; }
        public Player Player { get; private set; }
        public Friend Friend { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public List<CollectableItem> ItemToCollect { get; private set; }
        public List<MazeItem> Maze { get; private set; }


        public void Load()
        {
            //TODO implement diff levels 
            //-> pass as parameter in methed the level create sweatch for levels and set for mapPath diff map resourse

            
            string mapPath = AppSettings.MapLevel1;
            var frientFactory = new FriendFactory();
            var enemyFactory = new EnemyFactory();

            var width = AppSettings.MapElementSize.Width;
            var height = AppSettings.MapElementSize.Height; 
            

            try
            {
                using (StreamReader reader = new StreamReader(mapPath))
                {
                    for (int row = 0; row < AppSettings.MapElementsCountY; row++)
                    {
                        var top = (row*height)+AppSettings.MapPosition.Top;

                        string line = reader.ReadLine();
                        for (int col = 0; col < AppSettings.MapElementsCountX; col++)
                        {
                            var left = col*width;

                            var currentsymbol = line[col];
                            switch (currentsymbol)
                            {
                                case 'p':
                                    Player = new Player(this.PlayerRace)
                                    {
                                        Position = new Position (left, top),
                                        Size = new Size(width, height)
                                    };
                                    break;

                                case 'f':
                                    Friend = (Friend)frientFactory.Create(_friendRace);
                                    Friend.Position = new Position(left, top);
                                    Friend.Size = new Size(width, height);
                                    break;

                                case 'e':
                                    var enemy = (Enemy)enemyFactory.Create(_enemyRace);
                                    enemy.Aggression = 20;
                                    enemy.Position = new Position (left, top);
                                    enemy.Size = new Size(width, height);
                                    Enemies.Add(enemy);
                                    break;


                                case 'w': 
                                    MazeItem mazeElement = new MazeItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    Maze.Add(mazeElement);
                                    break;

                                case 'b': 
                                    BeerItem beer = new BeerItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    ItemToCollect.Add(beer);
                                    break;

                                case 'l': 
                                    LifeItem itemLife = new LifeItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    ItemToCollect.Add(itemLife);
                                    break;

                                case 'h':
                                    
                                    LargeHealthItem itemHealth = new LargeHealthItem()
                                    {
                                        Position = new Position(left, top),
                                        Size = new Size(width, height)
                                    };
                                    ItemToCollect.Add(itemHealth);
                                    break;
                            }
                        }   
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private IRace ChoseRandomEnemyRace()
        {
            var index = this.Rand.Next(0, this._enemyRaces.Count);
            return _enemyRaces[index];
        }

        private IRace ChoseRandomFriendRace()
        {
            var index = this.Rand.Next(0, this._frienRaces.Count);
            return _frienRaces[index];
        }
    }
}
