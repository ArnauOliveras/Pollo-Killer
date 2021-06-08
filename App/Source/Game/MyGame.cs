using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System;

namespace TcGame
{
    public class MyGame : Game
    {
        public Scene Scene { private set; get; }

        public DebugManager Debug { private set; get; }

        public Vector2f MousePos { get { return new Vector2f(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y); } }

        public RenderWindow Window { private set; get; }

        /// <summary>
        /// Speed in pixels/second of the world vertical scroll
        /// </summary>
        public float WorldSpeed = 30.0f;

        /// <summary>
        /// Unique instance of MyGame
        /// </summary>
        private static MyGame instance; 
        public float maxMinY = 600;
        public float LeftMaxMinX = -40;
        public float RightMaxMinX = 1040;

        private Vector2f leftSightOffset, rightSightOffset;
        public static Vector2f leftStartPosition, rightStartPosition;

        public static bool gameStarted = false;
        HUD theHud = new HUD();
        private Music music;

        /// <summary>
        /// Accesor for MyGame, implements the Singleton pattern
        /// </summary>
        public static MyGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyGame();
                }

                return instance;
            }
        }

        private MyGame()
        {

        }

        public void Init()
        {
            Resources.LoadResources();

            VideoMode videoMode = new VideoMode(1000, 649);
            Window = new RenderWindow(videoMode, "MyGame");
            Window.SetVerticalSyncEnabled(true);

            Debug = new DebugManager();
            Debug.Init();

            music = new Music("Data/Audios/Song.wav");
            music.Play();
            music.Loop = true;

            Scene = new Scene();

            Intro intro;
            intro = Scene.Create<Intro>();
            intro.Speed = WorldSpeed;
            intro.Position = new Vector2f(65, 50);

            Background background;
            background = Scene.Create<Background>();
            background.Speed = WorldSpeed;

            leftSightOffset = new Vector2f(-85.0f, 250.0f);
            rightSightOffset = new Vector2f(65.0f, 250.0f);

            Sight leftSight;
            leftSight = Scene.Create<Sight>();
            leftSight.Position = new Vector2f(videoMode.Width, videoMode.Height) / 2 + leftSightOffset;
            leftStartPosition = leftSight.Position;

            SightX rightSight;
            rightSight = Scene.Create<SightX>();
            rightSight.Position = new Vector2f(videoMode.Width, videoMode.Height) / 2 + rightSightOffset;
            rightStartPosition = rightSight.Position;

            CreateWhiteHenSpawner();
            CreateGreenHenSpawner();
            CreateGoldenHenSpawner();
            CreateBirdSpawner();
            CreateWhiteHenXSpawner();
            CreateGreenHenXSpawner();
            CreateGoldenHenXSpawner();
            CreateBirdXSpawner();
        }

        //White
        private void CreateWhiteHenSpawner()
        {
            ActorSpawner<WhiteHen> spawner;
            spawner = Scene.Create<ActorSpawner<WhiteHen>>();
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MaxTime = 30.0f;
            spawner.nameEnemy = "whiteHen";
            spawner.Reset();
        }
        private void CreateWhiteHenXSpawner()
        {
            ActorSpawner<WhiteHenX> spawner;
            spawner = Scene.Create<ActorSpawner<WhiteHenX>>();
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MaxTime = 30.0f;
            spawner.nameEnemy = "whiteHen";
            spawner.Reset();
        }

        //Green
        private void CreateGreenHenSpawner()
        {
            ActorSpawner<GreenHen> spawner;
            spawner = Scene.Create<ActorSpawner<GreenHen>>(); 
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 30.0f;
            spawner.MaxTime = 100.0f;
            spawner.nameEnemy = "greenHen";
            spawner.Reset();
        }
        private void CreateGreenHenXSpawner()
        {
            ActorSpawner<GreenHenX> spawner;
            spawner = Scene.Create<ActorSpawner<GreenHenX>>();
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 30.0f;
            spawner.MaxTime = 100.0f;
            spawner.nameEnemy = "greenHen";
            spawner.Reset();
        }

        //Golden
        private void CreateGoldenHenSpawner()
        {
            ActorSpawner<GoldenHen> spawner;
            spawner = Scene.Create<ActorSpawner<GoldenHen>>();
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 20.0f;
            spawner.MaxTime = 80.0f;
            spawner.nameEnemy = "goldenHen";
            spawner.Reset();
        }
        private void CreateGoldenHenXSpawner()
        {
            ActorSpawner<GoldenHenX> spawner;
            spawner = Scene.Create<ActorSpawner<GoldenHenX>>();
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 20.0f;
            spawner.MaxTime = 80.0f;
            spawner.nameEnemy = "goldenHen";
            spawner.Reset();
        }

        //Bird
        private void CreateBirdSpawner()
        {
            ActorSpawner<Bird> spawner;
            spawner = Scene.Create<ActorSpawner<Bird>>();
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MaxTime = 30.0f;
            spawner.nameEnemy = "Bird";
            spawner.Reset();
        }
        
        private void CreateBirdXSpawner()
        {
            ActorSpawner<BirdX> spawner;
            spawner = Scene.Create<ActorSpawner<BirdX>>();
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MaxTime = 30.0f;
            spawner.nameEnemy = "Bird" ;
            spawner.Reset();
        }

        public void DeInit()
        {
            Debug.DeInit();
            Window.Dispose();
        }

        public void Update(float dt)
        {
            Window.DispatchEvents();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                Window.Close();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Num1) && gameStarted == false)
            {
                gameStarted = true;
                theHud.setLives(10);
                theHud.setMunition(20);
                CreateHUD();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Num2) && gameStarted == false)
            {
                gameStarted = true;
                theHud.setLives(5);
                theHud.setMunition(10);
                CreateHUD();

            }

            if (HUD.gameOver == true)
            {
                GameOver();
            }

            if (HUD.upgrade == true)
            {
                Upgrade();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.P) && music.Status == SoundStatus.Playing)
            {
                music.Pause();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.P) && music.Status == SoundStatus.Paused)
            {
                music.Play();
            }

            Debug.Update(dt);
            Scene.Update(dt);
        }

        public void Draw()
        {
            Window.Clear(new Color(100, 100, 100));

            Window.Draw(Scene);
            Window.Draw(Debug);

            Window.Display();
        }

        public bool IsAlive()
        {
            return Window.IsOpen;
        }

        private void GameOver()
        {
            End end;
            end = Scene.Create<End>();
            end.Speed = WorldSpeed;
            end.Position = new Vector2f(160, 100);
        }

        private void CreateHUD()
        {
            HUD hud;
            hud = Scene.Create<HUD>();

            HUDBackground hudBack;
            hudBack = Scene.Create<HUDBackground>();
            hudBack.Speed = WorldSpeed;
        }

        public void Upgrade()
        {
            Upgrade upgrade;
            upgrade = Scene.Create<Upgrade>();
            upgrade.Speed = WorldSpeed;
            upgrade.Position = new Vector2f(20, 100);
        }
    }
}

