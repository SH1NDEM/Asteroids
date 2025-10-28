using System;
using System.Windows.Forms;
using Asteroids.Game;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        private GameEngine game;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Инициализируем игру **после InitializeComponent**
            game = new GameEngine();

            // Таймер обновления
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Подписка на события клавиатуры
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            game.Update();
            this.Invalidate(); // перерисовать форму
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            game.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.OnKeyDown(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            game.OnKeyUp(e.KeyCode);
        }
    }
}
