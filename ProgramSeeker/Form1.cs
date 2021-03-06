﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Management;

namespace ProgramSeeker
{
    public partial class Form1 : Form
    {
        private int running;
        private string folderName;
        private System.ComponentModel.BackgroundWorker backWorker = new System.ComponentModel.BackgroundWorker();
        TreeNode lastSelectedNode;

        enum Query { software = 0, serial, model };

        public Form1()
        {
            InitializeComponent();
            InitializeWorker();
            txtPassword.PasswordChar = '*';
            btnAdd.Enabled = false;
            chkProdName.Checked = true;     // Get product by default
            progressScan.Style = ProgressBarStyle.Marquee;
            progressScan.MarqueeAnimationSpeed = 0;
            ReadFromFile();
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
            AddNode((TreeNode)e.Argument);
        }

        /// <summary>
        /// Called when the WMIC process returns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backWorker_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Interlocked.Decrement(ref running);
            if (running == 0)
            {
                WriteToFile();
                ResetProgress();
            }
        }

        /// <summary>
        /// Selects a folder for file output
        /// Note: Will become obselete after Excel Export is integrated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog() { ShowNewFolderButton = true, RootFolder = Environment.SpecialFolder.Personal };

            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
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
        /// ToDo: Update to divide nodes into chunks. Have a task run on multiple WMIC instances
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            /* Update GUI */
            progressScan.Style = ProgressBarStyle.Marquee;
            progressScan.MarqueeAnimationSpeed = 20;

            /* Save info from GUI */
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            bool product = chkProdName.Checked;
            bool version = chkProdVer.Checked;
            bool serial = chkSerialNum.Checked;
            bool model = chkModelName.Checked;

            /* Set up task lists */
            List<List<string>> ParentList = new List<List<string>>();
            int count;
            for (count = 0; count < 10; ++count)
                ParentList.Add(new List<String>());

            count = 0;
            foreach (string s in listTargets.Items)
            {
                ParentList[count % 10].Add(s);
                count++;
            }

            foreach (List<string> list in ParentList)
            {
                Interlocked.Increment(ref running);
                Task.Run(() =>
                    {
                        foreach (string s in list)
                        {
                            TreeNode node = null;
                            WMIC wmic = new WMIC(s, userName, password, version, serial, model);
                            if (product)
                                node = getSoftware(wmic);

                            if (serial)
                                node.Nodes.Add(getSerial(wmic));

                            if (model)
                                node.Nodes.Add(getModel(wmic));

                            if (node.GetNodeCount(true) < 4)
                                AddFailedNode(node);
                            else
                                AddNode(node);
                        }
                        Interlocked.Decrement(ref running);
                        if (running == 0)
                        {
                            ResetProgress(); 
                            WriteToFile();
                        }
                    });
            }
        }

        // Change this so it only gets software and adds it to a node
        /// <summary>
        /// Gets a list of software from the target node.
        /// ToDo: Configure for adaptable WMIC calls rather than hard coded.
        /// ToDo: Edit Node names
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private TreeNode getSoftware(WMIC wmic)
        {
            TreeNode softNode = new TreeNode();
            softNode.Name = "Software";
            softNode.Text = "Software";
            TreeNode node;
            string response = "";
            string dupResponse;


            response = wmicCall(wmic.createQuery((int)Query.software));
            dupResponse = response;
            foreach (string l in filterResponse(response, wmic.Version))
            {
                if (!string.IsNullOrEmpty(l.Trim()))
                {
                    TreeNode version = new TreeNode();
                    TreeNode n = new TreeNode();
                    n.Name = l.Substring(0, l.LastIndexOf(" ")).Replace(' ', '.');
                    n.Text = l.Substring(0, l.LastIndexOf(" "));
                    if (wmic.Version)
                    {
                        version.Name = "Version";
                        version.Text = "Version: " + l.Substring(l.LastIndexOf(" "));
                        n.Nodes.Add(version);
                    }
                    softNode.Nodes.Add(n);

                    AddToSoftware(l);
                }
            }

            node = new TreeNode();
            node.Text = wmic.Name;
            node.Name = wmic.Name;
            if (softNode.GetNodeCount(true) > 1)
                node.Nodes.Add(softNode);
            return node;
        }

        private TreeNode getSerial(WMIC wmic)
        {
            TreeNode serial = new TreeNode();
            string response = wmicCall(wmic.createQuery((int)Query.serial));
            serial.Name = "SerialNO";
            serial.Text = "Serial Number: " + response.Replace("SerialNumber", "").Trim();
            serial.Tag = response;
            return serial;
        }

        private TreeNode getModel(WMIC wmic)
        {
            TreeNode model = new TreeNode();
            string response = wmicCall(wmic.createQuery((int)Query.model));
            model.Name = "Model";
            model.Text = response.Replace("Name", "").Trim();
            return model;
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
        private string[] filterResponse(string response, bool getVersion)
        { 
            string temp;
            int offset = 0;
            string [] lines = response.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string l in lines)
            {
                temp = l.Trim();
                if (!string.IsNullOrEmpty(temp))
                {
                    string name = temp.Substring(0, (getVersion? temp.LastIndexOf(" ") : temp.Length)).Trim() + " ";
                    string version = "";
                    if(getVersion) version = temp.Substring(temp.LastIndexOf(" ")).Trim();
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

            Process reg = new Process() { StartInfo = psi };

            reg.Start();
            using (System.IO.StreamReader output = reg.StandardOutput)
                val += output.ReadToEnd();

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
                    listTargets.Items.Add(line);
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
            listTargets.Items.Add(txtSingleNode.Text.Trim());
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
        /// Handler for the context menu remove option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listTargets.Items.RemoveAt(listTargets.SelectedIndex);
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

        delegate void AddFailedNodeCallback(TreeNode node);
        delegate void RemoveFailedNodeCallback(TreeNode node);

        /// <summary>
        /// 
        /// </summary>
        delegate void ResetProgressCallback();

        /// <summary>
        /// 
        /// </summary>
        public void ResetProgress()
        {
            if (this.progressScan.InvokeRequired)
            {
                ResetProgressCallback c = new ResetProgressCallback(ResetProgress);
                this.Invoke(c, new object[] {  });
            }
            else
            {
                this.progressScan.MarqueeAnimationSpeed = 0;
                this.progressScan.Style = ProgressBarStyle.Blocks;
                this.progressScan.Value = 0;
            }
        }

        /// <summary>
        /// Adds a node to treeNodes
        /// If duplicate nodes exist already than the node with more children is kept.
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
            {
                if (this.treeNodes.Nodes.ContainsKey(node.Name)) 
                    this.treeNodes.Nodes.RemoveByKey(node.Name);
                RemoveFailed(node);
                    
                this.treeNodes.Nodes.Add(node);
            }
        }

        public void RemoveFailed(TreeNode node)
        {
            if (this.treeFailed.InvokeRequired)
            {
                RemoveFailedNodeCallback c = new RemoveFailedNodeCallback(RemoveFailed);
                this.Invoke(c, new object[] { node });
            }
            else
            {
                if (this.treeFailed.Nodes.ContainsKey(node.Name))
                    this.treeFailed.Nodes.RemoveByKey(node.Name);
            }
        }

        public void AddFailedNode(TreeNode node)
        {
            if (this.treeFailed.InvokeRequired)
            {
                AddFailedNodeCallback c = new AddFailedNodeCallback(AddFailedNode);
                this.Invoke(c, new object[] { node });
            }
            else
            {
                if (this.treeFailed.Nodes.ContainsKey(node.Name))
                    this.treeFailed.Nodes.RemoveByKey(node.Name);

                this.treeFailed.Nodes.Add(node);
            }
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

        private void treeNodes_MouseUp(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lastSelectedNode = treeNodes.SelectedNode;
                contextStripResults.Show(treeNodes, e.Location); 
            }
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
                int index = this.listTargets.IndexFromPoint(e.Location);
                listTargets.ClearSelected();
                if (index != ListBox.NoMatches)
                {
                    listTargets.SelectedIndex = index;
                    contextStripNodes.Show(listTargets, e.Location);
                }
            }
        }

        /// <summary>
        /// Removes a node from the list of node results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            treeNodes.Nodes.Remove(this.treeNodes.SelectedNode);
            WriteToFile();
        }

        /// <summary>
        /// Enter key trap for add node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSingleNode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                listTargets.Items.Add(txtSingleNode.Text.Trim());
                txtSingleNode.Text = "";
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            bool product = chkProdName.Checked;
            bool version = chkProdVer.Checked;
            bool serial = chkSerialNum.Checked;
            bool model = chkModelName.Checked;
            
            Interlocked.Increment(ref running);
            Task.Run(() =>
            {
                TreeNode node;
                node = getSoftware(new WMIC(lastSelectedNode.Text, userName, password, version, serial, model));
                while (backWorker.IsBusy) ;
                backWorker.RunWorkerAsync(node);
            });
        }

        private void WriteToFile()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            folder = Path.Combine( folder, "ProgramSeeker");
            string path = folder + @"\responses.dat";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using(Stream file = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
               
                bf.Serialize(file, treeNodes.Nodes.Cast<TreeNode>().ToList());
            }

            path = folder + @"\failed.dat";
            using(Stream file = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, treeFailed.Nodes.Cast<TreeNode>().ToList());
            }

            path = folder + @"\software.dat";
            using(Stream file = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, treeSoftware.Nodes.Cast<TreeNode>().ToList());
            }
            
        }

        private void ReadFromFile()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            folder = Path.Combine( folder, "ProgramSeeker");
            string path = folder + @"\responses.dat";
            if(File.Exists(path))
            {
                using(Stream file = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(file);

                    TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                    treeNodes.Nodes.AddRange(nodeList);
                }
            }

            path = folder + @"\failed.dat";
            if (File.Exists(path))
            {
                using (Stream file = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(file);

                    TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                    treeFailed.Nodes.AddRange(nodeList);
                }
            }

            path = folder + @"\software.dat";
            if (File.Exists(path))
            {
                using (Stream file = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(file);

                    TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                    treeSoftware.Nodes.AddRange(nodeList);
                }
            }
        }

        private void ExcelExport()
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;
                oWB = oXL.Workbooks.Add("");
                oSheet = oWB.ActiveSheet;

                int x = 1;
                int y = 2;

                oSheet.Cells[1, 1] = "Computer Name";
                oSheet.Cells[1, 2] = "Computer Model";
                oSheet.Cells[1, 3] = "Serial Number";
                oSheet.Cells[1, 4] = "Software";

                foreach (TreeNode t in treeNodes.Nodes)
                {
                    oSheet.Cells[y, x++] = t.Text;
                    oSheet.Cells[y, x++] = t.Nodes[2].Text;
                    oSheet.Cells[y, x++] = t.Nodes[1].Tag;
                    foreach (TreeNode a in t.Nodes[0].Nodes)
                        oSheet.Cells[y, x++] = a.Text;
                    ++y;
                    x = 1;
                }
            }
            catch (Exception x) { }
        }

        private void clearOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeNodes.Nodes.Clear();
            treeSoftware.Nodes.Clear();
            WriteToFile();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }

        private void treeFailed_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextFailed.Show(treeFailed, e.Location);
            }
        }

        private void reScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (running > 0);


            /* Update GUI */
            progressScan.Style = ProgressBarStyle.Marquee;
            progressScan.MarqueeAnimationSpeed = 20;

            /* Save info from GUI */
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            bool product = chkProdName.Checked;
            bool version = chkProdVer.Checked;
            bool serial = chkSerialNum.Checked;
            bool model = chkModelName.Checked;

            /* Set up task lists */
            List<List<string>> ParentList = new List<List<string>>();
            int count;
            for (count = 0; count < 10; ++count)
                ParentList.Add(new List<String>());

            count = 0;
            foreach (TreeNode t in treeFailed.Nodes)
            {
                ParentList[count % 10].Add(t.Text);
                count++;
            }

            foreach (List<string> list in ParentList)
            {
                Interlocked.Increment(ref running);
                Task.Run(() =>
                {
                    foreach (string s in list)
                    {
                        TreeNode node = null;
                        WMIC wmic = new WMIC(s, userName, password, version, serial, model);
                        if (product)
                            node = getSoftware(wmic);

                        if (serial)
                            node.Nodes.Add(getSerial(wmic));

                        if (model)
                            node.Nodes.Add(getModel(wmic));

                        if (node.GetNodeCount(true) < 4)
                            AddFailedNode(node);
                        else
                            AddNode(node);
                    }
                    Interlocked.Decrement(ref running);
                    if (running == 0)
                    {
                        ResetProgress();
                    }
                });
            }
        }
    }
}
