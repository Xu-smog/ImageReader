namespace ImageReader
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RightArrow = new System.Windows.Forms.Button();
            this.Equal = new System.Windows.Forms.Button();
            this.LeftArrow = new System.Windows.Forms.Button();
            this.RightBracket = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.LeftBracket = new System.Windows.Forms.Button();
            this.Div = new System.Windows.Forms.Button();
            this.Mul = new System.Windows.Forms.Button();
            this.Sub = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.formulaBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(808, 443);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(808, 490);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(808, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(161, 17);
            this.toolStripStatusLabel1.Text = "各项输入之间应以空格间隔...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.RightArrow);
            this.splitContainer1.Panel2.Controls.Add(this.Equal);
            this.splitContainer1.Panel2.Controls.Add(this.LeftArrow);
            this.splitContainer1.Panel2.Controls.Add(this.RightBracket);
            this.splitContainer1.Panel2.Controls.Add(this.Clear);
            this.splitContainer1.Panel2.Controls.Add(this.LeftBracket);
            this.splitContainer1.Panel2.Controls.Add(this.Div);
            this.splitContainer1.Panel2.Controls.Add(this.Mul);
            this.splitContainer1.Panel2.Controls.Add(this.Sub);
            this.splitContainer1.Panel2.Controls.Add(this.Add);
            this.splitContainer1.Panel2.Controls.Add(this.formulaBox);
            this.splitContainer1.Size = new System.Drawing.Size(808, 443);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView3
            // 
            this.treeView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView3.Location = new System.Drawing.Point(0, 0);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(194, 443);
            this.treeView3.TabIndex = 2;
            this.treeView3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewMouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "系数：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(27, 106);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 32);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "1.0";
            // 
            // RightArrow
            // 
            this.RightArrow.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RightArrow.Location = new System.Drawing.Point(118, 22);
            this.RightArrow.Margin = new System.Windows.Forms.Padding(2);
            this.RightArrow.Name = "RightArrow";
            this.RightArrow.Size = new System.Drawing.Size(38, 193);
            this.RightArrow.TabIndex = 10;
            this.RightArrow.Text = "→";
            this.RightArrow.UseVisualStyleBackColor = true;
            this.RightArrow.Click += new System.EventHandler(this.RightArrowButton);
            // 
            // Equal
            // 
            this.Equal.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Equal.Location = new System.Drawing.Point(454, 174);
            this.Equal.Margin = new System.Windows.Forms.Padding(2);
            this.Equal.Name = "Equal";
            this.Equal.Size = new System.Drawing.Size(38, 40);
            this.Equal.TabIndex = 9;
            this.Equal.Text = "=";
            this.Equal.UseVisualStyleBackColor = true;
            this.Equal.Click += new System.EventHandler(this.EqualButton);
            // 
            // LeftArrow
            // 
            this.LeftArrow.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeftArrow.Location = new System.Drawing.Point(227, 174);
            this.LeftArrow.Margin = new System.Windows.Forms.Padding(2);
            this.LeftArrow.Name = "LeftArrow";
            this.LeftArrow.Size = new System.Drawing.Size(38, 40);
            this.LeftArrow.TabIndex = 8;
            this.LeftArrow.Text = "←";
            this.LeftArrow.UseVisualStyleBackColor = true;
            this.LeftArrow.Click += new System.EventHandler(this.LeftArrowButton);
            // 
            // RightBracket
            // 
            this.RightBracket.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RightBracket.Location = new System.Drawing.Point(454, 96);
            this.RightBracket.Margin = new System.Windows.Forms.Padding(2);
            this.RightBracket.Name = "RightBracket";
            this.RightBracket.Size = new System.Drawing.Size(38, 40);
            this.RightBracket.TabIndex = 7;
            this.RightBracket.Text = ")";
            this.RightBracket.UseVisualStyleBackColor = true;
            this.RightBracket.Click += new System.EventHandler(this.RightBracketButton);
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Clear.Location = new System.Drawing.Point(338, 174);
            this.Clear.Margin = new System.Windows.Forms.Padding(2);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(38, 40);
            this.Clear.TabIndex = 6;
            this.Clear.Text = "C";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.ClearButton);
            // 
            // LeftBracket
            // 
            this.LeftBracket.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeftBracket.Location = new System.Drawing.Point(338, 96);
            this.LeftBracket.Margin = new System.Windows.Forms.Padding(2);
            this.LeftBracket.Name = "LeftBracket";
            this.LeftBracket.Size = new System.Drawing.Size(38, 40);
            this.LeftBracket.TabIndex = 5;
            this.LeftBracket.Text = "(";
            this.LeftBracket.UseVisualStyleBackColor = true;
            this.LeftBracket.Click += new System.EventHandler(this.LeftBracketButton);
            // 
            // Div
            // 
            this.Div.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Div.Location = new System.Drawing.Point(227, 97);
            this.Div.Margin = new System.Windows.Forms.Padding(2);
            this.Div.Name = "Div";
            this.Div.Size = new System.Drawing.Size(38, 40);
            this.Div.TabIndex = 4;
            this.Div.Text = "/";
            this.Div.UseVisualStyleBackColor = true;
            this.Div.Click += new System.EventHandler(this.DivButton);
            // 
            // Mul
            // 
            this.Mul.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mul.Location = new System.Drawing.Point(454, 23);
            this.Mul.Margin = new System.Windows.Forms.Padding(2);
            this.Mul.Name = "Mul";
            this.Mul.Size = new System.Drawing.Size(38, 40);
            this.Mul.TabIndex = 3;
            this.Mul.Text = "*";
            this.Mul.UseVisualStyleBackColor = true;
            this.Mul.Click += new System.EventHandler(this.MulButton);
            // 
            // Sub
            // 
            this.Sub.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sub.Location = new System.Drawing.Point(338, 22);
            this.Sub.Margin = new System.Windows.Forms.Padding(2);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(38, 40);
            this.Sub.TabIndex = 2;
            this.Sub.Text = "-";
            this.Sub.UseVisualStyleBackColor = true;
            this.Sub.Click += new System.EventHandler(this.SubButton);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add.Location = new System.Drawing.Point(227, 23);
            this.Add.Margin = new System.Windows.Forms.Padding(2);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(38, 40);
            this.Add.TabIndex = 1;
            this.Add.Text = "+";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.AddButton);
            // 
            // formulaBox
            // 
            this.formulaBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.formulaBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.formulaBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.formulaBox.Location = new System.Drawing.Point(0, 271);
            this.formulaBox.Margin = new System.Windows.Forms.Padding(2);
            this.formulaBox.Multiline = true;
            this.formulaBox.Name = "formulaBox";
            this.formulaBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.formulaBox.Size = new System.Drawing.Size(611, 172);
            this.formulaBox.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 490);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "波段计算";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Equal;
        private System.Windows.Forms.Button LeftArrow;
        private System.Windows.Forms.Button RightBracket;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button LeftBracket;
        private System.Windows.Forms.Button Div;
        private System.Windows.Forms.Button Mul;
        private System.Windows.Forms.Button Sub;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox formulaBox;
        private System.Windows.Forms.Button RightArrow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}