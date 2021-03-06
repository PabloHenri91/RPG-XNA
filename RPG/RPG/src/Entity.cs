﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Entity
    {
        internal Vector2 position;
        internal float rotation;
        internal int width;
        internal int height;
        internal int biggerSide;
        internal Rectangle rectangle;

        internal Entity(float x, float y, int width, int height)
        {
            this.width = width;
            this.height = height;
            biggerSide = Math.Max(width, height);
            position = new Vector2(x, y);

            rectangle = new Rectangle((int)x, (int)y, width, height);
        }

        internal void setSize(int width, int height)
        {
            this.width = width;
            this.height = height;

            biggerSide = Math.Max(width, height);

            rectangle.Width = width;
            rectangle.Height = height;
        }

        internal void setPosition(float x, float y)
        {
            if (position.X == x && position.Y == y)
            {
                return;
            }
            Game1.needToDraw = true;
            this.position.X = x;
            this.position.Y = y;
        }

        internal void setPosition(Vector2 vector2)
        {
            if (position == vector2)
            {
                return;
            }
            Game1.needToDraw = true;
            this.position = vector2;
        }

        internal void setRotation(float rotation)
        {
            if (this.rotation == rotation)
            {
                return;
            }
            Game1.needToDraw = true;
            this.rotation = rotation;
        }

        internal void setPosition(float x, float y, float rotation)
        {
            if (this.rotation == rotation)
            {
                if (position.X == x && position.Y == y)
                {
                    return;
                }
            }
            Game1.needToDraw = true;
            position.X = x;
            position.Y = y;
            this.rotation = rotation;
        }

        public bool intersectsWithMouseClick()
        {
            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
            return Game1.input.mouseRectangle.Intersects(rectangle);
        }

        public bool intersectsWithMouseClick(int x, int y)
        {
            rectangle.X = x;
            rectangle.Y = y;
            return Game1.input.mouseRectangle.Intersects(rectangle);
        }

        public bool intersectsWithMouseClick(Vector2 vector2)
        {
            rectangle.X = (int)vector2.X;
            rectangle.Y = (int)vector2.Y;
            return Game1.input.mouseRectangle.Intersects(rectangle);
        }
    }
}
