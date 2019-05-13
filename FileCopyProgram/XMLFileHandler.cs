using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace FileCopyProgram
{
    /// <summary>
    /// handle the xml file methods
    /// </summary>
    public class XMLFileHandler
    {
        private static string _xmlfpne = string.Empty;
        private static bool _xmlfileloaded = false;

        /// <summary>
        /// xml file path information
        /// </summary>
        public static string xmlFPNE
        {
            get
            {
                return _xmlfpne;
            }
        }

        /// <summary>
        /// is xml file loaded into memory
        /// </summary>
        public static bool xmlFileLoaded
        {
            get
            {
                return _xmlfileloaded;
            }
        }

        /// <summary>
        /// method to save the xml file
        /// </summary>
        /// <returns></returns>
        public static bool SaveXMLFile()
        {
            System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
            saveDlg.Filter = "xml files (*.xml)|*.xml";
            saveDlg.FileName = "FileCopyScript" + "_" + DateTime.Now.ToString("MMM_dd_yyyy_H_mm_ss");
            saveDlg.RestoreDirectory = true;
            if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _xmlfpne = saveDlg.FileName;
                _xmlfileloaded = true;
                return true;
            }
            else
            {
                _xmlfpne = string.Empty;
                _xmlfileloaded = false;
                return false;
            }
        }

        /// <summary>
        /// method to load the saved xml file
        /// </summary>
        /// <returns></returns>
        public static bool LoadXMLFile()
        {
            System.Windows.Forms.OpenFileDialog openDlg = new System.Windows.Forms.OpenFileDialog();
            openDlg.Filter = "xml files (*.xml)|*.xml";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _xmlfpne = openDlg.FileName;
                _xmlfileloaded = true;
                return true;
            }
            else
            {
                _xmlfpne = string.Empty;
                _xmlfileloaded = false;
                return false;
            }
        }

        /// <summary>
        /// method to write the xml file to disk
        /// </summary>
        /// <param name="DirectoryTree"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool WriteXMLFile(ref System.Windows.Forms.TreeView DirectoryTree, ref string msg)
        {

            XmlSerializer xmlSerial = null;
            FileStream fs = null;

            try
            {

                if (File.Exists(_xmlfpne))
                    File.Delete(_xmlfpne);

                System.Threading.Thread.Sleep(10);

                fs = new FileStream(_xmlfpne, FileMode.Create);

                System.Windows.Forms.TreeNode dirnode;
                System.Windows.Forms.TreeNode filenode;

                XMLDirectoryObject[] xmlDirList = null;
                XMLFileObject[] xmlFileList = null;
                XMLCopyScript xmlCopyScript = null;

                if (DirectoryTree == null || DirectoryTree.Nodes.Count <= 0)
                {
                    msg = "Empty directory tree.";
                    return false;
                }

                xmlCopyScript = new XMLCopyScript(Common.TargetFolder);
                xmlDirList = new XMLDirectoryObject[DirectoryTree.Nodes.Count];
                //xmlCopyScript.directoryItems = xmlDirList;

                for (int i = 0; i < DirectoryTree.Nodes.Count; i++)
                {
                    dirnode = DirectoryTree.Nodes[i];

                    //build the xml directory object
                    xmlDirList[i] = new XMLDirectoryObject();
                    xmlDirList[i].fullpath = ((DirectoryInfo)dirnode.Tag).FullName;
                    xmlDirList[i].ischecked = Convert.ToInt16(dirnode.Checked);

                    xmlFileList = new XMLFileObject[dirnode.Nodes.Count];

                    //enumerate the file items for the directory
                    for (int j = 0; j < dirnode.Nodes.Count; j++)
                    {
                        filenode = dirnode.Nodes[j];
                        xmlFileList[j] = new XMLFileObject();
                        xmlFileList[j].fullpath = ((FileInfo)filenode.Tag).FullName;
                        xmlFileList[j].ischecked = Convert.ToInt16(dirnode.Checked);
                    }
                    xmlDirList[i].fileItems = xmlFileList;
                }
                xmlCopyScript.directoryItems = xmlDirList;

                System.Type typ = xmlCopyScript.GetType();
                xmlSerial = new XmlSerializer(typ);

                xmlSerial.Serialize(fs, xmlCopyScript);

                return true;
            }
            catch (Exception ex)
            {
                if (fs != null)
                    fs.Close();

                msg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// override: loads the xml file and return the directory object array
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <param name="loadMsg"></param>
        /// <returns></returns>
        public static XMLDirectoryObject[] LoadXMLFile(string xmlFile, ref string loadMsg)
        {

            XmlSerializer xmlSerial = null;
            FileStream fs = null;

            try
            {
                fs = new FileStream(xmlFile, FileMode.Open);
                XMLCopyScript xmlCopyScript = null;
                XMLDirectoryObject[] xmlDirList = null;

                //System.Type typ = xmlDirList.GetType();
                xmlSerial = new XmlSerializer(typeof(XMLCopyScript));
                xmlCopyScript = (XMLCopyScript)xmlSerial.Deserialize(fs);
                Common.TargetFolder = xmlCopyScript.copytopath;
                xmlDirList = (XMLDirectoryObject[])xmlCopyScript.directoryItems;

                fs.Close();

                return xmlDirList;
            }
            catch (Exception ex)
            {
                loadMsg = "Failed: " + ex.Message;
                if (fs != null)
                    fs.Close();
                return null;
            }
        }

        /// <summary>
        /// return the file counts for the given directory object collection
        /// </summary>
        /// <param name="xmlDirectoryList"></param>
        /// <returns></returns>
        public static long XMLFileItemCount(XMLDirectoryObject[] xmlDirectoryList)
        {
            if (xmlDirectoryList == null || xmlDirectoryList.Count() <= 0)
                return 0;

            long fileItemCount = 0;

            for (int i = 0; i < xmlDirectoryList.Count(); i++)
                fileItemCount += xmlDirectoryList[i].fileItems.Count();

            return fileItemCount;
        }
    }
}
