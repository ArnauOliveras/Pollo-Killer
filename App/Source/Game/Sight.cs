using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System;

namespace TcGame
{
    public class Sight : StaticActor
    {
        public Music m;
        private Texture texture;
        public HUD h;
        private bool hasShootLeft = false;
        public float timer = 0;

        public Sight()
        {
            Layer = ELayer.Middle;
            h = new HUD();
            texture = Resources.Texture("Textures/Mira");
            texture.Repeated = true;
            Sprite = new Sprite(texture);
            Position = new Vector2f(1024, 768) / 2;
            Center();
            
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            timer += dt;

            Vector2f movimiento = new Vector2f(415.0f, moveYSight());
            Position = movimiento;

            if (!(h.getMunition() <= 0))
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.A) && hasShootLeft == false)
                {
                    
                    hasShootLeft = true;
                    shotLeft();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.A) == false)
                {
                    hasShootLeft = false;
                }
            }
        }

        public float moveYSight()
        {
            float posX = 10000.0f;
            float posY = 570.0f;
            var enemys = MyGame.Instance.Scene.GetAll<Enemy>();
            foreach (Enemy e in enemys)
            {
                if (Math.Abs(e.Position.X - Position.X) < posX)
                {
                    posX = Math.Abs(e.Position.X - Position.X);
                    posY = e.Position.Y;
                }
            }
            return posY;
        }
        private void shotLeft()
        {
            var enemy = MyGame.Instance.Scene.GetAll<Enemy>();
            foreach (Enemy e in enemy)
            {
                if ((e.Position - Position).Size() <= 40)
                {
                    if (e.nameEnemy == "WhiteHen")
                    {
                        h.addPoints(10);
                    }
                    else if (e.nameEnemy == "GoldenHen")
                    {
                        h.addPoints(50);
                    }
                    else if (e.nameEnemy == "Bird")
                    {
                        h.addPoints(20);
                    }
                    else if (e.nameEnemy == "GreenHen")
                    {
                        h.liveCount(1);
                        h.addPoints(50);
                    }

                    m = new Music("Data/Audios/Dead.wav");
                    m.Play();

                    e.Destroy();
                    break;
                }
                else
                {
                    if (timer >= 0.2f)
                    {
                        h.munitionCount(-1);
                        timer = 0;
                    }
                }
            }
        }
    }

    public class SightX : StaticActor
    {
        public Music m;
        private Texture texture;
        public HUD h;
        private bool hasShootRight = false;
        public float timer = 0;

        public SightX()
        {
            Layer = ELayer.Middle;

            h = new HUD();
            texture = Resources.Texture("Textures/Mira");
            texture.Repeated = true;
            Sprite = new Sprite(texture);
            Position = new Vector2f(1024, 768) / 2;
            Center();
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            timer += dt;

            Vector2f movimiento = new Vector2f(565.0f, moveYSight());
            Position = movimiento;

            if (!(h.getMunition() <= 0))
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.D) && hasShootRight == false)
                {
                    
                    hasShootRight = true;
                    shotRight();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.D) == false)
                {
                    hasShootRight = false;
                }
            }
        }

        public float moveYSight()
        {
            float posX = 10000.0f;
            float posY = 570.0f;
            var enemys = MyGame.Instance.Scene.GetAll<Enemy>();
            foreach (Enemy e in enemys)
            {
                if (Math.Abs(e.Position.X - Position.X) < posX)
                {
                    posX = Math.Abs(e.Position.X - Position.X);
                    posY = e.Position.Y;
                }
            }
            return posY;
        }

        private void shotRight()
        {
            var enemy = MyGame.Instance.Scene.GetAll<Enemy>();
            foreach (Enemy e in enemy)
            {
                if ((e.Position - Position).Size() <= 40)
                {
                    if (e.nameEnemy == "WhiteHen")
                    {
                        h.addPoints(10);
                    }
                    else if (e.nameEnemy == "GoldenHen")
                    {
                        h.addPoints(50);
                    }
                    else if (e.nameEnemy == "Bird")
                    {
                        h.addPoints(20);
                    }
                    else if (e.nameEnemy == "GreenHen")
                    {
                        h.liveCount(1);
                        h.addPoints(100);
                    }
                    m = new Music("Data/Audios/Dead.wav");
                    m.Play();
                    e.Destroy();
                    break;
                }
                else
                {
                    if (timer >= 0.2f)
                    {
                        h.munitionCount(-1);
                        timer = 0;
                    }
                }
            }
        }
    }
}
