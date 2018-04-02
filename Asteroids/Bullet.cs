using System.Drawing;

namespace Asteroids
{
    class Bullet : BaseObject
    {
        public Bullet() : base(new Point(0, 200), new Point(5, 0), new Size(4, 1)) 
        {
        }

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }
    }
}
