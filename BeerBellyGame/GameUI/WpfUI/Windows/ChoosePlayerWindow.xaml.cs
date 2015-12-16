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

    public partial class ChoosePlayerWindow : Window
    {
        public ChoosePlayerWindow()
        {
            InitializeComponent();
            var avatarSource = new BitmapImage();
            avatarSource.BeginInit();
            avatarSource.UriSource = new Uri(new PickachuRace().DefaultAvatar, UriKind.Relative);
            avatarSource.EndInit();
            this.avatar1.Source = avatarSource;

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
    }
}
