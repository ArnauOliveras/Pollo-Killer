using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public abstract class Enemy : AnimatedActor
    {
        private Random rnd;
        public float speed;
        public bool left;
        protected Enemy()
        {
            OnDestroy += Explode;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            if (left)
            {
                Vector2f movimiento = new Vector2f(1.0f, -1.0f);
                Position += movimiento * 2f;
            }
            else
            {

            }
        }


        private void Explode(Actor actor)
        {
            MyGame.Instance.Scene.Create<Explosion>(Position);
        }
    }
}

