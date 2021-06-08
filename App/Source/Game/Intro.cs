using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

namespace TcGame
{
    class Intro : StaticActor
    {
        private Texture texture;
        public float Speed = 30.0f;

        public Intro()
        {
            Layer = ELayer.Front;

            texture = Resources.Texture("Textures/Start");
            texture.Repeated = true;
            Sprite = new Sprite(texture);

            
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (MyGame.gameStarted == true)
            {
                Destroy();
            }
        }
    }

    class End : StaticActor
    {
        private Texture texture;
        public float Speed = 30.0f;

        public End()
        {
            Layer = ELayer.Front;

            texture = Resources.Texture("Textures/End");
            texture.Repeated = true;
            Sprite = new Sprite(texture);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (MyGame.gameStarted == true)
            {
                Destroy();
            }
        }
    }
}
