using System.Drawing;
using System.Windows.Forms;

namespace Asteroids.Entities
{
    public class Spaceship
    {
        private bool isLeftPressed = false;
        private bool isRightPressed = false;
        private bool isUpPressed = false;

        private int x = 43;
        private int y = 27;
        private int size = 10;
        private double angle = 10 * Math.PI / 180;
        private double spaceship_Angle = 270 * Math.PI / 180;
        private double velocityX = 0;
        private double velocityY = 0;

        public double x1, y1, x2, y2, x3, y3, x4, y4;

        // Конструктор без параметров, корабль всегда начинает на фиксированной позиции
        public Spaceship()
        {
            // начальные координаты корабля
            x1 = (0 + x) * size;
            y1 = (0 + y) * size;
            x2 = (-1 + x) * size;
            y2 = (1 + y) * size;
            x3 = (0 + x) * size;
            y3 = (-2 + y) * size;
            x4 = (1 + x) * size;
            y4 = (1 + y) * size;
        }

        public void Update()
        {
            Spaceship_Move();
            Spaceship_Inertia_Move();
        }

        public void Portaling()
        {
            if (x1 > 850 && x2 > 850 && x3 > 850 && x4 > 850)
            {
                x1 -= 875;
                x2 -= 875;
                x3 -= 875;
                x4 -= 875;

            }

            else if (x1 < 0 && x2 < 0 && x3 < 0 && x4 < 0)
            {
                x1 += 875;
                x2 += 875;
                x3 += 875;
                x4 += 875;

            }

            else if (y1 > 540 && y2 > 540 && y3 > 540 && y4 > 540)
            {
                y1 -= 575;
                y2 -= 575;
                y3 -= 575;
                y4 -= 575;

            }

            else if (y1 < 0 && y2 < 0 && y3 < 0 && y4 < 0)
            {
                y1 += 575;
                y2 += 575;
                y3 += 575;
                y4 += 575;

            }
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.White, 2);
            g.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
            g.DrawLine(pen, (int)x2, (int)y2, (int)x3, (int)y3);
            g.DrawLine(pen, (int)x3, (int)y3, (int)x4, (int)y4);
            g.DrawLine(pen, (int)x4, (int)y4, (int)x1, (int)y1);
            pen.Dispose();
        }

        public void OnKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Left: isLeftPressed = true; break;
                case Keys.Right: isRightPressed = true; break;
                case Keys.Up: isUpPressed = true; break;
            }
        }

        public void OnKeyUp(Keys key)
        {
            switch (key)
            {
                case Keys.Left: isLeftPressed = false; break;
                case Keys.Right: isRightPressed = false; break;
                case Keys.Up: isUpPressed = false; break;
            }
        }

        private void Spaceship_Move()
        {
            Portaling();

            if (isLeftPressed)
            {
                double cosA = Math.Cos(angle);
                double sinA = -Math.Sin(angle);

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

        private void Spaceship_Inertia_Move()
        {
            x1 += velocityX; y1 += velocityY;
            x2 += velocityX; y2 += velocityY;
            x3 += velocityX; y3 += velocityY;
            x4 += velocityX; y4 += velocityY;
            x += (int)velocityX;
            y += (int)velocityY;

            velocityX *= 0.98;
            velocityY *= 0.98;
        }
    }
}
