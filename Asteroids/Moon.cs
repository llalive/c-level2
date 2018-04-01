using System;
using System.Drawing;

namespace Asteroids
{
    class Moon : BaseObject
    {
        private Image image;

        public Moon(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Resources/moon.png");
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Random rnd = new Random();
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = rnd.Next(0 + Size.Height, Game.Height - Size.Height);
            }
        }
    }
}
