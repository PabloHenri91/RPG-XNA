using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class State
    {
        public Dictionary<string, Sprite> textures2D;
        protected List<string> textures2Dlocations;
        protected int textures2DlocationsCount;

        public State()
        {
            textures2D = new Dictionary<string, Sprite>();
            textures2Dlocations = new List<string>();
        }

        public bool load()
        {
            foreach (string reference in textures2Dlocations)
            {
                textures2D.Add(reference, new Sprite(reference));
            }
            return true;
        }
    }
}
