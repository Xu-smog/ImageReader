/*using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using OpenCvSharp;
using System.Drawing;

namespace ImageReader
{
    public partial class Form2 : Form
    {
        #region 变量
        int num = 0;
        private int tail = 0;
        private string[] formula = new string[1000];        
        private Stack bandStack = new Stack();
        private Stack operatorStack = new Stack();

        public Mat result = null;
        private Form1.DelegateRefreshDGV dgv;
        #endregion

        public Form2(Form1.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            dgv = _dgv;
            TreeviewUpdate();
        }

        private void TreeviewUpdate()
        {
            treeView3.Nodes.Clear();
            string[] folders= Directory.GetDirectories("hdfImage");
            foreach(string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                List<string> bandName = new List<string>();
                treeView3.Nodes.Add(folderName[folderName.Length-1]);
                string[] tiffiles = Directory.GetFiles(folder, "*.tif");
                foreach (string tif in tiffiles)
                {
                    string[] tifName = tif.Split('\\');
                    bandName.Add(tifName[tifName.Length - 1]);
                }
                bandName.Sort(new FileNameCompare());
                foreach (string temp in bandName)
                {
                    treeView3.Nodes[treeView3.Nodes.Count - 1].Nodes.Add(temp);
                }
            }           
        }

        #region 加减乘除
        private void AddButton(object sender,EventArgs e)
        {
            try
            {
                formula[tail++] = "+ ";
                formulaBox.Text += "+ ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void SubButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "- ";
                formulaBox.Text += "- ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void MulButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "* ";
                formulaBox.Text += "* ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void DivButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "/ ";
                formulaBox.Text += "/ ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void LeftBracketButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "( ";
                formulaBox.Text += "( ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void RightBracketButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = ") ";
                formulaBox.Text += ") ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }
        #endregion

        private void LeftArrowButton(object sender, EventArgs e)
        {
            if (tail == 0)
                return;
            tail--;
            string text = "";
            string[] temp = formulaBox.Text.Split(' ');
            for (int i=0;i<tail;i++)
            {
                text += temp[i] + " ";
            }
            formulaBox.Text = text;
        }

        private void RightArrowButton(object sender, EventArgs e)
        {
            formula[tail++] = textBox1.Text + "~" + treeView3.SelectedNode.Parent.Text + "~" + treeView3.SelectedNode.Text + " ";
            formulaBox.Text += textBox1.Text + "~" + treeView3.SelectedNode.Parent.Text + "~" + treeView3.SelectedNode.Text + " ";
        }

        private void ClearButton(object sender, EventArgs e)
        {
            tail = 0;
            formulaBox.Text = "";
        }

        private void EqualButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "= ";
                formulaBox.Text += "= ";
                //operatorStack.Push("=");
                string[] temp = formulaBox.Text.Split(' ');
                foreach (string str in temp)
                {
                    if (str == "")
                        break;
                    if (str.Length == 1)
                    {
                        while (operatorStack.Count > 0 && OperatorCompare(operatorStack.Peek().ToString(), str))
                        {
                            CalculateBand();
                            if (str == ")" && operatorStack.Peek().ToString() == "(")
                            {
                                operatorStack.Pop();
                                break;
                            }
                            operatorStack.Push(str);                                
                        }
                        if (str != "=" && str != ")")
                            operatorStack.Push(str);                        
                    }
                    else
                    {
                        double coefficient = 1.0;
                        string[] tmp = str.Split('~');
                        coefficient = double.Parse(tmp[0]);
                        string path = tmp[1] + "\\" + tmp[2];

                        Mat readImg = new Mat("hdfImage\\" + path, ImreadModes.Color);
                        Mat band = new Mat();
                        Cv2.Normalize(readImg, band, 0.0, 1.0, NormTypes.MinMax);
                        band = band * coefficient;
                        bandStack.Push(band);
                        readImg.Dispose();
                    }
                }
                while (operatorStack.Peek().ToString() != "=")
                {
                    CalculateBand();
                }
                Mat img = new Mat();
                result = (Mat)bandStack.Pop();
                Cv2.Normalize(result, img, 0, 255, NormTypes.MinMax);

                img.SaveImage("hdfImage\\BandCalculate\\result" + num + ".tif");
                Bitmap bitmap = new Bitmap("hdfImage\\BandCalculate\\result" + num + ".tif");
                num++;
                Form3 from3= new Form3(bitmap);
                from3.Show();
                dgv(); //调用委托方法
                //Cv2.ImShow("波段计算结果", result);
            }
            catch
            {
                MessageBox.Show("公式有误，请重新输入");
            }
        }

        #region 波段计算
        private void CalculateBand()
        {
            string str = operatorStack.Pop().ToString();
            if (bandStack.Count < 2)
                return;
            Mat band2 = (Mat)bandStack.Pop();
            Mat band1 = (Mat)bandStack.Pop();
            Mat band3 = new Mat();
            
            if (str == "+")
            {
                Cv2.Add(band1, band2, band3);
                bandStack.Push(band3);
            }
            else if (str == "-")
            {
                Cv2.Subtract(band1, band2, band3);
                bandStack.Push(band3);
            }
            else if (str == "*")
            {
                Cv2.Multiply(band1, band2, band3);
                bandStack.Push(band3);
            }
            else if (str == "/")
            {
                 Cv2.Divide(band1, band2, band3);
                 bandStack.Push(band3);
            }
            else if(str=="="||str=="(")
            {
                return;
            }
            else
            {
                MessageBox.Show("公式有误，请重新输入");
            }
        }

        private bool OperatorCompare(string str1, string str2)
        {
            Dictionary<string, int> priority = new Dictionary<string, int>();
            priority.Add("+", 1);
            priority.Add("-", 1);
            priority.Add("*", 2);
            priority.Add("/", 2);
            priority.Add(")", 0);
            priority.Add("(", 1);
            priority.Add("=", 0);

            if (priority[str1] <= priority[str2])
                return false;
            else
                return true;
        }
        #endregion

        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView3.SelectedNode = treeView3.GetNodeAt(e.X, e.Y);
            }
        }

    }
}*/
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using OpenCvSharp;
using System.Drawing;

namespace ImageReader
{
    public partial class Form2 : Form
    {
        #region 变量
        int num = 0;
        private int tail = 0;
        private string[] formula = new string[1000];
        private Stack bandStack = new Stack();
        private Stack operatorStack = new Stack();

        public Mat result = null;
        private Form1.DelegateRefreshDGV dgv;
        #endregion

        public Form2(Form1.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            dgv = _dgv;
            TreeviewUpdate();
        }

        private void TreeviewUpdate()
        {
            treeView3.Nodes.Clear();
            string[] folders = Directory.GetDirectories("hdfImage");
            foreach (string folder in folders)
            {
                string[] folderName = folder.Split('\\');
                List<string> bandName = new List<string>();
                treeView3.Nodes.Add(folderName[folderName.Length - 1]);
                string[] tiffiles = Directory.GetFiles(folder, "*.tif");
                foreach (string tif in tiffiles)
                {
                    string[] tifName = tif.Split('\\');
                    bandName.Add(tifName[tifName.Length - 1]);
                }
                bandName.Sort(new FileNameCompare());
                foreach (string temp in bandName)
                {
                    treeView3.Nodes[treeView3.Nodes.Count - 1].Nodes.Add(temp);
                }
            }
        }

        #region 加减乘除
        private void AddButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "+ ";
                formulaBox.Text += "+ ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void SubButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "- ";
                formulaBox.Text += "- ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void MulButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "* ";
                formulaBox.Text += "* ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void DivButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "/ ";
                formulaBox.Text += "/ ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void LeftBracketButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "( ";
                formulaBox.Text += "( ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }

        private void RightBracketButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = ") ";
                formulaBox.Text += ") ";
            }
            catch
            {
                MessageBox.Show("输入算式过多，请分步输入");
            }
        }
        #endregion

        private void LeftArrowButton(object sender, EventArgs e)
        {
            if (tail == 0)
                return;
            tail--;
            string text = "";
            string[] temp = formulaBox.Text.Split(' ');
            for (int i = 0; i < tail; i++)
            {
                text += temp[i] + " ";
            }
            formulaBox.Text = text;
        }

        private void RightArrowButton(object sender, EventArgs e)
        {
            formula[tail++] = textBox1.Text + "~" + treeView3.SelectedNode.Parent.Text + "~" + treeView3.SelectedNode.Text + " ";
            formulaBox.Text += textBox1.Text + "~" + treeView3.SelectedNode.Parent.Text + "~" + treeView3.SelectedNode.Text + " ";
        }

        private void ClearButton(object sender, EventArgs e)
        {
            tail = 0;
            formulaBox.Text = "";
        }

        private void EqualButton(object sender, EventArgs e)
        {
            try
            {
                formula[tail++] = "= ";
                formulaBox.Text += "= ";
                //operatorStack.Push("=");
                string[] temp = formulaBox.Text.Split(' ');
                foreach (string str in temp)
                {
                    if (str == "")
                        break;
                    if (str.Length == 1)
                    {
                        while (operatorStack.Count > 0 && OperatorCompare(operatorStack.Peek().ToString(), str))
                        {
                            CalculateBand();
                            if (str == ")" && operatorStack.Peek().ToString() == "(")
                            {
                                operatorStack.Pop();
                                break;
                            }
                            operatorStack.Push(str);
                        }
                        if (str != "=" && str != ")")
                            operatorStack.Push(str);
                    }
                    else
                    {
                        double coefficient = 1.0;
                        string[] tmp = str.Split('~');
                        coefficient = double.Parse(tmp[0]);
                        string path = tmp[1] + "\\" + tmp[2];
                        Mat band = new Mat("hdfImage\\" + path, ImreadModes.Color);
                        band = band * coefficient;
                        bandStack.Push(band);
                    }
                }
                while (operatorStack.Peek().ToString() != "=")
                {
                    CalculateBand();
                }
                result = (Mat)bandStack.Pop();
                result.SaveImage("hdfImage\\BandCalculate\\result" + num + ".tif");
                Bitmap bitmap = new Bitmap("hdfImage\\BandCalculate\\result" + num + ".tif");
                num++;
                Form3 from3 = new Form3(bitmap);
                from3.Show();
                dgv(); //调用委托方法
                //Cv2.ImShow("波段计算结果", result);
            }
            catch
            {
                MessageBox.Show("公式有误，请重新输入");
            }
        }

        #region 波段计算
        private void CalculateBand()
        {
            string str = operatorStack.Pop().ToString();
            if (bandStack.Count < 2)
                return;
            Mat band2 = (Mat)bandStack.Pop();
            Mat band1 = (Mat)bandStack.Pop();
            Mat band3 = new Mat();

            if (str == "+")
            {
                Cv2.Add(band1, band2, band3);
                bandStack.Push(band3);
            }
            else if (str == "-")
            {
                Cv2.Subtract(band1, band2, band3);
                bandStack.Push(band3);
            }
            else if (str == "*")
            {
                Cv2.Multiply(band1, band2, band3);
                bandStack.Push(band3);
            }
            else if (str == "/")
            {
                Cv2.Divide(band1, band2, band3);
                bandStack.Push(band3);
            }
            else if (str == "=" || str == "(")
            {
                return;
            }
            else
            {
                MessageBox.Show("公式有误，请重新输入");
            }
        }

        private bool OperatorCompare(string str1, string str2)
        {
            Dictionary<string, int> priority = new Dictionary<string, int>();
            priority.Add("+", 1);
            priority.Add("-", 1);
            priority.Add("*", 2);
            priority.Add("/", 2);
            priority.Add(")", 0);
            priority.Add("(", 1);
            priority.Add("=", 0);

            if (priority[str1] <= priority[str2])
                return false;
            else
                return true;
        }
        #endregion

        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView3.SelectedNode = treeView3.GetNodeAt(e.X, e.Y);
            }
        }
    }
}

