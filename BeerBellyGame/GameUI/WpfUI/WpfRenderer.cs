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
                if (go is Player)
                {
                    this.DrowPlayer(go);
                }
                else if (go is Enemy)
                {
                    this.DrowEnemy(go);
                } 
                else if (go is Hud) 
                {
                    this.DrawHud(go);
                }
            }       
        }

        private void DrowEnemy(GameObject enemy)
        {
            var avatarSource = new BitmapImage();
            avatarSource.BeginInit();
            avatarSource.UriSource = new Uri(enemy.AvatarUri, UriKind.Relative);
            avatarSource.EndInit();
            var avatar = new Image
            {
                Source = avatarSource,
                Width = enemy.Size.Width,
                Height = enemy.Size.Height
            };

            Canvas.SetLeft(avatar, enemy.Position.Left);
            Canvas.SetTop(avatar, enemy.Position.Top);
            this._canvas.Children.Add(avatar);
        }

        private void DrowPlayer(GameObject player)
        {
            var avatarSource = new BitmapImage();
            avatarSource.BeginInit();
            avatarSource.UriSource = new Uri(player.AvatarUri, UriKind.Relative);
            avatarSource.EndInit();
            var avatar = new Image
            {
                Source = avatarSource,
                Width = player.Size.Width,
                Height = player.Size.Height
            };

            Canvas.SetLeft(avatar, player.Position.Left);
            Canvas.SetTop(avatar, player.Position.Top);
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
 