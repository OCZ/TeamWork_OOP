namespace BeerBellyGame.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.Characters.Factories;
    using GameObjects.Characters.Races;
    using GameObjects.Interfaces;
    using GameObjects.Items;

    public static class MapLoader
    {
        public static Player Player;
        public static Friend Friend;
        public static List<Enemy> Enemies = new List<Enemy>();
        public static List<GameObject> ItemToCollect = new List<GameObject>();
        public static List<MazeItem> Maze = new List<MazeItem>();
      
        public static void Load()
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
                                    Player = new Player(new PickachuRace())
                                    {
                                        Position = new Position (left, top),
                                        Size = new Size(width, height)
                                    };
                                    break;

                                case 'f':
                                    Friend = (Friend)frientFactory.Create();
                                    Friend.Position = new Position(left, top);
                                    Friend.Size = new Size(width, height);
                                    break;

                                case 'e':
                                    var enemy = (Enemy)enemyFactory.Create();
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
                                    HealthItem itemHealth = new HealthItem()
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
    }
}
