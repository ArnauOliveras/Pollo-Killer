﻿using SFML.Graphics;
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

        public enum State
        {
            None,
            Splash,
            Playing,
            Option
        }

        public State currentState = State.None;

        public void Init()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) ChangeState(State.Splash);
            //Engine.Get.Scene.Create<Background>();
            //HUD myHUD = Engine.Get.Scene.Create<HUD>();
            //Engine.Get.Scene.Create<FishSpawner>();

            Resources.LoadResources();

            VideoMode videoMode = new VideoMode(1000, 649);
            Window = new RenderWindow(videoMode, "MyGame");
            Window.SetVerticalSyncEnabled(true);

            Debug = new DebugManager();
            Debug.Init();

            Scene = new Scene();

            //Background background;
            //background = Scene.Create<Background>();
            //background.Speed = WorldSpeed;

            
            //WeaponSight weaponAim;
            //weaponAim = Scene.Create<WeaponSight>();
            //weaponAim.Position = new Vector2f(videoMode.Width, videoMode.Height) / 2;


            //CreateWhiteHenSpawner();
            //CreateGreenHenSpawner();
            //CreateGoldenHenSpawner();
            //CreateBirdSpawner();
            //CreateWhiteHenXSpawner();
            //CreateGreenHenXSpawner();
            //CreateGoldenHenXSpawner();
            //CreateBirdXSpawner();
        
        }

        public void ChangeState(State newState)
        {
            onLeaveState(currentState);
            onEnterState(newState);
            currentState = newState;

        }

        private void onLeaveState(State oldState)
        {
            switch (currentState)
            {
                case State.Splash:
                    Scene.Destroy(Scene.GetFirst<Splash>());
                    break;

                case State.Playing:
                    Scene.Destroy(Scene.GetFirst<Background>());
                    Scene.Destroy(Scene.GetFirst<HUD>());
                    break;
                case State.Option:
                    break;
            }
        }

        private void onEnterState(State newState)
        {
            switch (newState)
            {
                case State.Splash:
                    Scene.Create<Splash>();
                    break;

                case State.Playing:
                    Scene.Create<Background>();
                    Scene.Create<HUD>();
                    break;

                case State.Option:
                    break;
            }
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

