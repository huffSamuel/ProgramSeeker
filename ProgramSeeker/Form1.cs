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
        private System.ComponentModel.BackgroundWorker backWorker = new System.ComponentModel.BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
            InitializeWorker();
            txtPassword.PasswordChar = '*';
            //btnStart.Enabled = false;
            btnAdd.Enabled = false;
            chkProdVer.Enabled = false;
            progressScan.Style = ProgressBarStyle.Marquee;
            progressScan.MarqueeAnimationSpeed = 0;
            progressScan.Maximum = 20;
            progressScan.Step = 1;
        }

        /// <summary>
        /// Initializes the background worker for running our WMIC process
        /// ToDo: Potentially switch to using the Task parallel library instead of BackgroundWorker
        /// </summary>
        private void InitializeWorker()
        {
            backWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backWorker_DoWork);
            backWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backWorker_Completed);
        }

        /// <summary>
        /// Triggers the WMIC process on a BackgroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            WMIC wmic = (WMIC)e.Argument;
            e.Result = getSoftware(wmic);
        }

        /// <summary>
        /// Called when the WMIC process returns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backWorker_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //progressScan.PerformStep();
            TreeNode t = (TreeNode)e.Result;
            AddNode(t);
            progressScan.MarqueeAnimationSpeed = 0;
        }

        /// <summary>
        /// Selects a folder for file output
        /// Note: Will become obselete after Excel Export is integrated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Depricated. Remains to prevent current refactor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateOptions(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }

        /// <summary>
        /// Enables and disables the product version checkbox based on product name checkbox status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chkProdVer.Enabled = chkProdName.Checked;
        }

        /// <summary>
        /// Runs the actual WMIC query.
        /// ToDo: Update so it runs on all available nodes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            progressScan.MarqueeAnimationSpeed = 20;

            WMIC wmic = new WMIC(listNodes.Items[0].ToString(), txtUsername.Text, txtPassword.Text, true);
            if(!backWorker.IsBusy)
                backWorker.RunWorkerAsync(wmic);
        }

        /// <summary>
        /// Gets a list of software from the target node.
        /// ToDo: Configure for adaptable WMIC calls rather than hard coded.
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private TreeNode getSoftware(WMIC wmic)
        {
            TreeNode softNode = new TreeNode("Software");
            TreeNode node;
            string response = "";

            response = wmicCall(wmic.createSoftwareQuery(chkProdVer.Checked));
            
            foreach (string l in filterResponse(response))
            {
                if (!string.IsNullOrEmpty(l.Trim()))
                {
                    TreeNode n = new TreeNode(l.Substring(0, l.LastIndexOf(" ")));
                    n.Nodes.Add("Version: " + l.Substring(l.LastIndexOf(" ")));
                    softNode.Nodes.Add(n);

                    AddToSoftware(l);
                }
            }

            node = new TreeNode(wmic.getName());
            node.Nodes.Add(softNode);
            return node;
        }

        /// <summary>
        /// Adds a software node to the tree of all software.
        /// </summary>
        /// <param name="software"></param>
        private void AddToSoftware(string software)
        {
            bool found = false;
            foreach(TreeNode n in treeSoftware.Nodes)
            {
                if((string)n.Tag == software)
                {
                    found = true;
                    // If the node is found update the node's count
                    UpdateNodeText(n);
                }
            }

            //If the node is not found add it
            if(!found)
            {
                TreeNode node = new TreeNode(software) { Tag = software };
                node.Nodes.Add(new TreeNode("Count: 1") { Tag = "Count" });
                AddSoftwareNode(node);
            }
        }

        /// <summary>
        /// Filters the response from the WMIC call to remove extra whitespace
        /// ToDo: Adapt to using a class to contain information (ISoftware, INode, IBios, etc)
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string[] filterResponse(string response)
        { 
            string temp;
            int offset = 0;
            string [] lines = response.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string l in lines)
            {
                temp = l.Trim();
                if (!string.IsNullOrEmpty(temp))
                {
                    string name = temp.Substring(0, temp.LastIndexOf(" ")).Trim() + " ";
                    string version = temp.Substring(temp.LastIndexOf(" ")).Trim();
                    lines[offset] = name + "\t\t" + version;

                    offset++;
                }
            }

            Array.Sort(lines);

            return lines;
        }

        /// <summary>
        /// Executes the WMIC call on a new process and captures the output.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>String of output text from the process</returns>
        private string wmicCall(string args)
        {
            string val = "";

            ProcessStartInfo psi = new ProcessStartInfo("cmd", args)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true
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

        /// <summary>
        /// Imports nodes from a text file. Regex removes data from an SCCM copy+pase txt file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Manually adds a node to the node list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            listNodes.Items.Add(txtSingleNode.Text.Trim());
            txtSingleNode.Text = "";
        }

        /// <summary>
        /// Enables the addNode button if the addNode textbox is not empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSingleNode_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(txtSingleNode.Text);
        }

        /// <summary>
        /// Traps mouse events in the listNodes treeview to display the remove context menu for nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handler for the context menu remove option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listNodes.Items.RemoveAt(listNodes.SelectedIndex);
        }
        /// <summary>
        /// Delegate for UpdateNodeText
        /// </summary>
        /// <param name="node"></param>
        delegate void UpdateNodeTextCallback(TreeNode node);

        /// <summary>
        /// Delegate for AddSoftwareNode
        /// </summary>
        /// <param name="node"></param>
        delegate void AddSoftwareNodeCallback(TreeNode node);

        /// <summary>
        /// Delegate for AddNode
        /// </summary>
        /// <param name="node"></param>
        delegate void AddNodeCallback(TreeNode node);

        /// <summary>
        /// Adds a node to treeNodes
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(TreeNode node)
        {
            if (this.treeNodes.InvokeRequired)
            {
                AddNodeCallback c = new AddNodeCallback(AddNode);
                this.Invoke(c, new object[] { node });
            }
            else
                this.treeNodes.Nodes.Add(node);
        }

        /// <summary>
        /// Adds a node to treeSoftware
        /// </summary>
        /// <param name="node"></param>
        public void AddSoftwareNode(TreeNode node)
        {
            if (this.treeSoftware.InvokeRequired)
            {
                AddSoftwareNodeCallback c = new AddSoftwareNodeCallback(AddSoftwareNode);
                this.Invoke(c, new object[] { node });
            }
            else
                this.treeSoftware.Nodes.Add(node);
        }

        /// <summary>
        /// Updates the text of a node in treeSoftware
        /// </summary>
        /// <param name="node"></param>
        public void UpdateNodeText(TreeNode node)
        {
            if(this.treeSoftware.InvokeRequired)
            {
                UpdateNodeTextCallback c = new UpdateNodeTextCallback(UpdateNodeText);
                this.Invoke(c, new object[] { node });
            }
            else
            {
                TreeNode n = this.treeSoftware.Nodes[this.treeSoftware.Nodes.IndexOf(node)];
                foreach (TreeNode child in n.Nodes)
                {
                    if ((string)child.Tag == "Count")
                    {
                        child.Text = child.Text.Substring(0, child.Text.LastIndexOf(":") + 1) + (Int32.Parse(child.Text.Substring(child.Text.LastIndexOf(":") + 1)) + 1).ToString();
                        break;
                    }
                }
            }
        }
    }
}
