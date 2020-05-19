using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class Form7 : Form
    {
        #region 变量
        private double[] waveLength = new double[] { 411.3, 443.6, 491.8, 511.5, 532.0, 563.6, 576.1, 593.2, 625.3, 654.3, 672.9, 684.1, 692.7, 710.7, 760.4, 786.1, 878.6, 1026.7 };
        string currentFolder = string.Empty;
        private Form1.DelegateRefreshDGV dgv;
        #endregion

        public Form7(Form1.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            dgv = _dgv;
            TreeviewUpdate();
            InitComboBox();
        }

        private void InitComboBox()
        {
            Deri.SelectedIndex = 0;
            Step.SelectedIndex = 0;
        }

        private void TreeviewUpdate()
        {
            treeView4.Nodes.Clear();
            string[] folders = Directory.GetDirectories("hdfImage");
            foreach (string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                List<string> bandName = new List<string>();
                treeView4.Nodes.Add(folderName[folderName.Length - 1]);
                string[] tiffiles = Directory.GetFiles(folder, "*.tif");
                foreach (string tif in tiffiles)
                {
                    string[] tifName = tif.Split('\\');
                    bandName.Add(tifName[tifName.Length - 1]);
                }
                bandName.Sort(new FileNameCompare());
                foreach (string temp in bandName)
                {
                    if(temp!="temp.tif")
                        treeView4.Nodes[treeView4.Nodes.Count - 1].Nodes.Add(temp);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveLenData.RowCount > 0)
                {
                    waveLenData.Rows.Remove(waveLenData.SelectedRows[0]);
                }
            }
            catch
            {
                MessageBox.Show("请选中要删除的行...");
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            while (waveLenData.RowCount > 0)
            {
                waveLenData.Rows.RemoveAt(0);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if(waveLenData.RowCount-Deri.SelectedIndex-1<1)
            {
                MessageBox.Show("波段过少，无法计算...");
                return;
            }

            FileStream fs = new FileStream("Configure.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("3");
            sw.WriteLine("hdfImage\\Derivative");
            sw.WriteLine(waveLenData.RowCount);
            sw.WriteLine(Deri.SelectedIndex);            

            for (int i = 0; i < waveLenData.RowCount; i++)
            {
                sw.WriteLine("hdfImage\\" + currentFolder + "\\" + waveLenData.Rows[i].Cells[0].Value);
                sw.WriteLine(waveLenData.Rows[i].Cells[1].Value);
            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            DirectoryInfo deri1 = new DirectoryInfo("hdfImage\\Derivative1");
            deri1.Create();
            DirectoryInfo deri2 = new DirectoryInfo("hdfImage\\Derivative2");
            deri2.Create();
            DirectoryInfo deri3 = new DirectoryInfo("hdfImage\\Derivative3");
            deri3.Create();

            toolStripStatusLabel1.Text = "导数变换中...";

            Process Configure = new Process();
            Configure.StartInfo.UseShellExecute = false;
            Configure.StartInfo.FileName = @"Algorithm\Algorithm.exe";
            Configure.StartInfo.CreateNoWindow = true;
            Configure.Start();
            Configure.WaitForExit();
            Configure.Close();

            MessageBox.Show("导数变换成功,请在主界面中查看...");
            toolStripStatusLabel1.Text = "导数变换成功...";
            dgv(); //调用委托方法
        }

        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView4.SelectedNode = treeView4.GetNodeAt(e.X, e.Y);
            }
        }

        private void ShowImageDoubleClick(object sender, EventArgs e)
        {
            try
            {
                int i = treeView4.SelectedNode.Index;

                if(currentFolder != treeView4.SelectedNode.Parent.Text&& currentFolder != string.Empty)
                {
                    MessageBox.Show("请在同一个数据集下选择波段...");
                    return;
                }

                currentFolder = treeView4.SelectedNode.Parent.Text;

                DirectoryInfo directory = new DirectoryInfo("hdfImage\\" + currentFolder);

                string[] prefix = treeView4.SelectedNode.Text.Split('_');
                List<string> bandName = new List<string>();
                foreach (FileInfo tif in directory.GetFiles("*.tif"))
                {
                    if (tif.Name.Split('_')[0] != prefix[0])
                        continue;
                    bandName.Add(tif.Name);                    
                }
                bandName.Sort(new FileNameCompare());
                bool flag = false;
                int cnt = -1;
                foreach (string temp in bandName)
                {
                    if (temp == treeView4.SelectedNode.Text)
                    {
                        flag = true;
                        cnt = 0;
                    }                        
                    if(flag&&cnt==0)
                    {
                        waveLenData.Rows.Add();
                        waveLenData.Rows[waveLenData.RowCount - 1].Cells[0].Value = temp;
                        waveLenData.Rows[waveLenData.RowCount - 1].Cells[1].Value = waveLength[i];
                        i += Step.SelectedIndex + 1;
                        cnt= Step.SelectedIndex + 1;
                    }
                    cnt--;
                }
            }
            catch
            {
                MessageBox.Show("请选中波段...");
            }
        }
    }
}
