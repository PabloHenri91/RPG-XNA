using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.data
{
    class Story
    {
        public Dictionary<string, string> story;
        public Story()
        {
            story = new Dictionary<string, string>();
        }

        void load(){
            story.Clear();
            story.Add("intro0" , "");
        }
    }
}
