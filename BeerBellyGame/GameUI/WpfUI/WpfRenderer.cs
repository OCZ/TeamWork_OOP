namespace BeerBellyGame.GameUI.WpfUI
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
   
    using GameObjects;
    using GameObjects.Characters;
    using GameObjects.Interfaces;
    using GameObjects.HUD;

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
            foreach (GameObject go in gameObjects)
            {
                if (go is Hud)
                {
                    this.DrawHud(go);
                }
                else this.DrowGo(go);
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
            var avatarSource = new BitmapImage();
            avatarSource.BeginInit();
            avatarSource.UriSource = new Uri(hud.AvatarUri, UriKind.Relative);
            avatarSource.EndInit();

            var avatar = new Image
            {
                Source = avatarSource,
                Width = hud.Size.Width,
                Height = hud.Size.Height
            };

            Canvas.SetLeft(avatar, hud.Position.Left);
            Canvas.SetTop(avatar, hud.Position.Top);
            this._canvas.Children.Add(avatar);
        }
    }
}
 