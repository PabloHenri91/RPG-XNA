using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class MapManager
    {
        //for
        int i;

        List<Chunk> chunkList = new List<Chunk>();
        List<Chunk> miniMapChunkList = new List<Chunk>();

        internal Point playerRegion;
        internal Point loadedRegion;

        //Mini Map
        private RenderTarget2D miniMapRenderTarget2D;
        internal Texture2D miniMapTexture2d;
        internal Rectangle miniMapAuxRetangle;

        //Draw MiniMap
        private Rectangle miniMapDestinationRectangle;
        private Rectangle sourceRectangle;
        private Vector2 miniMapAuxPosition;

        public MapManager()
        {
            /*
             * 0    1   2   3   4
             * 5    6   7   8   9
             * 10   11  12  13  14
             * 15   16  17  18  19
             * 20   21  22  23  24
             * 
             * 0    1   2
             * 3    4   5
             * 6    7   8
             */
            miniMapRenderTarget2D = new RenderTarget2D(Game1.graphicsDeviceManager.GraphicsDevice, 320, 320);
            miniMapAuxRetangle = new Rectangle(0, 0, 1, 1);
            miniMapDestinationRectangle = new Rectangle(804, 4, 192, 192);
            sourceRectangle = new Rectangle(0, 0, 192, 192);
        }

        internal void update()
        {
            playerRegion.X = (int)(Game1.mission.player.position.X / Config.chunkSize);
            playerRegion.Y = (int)(Game1.mission.player.position.Y / Config.chunkSize);

            if (playerRegion.X <= 0)
            {
                if (Game1.mission.player.position.X < 0)
                {
                    playerRegion.X--;
                }
            }

            if (playerRegion.Y <= 0)
            {
                if (Game1.mission.player.position.Y < 0)
                {
                    playerRegion.Y--;
                }
            }

            if (playerRegion != loadedRegion)
            {
                loadMap();
                updateMiniMapTexture2d();
                loadedRegion = playerRegion;
            }
        }

        private void loadMap()
        {
            if (playerRegion.X < loadedRegion.X)
            {
                loadA();
            }
            if (playerRegion.Y < loadedRegion.Y)
            {
                loadS();
            }
            if (playerRegion.X > loadedRegion.X)
            {
                loadD();
            }
            if (playerRegion.Y > loadedRegion.Y)
            {
                loadW();
            }
        }

        private void loadW()
        {
            for (i = 0; i < 4; i++)
            {
                miniMapChunkList[20 - (i * 5)] = miniMapChunkList[15 - (i * 5)];
                miniMapChunkList[21 - (i * 5)] = miniMapChunkList[16 - (i * 5)];
                miniMapChunkList[22 - (i * 5)] = miniMapChunkList[17 - (i * 5)];
                miniMapChunkList[23 - (i * 5)] = miniMapChunkList[18 - (i * 5)];
                miniMapChunkList[24 - (i * 5)] = miniMapChunkList[19 - (i * 5)];
            }

            miniMapChunkList[0] = new Chunk(playerRegion.X - 2, playerRegion.Y + 2);
            miniMapChunkList[1] = new Chunk(playerRegion.X - 1, playerRegion.Y + 2);
            miniMapChunkList[2] = new Chunk(playerRegion.X + 0, playerRegion.Y + 2);
            miniMapChunkList[3] = new Chunk(playerRegion.X + 1, playerRegion.Y + 2);
            miniMapChunkList[4] = new Chunk(playerRegion.X + 2, playerRegion.Y + 2);

            for (i = 0; i < 2; i++)
            {
                chunkList[6 - (i * 3)] = chunkList[3 - (i * 3)];
                chunkList[7 - (i * 3)] = chunkList[4 - (i * 3)];
                chunkList[8 - (i * 3)] = chunkList[5 - (i * 3)];
            }

            chunkList[0] = miniMapChunkList[6];
            chunkList[1] = miniMapChunkList[7];
            chunkList[2] = miniMapChunkList[8];
        }

        private void loadD()
        {
            for (i = 0; i < 4; i++)
            {
                miniMapChunkList[0 + i] = miniMapChunkList[1 + i];
                miniMapChunkList[5 + i] = miniMapChunkList[6 + i];
                miniMapChunkList[10 + i] = miniMapChunkList[11 + i];
                miniMapChunkList[15 + i] = miniMapChunkList[16 + i];
                miniMapChunkList[20 + i] = miniMapChunkList[21 + i];
            }

            miniMapChunkList[4] = new Chunk(playerRegion.X + 2, playerRegion.Y + 2);
            miniMapChunkList[9] = new Chunk(playerRegion.X + 2, playerRegion.Y + 1);
            miniMapChunkList[14] = new Chunk(playerRegion.X + 2, playerRegion.Y + 0);
            miniMapChunkList[19] = new Chunk(playerRegion.X + 2, playerRegion.Y - 1);
            miniMapChunkList[24] = new Chunk(playerRegion.X + 2, playerRegion.Y - 2);

            for (i = 0; i < 2; i++)
            {
                chunkList[0 + i] = chunkList[1 + i];
                chunkList[3 + i] = chunkList[4 + i];
                chunkList[6 + i] = chunkList[7 + i];
            }

            chunkList[2] = miniMapChunkList[8];
            chunkList[5] = miniMapChunkList[13];
            chunkList[8] = miniMapChunkList[18];
        }

        private void loadS()
        {
            for (i = 0; i < 4; i++)
            {
                miniMapChunkList[0 + (i * 5)] = miniMapChunkList[5 + (i * 5)];
                miniMapChunkList[1 + (i * 5)] = miniMapChunkList[6 + (i * 5)];
                miniMapChunkList[2 + (i * 5)] = miniMapChunkList[7 + (i * 5)];
                miniMapChunkList[3 + (i * 5)] = miniMapChunkList[8 + (i * 5)];
                miniMapChunkList[4 + (i * 5)] = miniMapChunkList[9 + (i * 5)];
            }

            miniMapChunkList[20] = new Chunk(playerRegion.X - 2, playerRegion.Y - 2);
            miniMapChunkList[21] = new Chunk(playerRegion.X - 1, playerRegion.Y - 2);
            miniMapChunkList[22] = new Chunk(playerRegion.X + 0, playerRegion.Y - 2);
            miniMapChunkList[23] = new Chunk(playerRegion.X + 1, playerRegion.Y - 2);
            miniMapChunkList[24] = new Chunk(playerRegion.X + 2, playerRegion.Y - 2);

            for (i = 0; i < 2; i++)
            {
                chunkList[0 + (i * 3)] = chunkList[3 + (i * 3)];
                chunkList[1 + (i * 3)] = chunkList[4 + (i * 3)];
                chunkList[2 + (i * 3)] = chunkList[5 + (i * 3)];
            }

            chunkList[6] = miniMapChunkList[16];
            chunkList[7] = miniMapChunkList[17];
            chunkList[8] = miniMapChunkList[18];
        }

        private void loadA()
        {
            for (i = 0; i < 4; i++)
            {
                miniMapChunkList[4 - i] = miniMapChunkList[3 - i];
                miniMapChunkList[9 - i] = miniMapChunkList[8 - i];
                miniMapChunkList[14 - i] = miniMapChunkList[13 - i];
                miniMapChunkList[19 - i] = miniMapChunkList[18 - i];
                miniMapChunkList[24 - i] = miniMapChunkList[23 - i];
            }

            miniMapChunkList[0] = new Chunk(playerRegion.X - 2, playerRegion.Y + 2);
            miniMapChunkList[5] = new Chunk(playerRegion.X - 2, playerRegion.Y + 1);
            miniMapChunkList[10] = new Chunk(playerRegion.X - 2, playerRegion.Y + 0);
            miniMapChunkList[15] = new Chunk(playerRegion.X - 2, playerRegion.Y - 1);
            miniMapChunkList[20] = new Chunk(playerRegion.X - 2, playerRegion.Y - 2);

            for (i = 0; i < 2; i++)
            {
                chunkList[2 - i] = chunkList[1 - i];
                chunkList[5 - i] = chunkList[4 - i];
                chunkList[8 - i] = chunkList[7 - i];
            }

            chunkList[0] = miniMapChunkList[6];
            chunkList[3] = miniMapChunkList[11];
            chunkList[6] = miniMapChunkList[16];
        }

        public void reLoadMap()
        {
            playerRegion.X = (int)(Game1.mission.player.position.X / Config.chunkSize);
            playerRegion.Y = (int)(Game1.mission.player.position.Y / Config.chunkSize);

            chunkList.Clear();
            for (int y = playerRegion.Y + 1; y >= playerRegion.Y - 1; y--)
            {
                for (int x = playerRegion.X - 1; x <= playerRegion.X + 1; x++)
                {
                    chunkList.Add(new Chunk(x, y));
                }
            }

            reloadMiniMap();
            loadedRegion = playerRegion;
        }

        public void drawMapFloor()
        {
            foreach (Chunk chunk in chunkList)
            {
                chunk.drawChunkFloor();
            }
        }

        public void drawMapRoof()
        {
            foreach (Chunk chunk in chunkList)
            {
                chunk.drawChunkRoof();
            }
        }

        internal void reloadMiniMap()
        {
            miniMapChunkList.Clear();
            for (int y = playerRegion.Y + 2; y >= playerRegion.Y - 2; y--)
            {
                for (int x = playerRegion.X - 2; x <= playerRegion.X + 2; x++)
                {
                    miniMapChunkList.Add(new Chunk(x, y));
                }
            }

            updateMiniMapTexture2d();
        }

        private void updateMiniMapTexture2d()
        {
            miniMapRenderTarget2D = new RenderTarget2D(Game1.graphicsDeviceManager.GraphicsDevice, 320, 320);
            Game1.graphicsDeviceManager.GraphicsDevice.SetRenderTarget(miniMapRenderTarget2D);
            Game1.spriteBatch.Begin();

            if (miniMapTexture2d != null)
            {
                miniMapAuxPosition.X = (loadedRegion.X - playerRegion.X) * Config.tilesPerChunk;
                miniMapAuxPosition.Y = -((loadedRegion.Y - playerRegion.Y) * Config.tilesPerChunk);
                Game1.spriteBatch.Draw((Texture2D)miniMapTexture2d, miniMapAuxPosition, Color.White);
            }

            foreach (var chunk in miniMapChunkList)
            {
                if (chunk.needToDrawOnMiniMap)
                {
                    chunk.drawOnMiniMap();
                    chunk.needToDrawOnMiniMap = false;
                }
            }

            Game1.spriteBatch.End();
            Game1.graphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);

            Game1.graphicsDeviceManager.GraphicsDevice.ScissorRectangle = Game1.display.centerViewport.Bounds;
            Game1.graphicsDeviceManager.GraphicsDevice.Viewport = Game1.display.centerViewport;

            miniMapTexture2d = (Texture2D)miniMapRenderTarget2D;
        }

        internal void drawMiniMap()
        {
            sourceRectangle.X = (int)(((Game1.mission.player.position.X - Config.chunkSize * playerRegion.X) / Config.tileSize) + (Config.tilesPerChunk * 0.5f));
            sourceRectangle.Y = (int)((-(Game1.mission.player.position.Y - Config.chunkSize * playerRegion.Y) / Config.tileSize) + (Config.tilesPerChunk * 1.5f));

            Game1.spriteBatch.Draw(miniMapTexture2d, miniMapDestinationRectangle, sourceRectangle, Color.White);
        }
    }
}
