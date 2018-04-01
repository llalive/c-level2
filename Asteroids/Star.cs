using System;
using System.Drawing;

namespace Asteroids
{
    class Star : BaseObject
    {
        private Image image;

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) => image = Image.FromFile(filename: $"Resources/star{new Random().Next(1, 3)}.png");

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);

        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = new Random().Next(0, Game.Height - Size.Height);
            }
        }
    }
}
