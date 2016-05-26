using Ionic.Zip;
using System.IO;

namespace Suoja
{
    class SuojaCompression
    {

        public static void Compress(string[] content, string outputPath)
        {
            using (ZipFile zip = new ZipFile()) //Create a new archive
            {
                foreach (string file in content) 
                {
                    zip.AddFile(file, "/"); //Add the files
                }
                FileStream stream = new FileStream(outputPath, FileMode.Create); //Initialize a new FileStream for saving the archive
                zip.Save(stream); //Save
                stream.Flush(); //Complete the process
                stream.Dispose(); //Cleanup
            }
        }

        public static void Extract(string file, string outputPath)
        {
            using (ZipFile zip = ZipFile.Read(file))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(outputPath, ExtractExistingFileAction.DoNotOverwrite); //Extract all files
                }
            }
        }

    }
}
