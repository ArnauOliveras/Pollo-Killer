using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class GreenHen : Enemy
    {
        private Texture texture;

        public GreenHen()
        {
            texture = Resources.Texture("Textures/Enemies/Chicken03");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
            left = true;
            speed = 6.0f;
            movimientoY = generateMovimientoY();
        }

        
    }

    public class GreenHenX : Enemy
    {
        private Texture texture;

        public GreenHenX()
        {
            texture = Resources.Texture("Textures/Enemies/Chicken03X");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
            left = false;
            speed = 6.0f;
            movimientoY = generateMovimientoY();
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
