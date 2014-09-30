using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class GameBody : Entity
    {
        internal Body body;
        private Vector2 transform;

        internal GameBody(float x, float y,int width, int height, BodyType bodyType)
            : base(x, y, width, height)
        {
            body = BodyFactory.CreateRectangle(Game1.mission.world, ConvertUnits.ToSimUnits(width), ConvertUnits.ToSimUnits(height), 1f);
            body.BodyType = bodyType;
            setPosition(x, y);
        }

        internal void getPosition()
        {
            if (position.X == ConvertUnits.ToDisplayUnits(body.Position.X) && position.Y == ConvertUnits.ToDisplayUnits(body.Position.Y))
            {
                return;
            }
            Game1.needToDraw = true;
            position.X = ConvertUnits.ToDisplayUnits(body.Position.X);
            position.Y = ConvertUnits.ToDisplayUnits(body.Position.Y);
            rotation = body.Rotation;
        }

        internal new void setPosition(float x, float y)
        {
            base.setPosition(x, y);
            transform.X = ConvertUnits.ToSimUnits(x);
            transform.Y = ConvertUnits.ToSimUnits(y);
            body.SetTransform(transform, body.Rotation);
        }

        internal new void setPosition(Vector2 vector2)
        {
            base.setPosition(vector2);
            body.SetTransform(vector2, body.Rotation);
        }

        internal new void setPosition(float x, float y, float rotation)
        {
            base.setPosition(x, y, rotation);
            transform.X = ConvertUnits.ToSimUnits(x);
            transform.Y = ConvertUnits.ToSimUnits(y);
            body.SetTransform(transform, rotation);
        }
    }
}
