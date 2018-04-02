using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Form mainScreen = new Form
            {
                Width = 800,
                Height = 600
            };
            SplashScreen mainMenu = new SplashScreen(mainScreen);
            Application.Run(mainScreen);
        }
    }
}
