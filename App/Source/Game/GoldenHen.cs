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
            nameEnemy = "goldenHen";
            texture = Resources.Texture("Textures/Enemies/Chicken02");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
            left = true;
            speed = 5.0f;
            movimientoY = generateMovimientoY(); 
        }

        
    }

    public class GoldenHenX : Enemy
    {
        private Texture texture;

        public GoldenHenX()
        {
            nameEnemy = "goldenHen";
            texture = Resources.Texture("Textures/Enemies/Chicken02X");
            texture.Repeated = true;
            AnimatedSprite = new AnimatedSprite(texture, 3, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.1f;
            Position = new Vector2f(1024, 768) / 2;
            Center();
            left = false;
            speed = 5.0f;
            movimientoY = generateMovimientoY();
        }
    }
}
