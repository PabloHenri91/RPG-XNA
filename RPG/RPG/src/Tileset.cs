using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.src
{
    internal class Tileset : Sprite
    {
        internal int tileWidth, tileHeight;
        internal int tilesPerRow;
        internal int tilesPerColumn;
        private Rectangle source;
        internal int tilesCount;

        internal Tileset(String reference, int tileSize)
            : base(reference)
        {
            tileWidth = tileSize;
            tileHeight = tileSize;
            tilesPerRow = texture.Width / tileSize;
            tilesPerColumn = texture.Height / tileSize;
            tilesCount = tilesPerRow * tilesPerColumn;
            source = new Rectangle(0, 0, tileSize, tileSize);
            origin = new Vector2(tileWidth / 2f, tileHeight / 2f);
            destinationRectangle.Width = tileWidth;
            destinationRectangle.Height = tileHeight;
        }

        internal Tileset(String reference, int tileWidth, int tileHeight)
            : base(reference, tileWidth, tileHeight)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            tilesPerRow = texture.Width / tileWidth;
            tilesPerColumn = texture.Height / tileHeight;
            tilesCount = tilesPerRow * tilesPerColumn;
            source = new Rectangle(0, 0, tileWidth, tileHeight);
            origin = new Vector2(tileWidth / 2f, tileHeight / 2f);
            destinationRectangle.Width = tileWidth;
            destinationRectangle.Height = tileHeight;
        }

        internal void drawTile(int x, int y, int texCoordx, int texCoordy)
        {
            source.X = texCoordx * tileWidth;
            source.Y = texCoordy * tileHeight;
            destinationRectangle.X = (int)(x + Game1.matrix.X);
            destinationRectangle.Y = (int)(-y + Game1.matrix.Y);
            Game1.spriteBatch.Draw(texture, destinationRectangle, source, Color.White, 0f, origin, SpriteEffects.None, 0f);
        }
    }
}

