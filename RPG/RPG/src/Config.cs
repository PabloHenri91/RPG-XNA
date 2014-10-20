using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    public class Config
    {
        public static int displayWidth = 1000;
        public static int displayHeight = 700;

        public static bool IsFullScreen = false;

        public static int clickInterval = 60;

        public static float tileSize = 16;
        public static float tilesPerChunk = 64;
        public static float chunksPerMap = 64;

        public static float chunkSize = tilesPerChunk * tileSize;
        public static float mapSize = chunksPerMap * chunkSize;

        //Foes
        public int spawningInterval = 60 * 5;
        public static int idleInterval = 6;
    }
}
