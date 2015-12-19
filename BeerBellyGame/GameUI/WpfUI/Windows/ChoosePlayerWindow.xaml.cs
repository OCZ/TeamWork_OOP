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
    using Engines;
    using GameObjects.Characters.Races;
    using GameObjects.Characters.Races.AIPlayerRaces;
    using GameObjects.Characters.Races.PlayerRaces;
    using GameObjects.Interfaces;

    public partial class ChoosePlayerWindow : Window
    {
        private IRace _selectedPlayerRace;
        private ICollection<IRace> _playeRaces = new List<IRace>()
        {
            new PickachuRace(), 
            
        };
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
            MapLoader.Instance.PlayerRace = this._selectedPlayerRace;
            var gameWindow = new MainWindow()
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
            this._selectedPlayerRace = new PickachuRace();
        }


        private void BtnChooseLeprechaun_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._selectedPlayerRace = new MageRace();
        }

        private void BtnChoosePoliceman_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._selectedPlayerRace = new ChuckNorrisRace();
        }
    }
}
