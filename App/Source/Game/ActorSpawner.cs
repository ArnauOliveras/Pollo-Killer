using SFML.Window;
using SFML.System;
using System;

namespace TcGame
{
    public class ActorSpawner<T> : Actor where T : Actor, new()
    {
        public float MinTime = 2.0f;
        public float MaxTime = 3.0f;

        public Vector2f MinPosition;
        public Vector2f MaxPosition;

        private float coolDown;
        public string nameEnemy;
        private int white, green, golden, bird;
        private int MaxWhite = 2;
        private int MaxGreen = 1;
        private int MaxGolden = 1;
        private int MaxBird = 2;

        public void Reset()
        {
            Random r = new Random();
            float d = (float)r.NextDouble();

            coolDown = MaxTime * d + (1.0f - d) * MinTime;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            white = 0;
            green = 0;
            golden = 0;
            bird = 0;

            checkEnemys();
            if ()
            
             coolDown -= dt;
             if (coolDown < 0.0f)
             {
                 SpawnActor();
                 Reset();
             }
            
        }

        public void SpawnActor()
        {
            Random r = new Random();
            float d1 = (float)r.NextDouble();
            float d2 = (float)r.NextDouble();

            float X = MaxPosition.X * d1 + (1.0f - d1) * MinPosition.X;
            float Y = MaxPosition.Y * d2 + (1.0f - d2) * MinPosition.Y;

            MyGame.Instance.Scene.Create<T>(new Vector2f(X, Y));
        }

        private void checkEnemys()
        {
            var enemys = MyGame.Instance.Scene.GetAll<Enemy>();
            foreach (Enemy e in enemys)
            {
                if (e.nameEnemy == "whiteHen")
                {
                    white++;
                }
                else if (e.nameEnemy == "greenHen")
                {
                    green++;
                }
                else if(e.nameEnemy == "goldenHen")
                {
                    golden++;
                }
                else if (e.nameEnemy == "Bird")
                {
                    bird++;
                }
            }

        }
    }
}

