using System;
using System.Reflection.Metadata;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;

        // События клавиш управления
        private bool isLeftPressed = false;
        private bool isRightPressed = false;
        private bool isUpPressed = false;

        // Началььные настройки корабля 
        private int x = 57;
        private int y = 32;
        private int size = 7;
        double angle = 10 * Math.PI / 180; // 10 градусов
        double spaceship_Angle = 270 * Math.PI / 180;
        double velocityX = 0;
        double velocityY = 0;
        private double x1, y1, x2, y2, x3, y3, x4, y4;


        public Form1()
        {
            InitializeComponent();
            // Отрисовка объектов
            this.Paint += new PaintEventHandler(Spaceship);

            // Обработка события клавиатуры
            this.KeyPreview = true;
            this.KeyDown += Spaceship_KeyDown;
            this.KeyUp += Spaceship_KeyUp;
            // Инициализация таймера
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20; // Интервал в миллисекундах
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Spaceship_Move(null, null);
            Spaceship_Inertia_Move(null, null);
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
            }
        }

        private void Spaceship_Move(object sender, EventArgs e)
        {
            if (isLeftPressed)
            {
                double cosA = Math.Cos(angle);
                double sinA = -(Math.Sin(angle));

                double newX2 = x1 + (x2 - x1) * cosA - (y2 - y1) * sinA;
                double newY2 = y1 + (x2 - x1) * sinA + (y2 - y1) * cosA;

                double newX3 = x1 + (x3 - x1) * cosA - (y3 - y1) * sinA;
                double newY3 = y1 + (x3 - x1) * sinA + (y3 - y1) * cosA;

                double newX4 = x1 + (x4 - x1) * cosA - (y4 - y1) * sinA;
                double newY4 = y1 + (x4 - x1) * sinA + (y4 - y1) * cosA;

                x2 = newX2; y2 = newY2;
                x3 = newX3; y3 = newY3;
                x4 = newX4; y4 = newY4;
                spaceship_Angle += 10 * Math.PI / 180;
            }

            if (isRightPressed)
            {
                double cosA = Math.Cos(angle);
                double sinA = Math.Sin(angle);

                double newX2 = x1 + (x2 - x1) * cosA - (y2 - y1) * sinA;
                double newY2 = y1 + (x2 - x1) * sinA + (y2 - y1) * cosA;

                double newX3 = x1 + (x3 - x1) * cosA - (y3 - y1) * sinA;
                double newY3 = y1 + (x3 - x1) * sinA + (y3 - y1) * cosA;

                double newX4 = x1 + (x4 - x1) * cosA - (y4 - y1) * sinA;
                double newY4 = y1 + (x4 - x1) * sinA + (y4 - y1) * cosA;

                x2 = newX2; y2 = newY2;
                x3 = newX3; y3 = newY3;
                x4 = newX4; y4 = newY4;
                spaceship_Angle -= 10 * Math.PI / 180;
            }

            if (isUpPressed)
            {
                double accel = 0.3;
                velocityX += accel * -Math.Cos(spaceship_Angle);
                velocityY += accel * Math.Sin(spaceship_Angle);
            }
        }

        private void Spaceship_Inertia_Move(object sender, EventArgs e)
        {
            // Обновляем координаты корабля
            x1 += velocityX; y1 += velocityY;
            x2 += velocityX; y2 += velocityY;
            x3 += velocityX; y3 += velocityY;
            x4 += velocityX; y4 += velocityY;

            x += (int)velocityX;
            y += (int)velocityY;

            // Плавное торможение
            velocityX *= 0.98;
            velocityY *= 0.98;
        }


        private void Spaceship(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 2);

            // Координаты начала и конца линии

            // Вывод линии
            e.Graphics.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
            e.Graphics.DrawLine(pen, (int)x2, (int)y2, (int)x3, (int)y3);
            e.Graphics.DrawLine(pen, (int)x3, (int)y3, (int)x4, (int)y4);
            e.Graphics.DrawLine(pen, (int)x4, (int)y4, (int)x1, (int)y1);

            // Обязательно освободите ресурсы, занимаемые Pen
            pen.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = (0 + x) * size;
            y1 = (0 + y) * size;
            x2 = (-1 + x) * size;
            y2 = (1 + y) * size;
            x3 = (0 + x) * size;
            y3 = (-2 + y) * size;
            x4 = (1 + x) * size;
            y4 = (1 + y) * size;
        }
    }
}
