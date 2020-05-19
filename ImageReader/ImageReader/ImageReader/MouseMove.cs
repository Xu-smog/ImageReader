using System.Drawing;
using System.Windows.Forms;

namespace ImageReader
{
    public static class MouseMove
    {
        private static bool isMove = false;
        private static Point mouseDownPoint = new Point();

        public static void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;

                int x = e.Location.X;
                int y = e.Location.Y;
                int ow = pictureBox.Width;
                int oh = pictureBox.Height;
                //因缩放产生的位移矢量
                int VX, VY;

                if (e.Delta > 0)
                {
                    // 限制放大效果 600% 以内  
                    if (pictureBox.Width / (double)pictureBox.Image.Width < 6.0)
                    {
                        pictureBox.Size = new Size((int)(pictureBox.Width * 1.1), (int)(pictureBox.Height * 1.1));
                    }
                }
                if (e.Delta < 0)
                {
                    // 限制缩小效果 15% 以内  
                    if (pictureBox.Width / (double)pictureBox.Image.Width > 0.15)
                    {
                        pictureBox.Size = new Size((int)(pictureBox.Width * 0.9), (int)(pictureBox.Height * 0.9));
                    }
                }
                //求因缩放产生的位移，进行补偿，实现锚点缩放的效果
                VX = (int)((double)x * (ow - pictureBox.Width) / ow);
                VY = (int)((double)y * (oh - pictureBox.Height) / oh);
                pictureBox.Location = new Point(pictureBox.Location.X + VX, pictureBox.Location.Y + VY);
            }
        }
        public static void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                if (e.Button == MouseButtons.Left)
                {
                    mouseDownPoint.X = Cursor.Position.X;
                    mouseDownPoint.Y = Cursor.Position.Y;
                    isMove = true;
                    pictureBox.Focus();
                }
            }
        }
        public static void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }
        public static void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                if (isMove)
                {
                    int x, y;
                    int moveX, moveY;
                    moveX = Cursor.Position.X - mouseDownPoint.X;
                    moveY = Cursor.Position.Y - mouseDownPoint.Y;
                    x = pictureBox.Location.X + moveX;
                    y = pictureBox.Location.Y + moveY;
                    pictureBox.Location = new Point(x, y);
                    mouseDownPoint.X = Cursor.Position.X;
                    mouseDownPoint.Y = Cursor.Position.Y;
                }
            }
        }
    }
}

