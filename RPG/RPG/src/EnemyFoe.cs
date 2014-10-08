using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using RPG.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class EnemyFoe : GameBody
    {
        internal string state = "";
        internal Point texCoord;
        internal string typeToString;

        public EnemyFoe(int x, int y, int width, int height, int type)
            : base(x, y, width, height, BodyType.Dynamic)
        {
            this.typeToString = ((Enemies.types)type).ToString();

            body.FixedRotation = true;
            body.health = 100;
            body.LinearDamping = 10f;
            body.OnCollision += enemyFoeBody_OnCollision;
        }

        private bool enemyFoeBody_OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            return true;
        }

        internal void update()
        {
            
        }
    }
}
