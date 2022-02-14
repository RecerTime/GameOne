using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GemeOne
{
    public partial class GemeWindow : Form
    {
        Controller controller = new Controller();

        Pen playerPen = new Pen(Color.Red);
        Pen platformPen = new Pen(Color.Blue);

        const int fps = 120;
        public System.Windows.Forms.Timer drawTimer = new System.Windows.Forms.Timer();

        Bitmap bitmap;
        Graphics g;

        public GemeWindow()
        {
            InitializeComponent();

            drawTimer.Tick += new EventHandler(Draw);
            drawTimer.Interval = 1000 / fps;

            this.DoubleBuffered = true;

            bitmap = new Bitmap(MainWindow.Size.Width, MainWindow.Size.Height);
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            drawTimer.Start();
        }

        void Draw(Object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);

            Size rectSize;
            Point rectPoint;

            for (int i = 0; i < controller.platforms.Length; i++)
            {
                rectSize = GameVectorToScreenSize(controller.platforms[i].rectSize.multiply(2));
                rectPoint = GameVectorToScreenPoint(controller.platforms[i].position);

                g.DrawRectangle(platformPen, new Rectangle(new Point(rectPoint.X - (rectSize.Width / 2), rectPoint.Y - (rectSize.Height / 2)), rectSize));
            }



            for (int i = 0; i < controller.player.boundingBox.Length; i++)
            {
                rectPoint = GameVectorToScreenPoint(controller.player.boundingBox[i]);
                bitmap.SetPixel(rectPoint.X, rectPoint.Y, Color.Black);
            }

            /*Size playerRectSize = GameVectorToScreenSize(controller.player.radius*2);
            Point playerRectPoint = GameVectorToScreenPoint(controller.player.position);
            g.DrawEllipse(playerPen, new Rectangle(new Point(playerRectPoint.X - (playerRectSize.Width / 2), playerRectPoint.Y - (playerRectSize.Height / 2)), playerRectSize));*/

            MainWindow.Image = bitmap;
        }

        private void textbox1_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e)
        {
            controller.MovePlayer(e.KeyCode);
        }

        Point GameVectorToScreenPoint(Vector2 input)
        {
            return new Point((int)((input.x * (MainWindow.MaximumSize.Width - MainWindow.MinimumSize.Width)) / (controller.gameworldSize.x + MainWindow.MinimumSize.Width)),
                (int)((input.y * (MainWindow.MaximumSize.Height - MainWindow.MinimumSize.Height)) / (controller.gameworldSize.y + MainWindow.MinimumSize.Height)));
        }

        Size GameVectorToScreenSize(Vector2 input)
        {
            return new Size((int)((input.x * (MainWindow.MaximumSize.Width - MainWindow.MinimumSize.Width)) / (controller.gameworldSize.x + MainWindow.MinimumSize.Width)),
                (int)((input.y * (MainWindow.MaximumSize.Height - MainWindow.MinimumSize.Height)) / (controller.gameworldSize.y + MainWindow.MinimumSize.Height)));
        }

        Size GameVectorToScreenSize(float input)
        {
            return new Size((int)((input * (MainWindow.MaximumSize.Width - MainWindow.MinimumSize.Width)) / (controller.gameworldSize.x + MainWindow.MinimumSize.Width)),
                (int)((input * (MainWindow.MaximumSize.Height - MainWindow.MinimumSize.Height)) / (controller.gameworldSize.y + MainWindow.MinimumSize.Height)));
        }
    }
}
