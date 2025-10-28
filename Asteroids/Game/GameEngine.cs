using System.Drawing;
using System.Windows.Forms;
using Asteroids.Entities;

namespace Asteroids.Game
{
    public class GameEngine
    {
        private readonly Spaceship spaceship;

        public GameEngine()
        {
            spaceship = new Spaceship(); // объект создаём сразу
        }

        public void Update()
        {
            spaceship.Update();
        }

        public void Draw(Graphics g)
        {
            spaceship.Draw(g);
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
