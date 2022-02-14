using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemeOne
{
    public class Line
    {
        public Vector2 p1;
        public Vector2 p2;

        public float x1;
        public float x2;
        public float y1;
        public float y2;

        public float m;
        public float k;

        public Line(Vector2 point1, Vector2 point2)
        {
            p1 = point1;
            p2 = point2;

            x1 = p1.x;
            y1 = p1.y;

            x2 = p2.x;
            y2 = p2.y;
        }

        public Line(float xOne, float yOne, float xTwo, float yTwo)
        {
            x1 = xOne;
            x2 = xTwo;

            y1 = yOne;
            y2 = yTwo;

            p1 = new Vector2(x1, y1);
            p2 = new Vector2(x2, y2);
        }

        void GetVars()
        {
            k = (y1 - y2) / (x1 - x2);
            m = y1 - (k * x1);
        }

        public bool OnLine(Vector2 input)
        {
            return input.y == (k*input.x) + m;
        }

        public bool OnLine(Vector2 input, float distance)
        {
            return Math.Abs(input.y - ((k * input.x) + m)) < distance;
        }
    }
}
