namespace Common.IO
{
    public class FileReader
    {
        public string GetFileContent(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public List<string> GetFileContentAsList(string fileName)
        {
            var content = GetFileContent(fileName);

            var contentSplitter = new ContentSplitter();
            return contentSplitter.SplitIntoStrings(content);
        }
    }
}
