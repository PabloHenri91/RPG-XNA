using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Player : GameBody
    {
        internal Player(int x, int y, int width, int height)
            : base(x, y, width, height, BodyType.Dynamic)
        {
            body.health = 100;

            body.OnCollision += playerBody_OnCollision;
        }

        private bool playerBody_OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            return true;
        }


        internal void update()
        {
            if (Game1.input.click0)
            {
                
            }
        }
    }
}
