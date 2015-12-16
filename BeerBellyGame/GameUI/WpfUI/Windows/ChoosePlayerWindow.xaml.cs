namespace BeerBellyGame.GameUI.WpfUI.Windows
{
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
    using GameObjects.Characters.Races;
    using GameObjects.Interfaces;

    public partial class ChoosePlayerWindow : Window
    {
        private IRace _playerRace;

        public ChoosePlayerWindow()
        {
            InitializeComponent();
            var avatarSource = new BitmapImage();
            avatarSource.BeginInit();
            avatarSource.UriSource = new Uri(new PickachuRace().DefaultAvatar, UriKind.Relative);
            avatarSource.EndInit();
            this.avatar1.Source = avatarSource;
            this.BtnStartGame.IsEnabled = false;

        }
        
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var window = new MenuWindow()
            {
                Height = AppSettings.WindowHeight,
                Width = AppSettings.WindowWidth,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = new ImageBrush(new BitmapImage(new Uri(AppSettings.WindowBackgraund))),
                Icon = new BitmapImage(new Uri(AppSettings.WindowIcon))
            };

            window.Show();
            this.Close();
        }
        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            var gameWindow = new MainWindow(this._playerRace)
            {
                Height = AppSettings.WindowHeight,
                Width = AppSettings.WindowWidth,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = new ImageBrush(new BitmapImage(new Uri(AppSettings.WindowBackgraund))),
                Icon = new BitmapImage(new Uri(AppSettings.WindowIcon))
            };

            gameWindow.Show();
            this.Close();
        }

        private void BtnChoosePickachu_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._playerRace = new PickachuRace();
        }


        private void BtnChooseLeprechaun_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._playerRace = new LeprechaunRace();
        }

        private void BtnChoosePoliceman_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._playerRace = new PolicemanRace();
        }
    }
}
