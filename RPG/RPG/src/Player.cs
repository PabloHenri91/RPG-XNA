using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Player : GameBody
    {
        internal Point region;

        internal void getRegion()
        {
            region.X = (int)(position.X / (16f * 64f));
            region.Y = (int)(position.Y / (16f * 64f));
            //if (region.X != loadedRegionX && region.Y != loadedRegionY)
            //{
            //    mapManager.reLoadMap(world, regionX, regionY, contentManager);
            //    loadedRegionX = regionX;
            //    loadedRegionY = regionY;
            //}
            //else if (regionX != loadedRegionX || regionY != loadedRegionY)
            //{
            //    mapManager.loadMap(world, regionX, regionY, contentManager);
            //    loadedRegionX = regionX;
            //    loadedRegionY = regionY;
            //}
        }
    }
}
