using Ionic.Zip;
using System.IO;

namespace Suoja
{
    class SuojaCompression
    {

        public static void Compress(string[] content, string outputPath)
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (string file in content)
                {
                    zip.AddFile(file, "/");
                }
                FileStream stream = new FileStream(outputPath, FileMode.Create);
                zip.Save(stream);
                stream.Flush();
                stream.Dispose();
            }
        }

        public static void Extract(string file, string outputPath)
        {
            using (ZipFile zip = ZipFile.Read(file))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(outputPath, ExtractExistingFileAction.DoNotOverwrite);
                }
            }
        }

    }
}
