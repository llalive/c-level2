using System.Drawing;

namespace Asteroids
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        private Image image;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile($"Resources/ship.png");
        }

        public static event Message MessageDie;

        public int Energy => _energy;

        public void EnergyChange(int n)
        {
            _energy -= n;
            if (_energy > 100) _energy = 100;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
