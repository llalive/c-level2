using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class SplashScreen
    {
        private Form mainScreen;

        private static Button btnStart;
        private static Button btnExit;
        private static Label lblAutor = new Label();

        class MainMenuBtn : Button
        {
            public MainMenuBtn(Point location, String text)
            {
                Location = location;
                FlatStyle = FlatStyle.Flat;
                BackColor = Color.DimGray;
                Font = new Font("Verdana", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                Text = text;
                AutoSize = true;
            }
        }

        public SplashScreen(Form form)
        {
            mainScreen = form;
            form.BackColor = Color.Black;
            lblAutor.Text = "Created by Babikov P.";
            lblAutor.Location = new Point(form.Width / 2 - lblAutor.Width, form.Height - 60 - lblAutor.Height);
            lblAutor.Font = new Font("Verdana", 13F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            lblAutor.ForeColor = Color.White;
            lblAutor.AutoSize = true;
            form.Controls.Add(lblAutor);

            btnStart = new MainMenuBtn(new Point(form.Width / 2 - 50, form.Height / 2 - 50), "New game");
            form.Controls.Add(btnStart);
            btnStart.Click += new EventHandler(BtnStart_Click);

            btnExit = new MainMenuBtn(new Point(btnStart.Location.X, btnStart.Location.Y + btnStart.Height + 10), "Exit");
            form.Controls.Add(btnExit);
            btnExit.Click += new EventHandler(BtnExit_Click);

            form.Show();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnExit.Visible = false;
            lblAutor.Visible = false;
            Game.Init(mainScreen);
            Game.Draw();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            mainScreen.Close();
        }
    }
}
