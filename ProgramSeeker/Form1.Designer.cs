namespace ProgramSeeker
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabHost = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.listNodes = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabHost.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(113, 6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(178, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.validateOptions);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 35);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.validateOptions);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // tabHost
            // 
            this.tabHost.Controls.Add(this.tabPage1);
            this.tabHost.Controls.Add(this.tabPage2);
            this.tabHost.Controls.Add(this.tabPage3);
            this.tabHost.Controls.Add(this.tabPage4);
            this.tabHost.Location = new System.Drawing.Point(12, 12);
            this.tabHost.Name = "tabHost";
            this.tabHost.SelectedIndex = 0;
            this.tabHost.Size = new System.Drawing.Size(350, 312);
            this.tabHost.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(342, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtName);
            this.tabPage2.Controls.Add(this.txtPath);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(107, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 20);
            this.txtName.TabIndex = 13;
            this.txtName.TextChanged += new System.EventHandler(this.validateOptions);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(107, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(153, 20);
            this.txtPath.TabIndex = 12;
            this.txtPath.TextChanged += new System.EventHandler(this.validateOptions);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filename:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Output Folder:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox7);
            this.tabPage3.Controls.Add(this.checkBox6);
            this.tabPage3.Controls.Add(this.checkBox5);
            this.tabPage3.Controls.Add(this.checkBox4);
            this.tabPage3.Controls.Add(this.checkBox3);
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(342, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Output";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(23, 162);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(80, 17);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Text = "checkBox7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(23, 138);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(80, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "checkBox6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(23, 114);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(80, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(23, 90);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(106, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Get Model Name";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(23, 66);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(112, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Get Serial Number";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(23, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(121, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Get Product Version";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Get Product Name";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.listNodes);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(342, 286);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Targets";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listNodes
            // 
            this.listNodes.FormattingEnabled = true;
            this.listNodes.Location = new System.Drawing.Point(6, 3);
            this.listNodes.Name = "listNodes";
            this.listNodes.ScrollAlwaysVisible = true;
            this.listNodes.Size = new System.Drawing.Size(330, 251);
            this.listNodes.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 330);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 365);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabHost);
            this.Name = "Form1";
            this.Text = "ProgramSeeker";
            this.tabHost.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabHost;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listNodes;
    }
}

