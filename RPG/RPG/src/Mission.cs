using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.data;
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

        private Story story;

        internal Player player;

        internal MapManager mapManager;

        //Phisics
        public World world;

        public Mission()
            : base()
        {
            state = states.loading;
            nextState = states.mission;

            world = new World(new Vector2(0f, 0f));

            story = new Story();

            mapManager = new MapManager();

            tilesetslocations.Add(Game1.memoryCard.playerClass + "Player", new Vector2(32));

            textures2Dlocations.Add("missionHUD");
        }

        public void doLogic()
        {
            if (state == nextState)
            {
                switch (state)
                {
                    case states.mission: 
                        {
                            world.Step(Game1.frameDurationSeconds);
                            player.getPosition();
                            player.update();
                            translateMatrix(player.position.X, player.position.Y);
                            
                            mapManager.update();
                        }
                        break;
                    case states.pause: 
                        {

                        }
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
                            if (player == null)
                            {
                                player = new Player(0, 0, 32, 32);
                                mapManager.reLoadMap();
                            }
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

        private void translateMatrix(float x, float y)
        {
            Game1.matrix.X = -x + Game1.display.displayWidthOver2 -100;
            Game1.matrix.Y = -y + -Game1.display.displayHeightOver2 +100;
        }

        public void draw()
        {
            switch (state)
            {
                case states.mission: 
                    {
                        mapManager.drawMapFloor();
                        tilesets[Game1.memoryCard.playerClass + "Player"].drawTile((int)player.position.X, (int)player.position.Y, 0, 0);
                        mapManager.drawMapRoof();
                        Game1.spriteBatch.Draw(mapManager.miniMapTexture2d, new Vector2(800, 0), Color.White);
                        textures2D["missionHUD"].drawOnScreen();
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
