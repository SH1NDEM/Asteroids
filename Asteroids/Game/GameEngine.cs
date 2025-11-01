using Asteroids.Entities;
using System.Diagnostics;

namespace Asteroids.Game
{
    public class GameEngine
    {
        private readonly Spaceship spaceship;
        private readonly List<Asteroid> asteroids = new();
        private readonly Random random = new Random();

        private bool isInvincible = false;
        private Stopwatch invincibleTimer = new Stopwatch();

        public GameEngine()
        {
            spaceship = new Spaceship();
            spaceship.ActivateInvincibility(2);
            for (int i = 0; i < 10; i++)
            {
                int size = random.Next(1, 4);
                int speed = random.Next(1, 5);
                int posX = random.Next(1, 850);
                int posY = random.Next(1, 550);
                double angle = random.Next(0, 360); // направление полёта
                double spin = (random.NextDouble() - 0.5) * 0.05; // медленное вращение

                asteroids.Add(new Asteroid(size, speed, posX, posY, angle, spin));
            }
        }

        public void Update()
        {
            spaceship.Update();
            foreach (var asteroid in asteroids)
                asteroid.Update();

            CheckCollisions();
            CheckBulletCollisions();

            // Проверка таймера бессмертия
            if (isInvincible && invincibleTimer.ElapsedMilliseconds > 2000)
            {
                isInvincible = false;
                invincibleTimer.Reset();
            }

        }

        private void CheckCollisions()
        {
            if (isInvincible)
                return;

            // Координаты центра корабля
            double sx = (spaceship.x1 + spaceship.x2 + spaceship.x3 + spaceship.x4) / 4;
            double sy = (spaceship.y1 + spaceship.y2 + spaceship.y3 + spaceship.y4) / 4;

            foreach (var asteroid in asteroids)
            {
                double dx = asteroid._position_x - sx;
                double dy = asteroid._position_y - sy;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                // порог столкновения: зависит от размера астероида
                if (distance < asteroidRadius(asteroid))
                {
                    RespawnSpaceship();
                    break;
                }
            }
            if (asteroids.Count == 0)
            {
                SpawnAsteroids(10);
            }

        }

        private void SpawnAsteroids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int size = random.Next(1, 4);
                int speed = random.Next(2, 4);
                int posX = random.Next(0, 850);
                int posY = random.Next(0, 550);
                double angle = random.Next(0, 360);
                double spin = (random.NextDouble() - 0.5) * 0.05; // 💫 медленное вращение

                asteroids.Add(new Asteroid(size, speed, posX, posY, angle, spin));
            }
        }



        private void CheckBulletCollisions()
        {
            var bullets = spaceship.GetBullets();

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                var b = bullets[i];
                bool destroyed = false;

                for (int j = asteroids.Count - 1; j >= 0; j--)
                {
                    var a = asteroids[j];

                    // Считаем расстояние между пулей и центром астероида
                    double dx = a._position_x - b.X;
                    double dy = a._position_y - b.Y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    // === Исправление 1: добавляем радиус пули ===
                    double bulletRadius = 3; // радиус пули (можно настроить)
                    double asteroidRadius = a.GetRadius();                    // если GetSize() возвращает радиус

                    // Попадание, если пуля и астероид пересекаются по радиусам
                    if (distance < asteroidRadius + bulletRadius)
                    {
                        // Удаляем астероид и пулю
                        asteroids.RemoveAt(j);
                        bullets.RemoveAt(i);
                        destroyed = true;

                        // === 💡 Исправление 2: дробление с меньшим вращением ===
                        if (a.GetSize() > 9)
                        {
                            int newSize = Math.Max(1, a.GetSize() / 5);

                            // уменьшаем угол и вращение
                            double rotation1 = 45 + random.Next(-10, 10);
                            double rotation2 = -45 + random.Next(-10, 10);

                            double spin1 = (random.NextDouble() - 0.5) * 0.05; // медленное вращение
                            double spin2 = (random.NextDouble() - 0.5) * 0.05;

                            asteroids.Add(new Asteroid(newSize, 3, a._position_x, a._position_y, rotation1, spin1));
                            asteroids.Add(new Asteroid(newSize, 3, a._position_x, a._position_y, rotation2, spin2));
                        }

                        break; // прекращаем проверку для этой пули
                    }
                }

                if (destroyed)
                    continue;
            }
        }



        private double asteroidRadius(Asteroid a)
        {
            return aSize(a); // для ясности вынесено в отдельную функцию
        }

        private double aSize(Asteroid a)
        {
            // примерная «зона» столкновения
            return 15 + a.GetSize() * 3;
        }

        private void RespawnSpaceship()
        {
            spaceship.ResetToCenter();
            isInvincible = true;
            invincibleTimer.Restart();
        }

        public void Draw(Graphics g)
        {
            // Если корабль неуязвим — делаем мигание
            if (!isInvincible || (invincibleTimer.ElapsedMilliseconds / 200) % 2 == 0)
                spaceship.Draw(g);

            foreach (var asteroid in asteroids)
                asteroid.Draw(g);
        }

        public void OnKeyDown(Keys key)
        {
            if (key == Keys.Space)
                spaceship.Shoot();
            else
                spaceship.OnKeyDown(key);
        }

        public void OnKeyUp(Keys key) => spaceship.OnKeyUp(key);
    }
}
