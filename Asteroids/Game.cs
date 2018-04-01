﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _objs;

        private const int StarSpeed = 8;
        private const int MinStarSize = 15;
        private const int MaxStarSize = 30;
        private const int MinAsteroidSize = 30;
        private const int MaxAsteroidSize = 50;
        private const int AsteroidsCount = 10;
        private const int StarsCount = 16;

        public Game()
        {

        }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public static void Load()
        {
            Random rnd = new Random();
            _objs = new BaseObject[AsteroidsCount + StarsCount + 1];
            _objs[0] = new Moon(new Point(Width, rnd.Next(0, Height)), new Point(-5, 0), new Size(100, 100));
            for (int i = 1; i < StarsCount; i++)
            {
                int size = rnd.Next(MinStarSize, MaxStarSize);
                _objs[i] = new Star(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(-1 * StarSpeed, 0), new Size(size, size));
            }
            for (int i = StarsCount; i < _objs.Length; i++)
            {
                int size = rnd.Next(MinAsteroidSize, MaxAsteroidSize);
                _objs[i] = new Asteroid(new Point(rnd.Next(Width / 2, Width), rnd.Next(0, Height)), new Point(rnd.Next(-5, 10), rnd.Next(-5, 10)), new Size(size, size));
            }

        }
    }
}