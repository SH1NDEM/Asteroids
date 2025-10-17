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
        private int x = 40;
        private int y = 23;
        private int size = 10;
        double angle = 10 * Math.PI / 180; // 10 градусов
        double spaceship_Angle = 270 * Math.PI / 180;
        double spaceship_Angle_Ineria = 270 * Math.PI / 180;
        private double spaseship_Inertia = 0;
        private double spaseship_Speed = 5;
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

        private void Spaceship_Move(object sender, KeyEventArgs e)
        {
            //Поворот корабля налево
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

            //Поворот корабля направо
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
            // Лететь вперед
            if (isUpPressed)
            {
                // Вычисляем приращение
                double dx = spaseship_Speed * -Math.Cos(spaceship_Angle);
                double dy = spaseship_Speed * Math.Sin(spaceship_Angle);

                // Смещаем все точки корабля
                x1 += dx; y1 += dy;
                x2 += dx; y2 += dy;
                x3 += dx; y3 += dy;
                x4 += dx; y4 += dy;

                // И при необходимости — сам центр (если ты его используешь)
                x += (int)dx;
                y += (int)dy;
                spaseship_Inertia = spaseship_Speed;

                if (spaseship_Inertia == 0)
                {
                    spaceship_Angle_Ineria = spaceship_Angle;
                }
                else 
                {
                    spaceship_Angle_Ineria = (spaceship_Angle + spaceship_Angle_Ineria) /2;
                }
            }
        }

        private void Spaceship_Inertia_Move(object sender, EventArgs e)
        {
            if (spaseship_Inertia > 0.1)
            {
                double dx = spaseship_Inertia * -Math.Cos(spaceship_Angle_Ineria);
                double dy = spaseship_Inertia * Math.Sin(spaceship_Angle_Ineria);

                x1 += dx; y1 += dy;
                x2 += dx; y2 += dy;
                x3 += dx; y3 += dy;
                x4 += dx; y4 += dy;

                x += (int)dx;
                y += (int)dy;

                // Плавное снижение: коэфф < 1
                spaseship_Inertia *= 0.95; // 0.95 — скорость затухания; уменьшайте/увеличивайте по вкусу
            }
            else
            {
                spaseship_Inertia = 0;
            }
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
