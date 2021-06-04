using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class Sight : StaticActor
    {
        private Texture texture;
        //private Vector2f WeaponAim1, WeaponAim2;

        public Sight()
        {
            Layer = ELayer.Back;

            texture = Resources.Texture("Textures/Mira");
            texture.Repeated = true;
            Sprite = new Sprite(texture);
            Position = new Vector2f(1024, 768) / 2;
            Center();

        }
        public override void Update(float dt)
        {
            base.Update(dt);
            Vector2f movimiento = new Vector2f(0.0f, 0.0f);
        }
    }
}
