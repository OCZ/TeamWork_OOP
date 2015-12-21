using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeerBellyGame.GameUI.WpfUI.Windows
{
    using Engines;

    public partial class EndGameWindow : Window
    {
        public EndGameWindow(GameStage gameStage)
        {
            InitializeComponent();
            switch (gameStage)
            {
                    case GameStage.Won:
                    this.Result.Text = "                      YOU WIN !!! \n                    WE ARE PROUD \n            OF YOUR BEER BELLY!!! :)";
                    break;
                    case GameStage.Lost:
                    this.Result.Text = "     YOU   LOOSE :( \n      Next time try harder...";
                    break;
            }
        }

        private void BtnPlayAgain_Click(object sender, RoutedEventArgs e)
        {

            var menuWindow = new MenuWindow()
            {
                Height = AppSettings.WindowHeight,
                Width = AppSettings.WindowWidth,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = new ImageBrush(new BitmapImage(new Uri(AppSettings.WindowBackgraund))),
                Icon = new BitmapImage(new Uri(AppSettings.WindowIcon))
            };
            menuWindow.Show();
            this.Close();
        }
        /* tozi buton ne e implementiran
        <Button x:Name="BtnPlayAgain" Content="Play Again" Margin="733,57,39,478" BorderThickness="1" FontFamily="Comic Sans MS" FontSize="20" Background="{x:Null}" BorderBrush="#FF51504C" Foreground="#FF2B2B12" FontWeight="Bold" ClickMode="Press" Click="BtnPlayAgain_Click" >
        <Button.Effect>
                <DropShadowEffect ShadowDepth="10" BlurRadius="10"/>
        </Button.Effect>
        </Button>
         */
    }
}
