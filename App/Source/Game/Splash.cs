using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
    public class Splash : StaticActor
    {
        private Texture t;
        private Text tx, tx2;
        private Font f;

        public Splash()
        {
            var screenSize = Engine.Get.Window.Size;

            t = new Texture("Data/Textures/Background.jpg");
            Sprite = new Sprite(t);
            Sprite.TextureRect = new IntRect(0, 0, (int)screenSize.X, (int)screenSize.Y);
            f = new Font("Data/Fonts/neuro.ttf");
            tx = new Text("Splash Window", f, 54);
            tx2 = new Text("Press Return to Start", f, 30);
            tx.Origin = new Vector2f(tx.GetLocalBounds().Width / 2.0f, tx.GetLocalBounds().Height / 2.0f);
            tx2.Origin = new Vector2f(tx2.GetLocalBounds().Width / 2.0f, tx2.GetLocalBounds().Height / 2.0f);
            tx.Position = new Vector2f(Engine.Get.Window.Size.X / 2.0f, Engine.Get.Window.Size.Y / 3.0f);
            tx2.Position = new Vector2f(Engine.Get.Window.Size.X / 2.0f, Engine.Get.Window.Size.Y / 3.0f * 2.0f);

        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            //states.Shader = shader;
            states.Texture = t;
            base.Draw(target, states);
            tx.Draw(target, states);
            tx2.Draw(target, states);
        }
    }
}
