using System.IO;

namespace lab1.Entities
{
    public class Journal
    {
        private string writePath;

        public Journal(string path)
        {
            writePath = path;
        }

        public void Log(string msg)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            { 
                sw.WriteLine(msg);
            }
        }
    }
}