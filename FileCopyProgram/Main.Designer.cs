namespace FileCopyProgram
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSync = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkExpandAll = new System.Windows.Forms.CheckBox();
            this.chkAppend = new System.Windows.Forms.CheckBox();
            this.lblEmptyTree = new System.Windows.Forms.Label();
            this.lblFootnote = new System.Windows.Forms.Label();
            this.treeDirectory = new System.Windows.Forms.TreeView();
            this.cmdDirSelect = new System.Windows.Forms.Button();
            this.stBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel0 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAvailableSpace = new System.Windows.Forms.Label();
            this.txtTargetDir = new System.Windows.Forms.TextBox();
            this.cmdTargetSelect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optIncomingNewer = new System.Windows.Forms.RadioButton();
            this.optAllCases = new System.Windows.Forms.RadioButton();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progress = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdSync);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.chkAppend);
            this.groupBox1.Controls.Add(this.lblEmptyTree);
            this.groupBox1.Controls.Add(this.lblFootnote);
            this.groupBox1.Controls.Add(this.treeDirectory);
            this.groupBox1.Controls.Add(this.cmdDirSelect);
            this.groupBox1.Location = new System.Drawing.Point(23, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(876, 355);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Select files to copy";
            // 
            // cmdSync
            // 
            this.cmdSync.Enabled = false;
            this.cmdSync.Location = new System.Drawing.Point(25, 308);
            this.cmdSync.Name = "cmdSync";
            this.cmdSync.Size = new System.Drawing.Size(101, 25);
            this.cmdSync.TabIndex = 22;
            this.cmdSync.Text = "Synchronize";
            this.cmdSync.UseVisualStyleBackColor = true;
            this.cmdSync.Click += new System.EventHandler(this.cmdSync_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkAll);
            this.groupBox4.Controls.Add(this.chkExpandAll);
            this.groupBox4.Location = new System.Drawing.Point(10, 141);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(134, 86);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Enabled = false;
            this.chkAll.Location = new System.Drawing.Point(15, 21);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(88, 21);
            this.chkAll.TabIndex = 7;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkExpandAll
            // 
            this.chkExpandAll.AutoSize = true;
            this.chkExpandAll.Enabled = false;
            this.chkExpandAll.Location = new System.Drawing.Point(15, 48);
            this.chkExpandAll.Name = "chkExpandAll";
            this.chkExpandAll.Size = new System.Drawing.Size(96, 21);
            this.chkExpandAll.TabIndex = 20;
            this.chkExpandAll.Text = "Expand All";
            this.chkExpandAll.UseVisualStyleBackColor = true;
            this.chkExpandAll.CheckedChanged += new System.EventHandler(this.chkExpandAll_CheckedChanged);
            // 
            // chkAppend
            // 
            this.chkAppend.AutoSize = true;
            this.chkAppend.Enabled = false;
            this.chkAppend.Location = new System.Drawing.Point(6, 67);
            this.chkAppend.Name = "chkAppend";
            this.chkAppend.Size = new System.Drawing.Size(141, 21);
            this.chkAppend.TabIndex = 6;
            this.chkAppend.Text = "Append Selection";
            this.chkAppend.UseVisualStyleBackColor = true;
            // 
            // lblEmptyTree
            // 
            this.lblEmptyTree.AutoSize = true;
            this.lblEmptyTree.BackColor = System.Drawing.SystemColors.Window;
            this.lblEmptyTree.Location = new System.Drawing.Point(426, 165);
            this.lblEmptyTree.Name = "lblEmptyTree";
            this.lblEmptyTree.Size = new System.Drawing.Size(158, 17);
            this.lblEmptyTree.TabIndex = 5;
            this.lblEmptyTree.Text = "Display area for files list";
            // 
            // lblFootnote
            // 
            this.lblFootnote.AutoSize = true;
            this.lblFootnote.Location = new System.Drawing.Point(150, 336);
            this.lblFootnote.Name = "lblFootnote";
            this.lblFootnote.Size = new System.Drawing.Size(195, 17);
            this.lblFootnote.TabIndex = 4;
            this.lblFootnote.Text = "* checked items will be copied";
            // 
            // treeDirectory
            // 
            this.treeDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDirectory.CheckBoxes = true;
            this.treeDirectory.Location = new System.Drawing.Point(153, 36);
            this.treeDirectory.Name = "treeDirectory";
            this.treeDirectory.Size = new System.Drawing.Size(695, 297);
            this.treeDirectory.TabIndex = 3;
            this.treeDirectory.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeDirectory_AfterCheck);
            // 
            // cmdDirSelect
            // 
            this.cmdDirSelect.Location = new System.Drawing.Point(30, 36);
            this.cmdDirSelect.Name = "cmdDirSelect";
            this.cmdDirSelect.Size = new System.Drawing.Size(84, 25);
            this.cmdDirSelect.TabIndex = 0;
            this.cmdDirSelect.Text = "Select";
            this.cmdDirSelect.UseVisualStyleBackColor = true;
            this.cmdDirSelect.Click += new System.EventHandler(this.cmdDirSelect_Click);
            // 
            // stBar
            // 
            this.stBar.Location = new System.Drawing.Point(0, 747);
            this.stBar.Name = "stBar";
            this.stBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel0,
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.stBar.ShowPanels = true;
            this.stBar.Size = new System.Drawing.Size(924, 18);
            this.stBar.TabIndex = 13;
            // 
            // statusBarPanel0
            // 
            this.statusBarPanel0.Name = "statusBarPanel0";
            this.statusBarPanel0.Width = 150;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 375;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 375;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblAvailableSpace);
            this.groupBox2.Controls.Add(this.txtTargetDir);
            this.groupBox2.Controls.Add(this.cmdTargetSelect);
            this.groupBox2.Location = new System.Drawing.Point(23, 408);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(876, 84);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Select copy destination";
            // 
            // lblAvailableSpace
            // 
            this.lblAvailableSpace.AutoSize = true;
            this.lblAvailableSpace.Location = new System.Drawing.Point(150, 60);
            this.lblAvailableSpace.Name = "lblAvailableSpace";
            this.lblAvailableSpace.Size = new System.Drawing.Size(0, 17);
            this.lblAvailableSpace.TabIndex = 3;
            // 
            // txtTargetDir
            // 
            this.txtTargetDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetDir.Location = new System.Drawing.Point(147, 35);
            this.txtTargetDir.Name = "txtTargetDir";
            this.txtTargetDir.ReadOnly = true;
            this.txtTargetDir.Size = new System.Drawing.Size(701, 22);
            this.txtTargetDir.TabIndex = 2;
            // 
            // cmdTargetSelect
            // 
            this.cmdTargetSelect.Location = new System.Drawing.Point(30, 32);
            this.cmdTargetSelect.Name = "cmdTargetSelect";
            this.cmdTargetSelect.Size = new System.Drawing.Size(84, 25);
            this.cmdTargetSelect.TabIndex = 1;
            this.cmdTargetSelect.Text = "Select";
            this.cmdTargetSelect.UseVisualStyleBackColor = true;
            this.cmdTargetSelect.Click += new System.EventHandler(this.cmdTargetSelect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.optIncomingNewer);
            this.groupBox3.Controls.Add(this.optAllCases);
            this.groupBox3.Controls.Add(this.chkOverwrite);
            this.groupBox3.Location = new System.Drawing.Point(23, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(876, 108);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Set copy options";
            // 
            // optIncomingNewer
            // 
            this.optIncomingNewer.AutoSize = true;
            this.optIncomingNewer.Enabled = false;
            this.optIncomingNewer.Location = new System.Drawing.Point(232, 61);
            this.optIncomingNewer.Name = "optIncomingNewer";
            this.optIncomingNewer.Size = new System.Drawing.Size(199, 21);
            this.optIncomingNewer.TabIndex = 2;
            this.optIncomingNewer.TabStop = true;
            this.optIncomingNewer.Text = "Only If Incoming File Newer";
            this.optIncomingNewer.UseVisualStyleBackColor = true;
            // 
            // optAllCases
            // 
            this.optAllCases.AutoSize = true;
            this.optAllCases.Enabled = false;
            this.optAllCases.Location = new System.Drawing.Point(232, 34);
            this.optAllCases.Name = "optAllCases";
            this.optAllCases.Size = new System.Drawing.Size(87, 21);
            this.optAllCases.TabIndex = 1;
            this.optAllCases.TabStop = true;
            this.optAllCases.Text = "All Cases";
            this.optAllCases.UseVisualStyleBackColor = true;
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(30, 34);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(175, 21);
            this.chkOverwrite.TabIndex = 0;
            this.chkOverwrite.Text = "Overwrite Existing Files";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            this.chkOverwrite.CheckedChanged += new System.EventHandler(this.chkOverwrite_CheckedChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(819, 687);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 29);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.Location = new System.Drawing.Point(724, 687);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(80, 29);
            this.cmdOk.TabIndex = 17;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(607, 721);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "* click Cancel at anytime to cancel operations";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(23, 624);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(876, 23);
            this.progress.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 29);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(48, 25);
            this.scriptToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceDirectoryToolStripMenuItem,
            this.copyDestinationToolStripMenuItem});
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // sourceDirectoryToolStripMenuItem
            // 
            this.sourceDirectoryToolStripMenuItem.Name = "sourceDirectoryToolStripMenuItem";
            this.sourceDirectoryToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.sourceDirectoryToolStripMenuItem.Text = "Source Directory";
            this.sourceDirectoryToolStripMenuItem.Click += new System.EventHandler(this.sourceDirectoryToolStripMenuItem_Click);
            // 
            // copyDestinationToolStripMenuItem
            // 
            this.copyDestinationToolStripMenuItem.Name = "copyDestinationToolStripMenuItem";
            this.copyDestinationToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.copyDestinationToolStripMenuItem.Text = "Copy Destination";
            this.copyDestinationToolStripMenuItem.Click += new System.EventHandler(this.copyDestinationToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 765);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.stBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 810);
            this.MinimumSize = new System.Drawing.Size(932, 810);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Copy Program";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdDirSelect;
        private System.Windows.Forms.StatusBar stBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanel0;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.TreeView treeDirectory;
        private System.Windows.Forms.Label lblFootnote;
        private System.Windows.Forms.Label lblEmptyTree;
        private System.Windows.Forms.CheckBox chkAppend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTargetDir;
        private System.Windows.Forms.Button cmdTargetSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.RadioButton optIncomingNewer;
        private System.Windows.Forms.RadioButton optAllCases;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label lblAvailableSpace;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkExpandAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDestinationToolStripMenuItem;
        private System.Windows.Forms.Button cmdSync;
    }
}

