namespace BeerBellyGame.GameUI.WpfUI.Windows
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Engines;

    public partial class EndGameWindow : Window
    {
        public EndGameWindow(GameResult gameStage)
        {
            InitializeComponent();
            switch (gameStage)
            {
                    case GameResult.Won:
                    this.Result.Text = "                      YOU WIN !!! \n                    WE ARE PROUD \n            OF YOUR BEER BELLY!!! :)";
                    break;
                    case GameResult.Lost:
                    this.Result.Text = "     YOU   LOOSE :( \n      Next time try harder...";
                    break;
            }
        }

        private void BtnPlayAgain_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        /* tozi buton ne e implementiran
        
         */
    }
}
