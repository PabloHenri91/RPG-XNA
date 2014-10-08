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

        //Move
        private Vector3 destination;
        private bool needToMove;
        private float cateto_adjacente;
        private float cateto_oposto;
        private float hipotenusa;
        private float auxRotation;
        private int directionInputCount;
        private float maxSpeed;

        internal Player(int x, int y, int width, int height)
            : base(x, y, width, height, BodyType.Dynamic)
        {
            body.FixedRotation = true;
            body.health = 100;
            body.LinearDamping = 10f;
            body.OnCollision += playerBody_OnCollision;

            maxSpeed = 5f;
        }

        private bool playerBody_OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            return true;
        }


        internal void update()
        {
            //if (Game1.input.mouse0)
            //{
            //    auxRotation = (float)-Math.Atan2(position.X - Game1.input.mouseX, -(position.Y - Game1.input.mouseY));
            //}
            //else
            //{
            //    auxRotation = (float)-Math.Atan2(position.X - destination.X, -(position.Y - destination.Y));
            //}
            move();
        }

        void move()
        {
            directionInputCount = 0;
            if (Game1.input.key_left) directionInputCount++;
            if (Game1.input.key_down) directionInputCount++;
            if (Game1.input.key_right) directionInputCount++;
            if (Game1.input.key_up) directionInputCount++;

            if (directionInputCount > 0)
            {
                needToMove = false;

                if ((body.LinearVelocity.X * body.LinearVelocity.X) + (body.LinearVelocity.Y * body.LinearVelocity.Y) < maxSpeed * maxSpeed)
                {
                    if (Game1.input.key_left)
                    {
                        body.ApplyForce(new Vector2(-maxSpeed, 0), body.Position);
                    }
                    if (Game1.input.key_down)
                    {
                        body.ApplyForce(new Vector2(0, -maxSpeed), body.Position);
                    }
                    if (Game1.input.key_right)
                    {
                        body.ApplyForce(new Vector2(maxSpeed, 0), body.Position);
                    }
                    if (Game1.input.key_up)
                    {
                        body.ApplyForce(new Vector2(0, maxSpeed), body.Position);
                    }
                }
            }
            else
            {
                if (Game1.input.click0)
                {
                    destination = new Vector3(Game1.input.mouseX, Game1.input.mouseY, (float)Game1.frameCount);
                    needToMove = true;
                }
            }

            if (needToMove)
            {
                cateto_adjacente = destination.X - position.X;
                cateto_oposto = destination.Y - position.Y;
                hipotenusa = (float)Math.Sqrt((cateto_adjacente * cateto_adjacente) + (cateto_oposto * cateto_oposto));

                if (hipotenusa < biggerSide || Game1.frameCount - destination.Z > 60 * 5)
                {
                    needToMove = false;
                }
                else
                {
                    if ((body.LinearVelocity.X * body.LinearVelocity.X) + (body.LinearVelocity.Y * body.LinearVelocity.Y) < maxSpeed * maxSpeed)
                    {
                        body.ApplyForce(new Vector2((cateto_adjacente / hipotenusa) * maxSpeed, (cateto_oposto / hipotenusa) * maxSpeed), body.Position);
                    }
                }
            }

            //texCoord.Y = 0; s -y
            //texCoord.Y = 1; a -x
            //texCoord.Y = 2; d +x
            //texCoord.Y = 3; w +y
            if (directionInputCount > 0 || needToMove)
            {
                if (Math.Abs(body.LinearVelocity.X) > Math.Abs(body.LinearVelocity.Y))
                {
                    texCoord.Y = (body.LinearVelocity.X < 0) ? 1 : 2;
                }
                else
                {
                    texCoord.Y = (body.LinearVelocity.Y < 0) ? 0 : 3;
                }

                texCoord.X = (Game1.frameCount / 10) % 3;
            }
            else
            {
                texCoord.X = 1;
            }
        }
    }
}
