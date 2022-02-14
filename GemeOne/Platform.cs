using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemeOne
{
    public class Platform : Collider
    {
        public Vector2 position;
        public Vector2 rectSize;
        public Platform(Vector2 pos, Vector2 size)
        {
            shape = "box";

            position = pos;
            rectSize = size;

            boundingBox = GenerateCollider(position, rectSize);
        }
        public Line[] GetLines()
        {
            return new Line[] { new Line(boundingBox[0], boundingBox[1]), new Line(boundingBox[1], boundingBox[2]), new Line(boundingBox[2], boundingBox[3]), new Line(boundingBox[3], boundingBox[0]) };
        }
    }
}
