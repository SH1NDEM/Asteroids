using System.Drawing;
using System.Windows.Forms;

namespace Asteroids.Entities
{
    public class Spaceship : IGameObject
    {
        private Point position;
        private int speed = 5;
        private bool moveLeft, moveRight, moveUp, moveDown;

        public Spaceship(Size clientSize)
        {
            // Инициализация корабля в центре окна
            position = new Point(clientSize.Width / 2, clientSize.Height / 2);
        }

        public void Update()
        {
            if (moveLeft) position.X -= speed;
            if (moveRight) position.X += speed;
            if (moveUp) position.Y -= speed;
            if (moveDown) position.Y += speed;
        }

        public void Draw(Graphics g)
        {
            g.FillPolygon(Brushes.White, new Point[]
            {
                new Point(position.X, position.Y - 10),
                new Point(position.X - 10, position.Y + 10),
                new Point(position.X + 10, position.Y + 10)
            });
        }

        public void OnKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Left: moveLeft = true; break;
                case Keys.Right: moveRight = true; break;
                case Keys.Up: moveUp = true; break;
                case Keys.Down: moveDown = true; break;
            }
        }

        public void OnKeyUp(Keys key)
        {
            switch (key)
            {
                case Keys.Left: moveLeft = false; break;
                case Keys.Right: moveRight = false; break;
                case Keys.Up: moveUp = false; break;
                case Keys.Down: moveDown = false; break;
            }
        }
    }
}
