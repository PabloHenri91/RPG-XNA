using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class MemoryCard
    {
        private int i;
        private string line;

        internal bool loadGame()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader("data"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();

                        if (line.StartsWith("="))
                        {
                            i = Convert.ToInt32(line.Split('=')[1]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
