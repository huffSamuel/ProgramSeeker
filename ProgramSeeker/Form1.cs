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

        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            //btnStart.Enabled = false;
            btnAdd.Enabled = false;
            chkProdVer.Enabled = false;
        }

        // Selects the destination of the output
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

        // Runs to enable/disable the start button
        private void validateOptions(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtPath.Text) ||           // Output path is empty
            //    string.IsNullOrEmpty(txtName.Text) ||           // Output filename is empty
            //    string.IsNullOrEmpty(txtPassword.Text) ||       // Password is empty
            //    string.IsNullOrEmpty(txtUsername.Text))         // Username is empty
            //{
            //    btnStart.Enabled = false;                       // Don't allow the query to run
            //}
            //else
                btnStart.Enabled = true;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chkProdVer.Enabled = chkProdName.Checked;
        }

        // Go.
        private void btnStart_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            string response = "";
            if (chkProdName.Checked)
            {
                sw.Start();
                if (chkProdVer.Checked)
                {
                    response = wmicCall(@"/c wmic product get name,version");
                }
                else
                {
                    response = wmicCall(@"/c wmic /node:bh134_4889 /user:bh134_4889\" + txtUsername.Text + " /password:" + txtPassword.Text + " product get name");
                }
                sw.Stop();
            }

            filterResponse(response);

            MessageBox.Show("Finished in " + sw.Elapsed +" seconds");
        }

        private void filterResponse(string response)
        {
            string data;
            string [] lines = response.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            data = lines[0];
            
            Array.Sort<string>(lines);
            System.IO.File.WriteAllText(@"C:\Users\Telecom\Desktop\ProgramSeeker.txt", "Logged at " + DateTime.Now.TimeOfDay);
            System.IO.File.AppendAllLines(@"C:\Users\Telecom\Desktop\ProgramSeeker.txt", lines);
        }

        // Calls the WMIC command and returns the output
        private string wmicCall(string args)
        {
            string val = "";

            ProcessStartInfo psi = new ProcessStartInfo("cmd", args)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
            };

            Process reg = new Process();
            reg.StartInfo = psi;

            reg.Start();
            using (System.IO.StreamReader output = reg.StandardOutput)
            {
                val += output.ReadToEnd();
            }

            return val;
        }

        // Import remote nodes
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listNodes.Items.Add(txtSingleNode.Text.Trim());
            txtSingleNode.Text = "";
        }

        
        private void txtSingleNode_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(txtSingleNode.Text);
        }

        // Trap mouse-up events for context menu
        private void listNodes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.listNodes.IndexFromPoint(e.Location);
                listNodes.ClearSelected();
                if (index != ListBox.NoMatches)
                {
                    listNodes.SelectedIndex = index;
                    contextStripNodes.Show(listNodes, e.Location);
                }
            }
        }

        // Context menu for removing item from list of nodes to scan
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listNodes.Items.RemoveAt(listNodes.SelectedIndex);
        }
    }
}
