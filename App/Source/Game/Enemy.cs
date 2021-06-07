using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public abstract class Enemy : AnimatedActor
    {
        private Random rnd = new Random();
        public float speed;
        public bool left;
        public float movimientoY;
        public string nameEnemy;
        private static Vector2f sightPosition;

        protected Enemy()
        {
            OnDestroy += Explode;

        }

        public override void Update(float dt)
        {
            base.Update(dt);
            moveEnemy();
            DestroyThisEnemy();

            
            
        }


        private void Explode(Actor actor)
        {
            MyGame.Instance.Scene.Create<Explosion>(Position);
        }

        protected float generateMovimientoY()
        {
            float movimientoDeLaY = -0.75f;
            int Y = 0;
            Y = rnd.Next(3, 10);

            switch (Y)
            {
                case 3:
                    movimientoDeLaY = -0.3f;
                    break;
                case 4:
                    movimientoDeLaY = -0.4f;
                    break;
                case 5:
                    movimientoDeLaY = -0.5f;
                    break;
                case 6:
                    movimientoDeLaY = -0.6f;
                    break;
                case 7:
                    movimientoDeLaY = -0.7f;
                    break;
                case 8:
                    movimientoDeLaY = -0.8f;
                    break;
                case 9:
                    movimientoDeLaY = -0.9f;
                    break;
            }
            return movimientoDeLaY;
        }


        private void moveEnemy()
        {
            if (left)
            {
                Vector2f movimiento = new Vector2f(1.0f, movimientoY);
                Position += movimiento * speed;
            }
            else
            {
                Vector2f movimiento = new Vector2f(-1.0f, movimientoY);
                Position += movimiento * speed;
            }
        }

        private void DestroyThisEnemy()
        {
            if (Position.X >= 1050 || Position.X <= -40 || Position.Y <= -50)
            {
                Destroy();
            }
        }

        public static void CheckPosition(Vector2f theSightPosition)
        {
            sightPosition = theSightPosition;
        }

        private void CheckIfDestroy()
        {
            if (left == true)
            {
                if (sightPosition == Position)
                {
                    Destroy();
                }
            }

            if (left == false)
            {
                if (sightPosition == Position)
                {
                    Destroy();
                }
            }
        }

    }
}

