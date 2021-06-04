using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class Bird : Enemy
    {
        private Texture texture;

        public Bird()
        {
            texture = Resources.Texture("Textures/Enemies/Bird");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 4, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
