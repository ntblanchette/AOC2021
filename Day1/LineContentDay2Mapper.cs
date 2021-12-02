using Common.Services;

namespace Day1
{
    public class LineContentDay1Mapper : ILineContentMapper<LineContentDay1>
    {
        public LineContentDay1 Map(string[] array)
        {
            var obj = new LineContentDay1
            {
                Depth = Convert.ToInt32(array[0])
            };

            return obj;
        }
    }
}
