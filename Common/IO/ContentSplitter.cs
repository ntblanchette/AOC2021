namespace Common.IO
{
    internal class ContentSplitter
    {
        public List<string> SplitIntoStrings(string content)
        {
            var allStrings = content.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            return allStrings.ToList();
        }
    }
}
