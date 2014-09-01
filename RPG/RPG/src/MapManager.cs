using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class MapManager
    {
        List<Chunk> chunkList = new List<Chunk>();

        int regionX, regionY;
        private Point region;

        void reLoadMap(){
            chunkList.Clear();

            region = Game1.mission.player.region;

            for (int x = region.X - 1; x <= region.Y + 1; x++)
            {
                for (int y = region.X + 1; y >= region.Y - 1; y--)    
                {
                    chunkList.Add(new Chunk(x, y));
                }
            }
        }


    }
}
