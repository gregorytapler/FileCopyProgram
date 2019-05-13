using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace FileCopyProgram
{
    public partial class Main : Form
    {

        //variable declarations
        bool ehandled = false;
        //delegate needed for thread safety of node text value set in FileCopy
        public delegate void SetTextCallback(TreeNode nd, string text);

        public Main()
        {
            InitializeComponent();
        }

        private void cmdDirSelect_Click(object sender, EventArgs e)
        {
            //browse out to directory to copy
            FolderBrowserDialog dirDlg = new FolderBrowserDialog();
            dirDlg.Description = "Select The Root Folder";
            if (dirDlg.ShowDialog() == DialogResult.OK)
            {
                //don't include slash
                Common.RootFolder = dirDlg.SelectedPath + @"\";
                stBar.Panels[0].Text = "Examining folder...";
                //extractDirectoryInfo();
                BuildDirTree(Common.RootFolder, false);
                stBar.Panels[1].Text = Common.Counter_FilesLoaded + " files loaded.";
                GoReadyState("Ready.");
            }
            else
            {
                GoReadyState("Action Cancelled.");
            }
        }

        private void GoReadyState(string panel0Text)
        {
            Common.ProgressBarMax = 0;
            Common.ProgressBarValue = 0;
            progress.Maximum = Common.ProgressBarMax;
            progress.Value = Common.ProgressBarValue;

            setEmptyTreeDisplay();
            setAppendCheckboxEnabled();
            setExpandCheckboxEnabled();
            setFileSaveMenuEnabled();
            setCheckAllEnabled();
            setSyncButtonEnabled();
            stBar.Panels[0].Text = panel0Text;
        }

        public void BuildDirTree(string rootDirectory)
        {
            TreeNode tndir = null;
            TreeNode tnfil = null;
            int fileCount = 0;
            int idx = 0;

            DirectoryInfo dInfo = new DirectoryInfo(rootDirectory);

            //get the progress bar max value and set
            int pBarMax = dInfo.GetFiles("*.*", SearchOption.AllDirectories).Count();
            Common.ProgressBarMax = pBarMax;
            progress.Maximum = Common.ProgressBarMax;

            // Store a stack of our directories.
            ArrayList stack = new ArrayList();

            // Add initial directory.
            stack.Add(rootDirectory);

            //clear tree if append not checked
            if (!chkAppend.Checked)
            {
                if (treeDirectory != null && treeDirectory.Nodes.Count > 0)
                    treeDirectory.Nodes.Clear();

                Common.BytesToCopy = 0;
            }

            // Continue while there are directories to process
            while (stack.Count > 0)
            {
                // Get top directory
                if (idx >= stack.Count)
                    break;

                dInfo = new DirectoryInfo(stack[idx].ToString());
                tndir = new TreeNode();
                tndir.Text = dInfo.FullName;
                //tndir.Tag = "directory";
                tndir.Tag = dInfo;

                try
                {
                    // Add all files at this directory to the result List.
                    foreach (FileInfo fn in dInfo.GetFiles("*.*"))
                    {
                        tnfil = new TreeNode();
                        tnfil.Text = fn.Name;
                        //tnfil.Tag = "file";
                        tnfil.Tag = fn;
                        //add file item to directory item
                        tndir.Nodes.Add(tnfil);
                        fileCount++;
                        Common.Counter_FilesLoaded++;
                        //increment progress bar
                        Common.ProgressBarValue++;
                        progress.Value = Common.ProgressBarValue;
                    }
                    //add directory node to tree
                    if (fileCount > 0)
                        treeDirectory.Nodes.Add(tndir);

                    //reset file counter
                    fileCount = 0;

                    // Add all directories at this directory.
                    foreach (DirectoryInfo dn in dInfo.GetDirectories())
                    {
                        stack.Add(dn.FullName);
                    }
                    stack.Sort();
                    idx++;
                }
                catch(Exception ex)
                {
                    // Could not open the directory
                    MessageBox.Show("Error in processing: " + ex.Message, "FileCopy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HandleControlsEnable(false);
                    cmdCancel.Text = "Close";
                }
            }
        }

        //use this for testing synchronizing
        public void BuildDirTree(string rootDirectory, bool sync)
        {
            TreeNode tndir = null;
            TreeNode tnfil = null;
            int fileCount = 0;
            int idx = 0;
            bool isDirChecked = false;
            bool isFileChecked = false; 

            if (!Directory.Exists(rootDirectory))
            {
                MessageBox.Show("Root directory missing!", "FileCopy Synchronization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DirectoryInfo dInfo = new DirectoryInfo(rootDirectory);

            //get the progress bar max value and set
            int pBarMax = dInfo.GetFiles("*.*", SearchOption.AllDirectories).Count();
            Common.ProgressBarMax = pBarMax;
            progress.Maximum = Common.ProgressBarMax;

            // Store a stack of our directories.
            ArrayList stack = new ArrayList();

            // Add initial directory.
            stack.Add(rootDirectory);

            //clear tree if append not checked
            if (!chkAppend.Checked)
            {
                if (treeDirectory != null && treeDirectory.Nodes.Count > 0)
                    treeDirectory.Nodes.Clear();

                Common.BytesToCopy = 0;
            }

            // Continue while there are directories to process
            while (stack.Count > 0)
            {
                // Get top directory
                if (idx >= stack.Count)
                    break;

                dInfo = new DirectoryInfo(stack[idx].ToString());
                tndir = new TreeNode();
                tndir.Text = dInfo.FullName;
                //tndir.Tag = "directory";
                tndir.Tag = dInfo;
                if (sync)
                {
                    if (FileSync.IsNewItem(dInfo.FullName, ref isDirChecked))
                        tndir.ForeColor = System.Drawing.Color.DarkCyan;
                }

                try
                {
                    // Add all files at this directory to the result List.
                    foreach (FileInfo fn in dInfo.GetFiles("*.*"))
                    {
                        tnfil = new TreeNode();
                        tnfil.Text = fn.Name;
                        //tnfil.Tag = "file";
                        tnfil.Tag = fn;
                        if (sync)
                        {
                            if (FileSync.IsNewItem(dInfo.FullName, fn.FullName, ref isFileChecked))
                                tnfil.ForeColor = System.Drawing.Color.DarkCyan;
                        }
                        //add file item to directory item
                        tndir.Nodes.Add(tnfil);

                        if (sync)
                        {
                            if (isFileChecked)
                                tnfil.Checked = true;
                        }

                        fileCount++;
                        Common.Counter_FilesLoaded++;
                        //increment progress bar
                        Common.ProgressBarValue++;
                        progress.Value = Common.ProgressBarValue;
                    }
                    //add directory node to tree
                    if (fileCount > 0)
                    {
                        if (sync)
                        {
                            if (isDirChecked)
                                tndir.Checked = true;
                        }
                        treeDirectory.Nodes.Add(tndir);
                    }

                    //reset file counter
                    fileCount = 0;

                    // Add all directories at this directory.
                    foreach (DirectoryInfo dn in dInfo.GetDirectories())
                    {
                        stack.Add(dn.FullName);
                    }
                    stack.Sort();
                    idx++;
                }
                catch (Exception ex)
                {
                    // Could not open the directory
                    MessageBox.Show("Error in processing: " + ex.Message, "FileCopy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HandleControlsEnable(false);
                    cmdCancel.Text = "Close";
                }
            }
        }

        public void BuildDirTree(XMLDirectoryObject[] xmlDirectoryList)
        {
            TreeNode tndir = null;
            TreeNode tnfil = null;
            int fileCount = 0;

            if (xmlDirectoryList == null || xmlDirectoryList.Count() <= 0)
                return;

            string rootDirectory = xmlDirectoryList[0].fullpath;

            Common.RootFolder = rootDirectory;

            DirectoryInfo dInfo = null;
            FileInfo fInfo = null;

            //get the progress bar max value and set
            Common.ProgressBarMax = (int)XMLFileHandler.XMLFileItemCount(xmlDirectoryList);
            progress.Maximum = Common.ProgressBarMax;

            //clear tree if append not checked
            if (!chkAppend.Checked)
            {
                if (treeDirectory != null && treeDirectory.Nodes.Count > 0)
                    treeDirectory.Nodes.Clear();

                Common.BytesToCopy = 0;
            }

            try
            {
                // Add all files at this directory to the result List.
                foreach (XMLDirectoryObject xmlDirectoryItem in xmlDirectoryList)
                {
                    dInfo = new DirectoryInfo(xmlDirectoryItem.fullpath);
                    tndir = new TreeNode();

                    //add directory node to tree
                    treeDirectory.Nodes.Add(tndir);

                    tndir.Text = dInfo.FullName;
                    tndir.Tag = dInfo;
                    tndir.Checked = Convert.ToBoolean(xmlDirectoryItem.ischecked);

                    foreach (XMLFileObject xmlFileItem in xmlDirectoryItem.fileItems)
                    {
                        fInfo = new FileInfo(xmlFileItem.fullpath);
                        tnfil = new TreeNode();
                        //add file item to directory item
                        tndir.Nodes.Add(tnfil);

                        tnfil.Text = fInfo.Name;
                        tnfil.Tag = fInfo;
                        tnfil.Checked = Convert.ToBoolean(xmlFileItem.ischecked);
                        fileCount++;
                        Common.Counter_FilesLoaded++;
                        //increment progress bar
                        Common.ProgressBarValue++;
                        progress.Value = Common.ProgressBarValue;
                    }
                }

                //reset file counter
                fileCount = 0;
            }
            catch (Exception ex)
            {
                // Could not open the directory
                MessageBox.Show("Error in processing: " + ex.Message, "FileCopy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleControlsEnable(false);
                cmdCancel.Text = "Close";
            }
        }

        private void treeDirectory_AfterCheck(object sender, TreeViewEventArgs e)
        {

            //if handled, reset handle and return
            if (ehandled)
            {
                ehandled = false;
                return;
            }

            //if directory node checked, check or uncheck each child node
            if (e.Node.Tag.GetType() == typeof(DirectoryInfo))
            {
                foreach (TreeNode item in e.Node.Nodes)
                    if (item.Checked != e.Node.Checked)
                    {
                        ehandled = true;
                        item.Checked = e.Node.Checked;

                        //handle counter
                        if (e.Node.Checked)
                        {
                            Common.BytesToCopy += ((FileInfo)item.Tag).Length;
                            ValidateRequiredSize();
                            Common.Counter_FilesToCopy++;
                        }
                        else
                        {
                            Common.BytesToCopy -= ((FileInfo)item.Tag).Length;
                            ValidateRequiredSize();
                            Common.Counter_FilesToCopy--;
                        }
                    }
            }
            else if (e.Node.Tag.GetType() == typeof(FileInfo))
            {
                if (e.Node.Checked)
                {
                    Common.BytesToCopy += ((FileInfo)e.Node.Tag).Length;
                    ValidateRequiredSize();
                    Common.Counter_FilesToCopy++;
                }
                else
                {
                    Common.BytesToCopy -= ((FileInfo)e.Node.Tag).Length;
                    ValidateRequiredSize();
                    Common.Counter_FilesToCopy--;
                }

                CheckParent(e.Node.Parent);
            }

            stBar.Panels[2].Text = Common.Counter_FilesToCopy + " file(s) marked for copy.";
            stBar.Panels[2].Text += " - Est. size: " + ConvertBytesToString(Common.BytesToCopy);
        }

        private void CheckParent(TreeNode parentNode)
        {
            ehandled = true;

            foreach (TreeNode chld in parentNode.Nodes)
            {
                //if checked state is true, set parent and return
                if (chld.Checked)
                {
                    parentNode.Checked = true;
                    return;
                }
            }

            //if this point reached, no checked states, force unchecked
            parentNode.Checked = false;
        }

        private void setEmptyTreeDisplay()
        {
            if (treeDirectory == null || treeDirectory.Nodes.Count == 0)
                lblEmptyTree.Visible = true;
            else
                lblEmptyTree.Visible = false;
        }

        private void setFileSaveMenuEnabled()
        {
            if (XMLFileHandler.xmlFileLoaded)
                saveToolStripMenuItem.Enabled = true;
            else
                if (treeDirectory != null && treeDirectory.Nodes.Count > 0)
                    saveToolStripMenuItem.Enabled = true;
                else
                    saveToolStripMenuItem.Enabled = false;
        }
        
        private void setAppendCheckboxEnabled()
        {
            if (treeDirectory == null || treeDirectory.Nodes.Count == 0)
                chkAppend.Enabled = false;
            else
                chkAppend.Enabled = true;
        }

        private void setSyncButtonEnabled()
        {
            if (XMLFileHandler.xmlFileLoaded)
                cmdSync.Enabled = true;
            else
                cmdSync.Enabled = false;
        }

        private void setExpandCheckboxEnabled()
        {
            if (treeDirectory == null || treeDirectory.Nodes.Count == 0)
                chkExpandAll.Enabled = false;
            else
                chkExpandAll.Enabled = true;
        }

        private void setCheckAllEnabled()
        {
            if (treeDirectory == null || treeDirectory.Nodes.Count == 0)
                chkAll.Enabled = false;
            else
                chkAll.Enabled = true;
        }

        private void cmdTargetSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dirDlg = new FolderBrowserDialog();
            dirDlg.Description = "Select The Root Folder";
            if (dirDlg.ShowDialog() == DialogResult.OK)
            {
                Common.TargetFolder = dirDlg.SelectedPath;
                txtTargetDir.Text = Common.TargetFolder;
                if (!Common.TargetFolder.EndsWith("\\"))
                    Common.TargetFolder += "\\";

                CalculateRequiredSize();
                ValidateRequiredSize();
            }
            else
            {
                stBar.Panels[0].Text = "Action Cancelled.";
            }

            stBar.Panels[0].Text = "Ready.";
        }

        private void CalculateRequiredSize()
        {
            DirectoryInfo dInfo = new DirectoryInfo(Common.TargetFolder);
            long spaceAvail = SystemDrives.AvailableSpace(dInfo.Root.ToString());
            Common.BytesAvailable = spaceAvail;
            if (Common.BytesAvailable < 0)
                lblAvailableSpace.Text = "* Est. Available space: N/A - Ensure the network drive is mapped.";
            else
                lblAvailableSpace.Text = "* Est. Available space: " + ConvertBytesToString(spaceAvail);
        }

        private void ValidateRequiredSize()
        {
            if (Common.BytesAvailable < Common.BytesToCopy)
                lblAvailableSpace.ForeColor = Color.Red;
            else
                lblAvailableSpace.ForeColor = Color.Black;
        }

        private void chkOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOverwrite.Checked)
            {
                optAllCases.Enabled = true;
                optIncomingNewer.Enabled = true;

                optIncomingNewer.Checked = true;
            }
            else if (!chkOverwrite.Checked)
            {
                optAllCases.Enabled = false;
                optIncomingNewer.Enabled = false;

                optAllCases.Checked = false;
                optIncomingNewer.Checked = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (!Common.isCopying)
                this.Close();
            else if (Common.isCopying)
                FileCopy.abortCopy = true;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (Common.Counter_FilesToCopy <= 0)
            {
                MessageBox.Show("Zero files selected to copy.  Please select file(s) to copy.", "FileCopy Notification", MessageBoxButtons.OK);
                return;
            }
            else if (Common.Counter_FilesToCopy > 0)
            {
                if (Common.TargetFolder == string.Empty)
                {
                    MessageBox.Show("Please select a target directory.", "FileCopy Notification", MessageBoxButtons.OK);
                    return;
                }
                
                Common.isCopying = true;

                //set progress bar values
                Common.ProgressBarMax = Common.Counter_FilesToCopy;
                progress.Maximum = Common.ProgressBarMax;

                //disable controls (except cancel)
                HandleControlsEnable(false);

                //set overwrite variable
                SetOverwriteValue();

                //start the timer
                timer1.Start();
                
                //define and start the thread
                Common.workThread = new System.Threading.Thread(Thread_StartFileCopy);
                Common.workThread.Start();
            }
        }

        private void SetOverwriteValue()
        {
            if (!chkOverwrite.Checked)
                Common.copyOptions = Common.CopyOption.nooverwrite;
            else
                if (optAllCases.Checked)
                    Common.copyOptions = Common.CopyOption.overwriteall;
                else
                    Common.copyOptions = Common.CopyOption.overwriteifnewer;
        }

        //used with delegate to set node text
        public static void SetNodeText(TreeNode nd, string newText)
        {
            nd.Text = newText;
        }

        protected void Thread_StartFileCopy()
        {
            Common.startCopy = DateTime.Now;
            Common.Status1Text = "Copying selected files...";
            FileCopy.Start(ref treeDirectory);
            DateTime end = DateTime.Now;
            Common.isCopying = false;
            if (FileCopy.abortCopy)
            {
                MessageBox.Show("Copy operation cancelled!", "FileCopy Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Common.Status1Text = "Copy Aborted!!!";
                Common.workThread.Abort();
            }
            else
            {
                Common.Status1Text = "Done.";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //set status bar text
            stBar.Panels[0].Text = Common.Status1Text;
            stBar.Panels[1].Text = Common.Status2Text;
            stBar.Panels[2].Text = Common.Status3Text;

            //set progress bar value
            if (Common.ProgressBarValue > progress.Maximum)
                progress.Maximum = Common.ProgressBarValue;

            try
            {
                progress.Value = Common.ProgressBarValue;
            }
            catch
            {
                //handle value > max
            }

            //refresh controls
            stBar.Refresh();
            progress.Refresh();

            //ye ole faithful
            Application.DoEvents();

            //if work thread is complete, set cancel text to close
            if (Common.workThread.ThreadState == System.Threading.ThreadState.Stopped ||
                Common.workThread.ThreadState == System.Threading.ThreadState.Aborted)
            {
                treeDirectory.Enabled = true;
                chkExpandAll.Checked = true;
                cmdCancel.Text = "Close";
                timer1.Stop();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (treeDirectory == null || treeDirectory.Nodes.Count <= 0)
                return;

            bool state = chkAll.Checked; ;
            TreeNode node = null;

            for (int i = 0; i < treeDirectory.Nodes.Count; i++)
            {
                node = treeDirectory.Nodes[i];
                node.Checked = state;
            }

            if (chkAll.Checked)
            {
                chkAll.Text = "Uncheck All";
            }
            else if (!chkAll.Checked)
            {
                state = false;
                chkAll.Text = "Check All";
            }
        }

        private void HandleControlsEnable(bool enableSwitch)
        {
            chkAll.Enabled = enableSwitch;
            chkAppend.Enabled = enableSwitch;
            cmdDirSelect.Enabled = enableSwitch;
            treeDirectory.Enabled = enableSwitch;
            cmdTargetSelect.Enabled = enableSwitch;
            chkOverwrite.Enabled = enableSwitch;
            optAllCases.Enabled = enableSwitch;
            optIncomingNewer.Enabled = enableSwitch;
            cmdOk.Enabled = enableSwitch;
        }

        private string ConvertBytesToString(long estBytes)
        {
            double kb = 0;
            double mb = 0;
            double gb = 0;

            try
            {
                kb = (estBytes / 1024);
                if (kb < 1000)
                    return kb.ToString("###,###,##0.00") + " KB";

                mb = kb / 1024;
                if (mb < 1000)
                    return mb.ToString("###,###,##0.00") + " MB";

                gb = mb / 1024;

                return gb.ToString("###,###,##0.00") + " GB";
            }
            catch
            {
                return "Failed to calculate";
            }
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            if (treeDirectory == null || treeDirectory.Nodes.Count <= 0)
                return;

            if (chkExpandAll.Checked)
            {
                treeDirectory.ExpandAll();
                chkExpandAll.Text = "Collapse All";
            }
            else if (!chkExpandAll.Checked)
            {
                treeDirectory.CollapseAll();
                chkExpandAll.Text = "Expand All";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            //xml file loaded, save existing
            if (XMLFileHandler.xmlFileLoaded)
            {
                DialogResult saveOver = MessageBox.Show("Save current xml file script: " + Path.GetFileName(XMLFileHandler.xmlFPNE) + "?", "FileCopy Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (saveOver == DialogResult.Yes)
                {
                    if (!XMLFileHandler.WriteXMLFile(ref treeDirectory, ref msg))
                    {
                        stBar.Panels[1].Text = msg;
                        GoReadyState("Error in save.");
                    }
                    else
                    {
                        stBar.Panels[1].Text = "Script file saved.";
                        GoReadyState("Ready.");
                    }

                }
                else
                {
                    GoReadyState("Script Save Cancelled.");
                }
            }
            else //xml file not loaded, select file to save
            {
                if (XMLFileHandler.SaveXMLFile())
                {
                    if (!XMLFileHandler.WriteXMLFile(ref treeDirectory, ref msg))
                    {
                        stBar.Panels[1].Text = msg;
                        GoReadyState("Error in save.");
                    }
                    else
                    {
                        stBar.Panels[1].Text = "Script file saved.";
                        GoReadyState("Ready.");
                    }
                }
                else
                {
                    GoReadyState("Script Save Cancelled.");
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            XMLDirectoryObject[] xmlDirList = null;

            if (XMLFileHandler.LoadXMLFile())
            {
                stBar.Panels[0].Text = "Importing script...";
                System.Threading.Thread.Sleep(100);
                this.Refresh();
                System.Threading.Thread.Sleep(10);
                xmlDirList = XMLFileHandler.LoadXMLFile(XMLFileHandler.xmlFPNE, ref msg);
                if (xmlDirList == null || xmlDirList.Count() <= 0)
                    stBar.Panels[1].Text = msg;
                else
                {
                    BuildDirTree(xmlDirList);
                    txtTargetDir.Text = Common.TargetFolder;
                    CalculateRequiredSize();
                    ValidateRequiredSize();
                    stBar.Panels[1].Text = Common.Counter_FilesLoaded + " files loaded.";
                    GoReadyState("Ready.");
                }
            }
            else
            {
                GoReadyState("Action Cancelled.");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sourceDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdDirSelect_Click(sender, e);
        }

        private void copyDestinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdTargetSelect_Click(sender, e);
        }

        private void cmdSync_Click(object sender, EventArgs e)
        {
            stBar.Panels[0].Text = "Synchronizing folders...";
            FileSync.UnsynchronizedTree = treeDirectory;

            BuildDirTree(Common.RootFolder, true);
            stBar.Panels[1].Text = Common.Counter_FilesLoaded + " files loaded.";
            GoReadyState("Ready.");
        }
    }
}
