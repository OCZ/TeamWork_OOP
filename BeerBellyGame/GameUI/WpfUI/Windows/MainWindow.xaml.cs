namespace BeerBellyGame.GameUI.WpfUI.Windows
{
    using System.Windows;
    using Engines;
    using GameObjects.Interfaces;
    using WpfUI;

    public partial class MainWindow : Window
    {
        public MainWindow(IRace playerRace)
        {
            InitializeComponent();
            var renderer = new WpfRenderer(this.GameCanvas);
            var inputHandlerer = new WpfInputHandlerer(this.GameCanvas);

            this.Engine = new GameEngine(renderer, inputHandlerer, playerRace);
            this.Engine.InitGame();
            this.Engine.StartGame();  
        }

        public GameEngine Engine { get; set; }
    }
}
