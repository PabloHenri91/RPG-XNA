using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Mission : State
    {
        internal enum states { mission, loading, pause };
        states state;
        states nextState;

        internal Player player;
        public Point playerRegion;

        public Mission()
            : base()
        {
            state = states.loading;
            nextState = states.mission;

            tilesetslocations.Add(Game1.memoryCard.playerClass + "Player", new Vector2(32));
        }

        public void doLogic()
        {
            if (state == nextState)
            {
                switch (state)
                {
                    case states.mission: 
                        {
                            player.getRegion();
                        }
                        break;
                    case states.pause: { }
                        break;
                }
            }
            else
            {
                //Reload nextState
                positions.Clear();

                switch (nextState)
                {
                    case states.mission:
                        {
                            
                        }
                        break;
                    case states.pause: 
                        {

                        }
                        break;
                }
                state = nextState;
                Game1.needToDraw = true;
            }
        }

        public void draw()
        {
            switch (state)
            {
                case states.mission: 
                    {
                        tilesets[Game1.memoryCard.playerClass + "Player"].drawTile(0, 0, 0, 0);
                    }
                    break;
                case states.pause: 
                    {

                    }
                    break;
            }
        }
    }
}
