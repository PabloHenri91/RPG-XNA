using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class EnemyFoe : GameBody
    {
        internal string state;
        internal Point texCoord;
        internal int type;

        public EnemyFoe(int width, int height, int type)
            : base(width, height, 0, 0, BodyType.Dynamic)
        {
            this.type = type;
            state = "";
        }

        internal void update()
        {
            
        }
    }
}
