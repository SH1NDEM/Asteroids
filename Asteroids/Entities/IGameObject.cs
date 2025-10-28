using System.Drawing;

namespace Asteroids.Entities
{
    public interface IGameObject
    {
        void Update();
        void Draw(Graphics g);
    }
}
