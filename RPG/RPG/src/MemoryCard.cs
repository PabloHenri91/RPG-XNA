using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RPG.src
{
    class MemoryCard
    {
        private int i;

        private string line;
        private PropertyInfo propertyInfo;

        public int level;
        public string playerClass;
        public int strenght;
        public int endurance;
        public int intelligence;
        public int willpower;
        public int speed;
        public int agility;

        internal bool loadGame()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader("data"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();

                        propertyInfo = this.GetType().GetProperty(line.Split('=')[0]);
                        propertyInfo.SetValue(this, Convert.ChangeType(line.Split('=')[1], propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal void newGame(string playerClass)
        {
            this.playerClass = playerClass;

            level = 1;

            strenght = 10 + Game1.players.playerTypes[playerClass].strenghtBonus;
            endurance = 10 + Game1.players.playerTypes[playerClass].enduranceBonus;
            intelligence = 10 + Game1.players.playerTypes[playerClass].intelligenceBonus;
            willpower = 10 + Game1.players.playerTypes[playerClass].willpowerBonus;
            speed = 10 + Game1.players.playerTypes[playerClass].speedBonus;
            agility = 10 + Game1.players.playerTypes[playerClass].agilityBonus;
        }
    }
}
