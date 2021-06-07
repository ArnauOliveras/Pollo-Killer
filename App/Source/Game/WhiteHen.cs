using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class WhiteHen : Enemy
    {
        private Texture texture;
        

        public WhiteHen()
        {
            nameEnemy = "WhiteHen";
            texture = Resources.Texture("Textures/Enemies/Chicken01");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
            left = true;
            speed = 2.0f;
            movimientoY = generateMovimientoY();
        }

    }

    public class WhiteHenX : Enemy
    {
        private Texture texture;


        public WhiteHenX()
        {
            left = false;

            nameEnemy = "WhiteHen";
            texture = Resources.Texture("Textures/Enemies/Chicken01X");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
            speed = 2.0f;
            movimientoY = generateMovimientoY();
        }
    }
}
