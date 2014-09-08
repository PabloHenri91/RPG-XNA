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
        protected Body body;

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
            body.SetTransform(new Vector2(ConvertUnits.ToSimUnits(x), ConvertUnits.ToSimUnits(y)), body.Rotation);
        }

        internal new void setPosition(Vector2 vector2)
        {
            base.setPosition(vector2);
            body.SetTransform(vector2, body.Rotation);
        }

        internal new void setPosition(float x, float y, float rotation)
        {
            base.setPosition(x, y, rotation);
            body.SetTransform(new Vector2(ConvertUnits.ToSimUnits(x), ConvertUnits.ToSimUnits(y)), rotation);
        }
    }
}
