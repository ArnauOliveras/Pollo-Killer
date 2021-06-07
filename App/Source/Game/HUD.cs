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

        public HUD()
        {
            Layer = ELayer.HUD;
            font = new Font("Data/Fonts/LuckiestGuy.ttf");
            tHUD = new Text("", font);
            //tHUD.FillColor = new Color(Color.Yellow);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            //Console.WriteLine("points: {0}", points);
            Console.WriteLine("lives: {0}", lives);
            Console.WriteLine("munition: {0}", munition);
        }

        public void addPoints(int p)
        {
            points += p;
        }
        public void liveCount (int l)
        {
            lives += l;
        }
        public void munitionCount(int m)
        {
            munition += m;
        }
    }
}

