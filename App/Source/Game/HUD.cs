using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
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
        private static int lives = 0, maxLives = 0;
        private static int munition = 0;
        private static int level = 1;

        public static bool gameOver = false, upgrade = false;
        private bool upgradeShow1 = false, upgradeShow2 = false, upgradeShow3 = false, upgradeShow4 = false;
        int count = 0;
        private float timer = 0;

        public HUD()
        {
            Layer = ELayer.HUD;
            font = new Font("Data/Fonts/LuckiestGuy.ttf");
            tHUD = new Text("", font);
            tHUD.FillColor = new Color(Color.White);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            tHUD.DisplayedString = String.Format("             {0}                     {1}" +
            "                                            {2}                                                {3}", lives, munition, level, points);

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

            if (lives <= 0 && MyGame.gameStarted == true)
            {
                tHUD.FillColor = new Color(Color.Red);
                gameOver = true;
            }

            if (points >= 200 && upgradeShow1 == false)
            {
                UpgradeLevel(1);
            }
            if (points >= 500 && upgradeShow2 == false)
            {
                UpgradeLevel(2);
            }
            if (points >= 1000 && upgradeShow3 == false)
            {
                UpgradeLevel(3);
            }
            if (points >= 2000 && upgradeShow4 == false)
            {
                UpgradeLevel(4);
            }
        }

        private void UpgradeLevel(int upgradeLvl)
        {
            
            if (timer <= 2.0f)
            {
                upgrade = true;
            }

            if (timer > 2.0f)
            {
                upgrade = false;
                timer = 0;
                count++; 
            }

            if (count == 2 && upgradeLvl == 1)
            {
                upgradeShow1 = true;
                count = 0;
            }
            if (count == 2 && upgradeLvl == 2)
            {
                upgradeShow2 = true;
                count = 0;
            }
            if (count == 2 && upgradeLvl == 3)
            {
                upgradeShow3 = true;
                count = 0;
            }
            if (count == 2 && upgradeLvl == 4)
            {
                upgradeShow4 = true;
                count = 0;
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
            if (lives >= maxLives)
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

        public void setMunition(int munitionNum)
        {
            munition = munitionNum;
        }

        public void setLives(int livesNum)
        {
            lives = livesNum;
            maxLives = livesNum;
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

    public class HUDBackground : StaticActor
    {
        private Texture texture;

        public float Speed = 30.0f;

        public HUDBackground()
        {
            Layer = ELayer.Front;

            texture = Resources.Texture("Textures/HUD");
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
        }
    }
}

