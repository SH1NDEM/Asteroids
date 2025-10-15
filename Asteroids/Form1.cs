using System;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;

        // ������� ������ ����������
        private bool isLeftPressed = false;
        private bool isRightPressed = false;
        private bool isUpPressed = false;
        private bool isDownPressed = false;

        // ���������� ��������� ������� 
        private int x = 40;
        private int y = 23;
        private int size = 10;
        private int spaseship_Speed = 1;

        public Form1()
        {
            InitializeComponent();
            // ��������� ��������
            this.Paint += new PaintEventHandler(Spaceship);
            //this.Paint += Asteriods;

            // ��������� ������� ����������
            this.KeyPreview = true;
            this.KeyDown += Spaceship_KeyDown;
            this.KeyUp += Spaceship_KeyUp;
            // ������������� �������
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20; // �������� � �������������
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Spaceship_Move(null, null);
            this.Invalidate();
        }
        private void Spaceship_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    isLeftPressed = true;
                    break;
                case Keys.Right:
                    isRightPressed = true;
                    break;
                case Keys.Up:
                    isUpPressed = true;
                    break;
                case Keys.Down:
                    isDownPressed = true;
                    break;
            }
        }

        private void Spaceship_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    isLeftPressed = false;
                    break;
                case Keys.Right:
                    isRightPressed = false;
                    break;
                case Keys.Up:
                    isUpPressed = false;
                    break;
                case Keys.Down:
                    isDownPressed = false;
                    break;
            }
        }

        private void Spaceship_Move(object sender, KeyEventArgs e)
        {
            if (isLeftPressed) x -= spaseship_Speed;
            if (isRightPressed) x += spaseship_Speed;
            if (isUpPressed) y -= spaseship_Speed;
            if (isDownPressed) y += spaseship_Speed;

        }

        private void Asteriods(object sender, PaintEventArgs e)
        {
            // ��������� ������� �����
            using (Pen pen = new Pen(Color.White, 2))
            {
                // ��� ����� ������ � ������ ��������������� �������������� ������ ���� �����
                int x = 50;
                int y = 50;
                int size = 20; // ������� �����

                e.Graphics.DrawEllipse(pen, x, y, size, size);
            }
        }
        private void Spaceship(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 2); 

            // ���������� ������ � ����� �����
            int x1 = (0 + x) * size, y1 = (0 + y) * size;
            int x2 = (-1 + x) * size, y2 = (1 + y) * size;
            int x3 = (0 + x) * size, y3 = (-2 + y) * size;
            int x4 = (1 + x) * size, y4 = (1 + y) * size;

            // ����� �����
            e.Graphics.DrawLine(pen, x1, y1, x2, y2);
            e.Graphics.DrawLine(pen, x2, y2, x3, y3);
            e.Graphics.DrawLine(pen, x3, y3, x4, y4);
            e.Graphics.DrawLine(pen, x4, y4, x1, y1);

            // ����������� ���������� �������, ���������� Pen
            pen.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
