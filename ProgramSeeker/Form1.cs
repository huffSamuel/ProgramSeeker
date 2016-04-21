using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Management;

namespace ProgramSeeker
{
    public partial class Form1 : Form
    {
        private string folderName;
        private string val = "";

        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            //btnStart.Enabled = false;
            checkBox2.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
                txtPath.Text = "..." + folderBrowserDialog1.SelectedPath.Substring(folderName.LastIndexOf('\\'));
            }
        }

        private void validateOptions(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text) ||
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtUsername.Text))
            {
                btnStart.Enabled = false;
            }
            else
                btnStart.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = true;
            }
            else
                checkBox2.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\telecom\Downloads\test.cmd", "wmic csproduct get name");
            System.IO.File.WriteAllText(@"C:\Users\Telecom\Desktop\Output.txt", "Gathered Information:");

            Process p = new Process();
            val = "";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "C:\\Users\\telecom\\Downloads\\test.cmd";

            p.Start();
            val += p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            /* This scans for everything and sorts it */
            string[] lines = val.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(lines, (x, y) => String.Compare(x, y));
            foreach (string l in lines)
            {
                if (!l.StartsWith("C:\\") && !string.IsNullOrEmpty(l))
                {
                    System.IO.File.AppendAllText(@"C:\Users\Telecom\Desktop\Output.txt", l + Environment.NewLine);
                }
            }
            MessageBox.Show("Finished");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string line;
            MessageBox.Show("Select text file that contains a raw paste of SCCM all items.");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                while ((line = sr.ReadLine()) != null)
                {
                    line = Regex.Replace(line, @"OTK", "");
                    line = Regex.Replace(line, @"Active", "");
                    line = Regex.Replace(line, @"Inactive", "");
                    line = Regex.Replace(line, @"Yes", "");
                    line = Regex.Replace(line, @"No", "");
                    line = Regex.Replace(line, @"\t+", "");
                    listNodes.Items.Add(line);
                }
            }
        }
    }
}
