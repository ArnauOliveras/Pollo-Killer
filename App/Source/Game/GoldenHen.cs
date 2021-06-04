using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class GoldenHen : Enemy
    {
        private Texture texture;

        public GoldenHen()
        {
            texture = Resources.Texture("Textures/Enemies/Chicken02");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
            speed = 1;
        }

        
    }

    public class GoldenHenX : Enemy
    {
        private Texture texture;

        public GoldenHenX()
        {
            texture = Resources.Texture("Textures/Enemies/Chicken02X");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
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
