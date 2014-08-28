using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Sprite
    {
        public int width;
        public int height;
        public int biggerSide;

        public Texture2D texture;
        public Vector2 position;
        public float rotation = 0;

        public Sprite(String reference)
        {
            texture = Game1.myContentManager.Load<Texture2D>(reference);
            width = texture.Width;
            height = texture.Height;
            biggerSide = Math.Max(width, height);
        }

        public Sprite(String reference, ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>(reference);
            width = texture.Width;
            height = texture.Height;
            biggerSide = Math.Max(width, height);
        }

        public Sprite(String reference, int width, int height)
        {
            texture = Game1.myContentManager.Load<Texture2D>(reference);
            this.width = width;
            this.height = height;
            biggerSide = Math.Max(width, height);
        }

        public void setAngle(float rotation)
        {
            if (this.rotation == rotation)
            {
                return;
            }
            Game1.needToDraw = true;
            this.rotation = rotation;
        }

        public void setPosition(int x, int y)
        {
            if (position.X == x && position.Y == y)
            {
                return;
            }
            Game1.needToDraw = true;
            this.position.X = x;
            this.position.Y = y;
        }

        public void setPosition(int x, int y, float rotation)
        {
            if (this.rotation == rotation)
            {
                if (position.X == x && position.Y == y)
                {
                    return;
                }
            }
            Game1.needToDraw = true;
            this.position.X = x;
            this.position.Y = y;
            this.rotation = rotation;
        }

        public void draw()
        {
            Game1.spriteBatch.Draw(texture, new Vector2(position.X + Game1.matrix.X - width / 2f, -1f * (position.Y + Game1.matrix.Y + height / 2f)), Color.White);
        }

        public void drawOnScreen()
        {
            Game1.spriteBatch.Draw(texture, position, Color.White);
        }
        public void drawOnScreen2()
        {
            Game1.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, width, height), null, Color.White, rotation, new Vector2(width / 2f, height / 2f), SpriteEffects.None, 0f);
        }

        public void draw(int x, int y)
        {
            Game1.spriteBatch.Draw(texture, new Vector2(x + Game1.matrix.X - width / 2f, -1f * (y + Game1.matrix.Y + height / 2f)), Color.White);
        }

        public void draw(Vector2 vector2)
        {
            Game1.spriteBatch.Draw(texture, new Vector2(vector2.X + Game1.matrix.X - width / 2f, -1f * (vector2.Y + Game1.matrix.Y + height / 2f)), Color.White);
        }

        public void drawOnScreen(Vector2 vector2)
        {
            Game1.spriteBatch.Draw(texture, vector2, Color.White);
        }

        public void draw(int x, int y, float rotation)
        {
            Game1.spriteBatch.Draw(texture, new Rectangle((int)(x + Game1.matrix.X), (int)(y - Game1.matrix.Y), width, height), null, Color.White, rotation, new Vector2(width / 2f, height / 2f), SpriteEffects.None, 0f);
        }

        public void drawOnScreen(int x, int y, float rotation)
        {
            Game1.spriteBatch.Draw(texture, new Rectangle(x, y, width, height), null, Color.White, rotation, new Vector2(width / 2f, height / 2f), SpriteEffects.None, 0f);
        }

        public bool intersectsWithMouseClick()
        {
            Rectangle me = new Rectangle((int)position.X, (int)position.Y, width, height);
            Rectangle him = new Rectangle(Game1.input.onScreenMouseX, Game1.input.onScreenMouseY, 1, 1);
            return him.Intersects(me);
        }

        public bool intersectsWithMouseClick(int x, int y)
        {
            Rectangle me = new Rectangle(x, y, width, height);
            Rectangle him = new Rectangle(Game1.input.onScreenMouseX, Game1.input.onScreenMouseY, 1, 1);
            return him.Intersects(me);
        }

        public bool intersectsWithMouseClick(Vector2 vector2)
        {
            Rectangle me = new Rectangle((int)vector2.X, (int)vector2.Y, width, height);
            Rectangle him = new Rectangle(Game1.input.onScreenMouseX, Game1.input.onScreenMouseY, 1, 1);
            return him.Intersects(me);
        }
    }
}
