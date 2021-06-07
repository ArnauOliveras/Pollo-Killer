using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class WeaponSight : StaticActor
    {

        private Vector2f WeaponAimOffset1, WeaponAimOffset2;

        public WeaponSight()
        {
            WeaponAimOffset1 = new Vector2f(30.0f, -30.0f);
            WeaponAimOffset2 = new Vector2f(-40.0f, -30.0f);

            Sight WeaponAim1 = MyGame.Instance.Scene.Create<Sight>();
            WeaponAim1.Position = Position + WeaponAimOffset1;
            WeaponAim1.Rotation = Rotation;

            Sight WeaponAim2 = MyGame.Instance.Scene.Create<Sight>();
            WeaponAim2.Position = Position + WeaponAimOffset2;
            WeaponAim2.Rotation = Rotation;

        }
    }
}
