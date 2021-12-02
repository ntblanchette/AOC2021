namespace Common.IO
{
    public class ContentSplitter
    {
        public List<int> SplitIntoInt(string content)
        {
            var allStrings = content.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            return allStrings.Select(x => Convert.ToInt32(x)).ToList();
        }
    }
}
