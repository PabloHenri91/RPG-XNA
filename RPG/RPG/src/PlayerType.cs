﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class PlayerType
    {
        public string type;
        public int strenghtBonus;
        public int enduranceBonus;
        public int intelligenceBonus;
        public int willpowerBonus;
        public int speedBonus;
        public int agilityBonus;

        public PlayerType(string type, int strenght, int endurance, int intelligence, int willpower, int speed, int agility)
        {
            this.type = type;
            this.strenghtBonus = strenght;
            this.enduranceBonus = endurance;
            this.intelligenceBonus = intelligence;
            this.willpowerBonus = willpower;
            this.speedBonus = speed;
            this.agilityBonus = agility;
        }
    }
}
