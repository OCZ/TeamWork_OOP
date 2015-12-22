namespace BeerBellyGame.GameUI.WpfUI
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    using Windows;
    using Engines;
    
    using GameObjects;
    using GameObjects.HUD;
    using Interfaces;

    public class WpfRenderer: IGameRenderer
    {

        private readonly Canvas _canvas;
       
        public WpfRenderer(Canvas canvas)
        {
            this._canvas = canvas;
        }

        public void Clear()
        {
          this._canvas.Children.Clear();
        }

        public void Draw(params IDrawable[] gameObjects)
        {
            if (gameObjects != null)
            {
                foreach (GameObject go in gameObjects)
                {
                    if (go is Hud)
                    {
                        this.DrawHud(go);
                    }
                    else this.DrowGo(go);
                } 
            }   
        }

        public void ShowGameSatgeView(GameResult gameStage)
        {
            var endGameWindow = new EndGameWindow(gameStage)
            {
                Height = AppSettings.WindowHeight,
                Width = AppSettings.WindowWidth,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = new ImageBrush(new BitmapImage(new Uri(AppSettings.WindowBackgraund))),
                Icon = new BitmapImage(new Uri(AppSettings.WindowIcon))
            };
            endGameWindow.Show();
            
            foreach (Window window in Application.Current.Windows.Cast<Window>().Where(window => window.Title == "The Beer Belly Game"))
            {
                window.Close();
            }
        }

        private void DrowGo(GameObject go)
        {
            var avatarSource = new BitmapImage();
            avatarSource.BeginInit();
            avatarSource.UriSource = new Uri(go.AvatarUri, UriKind.Relative);
            avatarSource.EndInit();
            var avatar = new Image
            {
                Source = avatarSource,
                Width = go.Size.Width,
                Height = go.Size.Height
            };

            Canvas.SetLeft(avatar, go.Position.Left);
            Canvas.SetTop(avatar, go.Position.Top);
            this._canvas.Children.Add(avatar);
        }


        private void DrawHud(GameObject hud)
        {
            this.DrawLogo();

            var hudInstance = (Hud) hud;

            foreach (TextBlock element in hudInstance.DynamicElements.Values)
            {
                this._canvas.Children.Add(element);
            }
            foreach (Label element in hudInstance.StaticElements)
            {
                this._canvas.Children.Add(element);
            }
        }

        private void DrawLogo()
        {
           var logoSorce = new BitmapImage();
            logoSorce.BeginInit();
            logoSorce.UriSource = new Uri(AppSettings.WindowSmalLogo, UriKind.Relative);
            logoSorce.EndInit();
            var logo = new Image
            {
                Source = logoSorce,
                Width = 181,
                Height = 109,
                HorizontalAlignment = HorizontalAlignment.Left, 
                VerticalAlignment = VerticalAlignment.Top, 
                Margin = new Thickness(5, 0, 0, 0)
            };

            Canvas.SetLeft(logo, 0);
            Canvas.SetTop(logo, 0);
            this._canvas.Children.Add(logo);
        }
    }
}
 