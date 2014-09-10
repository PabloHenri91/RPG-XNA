using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    public class Input
    {
        private MouseState mouseState, lastMouseState;
        private bool backButtonPressed, lastBackButtonPressed, mouseStartMooving;
        public bool mouse0, click0, backButtonClick;
        private int clickInterval, last0Touch, mouseX, mouseY, lastMouseX, lastMouseY, dx, dy, totalDx, totalDy;
        public int onScreenMouseX, onScreenMouseY;
        public Rectangle mouseRectangle;
        public bool key_left, key_down, key_right, key_up;

        private KeyboardState keyboardState;
        private KeyboardState lastKeyboardState;

        public void setup()
        {
            clickInterval = Config.clickInterval;
            mouseRectangle = new Rectangle(0, 0, 1, 1);
        }

        public void update()
        {
            if (mouse0 || click0 || backButtonPressed)
            {
                Game1.needToDraw = true;
            }

            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastBackButtonPressed = backButtonPressed;
            backButtonPressed = keyboardState.IsKeyDown(Keys.Escape);
            backButtonClick = !backButtonPressed && lastBackButtonPressed;

            key_left = keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left);
            key_down = keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down);
            key_right = keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right);
            key_up = keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up);

            if ((keyboardState.IsKeyDown(Keys.LeftAlt) || keyboardState.IsKeyDown(Keys.RightAlt)) && (lastKeyboardState.IsKeyDown(Keys.Enter) && keyboardState.IsKeyUp(Keys.Enter)))
            {
                Config.IsFullScreen = !Config.IsFullScreen;
                Game1.display.setup(Game1.graphicsDeviceManager);
                switch (Game1.state)
                {
                    case Game1.states.mission:
                        Game1.mission.mapManager.reloadMiniMap();
                        break;
                    case Game1.states.loading:
                        break;
                    case Game1.states.mainMenu:
                        break;
                    case Game1.states.quit:
                        break;
                    default:
                        break;
                }
            }

            switch (Game1.state)
            {
                default:
                    {
                        lastMouseState = mouseState;
                        mouseState = Mouse.GetState();

                        click0 = ((lastMouseState.LeftButton == ButtonState.Pressed) && (mouseState.LeftButton == ButtonState.Released));

                        if (click0)
                        {
                            click0 = (Game1.frameCount - last0Touch < clickInterval);
                            mouse0 = false;
                            updateMousePosition();
                        }
                        else
                        {
                            mouse0 = mouseState.LeftButton == ButtonState.Pressed;

                            if (mouse0)
                            {
                                lastMouseX = mouseX;
                                lastMouseY = mouseY;
                                updateMousePosition();

                                if (mouseStartMooving)
                                {
                                    mouseStartMooving = false;
                                }
                                else
                                {
                                    dx = mouseX - lastMouseX;
                                    dy = mouseY - lastMouseY;
                                    totalDx = totalDx + dx;
                                    totalDy = totalDy + dy;
                                }
                            }
                            else
                            {
                                totalDx = 0;
                                totalDy = 0;
                                dx = 0;
                                dy = 0;
                                last0Touch = Game1.frameCount;
                                mouseStartMooving = true;
                            }
                        }
                    }
                    break;
            }
        }

        private void updateMousePosition()
        {
            mouseX = (int)(((mouseState.X / Game1.display.scale) - Game1.display.displayWidthOver2 + Game1.display.translateX) - Game1.matrix.X + Game1.display.displayWidthOver2);
            mouseY = (int)(-((mouseState.Y / Game1.display.scale) - Game1.display.displayHeightOver2 + Game1.display.translateY) - Game1.matrix.Y - Game1.display.displayHeightOver2);

            onScreenMouseX = (int)((mouseState.X / Game1.display.scale) + Game1.display.translateX);
            onScreenMouseY = (int)((mouseState.Y / Game1.display.scale) + Game1.display.translateY);

            mouseRectangle.X = onScreenMouseX;
            mouseRectangle.Y = onScreenMouseY;
        }
    }
}
