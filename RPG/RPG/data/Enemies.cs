using RPG.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.data
{
    internal class Enemies
    {
        internal Dictionary<int, EnemyType> enemyTypes;

        EnemyType enemyType;

        internal static enum types { goblim, golem };

        internal Enemies()
        {
            enemyTypes = new Dictionary<int, EnemyType>();
        }

        internal void load()
        {
            enemyTypes.Clear();
            for (int i = 0; i < 2; i++)
            {
                switch ((types)i)
                {
                    case types.goblim:
                        {
                            enemyTypes.Add(i, enemyType = new EnemyType((types)i, 10, 10, 10, 10, 10, 10));
                        }
                        break;
                    case types.golem:
                        {
                            enemyTypes.Add(i, enemyType = new EnemyType((types)i, 10, 10, 10, 10, 10, 10));
                        }
                        break;
                    //default:
                    //    break;
                }
            }
        }
    }
}
