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
        internal Point texCoord;
        internal Player(int x, int y, int width, int height)
            : base(x, y, width, height, BodyType.Dynamic)
        {
            body.health = 100;

            body.LinearDamping = 20f;

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
            move();
        }

        void move()
        {
            int maxSpeed = 100;
            if (Game1.input.key_left && body.LinearVelocity.X > -maxSpeed)
            {
                body.ApplyForce(new Vector2(-100f, 0), body.Position);
                texCoord.Y = 1;
            }
            if (Game1.input.key_down && body.LinearVelocity.Y > -maxSpeed)
            {
                body.ApplyForce(new Vector2(0, -100f), body.Position);
                texCoord.Y = 0;
            }
            if (Game1.input.key_right && body.LinearVelocity.X < maxSpeed)
            {
                body.ApplyForce(new Vector2(100f, 0), body.Position);
                texCoord.Y = 2;
            }
            if (Game1.input.key_up && body.LinearVelocity.Y < maxSpeed)
            {
                body.ApplyForce(new Vector2(0, 100f), body.Position);
                texCoord.Y = 3;
            }
        }
    }
}
