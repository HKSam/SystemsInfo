namespace Test
{
    partial class frmProcess
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcess));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Line1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Status1 = new System.Windows.Forms.StatusStrip();
            this.Status1_Process = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status1_Cpu = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status1_Memory = new System.Windows.Forms.ToolStripStatusLabel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.tabMain_App = new System.Windows.Forms.TabPage();
            this.LvApp = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PnlAppBtn = new System.Windows.Forms.Panel();
            this.btReApp = new System.Windows.Forms.Button();
            this.tabMain_Process = new System.Windows.Forms.TabPage();
            this.lvProcess = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlProcessBtn = new System.Windows.Forms.Panel();
            this.btEndProcess = new System.Windows.Forms.Button();
            this.tabMain_Sys = new System.Windows.Forms.TabPage();
            this.pnlSys = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstNet = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvDisk = new System.Windows.Forms.ListView();
            this.DiskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Space = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpaceAvailable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbCup = new System.Windows.Forms.GroupBox();
            this.lcCpu = new Test.LineChart();
            this.tmrProcess = new System.Windows.Forms.Timer(this.components);
            this.tmrSysInfo = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.Status1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TabMain.SuspendLayout();
            this.tabMain_App.SuspendLayout();
            this.PnlAppBtn.SuspendLayout();
            this.tabMain_Process.SuspendLayout();
            this.pnlProcessBtn.SuspendLayout();
            this.tabMain_Sys.SuspendLayout();
            this.pnlSys.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbCup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(556, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_New,
            this.mnuFile_Line1,
            this.mnuFile_Exit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(58, 21);
            this.mnuFile.Text = "文件(&F)";
            // 
            // mnuFile_New
            // 
            this.mnuFile_New.Name = "mnuFile_New";
            this.mnuFile_New.Size = new System.Drawing.Size(151, 22);
            this.mnuFile_New.Text = "新建任务(&N)...";
            this.mnuFile_New.Click += new System.EventHandler(this.mnuFile_New_Click);
            // 
            // mnuFile_Line1
            // 
            this.mnuFile_Line1.Name = "mnuFile_Line1";
            this.mnuFile_Line1.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuFile_Exit
            // 
            this.mnuFile_Exit.Name = "mnuFile_Exit";
            this.mnuFile_Exit.Size = new System.Drawing.Size(151, 22);
            this.mnuFile_Exit.Text = "退出(&X)";
            this.mnuFile_Exit.Click += new System.EventHandler(this.mnuFile_Exit_Click);
            // 
            // Status1
            // 
            this.Status1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status1_Process,
            this.Status1_Cpu,
            this.Status1_Memory});
            this.Status1.Location = new System.Drawing.Point(0, 558);
            this.Status1.Name = "Status1";
            this.Status1.Size = new System.Drawing.Size(556, 22);
            this.Status1.TabIndex = 1;
            // 
            // Status1_Process
            // 
            this.Status1_Process.AutoSize = false;
            this.Status1_Process.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Status1_Process.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.Status1_Process.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Status1_Process.Name = "Status1_Process";
            this.Status1_Process.Size = new System.Drawing.Size(100, 19);
            this.Status1_Process.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status1_Cpu
            // 
            this.Status1_Cpu.AutoSize = false;
            this.Status1_Cpu.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Status1_Cpu.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.Status1_Cpu.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Status1_Cpu.Name = "Status1_Cpu";
            this.Status1_Cpu.Size = new System.Drawing.Size(120, 19);
            this.Status1_Cpu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status1_Memory
            // 
            this.Status1_Memory.AutoSize = false;
            this.Status1_Memory.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Status1_Memory.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.Status1_Memory.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Status1_Memory.Name = "Status1_Memory";
            this.Status1_Memory.Size = new System.Drawing.Size(321, 19);
            this.Status1_Memory.Spring = true;
            this.Status1_Memory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TabMain);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 25);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.Panel1.Size = new System.Drawing.Size(556, 533);
            this.Panel1.TabIndex = 2;
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.tabMain_App);
            this.TabMain.Controls.Add(this.tabMain_Process);
            this.TabMain.Controls.Add(this.tabMain_Sys);
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(6, 4);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(544, 523);
            this.TabMain.TabIndex = 0;
            // 
            // tabMain_App
            // 
            this.tabMain_App.Controls.Add(this.LvApp);
            this.tabMain_App.Controls.Add(this.PnlAppBtn);
            this.tabMain_App.Location = new System.Drawing.Point(4, 22);
            this.tabMain_App.Name = "tabMain_App";
            this.tabMain_App.Padding = new System.Windows.Forms.Padding(12);
            this.tabMain_App.Size = new System.Drawing.Size(536, 497);
            this.tabMain_App.TabIndex = 0;
            this.tabMain_App.Text = "应用程序";
            this.tabMain_App.UseVisualStyleBackColor = true;
            // 
            // LvApp
            // 
            this.LvApp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title});
            this.LvApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvApp.FullRowSelect = true;
            this.LvApp.HideSelection = false;
            this.LvApp.Location = new System.Drawing.Point(12, 12);
            this.LvApp.Name = "LvApp";
            this.LvApp.Size = new System.Drawing.Size(512, 443);
            this.LvApp.TabIndex = 0;
            this.LvApp.UseCompatibleStateImageBehavior = false;
            this.LvApp.View = System.Windows.Forms.View.Details;
            // 
            // title
            // 
            this.title.Text = "标题";
            this.title.Width = 360;
            // 
            // PnlAppBtn
            // 
            this.PnlAppBtn.Controls.Add(this.btReApp);
            this.PnlAppBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlAppBtn.Location = new System.Drawing.Point(12, 455);
            this.PnlAppBtn.Name = "PnlAppBtn";
            this.PnlAppBtn.Size = new System.Drawing.Size(512, 30);
            this.PnlAppBtn.TabIndex = 1;
            // 
            // btReApp
            // 
            this.btReApp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btReApp.Location = new System.Drawing.Point(437, 6);
            this.btReApp.Name = "btReApp";
            this.btReApp.Size = new System.Drawing.Size(75, 23);
            this.btReApp.TabIndex = 0;
            this.btReApp.Text = "刷新(&R)";
            this.btReApp.UseVisualStyleBackColor = true;
            this.btReApp.Click += new System.EventHandler(this.btReApp_Click);
            // 
            // tabMain_Process
            // 
            this.tabMain_Process.Controls.Add(this.lvProcess);
            this.tabMain_Process.Controls.Add(this.pnlProcessBtn);
            this.tabMain_Process.Location = new System.Drawing.Point(4, 22);
            this.tabMain_Process.Name = "tabMain_Process";
            this.tabMain_Process.Padding = new System.Windows.Forms.Padding(12);
            this.tabMain_Process.Size = new System.Drawing.Size(536, 497);
            this.tabMain_Process.TabIndex = 1;
            this.tabMain_Process.Text = "进程";
            this.tabMain_Process.UseVisualStyleBackColor = true;
            // 
            // lvProcess
            // 
            this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcess.FullRowSelect = true;
            this.lvProcess.HideSelection = false;
            this.lvProcess.Location = new System.Drawing.Point(12, 12);
            this.lvProcess.MultiSelect = false;
            this.lvProcess.Name = "lvProcess";
            this.lvProcess.Size = new System.Drawing.Size(512, 442);
            this.lvProcess.TabIndex = 12;
            this.lvProcess.UseCompatibleStateImageBehavior = false;
            this.lvProcess.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CPU";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 30;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "内存";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "路径";
            this.columnHeader6.Width = 200;
            // 
            // pnlProcessBtn
            // 
            this.pnlProcessBtn.Controls.Add(this.btEndProcess);
            this.pnlProcessBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProcessBtn.Location = new System.Drawing.Point(12, 454);
            this.pnlProcessBtn.Name = "pnlProcessBtn";
            this.pnlProcessBtn.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlProcessBtn.Size = new System.Drawing.Size(512, 31);
            this.pnlProcessBtn.TabIndex = 13;
            // 
            // btEndProcess
            // 
            this.btEndProcess.Dock = System.Windows.Forms.DockStyle.Right;
            this.btEndProcess.Location = new System.Drawing.Point(408, 8);
            this.btEndProcess.Name = "btEndProcess";
            this.btEndProcess.Size = new System.Drawing.Size(104, 23);
            this.btEndProcess.TabIndex = 0;
            this.btEndProcess.Text = "结束进程(&E)";
            this.btEndProcess.UseVisualStyleBackColor = true;
            this.btEndProcess.Click += new System.EventHandler(this.btEndProcess_Click);
            // 
            // tabMain_Sys
            // 
            this.tabMain_Sys.Controls.Add(this.pnlSys);
            this.tabMain_Sys.Location = new System.Drawing.Point(4, 22);
            this.tabMain_Sys.Name = "tabMain_Sys";
            this.tabMain_Sys.Padding = new System.Windows.Forms.Padding(12);
            this.tabMain_Sys.Size = new System.Drawing.Size(536, 497);
            this.tabMain_Sys.TabIndex = 2;
            this.tabMain_Sys.Text = "性能";
            this.tabMain_Sys.UseVisualStyleBackColor = true;
            // 
            // pnlSys
            // 
            this.pnlSys.Controls.Add(this.groupBox2);
            this.pnlSys.Controls.Add(this.groupBox1);
            this.pnlSys.Controls.Add(this.gbCup);
            this.pnlSys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSys.Location = new System.Drawing.Point(12, 12);
            this.pnlSys.Name = "pnlSys";
            this.pnlSys.Size = new System.Drawing.Size(512, 473);
            this.pnlSys.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstNet);
            this.groupBox2.Location = new System.Drawing.Point(296, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 280);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网络信息";
            // 
            // lstNet
            // 
            this.lstNet.FormattingEnabled = true;
            this.lstNet.ItemHeight = 12;
            this.lstNet.Location = new System.Drawing.Point(8, 24);
            this.lstNet.Name = "lstNet";
            this.lstNet.Size = new System.Drawing.Size(200, 244);
            this.lstNet.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvDisk);
            this.groupBox1.Location = new System.Drawing.Point(0, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 280);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "磁盘信息";
            // 
            // lvDisk
            // 
            this.lvDisk.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DiskName,
            this.Space,
            this.SpaceAvailable});
            this.lvDisk.FullRowSelect = true;
            this.lvDisk.Location = new System.Drawing.Point(8, 24);
            this.lvDisk.MultiSelect = false;
            this.lvDisk.Name = "lvDisk";
            this.lvDisk.Size = new System.Drawing.Size(272, 248);
            this.lvDisk.TabIndex = 10;
            this.lvDisk.UseCompatibleStateImageBehavior = false;
            this.lvDisk.View = System.Windows.Forms.View.Details;
            // 
            // DiskName
            // 
            this.DiskName.Text = "盘符";
            // 
            // Space
            // 
            this.Space.Text = "总空间";
            this.Space.Width = 100;
            // 
            // SpaceAvailable
            // 
            this.SpaceAvailable.Text = "剩余空间";
            this.SpaceAvailable.Width = 100;
            // 
            // gbCup
            // 
            this.gbCup.Controls.Add(this.lcCpu);
            this.gbCup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCup.Location = new System.Drawing.Point(0, 0);
            this.gbCup.Name = "gbCup";
            this.gbCup.Padding = new System.Windows.Forms.Padding(8);
            this.gbCup.Size = new System.Drawing.Size(512, 168);
            this.gbCup.TabIndex = 0;
            this.gbCup.TabStop = false;
            this.gbCup.Text = "CPU 使用记录";
            // 
            // lcCpu
            // 
            this.lcCpu.BackColor = System.Drawing.Color.Black;
            this.lcCpu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lcCpu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcCpu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.lcCpu.GridMoveStep = 3;
            this.lcCpu.GridSize = new System.Drawing.Size(12, 12);
            this.lcCpu.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lcCpu.Location = new System.Drawing.Point(8, 22);
            this.lcCpu.MoveGrid = true;
            this.lcCpu.Name = "lcCpu";
            this.lcCpu.Size = new System.Drawing.Size(496, 138);
            this.lcCpu.TabIndex = 0;
            // 
            // tmrProcess
            // 
            this.tmrProcess.Enabled = true;
            this.tmrProcess.Interval = 1000;
            this.tmrProcess.Tick += new System.EventHandler(this.tmrProcess_Tick);
            // 
            // tmrSysInfo
            // 
            this.tmrSysInfo.Enabled = true;
            this.tmrSysInfo.Interval = 1000;
            this.tmrSysInfo.Tick += new System.EventHandler(this.tmrSysInfo_Tick);
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 580);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Status1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "frmProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows 任务管理器";
            this.Load += new System.EventHandler(this.frmProcess_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Status1.ResumeLayout(false);
            this.Status1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.TabMain.ResumeLayout(false);
            this.tabMain_App.ResumeLayout(false);
            this.PnlAppBtn.ResumeLayout(false);
            this.tabMain_Process.ResumeLayout(false);
            this.pnlProcessBtn.ResumeLayout(false);
            this.tabMain_Sys.ResumeLayout(false);
            this.pnlSys.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbCup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_New;
        private System.Windows.Forms.ToolStripSeparator mnuFile_Line1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Exit;
        private System.Windows.Forms.StatusStrip Status1;
        private System.Windows.Forms.ToolStripStatusLabel Status1_Cpu;
        private System.Windows.Forms.ToolStripStatusLabel Status1_Memory;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage tabMain_App;
        private System.Windows.Forms.TabPage tabMain_Process;
        private System.Windows.Forms.TabPage tabMain_Sys;
        private System.Windows.Forms.ListView LvApp;
        private System.Windows.Forms.Panel PnlAppBtn;
        private System.Windows.Forms.ListView lvProcess;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Timer tmrProcess;
        private System.Windows.Forms.Panel pnlProcessBtn;
        private System.Windows.Forms.Button btEndProcess;
        private System.Windows.Forms.Timer tmrSysInfo;
        private System.Windows.Forms.ToolStripStatusLabel Status1_Process;
        private System.Windows.Forms.Panel pnlSys;
        private System.Windows.Forms.GroupBox gbCup;
        private LineChart lcCpu;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.Button btReApp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvDisk;
        private System.Windows.Forms.ColumnHeader DiskName;
        private System.Windows.Forms.ColumnHeader Space;
        private System.Windows.Forms.ColumnHeader SpaceAvailable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstNet;
    }
}