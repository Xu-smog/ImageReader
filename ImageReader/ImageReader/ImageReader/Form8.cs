using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class Form8 : Form
    {

        string saveFolder = string.Empty;

        public Form8()
        {
            InitializeComponent();
            TreeviewUpdate();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                saveFolder = dialog.SelectedPath;
                textBox1.Text = saveFolder;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFolder == string.Empty)
                    return;
                foreach (TreeNode subTree in treeView2.Nodes)
                {
                    string filePath = subTree.Text;
                    foreach (TreeNode nodes in subTree.Nodes)
                    {
                        if (nodes.BackColor == Color.Green)
                        {
                            string fileName = nodes.Text;
                            FileInfo sourceFile = new FileInfo("hdfImage\\" + filePath + "\\" + fileName);
                            FileInfo targetFile = new FileInfo(saveFolder + "\\" + fileName);
                            //targetFile.Create();
                            sourceFile.CopyTo(saveFolder + "\\" + fileName);
                        }
                    }
                }
                MessageBox.Show("文件保存成功...");
            }
            catch
            {
                MessageBox.Show("文件保存失败！请确定文件未被占用或者要保存文件是否正确选中");
            }
        }

        private void TreeviewUpdate()
        {
            treeView2.Nodes.Clear();
            string[] folders = Directory.GetDirectories("hdfImage");
            foreach (string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                List<string> bandName = new List<string>();
                treeView2.Nodes.Add(folderName[folderName.Length - 1]);
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
                        treeView2.Nodes[treeView2.Nodes.Count - 1].Nodes.Add(temp);
                }
            }
        }

        private void SaveMultipage(Image[] bmp, string location, string type)
        {
            if (bmp != null)
            {
                try
                {
                    File.Delete(location);

                    var codecInfo = getCodecForstring(type);

                    if (bmp.Length == 1)
                    {
                        var iparams = new EncoderParameters(1);
                        var iparam = Encoder.Compression;
                        var iparamPara = new EncoderParameter(iparam, (long)(EncoderValue.CompressionNone));

                        iparams.Param[0] = iparamPara;
                        bmp[0].Save(location, codecInfo, iparams);
                    }
                    else if (bmp.Length > 1)
                    {
                        // Save the first page (frame).
                        var encoderParam1 = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
                        var encoderParam2 = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionNone);

                        var encoderParams = new EncoderParameters(2);
                        encoderParams.Param[0] = encoderParam1;
                        encoderParams.Param[1] = encoderParam2;

                        bmp[0].Save(location, codecInfo, encoderParams);

                        for (int i = 1; i < bmp.Length; i++)
                        {
                            if (bmp[i] == null)
                                break;

                            encoderParams.Param[0] = encoderParam1;
                            encoderParams.Param[1] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
                            bmp[0].SaveAdd(bmp[i], encoderParams);
                        }

                        encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.Flush);
                        bmp[0].SaveAdd(encoderParams);
                    }
                    MessageBox.Show("tiff文件生成成功...");
                }
                catch
                {
                    MessageBox.Show("tiff文件生成失败...");
                }
            }
        }

        private ImageCodecInfo getCodecForstring(string type)
        {
            var info = ImageCodecInfo.GetImageEncoders();

            return (info.Select(t => new { t, enumName = type }).Where(@t1 => @t1.t.FormatDescription.Equals(@t1.enumName)).Select(@t1 => @t1.t)).FirstOrDefault();
        }




        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView2.SelectedNode = treeView2.GetNodeAt(e.X, e.Y);
            }
        }

        private void SaveImageDoubleClick(object sender, EventArgs e)
        {
            if(treeView2.SelectedNode.BackColor == Color.Green)
            {
                treeView2.SelectedNode.BackColor = Color.White;
            }
            else
            {
                treeView2.SelectedNode.BackColor = Color.Green;
            }
        }

        private void SaveMultipageButton_Click(object sender, EventArgs e)
        {
            if (saveFolder == string.Empty)
                return;
            int cnt = 0;
            Image[] images = new Image[100];
            foreach (TreeNode subTree in treeView2.Nodes)
            {
                string filePath = subTree.Text;
                foreach (TreeNode nodes in subTree.Nodes)
                {
                    if (nodes.BackColor == Color.Green)
                    {
                        string fileName = nodes.Text;
                        images[cnt++] = Image.FromFile("hdfImage\\" + filePath + "\\" + fileName);
                    }
                }
            }

            Random random = new Random();
            SaveMultipage(images.ToArray(), saveFolder + "\\" + random.Next().ToString() + ".tiff", "TIFF");
        }
    }
}
