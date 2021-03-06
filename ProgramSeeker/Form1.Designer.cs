﻿namespace ProgramSeeker
{
    partial class Form1
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.contextStripNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeNodes = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSingleNode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listTargets = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkModelName = new System.Windows.Forms.CheckBox();
            this.chkSerialNum = new System.Windows.Forms.CheckBox();
            this.chkProdVer = new System.Windows.Forms.CheckBox();
            this.chkProdName = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabHost = new System.Windows.Forms.TabControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.treeSoftware = new System.Windows.Forms.TreeView();
            this.progressScan = new System.Windows.Forms.ProgressBar();
            this.contextStripResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.treeFailed = new System.Windows.Forms.TreeView();
            this.contextFailed = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextStripNodes.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabHost.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.contextStripResults.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.contextFailed.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 678);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // contextStripNodes
            // 
            this.contextStripNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.contextStripNodes.Name = "contextStripNodes";
            this.contextStripNodes.Size = new System.Drawing.Size(118, 26);
            this.contextStripNodes.Text = "Remove";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // treeNodes
            // 
            this.treeNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeNodes.Location = new System.Drawing.Point(-4, 0);
            this.treeNodes.Name = "treeNodes";
            this.treeNodes.Size = new System.Drawing.Size(833, 645);
            this.treeNodes.TabIndex = 11;
            this.treeNodes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeNodes_MouseUp);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnAdd);
            this.tabPage4.Controls.Add(this.txtSingleNode);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.listTargets);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(295, 619);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Targets";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 590);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSingleNode
            // 
            this.txtSingleNode.Location = new System.Drawing.Point(84, 592);
            this.txtSingleNode.Name = "txtSingleNode";
            this.txtSingleNode.Size = new System.Drawing.Size(205, 20);
            this.txtSingleNode.TabIndex = 2;
            this.txtSingleNode.TextChanged += new System.EventHandler(this.txtSingleNode_TextChanged);
            this.txtSingleNode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSingleNode_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 561);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listTargets
            // 
            this.listTargets.FormattingEnabled = true;
            this.listTargets.Location = new System.Drawing.Point(6, 3);
            this.listTargets.Name = "listTargets";
            this.listTargets.ScrollAlwaysVisible = true;
            this.listTargets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listTargets.Size = new System.Drawing.Size(283, 550);
            this.listTargets.TabIndex = 0;
            this.listTargets.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listNodes_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkModelName);
            this.tabPage3.Controls.Add(this.chkSerialNum);
            this.tabPage3.Controls.Add(this.chkProdVer);
            this.tabPage3.Controls.Add(this.chkProdName);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(295, 619);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Output";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkModelName
            // 
            this.chkModelName.AutoSize = true;
            this.chkModelName.Location = new System.Drawing.Point(23, 90);
            this.chkModelName.Name = "chkModelName";
            this.chkModelName.Size = new System.Drawing.Size(106, 17);
            this.chkModelName.TabIndex = 3;
            this.chkModelName.Text = "Get Model Name";
            this.chkModelName.UseVisualStyleBackColor = true;
            // 
            // chkSerialNum
            // 
            this.chkSerialNum.AutoSize = true;
            this.chkSerialNum.Location = new System.Drawing.Point(23, 66);
            this.chkSerialNum.Name = "chkSerialNum";
            this.chkSerialNum.Size = new System.Drawing.Size(112, 17);
            this.chkSerialNum.TabIndex = 2;
            this.chkSerialNum.Text = "Get Serial Number";
            this.chkSerialNum.UseVisualStyleBackColor = true;
            // 
            // chkProdVer
            // 
            this.chkProdVer.AutoSize = true;
            this.chkProdVer.Location = new System.Drawing.Point(23, 42);
            this.chkProdVer.Name = "chkProdVer";
            this.chkProdVer.Size = new System.Drawing.Size(121, 17);
            this.chkProdVer.TabIndex = 1;
            this.chkProdVer.Text = "Get Product Version";
            this.chkProdVer.UseVisualStyleBackColor = true;
            // 
            // chkProdName
            // 
            this.chkProdName.AutoSize = true;
            this.chkProdName.Location = new System.Drawing.Point(23, 18);
            this.chkProdName.Name = "chkProdName";
            this.chkProdName.Size = new System.Drawing.Size(114, 17);
            this.chkProdName.TabIndex = 0;
            this.chkProdName.Text = "Get Product Name";
            this.chkProdName.UseVisualStyleBackColor = true;
            this.chkProdName.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.txtPath);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(295, 619);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Output File";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Login Information";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 153);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 20);
            this.txtName.TabIndex = 18;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(88, 127);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(153, 20);
            this.txtPath.TabIndex = 17;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(88, 35);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(178, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.validateOptions);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.validateOptions);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Filename:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Output Folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // tabHost
            // 
            this.tabHost.Controls.Add(this.tabPage1);
            this.tabHost.Controls.Add(this.tabPage3);
            this.tabHost.Controls.Add(this.tabPage4);
            this.tabHost.Location = new System.Drawing.Point(12, 27);
            this.tabHost.Name = "tabHost";
            this.tabHost.SelectedIndex = 0;
            this.tabHost.Size = new System.Drawing.Size(303, 645);
            this.tabHost.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(352, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 674);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeNodes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 648);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Nodes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.treeSoftware);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(832, 648);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Software";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // treeSoftware
            // 
            this.treeSoftware.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeSoftware.Location = new System.Drawing.Point(-4, 0);
            this.treeSoftware.Name = "treeSoftware";
            this.treeSoftware.Size = new System.Drawing.Size(836, 667);
            this.treeSoftware.TabIndex = 0;
            // 
            // progressScan
            // 
            this.progressScan.Location = new System.Drawing.Point(94, 678);
            this.progressScan.Name = "progressScan";
            this.progressScan.Size = new System.Drawing.Size(217, 23);
            this.progressScan.TabIndex = 13;
            // 
            // contextStripResults
            // 
            this.contextStripResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.contextStripResults.Name = "contextStripResults";
            this.contextStripResults.Size = new System.Drawing.Size(118, 48);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem1_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearOutputToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // clearOutputToolStripMenuItem
            // 
            this.clearOutputToolStripMenuItem.Name = "clearOutputToolStripMenuItem";
            this.clearOutputToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearOutputToolStripMenuItem.Text = "Clear Output";
            this.clearOutputToolStripMenuItem.Click += new System.EventHandler(this.clearOutputToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.treeFailed);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(832, 648);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Failed";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // treeFailed
            // 
            this.treeFailed.Location = new System.Drawing.Point(0, 0);
            this.treeFailed.Name = "treeFailed";
            this.treeFailed.Size = new System.Drawing.Size(829, 648);
            this.treeFailed.TabIndex = 0;
            this.treeFailed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeFailed_MouseUp);
            // 
            // contextFailed
            // 
            this.contextFailed.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reScanToolStripMenuItem});
            this.contextFailed.Name = "contextFailed";
            this.contextFailed.Size = new System.Drawing.Size(153, 48);
            // 
            // reScanToolStripMenuItem
            // 
            this.reScanToolStripMenuItem.Name = "reScanToolStripMenuItem";
            this.reScanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reScanToolStripMenuItem.Text = "Re-Scan";
            this.reScanToolStripMenuItem.Click += new System.EventHandler(this.reScanToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 713);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.progressScan);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabHost);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ProgramSeeker";
            this.contextStripNodes.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabHost.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.contextStripResults.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.contextFailed.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ContextMenuStrip contextStripNodes;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.TreeView treeNodes;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSingleNode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listTargets;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkModelName;
        private System.Windows.Forms.CheckBox chkSerialNum;
        private System.Windows.Forms.CheckBox chkProdVer;
        private System.Windows.Forms.CheckBox chkProdName;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabHost;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TreeView treeSoftware;
        private System.Windows.Forms.ProgressBar progressScan;
        private System.Windows.Forms.ContextMenuStrip contextStripResults;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TreeView treeFailed;
        private System.Windows.Forms.ContextMenuStrip contextFailed;
        private System.Windows.Forms.ToolStripMenuItem reScanToolStripMenuItem;
    }
}

