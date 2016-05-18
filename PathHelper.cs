using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suoja
{
    public class PathHelper
    {
        public static string GetDirectory(string filepath)
        {
            return filepath.Substring(0, filepath.Length - filepath.Split('\\').Last().Length);
        }

        public static string GetFilename(string filepath)
        {
            return filepath.Split('\\').Last();
        }
    }
}
