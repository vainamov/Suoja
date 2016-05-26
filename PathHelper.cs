using System.Linq;

namespace Suoja
{
    public class PathHelper
    {
        public static string GetDirectory(string filepath)
        {
            return filepath.Substring(0, filepath.Length - filepath.Split('\\').Last().Length); //Returns the Directory path of the given file
        }

        public static string GetFilename(string filepath)
        {
            return filepath.Split('\\').Last(); //Returns the filename itself without its path
        }
    }
}
