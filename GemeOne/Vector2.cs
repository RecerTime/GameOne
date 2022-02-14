using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GemeOne
{
    public struct Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }

        public Vector2 ArrayToVector2(float[] input)
        {
            if (input.Length != 2)
            {
                throw new ArgumentException();
            }
            return new Vector2(input[0], input[1]);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public Vector2 Normalize()
        {
            float magnitude = Magnitude();
            return new Vector2(x / magnitude, y / magnitude);
        }

        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }

        public Point ToPoint(Size size)
        {
            return new Point((int)x - (size.Width / 2), (int)y - (size.Height / 2));
        }

        public float Distance(Vector2 comparator)
        {
            return 0f;//MathF.Sqrt(MathF.Pow(comparator.x - x, 2) + MathF.Pow(comparator.y - y, 2));
        }

        public bool IsEqualTo (Vector2 comparator)
        {
            return comparator.x == x && comparator.y == y;
        }

        public bool IsEqualTo(Vector2[] comparatorArray)
        {
            bool ret = false;
            for (int i = 0; i < comparatorArray.Length; i++)
            {
                if (comparatorArray[i].x == x && comparatorArray[i].y == y)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public Vector2 add(Vector2 vector2)
        {
            return new Vector2(x + vector2.x, y + vector2.y);
        }

        public Vector2 add(float o)
        {
            return new Vector2(x + o, y + o);
        }

        public Vector2 multiply(Vector2 vector2)
        {
            return new Vector2(x * vector2.x + x * vector2.y, y * vector2.x + y * vector2.y);
        }

        public Vector2 multiply(float o)
        {
            return new Vector2(x * o, y * o);
        }

        public Vector2 subtract(Vector2 vector2)
        {
            return new Vector2(x - vector2.x, y - vector2.y);
        }

        public float[] vectorToArray(Vector2 input)
        {
            float[] output = new float[2];

            output[0] = input.x;
            output[1] = input.y;

            return output;
        }
    }
}