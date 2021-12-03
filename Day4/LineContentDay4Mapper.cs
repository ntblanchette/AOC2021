using Common.Services;

namespace Day4
{
    public class LineContentDay4Mapper : ILineContentMapper<LineContentDay4>
    {
        public LineContentDay4 Map(string[] array)
        {
            if (array.Length == 1)
            {
                return new LineContentDay4() { Numbers = array.Single().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList() };
            }

            var obj = new LineContentDay4
            {
                Numbers = array.Select(x => Convert.ToInt32(x)).ToList()
            };

            return obj;
        }
    }
}
