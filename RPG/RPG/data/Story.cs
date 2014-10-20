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
            story.Add("intro0",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eu mattis orci. Suspendisse venenatis mi nisi,"+
                "ut tincidunt dui dictum in. Fusce posuere fringilla vestibulum. Nunc sit amet tincidunt felis. Ut ac arcu sit" +
                "amet eros interdum mattis non non sapien. Integer mollis nec dui non efficitur. Cras at dui a ex pulvinar" +
                "vestibulum. Aliquam faucibus, augue consequat tempus scelerisque, tortor diam rutrum augue, id dignissim" +
                "ligula eros in tortor. Nam at lacinia libero. Nunc at eleifend nulla, ut suscipit metus. Integer rutrum," +
                "nunc nec viverra sodales, arcu lorem fermentum nunc, ut aliquet lacus est eget neque.");
        }
    }
}
