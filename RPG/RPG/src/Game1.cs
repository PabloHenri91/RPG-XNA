using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;
using RPG.data;

namespace RPG.src
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphicsDeviceManager;
        public static SpriteBatch spriteBatch;
        public static ContentManager myContentManager;
        private bool contentIsEmpty;

        //FPS
        private int fps = 60;
        public static int frameCount;

        //Performance
        public static bool needToDraw;
        private int lastMilliseconds;
        private int elapsedMilliseconds;
        private int oversleep;
        private int last;
        private int elapsed;

        //Estados
        public enum states { game, loading, mainMenu, quit };
        public static states state;
        public static states nextState;
        private LoadScreen loadScreen;
        private MainMenu mainMenu;

        //Display
        public static Display display;
        public static Vector2 matrix;

        //Memory Card
        internal static MemoryCard memoryCard;

        //Entradas
        public static Input input;

        //Fonts
        private SpriteFont verdana20;
        private SpriteFont verdana12;

        //Story
        private Story story;

        //Aux
        private Random random;
        public static Config config;
        private Texture2D voidTexture;
        private bool loadScreenLoaded;

        //Debug
#if DEBUG
        private int updateCount;
        private int drawCount;
        private float timeSinceLastDraw;
        private int dps;
        private float timeSinceLastUpdate;
        private int ups;
#endif

        public Game1()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //FPS
            IsFixedTimeStep = false;
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = TimeSpan.FromTicks(10000000 / fps);
            frameCount = 0;

            //Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromMilliseconds(1000);

            myContentManager = new ContentManager(Services, "Content");
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Iniciando o Display
            display = new Display();
            display.setup(graphicsDeviceManager);

            config = new Config();

            input = new Input();
            input.setup();

            random = new Random();

            memoryCard = new MemoryCard();

            //Definindo Estados
            state = states.loading;
            nextState = states.mainMenu;

            loadScreenLoaded = false;
            contentIsEmpty = true;

            //iniciando matriz
            matrix = new Vector2((float)display.displayWidthOver2, -(float)display.displayHeightOver2);

            story = new Story();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            verdana20 = Content.Load<SpriteFont>("verdana20");
            verdana12 = Content.Load<SpriteFont>("verdana12");
            voidTexture = Content.Load<Texture2D>("void");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            lastMilliseconds = Environment.TickCount;

            needToDraw = false;
#if DEBUG
            countFPSUpdate(gameTime);
#endif
            input.update();

            if (state == nextState)
            {
                switch (state)
                {
                    case states.mainMenu:
                        mainMenu.doLogic();
                        break;
                }
            }
            else if (loadScreenLoaded)
            {
                needToDraw = true;
                unloadContent(state);
                switch (nextState)
                {
                    case states.mainMenu:
                        if (mainMenu == null)
                            mainMenu = new MainMenu();
                        if (mainMenu.load())
                            changeState();
                        break;
                }
            }
            else
            {
                unloadContent(state);
                if (loadScreen == null)
                    loadScreen = new LoadScreen();
                loadScreenLoaded = loadScreen.load(Content);
            }

            if (nextState == states.quit)
                this.Exit();

            base.Update(gameTime);

            frameCount++;
#if DEBUG
            updateCount++;
#endif

            if (state == nextState)
            {
                if (!needToDraw)
                {
#if !DEBUG
                    Sleep();
                    this.SuppressDraw();
#else
                    drawCount--;
#endif
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
#if DEBUG
            countFPSDraw(gameTime);
#endif
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, display.scissorTestRasterizerState, null, display.camera);

            if (state == nextState)
            {
                switch (state)
                {
                    case states.mainMenu:
                        mainMenu.draw();
                        break;
                }
            }
            else if (loadScreenLoaded)
            {
                loadScreen.draw();
            }
#if DEBUG
            spriteBatch.DrawString(verdana12, "Logic FPS: " + ups, new Vector2(11f, 11f), Color.Black);
            spriteBatch.DrawString(verdana12, "Logic FPS: " + ups, new Vector2(10f, 10f), Color.White);
            spriteBatch.DrawString(verdana12, "Draw FPS: " + dps, new Vector2(11f, 26f), Color.Black);
            spriteBatch.DrawString(verdana12, "Draw FPS: " + dps, new Vector2(10f, 25f), Color.White);
#endif
            spriteBatch.End();
#if DEBUG
            drawCount++;
#endif
            base.Draw(gameTime);

            if (state == nextState)
            {
                Sleep();
            }
        }

        private void unloadContent(states state)
        {
            if (contentIsEmpty == false)
            {
                IsFixedTimeStep = false;
                graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;

                myContentManager.Unload();
                contentIsEmpty = true;

                switch (state)
                {
                    case states.mainMenu:
                        mainMenu = null;
                        break;
                }
            }
        }
        private void changeState()
        {
            IsFixedTimeStep = true;
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = true;

            state = nextState;
            Game1.needToDraw = true;
            contentIsEmpty = false;
            GC.Collect();
        }

#if DEBUG
        private void countFPSUpdate(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastDraw += elapsed;

            if (timeSinceLastDraw > 1)
            {
                dps = drawCount;
                drawCount = 0;
                timeSinceLastDraw -= 1;
            }
        }
#endif

#if DEBUG
        private void countFPSDraw(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastUpdate += elapsed;

            if (timeSinceLastUpdate > 1)
            {
                ups = updateCount;
                updateCount = 0;
                timeSinceLastUpdate -= 1;
            }
        }
#endif

        private void Sleep()
        {
            //Resumo. Era pra funcionar assim mas precisou de vários ajustes
            //elapsedMilliseconds = Environment.TickCount - lastMilliseconds;
            //if (elapsedMilliseconds < frameDuration)
            //{
            //    System.Threading.Thread.Sleep(frameDuration - elapsedMilliseconds);
            //}

            elapsedMilliseconds = Environment.TickCount - lastMilliseconds;
            if (elapsedMilliseconds < TargetElapsedTime.TotalMilliseconds)//Need to sleep?
            {
                if (elapsedMilliseconds + oversleep < TargetElapsedTime.TotalMilliseconds)
                {
                    last = Environment.TickCount;
                    Thread.Sleep((int)TargetElapsedTime.TotalMilliseconds - (elapsedMilliseconds + oversleep));//Sleep
                    elapsed = Environment.TickCount - last;

                    if (elapsedMilliseconds + elapsed > TargetElapsedTime.TotalMilliseconds)
                    {
                        oversleep = (((elapsedMilliseconds + elapsed - (int)TargetElapsedTime.TotalMilliseconds) + oversleep) / 2);
                    }
                }
                else if (oversleep > 0)
                {
                    oversleep--;
                }
            }
        }
    }
}
