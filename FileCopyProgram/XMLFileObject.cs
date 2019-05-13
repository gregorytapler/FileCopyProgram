using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCopyProgram
{

    /// <summary>
    /// class structure of the file objects for the xml serialization
    /// </summary>
    public class XMLFileObject
    {
        public string fullpath;
        public int ischecked;

        public XMLFileObject()
        {
            fullpath = string.Empty;
            ischecked = 0;
        }
    }
}
