using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class Sight : StaticActor
    {
        private Texture texture;

        public Sight()
        {
            Layer = ELayer.Front;

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
    }

    public class SightX : StaticActor
    {
        private Texture texture;

        public SightX()
        {
            Layer = ELayer.Front;

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
    }
}
