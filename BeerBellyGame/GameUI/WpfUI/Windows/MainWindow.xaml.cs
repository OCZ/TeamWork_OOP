namespace BeerBellyGame.GameUI.WpfUI.Windows
{
    using System.Windows;
    using Engines;
    using WpfUI;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var renderer = new WpfRenderer(this.GameCanvas);
            var inputHandlerer = new WpfInputHandlerer(this.GameCanvas);
            this.Engine = new GameEngine(renderer, inputHandlerer);
            this.Engine.InitGame();
            //this.PlayerLife.Text = this.Engine.Player.Life.ToString();
            //this.PlayerBeerBelly.Text = this.Engine.Player.BeerBelly.ToString();
            this.Engine.StartGame();  
        }

        public GameEngine Engine { get; set; }
    }
}
