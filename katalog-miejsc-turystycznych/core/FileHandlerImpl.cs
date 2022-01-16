using System.IO;

namespace core
{
    internal class FileHandlerImpl : FileHandler
    {
        string FileHandler.ReadFile(string filename)
        {
            string path = BuildFullPath(filename);
            return File.ReadAllText(path);
        }

        void FileHandler.WriteToFile(string filename, string content)
        {
            string path = BuildFullPath(filename);
            File.WriteAllText(path, content);
        }

        private static string BuildFullPath(string filename)
        {
            return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), filename);
        }
    }
}
