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
        private readonly IList<IRace> PlayerRaces = RacesExtractor.Instance.PlayerRaces;
        private IEnumerable<Image> avatars;
        private IEnumerable<TextBlock> descriptions;



        public ChoosePlayerWindow()
        {
            InitializeComponent();
            avatars = this.FindVisualChildren<Image>(this.window).ToList();
            descriptions = this.FindVisualChildren<TextBlock>(this.window).ToList();
            this.SetControls(PlayerRaces);
            this.BtnStartGame.IsEnabled = false;
        }

        private void SetControls(IList<IRace> playerRaces)
        {
            int index = 0;
            foreach (var avatar in avatars)
            {
                var avatarSource = new BitmapImage();
                avatarSource.BeginInit();
                avatarSource.UriSource = new Uri(playerRaces[index].DefaultAvatar, UriKind.Relative);
                avatarSource.EndInit();

                avatar.Source = avatarSource;
                index++;
            }
            index = 0;
            foreach (var description in descriptions)
            {
                description.Text = playerRaces[index].Description;
                index++;
            }
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
            this._selectedPlayerRace = PlayerRaces[0];
            //MapLoader.Instance.PlayerRace = this._selectedPlayerRace;
            
        }


        private void BtnChooseLeprechaun_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._selectedPlayerRace = PlayerRaces[1];
        }

        private void BtnChoosePoliceman_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._selectedPlayerRace = PlayerRaces[2];
        }

        private IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
