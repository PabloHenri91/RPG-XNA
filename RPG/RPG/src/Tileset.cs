using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    internal class Tileset : Sprite
    {
        internal int tileWidth, tileHeight;
        internal int tilesPerRow;
        internal int tilesPerColumn;
        private Rectangle source;
        internal int tilesCount;

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
            destinationRectangle.Y = -(int)(y + Game1.matrix.Y);
            Game1.spriteBatch.Draw(texture, destinationRectangle, source, Color.White, rotation, origin, SpriteEffects.None, 0f);
        }

        internal void drawTile(int x, int y, int texCoordx, int texCoordy, Color color)
        {
            source.X = texCoordx * tileWidth;
            source.Y = texCoordy * tileHeight;
            destinationRectangle.X = (int)(x + Game1.matrix.X);
            destinationRectangle.Y = -(int)(y + Game1.matrix.Y);
            Game1.spriteBatch.Draw(texture, destinationRectangle, source, color, rotation, origin, SpriteEffects.None, 0f);
        }

        internal void drawTile(Vector2 position, int texCoordx, int texCoordy)
        {
            source.X = texCoordx * tileWidth;
            source.Y = texCoordy * tileHeight;
            destinationRectangle.X = (int)(position.X + Game1.matrix.X);
            destinationRectangle.Y = -(int)(position.Y + Game1.matrix.Y);
            Game1.spriteBatch.Draw(texture, destinationRectangle, source, Color.White, rotation, origin, SpriteEffects.None, 0f);
        }

        internal void drawTileOnMiniMap(int x, int y, int texCoordx, int texCoordy)
        {
            source.X = texCoordx * tileWidth;
            source.Y = texCoordy * tileHeight;
            Game1.mission.mapManager.miniMapAuxRetangle.X = x;
            Game1.mission.mapManager.miniMapAuxRetangle.Y = -y;
            Game1.spriteBatch.Draw(texture, Game1.mission.mapManager.miniMapAuxRetangle, source, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 0f);
        }
    }
}

