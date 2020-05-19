using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Timers;
using System.Collections;
using OpenCvSharp;
using System.Threading;

namespace ImageReader
{
    public partial class Form1 : Form
    {
        #region 变量
        int imageHeight, imageWidth;
        string currentFolder = "";
        string currentImage = "";
        string curImagePath = string.Empty;
        Bitmap disposeBitmap=null;
        ArrayList dataSetName = new ArrayList() ;
        #endregion

        #region 委托
        //声明传递FileSystemEventArgs对象的委托，用于文件Created，Deleted和Changed变动时更新UI界面。
        private delegate void setLogTextDelegate(FileSystemEventArgs e);
        public delegate void DelegateRefreshDGV();
        #endregion

        public Form1()
        {
            DirectoryInfo directory = new DirectoryInfo("hdfImage");
            if (directory.Exists)
                directory.Delete(true);
            InitializeComponent();
            InitPictureBox();
        }        

        #region ShowPosition
        private void pictureBox_MouseOn(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int currentWidth = pictureBox.Width;
                double rate = (double)currentWidth / imageWidth;

                double original_x = e.X  / rate;
                double original_y = e.Y  / rate;

                toolStripStatusLabel1.Text = "(" + (int)original_x + "," + (int)original_y + ")";
            }
        }
        #endregion

        #region InitPictureBox
        private void InitPictureBox()
        {
            pictureBox1.MouseDown += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseDown);
            pictureBox1.MouseUp += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseUp);
            pictureBox1.MouseMove += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseMove);
            pictureBox1.MouseWheel += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseWheel);
        }
        #endregion

        #region 打开文件
        private void OpenFile_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string[] fileName ;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "hdf文件（*.hdf）|*.hdf";
            FileStream fs = new FileStream("Configure.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //文件读取
                filePath = openFileDialog.FileName;
                fileName = openFileDialog.SafeFileName.Split('.');
                DirectoryInfo directory = new DirectoryInfo("hdfImage");
                directory.Create();
                directory.CreateSubdirectory(fileName[0]);
                dataSetName.Add(fileName[0]);
                //FileInfo txt = new FileInfo("hdfImage\\" + fileName[0] + "\\" + fileName[0] + ".txt");
                //txt.Create();
                sw.WriteLine(0);
                sw.WriteLine(filePath);
                sw.WriteLine("hdfImage\\" + fileName[0]);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                toolStripStatusLabel1.Text = "图像正在读取中...";

                ThreadStart threadStart = DoWork;
                Thread thread = new Thread(threadStart);
                thread.Start();

                Form11 form11 = new Form11();
                form11.Show();
                while(thread.IsAlive)
                {
                    Application.DoEvents();
                    //Thread.Sleep(5);
                }

                thread.Join();
                form11.Close();
                MessageBox.Show("图像读取成功...");
                toolStripStatusLabel1.Text = "图像读取成功";

                TreeviewUpdate();
            }
        }
        #endregion

        private void DoWork()
        {
            Process Configure = new Process();
            Configure.StartInfo.UseShellExecute = false;
            Configure.StartInfo.FileName = @"Algorithm\Algorithm.exe";
            Configure.StartInfo.CreateNoWindow = true;
            Configure.Start();
            Configure.WaitForExit();
            Configure.Close();
        }

        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ShowImageDoubleClick(object sender, EventArgs e)
        {
            try
            {
                currentFolder = treeView1.SelectedNode.Parent.Text;
                currentImage = treeView1.SelectedNode.Text;
                string filePath = "hdfImage\\" + treeView1.SelectedNode.Parent.Text + "\\" + treeView1.SelectedNode.Text;
                if (disposeBitmap != null)
                    disposeBitmap.Dispose();
                curImagePath = filePath;
                Bitmap bitmap = new Bitmap(filePath);
                Bitmap dstBitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
                disposeBitmap = dstBitmap;
                pictureBox1.Image = dstBitmap;
                pictureBox1.Height = dstBitmap.Height;
                pictureBox1.Width = dstBitmap.Width;
                imageHeight = dstBitmap.Height;
                imageWidth = dstBitmap.Width;
                pictureBox1.MouseMove += new MouseEventHandler(pictureBox_MouseOn);
                bitmap.Dispose();
            }
            catch
            {
                MessageBox.Show("请选中图片...");
            }
        }

        #region 图片点击显示灰度

        private void Cross_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            pictureBox1.MouseClick += new MouseEventHandler(pictureBox_Click);
        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            try
            {
                if (currentFolder != "" && Cursor == Cursors.Cross && sender is PictureBox)
                {
                    Cursor = Cursors.Arrow;

                    PictureBox pictureBox = (PictureBox)sender;
                    int currentWidth = pictureBox.Width;
                    double rate = (double)currentWidth / imageWidth;

                    double original_x = e.X / rate;
                    double original_y = e.Y / rate;

                    //int maxByte = 0;
                    byte[] value = new byte[100];
                    string[] imageName=new string[100];

                    DirectoryInfo directory = new DirectoryInfo("hdfImage\\" + currentFolder);

                    int cnt = 0;
                    string[] prefix = currentImage.Split('_');
                    foreach(FileInfo tif in directory.GetFiles("*.tif"))
                    {
                        if (tif.Name.Split('_')[0] != prefix[0])
                            continue;
                        Bitmap bitmap = new Bitmap(tif.FullName);
                        value[cnt] = bitmap.GetPixel((int)original_x, (int)original_y).R;
                        imageName[cnt++] = tif.Name;
                        bitmap.Dispose();
                    }
                    /*
                    FileSystemInfo[] tifs = directory.GetFileSystemInfos();
                    for (int i = 0; i < tifs.Length; i++)
                    {
                        Bitmap bitmap = new Bitmap(tifs[i].FullName);
                        value[cnt] = bitmap.GetPixel((int)original_x, (int)original_y).R;
                        imageName[cnt++] = tifs[i].Name;
                        bitmap.Dispose();
                    }*/

                    try
                    {
                        Form5 form5 = new Form5(imageName, value, cnt);
                        form5.Show();
                    }
                    catch
                    {
                        MessageBox.Show("出现未知错误,请联系软件制作者...");
                    }
                }
            }
            catch
            {
                MessageBox.Show("鼠标点击有误,请重新选取坐标...");
            }
        }
        #endregion

        private void SSModel_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void RunBandCalculate_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo("hdfImage\\BandCalculate");
            directory.Create();
            DelegateRefreshDGV dgv = new DelegateRefreshDGV(TreeviewUpdate);
            Form2 form2 = new Form2(dgv);
            form2.Show();
        }

        private void Arrow_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void RunCorrection_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentImage == string.Empty)
                {
                    MessageBox.Show("请在左侧选中图片并显示...");
                    return;
                }
                DirectoryInfo directory = new DirectoryInfo("hdfImage\\GeometricCorrection");
                directory.Create();
                DelegateRefreshDGV dgv = new DelegateRefreshDGV(TreeviewUpdate);
                Form6 form6 = new Form6(dgv,currentImage, (Bitmap)pictureBox1.Image);
                form6.Show();
            }
            catch
            {
                MessageBox.Show("图像几何校正错误...");
            }
        }

        private void MomentMatching_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Configure.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);            
            DirectoryInfo directory = new DirectoryInfo("hdfImage\\StripNoiseRemoval");
            directory.Create();
            sw.WriteLine(2);
            sw.WriteLine("hdfImage\\" + currentFolder + "\\" + currentImage);
            sw.WriteLine("hdfImage\\StripNoiseRemoval\\" + currentImage);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            toolStripStatusLabel1.Text = "矩匹配中...";

            Process Configure = new Process();
            Configure.StartInfo.UseShellExecute = false;
            Configure.StartInfo.FileName = @"Algorithm\Algorithm.exe";
            Configure.StartInfo.CreateNoWindow = true;
            Configure.Start();
            Configure.WaitForExit();
            Configure.Close();

            toolStripStatusLabel1.Text = "矩匹配成功...";

            Bitmap bitmap = new Bitmap("hdfImage\\StripNoiseRemoval\\" + currentImage);
            
            Form3 from3 = new Form3(bitmap);
            from3.Show();
        }

        private void RunDerivativeTransformation_Click(object sender, EventArgs e)
        {
            DelegateRefreshDGV dgv = new DelegateRefreshDGV(TreeviewUpdate);
            Form7 form7 = new Form7(dgv);
            form7.Show();
        }

        private void TreeviewUpdate()
        {
            treeView1.Nodes.Clear();
            string[] folders = Directory.GetDirectories("hdfImage");
            foreach (string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                List<string> bandName = new List<string>();
                treeView1.Nodes.Add(folderName[folderName.Length - 1]);
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
                        treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add(temp);
                }
            }
        }

        private void RunMakeRGB_Click(object sender, EventArgs e)
        {
            DelegateRefreshDGV dgv = new DelegateRefreshDGV(TreeviewUpdate);
            Form9 form9 = new Form9(dgv);
            form9.Show();
        }

        private void RunHeader_Click(object sender, EventArgs e)
        {
            string[] folders = Directory.GetDirectories("hdfImage");
            foreach (string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                string[] txtfiles = Directory.GetFiles(folder, "*.txt");
                foreach (string txt in txtfiles)
                {
                    Process.Start("notepad.exe", txt);
                }
            }
        }

        private void RunAtmCorr_Click(object sender, EventArgs e)
        {
            DelegateRefreshDGV dgv = new DelegateRefreshDGV(TreeviewUpdate);
            Form10 form10 = new Form10(dgv);
            form10.Show();
        }

        private void SaveFiles_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void RunUpdate_Click(object sender, EventArgs e)
        {
            TreeviewUpdate();
        }

        #region NDVI&NDWI
        private void NDVIBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("归一化差分植被指数图像生成中...");
            try
            {
                bool flag = false;
                string allDataSet = string.Empty, folder = string.Empty, preName = string.Empty;
                foreach (string node in dataSetName)
                {
                    allDataSet += node + " ";
                    if (node == treeView1.SelectedNode.Text.ToString())
                    {
                        folder = node;
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("请在左侧选中以下数据集中的一个：" + allDataSet);
                    return;
                }                    

                flag = false;
                foreach(string node in Directory.GetFiles("hdfImage\\" + folder, "*.tif"))
                {
                    string[] tifName = node.Split('\\');
                    string[] splitName = tifName[tifName.Length - 1].Split('_');
                    if(splitName[1]=="band13.tif")
                    {
                        if(flag==false)
                        {
                            preName = splitName[0];
                            flag = true;
                        }
                        else if(preName==splitName[0])
                        {
                            Mat band;
                            Mat band13 = new Mat();
                            Mat band17 = new Mat();
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band13.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band13, 0.0, 1.0, NormTypes.MinMax);
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band17.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band17, 0.0, 1.0, NormTypes.MinMax);

                            Mat bandSub = new Mat();
                            Mat bandAdd = new Mat();
                            Mat bandDiv = new Mat();
                            Cv2.Subtract(band17, band13, bandSub);
                            Cv2.Add(band17, band13, bandAdd);
                            Cv2.Divide(bandSub, bandAdd, bandDiv);
                            //Cv2.CvtColor(bandDiv, band, ColorConversionCodes.HSV2RGB);
                            Cv2.Normalize(bandDiv, band, 0, 255, NormTypes.MinMax);

                            band.SaveImage("hdfImage\\" + folder + "\\" + preName + "_NDVI" + ".tif");
                            flag = false;
                        }                        
                    }
                    if(splitName[1]=="band17.tif")
                    {
                        if (flag == false)
                        {
                            preName = splitName[0];
                            flag = true;
                        }
                        else if (preName == splitName[0])
                        {
                            Mat band;
                            Mat band13 = new Mat();
                            Mat band17 = new Mat();
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band13.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band13, 0.0, 1.0, NormTypes.MinMax);
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band17.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band17, 0.0, 1.0, NormTypes.MinMax);
                            
                            Mat bandSub = new Mat();
                            Mat bandAdd = new Mat();
                            Mat bandDiv = new Mat();
                            Cv2.Subtract(band17, band13, bandSub);
                            Cv2.Add(band17, band13, bandAdd);
                            Cv2.Divide(bandSub, bandAdd, bandDiv);
                            //Cv2.CvtColor(bandDiv, band, ColorConversionCodes.HSV2RGB);
                            Cv2.Normalize(bandDiv, band, 0, 255, NormTypes.MinMax);

                            band.SaveImage("hdfImage\\" + folder + "\\" + preName + "_NDVI" + ".tif");
                            flag = false;
                        }
                    }
                }
                TreeviewUpdate();
                MessageBox.Show("NDVI图像生成成功...");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void NDWIBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("归一化差分水体指数图像生成中...");
            try
            {
                bool flag = false;
                string allDataSet = string.Empty, folder = string.Empty, preName = string.Empty;
                foreach (string node in dataSetName)
                {
                    allDataSet += node + " ";
                    if (node == treeView1.SelectedNode.Text.ToString())
                    {
                        folder = node;
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("请在左侧选中以下数据集中的一个：" + allDataSet);
                    return;
                }

                flag = false;
                foreach (string node in Directory.GetFiles("hdfImage\\" + folder, "*.tif"))
                {
                    string[] tifName = node.Split('\\');
                    string[] splitName = tifName[tifName.Length - 1].Split('_');
                    if (splitName[1] == "band5.tif")
                    {
                        if (flag == false)
                        {
                            preName = splitName[0];
                            flag = true;
                        }
                        else if (preName == splitName[0])
                        {
                            Mat band;
                            Mat band5 = new Mat();
                            Mat band17 = new Mat();
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band5.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band5, 0.0, 1.0, NormTypes.MinMax);
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band17.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band17, 0.0, 1.0, NormTypes.MinMax);

                            Mat bandSub = new Mat();
                            Mat bandAdd = new Mat();
                            Mat bandDiv = new Mat();
                            Cv2.Subtract(band5, band17, bandSub);
                            Cv2.Add(band17, band5, bandAdd);
                            Cv2.Divide(bandSub, bandAdd, bandDiv);
                            //Cv2.CvtColor(bandDiv, band, ColorConversionCodes.HSV2RGB);
                            Cv2.Normalize(bandDiv, band, 0, 255, NormTypes.MinMax);

                            band.SaveImage("hdfImage\\" + folder + "\\" + preName + "_NDWI" + ".tif");
                            flag = false;
                        }
                    }
                    if (splitName[1] == "band17.tif")
                    {
                        if (flag == false)
                        {
                            preName = splitName[0];
                            flag = true;
                        }
                        else if (preName == splitName[0])
                        {
                            Mat band;
                            Mat band5 = new Mat();
                            Mat band17 = new Mat();
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band5.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band5, 0.0, 1.0, NormTypes.MinMax);
                            band = new Mat("hdfImage\\" + folder + "\\" + preName + "_band17.tif", ImreadModes.Color);
                            Cv2.Normalize(band, band17, 0.0, 1.0, NormTypes.MinMax);

                            Mat bandSub = new Mat();
                            Mat bandAdd = new Mat();
                            Mat bandDiv = new Mat();
                            Cv2.Subtract(band5, band17, bandSub);
                            Cv2.Add(band17, band5, bandAdd);
                            Cv2.Divide(bandSub, bandAdd, bandDiv);
                            //Cv2.CvtColor(bandDiv, band, ColorConversionCodes.HSV2RGB);
                            Cv2.Normalize(bandDiv, band, 0, 255, NormTypes.MinMax);

                            band.SaveImage("hdfImage\\" + folder + "\\" + preName + "_NDWI" + ".tif");
                            flag = false;
                        }
                    }
                }
                TreeviewUpdate();
                MessageBox.Show("NDWI图像生成成功...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void RunTianchong_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentImage == string.Empty)
                {
                    MessageBox.Show("请读取影像...");
                    return;
                }
                string filePath = "hdfImage\\" + treeView1.SelectedNode.Parent.Text + "\\" + treeView1.SelectedNode.Text;
                FileStream fs = new FileStream("Configure.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                DirectoryInfo directory = new DirectoryInfo("hdfImage\\DarkElementFilling");
                directory.Create();
                sw.WriteLine(7);
                sw.WriteLine(filePath);
                sw.WriteLine("hdfImage\\DarkElementFilling\\" + currentImage);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                toolStripStatusLabel1.Text = "暗元填充中...";

                Process Configure = new Process();
                Configure.StartInfo.UseShellExecute = false;
                Configure.StartInfo.FileName = @"Algorithm\Algorithm.exe";
                Configure.StartInfo.CreateNoWindow = true;
                Configure.Start();
                Configure.WaitForExit();
                Configure.Close();

                toolStripStatusLabel1.Text = "暗元填充成功...";
                MessageBox.Show("暗元填充成功...");
                Bitmap bitmap = new Bitmap("hdfImage\\DarkElementFilling\\" + currentImage);
                Bitmap dstBitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
                disposeBitmap = dstBitmap;
                pictureBox1.Image = dstBitmap;
                pictureBox1.Height = dstBitmap.Height;
                pictureBox1.Width = dstBitmap.Width;
                imageHeight = dstBitmap.Height;
                imageWidth = dstBitmap.Width;
                pictureBox1.MouseMove += new MouseEventHandler(pictureBox_MouseOn);
                bitmap.Dispose();

                TreeviewUpdate();
            }
            catch
            {
                MessageBox.Show("暗元填充失败...");
            }
        }

        #region 图像二值化
        private void binBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (curImagePath == string.Empty)
                {
                    MessageBox.Show("请选中图像后使用此功能...");
                    return;
                }
                Bitmap bitmap = new Bitmap(curImagePath);
                Bitmap bmp = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
                bitmap.Dispose();
                
                int average = 0;
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        Color color = bmp.GetPixel(i, j);
                        average += color.B;
                    }
                }
                average = (int)average / (bmp.Width * bmp.Height);
                
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        //获取该点的像素的RGB的颜色
                        Color color = bmp.GetPixel(i, j);
                        int value = 255 - color.B;
                        Color newColor = value > average  ? Color.FromArgb(1, 1, 1) : Color.FromArgb(255, 255, 255);
                        bmp.SetPixel(i, j, newColor);
                    }
                }

                Form3 from3 = new Form3(bmp);
                from3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 灰度转彩色
        private byte[,] rainTable = new byte[128, 3] {
            {0,   0,   0},
            {0,   0,   0},
            {15,   0,  15},
            {31,   0,  31},
            {47,   0,  47},
            {63,   0,  63},
            {79,   0,  79},
            {95,   0,  95},
            {111,   0, 111},
            {127,   0, 127},
            {143,   0, 143},
            {159,   0, 159},
            {175,   0, 175},
            {191,   0, 191},
            {207,   0, 207},
            {223,   0, 223},
            {239,   0, 239},
            {255,   0, 255},
            {239,   0, 250},
            {223,   0, 245},
            {207,   0, 240},
            {191,   0, 236},
            {175,   0, 231},
            {159,   0, 226},
            {143,   0, 222},
            {127,   0, 217},
            {111,   0, 212},
            {95,   0, 208},
            {79,   0, 203},
            {63,   0, 198},
            {47,   0, 194},
            {31,   0, 189},
            {15,   0, 184},
            {0,   0, 180},
            {0,  15, 184},
            {0,  31, 189},
            {0,  47, 194},
            {0,  63, 198},
            {0,  79, 203},
            {0,  95, 208},
            {0, 111, 212},
            {0, 127, 217},
            {0, 143, 222},
            {0, 159, 226},
            {0, 175, 231},
            {0, 191, 236},
            {0, 207, 240},
            {0, 223, 245},
            {0, 239, 250},
            {0, 255, 255},
            {0, 245, 239},
            {0, 236, 223},
            {0, 227, 207},
            {0, 218, 191},
            {0, 209, 175},
            {0, 200, 159},
            {0, 191, 143},
            {0, 182, 127},
            {0, 173, 111},
            {0, 164,  95},
            {0, 155,  79},
            {0, 146,  63},
            {0, 137,  47},
            {0, 128,  31},
            {0, 119,  15},
            {0, 110,   0},
            {15, 118,   0},
            {30, 127,   0},
            {45, 135,   0},
            {60, 144,   0},
            {75, 152,   0},
            {90, 161,   0},
            {105, 169,  0},
            {120, 178,  0},
            {135, 186,  0},
            {150, 195,  0},
            {165, 203,  0},
            {180, 212,  0},
            {195, 220,  0},
            {210, 229,  0},
            {225, 237,  0},
            {240, 246,  0},
            {255, 255,  0},
            {251, 240,  0},
            {248, 225,  0},
            {245, 210,  0},
            {242, 195,  0},
            {238, 180,  0},
            {235, 165,  0},
            {232, 150,  0},
            {229, 135,  0},
            {225, 120,  0},
            {222, 105,  0},
            {219,  90,  0},
            {216,  75,  0},
            {212,  60,  0},
            {209,  45,  0},
            {206,  30,  0},
            {203,  15,  0},
            {200,   0,  0},
            {202,  11,  11},
            {205,  23,  23},
            {207,  34,  34},
            {210,  46,  46},
            {212,  57,  57},
            {215,  69,  69},
            {217,  81,  81},
            {220,  92,  92},
            {222, 104, 104},
            {225, 115, 115},
            {227, 127, 127},
            {230, 139, 139},
            {232, 150, 150},
            {235, 162, 162},
            {237, 173, 173},
            {240, 185, 185},
            {242, 197, 197},
            {245, 208, 208},
            {247, 220, 220},
            {250, 231, 231},
            {252, 243, 243},
            {252, 243, 243},
            {252, 243, 243},
            {252, 243, 243},
            {252, 243, 243},
            {252, 243, 243},
            {252, 243, 243},
            {252, 243, 243}
        };

        private void g2cBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (curImagePath == string.Empty)
                {
                    MessageBox.Show("请选中图像后使用此功能...");
                    return;
                }
                Bitmap bitmap = new Bitmap(curImagePath);
                Bitmap a = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
                bitmap.Dispose();

                Rectangle rect = new Rectangle(0, 0, a.Width, a.Height);
                System.Drawing.Imaging.BitmapData bmpData = a.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                int stride = bmpData.Stride;
                unsafe
                {
                    byte* pIn = (byte*)bmpData.Scan0.ToPointer();
                    int temp;
                    byte R, G, B;

                    for (int y = 0; y < a.Height; y++)
                    {
                        for (int x = 0; x < a.Width; x++)
                        {
                            temp = pIn[0] / 2;

                            R = rainTable[temp, 0];
                            G = rainTable[temp, 1];
                            B = rainTable[temp, 2];

                            pIn[0] = B;
                            pIn[1] = G;
                            pIn[2] = R;

                            pIn += 3;
                        }
                        pIn += stride - a.Width * 3;
                    }
                }
                a.UnlockBits(bmpData);
                Form3 from3 = new Form3(a);
                from3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

    }
}
