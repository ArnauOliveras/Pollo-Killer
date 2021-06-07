using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class Sight : StaticActor
    {
        private Texture texture;
        public HUD h;
        public float timer = 0.0f;

        public Sight()
        {
            Layer = ELayer.Front;
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
            Vector2f movimiento = new Vector2f(415.0f, moveYSight());
            Position = movimiento;
            timer += dt;
            shotLeft();
            

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
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                var enemy = MyGame.Instance.Scene.GetAll<Enemy>();
                foreach (Enemy e in enemy)
                {
                    if ((e.Position - Position).Size() < 30)
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
                        }
                        e.Destroy();
                        break;
                    }
                    else
                    {
                        if (timer >= 0.5f)
                        {
                            timer = 0.0f;
                            h.munitionCount(-1);
                        }
                    }
                }
            }
        }
    }













    public class SightX : StaticActor
    {
        private Texture texture;
        public HUD h;
        public float timer = 0.0f;
        public SightX()
        {
            Layer = ELayer.Front;
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
            Vector2f movimiento = new Vector2f(565.0f, moveYSight());
            Position = movimiento;
            timer += dt;
            shotRight();
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
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                var enemy = MyGame.Instance.Scene.GetAll<Enemy>();
                foreach (Enemy e in enemy)
                {
                    if ((e.Position - Position).Size() < 30)
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
                        }
                        e.Destroy();
                        break;
                    }
                    else
                    {
                        if (timer >= 0.5f)
                        {
                            timer = 0.0f;
                            h.munitionCount(-1);
                        }
                    }
                }
            }
        }
    }
}
