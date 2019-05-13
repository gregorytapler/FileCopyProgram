using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace FileCopyProgram
{
    class FileCopy
    {
        //variable declarations
        public static bool abortCopy = false;
        private static ArrayList al_copyresults;
        private static string baseDirectory = string.Empty;

        //methods

        /// <summary>
        /// start the file copy procedure
        /// </summary>
        /// <param name="fileTree"></param>
        public static void Start(ref System.Windows.Forms.TreeView fileTree)
        {
            DateTime dtNow;
            TimeSpan span;
            string copymsg = string.Empty;
            Common.CopyResult result;
            al_copyresults = new ArrayList();

            System.Windows.Forms.TreeNode dirnode;
            System.Windows.Forms.TreeNode filenode;

            //define base directory with first item in tree
            baseDirectory = fileTree.Nodes[0].FullPath;
            
            //enumerate the tree
            for (int i = 0; i < fileTree.Nodes.Count; i++)
            {
                dirnode = fileTree.Nodes[i];

                //abort if operations cancelled
                if (abortCopy)
                    return;

                //only copy fileinfo type
                if (dirnode.Tag.GetType() == typeof(DirectoryInfo))
                    for (int j = 0; j < dirnode.Nodes.Count; j++)
                    {
                        //get the fileinfo object
                        filenode = dirnode.Nodes[j];
                        //perform copy 
                        result = DoCopy((FileInfo)filenode.Tag, ref copymsg);
                        //add result to array list for reporting
                        al_copyresults.Add(result);

                        //set the node back color and tag
                        filenode.ForeColor = Common.CopyResultColor(result);
                        copymsg = Common.CopyResultToString(result);

                        //set the text of the node (invoke needed for thread safety)
                        if (result != Common.CopyResult.copygood)
                        {
                            string ndText = filenode.Text + "  [" + copymsg + "]";
                            Main.SetTextCallback d = new Main.SetTextCallback(Main.SetNodeText);
                            fileTree.Invoke
                                (d, new object[] { filenode, ndText });

                        }

                        copymsg = string.Empty;
                        //set display values
                        dtNow = DateTime.Now;
                        span = dtNow.Subtract(Common.startCopy);

                        Common.ProgressBarValue++;
                        Common.Status2Text = Common.Counter_FilesCopied.ToString() + " of " + Common.Counter_FilesToCopy.ToString() + " files copied.";
                        Common.Status3Text = "Elapsed time: " + FormatTimeSpan(span, false);
                    }
            }

            Common.isCopying = false;
        }

        /// <summary>
        /// perform the copy
        /// </summary>
        /// <param name="fileInfoItem"></param>
        /// <param name="emsg"></param>
        /// <returns></returns>
        private static Common.CopyResult DoCopy(FileInfo fileInfoItem, ref string emsg)
        {
            //replace root of base directory with target folder
            string targetFPNE = fileInfoItem.FullName.Replace(fileInfoItem.Directory.Root.Name,Common.TargetFolder);
            
            //if source file not found, return
            if (!fileInfoItem.Exists)
                return Common.CopyResult.sourcedoesnotexists;

            try
            {
                //validate target folder
                if (targetFPNE.Length > 255)
                    throw new Exception("Target Path Over 255 characters.");

                //if no overwrite, and target exists, return
                if (Common.copyOptions == Common.CopyOption.nooverwrite)
                {
                    if (File.Exists(targetFPNE))
                        return Common.CopyResult.targetexists;
                    else
                    {
                        if(!Directory.Exists(Path.GetDirectoryName(targetFPNE)))
                            Directory.CreateDirectory(Path.GetDirectoryName(targetFPNE));

                        File.Copy(fileInfoItem.FullName, targetFPNE);
                        Common.Counter_FilesCopied++;
                        return Common.CopyResult.copygood;
                    }
                }
                else if (Common.copyOptions == Common.CopyOption.overwriteifnewer)
                {
                    //first check of target file exists
                    if (File.Exists(targetFPNE))
                    {
                        //file exists, compare dates
                        FileInfo targetInfo = new FileInfo(targetFPNE);
                        //DateTime.Compare() - <0: t1 earlier than t2 - =0: same - >0: t1 later than t2
                        if (DateTime.Compare(targetInfo.LastWriteTime, fileInfoItem.LastWriteTime) < 0)
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(targetFPNE)))
                                Directory.CreateDirectory(Path.GetDirectoryName(targetFPNE));

                            File.Copy(fileInfoItem.FullName, targetFPNE, true);
                            Common.Counter_FilesCopied++;
                            return Common.CopyResult.copygood;
                        }
                        else if (DateTime.Compare(targetInfo.LastWriteTime, fileInfoItem.LastWriteTime) > 0)
                            return Common.CopyResult.targetisnewer;
                        else
                            return Common.CopyResult.samedate;
                    }
                    else
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(targetFPNE)))
                            Directory.CreateDirectory(Path.GetDirectoryName(targetFPNE));

                        File.Copy(fileInfoItem.FullName, targetFPNE);
                        Common.Counter_FilesCopied++;
                        return Common.CopyResult.copygood;
                    }

                }
                else if (Common.copyOptions == Common.CopyOption.overwriteall)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(targetFPNE)))
                        Directory.CreateDirectory(Path.GetDirectoryName(targetFPNE));

                    File.Copy(fileInfoItem.FullName, targetFPNE, true);
                    Common.Counter_FilesCopied++;
                    return Common.CopyResult.copygood;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                emsg = ex.Message;
                return Common.CopyResult.copyfail;
            }
            emsg = "Copy condition not met";
            return Common.CopyResult.copyfail;
        }

        /// <summary>
        /// format the time
        /// </summary>
        /// <param name="span"></param>
        /// <param name="showSign"></param>
        /// <returns></returns>
        private static string FormatTimeSpan(TimeSpan span, bool showSign)
        {
            string sign = String.Empty;
            if (showSign && (span > TimeSpan.Zero))
                sign = "+";

            return span.Hours.ToString("00") + ":" +
                   span.Minutes.ToString("00") + ":" +
                   span.Seconds.ToString("00");
        }

    }
}
