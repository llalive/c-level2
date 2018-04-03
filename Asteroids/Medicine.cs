using System.Drawing;

namespace Asteroids
{
    internal class Medicine : Asteroid
    {
        public Medicine(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile($"Resources/heart.png");
            Power = 10;
        }
    }
}
