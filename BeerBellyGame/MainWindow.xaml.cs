

namespace BeerBellyGame
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using Engines;
    using GameUI;
    using GameUI.WpfUI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var renderer = new WpfRenderer(this.GameCanvas);
            var inputHandlerer = new WpfInputHandlerer(this.GameCanvas);
            this.Engine = new GameEngine(renderer, inputHandlerer);
            this.Engine.InitGame();
            this.Engine.StartGame();  
        }

        public GameEngine Engine { get; set; }

        

    }
}
