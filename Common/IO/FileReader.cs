namespace Common.IO
{
    public class FileReader
    {
        public string GetFileContent(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
