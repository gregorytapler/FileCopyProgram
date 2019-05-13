using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCopyProgram
{
    class Common
    {
        /// <summary>
        /// Copy options for overwrite
        /// </summary>
        public enum CopyOption
        {
            nooverwrite = 0,
            overwriteall,
            overwriteifnewer
        }

        /// <summary>
        /// Copy results
        /// </summary>
        public enum CopyResult
        {
            sourcedoesnotexists = 0,
            targetexists,
            samedate,
            targetisnewer,
            copygood,
            copyfail
        }

        //variable declaration
        public static string RootFolder = string.Empty;
        public static string TargetFolder = string.Empty;
        public static string Status1Text = string.Empty;
        public static string Status2Text = string.Empty;
        public static string Status3Text = string.Empty;
        
        public static int Counter_FilesLoaded = 0;
        public static int Counter_FilesToCopy = 0;
        public static int Counter_FilesCopied = 0;
        public static int ProgressBarMax = 0;
        public static int ProgressBarValue = 0;

        public static long BytesToCopy = 0;
        public static long BytesAvailable = 0;

        public static bool isCopying = false;
        public static bool abortOperations = true;
        public static bool operationsComplete = false;

        public static DateTime startCopy;

        //default copy option to no overwrite
        public static CopyOption copyOptions = CopyOption.nooverwrite;

        public static System.Threading.Thread workThread;
        
        /// <summary>
        /// reset the common variables to default values
        /// </summary>
        public static void resetCommonVariables()
        {
            RootFolder = string.Empty;
            TargetFolder = string.Empty;
            Status1Text = string.Empty;
            Status2Text = string.Empty;
            Status3Text = string.Empty;

            Counter_FilesLoaded = 0;
            Counter_FilesToCopy = 0;
            Counter_FilesCopied = 0;
            ProgressBarMax = 0;
            ProgressBarValue = 0;

            BytesToCopy = 0;
            BytesAvailable = 0;

            isCopying = false;
            abortOperations = true;
            operationsComplete = false;
        }

        /// <summary>
        /// get the color for the copy result
        /// </summary>
        /// <param name="resultOfCopy"></param>
        /// <returns></returns>
        public static System.Drawing.Color CopyResultColor(CopyResult resultOfCopy)
        {
            switch (resultOfCopy)
            {
                case CopyResult.copygood:
                    return System.Drawing.Color.Green;
                case CopyResult.samedate:
                case CopyResult.targetexists:
                    return System.Drawing.Color.Blue;
                case CopyResult.copyfail:
                case CopyResult.sourcedoesnotexists:
                case CopyResult.targetisnewer:
                    return System.Drawing.Color.Red;
                default:
                    return System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// get the string value for the copy result
        /// </summary>
        /// <param name="resultOfCopy"></param>
        /// <returns></returns>
        public static string CopyResultToString(CopyResult resultOfCopy)
        {
            switch (resultOfCopy)
            {
                case CopyResult.copyfail:
                    return "Copy failed";
                case CopyResult.sourcedoesnotexists:
                    return "Source file does not exist";
                case CopyResult.samedate:
                    return "Same date for target and source files";
                case CopyResult.targetisnewer:
                    return "Target file is newer than source file";
                case CopyResult.targetexists:
                    return "Target already exists";
                default:
                    return "Copy successful";
            }
        }
    }
}
