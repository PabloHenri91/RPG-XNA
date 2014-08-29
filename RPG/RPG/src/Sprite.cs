﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Sprite : Entity
    {
        internal Texture2D texture;
        internal Vector2 origin;
        internal Rectangle destinationRectangle;

        public Sprite(String reference)
            : base(0, 0, 0, 0)
        {
            texture = Game1.myContentManager.Load<Texture2D>(reference);
            width = texture.Width;
            rectangle.Width = width;
            height = texture.Height;
            rectangle.Height = height;
            biggerSide = Math.Max(width, height);

            origin = new Vector2(width / 2f, height / 2f);
            destinationRectangle = new Rectangle(0, 0, width, height);
        }

        public Sprite(String reference, ContentManager contentManager)
            : base(0, 0, 0, 0)
        {
            texture = contentManager.Load<Texture2D>(reference);
            width = texture.Width;
            rectangle.Width = width;
            height = texture.Height;
            rectangle.Height = height;
            biggerSide = Math.Max(width, height);

            origin = new Vector2(width / 2f, height / 2f);
            destinationRectangle = new Rectangle(0, 0, width, height);
        }

        public Sprite(String reference, int width, int height)
            : base(0, 0, width, height)
        {
            texture = Game1.myContentManager.Load<Texture2D>(reference);

            origin = new Vector2(width / 2f, height / 2f);
            destinationRectangle = new Rectangle(0, 0, width, height);
        }

        internal void draw()
        {
            destinationRectangle.X = (int)(position.X + Game1.matrix.X);
            destinationRectangle.Y = (int)(-position.Y + Game1.matrix.Y);
            Game1.spriteBatch.Draw(texture, destinationRectangle, null, Color.White, rotation, origin, SpriteEffects.None, 0f);
        }

        public void drawOnScreen()
        {
            destinationRectangle.X = (int)position.X;
            destinationRectangle.Y = (int)position.Y;
            Game1.spriteBatch.Draw(texture, destinationRectangle, null, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 0f);
        }

        public void drawOnScreen2()
        {
            destinationRectangle.X = (int)position.X;
            destinationRectangle.Y = (int)position.Y;
            Game1.spriteBatch.Draw(texture, destinationRectangle, null, Color.White, rotation, origin, SpriteEffects.None, 0f);
        }
    }
}
