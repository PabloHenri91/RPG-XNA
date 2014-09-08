using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    public class Display
    {
        public int displayWidth;
        public int displayHeight;
        public int displayWidthOver2;
        public int displayHeightOver2;
        public Matrix camera;
        public float scale;
        public float translateY;
        public float translateX;

        public Viewport screenViewport;
        public Viewport centerViewport;
        public RasterizerState scissorTestRasterizerState;

        public void setup(GraphicsDeviceManager graphicsDeviceManager)
        {
            scissorTestRasterizerState = new RasterizerState
            {
                ScissorTestEnable = true,
                CullMode = CullMode.None
            };

            //Resolução virtual
            displayWidth = Config.displayWidth;;
            displayHeight = Config.displayHeight;
            displayWidthOver2 = displayWidth / 2;
            displayHeightOver2 = displayHeight / 2;

            graphicsDeviceManager.IsFullScreen = Config.IsFullScreen;

            if (graphicsDeviceManager.IsFullScreen)
            {
                if (graphicsDeviceManager.GraphicsDevice.DisplayMode.Width > graphicsDeviceManager.GraphicsDevice.DisplayMode.Height)
                {
                    graphicsDeviceManager.PreferredBackBufferWidth = graphicsDeviceManager.GraphicsDevice.DisplayMode.Width;
                    graphicsDeviceManager.PreferredBackBufferHeight = graphicsDeviceManager.GraphicsDevice.DisplayMode.Height;
                }
                else
                {
                    graphicsDeviceManager.PreferredBackBufferWidth = graphicsDeviceManager.GraphicsDevice.DisplayMode.Height;
                    graphicsDeviceManager.PreferredBackBufferHeight = graphicsDeviceManager.GraphicsDevice.DisplayMode.Width;
                }
            }
            else
            {
                graphicsDeviceManager.PreferredBackBufferWidth = displayWidth;
                graphicsDeviceManager.PreferredBackBufferHeight = displayHeight;
            }

            graphicsDeviceManager.ApplyChanges();

            screenViewport = graphicsDeviceManager.GraphicsDevice.Viewport;
            centerViewport = screenViewport;

            float scaleX = (float)graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferWidth / displayWidth;
            float scaleY = (float)graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferHeight / displayHeight;
            scale = Math.Min(scaleX, scaleY);

            translateX = ((float)graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferWidth - (displayWidth * scale)) / 2f;
            translateY = ((float)graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferHeight - (displayHeight * scale)) / 2f;

            camera = Matrix.CreateScale(scale, scale, 1);

            centerViewport.X = (int)translateX;
            centerViewport.Width = (int)(centerViewport.Width - translateX - translateX);
            centerViewport.Y = (int)translateY;
            centerViewport.Height = (int)(centerViewport.Height - translateY - translateY);

            graphicsDeviceManager.GraphicsDevice.ScissorRectangle = centerViewport.Bounds;
            graphicsDeviceManager.GraphicsDevice.Viewport = centerViewport;

            translateX = -translateX / scale;
            translateY = -translateY / scale;
        }
    }
}
