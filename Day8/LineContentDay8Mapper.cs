using Common.Services;

namespace Day8
{
    public class LineContentDay8Mapper : ILineContentMapper<LineContentDay8>
    {
        public LineContentDay8 Map(string[] array)
        {
            var firstPart = array.TakeWhile(x => x != "|");
            var secondPart = array.SkipWhile(x => x != "|").Skip(1);
            var obj = new LineContentDay8
            {
                SignalPaterns = firstPart.Select(x => x).ToList(),
                Digits = secondPart.Select(x => x).ToList(),
            };

            return obj;
        }
    }
}
