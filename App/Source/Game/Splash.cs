using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
    public class Splash : StaticActor
    {
        private Texture texture;

        public float Speed = 30.0f;

        public Splash()
        {
            Layer = ELayer.Background;

            texture = Resources.Texture("Textures/Intro02");
            texture.Repeated = true;
            Sprite = new Sprite(texture);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            base.Draw(target, states);
        }
    }
}
