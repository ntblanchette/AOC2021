using Common.Services;

namespace Day9
{
    public class LineContentDay9Mapper : ILineContentMapper<LineContentDay9>
    {
        public LineContentDay9 Map(string[] array)
        {
            var obj = new LineContentDay9
            {
                Numbers = array[0].Select(x => Convert.ToInt32(x.ToString())).ToList()
            };

            return obj;
        }
    }
}
