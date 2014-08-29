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
        private bool backButtonPressed, lastBackButtonPressed, startMooving;
        public bool mouse0, click0, backButtonClick;
        private int clickInterval, last0Touch, mouseX, mouseY, lastMouseX, lastMouseY, dx, dy, totalDx, totalDy;
        public int onScreenMouseX, onScreenMouseY;
        public Rectangle mouseRectangle;

        public void setup()
        {
            clickInterval = Game1.config.clickInterval;
            mouseRectangle = new Rectangle(0, 0, 1, 1);
        }

        public void update()
        {
            if (mouse0 || click0 || backButtonPressed)
            {
                Game1.needToDraw = true;
            }

            lastBackButtonPressed = backButtonPressed;

            backButtonPressed = Keyboard.GetState().IsKeyDown(Keys.Escape);

            backButtonClick = !backButtonPressed && lastBackButtonPressed;

            switch (Game1.state)
            {
                default:
                    {
                        lastMouseState = mouseState;
                        mouseState = Mouse.GetState();

                        click0 = ((lastMouseState.LeftButton == ButtonState.Pressed) && (mouseState.LeftButton == ButtonState.Released));

                        if (click0)
                        {
                            click0 = (Game1.frameCount - last0Touch < Game1.config.clickInterval);
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

                                if (startMooving)
                                {
                                    startMooving = false;
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
                                startMooving = true;
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
