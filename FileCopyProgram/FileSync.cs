using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCopyProgram
{
    class FileSync
    {

        private static System.Windows.Forms.TreeView _unsynchronizedTree = null;

        /// <summary>
        /// tree item of unsynchronized items
        /// </summary>
        public static System.Windows.Forms.TreeView UnsynchronizedTree
        {
            set
            {
                if (value == null)
                    return;
                _unsynchronizedTree = new System.Windows.Forms.TreeView();

                foreach (System.Windows.Forms.TreeNode dNode in value.Nodes)
                {
                    if (dNode.Nodes != null)
                    {
                        _unsynchronizedTree.Nodes.Add((System.Windows.Forms.TreeNode)dNode.Clone());
                    }
                }
            }
        }

        /// <summary>
        /// check if given item is new to the saved file
        /// </summary>
        /// <param name="pathToSync"></param>
        /// <param name="checkItem"></param>
        /// <returns></returns>
        public static bool IsNewItem(string pathToSync, ref bool checkItem)
        {
            if (pathToSync == null)
            {
                checkItem = false;
                return false;
            }

            if (_unsynchronizedTree == null || _unsynchronizedTree.Nodes == null)
            {
                checkItem = false;
                return false;
            }
            
            System.IO.DirectoryInfo dInfo = null;

            foreach (System.Windows.Forms.TreeNode dNode in _unsynchronizedTree.Nodes)
            {
                dInfo = (System.IO.DirectoryInfo)dNode.Tag;
                checkItem = dNode.Checked;
                if (string.Compare(pathToSync, dInfo.FullName, true) == 0)
                    return false;
            }

            //item does not exist in tree, sync it up
            checkItem = false;
            return true;
        }

        /// <summary>
        /// override: check if given item is new to the saved file
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="fileToSync"></param>
        /// <param name="checkItem"></param>
        /// <returns></returns>
        public static bool IsNewItem(string directoryPath, string fileToSync, ref bool checkItem)
        {
            if (directoryPath == null)
            {
                checkItem = false;
                return false;
            }

            //find directory node from unsynchronized tree
            System.Windows.Forms.TreeNode dNode = currentDirectoryNode(directoryPath);
            if (dNode == null)
            {
                checkItem = false;
                return true;   //couldn't find the directory - default true
            }

            System.IO.FileInfo fInfo = null;

            foreach (System.Windows.Forms.TreeNode fNode in dNode.Nodes)
            {
                fInfo = (System.IO.FileInfo)fNode.Tag;
                checkItem = fNode.Checked;
                if (string.Compare(fileToSync, fInfo.FullName, true) == 0)
                    return false;
            }
            checkItem = false;
            return true;
        }

        /// <summary>
        /// return the current directory node from the tree
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        private static System.Windows.Forms.TreeNode currentDirectoryNode(string directoryPath)
        {
            if (_unsynchronizedTree == null || _unsynchronizedTree.Nodes.Count <= 0)
                return null;

            foreach (System.Windows.Forms.TreeNode dNode in _unsynchronizedTree.Nodes)
            {
                if (string.Compare(directoryPath, dNode.FullPath, true) == 0)
                    return dNode;
            }
            return null;
        }
    }
}
