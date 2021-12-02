namespace Common.Services
{
    public class ContentBreaker<T> where T : class, new()
    {
        private readonly ILineContentMapper<T> lineContentMapper;

        public ContentBreaker(ILineContentMapper<T> lineContentMapper)
        {
            this.lineContentMapper = lineContentMapper;
        }

        public List<T> BreakIntoObject(List<string> listOfString)
        {
            return listOfString.Select(x => GetLineContent(x)).ToList();
        }

        private T GetLineContent(string content)
        {
            var splitted = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var lineContent = lineContentMapper.Map(splitted);

            return lineContent;
        }
    }
}
