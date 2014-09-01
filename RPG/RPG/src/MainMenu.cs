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
        private string playerClass;

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
            textures2Dlocations.Add("warrior");
            textures2Dlocations.Add("mage");
            textures2Dlocations.Add("archer");
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
                                        Game1.nextState = Game1.states.mission;
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
                                if (textures2D["buttonBack"].intersectsWithMouseClick())
                                {
                                    nextState = states.mainMenu;
                                    return;
                                }
                                if (textures2D["buttonWarrior"].intersectsWithMouseClick())
                                {
                                    playerClass = "warrior";
                                    return;
                                }
                                if (textures2D["buttonArcher"].intersectsWithMouseClick())
                                {
                                    playerClass = "archer";
                                    return;
                                }
                                if (textures2D["buttonMage"].intersectsWithMouseClick())
                                {
                                    playerClass = "mage";
                                    return;
                                }
                                if (textures2D["buttonAccept"].intersectsWithMouseClick())
                                {
                                    Game1.memoryCard = new MemoryCard();
                                    Game1.memoryCard.newGame(playerClass);
                                    Game1.nextState = Game1.states.mission;
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
                                Game1.nextState = Game1.states.mission;
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
                positions.Clear();

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
                            playerClass = "warrior";

                            textures2D["buttonWarrior"].setPosition(430, 120);
                            textures2D["buttonWarriorPressed"].setPosition(430, 120);
                            textures2D["buttonArcher"].setPosition(430, 180);
                            textures2D["buttonArcherPressed"].setPosition(430, 180);
                            textures2D["buttonMage"].setPosition(430, 240);
                            textures2D["buttonMagePressed"].setPosition(430, 240);
                            textures2D["buttonBack"].setPosition(25, 625);
                            textures2D["buttonBackPressed"].setPosition(25, 625);
                            textures2D["buttonAccept"].setPosition(675, 530);
                            textures2D["buttonAcceptPressed"].setPosition(675, 530);
                            textures2D["warrior"].setPosition(110, 196);
                            textures2D["archer"].setPosition(110, 196);
                            textures2D["mage"].setPosition(110, 196);
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
                        textures2D["newGameBackground"].drawOnScreen();

                        textures2D["buttonWarrior"].drawOnScreen();
                        textures2D["buttonArcher"].drawOnScreen();
                        textures2D["buttonMage"].drawOnScreen();
                        textures2D["buttonBack"].drawOnScreen();
                        textures2D["buttonAccept"].drawOnScreen();

                        textures2D[playerClass].drawOnScreen();

                        if (Game1.input.mouse0)
                        {
                            if (textures2D["buttonWarrior"].intersectsWithMouseClick())
                            {
                                textures2D["buttonWarriorPressed"].drawOnScreen();
                                return;
                            }
                            if (textures2D["buttonArcher"].intersectsWithMouseClick())
                            {
                                textures2D["buttonArcherPressed"].drawOnScreen();
                                return;
                            }
                            if (textures2D["buttonMage"].intersectsWithMouseClick())
                            {
                                textures2D["buttonMagePressed"].drawOnScreen();
                                return;
                            }
                            if (textures2D["buttonBack"].intersectsWithMouseClick())
                            {
                                textures2D["buttonBackPressed"].drawOnScreen();
                                return;
                            }
                            if (textures2D["buttonAccept"].intersectsWithMouseClick())
                            {
                                textures2D["buttonAcceptPressed"].drawOnScreen();
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
