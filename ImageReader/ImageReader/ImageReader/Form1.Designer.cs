namespace ImageReader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.AtmCorr = new System.Windows.Forms.ToolStripMenuItem();
            this.SSModel = new System.Windows.Forms.ToolStripMenuItem();
            this.RunAtmCorr = new System.Windows.Forms.ToolStripMenuItem();
            this.StripNoiseRemoval = new System.Windows.Forms.ToolStripMenuItem();
            this.MomentMatching = new System.Windows.Forms.ToolStripMenuItem();
            this.tianchong = new System.Windows.Forms.ToolStripMenuItem();
            this.包络线去除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DerivativeTransformation = new System.Windows.Forms.ToolStripMenuItem();
            this.RunDerivativeTransformation = new System.Windows.Forms.ToolStripMenuItem();
            this.Correction = new System.Windows.Forms.ToolStripMenuItem();
            this.RunCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.showPicBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.RunBandCalculate = new System.Windows.Forms.ToolStripMenuItem();
            this.NDVIBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.NDWIBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeRGB = new System.Windows.Forms.ToolStripMenuItem();
            this.RunMakeRGB = new System.Windows.Forms.ToolStripMenuItem();
            this.Header = new System.Windows.Forms.ToolStripMenuItem();
            this.RunHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.dealBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.g2cBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.binBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.helpDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.Cross = new System.Windows.Forms.ToolStripButton();
            this.Arrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.AtmCorr,
            this.StripNoiseRemoval,
            this.包络线去除ToolStripMenuItem,
            this.DerivativeTransformation,
            this.Correction,
            this.showPicBtn,
            this.MakeRGB,
            this.Header,
            this.dealBtn,
            this.Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1066, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile,
            this.closeFile});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(44, 21);
            this.File.Text = "文件";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(100, 22);
            this.openFile.Text = "打开";
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(100, 22);
            this.saveFile.Text = "保存";
            this.saveFile.Click += new System.EventHandler(this.SaveFiles_Click);
            // 
            // closeFile
            // 
            this.closeFile.Name = "closeFile";
            this.closeFile.Size = new System.Drawing.Size(100, 22);
            this.closeFile.Text = "关闭";
            // 
            // AtmCorr
            // 
            this.AtmCorr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SSModel,
            this.RunAtmCorr});
            this.AtmCorr.Name = "AtmCorr";
            this.AtmCorr.Size = new System.Drawing.Size(68, 21);
            this.AtmCorr.Text = "大气校正";
            // 
            // SSModel
            // 
            this.SSModel.Name = "SSModel";
            this.SSModel.Size = new System.Drawing.Size(162, 22);
            this.SSModel.Text = "6S模型";
            this.SSModel.Click += new System.EventHandler(this.SSModel_Click);
            // 
            // RunAtmCorr
            // 
            this.RunAtmCorr.Name = "RunAtmCorr";
            this.RunAtmCorr.Size = new System.Drawing.Size(162, 22);
            this.RunAtmCorr.Text = "6S模型校正图像";
            this.RunAtmCorr.Click += new System.EventHandler(this.RunAtmCorr_Click);
            // 
            // StripNoiseRemoval
            // 
            this.StripNoiseRemoval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MomentMatching,
            this.tianchong});
            this.StripNoiseRemoval.Name = "StripNoiseRemoval";
            this.StripNoiseRemoval.Size = new System.Drawing.Size(92, 21);
            this.StripNoiseRemoval.Text = "条带噪声滤除";
            // 
            // MomentMatching
            // 
            this.MomentMatching.Name = "MomentMatching";
            this.MomentMatching.Size = new System.Drawing.Size(148, 22);
            this.MomentMatching.Text = "矩匹配法";
            this.MomentMatching.Click += new System.EventHandler(this.MomentMatching_Click);
            // 
            // tianchong
            // 
            this.tianchong.Name = "tianchong";
            this.tianchong.Size = new System.Drawing.Size(148, 22);
            this.tianchong.Text = "缺失像元填充";
            this.tianchong.Click += new System.EventHandler(this.RunTianchong_Click);
            // 
            // 包络线去除ToolStripMenuItem
            // 
            this.包络线去除ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行ToolStripMenuItem1});
            this.包络线去除ToolStripMenuItem.Name = "包络线去除ToolStripMenuItem";
            this.包络线去除ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.包络线去除ToolStripMenuItem.Text = "包络线去除";
            // 
            // 运行ToolStripMenuItem1
            // 
            this.运行ToolStripMenuItem1.Name = "运行ToolStripMenuItem1";
            this.运行ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.运行ToolStripMenuItem1.Text = "运行";
            // 
            // DerivativeTransformation
            // 
            this.DerivativeTransformation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunDerivativeTransformation});
            this.DerivativeTransformation.Name = "DerivativeTransformation";
            this.DerivativeTransformation.Size = new System.Drawing.Size(68, 21);
            this.DerivativeTransformation.Text = "导数变换";
            // 
            // RunDerivativeTransformation
            // 
            this.RunDerivativeTransformation.Name = "RunDerivativeTransformation";
            this.RunDerivativeTransformation.Size = new System.Drawing.Size(100, 22);
            this.RunDerivativeTransformation.Text = "运行";
            this.RunDerivativeTransformation.Click += new System.EventHandler(this.RunDerivativeTransformation_Click);
            // 
            // Correction
            // 
            this.Correction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunCorrection});
            this.Correction.Name = "Correction";
            this.Correction.Size = new System.Drawing.Size(68, 21);
            this.Correction.Text = "几何校正";
            // 
            // RunCorrection
            // 
            this.RunCorrection.Name = "RunCorrection";
            this.RunCorrection.Size = new System.Drawing.Size(100, 22);
            this.RunCorrection.Text = "运行";
            this.RunCorrection.Click += new System.EventHandler(this.RunCorrection_Click);
            // 
            // showPicBtn
            // 
            this.showPicBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunBandCalculate,
            this.NDVIBtn,
            this.NDWIBtn});
            this.showPicBtn.Name = "showPicBtn";
            this.showPicBtn.Size = new System.Drawing.Size(68, 21);
            this.showPicBtn.Text = "波段计算";
            // 
            // RunBandCalculate
            // 
            this.RunBandCalculate.Name = "RunBandCalculate";
            this.RunBandCalculate.Size = new System.Drawing.Size(180, 22);
            this.RunBandCalculate.Text = "运行";
            this.RunBandCalculate.Click += new System.EventHandler(this.RunBandCalculate_Click);
            // 
            // NDVIBtn
            // 
            this.NDVIBtn.Name = "NDVIBtn";
            this.NDVIBtn.Size = new System.Drawing.Size(180, 22);
            this.NDVIBtn.Text = "NDVI";
            this.NDVIBtn.Click += new System.EventHandler(this.NDVIBtn_Click);
            // 
            // NDWIBtn
            // 
            this.NDWIBtn.Name = "NDWIBtn";
            this.NDWIBtn.Size = new System.Drawing.Size(180, 22);
            this.NDWIBtn.Text = "NDWI";
            this.NDWIBtn.Click += new System.EventHandler(this.NDWIBtn_Click);
            // 
            // MakeRGB
            // 
            this.MakeRGB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunMakeRGB});
            this.MakeRGB.Name = "MakeRGB";
            this.MakeRGB.Size = new System.Drawing.Size(93, 21);
            this.MakeRGB.Text = "合成RGB图像";
            // 
            // RunMakeRGB
            // 
            this.RunMakeRGB.Name = "RunMakeRGB";
            this.RunMakeRGB.Size = new System.Drawing.Size(100, 22);
            this.RunMakeRGB.Text = "运行";
            this.RunMakeRGB.Click += new System.EventHandler(this.RunMakeRGB_Click);
            // 
            // Header
            // 
            this.Header.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunHeader});
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(104, 21);
            this.Header.Text = "遥感图像头文件";
            // 
            // RunHeader
            // 
            this.RunHeader.Name = "RunHeader";
            this.RunHeader.Size = new System.Drawing.Size(100, 22);
            this.RunHeader.Text = "运行";
            this.RunHeader.Click += new System.EventHandler(this.RunHeader_Click);
            // 
            // dealBtn
            // 
            this.dealBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g2cBtn,
            this.binBtn});
            this.dealBtn.Name = "dealBtn";
            this.dealBtn.Size = new System.Drawing.Size(68, 21);
            this.dealBtn.Text = "图像处理";
            // 
            // g2cBtn
            // 
            this.g2cBtn.Name = "g2cBtn";
            this.g2cBtn.Size = new System.Drawing.Size(180, 22);
            this.g2cBtn.Text = "灰度图转伪彩色";
            this.g2cBtn.Click += new System.EventHandler(this.g2cBtn_Click);
            // 
            // binBtn
            // 
            this.binBtn.Name = "binBtn";
            this.binBtn.Size = new System.Drawing.Size(180, 22);
            this.binBtn.Text = "图像二值化";
            this.binBtn.Click += new System.EventHandler(this.binBtn_Click);
            // 
            // Help
            // 
            this.Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpDoc});
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(44, 21);
            this.Help.Text = "帮助";
            // 
            // helpDoc
            // 
            this.helpDoc.Name = "helpDoc";
            this.helpDoc.Size = new System.Drawing.Size(124, 22);
            this.helpDoc.Text = "帮助文档";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.Cross,
            this.Arrow,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton10});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1066, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = global::ImageReader.Properties.Resources.open1;
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(24, 24);
            this.OpenButton.Text = "打开文件";
            this.OpenButton.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = global::ImageReader.Properties.Resources.save1;
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(24, 24);
            this.SaveButton.Text = "保存文件";
            this.SaveButton.Click += new System.EventHandler(this.SaveFiles_Click);
            // 
            // Cross
            // 
            this.Cross.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cross.Image = global::ImageReader.Properties.Resources.cross1;
            this.Cross.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cross.Name = "Cross";
            this.Cross.Size = new System.Drawing.Size(24, 24);
            this.Cross.Text = "取点";
            this.Cross.Click += new System.EventHandler(this.Cross_Click);
            // 
            // Arrow
            // 
            this.Arrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Arrow.Image = global::ImageReader.Properties.Resources.arrow1;
            this.Arrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Arrow.Name = "Arrow";
            this.Arrow.Size = new System.Drawing.Size(24, 24);
            this.Arrow.Text = "恢复鼠标形状";
            this.Arrow.Click += new System.EventHandler(this.Arrow_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ImageReader.Properties.Resources._6;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "6S模型";
            this.toolStripButton1.Click += new System.EventHandler(this.SSModel_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ImageReader.Properties.Resources.大气校正;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "6S模型校正图像";
            this.toolStripButton2.Click += new System.EventHandler(this.RunAtmCorr_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::ImageReader.Properties.Resources.矩匹配;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton8.Text = "矩匹配法";
            this.toolStripButton8.Click += new System.EventHandler(this.MomentMatching_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::ImageReader.Properties.Resources.填充;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton9.Text = "缺失像元填充";
            this.toolStripButton9.Click += new System.EventHandler(this.RunTianchong_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::ImageReader.Properties.Resources.导数变换;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "导数变换";
            this.toolStripButton3.Click += new System.EventHandler(this.RunDerivativeTransformation_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::ImageReader.Properties.Resources.几何校正;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "几何校正";
            this.toolStripButton4.Click += new System.EventHandler(this.RunCorrection_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::ImageReader.Properties.Resources.波段计算;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "波段计算";
            this.toolStripButton5.Click += new System.EventHandler(this.RunBandCalculate_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::ImageReader.Properties.Resources.RGB;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton6.Text = "合成RGB图像";
            this.toolStripButton6.Click += new System.EventHandler(this.RunMakeRGB_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::ImageReader.Properties.Resources.头文件;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton7.Text = "遥感图像头文件";
            this.toolStripButton7.Click += new System.EventHandler(this.RunHeader_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = global::ImageReader.Properties.Resources.更新;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton10.Text = "更新";
            this.toolStripButton10.Click += new System.EventHandler(this.RunUpdate_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1066, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1066, 583);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(228, 583);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.ShowImageDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewMouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(830, 583);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 657);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "滨海湿地高光谱卫星遥感影像处理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem closeFile;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem helpDoc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem AtmCorr;
        private System.Windows.Forms.ToolStripMenuItem SSModel;
        private System.Windows.Forms.ToolStripMenuItem RunAtmCorr;
        private System.Windows.Forms.ToolStripMenuItem StripNoiseRemoval;
        private System.Windows.Forms.ToolStripMenuItem MomentMatching;
        private System.Windows.Forms.ToolStripMenuItem 包络线去除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DerivativeTransformation;
        private System.Windows.Forms.ToolStripMenuItem RunDerivativeTransformation;
        private System.Windows.Forms.ToolStripMenuItem Correction;
        private System.Windows.Forms.ToolStripMenuItem RunCorrection;
        private System.Windows.Forms.ToolStripButton Cross;
        private System.Windows.Forms.ToolStripMenuItem showPicBtn;
        private System.Windows.Forms.ToolStripMenuItem RunBandCalculate;
        private System.Windows.Forms.ToolStripButton Arrow;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripMenuItem MakeRGB;
        private System.Windows.Forms.ToolStripMenuItem RunMakeRGB;
        private System.Windows.Forms.ToolStripMenuItem Header;
        private System.Windows.Forms.ToolStripMenuItem RunHeader;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripMenuItem tianchong;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripMenuItem NDVIBtn;
        private System.Windows.Forms.ToolStripMenuItem NDWIBtn;
        private System.Windows.Forms.ToolStripMenuItem dealBtn;
        private System.Windows.Forms.ToolStripMenuItem g2cBtn;
        private System.Windows.Forms.ToolStripMenuItem binBtn;
    }
}

