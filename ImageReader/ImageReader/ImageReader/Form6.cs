using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class Form6 : Form
    {
        int imageHeight, imageWidth;
        string fileName,savePath= "hdfImage\\GeometricCorrection\\";
        private Form1.DelegateRefreshDGV dgv;

        public Form6(Form1.DelegateRefreshDGV _dgv,string name,Bitmap bitmap)
        {
            fileName = name;
            InitializeComponent();
            dgv = _dgv;

            comboBox1.SelectedIndex = 0;
            checkedListBox1.SetItemChecked(0, true);

            InitPictureBox();
            correctionPictureBox.Image = bitmap;
            correctionPictureBox.Height = bitmap.Height;
            correctionPictureBox.Width = bitmap.Width;
            imageHeight = bitmap.Height;
            imageWidth = bitmap.Width;
            FileInfo fileInfo = new FileInfo(savePath + "temp.tif");
            if (fileInfo.Exists)
                fileInfo.Delete();
            bitmap.Save(savePath+"temp.tif");
            correctionPictureBox.MouseMove += new MouseEventHandler(pictureBox_MouseOn);
        }

        #region InitPictureBox
        private void InitPictureBox()
        {
            correctionPictureBox.MouseDown += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseDown);
            correctionPictureBox.MouseUp += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseUp);
            correctionPictureBox.MouseMove += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseMove);
            correctionPictureBox.MouseWheel += new MouseEventHandler(ImageReader.MouseMove.pictureBox_MouseWheel);

        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            correctionPictureBox.MouseClick += new MouseEventHandler(pictureBox_Click);
        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            try
            {
                if (Cursor == Cursors.Cross && sender is PictureBox)
                {
                    Cursor = Cursors.Arrow;

                    PictureBox pictureBox = (PictureBox)sender;
                    int currentWidth = pictureBox.Width;
                    double rate = (double)currentWidth / imageWidth;

                    int original_x = (int)(e.X / rate);
                    int original_y = (int)(e.Y / rate);

                    dataGridView.Rows[dataGridView.RowCount - 1].Cells[0].Value = original_x.ToString();
                    dataGridView.Rows[dataGridView.RowCount - 1].Cells[1].Value = original_x.ToString();
                }
            }
            catch
            {
                MessageBox.Show("鼠标点击有误,请重新选取坐标...");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==4)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            int n1 = 4326, n2 = 1;
            try
            {
                if(textBox1.Text!=string.Empty)
                    n1 = int.Parse(textBox1.Text);
                n2 = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("请输入数字...");
            }

            try
            {
                FileStream fs = new FileStream("Configure.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                fs.SetLength(0);
                sw.WriteLine(4);
                sw.WriteLine(savePath + "temp.tif");
                sw.WriteLine(savePath + fileName);
                sw.WriteLine(dataGridView.RowCount - 1);
                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {
                    sw.WriteLine(dataGridView.Rows[i].Cells[2].Value);
                    sw.WriteLine(dataGridView.Rows[i].Cells[3].Value);
                    sw.WriteLine(dataGridView.Rows[i].Cells[1].Value);
                    sw.WriteLine(dataGridView.Rows[i].Cells[0].Value);
                }
                if (comboBox1.SelectedIndex == 4)
                {
                    sw.WriteLine("EPSG");
                    sw.WriteLine(n1.ToString());
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    sw.WriteLine("NAD83");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    sw.WriteLine("NAD27");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    sw.WriteLine("WGS72");
                }
                else
                {
                    sw.WriteLine("WGS84");
                }

                if (checkedListBox1.GetItemChecked(0))
                {
                    sw.WriteLine("tps");
                }
                else if (checkedListBox1.GetItemChecked(0))
                {
                    sw.WriteLine("polynomialOrder");
                    sw.WriteLine(n2.ToString());
                }
                else
                {
                    sw.WriteLine("resampleAlg");
                }

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                toolStripStatusLabel1.Text = "图像几何校正中...";

                Process Configure = new Process();
                Configure.StartInfo.UseShellExecute = false;
                Configure.StartInfo.FileName = @"Algorithm\Algorithm.exe";
                Configure.StartInfo.CreateNoWindow = true;
                Configure.Start();
                Configure.WaitForExit();
                Configure.Close();

                toolStripStatusLabel1.Text = "图像几何校正成功";

                Bitmap bitmap = new Bitmap("hdfImage\\GeometricCorrection\\" + fileName);
                correctionPictureBox.Image = bitmap;

                dgv(); //调用委托方法
            }
            catch
            {
                MessageBox.Show("几何校正失败...");
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(dataGridView.RowCount>1)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
                }
            }
        }

        private void Arrow_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)correctionPictureBox.Image;
            string saveFile = ShowSaveFileDialog();
            if(saveFile!=string.Empty)
            {
                bitmap.Save(saveFile);
                MessageBox.Show("图像保存成功...");
            }
            bitmap.Dispose();
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

        private void OpenButton_Click(object sender, EventArgs e)
        {
            string filePath = "";
            //string[] fileName;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "hdfImage";
            openFileDialog.Filter = "tif文件（*.tif）|*.tif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //文件读取
                filePath = openFileDialog.FileName;
                //fileName = openFileDialog.SafeFileName.Split('.');
                Bitmap bitmap = new Bitmap(filePath);
                Bitmap dstBitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
                correctionPictureBox.Image = dstBitmap;
                correctionPictureBox.Height = dstBitmap.Height;
                correctionPictureBox.Width = dstBitmap.Width;
                bitmap.Dispose();
            }
        }

        private void pictureBox_MouseOn(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int currentWidth = pictureBox.Width;
                double rate = (double)currentWidth / imageWidth;

                double original_x = e.X / rate;
                double original_y = e.Y / rate;

                toolStripStatusLabel1.Text = "行：" + (int)original_x + ", 列：" + (int)original_y;
            }
        }


        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) return;//取消选中就不用进行以下操作

            for (int i = 0; i < ((CheckedListBox)sender).Items.Count; i++)
            {
                ((CheckedListBox)sender).SetItemChecked(i, false);//将所有选项设为不选中
            }
            e.NewValue = CheckState.Checked;//刷新       
        }

    }
}
