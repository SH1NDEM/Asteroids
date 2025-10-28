using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Asteroids.Entities;

namespace Asteroids.Game
{
    public class GameEngine
    {
        private List<IGameObject> gameObjects = new List<IGameObject>();
        private Spaceship spaceship;

        public GameEngine(Form form)
        {
            spaceship = new Spaceship(form.ClientSize);
            gameObjects.Add(spaceship);
        }

        public void Update()
        {
            foreach (var obj in gameObjects)
                obj.Update();
        }

        public void Draw(Graphics g)
        {
            foreach (var obj in gameObjects)
                obj.Draw(g);
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
