using RPG.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.data
{
    class Players
    {
        internal Dictionary<string, PlayerType> playerTypes;

        internal Players()
        {
            playerTypes = new Dictionary<string, PlayerType>(3);
            playerTypes.Add("warrior", new PlayerType("warrior", 15, 15, 0, 0, 0, 0));
            playerTypes.Add("archer", new PlayerType("archer", 0, 0, 0, 0, 15, 15));
            playerTypes.Add("mage", new PlayerType("mage", 0, 0, 15, 15, 0, 0));
        }
    }
}
