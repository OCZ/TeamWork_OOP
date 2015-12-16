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
    /// <summary>
    /// Interaction logic for HowToPlayWindow.xaml
    /// </summary>
    public partial class HowToPlayWindow : Window
    {
        public HowToPlayWindow()
        {
            InitializeComponent();
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
