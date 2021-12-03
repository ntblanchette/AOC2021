namespace Common.IO
{
    public class ContentSplitter
    {
        public List<string> SplitIntoStrings(string content)
        {
            var allStrings = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return allStrings.ToList();
        }
    }
}
