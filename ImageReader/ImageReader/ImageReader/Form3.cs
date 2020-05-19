using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class Form3 : Form
    {
        public Form3(Bitmap bitmap)
        {
            InitializeComponent();
            InitPictureBox();
            imageBox.Image = bitmap;
        }

        #region ShowPosition
        private void pictureBox_MouseOn(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int originalWidth = pictureBox.Image.Width;
                int originalHeight = pictureBox.Image.Height;

                int currentWidth = pictureBox.Width;
                int currentHeight = pictureBox.Height;

                double rate = (double)currentHeight / originalHeight;

                double black_left_width = (currentWidth == pictureBox.Width) ? 0 : (imageBox.Width - currentWidth) / 2;
                double black_top_height = (currentHeight == pictureBox.Height) ? 0 : (imageBox.Height - currentHeight) / 2;

                double original_x = (e.X - black_left_width) / rate;
                double original_y = (e.Y - black_top_height) / rate;

                toolStripTextBox1.Text = "(" + original_x + "," + original_y + ")";
            }
        }
        #endregion

        #region InitPictureBox
        private void InitPictureBox()
        {
            imageBox.MouseDown += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseDown);
            imageBox.MouseUp += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseUp);
            imageBox.MouseMove += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseMove);
            imageBox.MouseWheel += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseWheel);
            imageBox.MouseMove += new MouseEventHandler(pictureBox_MouseOn);
        }
        #endregion

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)imageBox.Image;
            string saveFile = ShowSaveFileDialog();
            if (saveFile != string.Empty)
            {
                bitmap.Save(saveFile);
                MessageBox.Show("图像保存成功...");
            }
            //bitmap.Dispose();
        }

        //选择保存路径
        private string ShowSaveFileDialog()
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "tif图片（*.tif）|*.tif";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 

                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                ////fs输出带文字或图片的文件，就看需求了 
            }
            return localFilePath;
        }
    }
}
