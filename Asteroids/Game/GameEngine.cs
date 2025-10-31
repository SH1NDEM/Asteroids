using System.Drawing;
using System.Windows.Forms;
using Asteroids.Entities;

namespace Asteroids.Game
{
    public class GameEngine
    {
        private readonly Spaceship spaceship;
        private readonly List<Asteroid> asteroids = new();
        Random random = new Random();

        public GameEngine()
        {
            spaceship = new Spaceship(); // объект создаём сразу
            for (int i = 0; i < 10; i++) // создаём 5 астероидов
            {
                asteroids.Add(new Asteroid(
                    random.Next(1, 4),         // размер
                    random.Next(1, 5),        // скорость (пример)
                    random.Next(1, 850),       // позиция X
                    random.Next(1, 550),       // позиция Y
                    random.Next(1, 5),        // направление (или коэффициент движения)
                    random.Next(0, 360)        // угол поворота
                ));
            }
        }

        public void Update()
        {
            spaceship.Update();
            foreach (var asteroid in asteroids)
            {
                asteroid.Update(); // вызываешь логику движения, вращения, порталинга
            }

        }

        public void Draw(Graphics g)
        {
            spaceship.Draw(g);
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw(g); // вызываешь логику движения, вращения, порталинга
            }
        }

        public void OnKeyDown(Keys key)
        {
            spaceship.OnKeyDown(key);
        }

        public void OnKeyUp(Keys key)
        {
            spaceship.OnKeyUp(key);
        }
    }
}
