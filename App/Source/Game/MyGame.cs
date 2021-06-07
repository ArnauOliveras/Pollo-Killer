using SFML.Graphics;
using SFML.System;
using SFML.Window;

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
        public float LeftMaxMinX = -20;
        public float RightMaxMinX = 1020;

        private Vector2f leftSightOffset, rightSightOffset;

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

            //if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            //{
            //    gameStarted = true;
            //}

            Resources.LoadResources();

            VideoMode videoMode = new VideoMode(1000, 649);
            Window = new RenderWindow(videoMode, "MyGame");
            Window.SetVerticalSyncEnabled(true);

            Debug = new DebugManager();
            Debug.Init();

            Scene = new Scene();

            Background background;
            background = Scene.Create<Background>();
            background.Speed = WorldSpeed;

            //if (gameStarted == true)
            //{ 
            //}

            leftSightOffset = new Vector2f(30.0f, -30.0f);
            rightSightOffset = new Vector2f(-40.0f, -30.0f);

            Sight leftSight;
            leftSight = Scene.Create<Sight>();
            leftSight.Position = new Vector2f(videoMode.Width, videoMode.Height) / 2 + leftSightOffset;

            Sight rightSight;
            rightSight = Scene.Create<Sight>();
            rightSight.Position = new Vector2f(videoMode.Width, videoMode.Height) / 2 + rightSightOffset;

            //WeaponSight weaponAim;
            //weaponAim = Scene.Create<WeaponSight>();
            //weaponAim.Position = new Vector2f(videoMode.Width, videoMode.Height) / 2;

            CreateWhiteHenSpawner();
            CreateGreenHenSpawner(); 
            CreateGoldenHenSpawner();
            CreateBirdSpawner();
            CreateWhiteHenXSpawner();
            CreateGreenHenXSpawner();
            CreateGoldenHenXSpawner();
            CreateBirdXSpawner();
        }

        private void CreateWhiteHenSpawner()
        {
            ActorSpawner<WhiteHen> spawner;
            spawner = Scene.Create<ActorSpawner<WhiteHen>>();
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MinTime = 10.0f;
            spawner.Reset();
        }
        private void CreateGreenHenSpawner()
        {
            ActorSpawner<GreenHen> spawner;
            spawner = Scene.Create<ActorSpawner<GreenHen>>(); 
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 20.0f;
            spawner.MinTime = 30.0f;
            spawner.Reset();
        }
        private void CreateGoldenHenSpawner()
        {
            ActorSpawner<GoldenHen> spawner;
            spawner = Scene.Create<ActorSpawner<GoldenHen>>();
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 10.0f;
            spawner.MinTime = 20.0f;
            spawner.Reset();
        }
        private void CreateBirdSpawner()
        {
            ActorSpawner<Bird> spawner;
            spawner = Scene.Create<ActorSpawner<Bird>>();
            spawner.MinPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(LeftMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MinTime = 10.0f;
            spawner.Reset();
        }
        private void CreateWhiteHenXSpawner()
        {
            ActorSpawner<WhiteHenX> spawner;
            spawner = Scene.Create<ActorSpawner<WhiteHenX>>();
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MinTime = 10.0f;
            spawner.Reset();
        }
        private void CreateGreenHenXSpawner()
        {
            ActorSpawner<GreenHenX> spawner;
            spawner = Scene.Create<ActorSpawner<GreenHenX>>(); 
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 20.0f;
            spawner.MinTime = 30.0f;
            spawner.Reset();
        }
        private void CreateGoldenHenXSpawner()
        {
            ActorSpawner<GoldenHenX> spawner;
            spawner = Scene.Create<ActorSpawner<GoldenHenX>>();
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 10.0f;
            spawner.MinTime = 20.0f;
            spawner.Reset();
        }
        private void CreateBirdXSpawner()
        {
            ActorSpawner<BirdX> spawner;
            spawner = Scene.Create<ActorSpawner<BirdX>>();
            spawner.MinPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MaxPosition = new Vector2f(RightMaxMinX, maxMinY);
            spawner.MinTime = 5.0f;
            spawner.MinTime = 10.0f;
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
    }
}

