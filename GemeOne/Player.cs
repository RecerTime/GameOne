using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemeOne
{
    class Player : Character
    {
        public Player(Vector2 pos, float size)
        {
            shape = "circle";
            position = pos;
            radius = size;
        }
    }
}
