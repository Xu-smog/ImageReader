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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        #region 获取输入
        private void GetInput()
        {
            FileStream fsOut = new FileStream("input.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fsOut);
            fsOut.SetLength(0);//把文件清空
            
            if (t1.Text != string.Empty)
            {
                sw.Write(t1.Text + '\n');
            }                
            if (t2.Text != string.Empty)
            {
                sw.Write(t2.Text + '\n');
            }
            if (t3.Text != string.Empty)
            {
                sw.Write(t3.Text + '\n');
            }
            if (t4.Text != string.Empty)
            {
                sw.Write(t4.Text + '\n');
            }
            if (t5.Text != string.Empty)
            {
                sw.Write(t5.Text + '\n');
            }
            if (t6.Text != string.Empty)
            {
                sw.Write(t6.Text + '\n');
            }
            if (t7.Text != string.Empty)
            {
                sw.Write(t7.Text + '\n');
            }
            if (t8.Text != string.Empty)
            {
                sw.Write(t8.Text + '\n');
            }
            if (t9.Text != string.Empty)
            {
                sw.Write(t9.Text + '\n');
            }
            if (t10.Text != string.Empty)
            {
                sw.Write(t10.Text + '\n');
            }
            if (t11.Text != string.Empty)
            {
                sw.Write(t11.Text + '\n');
            }
            if (t12.Text != string.Empty)
            {
                sw.Write(t12.Text + '\n');
            }
            if (t13.Text != string.Empty)
            {
                sw.Write(t13.Text + '\n');
            }
            if (t14.Text != string.Empty)
            {
                sw.Write(t14.Text + '\n');
            }
            if (t15.Text != string.Empty)
            {
                sw.Write(t15.Text + '\n');
            }
            if (t16.Text != string.Empty)
            {
                sw.Write(t16.Text + '\n');
            }
            if (t17.Text != string.Empty)
            {
                sw.Write(t17.Text + '\n');
            }
            if (t18.Text != string.Empty)
            {
                sw.Write(t18.Text + '\n');
            }
            if (t19.Text != string.Empty)
            {
                sw.Write(t19.Text + '\n');
            }
            if (t20.Text != string.Empty)
            {
                sw.Write(t20.Text + '\n');
            }
            if (t21.Text != string.Empty)
            {
                sw.Write(t21.Text + '\n');
            }
            if (t22.Text != string.Empty)
            {
                sw.Write(t22.Text + '\n');
            }
            if (t23.Text != string.Empty)
            {
                sw.Write(t23.Text + '\n');
            }
            if (t24.Text != string.Empty)
            {
                sw.Write(t24.Text + '\n');
            }
            if (t25.Text != string.Empty)
            {
                sw.Write(t25.Text + '\n');
            }
            if (t26.Text != string.Empty)
            {
                sw.Write(t26.Text + '\n');
            }
            if (t27.Text != string.Empty)
            {
                sw.Write(t27.Text + '\n');
            }
            if (t28.Text != string.Empty)
            {
                sw.Write(t28.Text + '\n');
            }
            sw.Close();
        }
        #endregion

        private void Start6S_Click(object sender, EventArgs e)
        {
            try
            {
                GetInput();
                // 启动 6S.exe 进程，进行重定向输入.建立一个新进程来运行目标程序。
                Process SProcess = new Process();
                SProcess.StartInfo.FileName = "6s.exe ";//6s.exe存放位置
                                                        //只有UseShellExecute、RedirectStandardInput进行设置才能重定向输入
                SProcess.StartInfo.UseShellExecute = false;
                SProcess.StartInfo.RedirectStandardInput = true;
                SProcess.StartInfo.CreateNoWindow = true;   //不创建窗口
                SProcess.StartInfo.UseShellExecute = false;//不使用系统外壳程序启动,重定向输出的话必须设为false
                SProcess.StartInfo.RedirectStandardOutput = true; //重定向输出，而不是默认的显示在dos控制台上
                SProcess.StartInfo.RedirectStandardError = true;
                //SProcess.StartInfo.Arguments = input;
                SProcess.Start();

                //写数据流，向进程中写数据。
                StreamWriter SStreamWriter = SProcess.StandardInput;

                // Prompt the user for input text lines to sort. 
                // Write each line to the StandardInput stream of
                // the sort command.
                string inputText;
                FileStream fsIn = new FileStream("input.txt", FileMode.Open);//参数文件，按行排列。
                StreamReader sr = new StreamReader(fsIn);
                inputText = sr.ReadLine();
                while (inputText != null)
                {
                    SStreamWriter.WriteLine(inputText);//程序的核心，向目标程序中写入数据。
                    inputText = sr.ReadLine();
                }
                fsIn.Close();

                // End the input stream to the sort command.
                // When the stream closes, the sort command
                // writes the sorted text lines to the 
                // console.
                SStreamWriter.Close();
                // Wait for the sort process to write the sorted text lines.

                FileStream fsOut = new FileStream("output.txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fsOut);
                string outputText = SProcess.StandardOutput.ReadLine();//获取输出信息 
                string organized = "";
                while (outputText != null)
                {
                    organized += outputText;
                    outputText = SProcess.StandardOutput.ReadLine();
                }
                for(int i=0;i< organized.Length;i++)
                {
                    if (i+2 < organized.Length)
                    {
                        if(organized[i]==' '&& organized[i+1] == '*' && organized[i+2] == '*')
                        {
                            sw.Write("\r\n");
                        }
                    }
                    sw.Write(organized[i]);
                }
                sw.Write(outputText);//写字符串
                sw.Close();

                SProcess.WaitForExit();
                SProcess.Close();
                Process.Start("notepad.exe", "output.txt");
            }
            catch
            {
                MessageBox.Show("输入数据有误！请重新输入...,");
            }
        }

        private void Explain_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "explain.txt");
        }

        private void inputCase_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "inputCase.txt");
        }

        private void Header_Click(object sender, EventArgs e)
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
    }
}