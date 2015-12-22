namespace BeerBellyGame.GameUI.WpfUI.Windows
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

      private void BtnHowToPLay_Click(object sender, RoutedEventArgs e)
        {
            var howToPlayWindow = new HowToPlayWindow()
            {
                Height = AppSettings.WindowHeight,
                Width = AppSettings.WindowWidth,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = new ImageBrush(new BitmapImage(new Uri(AppSettings.WindowBackgraund))),
                Icon = new BitmapImage(new Uri(AppSettings.WindowIcon))
            };
            howToPlayWindow.Show();
            this.Close();
        }

        private void BtnChooseHero_Click(object sender, RoutedEventArgs e)
        {
            var choosePlayerWindow = new ChoosePlayerWindow()
            {
                Height = AppSettings.WindowHeight,
                Width = AppSettings.WindowWidth,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = new ImageBrush(new BitmapImage(new Uri(AppSettings.WindowBackgraund))),
                Icon = new BitmapImage(new Uri(AppSettings.WindowIcon))
            };
            choosePlayerWindow.Show();
            this.Close();
        }
    }
}
