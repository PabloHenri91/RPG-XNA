using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class State
    {
        public Dictionary<string, Sprite> textures2D;
        public Dictionary<string, Tileset> tilesets;

        protected List<string> textures2Dlocations;
        protected Dictionary<string, Vector2> tilesetslocations;

        protected int textures2DlocationsCount;
        protected int tilesetslocationsCount;

        protected Dictionary<string, Vector2> positions;

        public State()
        {
            textures2D = new Dictionary<string, Sprite>();
            textures2Dlocations = new List<string>();

            tilesets = new Dictionary<string, Tileset>();
            tilesetslocations = new Dictionary<string, Vector2>();


            positions = new Dictionary<string, Vector2>();
        }

        public bool load()
        {
            textures2DlocationsCount = textures2Dlocations.Count;
            tilesetslocationsCount = tilesetslocations.Count;

            foreach (string reference in textures2Dlocations)
            {
                textures2D.Add(reference, new Sprite(reference));
            }

            foreach (KeyValuePair<string, Vector2> reference in tilesetslocations)
            {
                tilesets.Add(reference.Key, new Tileset(reference.Key, (int)reference.Value.X, (int)reference.Value.Y));
            }

            return true;
        }
    }
}
