using System;
using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject, ICloneable
    {
        protected Image image;
        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Random random = new Random();
            int asteroidNum = random.Next(1, 3);
            image = Image.FromFile($"Resources/asteroid{asteroidNum}.png");
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height))
            {
                Power = Power
            };
            return asteroid;
        }

        public void Respawn()
        {
            Random rnd = new Random();
            Pos.X = rnd.Next(Game.Width / 2, Game.Width);
            Pos.Y = rnd.Next(0, 2) == 1 ? Game.Height : 0;
        }
    }
}
