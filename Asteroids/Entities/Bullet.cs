using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Asteroids.Entities
{
    public class Bullet
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        private double _angle;
        private double _speed = 10;
        private int _lifeTime = 90; // примерно 1,5 секунды при 60 FPS

        public bool IsAlive => _lifeTime > 0;

        public Bullet(double x, double y, double angle)
        {
            X = x;
            Y = y;
            _angle = angle;
        }

        public void Update()
        {
            X += _speed * -Math.Cos(_angle);
            Y += _speed * Math.Sin(_angle);
            _lifeTime--;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.White, (float)X - 2, (float)Y - 2, 4, 4);
        }
    }
}

