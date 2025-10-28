using System;
using System.Windows.Forms;
using Asteroids.Game;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        private GameEngine engine; // ������������� ��� ��������� ����������������

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // ������� ��������
            engine = new GameEngine(this);

            // ������ ��� ���������� ����
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 16; // ~60 FPS
            timer.Tick += (s, e) =>
            {
                engine.Update();
                this.Invalidate();
            };
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            engine.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            engine.OnKeyDown(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            engine.OnKeyUp(e.KeyCode);
        }
    }
}
