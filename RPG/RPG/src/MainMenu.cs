using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class MainMenu : State
    {
        public enum states { mainMenu, loading, newGame, loadGame, credits };
        states state;
        states nextState;

        public MainMenu()
            : base()
        {
            state = states.loading;
            nextState = states.mainMenu;

            //Main Menu
            textures2Dlocations.Add("mainMenuBackground");
            textures2Dlocations.Add("buttonNewGame");
            textures2Dlocations.Add("buttonNewGamePressed");
            textures2Dlocations.Add("buttonLoadGame");
            textures2Dlocations.Add("buttonLoadGamePressed");
            textures2Dlocations.Add("buttonCredits");
            textures2Dlocations.Add("buttonCreditsPressed");
            textures2Dlocations.Add("buttonQuitGame");
            textures2Dlocations.Add("buttonQuitGamePressed");

            //New Game
            textures2Dlocations.Add("newGameBackground");
            textures2Dlocations.Add("buttonWarrior");
            textures2Dlocations.Add("buttonWarriorPressed");
            textures2Dlocations.Add("buttonArcher");
            textures2Dlocations.Add("buttonArcherPressed");
            textures2Dlocations.Add("buttonMage");
            textures2Dlocations.Add("buttonMagePressed");
            textures2Dlocations.Add("buttonBack");
            textures2Dlocations.Add("buttonBackPressed");
            textures2Dlocations.Add("buttonAccept");
            textures2Dlocations.Add("buttonAcceptPressed");




            textures2DlocationsCount = textures2Dlocations.Count;
        }

        public void doLogic()
        {
            if (state == nextState)
            {
                switch (state)
                {
                    //case states.mainMenu: 
                    #region
                    case states.mainMenu:
                        {
                            if (Game1.input.backButtonClick)
                            {
                                Game1.nextState = Game1.states.quit;
                                return;
                            }
                            if (Game1.input.click0)
                            {
                                if (textures2D["buttonQuitGame"].intersectsWithMouseClick())
                                {
                                    Game1.nextState = Game1.states.quit;
                                    return;
                                }
                                if (textures2D["buttonNewGame"].intersectsWithMouseClick())
                                {
                                    nextState = states.newGame;
                                    return;
                                }
                                if (textures2D["buttonLoadGame"].intersectsWithMouseClick())
                                {
                                    if (Game1.memoryCard.loadGame())
                                    {
                                        Game1.nextState = Game1.states.game;
                                    }
                                    else
                                    {
                                        nextState = states.newGame;
                                    }
                                    return;
                                }
                                if (textures2D["buttonCredits"].intersectsWithMouseClick())
                                {
                                    nextState = states.credits;
                                    return;
                                }
                            }
                        }
                        break;
                    #endregion
                    //case states.newGame:
                    #region
                    case states.newGame:
                        {
                            if (Game1.input.backButtonClick)
                            {
                                nextState = states.mainMenu;
                                return;
                            }

                            if (Game1.input.click0)
                            {
                                if (textures2D["backButton"].intersectsWithMouseClick())
                                {
                                    nextState = states.mainMenu;
                                    return;
                                }
                            }
                        }
                        break;
                    #endregion
                    //case states.loadGame:
                    #region
                    case states.loadGame:
                        {
                            if (Game1.memoryCard.loadGame())
                            {
                                Game1.nextState = Game1.states.game;
                            }
                            else
                            {
                                nextState = states.newGame;
                            }
                        }
                        break;
                    #endregion
                    //case states.credits:
                    #region
                    case states.credits:
                        {
                            //TODO Não Implementado
                            if (Game1.input.click0 || Game1.input.backButtonClick)
                            {
                                nextState = states.mainMenu;
                            }
                        }
                        break;
                    #endregion
                }
            }
            else
            {
                //Reload nextState
                switch (nextState)
                {
                    //case states.mainMenu:
                    #region
                    case states.mainMenu:
                        {
                            textures2D["buttonNewGame"].setPosition(400, 292);
                            textures2D["buttonNewGamePressed"].setPosition(400, 292);
                            textures2D["buttonLoadGame"].setPosition(400, 365);
                            textures2D["buttonLoadGamePressed"].setPosition(400, 365);
                            textures2D["buttonCredits"].setPosition(400, 439);
                            textures2D["buttonCreditsPressed"].setPosition(400, 439);
                            textures2D["buttonQuitGame"].setPosition(400, 512);
                            textures2D["buttonQuitGamePressed"].setPosition(400, 512);
                        }
                        break;
                    #endregion
                    //case states.newGame:
                    #region
                    case states.newGame:
                        {
                        }
                        break;
                    #endregion
                    //case states.loadGame:
                    #region
                    case states.loadGame:
                        {
                        }
                        break;
                    #endregion
                    //case states.credits:
                    #region
                    case states.credits:
                        {
                        }
                        break;
                    #endregion
                }
                state = nextState;
                Game1.needToDraw = true;
            }

        }

        public void draw()
        {
            switch (state)
            {
                //case states.mainMenu:
                #region
                case states.mainMenu:
                    {
                        textures2D["mainMenuBackground"].drawOnScreen();

                        textures2D["buttonNewGame"].drawOnScreen();
                        textures2D["buttonLoadGame"].drawOnScreen();
                        textures2D["buttonCredits"].drawOnScreen();
                        textures2D["buttonQuitGame"].drawOnScreen();

                        if (Game1.input.mouse0)
                        {
                            if (textures2D["buttonNewGame"].intersectsWithMouseClick())
                            {
                                textures2D["buttonNewGamePressed"].drawOnScreen();
                                return;
                            }
                            if (textures2D["buttonLoadGame"].intersectsWithMouseClick())
                            {
                                textures2D["buttonLoadGamePressed"].drawOnScreen();
                                return;
                            }
                            if (textures2D["buttonCredits"].intersectsWithMouseClick())
                            {
                                textures2D["buttonCreditsPressed"].drawOnScreen();
                                return;
                            }
                            if (textures2D["buttonQuitGame"].intersectsWithMouseClick())
                            {
                                textures2D["buttonQuitGamePressed"].drawOnScreen();
                                return;
                            }
                        }
                    }
                    break;
                #endregion
                //case states.newGame:
                #region
                case states.newGame:
                    {
                        textures2D["newGameBackground"].draw();
                    }
                    break;
                #endregion
                //case states.loadGame:
                #region
                case states.loadGame:
                    {
                    }
                    break;
                #endregion
                //case states.credits:
                #region
                case states.credits:
                    {
                    }
                    break;
                #endregion
            }
        }
    }
}
