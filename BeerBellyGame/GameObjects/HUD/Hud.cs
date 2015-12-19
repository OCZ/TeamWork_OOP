namespace BeerBellyGame.GameObjects.HUD
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Characters;
    using Interfaces;

    public sealed class Hud : GameObject, IDrawable
    {
        private static volatile Hud instance;
        private static object syncRoot = new Object();

        private Hud() 
        {
           this.StaticElements = new List<Label>();
            this.DynamicElements = new Dictionary<string, TextBlock>();
        }

        public static Hud Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Hud();
                        }
                    }
                }

                return instance;
            }
        }

        public List<Label> StaticElements { get; set; }
        public Dictionary<string, TextBlock> DynamicElements { get; set; }

        public void PopulateElements(Player player, Friend friend)
        {
            this.PopulateStaticElements();
            this.PopulateDynamicElements(player, friend);
           
        }

        private void PopulateDynamicElements(Player player, Friend friend)
        {
            this.DynamicElements.Add("playerBeerBelly", new TextBlock()
            {
                Name = "playerBeerBelly",
                Text = player.BeerBelly.ToString(),
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 39,
                Margin = new Thickness(677, 30, 0, 0)
            });

            this.DynamicElements.Add("playerLife", new TextBlock()
            {
                Name = "playerLife",
                Text = player.Life.ToString(),
                Margin = new Thickness(373, 30, 0, 0),
                Width = 18,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
            });
            this.DynamicElements.Add("friendLife", new TextBlock()
            {
                Name = "friendLife",
                Text = friend.Life.ToString(),
                Margin = new Thickness(373, 80, 0, 0),
                Width = 18,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
            });
            this.DynamicElements.Add("playerHealth", new TextBlock()
            {
                Name = "plyerHealth",
                Text = player.Health.ToString(CultureInfo.CurrentUICulture),
                Margin = new Thickness(459, 30, 0, 0),
                Width = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
            });
            
            this.DynamicElements.Add("friendHealth", new TextBlock()
            {
                Name = "friendHealth",
                Text = friend.Health.ToString(CultureInfo.CurrentUICulture),
                Margin = new Thickness(459, 80, 0, 0),
                Width = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
            });
            //this.DynamicElements.Add("playerAggretion", new TextBlock()
            //{
            //    Name = "playerAggretion",
            //    Text = player.Aggression.ToString(),
            //    Margin = new Thickness(576, 33, 0, 0),
            //    Width = 28,
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    TextWrapping = TextWrapping.Wrap,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
            //this.DynamicElements.Add("playerAggretionRange", new TextBlock()
            //{
            //    Name = "playerAggretionRange",
            //    Text = player.AggressionRange.ToString(),
            //    Margin = new Thickness(667, 33, 0, 0),
            //    Width = 28,
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    TextWrapping = TextWrapping.Wrap,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
           
            //this.DynamicElements.Add("friendAggretion", new TextBlock()
            //{
            //    Name = "friendAggreation",
            //    Text = friend.Aggression.ToString(),
            //    Margin = new Thickness(576, 80, 0, 0),
            //    Width = 28,
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    TextWrapping = TextWrapping.Wrap,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
            //this.DynamicElements.Add("friendAggretionRange", new TextBlock()
            //{
            //    Name = "friendAggreationRange",
            //    Text = friend.AggressionRange.ToString(),
            //    Margin = new Thickness(667, 80, 0, 0),
            //    Width = 28,
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    TextWrapping = TextWrapping.Wrap,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
            /* NOT ADDED Eventualy to ADD   
            p money  <TextBlock HorizontalAlignment="Left" Margin="747,35,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="28"><Run  Text="100"/></TextBlock>
            f money   <TextBlock HorizontalAlignment="Left" Margin="749,80,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="28"><Run Text="100"/></TextBlock>
                    */
        }

        
        private void PopulateStaticElements()
        {
            Label player = new Label()
            {
                Content = "Player",
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(227, 24, 0, 0),
                VerticalAlignment = VerticalAlignment.Top, 
                Width = 86, 
                FontFamily = new FontFamily("Comic Sans MS"),
                FontSize = 16
            };
            this.StaticElements.Add(player);
            Label friend = new Label()
            {
                Content = "Friend",
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(227, 71, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 86,
                FontFamily = new FontFamily("Comic Sans MS"),
                FontSize = 16
            };
            this.StaticElements.Add(friend);
            this.StaticElements.Add(new Label()
            {
                Content = "Lifes",
                Margin = new Thickness(319, 24, 0, 0),
                Width = 51,
                FontSize = 14,
                FontFamily = new FontFamily("Comic Sans MS"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            });
            this.StaticElements.Add(new Label()
            {
                Content = "Health",
                Margin = new Thickness(391, 24, 0, 0),
                Width = 62,
                FontSize = 14,
                FontFamily = new FontFamily("Comic Sans MS"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            });
            this.StaticElements.Add(new Label()
            {
                Content = "BeerBelly",
                Margin = new Thickness(586, 24, 0, 0),
                Width = 86,
                FontSize = 14,
                FontFamily = new FontFamily("Comic Sans MS"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            });
            this.StaticElements.Add(new Label()
            {
                Content = "Lifes",
                Margin = new Thickness(319, 71, 0, 0),
                Width = 51,
                FontSize = 14,
                FontFamily = new FontFamily("Comic Sans MS"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            });
            this.StaticElements.Add(new Label()
            {
                Content = "Health",
                Margin = new Thickness(391, 71, 0, 0),
                Width = 62,
                FontSize = 14,
                FontFamily = new FontFamily("Comic Sans MS"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            });

            //this.StaticElements.Add(new Label()
            //{
            //    Content = "Aggretion",
            //    Margin = new Thickness(495, 26, 0, 0),
            //    Width = 76,
            //    FontSize = 14,
            //    FontFamily = new FontFamily("Comic Sans MS"),
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
            //this.StaticElements.Add(new Label()
            //{
            //    Content = "Range",
            //    Margin = new Thickness(612, 26, 0, 0),
            //    Width = 48,
            //    FontSize = 14,
            //    FontFamily = new FontFamily("Comic Sans MS"),
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
            
            //this.StaticElements.Add(new Label()
            //{
            //    Content = "Aggretion",
            //    Margin = new Thickness(495, 71, 0, 0),
            //    Width = 76,
            //    FontSize = 14,
            //    FontFamily = new FontFamily("Comic Sans MS"),
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
            //this.StaticElements.Add(new Label()
            //{
            //    Content = "Range",
            //    Margin = new Thickness(612, 71, 0, 0),
            //    Width = 48,
            //    FontSize = 14,
            //    FontFamily = new FontFamily("Comic Sans MS"),
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Top,
            //});
            /** NOT ADDED Eventualy to ADD       
        Label Content="Money" HorizontalAlignment="Left" Margin="688,27,0,0" VerticalAlignment="Top" Width="55" FontFamily="Comic Sans MS" FontSize="14" />
        Label Content="Money" HorizontalAlignment="Left" Margin="688,72,0,0" VerticalAlignment="Top" Width="55" FontFamily="Comic Sans MS" FontSize="14" />
               */
        }

        public void RefreshDynamicElements(Player player, Friend friend)
        {
            this.DynamicElements["playerBeerBelly"].Text = player.BeerBelly.ToString();
            this.DynamicElements["playerLife"].Text = player.Life.ToString();
            this.DynamicElements["playerHealth"].Text = player.Health.ToString(CultureInfo.CurrentUICulture);
            //this.DynamicElements["playerAggretion"].Text = player.Aggression.ToString(CultureInfo.CurrentUICulture);
            //this.DynamicElements["playerAggretionRange"].Text = player.AggressionRange.ToString();
            this.DynamicElements["friendLife"].Text = friend.Life.ToString();
            this.DynamicElements["friendHealth"].Text = friend.Health.ToString(CultureInfo.CurrentUICulture);
            //this.DynamicElements["friendAggretion"].Text = friend.Aggression.ToString(CultureInfo.CurrentUICulture);
            //this.DynamicElements["friendAggretionRange"].Text = friend.AggressionRange.ToString();
        }
    }
}
