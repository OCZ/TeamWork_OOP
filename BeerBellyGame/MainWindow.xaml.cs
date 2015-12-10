namespace BeerBellyGame
{
    using System.Windows;

    using Engines;
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
