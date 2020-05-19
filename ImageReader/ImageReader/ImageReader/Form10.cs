using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class Form10 : Form
    {
        string fileName = string.Empty;
        private Form1.DelegateRefreshDGV dgv;

        public Form10(Form1.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            dgv = _dgv;
            TreeviewUpdate();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            double xa = 0, xb = 0, xc = 0;
            try
            {
                xa = double.Parse(textBox1.Text);
                xb = double.Parse(textBox2.Text);
                xc = double.Parse(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("输入有误，请重新输入...");
                return;
            }

            if(fileName==string.Empty)
            {
                MessageBox.Show("输入不能为空，请重新输入...");
                return;
            }

            try
            {
                FileStream fs = new FileStream("Configure.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(6);
                sw.WriteLine(xa);
                sw.WriteLine(xb);
                sw.WriteLine(xc);
                
                sw.WriteLine("hdfImage\\" + label4.Text);
                sw.WriteLine("hdfImage\\6S\\" + fileName);
               
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                DirectoryInfo directory = new DirectoryInfo("hdfImage\\6S");
                directory.Create();

                Process Configure = new Process();
                Configure.StartInfo.UseShellExecute = false;
                Configure.StartInfo.FileName = @"Algorithm\Algorithm.exe";
                Configure.StartInfo.CreateNoWindow = true;
                Configure.Start();
                Configure.WaitForExit();
                Configure.Close();

                MessageBox.Show("6S大气校正成功，请到主界面查看...");
                dgv(); //调用委托方法
            }
            catch
            {
                MessageBox.Show("6S大气校正失败...");
            }
        }

        private void TreeviewUpdate()
        {
            treeView6.Nodes.Clear();
            string[] folders = Directory.GetDirectories("hdfImage");
            foreach (string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                List<string> bandName = new List<string>();
                treeView6.Nodes.Add(folderName[folderName.Length - 1]);
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
                        treeView6.Nodes[treeView6.Nodes.Count - 1].Nodes.Add(temp);
                }
            }
        }

        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView6.SelectedNode = treeView6.GetNodeAt(e.X, e.Y);
            }
        }

        private void SelectImageDoubleClick(object sender, EventArgs e)
        {
            fileName = treeView6.SelectedNode.Text;
            label4.Text = treeView6.SelectedNode.Parent.Text + "\\" + treeView6.SelectedNode.Text;
        }
    }
}
