namespace BeerBellyGame
{
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

        //CHARACTERS

        public const int DefaultLifes = 1;
        public const int PlayerDefaultLifes = 3;
        public const int PlayerNeedHealMinPoints = 40;

        public const string PickachuAvatar = "/Content/Characters/pikachu_v1.png";
        public const string PickachuDescription = "Pikachu, the yellow hero";
        public const int PickachuAggressionRange = 100;
        public const double PickachuAggression = 50;

        public const string MageAvatar = "/Content/Characters/mage.png";
        public const string MageDescription = "MAGE, beer is regular part of your life so life is like a magic for you. You are medium aggressive";
        public const int MageAggressionRange = 150;
        public const double MageAggression = 300.2;

        public const string ChuckAvatar = "/Content/Characters/chucknorrist.gif";
        public const string ChuckDescription = "Chuck Norris,you are totally adicted to beer, that's why withouth beer you are very very aggressive.";
        public const int ChuckAggressionRange = 200;
        public const double ChuckAggression = 500.2;

        public const string SuperGrandpaAvatar = "/Content/Characters/grandpa.png";
        public const string SuperGrandpaDescription = "GrandPa";
        public const int SuperGrandpaAggressionRange = 3;
        public const double SuperGrandpaAggression = 300.2;

        public const string LeprechaunAvatar = "/Content/Characters/leprechaun_v2.png";
        public const string LeprechaunDescription = "Leprechaun the green hero";
        public const int LeprechaunAggressionRange = 1;
        public const double LeprechaunAggression = 300.2;

        public const string NinjaAvatar = "/Content/Characters/ninja.png";
        public const string NinjaDescription = "Ninja";
        public const int NinjaAggressionRange = 3;
        public const double NinjaAggression = 300.2;

        public const string RaceAvatarPoliceman = "/Content/Characters/policeman.png";
        public const string RaceDescriptionPoliceman = "policeman the blue hero";
        public const int RaceAggressionRangePoliceman = 2;
        public const double RaceAggressionPoliceman = 20.5;

        public const string SuperGrandmaAvatar = "/Content/Characters/grandma.png";
        public const string SuperGrandmaDescription = "GrandMa";
        public const int SuperGrandmaAggressionRange = 3;
        public const double SuperGrandmaAggression = 300.2;

        public const string WarriorAvatar = "/Content/Characters/warrior.png";
        public const string WarriorDescription = "Warrior";
        public const int WarriorAggressionRange = 3;
        public const double WarriorAggression = 5;

        public const string XenaAvatar = "/Content/Characters/xena.png";
        public const string XenaDescription = "Xena Warrior Princess";
        public const int XenaAggressionRange = 3;
        public const double XenaAggression = 300.2;

        public const string YodaAvatar = "/Content/Characters/yoda.png";
        public const string YodaDescription = "Yoda";
        public const int YodaAggressionRange = 3;
        public const double YodaAggression = 300.2;

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
