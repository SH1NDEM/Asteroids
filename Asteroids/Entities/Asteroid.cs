using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Entities
{
    internal class Asteroid
    {
        private double _angle;
        public int _position_x;
        public int _position_y;
        private double _rotation;
        private List<double[]> x = new List<double[]>
        {
            new double[] { 0, 1.5, 1, -1, -1.5},
            new double[] { 0, 2, 2, -1, -1, -2 },
            new double[] { 0, 2, 2, 3, 2, -1, -2, -3, -2 }
        };
        private List<double[]> y = new List<double[]>
        {
            new double[] { -1.5, -0.5, 1.5, 1.5, 0.5},
            new double[] { -2, -1, 1, 2, 0, -1 },
            new double[] { -3, -3, -2, -1, 2, 3, 0, -1, -2 }
        };
        private double[] x_new;
        private double[] y_new;
        private int _size;
        private int _speed;
        private int Size
        {
            get { return _size; }
            set
            {
                if (value > 0)
                {
                    _size = (int)value;
                }
                else
                {
                    _size = (int)Math.Abs(value);
                }
            }
        }

        private int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private double Angle
        {
            get { return _angle; }
            set { _angle = value * Math.PI / 180; }
        }

        public Asteroid(int size, int speed, int position_x, int position_y, double angle, double rotation)
        {
            // Размер — 1, 2 или 3 (или любое целое в пределах количества форм)
            int shapeIndex = Math.Clamp(size - 1, 0, x.Count - 1); // чтобы индекс не выходил за границы
            _size = 5 + size * 2; // визуальный масштаб на экране
            _speed = speed;
            _position_x = position_x;
            _position_y = position_y;
            _angle = angle * Math.PI / 180.0;
            _rotation = rotation;

            x_new = x[shapeIndex].ToArray();
            y_new = y[shapeIndex].ToArray();
        }

        public void Update()
        {
            Asteroid_Move();
        }

        public void Draw(Graphics g)
        {
            int Gx1, Gx2, Gy1, Gy2;
            Pen pen = new Pen(Color.White, 2);
            for (int i = 0; i < x_new.Length - 1; i++)
            {
                Gx1 = (int)(x_new[i] * _size + _position_x);
                Gx2 = (int)(x_new[i + 1] * _size + _position_x);
                Gy1 = (int)(y_new[i] * _size + _position_y);
                Gy2 = (int)(y_new[i + 1] * _size + _position_y);

                g.DrawLine(pen, Gx1, Gy1, Gx2, Gy2);
            }
            Gx1 = (int)(x_new[0] * _size + _position_x);
            Gx2 = (int)(x_new[x_new.Length - 1] * _size + _position_x);
            Gy1 = (int)(y_new[0] * _size + _position_y);
            Gy2 = (int)(y_new[y_new.Length - 1] * _size + _position_y);
            g.DrawLine(pen, Gx1, Gy1, Gx2, Gy2);
            pen.Dispose();
        }

        public void Asteroid_Move()
        {
            double cosA = Math.Cos(_angle);
            double sinA = -Math.Sin(_angle);

            for (int i = 0; i < x_new.Length; i++)
            {
                double x = x_new[i];
                double y = y_new[i];

                x_new[i] = x * cosA - y * sinA;
                y_new[i] = x * sinA + y * cosA;
            }
            _position_x += (int)(_speed * Math.Cos(_rotation));
            _position_y += (int)(_speed * Math.Sin(_rotation));
            portaling();
        }

        public void portaling()
        {
            {
                if (_position_x > 850)
                    _position_x = 0;
                else if (_position_x < 0)
                    _position_x = 850;

                if (_position_y > 550)
                    _position_y = 0;
                else if (_position_y < 0)
                    _position_y = 550;
            }
        }
    }
}
