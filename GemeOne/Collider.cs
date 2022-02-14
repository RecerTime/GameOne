using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GemeOne
{
    public class Collider
    {
        public string shape = "";
        public Vector2[] boundingBox;
        public float angle;

        Color color;

        public Vector2[] GenerateCollider(Vector2 pos, Vector2 size)
        {
            Vector2[] vector2s;

            switch (shape)
            {
                case "":
                    vector2s = new Vector2[] { };
                    break;

                case "box":
                    vector2s = new Vector2[] { pos.subtract(size), new Vector2(pos.x + size.x, pos.y - size.y), pos.add(size), new Vector2(pos.x - size.x, pos.y + size.y) };
                    break;

                case "circle":
                    vector2s = new Vector2[] { };
                    break;

                default:
                    vector2s = new Vector2[] { };
                    break;
            }

            return vector2s;
        }

        public Vector2[] GenerateCollider(Vector2 pos, float size)
        {
            Vector2[] vector2s;

            switch (shape)
            {
                case "":
                    vector2s = new Vector2[] { };
                    break;

                case "box":
                    vector2s = new Vector2[] { pos.add(-size), pos.add(new Vector2(size, -size)), pos.add(size), pos.add(new Vector2(-size, size)) };
                    break;

                case "circle":
                    List<Vector2> postitions = new List<Vector2>();

                    int d = (5 - (int)size * 4) / 4;
                    int x = 0;
                    int y = (int)size;

                    do
                    {
                        postitions.Add(new Vector2(pos.x + x, pos.y + y));

                        postitions.Add(new Vector2(pos.x + x, pos.y - y));

                        postitions.Add(new Vector2(pos.x - x, pos.y + y));

                        postitions.Add(new Vector2(pos.x - x, pos.y - y));

                        postitions.Add(new Vector2(pos.x + y, pos.y + x));

                        postitions.Add(new Vector2(pos.x + y, pos.y - x));

                        postitions.Add(new Vector2(pos.x - y, pos.y + x));

                        postitions.Add(new Vector2(pos.x - y, pos.y - x));

                        if (d < 0)
                        {
                            d += 2 * x + 1;
                        }
                        else
                        {
                            d += 2 * (x - y) + 1;
                            y--;
                        }
                        x++;
                    }
                    while (x < y);

                    vector2s = postitions.ToArray();
                    break;

                default:
                    vector2s = new Vector2[] { };
                    break;
            }

            return vector2s;
        }
    }
}