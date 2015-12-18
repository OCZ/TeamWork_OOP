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

    public static class MapLoader
    {
        public static Player Player;
        public static Friend Friend;
        private static IRace _playerRace;
        private static IRace _friendRace;
        private static IRace _enemyRace;
        private static readonly IList<IRace> EnemyRaces = RacesExtractor.Instance.EnemyRaces;
        private static readonly IList<IRace> FrienRaces = RacesExtractor.Instance.FriendRaces;
        public static List<Enemy> Enemies = new List<Enemy>();
        public static List<CollectableItem> ItemToCollect = new List<CollectableItem>();
        public static List<MazeItem> Maze = new List<MazeItem>();
        private static readonly Random Rand = new Random();
        
        public static void Load(IRace playerRace)
        {
            //TODO implement diff levels 
            //-> pass as parameter in methed the level create sweatch for levels and set for mapPath diff map resourse

            string mapPath = AppSettings.MapLevel1;
            _playerRace = playerRace;
            _friendRace = ChoseRandomFriendRace();
            _enemyRace = ChoseRandomEnemyRace();
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
                                    Player = new Player(_playerRace)
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
                                    enemy.Aggression = 50;
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

        private static IRace ChoseRandomEnemyRace()
        {
            var index = Rand.Next(0, EnemyRaces.Count);
            return EnemyRaces[index];
        }

        private static IRace ChoseRandomFriendRace()
        {
            var index = Rand.Next(0, FrienRaces.Count);
            return FrienRaces[index];
        }
    }
}
