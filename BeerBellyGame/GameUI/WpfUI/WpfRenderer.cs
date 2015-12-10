namespace BeerBellyGame.GameUI.WpfUI
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    using GameObjects;
    using GameObjects.HUD;
    using GameObjects.Interfaces;

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
                    this.DrowHud();
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
    
        // DRAW HUD
        private void DrowHud()
        {
            var hudSource = new BitmapImage();
            hudSource.BeginInit();
            hudSource.UriSource = new Uri(Hud.HudInstance.AvatarUri, UriKind.Relative);
            hudSource.EndInit();

            var avatar = new Image()
            {
                Source = hudSource,
                Width = Hud.HudInstance.Size.Width,
                Height = Hud.HudInstance.Size.Height
            };
            // TODO....
        }
    }
}
 