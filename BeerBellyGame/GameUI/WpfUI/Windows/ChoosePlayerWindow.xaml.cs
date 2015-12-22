namespace BeerBellyGame.GameUI.WpfUI.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    using Engines;
    
    using Interfaces;

    public partial class ChoosePlayerWindow : Window
    {
        private IRace _selectedPlayerRace;
        private readonly IList<IRace> _playerRaces = RacesExtractor.Instance.PlayerRaces;
        private readonly IEnumerable<Image> _avatars;
        private readonly IEnumerable<TextBlock> _descriptions;
        
        public ChoosePlayerWindow()
        {
            InitializeComponent();
            try
            {
                _avatars = this.FindVisualChildren<Image>(this.window).ToList();
                _descriptions = this.FindVisualChildren<TextBlock>(this.window).ToList();
                this.SetControls(_playerRaces);
                this.BtnStartGame.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SetControls(IList<IRace> playerRaces)
        {
            var index = 0;
            foreach (var avatar in _avatars)
            {
                if (avatar.Name == "Logo") continue;
                var avatarSource = new BitmapImage();
                avatarSource.BeginInit();
                avatarSource.UriSource = new Uri(playerRaces[index].DefaultAvatar, UriKind.Relative);
                avatarSource.EndInit();
                avatar.Source = avatarSource;
                index++;
            }
            index = 0;
            foreach (var description in _descriptions)
            {
                description.Text = playerRaces[index].Description;
                index++;
            }
        }
        
        private void BtnBack_Click(object sender, RoutedEventArgs e)
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
        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
         
            var gameWindow = new MainWindow(this._selectedPlayerRace)
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
            this._selectedPlayerRace = _playerRaces[0];
           
        }


        private void BtnChooseLeprechaun_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._selectedPlayerRace = _playerRaces[1];
        }

        private void BtnChoosePoliceman_Click(object sender, RoutedEventArgs e)
        {
            this.BtnStartGame.IsEnabled = true;
            this._selectedPlayerRace = _playerRaces[2];
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
