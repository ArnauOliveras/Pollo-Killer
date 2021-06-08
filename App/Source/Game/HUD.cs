using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class HUD : Actor, Drawable
    {
        Text tHUD;
        Font font;

        public float speedEnemys = 1.0f;
        public float timeSpawn = 1.0f;


        private static int points = 0;
        private static int lives = 5;
        private static int munition = 10;
        private static int level = 1;

        private float timer = 0;

        public HUD()
        {
            Layer = ELayer.HUD;
            font = new Font("Data/Fonts/LuckiestGuy.ttf");
            tHUD = new Text("", font);
            tHUD.FillColor = new Color(Color.Blue);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            tHUD.DisplayedString = String.Format(" puntos: {0} \n vidas: {1}\n municion: {2}\n nivel: {3}", points, lives, munition, level);

            timer += dt;

            if (munition <= 0 && lives > 0)
            {
                if (timer <= 1.0f)
                {
                    tHUD.FillColor = new Color(Color.Yellow);
                }

                if (timer >= 1.0f)
                {
                    tHUD.FillColor = new Color(Color.White);
                }

                if (timer >= 2.0f)
                {
                    timer = 0;
                }
            }

            if (lives <= 0)
            {
                tHUD.FillColor = new Color(Color.Red);
            }
        }

        public void Draw(RenderTarget rt, RenderStates st)
        {
            rt.Draw(tHUD);
        }

        public void addPoints(int p)
        {
            points += p;
        }

        public void liveCount (int l)
        {
            
            lives += l;
            if (lives >= 6)
                lives = 5;
            if (lives <= 0)
                lives = 0;
        }

        public void munitionCount(int m)
        {
            if (!(munition == 0))
                munition += m;
        }

        public int getMunition()
        {
            return munition;
        }

        public int getLives()
        {
            return lives;
        }

        public int getLevel()
        {
            return level;
        }

        public void checkLevel()
        {

            if (points >= 0 && points < 200)
            {
                level = 1;
                speedEnemys = 1.0f;
                timeSpawn = 1.0f;
            }
            if (points >= 200 && points < 500)
            {
                level = 2;
                speedEnemys = 1.5f;
                timeSpawn = 0.9f;
            }
            if (points >= 500 && points < 1000)
            {
                level = 3;
                speedEnemys = 2.0f;
                timeSpawn = 0.8f;
            }
            if (points >= 1000 && points < 2000)
            {
                level = 4;
                speedEnemys = 2.5f;
                timeSpawn = 0.7f;
            }
            if (points >= 2000)
            {
                level = 5;
                speedEnemys = 3.0f;
                timeSpawn = 0.6f;
            }
        }
    }
}

