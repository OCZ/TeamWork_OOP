namespace BeerBellyGame.GameUI.WpfUI.Windows
{
    using System;
    using System.Windows;
    using Engines;
    using Interfaces;
    using WpfUI;

    public partial class MainWindow : Window
    {
        
        public MainWindow(IRace selectedPlayerRace)
        {
            InitializeComponent();
            try
            {
                var renderer = new WpfRenderer(this.GameCanvas);
                var inputHandlerer = new WpfInputHandlerer(this.GameCanvas);
                this.Engine = new GameEngine(renderer, inputHandlerer);
                this.Engine.InitGame(selectedPlayerRace);
                this.Engine.StartGame();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public GameEngine Engine { get; set; }
    }
}
