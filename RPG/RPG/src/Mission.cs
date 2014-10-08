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
        Vector2 waterPosition;
        Vector2 waterDirection;

        //Map
        internal MapManager mapManager;

        //Phisics
        public World world;

        //
        List<EnemyFoe> enemyFoeList;
        private bool noEnemiesOnScreen;
        private int spawnedEnemies;
        private int lastSpawn;

        public Mission()
            : base()
        {
            state = states.loading;
            nextState = states.mission;

            world = new World(new Vector2(0f, 0f));

            story = new Story();

            mapManager = new MapManager();

            tilesetslocations.Add(Game1.memoryCard.playerClass + "Player", new Vector2(32));

            tilesetslocations.Add("golem", new Vector2(64));


            textures2Dlocations.Add("missionHUD");
            textures2Dlocations.Add("dot");
            textures2Dlocations.Add("water");

            enemyFoeList = new List<EnemyFoe>();
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

                            if (Game1.frameCount % 30 == 0)
                            {
                                waterDirection.X += -1 + (float)Game1.random.NextDouble() * 2;
                                waterDirection.Y += -1 + (float)Game1.random.NextDouble() * 2;

                                waterDirection.Normalize();
                            }

                            waterPosition += waterDirection;

                            player.getPosition();
                            player.update();
                            foreach (EnemyFoe enemyFoe in enemyFoeList)
                            {
                                enemyFoe.getPosition();
                            }
                            translateMatrix(player.position.X, player.position.Y);
                            mapManager.update();

                            updateEnemies();
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
                                player.getPosition();
                                translateMatrix(player.position.X, player.position.Y);
                                mapManager.reLoadMap();
                                textures2D["dot"].setPosition(900 - 4, 100 - 4);
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
            Game1.matrix.X = -x + Game1.display.displayWidthOver2 - 100;
            Game1.matrix.Y = -y + -Game1.display.displayHeightOver2 + 100;
        }

        public void draw()
        {
            switch (state)
            {
                case states.mission:
                    {
                        Game1.spriteBatch.End();

                        Game1.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, Game1.display.scissorTestRasterizerState, null, Game1.display.camera);
                        Game1.spriteBatch.Draw(textures2D["water"].texture, new Rectangle(Game1.display.displayWidthOver2, Game1.display.displayHeightOver2, Game1.display.displayWidth, Game1.display.displayHeight), new Rectangle((int)player.position.X + (int)waterPosition.X, (int)-player.position.Y + (int)waterPosition.Y, textures2D["water"].width, textures2D["water"].height), Color.White, 0, new Vector2(textures2D["water"].width / 2f, textures2D["water"].height / 2f), SpriteEffects.None, 0f);
                        Game1.spriteBatch.End();

                        Game1.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, Game1.display.scissorTestRasterizerState, null, Game1.display.camera);
                        mapManager.drawMapFloor();

                        foreach (EnemyFoe enemyFoe in enemyFoeList)
                        {
                            tilesets[enemyFoe.typeToString + enemyFoe.state].drawTile(enemyFoe.position, enemyFoe.texCoord.X, enemyFoe.texCoord.Y);
                        }

                        tilesets[Game1.memoryCard.playerClass + "Player"].setRotation(player.rotation);

                        tilesets[Game1.memoryCard.playerClass + "Player"].drawTile((int)player.position.X, (int)player.position.Y, player.texCoord.X, player.texCoord.Y);
                        mapManager.drawMapRoof();
                        textures2D["missionHUD"].drawOnScreen();
                        mapManager.drawMiniMap();
                        textures2D["dot"].drawOnScreen();
                    }
                    break;
                case states.pause:
                    {

                    }
                    break;
            }
        }

        //case states.mission:
        #region
        private void updateEnemies()
        {
            noEnemiesOnScreen = true;
            tryToSpawEnemyFoe();

            foreach (EnemyFoe enemyFoe in enemyFoeList)
            {
                enemyFoe.update();
            }

            for (int i = enemyFoeList.Count - 1; i >= 0; i--)
            {
                if (enemyFoeList[i].body.IsDisposed)
                {
                    enemyFoeList.RemoveAt(i);
                    spawnedEnemies--;
                }
            }
        }

        private void tryToSpawEnemyFoe()
        {
            if (player.body.health > 0)
            {
                if (Game1.frameCount - lastSpawn > Game1.config.spawningInterval)
                {
                    spawnEnemyFoe();
                    spawnedEnemies++;
                    lastSpawn = Game1.frameCount;
                }
            }
        }

        private void spawnEnemyFoe()
        {
            enemyFoeList.Add(new EnemyFoe(0, 0, 64, 64, 1));
        }
        #endregion
    }
}