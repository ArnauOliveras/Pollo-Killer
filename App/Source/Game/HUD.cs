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

        private static int points = 0;
        private static int lives = 5;
        private static int munition = 10;
        private static int level = 1;

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
    }
}

