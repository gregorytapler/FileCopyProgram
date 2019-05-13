using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCopyProgram
{
    /// <summary>
    /// class structure of the directory objects for the xml serialization
    /// </summary>
    public class XMLDirectoryObject
    {
        public string fullpath;
        public int ischecked;
        public XMLFileObject[] fileItems;

        public XMLDirectoryObject()
        {
            fullpath = string.Empty;
            ischecked = 0;
            fileItems = null;
        }
    }
}
