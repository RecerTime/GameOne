using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GemeOne
{
    public class Controller
    {
        public Vector2 gameworldSize = new Vector2(160, 90);
        public Platform[] platforms = new Platform[] { new Platform(new Vector2(40, 80), new Vector2(30, 1.5f)), new Platform(new Vector2(40, 80), new Vector2(1.5f, 10)) };
        public Character player = new Player(new Vector2(8, 10), 5);

        const int tickTime = 16;
        public System.Timers.Timer gameTick = new System.Timers.Timer();

        public double lineDist;
        public Controller()
        {
            gameTick.Elapsed += UpdateGamestate;
            gameTick.Interval = tickTime;
            gameTick.Start();
        }

        public void MovePlayer(Keys keys)
        {
            float velX = player.velocity.x;
            switch (keys)
            {
                case Keys.D:
                    velX += 1;
                    break;

                case Keys.A:
                    velX += -1;
                    break;

                case Keys.Space:
                    if (player.grounded)
                    {
                        player.velocity.y -= 1;
                    }
                    break;
            }

            if (player.velocity.x < 1 && player.velocity.x > -1)
            {
                player.velocity.x = velX;
            }
        }

        void UpdateGamestate(object source, System.Timers.ElapsedEventArgs e)
        {
            Vector2[] playerBoundingBox = player.UpdatePhysics();
            bool onGround = false;
            Line intersectedLine = new Line(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
            player.grounded = false;

            for (int i = 0; i < platforms.Length; i++)
            {
                Line[] lines = platforms[i].GetLines();

                for (int o = 0; o < lines.Length; o++)
                {
                    for (int u = 0; u < playerBoundingBox.Length; u++)
                    {
                        lineDist = Math.Abs(playerBoundingBox[u].y - ((lines[o].k * playerBoundingBox[u].x) + lines[o].m));
                        if (lines[o].OnLine(playerBoundingBox[u], 5))
                        {
                            onGround = true;
                            intersectedLine = lines[o];
                        }
                    }
                }

                /*if (playerBoundingBox[i].x > platform.boundingBox[0].x && playerBoundingBox[i].x < platform.boundingBox[1].x)
                {
                    if (Math.Abs(platform.boundingBox[0].y - playerBoundingBox[i].y) < 1)
                    {
                        player.grounded = true;

                        if (platform.boundingBox[2].y > playerBoundingBox[i].y && platform.boundingBox[0].y < playerBoundingBox[i].y)
                        {
                            onGround = true;
                        }
                    }
                }*/
            }

            if (onGround)
            {
                player.velocity.y = player.velocity.y * -1;
                player.position.y = intersectedLine.y1 - player.radius;

                player.velocity = player.velocity.multiply(0.6f);
            }

            player.position = player.position.add(player.velocity);
            player.boundingBox = player.UpdatePhysics();
        }
    }
}
