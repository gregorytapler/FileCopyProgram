using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCopyProgram
{

    /// <summary>
    /// class structure for the xml serialization
    /// </summary>
    public class XMLCopyScript
    {
        /// <summary>
        /// class structure of the script file object for the xml serialization
        /// </summary>
        public string copytopath;
        public XMLDirectoryObject[] directoryItems;

        public XMLCopyScript()
        {
            copytopath = string.Empty;
            directoryItems = null;
        }

        public XMLCopyScript(string copyPath)
        {
            copytopath = copyPath;
            directoryItems = null;
        }
    }
}
