using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class Form9 : Form
    {
        #region 变量
        int imageWidth = 1;
        bool r = false, g = false, b = false;
        string saveFolder = string.Empty;
        string savePath = string.Empty;
        private Form1.DelegateRefreshDGV dgv;
        #endregion

        public Form9(Form1.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            dgv = _dgv;
            TreeviewUpdate();
            InitPictureBox();
        }

        #region 更新树形图
        private void TreeviewUpdate()
        {
            treeView5.Nodes.Clear();
            string[] folders = Directory.GetDirectories("hdfImage");
            foreach (string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                List<string> bandName = new List<string>();
                treeView5.Nodes.Add(folderName[folderName.Length - 1]);
                string[] tiffiles = Directory.GetFiles(folder, "*.tif");
                foreach (string tif in tiffiles)
                {
                    string[] tifName = tif.Split('\\');
                    bandName.Add(tifName[tifName.Length - 1]);
                }
                bandName.Sort(new FileNameCompare());
                foreach (string temp in bandName)
                {
                    if (temp != "temp.tif")
                        treeView5.Nodes[treeView5.Nodes.Count - 1].Nodes.Add(temp);
                }
            }
        }
        #endregion

        #region 保存
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)pictureBox5.Image;
            string saveFile = ShowSaveFileDialog();
            if (saveFile != string.Empty)
            {
                bitmap.Save(saveFile);
                MessageBox.Show("图像保存成功...");
            }
        }

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
            }
            return localFilePath;
        }
        #endregion

        private void Run_Click(object sender, EventArgs e)
        {
            try
            {
                int redId = 0, greenId = 0, blueId = 0;

                string redBand = string.Empty;
                string greenBand = string.Empty;
                string blueBand = string.Empty;

                foreach (TreeNode subTree in treeView5.Nodes)
                {
                    string filePath = subTree.Text;
                    foreach (TreeNode nodes in subTree.Nodes)
                    {
                        if (nodes.BackColor == Color.Red)
                        {
                            string fileName = nodes.Text;
                            redId = nodes.Index + 1;
                            redBand = "hdfImage\\" + filePath + "\\" + fileName;
                        }
                        if (nodes.BackColor == Color.Green)
                        {
                            string fileName = nodes.Text;
                            greenId = nodes.Index + 1;
                            greenBand = "hdfImage\\" + filePath + "\\" + fileName;
                        }
                        if (nodes.BackColor == Color.Blue)
                        {
                            string fileName = nodes.Text;
                            blueId = nodes.Index + 1;
                            blueBand = "hdfImage\\" + filePath + "\\" + fileName;
                        }
                    }
                }
                savePath = "hdfImage\\RGBImage\\band_" + redId.ToString() + "_" + greenId.ToString() + "_" + blueId.ToString() + ".tif";
                FileStream fs = new FileStream("Configure.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(5);
                sw.WriteLine(redBand);
                sw.WriteLine(greenBand);
                sw.WriteLine(blueBand);
                sw.WriteLine(savePath);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                DirectoryInfo directory = new DirectoryInfo("hdfImage\\RGBImage");
                directory.Create();

                toolStripStatusLabel1.Text = "图像生成中...";

                Process Configure = new Process();
                Configure.StartInfo.UseShellExecute = false;
                Configure.StartInfo.FileName = @"Algorithm\Algorithm.exe";
                Configure.StartInfo.CreateNoWindow = true;
                Configure.Start();
                Configure.WaitForExit();
                Configure.Close();

                Bitmap bitmap = new Bitmap(savePath);
                Bitmap dstBitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);              
                pictureBox5.Image = dstBitmap;
                pictureBox5.Height = dstBitmap.Height;
                pictureBox5.Width = dstBitmap.Width;
                imageWidth = dstBitmap.Width;
                pictureBox5.MouseMove += new MouseEventHandler(pictureBox_MouseOn);
                bitmap.Dispose();
                MessageBox.Show("图像生成成功...");
                toolStripStatusLabel1.Text = "图像生成成功...";

                dgv(); //调用委托方法
            }
            catch
            {
                MessageBox.Show("图像生成失败...");
            }
        }

        #region InitPictureBox
        private void InitPictureBox()
        {
            pictureBox5.MouseDown += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseDown);
            pictureBox5.MouseUp += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseUp);
            pictureBox5.MouseMove += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseMove);
            pictureBox5.MouseWheel += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseWheel);
        }
        #endregion

        #region ShowPosition
        private void pictureBox_MouseOn(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int currentWidth = pictureBox.Width;
                double rate = (double)currentWidth / imageWidth;

                double original_x = e.X / rate;
                double original_y = e.Y / rate;

                toolStripStatusLabel1.Text = "(" + (int)original_x + "," + (int)original_y + ")";
            }
        }
        #endregion

        #region 树形图的点击
        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView5.SelectedNode = treeView5.GetNodeAt(e.X, e.Y);
            }
        }

        private void SelectImageDoubleClick(object sender, EventArgs e)
        {
            if (treeView5.SelectedNode.BackColor != Color.Red && treeView5.SelectedNode.BackColor != Color.Green && treeView5.SelectedNode.BackColor != Color.Blue)
            {
                if(r&&g&&b)
                {
                    MessageBox.Show("请取消一个选中的波段...");
                    return;
                }
                if(!r)
                {
                    r = true;
                    treeView5.SelectedNode.BackColor = Color.Red;
                }
                else if(!g)
                {
                    g = true;
                    treeView5.SelectedNode.BackColor = Color.Green;
                }
                else
                {
                    b = true;
                    treeView5.SelectedNode.BackColor = Color.Blue;
                }                
            }
            else
            {
                if(treeView5.SelectedNode.BackColor == Color.Red)
                {
                    r = false;
                    treeView5.SelectedNode.BackColor = Color.White;
                }
                else if(treeView5.SelectedNode.BackColor == Color.Green)
                {
                    g = false;
                    treeView5.SelectedNode.BackColor = Color.White;
                }
                else
                {
                    b = false;
                    treeView5.SelectedNode.BackColor = Color.White;
                }                
            }
        }
        #endregion
    }
}
