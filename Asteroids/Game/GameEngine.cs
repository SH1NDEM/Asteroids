using System.Drawing;
using System.Windows.Forms;
using Asteroids.Entities;

namespace Asteroids.Game
{
    public class GameEngine
    {
        private readonly Spaceship spaceship;
        private readonly Asteroid asteroid, asteroid1;

        public GameEngine()
        {
            spaceship = new Spaceship(); // объект создаём сразу
            asteroid = new Asteroid(15, 5, 100, 250, 1);
        }

        public void Update()
        {
            spaceship.Update();
            asteroid.Update();
        }

        public void Draw(Graphics g)
        {
            spaceship.Draw(g);
            asteroid.Draw(g);
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
