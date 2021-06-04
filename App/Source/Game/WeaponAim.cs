using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class WeaponAim : StaticActor
    {
        private Texture texture;
        private Vector2f WeaponAimOffset1, WeaponAimOffset2;

        public WeaponAim()
        {
            WeaponAimOffset1 = new Vector2f(30.0f, -30.0f);
            WeaponAimOffset2 = new Vector2f(-40.0f, -30.0f);

            Aim WeaponAim1 = MyGame.Instance.Scene.Create<Aim>();
            WeaponAim1.Position = Position + WeaponAimOffset1;
            WeaponAim1.Rotation = Rotation;

            Aim WeaponAim2 = MyGame.Instance.Scene.Create<Aim>();
            WeaponAim2.Position = Position + WeaponAimOffset2;
            WeaponAim2.Rotation = Rotation;

        }
        public override void Update(float dt)
        {
            base.Update(dt);
            Vector2f movimiento = new Vector2f(0.0f, 0.0f);
        }
    }
}
