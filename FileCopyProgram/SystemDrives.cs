using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileCopyProgram
{
    class SystemDrives
    {
        /// <summary>
        /// return the available space for the given root directory
        /// </summary>
        /// <param name="rootDrive"></param>
        /// <returns></returns>
        public static long AvailableSpace(string rootDrive)
        {
            try
            {
                DriveInfo drInfo = new DriveInfo(rootDrive);
                if (drInfo != null)
                    return drInfo.TotalFreeSpace;
            }
            catch
            {
                return -1;
            }
            return -1;
        }
    }
}
