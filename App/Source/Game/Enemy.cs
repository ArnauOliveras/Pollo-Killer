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

        //private static Vector2f sightPosition;

        //private int white, green, golden, bird;
        //private int MaxWhite = 2;
        //private int MaxGreen = 1;
        //private int MaxGolden = 1;
        //private int MaxBird = 2;

        protected Enemy()
        {
            OnDestroy += Explode;
            //white = 0;
            //green = 0;
            //golden = 0;
            //bird = 0;
            //checkEnemys();
            //canSpawnEnemy();
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            moveEnemy();
            DestroyThisEnemy();

            //if (sightPosition == Position)
            //{
            //    CheckIfDestroy();
            //}
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




        /// /////////////////////////////////////////////////////////////////////////////////////
        //public static void CheckPosition(Vector2f theSightPosition)
        //{
        //    sightPosition = theSightPosition;
        //}

        //private void CheckIfDestroy()
        //{
        //    if (left == true)
        //    {
        //        Destroy();
        //    }

        //    if (left == false)
        //    {
        //        Destroy();
        //    }
        //}


        
        //private void checkEnemys()
        //{
        //    var enemys = MyGame.Instance.Scene.GetAll<Enemy>();
        //    foreach (Enemy e in enemys)
        //    {
        //        if (e.nameEnemy == "WhiteHen")
        //        {
        //            white++;
        //        }
        //        else if (e.nameEnemy == "GreenHen")
        //        {
        //            green++;
        //        }
        //        else if (e.nameEnemy == "GoldenHen")
        //        {
        //            golden++;
        //        }
        //        else if (e.nameEnemy == "Bird")
        //        {
        //            bird++;
        //        }
        //    }

        //}
        //private void canSpawnEnemy()
        //{
        //    if (nameEnemy == "whiteHen")
        //    {
        //        if (white > MaxWhite)
        //        {
        //            Destroy();
        //        }
        //    }
        //    else if (nameEnemy == "greenHen")
        //    {
        //        if (green > MaxGreen)
        //        {
        //            Destroy();
        //        }
        //    }
        //    else if (nameEnemy == "goldenHen")
        //    {
        //        if (golden > MaxGolden)
        //        {
        //            Destroy();
        //        }
        //    }
        //    else if (nameEnemy == "Bird")
        //    {
        //        if (bird > MaxBird)
        //        {
        //            Destroy();
        //        }
        //    }
        //}
    }
}

