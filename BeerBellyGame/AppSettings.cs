﻿namespace BeerBellyGame
{
    using System.Windows.Media.TextFormatting;
    using GameObjects;

    public static class AppSettings
    {
        //GAME WINDOWS 
        public const string WindowIcon = @"pack://application:,,,/BeerBellyGame;component/Content/Windows/icon.png";
        public const string WindowBackgraund = @"pack://application:,,,/BeerBellyGame;component/Content/Windows/background.jpg";
        public const string WindowLogo = @"pack://application:,,,/BeerBellyGame;component/Content/Windows/logo.png";
        public const string WindowSmalLogo = "/Content/Windows/logo.png";
        public const int WindowHeight = 620;
        public const int WindowWidth = 950;
        
        //HUD
        public static readonly int HudHeight = 110;
      

        //Bullet
        public static readonly string BulletItemAvatar = "/Content/Items/bullet.png";

        //Map
        public static readonly Position MapPosition = new Position(0, HudHeight);
        public static readonly Size MapElementSize = new Size(30, 30);
        public static readonly Size BulletSize = new Size(10, 10);
        public static readonly int MapElementsCountX = 30;
        public static readonly int MapElementsCountY = 15;
        public static readonly int MapWidth = MapElementsCountX * MapElementSize.Width;
        public static readonly int MapHeight = MapElementsCountX * MapElementSize.Height;
        public static readonly string MapLevel1 =  "../../Content/Maps/map_l1.txt";

        //Items - Default Values
        public static readonly string MazeItemAvatar = "/Content/Items/wall_50x50.png";
        public static readonly string LifeItemAvatar = "/Content/Items/heart_v2.png";
        public static readonly string HealthItemAvatar = "/Content/Items/potion_v2.png";
        public static readonly string BeerItemAvatar = "/Content/Items/beer_vp1.png";
       
        public const int TargetAICount = 2;

        //GAME ENGINE
        public const int TimerTickIntervalInMilliseconds = 100;
        public const int MopvementSpeed = 10;
     



    }
}
