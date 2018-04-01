using System;
using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        private Image image;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Random random = new Random();
            int asteroidNum = random.Next(1, 3);
            image = Image.FromFile($"Resources/asteroid{asteroidNum}.png");
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
